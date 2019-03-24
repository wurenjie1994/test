using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Train
{
    public enum _WorkMode
    {
        FS=0,///完全监控模式
        CO=1,//引导模式
        OS=2,//目视行车模式
        SH=3,//调车模式
        SL=5,//休眠模式
        SB=6,//待机模式
        IS=10,//隔离模式
        TR=7,//冒进防护模式
        PT=8,//冒进后防护模式
    }
    public enum _ControlLevel
    {
        CTCS_0=0,
        STM=1,
        CTCS_1=2,
        CTCS_2=3,
        CTCS_3=4
    }
    public enum DriveDirection : byte
    {
        RMF = 0x01,                //RMF（向前）
        ZERO = 0x02,             //0
        RMR = 0x00               //RMR（向后）
    }
    public class DriverConsolerState
    {
        private static DriverConsolerState driverConsolerA = new DriverConsolerState(true );
        private static DriverConsolerState driverConsolerB = new DriverConsolerState(true );
        private static  DriverConsolerState NULL = new DriverConsolerState(false);
        private DriverConsolerState(bool active)
        {
            CabActive = active;
        }
        public static DriverConsolerState GetDriverConsolerA() { return driverConsolerA; }
        public static DriverConsolerState GetDriverConsolerB() { return driverConsolerB; }
        public static DriverConsolerState GetNULL() { return NULL; }
        /// <summary>
        /// 本意是想防止状态切换后，变量状态与界面显示状态不一致的情形
        /// 但这样做会导致使用三个实例分别保存三种状态没有意义。。。
        /// </summary>
        /// <param name="dcs">驾驶台上次状态</param>
        /// <returns></returns>
        public DriverConsolerState CopyOf(DriverConsolerState dcs)
        {
            if (dcs == null) return null;
            driveDirection = dcs.driveDirection;
            steerValue = dcs.steerValue;
            eBStatus = dcs.eBStatus;
            return this;
        }
        bool cabActive;
        DriveDirection driveDirection;
        double steerValue;
        bool eBStatus;
        _WorkMode workMode;
        _ControlLevel controlLevel;

        public bool CabActive
        {
            get
            {
                return cabActive;
            }

            set
            {
                cabActive = value;
            }
        }

        public DriveDirection DriveDirection
        {
            get
            {
                return driveDirection;
            }

            set
            {
                driveDirection = value;
            }
        }

        public double SteerValue
        {
            get
            {
                return steerValue;
            }

            set
            {
                steerValue = value;
            }
        }

        public bool EBStatus
        {
            get
            {
                return eBStatus;
            }

            set
            {
                eBStatus = value;
            }
        }

        public _WorkMode WorkMode
        {
            get
            {
                return workMode;
            }

            set
            {
                workMode = value;
            }
        }

        public _ControlLevel ControlLevel
        {
            get
            {
                return controlLevel;
            }

            set
            {
                controlLevel = value;
            }
        }
    }
    public class TrainState
    {
        double speed, accSpeed;
        bool bManualSpeed;
        bool bManualAccSpeed;
        bool brakeStatus, eBStatus;
        bool trainIntegrity;
        TrainLocation trainLocation = new TrainLocation();

        public double Speed
        {
            get
            {
                return speed;
            }

            set
            {
                speed = value;
            }
        }

        public double AccSpeed
        {
            get
            {
                return accSpeed;
            }

            set
            {
                accSpeed = value;
            }
        }

        public bool BManualSpeed
        {
            get
            {
                return bManualSpeed;
            }

            set
            {
                bManualSpeed = value;
            }
        }

        public bool BManualAccSpeed
        {
            get
            {
                return bManualAccSpeed;
            }

            set
            {
                bManualAccSpeed = value;
            }
        }

        public bool BrakeStatus
        {
            get
            {
                return brakeStatus;
            }

            set
            {
                brakeStatus = value;
            }
        }

        public bool EBStatus
        {
            get
            {
                return eBStatus;
            }

            set
            {
                eBStatus = value;
            }
        }

        public TrainLocation TrainLocation
        {
            get
            {
                return trainLocation;
            }

            set
            {
                trainLocation = value;
            }
        }

        public bool TrainIntegrity
        {
            get
            {
                return trainIntegrity;
            }

            set
            {
                trainIntegrity = value;
            }
        }
    }
    public class TrainLocation
    {
        private double leftLoc;  //列车左端位置，以米为单位
        private double rightLoc;//列车右端位置

        public static String LocToString(double loc)
        {
            return String.Format("K{0}+{1:f2}", (int)(loc / 1000), loc % 1000);
        }

        public double LeftLoc
        {
            get
            {
                return leftLoc;
            }

            set
            {
                leftLoc = value;
            }
        }

        public double RightLoc
        {
            get
            {
                return rightLoc;
            }

            set
            {
                rightLoc = value;
            }
        }
    }
}
