using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;
using Train.Trains;
using System.Text;

namespace Train
{
    public partial class MainForm : Form
    {
        private DriverConsolerState driverConsoler = DriverConsolerState.GetNULL();
        private Communication comm = null;

        public MainForm()
        {
            InitializeComponent();
        }
        private void MainForm_Load(object sender, EventArgs e)
        {
            StartTrain();
            StartComm();
        }

        private void rbCabChoose_CheckedChanged(object sender, EventArgs e)
        {
            String name = ((RadioButton)sender).Name;
            DriverConsolerState lastState = driverConsoler;
            if (name.Equals("rbCabA"))
                driverConsoler = DriverConsolerState.GetDriverConsolerA().CopyOf(lastState);
            else if (name.Equals("rbCabB"))
                driverConsoler = DriverConsolerState.GetDriverConsolerB().CopyOf(lastState);
            else driverConsoler = DriverConsolerState.GetNULL().CopyOf(lastState);
        }

        private void rbDirectionChoose_CheckedChanged(object sender, EventArgs e)
        {
            String name = ((RadioButton)sender).Name;
            if (name.Contains("Forward"))
                driverConsoler.DriveDirection = DriveDirection.RMF;
            else if (name.Contains("Backward"))
                driverConsoler.DriveDirection = DriveDirection.RMR;
            else driverConsoler.DriveDirection = DriveDirection.ZERO;
        }

        private void btnEBButton_Click(object sender, EventArgs e)
        {
            bool b = !driverConsoler.EBStatus;
            driverConsoler.EBStatus = b;
            btnEBButton.BackColor = b ? Color.Red : Control.DefaultBackColor;
        }

        private void trackBarSteer_Scroll(object sender, EventArgs e)
        {
            driverConsoler.SteerValue = trackBarSteer.Value - 10;
        }

        #region 列车运动模块
        private TrainState trainState = new TrainState();
        private Thread trainDynamicThread;
        private TrainDynamics trainDynamic;

        //列车界面更新线程
        private Thread updateVehicleInterfaceThread;
        public void StartTrain()
        {
            trainDynamic = new TrainDynamics();
            //列车运动线程
            trainDynamicThread = new Thread(TrainDynamicFun);
            trainDynamicThread.IsBackground = true;
            trainDynamicThread.Start();
            trainDynamicThread.Priority = ThreadPriority.Highest;
            //列车界面更新线程
            updateVehicleInterfaceThread = new Thread(UpdateVehicleInterfaceFun);
            updateVehicleInterfaceThread.IsBackground = true;
            updateVehicleInterfaceThread.Start();
        }
        public void TrainDynamicFun()
        {
            DriveDirection driveDirection;
            bool islefthead = false;
            double steerValue = 0;
            while (true)
            {
                if (driverConsoler == DriverConsolerState.GetNULL())
                {
                    Thread.Sleep(100);
                    continue;
                }
                islefthead = (driverConsoler == DriverConsolerState.GetDriverConsolerA());
                driveDirection = driverConsoler.DriveDirection;
                steerValue = driverConsoler.SteerValue;
                //  计算列车运动参量的函数
                if (trainDynamic != null)
                    trainDynamic.OperatingVehicle(islefthead, driverConsoler, trainState);
                Thread.Sleep(100);
            }
        }

        public delegate void UpdateVehicleInterfaceEventHandler();
        public event UpdateVehicleInterfaceEventHandler updateVehicleInterface;
        public void UpdateVehicleInterface()
        {
            #region 速度、加速度
            if (true)
            {
                bool b1 = cbManualSpeed.Checked, b2 = cbManualAccSpeed.Checked;
                nudSpeed.Enabled = cbManualSpeed.Checked;
                nudAccSpeed.Enabled = cbManualAccSpeed.Checked;
                trainState.BManualSpeed = cbManualSpeed.Checked;
                trainState.BManualAccSpeed = cbManualAccSpeed.Checked;
                if (b1)
                {
                    trainState.Speed = Convert.ToDouble(nudSpeed.Value) / 3.6;
                }
                else
                    nudSpeed.Value = Convert.ToDecimal((trainState.Speed * 3.6).ToString("f3"));
                if (b2)
                {
                    trainState.AccSpeed = Convert.ToDouble(nudAccSpeed.Value);
                }
                else
                    nudAccSpeed.Value = Convert.ToDecimal(trainState.AccSpeed.ToString("f3"));
            }
            #endregion

            //EB状态
            if (trainState.EBStatus)
            {
                this.lblEBStatus.Text = "是";
                this.lblEBStatus.ForeColor = Color.Red;
            }
            else
            {
                this.lblEBStatus.Text = "否";
                this.lblEBStatus.ForeColor = Color.Black;
            }
            //制动状态
            if (trainState.BrakeStatus)
            {
                this.lblBrakeStatus.Text = "是";
                this.lblBrakeStatus.ForeColor = Color.Red;
            }
            else
            {
                this.lblBrakeStatus.Text = "否";
                this.lblBrakeStatus.ForeColor = Color.Black;
            }
            //列车完整性
            trainState.TrainIntegrity = this.chkBoxTrainIntegrity.Checked;
            //列车位置
            this.lblLeftSegID.Text = trainState.TrainLocation.LeftSegmentID.ToString();
            this.lblLeftSegOffset.Text = (trainState.TrainLocation.LeftSegmentOffset).ToString("f2");
            this.lblRightSegID.Text = trainState.TrainLocation.RightSegmentID.ToString();
            this.lblRightSegOffset.Text = (trainState.TrainLocation.RightSegmentOffset).ToString("f2");
        }
        public void UpdateVehicleInterfaceFun()
        {
            updateVehicleInterface += UpdateVehicleInterface;
            while (true)
            {
                this.BeginInvoke(updateVehicleInterface);
                Thread.Sleep(100);
            }

        }

        #endregion


        public void StartComm()
        {
            string fileName = System.IO.Directory.GetCurrentDirectory() + "\\CommConfig.ini";
            if (comm == null)
                comm = new Communication(fileName);
            comm.Init();
            comm.Connect(_CommType.RBC);
            StartRecvMsgModule();
        }

        #region 收包模块    
        private Thread fromLineSimThread, fromRBCThread;
        public void StartRecvMsgModule()
        {

            if (fromLineSimThread == null)
            {
                fromLineSimThread = new Thread(RecvFromLineSim);
                fromLineSimThread.IsBackground = true;
                fromLineSimThread.Start();
            }

            if (fromRBCThread == null)
            {
                fromRBCThread = new Thread(RecvFromRBC);
                fromRBCThread.IsBackground = true;
                fromRBCThread.Start();
            }
        }
        public void RecvFromLineSim()
        {
            while (true)
            {
                try
                {
                    byte[] receiveData = comm.RecvMsg(_CommType.LINESIM);
                    if (receiveData != null && receiveData.Length > 8)
                    {

                    }
                }
                catch (System.Net.Sockets.SocketException)
                {

                }
                catch (Exception)
                { }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string sendString = Convert.ToString(textBox1.Text);//要发送的字符串
            byte[] sendData = null;//要发送的字节数组

            sendData = Encoding.Default.GetBytes(sendString);//获取要发送的字节数组

            comm.SendMsg(sendData, _CommType.RBC);
        }

        public void RecvFromRBC()
        {
            while (true)
            {
                try
                {
                    byte[] receiveData = comm.RecvMsg(_CommType.RBC);
                    if (receiveData != null)
                        MessageBox.Show(receiveData.ToString());
                }
                catch (System.Net.Sockets.SocketException)
                {
                }
                catch (Exception) { }
            }
        }

        #endregion


    }
}
