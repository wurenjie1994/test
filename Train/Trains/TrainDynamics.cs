using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace Train.Trains
{
    
    public class TrainDynamics
    {
        #region 车辆参数变量
        //定义机车参数
        private double locomotiveWeight; //机车自重
        private double locomotiveLoad;//机车载重
        private double locomotiveLength;//机车长度
        private int locomotiveMotorNumber;//电机数量 
        //定义车辆参数
        private double trailerWeight; //拖车自重
        private double trailerLoad;//拖车载重
        private double trailerLength;//拖车长度
        //定义应答器天线位置
        private double leftAntennaLoc; // 列车左端应答器天线距左车头位置
        private double rightAntennaLoc;//列车右端应答器天线距右车头位置
        //定义阻力参数
        private double resistanceCoefficient_a;//阻力系数a
        private double resistanceCoefficient_b;//阻力系数b
        private double resistanceCoefficient_c;//阻力系数c
        //定义牵引参数
        private int tractionGrade;//牵引力等级
        private double tractionValue;//牵引力大小
        private double tractionVelocity;//牵引力对应速度
        //定义线路参数
        private double lineSlope = 0;//路线坡度
        private double lineCurveRadius = 10000000;//曲线半径
        //编组信息
        private int locomotiveNumber;//机车数量
        private int trailerNumber;//拖车数量
        private int totalLength;//列车总长度,单位mm
        //列车重量信息
        private double totalWeight;//总重量
        private double locomotiveWeights;//机车总重量
        private double trailerWeights;//拖车总重量
        private double g = 9.81;//重力加速度值

        //牵引力-速度数组
        private double[] Vt = new double[20];
        private double[] Ft = new double[20];
        private int numberOfTraction;
        //制动力—速度数组
        private double[] Vb = new double[20];
        private double[] Fb = new double[20];
        private int numberOfBrake;
        //加速度与电流值对应关系
        private Dictionary<double, double> accDict = new Dictionary<double, double>();
        private Dictionary<double, double> accDict_TST = new Dictionary<double, double>();//TST
        #endregion
        //当前列车运行信息
        private double currentV = 0;//当前速度
        private double currentA = 0;//当前加速度
        private double currentS1 = 0;//当前右车头距离
        private double currentS0 = 0;//当前左车头距离
        private double prevS1, prevS0; //100ms前的位置
        private double displacement = 0; //总位移
        public double delT = 0.1;//时间步长

        public  const double LINE_LENGTH = 80 * 1000;//线路总长度
        Tracklet currentLeftTracklet , currentRightTracklet ;
        private List<int> trackletList = new List<int>();//当前列车所占的区段，以左车头到右车头的顺序放置
        private double deltaS = 0;

        // 下面List是线路的数据，存放trackletID
        public List<int> traceletInfo = new List<int>();

        public TrainDynamics()
        {
            Tracklet.Init();
            Switchlet.Init();
            InitialTrainDynamics();
        }
        //初始化列车
        public void InitialTrainDynamics()
        {
            string currentDirectory = System.IO.Directory.GetCurrentDirectory();
            currentDirectory = currentDirectory + "\\VehicleConfig.xml";
             GetParamersFromXML(currentDirectory);
            CaculateWeight();
           currentS1 = currentS0 + totalLength / 1000;
            currentLeftTracklet = currentRightTracklet = Tracklet.GetTracklet(5);
        }
        //初始化时从XML中读取列车配置参数信息
        private void GetParamersFromXML(string InfoPath)
        {
            XmlDocument xmlDoc = new XmlDocument();//读取XML中车辆配置信息
            XmlElement root = null, locomotive = null, antennaLoc=null,trailer = null,
                resistance = null, organization = null, traction = null, brake = null,acc=null,acc_tst=null;
            string currentDirectory = InfoPath;

            xmlDoc.Load(currentDirectory);
            root = xmlDoc.DocumentElement;

            locomotive = (XmlElement)root.SelectSingleNode("/VehicleConfig/Locomotive");
            locomotiveWeight = double.Parse(locomotive.Attributes["weight"].Value);//string 转换为double 
            locomotiveLoad = double.Parse(locomotive.Attributes["load"].Value);
            locomotiveLength = double.Parse(locomotive.Attributes["length"].Value);
            locomotiveMotorNumber = int.Parse(locomotive.Attributes["motornumber"].Value);

            trailer = (XmlElement)root.SelectSingleNode("/VehicleConfig/Trailer");
            trailerWeight = double.Parse(trailer.Attributes["weight"].Value);
            trailerLoad = double.Parse(trailer.Attributes["load"].Value);
            trailerLength = double.Parse(trailer.Attributes["length"].Value);

            antennaLoc = (XmlElement)root.SelectSingleNode("/VehicleConfig/BeaconAntennaLoc");
            leftAntennaLoc = double.Parse(antennaLoc.Attributes["disFromLeftHead"].Value) / 1000;
            rightAntennaLoc = double.Parse(antennaLoc.Attributes["disFromRightHead"].Value) / 1000;

            resistance = (XmlElement)root.SelectSingleNode("/VehicleConfig/Resistance");
            resistanceCoefficient_a = double.Parse(resistance.Attributes["coefficientA"].Value);
            resistanceCoefficient_b = double.Parse(resistance.Attributes["coefficientB"].Value);
            resistanceCoefficient_c = double.Parse(resistance.Attributes["coefficientC"].Value);

            organization = (XmlElement)root.SelectSingleNode("/VehicleConfig/Organization");
            locomotiveNumber = int.Parse(organization.Attributes["locomotivenumber"].Value);
            trailerNumber = int.Parse(organization.Attributes["trailernumber"].Value);
            totalLength = int.Parse(organization.Attributes["totalLength"].Value);

            traction = (XmlElement)root.SelectSingleNode("/VehicleConfig/Traction");//牵引力
            numberOfTraction = int.Parse(traction.Attributes["number"].Value);
            for (int i = 0; i < numberOfTraction; i++)
            {
                Vt[i] = double.Parse(traction.ChildNodes[i].Attributes["velocity"].Value);
                Ft[i] = double.Parse(traction.ChildNodes[i].Attributes["traction"].Value);
            }

            brake = (XmlElement)root.SelectSingleNode("/VehicleConfig/Brake");
            numberOfBrake = int.Parse(brake.Attributes["number"].Value);
            for (int i = 0; i < numberOfBrake; i++)
            {
                Vb[i] = double.Parse(brake.ChildNodes[i].Attributes["velocity"].Value);
                Fb[i] = double.Parse(brake.ChildNodes[i].Attributes["brake"].Value);
            }
            XmlNodeList accList = root.SelectNodes("/VehicleConfig/Acceleration");
            for(int j=0;j<accList.Count;j++)
            {
                acc = (XmlElement)accList[j];
                if(acc.GetAttribute("type").Equals("CSC"))
                {
                    int num = int.Parse(acc.Attributes["number"].Value);
                    for (int i = 0; i < num; i++)
                    {
                        double c = double.Parse(acc.ChildNodes[i].Attributes["normI"].Value);
                        accDict[c] = double.Parse(acc.ChildNodes[i].Attributes["a"].Value);
                    }
                    //按Key值升序排序
                    accDict = accDict.OrderBy(p => p.Key).ToDictionary(p => p.Key, o => o.Value);
                }
                if(acc.GetAttribute("type").Equals("TST"))
                {
                    acc_tst = acc;
                    int num_tst = int.Parse(acc_tst.Attributes["number"].Value);
                    for (int i = 0; i < num_tst; i++)
                    {
                        double c = double.Parse(acc_tst.ChildNodes[i].Attributes["normI"].Value);
                        accDict_TST[c] = double.Parse(acc_tst.ChildNodes[i].Attributes["a"].Value);
                    }
                    accDict_TST = accDict_TST.OrderBy(p => p.Key).ToDictionary(p => p.Key, o => o.Value);
                }
            }
                       
        }
        //初始化时列车质量计算公式
        private void CaculateWeight()
        {
            locomotiveWeights = locomotiveNumber * (locomotiveWeight + locomotiveLoad);//机车总质量
            trailerWeights = trailerNumber * (trailerWeight + trailerLoad);//车辆总质量
            totalWeight = trailerWeights + locomotiveWeights;//总质量 
            double totalLoad = locomotiveLoad * locomotiveNumber + trailerNumber * trailerLoad;
        }

        //外部其他模块调用本模块的函数
        //传出：速度、加速度、经过路程
        public void OperatingVehicle(bool isLeftHead, DriverConsolerState driverConsoler,TrainState trainState)
        {
            bool EBStatus = driverConsoler.EBStatus;
            bool FullServiceStatus = false, FastBrake = false;
            bool b1 =trainState.BManualSpeed, b2=trainState.BManualAccSpeed;
            DriveDirection driveDirection = driverConsoler.DriveDirection;
            double steerValue =MapSteerToCurrent(driverConsoler.SteerValue);
            double distance=CountTrain(EBStatus, FullServiceStatus, FastBrake, isLeftHead, b1,b2,currentV,currentA, driveDirection, steerValue);
            #region 计算列车位置
            prevS0 = currentS0;
            prevS1 = currentS1;
              CalTrainLocation(distance);
            {
                trainState.Speed = currentV;
                trainState.AccSpeed = currentA;
                trainState.TrainLocation.LeftLoc = currentS0;
                trainState.TrainLocation.RightLoc = currentS1;
                trainState.BrakeStatus = EBStatus || (steerValue < 0);
                trainState.EBStatus = EBStatus;
            }

            #endregion

        }

        private void CalTrainLocation(double distance)
        {
            currentS0 += distance;
            currentS1 += distance;
            if (currentS0 < 0)
            {
                currentS0 = 0;currentS1 = currentS0 + totalLength / 1000;
                currentV = currentA = 0;
            }
            if (currentS1 > LINE_LENGTH)
            {
                currentS1 = LINE_LENGTH; currentS0 = currentS1 - totalLength / 1000;
                currentV = currentA = 0;
            }
        }

        /* 
        private void CalTrainLocation(double distance)
        {
            if (currentLeftTracklet == null||currentRightTracklet==null) return;
            if (distance <= 0)     //向左行驶
            {
                Tracklet.LeftWard = true;
                double disNotMove = 0;  //由于列车到达了线路端点而没有走行的距离
                currentS0 += distance;
                while (currentS0 < 0)
                {
                    Tracklet next = currentLeftTracklet.GetNext();
                    if (next==null)    //数组越界
                    {
                        currentV = currentA = 0;
                        disNotMove = currentS0;
                        currentS0 = 0; //将车停在最左端
                        break;
                    }
                    currentS0 += next.TrackletLength;
                    currentLeftTracklet = next;
                }
                //求出车右端的SegmentID与offset
                currentS1 += distance-disNotMove;
                while (currentS1<0)  //向左行驶时应该不用考虑右端越界
                {
                    Tracklet next = currentRightTracklet.GetNext();
                    if(next == null) { break; }
                    currentS1 += next.TrackletLength;
                    currentRightTracklet = next;
                }
            }
            else                  //向右行驶，使用右端车计算简单些
            {
                Tracklet.LeftWard = false;
                double disNotMove = 0;
                currentS1 += distance;
                while (currentS1 >= currentRightTracklet.TrackletLength)
                {
                    currentS1 -= currentRightTracklet.TrackletLength;
                    Tracklet next = currentRightTracklet.GetNext();
                    if (next == null)   //数组越界
                    {
                        currentV = currentA = 0;
                        disNotMove = currentS1;    //本该走行但由于到达端点而没有走行的距离
                        currentS1 = currentRightTracklet.TrackletLength;          //将车停在最右端
                        break;
                    }
                    currentRightTracklet = next;
                }
                //求出端车A的SegmentID与offset
                currentS0 += distance-disNotMove;
                while (currentS0 >= currentLeftTracklet.TrackletLength)            //同理，向右行驶应该不用考虑左端越界
                {
                    currentS0 -= currentLeftTracklet.TrackletLength;
                    Tracklet next = currentLeftTracklet.GetNext();
                    if (next == null) { break; }    //数据出错
                    currentLeftTracklet = next;
                }
            }
        }
      */
        /// <summary>
        /// 获取列车当前覆盖的tracklet
        /// 之前是用来查找经过的应答器的，目前暂时用不着
        /// </summary>
        private bool GetTrackletsTrainCovered(int n, int[] A, Tracklet tracklet)
        {
            A[n] = tracklet.Id;
            if(tracklet.Id == currentRightTracklet.Id)
            {
                trackletList.Clear();
                for (int i = 0; i <= n; i++) trackletList.Add(A[i]);
                return true;
            }
            if (tracklet.Location1 > currentRightTracklet.Location1) return false;//剪枝
            if (tracklet.RightType == _TrackletType.ORDINARY)
            {
                return GetTrackletsTrainCovered(n + 1, A, Tracklet.GetTracklet(tracklet.RightIndex));
            }
            else if (tracklet.RightType == _TrackletType.DC)
            {
                Switchlet s = Switchlet.GetSwitchlet(tracklet.RightIndex);
                if (tracklet.Id == s.TrackletID1)
                {
                    if (GetTrackletsTrainCovered(n + 1, A, Tracklet.GetTracklet(s.TrackletID2))) return true;
                    return GetTrackletsTrainCovered(n + 1, A, Tracklet.GetTracklet(s.TrackletID3));
                }
                else //if (tracklet.Id == s.TrackletID3)
                    return GetTrackletsTrainCovered(n + 1, A, Tracklet.GetTracklet(s.TrackletID1));
            }
            return false;
        }



        //根据当前速度、牵引制动状态以及牵引制动等级计算出下一个时刻的速度，返回行驶的距离
        private double CountTrain(bool EBstatus, bool FullServiceStatus, bool FastBrake, bool isLeftHead, 
            bool bManualSpeed,bool bManualAccSpeed,double velocity, double acc,  
            DriveDirection driveDirection, double steerValue)
        {
            double a;
            if(EBstatus)          //紧急制动时，手动改的值无效
            {
                a = CalculateAcceleration(EBstatus, FullServiceStatus, FastBrake, velocity, isLeftHead, driveDirection, steerValue);
                currentV = a * delT + velocity;                     //时间步长后的速度   
            }
            else
            {
                if(bManualSpeed&&bManualAccSpeed)
                {
                    a = acc;currentV = velocity;
                }
                else if(bManualSpeed && !bManualAccSpeed)
                {
                    a= CalculateAcceleration(EBstatus, FullServiceStatus, FastBrake, velocity, isLeftHead, driveDirection, steerValue);
                    currentV = velocity;
                }
                else if(!bManualSpeed && bManualAccSpeed)
                {
                    a = acc;
                    currentV = a * delT + velocity;
                }
                else
                {
                    a = CalculateAcceleration(EBstatus, FullServiceStatus, FastBrake, velocity, isLeftHead, driveDirection, steerValue);
                    currentV = a * delT + velocity;                 
                }
            }
                
            if(EBstatus && velocity==0)
            {
                currentV = 0;a = 0;
            }
            if ((velocity == 0) && (steerValue > 0) && (CalculateTraction(0, steerValue) < CalculateResistance(0))) //列车静止
            {
                currentV = 0;
                a = 0;
            }
            else if ((currentV >= 0) && (velocity < 0) || ((currentV <= 0) && (velocity > 0)))  //
            {
                if ((a >= 0) && (velocity < 0))
                {
                    if ((isLeftHead == true) && (steerValue > 0))
                    {
                        if (CalculateTraction(-velocity, steerValue) < CalculateResistance(-velocity))
                        {
                            currentV = 0;
                            a = 0;
                        }
                    }
                }
                else if ((a <= 0) && (velocity > 0))
                {
                    if ((isLeftHead == false) && (steerValue > 0))
                    {
                        if (CalculateTraction(velocity, steerValue) < CalculateResistance(velocity))
                        {
                            currentV = 0;
                            a = 0;
                        }
                    }
                }
                if ((steerValue <= 0)  || (EBstatus ) || (FullServiceStatus ) || (FastBrake))
                {
                    currentV = 0;
                }
            }

            currentA = a;
            double distanceRun = 0.5 * a * delT * delT + velocity * delT;
            deltaS = distanceRun;
            displacement += distanceRun;
            return distanceRun;
        }

        //不同状态下加速度计算
        //steerValue：牵引制动等级，从0到1表示不同档位。
        private double CalculateAcceleration(bool EBstatus, bool FullServiceStatus, bool FastBrake, double velocity, bool isLeftHead, DriveDirection driveDirection, double steerValue)
        {
            double a = 0;
            int vDirection = 0; //速度方向
            if (velocity != 0) vDirection = velocity>0?1:-1;  
            if (EBstatus || FastBrake || FullServiceStatus) //制动状态
            {
                if (velocity != 0) a = vDirection * GetAcceleration(-1);//减速时，加速度方向保持与速度方向相反
                return a;
            }
            if (isLeftHead == true)
            {
                if (driveDirection == DriveDirection.RMF)//向前
                {
                    if (steerValue >= 0)
                    {
                        a = -GetAcceleration(steerValue);
                    }
                    else 
                    {
                        a = vDirection * GetAcceleration(steerValue);
                    }
                }
                else if (driveDirection == DriveDirection.ZERO) //空挡
                {
                    a = CalculateResistance(velocity * 3.6) / totalWeight;
                }
                else if (driveDirection == DriveDirection.RMR)//向后
                {
                    if (steerValue >= 0)
                    {
                        a = GetAcceleration(steerValue);
                    }
                    else
                    {
                        a = vDirection * GetAcceleration(steerValue);
                    }
                }
            }
            else//右车头
            {
                if (driveDirection == DriveDirection.RMF)
                {
                    if (steerValue >= 0)
                    {
                        a = GetAcceleration(steerValue);
                    }
                    else
                    {
                        a = vDirection * GetAcceleration(steerValue);
                    }
                }
                else if (driveDirection == DriveDirection.ZERO)
                {
                    a = CalculateResistance(velocity * 3.6) / totalWeight;
                }
                else if (driveDirection == DriveDirection.RMR)
                {
                    if (steerValue >= 0)
                    {
                        a = -GetAcceleration(steerValue);
                    }
                    else
                    {
                        a = vDirection * GetAcceleration(steerValue);
                    }
                }
            }
            return a;
        }

      
        private double CalculateTraction(double _v, double _tractionGrade)
        {
            double v = Math.Abs(_v);
            double l1 = numberOfTraction;
            double tractionGrade = _tractionGrade;

            for (int i = 0; i < l1; i++)
            {
                if (v >= Vt[i] && v < Vt[i + 1])
                    tractionValue = InterpolationCount(Vt[i], Vt[i + 1], Ft[i], Ft[i + 1], v)
                        * locomotiveNumber * locomotiveMotorNumber;//牵引力（单位KN）
            }
            if (v <= Vt[0])
                tractionValue = Ft[0] * locomotiveNumber * locomotiveMotorNumber;
            tractionValue = tractionValue * tractionGrade;
            return tractionValue;
        }

        //制动力计算函数，给出速度算出制动力大小，制动力方向总是与速度方向相反
        private double CalculateBrake(double _v, double brakeGrade)
        {
            if (_v == 0) return 0;
            double v = Math.Abs(_v);
            double l1 = numberOfBrake,brakeValue=0;
            for (int i = 0; i < l1; i++)
            {
                if (v >= Vb[i] && v <= Vb[i + 1])
                    brakeValue = InterpolationCount(Vb[i], Vb[i + 1], Fb[i], Fb[i + 1], v);//制动力（单位KN）
            }
            if (v <= Vb[0])
                brakeValue = Fb[0];
            brakeValue = brakeValue * brakeGrade;
            return (-v/_v)*brakeValue;

        }
        //插值计算函数
        private double InterpolationCount(double V1, double V2, double F1, double F2, double v)
        {
            return ((F2 - F1) / (V2 - V1)) * (v - V1) + F1;
        }
        //阻力计算函数，阻力方向总是与速度方向相反
        private double CalculateResistance(double _v)
        {
            if (Math.Abs(_v )<1e-6) return 0;  //这个不太准确，暂且这样
            double v = Math.Abs(_v);
            double resistanceValue = (resistanceCoefficient_a + resistanceCoefficient_b * v +
                resistanceCoefficient_c * v * v + lineSlope + 600 / lineCurveRadius) * totalWeight * g * 0.001;
            return (-v/_v)*resistanceValue;
        }
        
        private double GetAcceleration(double normI)
        {
            return GetAcceleration(normI, accDict);
        }
        private double GetAcceleration(double normI,Dictionary<double,double> dict)
        {
            double min=dict.Keys.Min(), max=dict.Keys.Max();
            if (normI <= min) return dict[min];
            if (normI >= max) return dict[max];
            foreach(double e in dict.Keys)
            {
                if (normI < e)
                {
                    max = e; break;
                }
                else min = e;
            }
            return InterpolationCount(min, max, dict[min], dict[max], normI);
        }
        /// <summary>
        /// 将驾驶台司控器的值转换为对应的电流值
        /// </summary>
        /// <param name="steer"></param>
        /// <returns></returns>
        public double MapSteerToCurrent(double steer)
        {
            double c = 0;
            if (steer > 0) c = 0.07 * steer + 0.2;
            else if (steer < 0) c = 0.07 * steer - 0.2;
            return c;//根据VehicleConfig中电流值与加速度的关系转换
        }
    }
}
