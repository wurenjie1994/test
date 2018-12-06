using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;
using Train.Trains;
using System.Text;
using Train.Utilities;
using Train.ShowMsg;
using Train.Messages;

namespace Train
{
    public partial class MainForm : Form
    {
        private DriverConsolerState driverConsoler = DriverConsolerState.GetNULL();
        private CircularQueue<ListViewContent> recvMsgQueue = new CircularQueue<ListViewContent>();
        private CircularQueue<ListViewContent> sendMsgQueue = new CircularQueue<ListViewContent>();

        public MainForm()
        {
            InitializeComponent();
        }
        private void MainForm_Load(object sender, EventArgs e)
        {
            StartTrain();
            StartComm();
        }
        #region 菜单项
        private void ConnectTSMI_Click(object sender, EventArgs e)
        {
            if (sender == rBCToolStripMenuItem)
            {
                Communication.Connect(_CommType.RBC);
                StartRecvMsgModule(_CommType.RBC);
            }
            else if (sender == nRBCToolStripMenuItem)
            {
                Communication.Connect(_CommType.NRBC);
                StartRecvMsgModule(_CommType.NRBC);
            }
        }

        private void DisconnectTSMI_Click(object sender, EventArgs e)
        {
            if (sender == disRBCToolStripMenuItem) Communication.Disconnect(_CommType.RBC);
            else if (sender == disNRBCToolStripMenuItem) Communication.Disconnect(_CommType.NRBC);
            MessageBox.Show("要经过2MSL时间（约2分钟）后才能再次发起连接！");
        }

        #endregion

        #region 主界面
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
        #endregion

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
            this.lblTrainLeftLoc.Text = TrainLocation.LocToString(trainState.TrainLocation.LeftLoc);
            this.lblTrainRightLoc.Text = TrainLocation.LocToString(trainState.TrainLocation.RightLoc);
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
            Communication.Init(fileName);
        }

        #region 收包模块    
        private Thread fromNRBCThread, fromRBCThread;
        public void StartRecvMsgModule(_CommType commType)
        {
            updateListView += UpdateListView;
            if (commType == _CommType.NRBC && fromNRBCThread == null)
            {
                fromNRBCThread = new Thread(RecvFromNRBC);
                fromNRBCThread.IsBackground = true;
                fromNRBCThread.Start();
            }
            
            if (commType == _CommType.RBC && fromRBCThread == null)
            {
                fromRBCThread = new Thread(RecvFromRBC);
                fromRBCThread.IsBackground = true;
                fromRBCThread.Start();
            }
        }
        public void RecvFromNRBC()
        {
            while (true)
            {
                try
                {
                    byte[] recvData = Communication.RecvMsg(_CommType.NRBC);
                    if (recvData == null || recvData.Length==0) continue;
                    AbstractRecvMessage arm = AbstractRecvMessage.GetMessage(recvData);
                    ListViewContent lvc = new ListViewContent(DateTime.Now,arm.NID_MESSAGE,_CommType.NRBC,arm);
                    this.BeginInvoke(updateListView, lvRecvMsg, recvMsgQueue, lvc);
                }
                catch (Exception)
                { }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string sendString = Convert.ToString(123);//要发送的字符串
            byte[] sendData = null;//要发送的字节数组

            sendData = Encoding.Default.GetBytes(sendString);//获取要发送的字节数组

            Communication.SendMsg(sendData, _CommType.NRBC);
        }

        public void RecvFromRBC()
        {
            while (true)
            {
                try
                {
                    byte[] recvData = Communication.RecvMsg(_CommType.RBC);
                    if (recvData == null) continue;
                    AbstractRecvMessage arm = AbstractRecvMessage.GetMessage(recvData);
                    ListViewContent lvc = new ListViewContent(DateTime.Now, arm.NID_MESSAGE, _CommType.RBC, arm);
                    this.BeginInvoke(updateListView, lvRecvMsg, recvMsgQueue, lvc);
                }
                catch (Exception) { }
            }
        }
        private void ListView_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            ListView listView = (ListView)sender;
            int index = listView.SelectedItems[0].Index;
            if(sender == lvRecvMsg)
            {
                AbstractRecvMessage arm = recvMsgQueue.IndexOf(index).Arm;
                new ShowMsgForm(arm.ToString());
            }
        }

        private delegate void UpdateListViewEventHandler(ListView lv, CircularQueue<ListViewContent> q, ListViewContent lvc);
        private event UpdateListViewEventHandler updateListView; 
        private void UpdateListView(ListView listView, CircularQueue<ListViewContent> queue,ListViewContent lvc)
        {
            if (lvc == null) return;
            listView.BeginUpdate();
            if (queue.IsFull() == false)
            {
                queue.Push(lvc);
                listView.Items.Add(GetItem(lvc));
            }
            else
            {
                listView.Items.Clear();
                queue.Pop();
                queue.Push(lvc);
                queue.DecreaseToHalf();     //如果消息队列满，则只保留最近的一半消息
                foreach(ListViewContent v in queue)
                {
                    listView.Items.Add(GetItem(v));
                }
            }
            listView.EndUpdate();
        }
        private ListViewItem GetItem(ListViewContent lvc)
        {
            ListViewItem lvi = new ListViewItem();
            lvi.Text = lvc.Time.ToString();
            lvi.SubItems.Add(lvc.MsgId.ToString());
            lvi.SubItems.Add(lvc.CommType.ToString());
            return lvi;
        }
        #endregion

        #region 通信连接状态显示
        public void SetConnStatusLabel(ToolStripStatusLabel tssl, bool isConnect, ref DateTime dt)
        {
            try
            {
                DateTime After = DateTime.Now;
                if (dt == null || dt == DateTime.MinValue)
                {
                    dt = After;
                }
                if (!isConnect)
                {
                    if (After.Subtract(dt).TotalMilliseconds > 2000)
                    {
                        Invoke(new Action(() =>
                        {
                            if (tssl != null && !tssl.IsDisposed)//
                            {
                                tssl.BackColor = Color.Red;
                                tssl.Text = "通信断开";
                            }
                        }));
                    }
                    else if (After.Subtract(dt).TotalMilliseconds > 1000)
                    {
                        Invoke(new Action(() =>
                        {
                            if (tssl != null && !tssl.IsDisposed)
                            {
                                tssl.BackColor = Color.Yellow;
                                tssl.Text = "正在连接...";
                            }
                        }));
                    }
                }
                else
                {
                    dt = After;
                    Invoke(new Action(() =>
                    {
                        if (tssl != null && !tssl.IsDisposed)
                        {
                            tssl.BackColor = Color.Green;
                            tssl.Text = "通信连接";
                        }
                    }));
                }
                //    Thread.Sleep(100);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        DateTime Before_NRBCConn;
        public bool ConnStatus_NRBC
        {
            get
            {
                return toolStripStatusLabel_NRBC.Text == "通信连接";
            }
            set
            {
                SetConnStatusLabel(toolStripStatusLabel_NRBC, value, ref Before_NRBCConn);

            }
        }

        DateTime Before_RBCConn;
        public bool ConnStatus_RBC
        {
            get
            {
                return toolStripStatusLabel_RBC.Text == "通信连接";
            }
            set
            {
                SetConnStatusLabel(toolStripStatusLabel_RBC, value, ref Before_RBCConn);
            }
        }

        private void timerConnStatus_Tick(object sender, EventArgs e)
        {
            DateTime After = DateTime.Now;
            if (After > Before_NRBCConn)
            {
                if (After.Subtract(Before_NRBCConn).TotalMilliseconds > 1000)
                    ConnStatus_NRBC = Communication.IsConnected(_CommType.NRBC);
            }
            if (After > Before_RBCConn)
            {
                if (After.Subtract(Before_RBCConn).TotalMilliseconds > 1000)
                    ConnStatus_RBC = Communication.IsConnected(_CommType.RBC);
            }
        }
        #endregion
    }
}
