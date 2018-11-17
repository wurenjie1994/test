using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.Net.Sockets;
using System.Net;
using System.Data.SqlClient;
using Train.Utilities;

namespace Train
{
    public enum _CommType
    {
        RBC,
        LINESIM,
    }
    public class Communication
    {
        #region 通信参数配置
        //IP
        private string trainIP;
        private string rbcIP;
        private string linesimIP;
        //Port
        private string train_rbcLocalPort;                //本端列车对RBC端口号
        private string train_linesimLocalPort;            //本端列车对LineSim端口号
        private string rbcRemotePort;                      //对端RBC端口号
        private string linesimRemotePort;                //对端LineSim端口号
        //IPEndPoint
        IPEndPoint train_rbcLocalIPEndPoint;
        IPEndPoint train_linesimLocalIPEndPoint;
        IPEndPoint rbcRemoteIPEndPoint;
        IPEndPoint linesimRemoteIPEndPoint;
        //TCP/UDP连接
        TcpClient train_rbc;
        UdpClient train_linesim;
        //
        NetworkStream train_rbcNS;
        const int BUFFER_SIZE = 1024;
        byte[] buffer = new byte[BUFFER_SIZE];
        #endregion

        public Communication(string fileName)
        {
            ReadIniFile(fileName);
        }
        //读取通信配置文件
        public void ReadIniFile(string fileName)
        {
            IniFile file = new IniFile(fileName);
            if (file.ExistINIFile())
            {
                //IP
                trainIP = file.IniReadValue("IP", "TrainIP");
                rbcIP = file.IniReadValue("IP", "RBCIP");
                linesimIP = file.IniReadValue("IP", "LineIP");
                //Port
                train_rbcLocalPort = file.IniReadValue("Port", "Train_RBCPort");
                train_linesimLocalPort = file.IniReadValue("Port", "Train_LinePort");
                rbcRemotePort = file.IniReadValue("Port", "RBCPort");
                linesimRemotePort = file.IniReadValue("Port", "LinePort");
            }
            else
            {
                MessageBox.Show("通信配置文件不存在，请确认配置文件路径是否正确");
            }
        }
        //初始化通信连接
        public void Init()
        {
            train_rbcLocalIPEndPoint = new IPEndPoint(IPAddress.Parse(trainIP), int.Parse(train_rbcLocalPort));
            train_linesimLocalIPEndPoint = new IPEndPoint(IPAddress.Parse(trainIP), int.Parse(train_linesimLocalPort));
            linesimRemoteIPEndPoint = new IPEndPoint(IPAddress.Parse(linesimIP), int.Parse(linesimRemotePort));
            rbcRemoteIPEndPoint = new IPEndPoint(IPAddress.Parse(rbcIP), int.Parse(rbcRemotePort));
            train_rbc = new TcpClient(train_rbcLocalIPEndPoint);
        }

        public void Close()
        {
            Disconnect(_CommType.LINESIM);
            Disconnect(_CommType.RBC);
        }
        public void Connect(_CommType commType)
        {
            switch(commType)
            {
                case _CommType.LINESIM:
                    if(train_linesim ==null)
                        train_linesim = new UdpClient(train_linesimLocalIPEndPoint);
                    break;
                case _CommType.RBC:
                    if (train_rbc != null) train_rbc.Close();
                    train_rbc = new TcpClient(train_rbcLocalIPEndPoint);
                    train_rbc.Connect(rbcRemoteIPEndPoint);
                    train_rbcNS = train_rbc.GetStream();
                    break;
            }
        }
        public void Disconnect(_CommType commType)
        {
            switch(commType)
            {
                case _CommType.LINESIM:
                    if (train_linesim != null) { train_linesim.Close(); train_linesim = null; }
                    break;
                case _CommType.RBC:
                    if (train_rbcNS != null) { train_rbcNS.Close(); train_rbcNS = null; }
                    if (train_rbc != null) {  train_rbc.Close(); train_rbc = null; }
                    break;
            }
        }


        public void SendMsg(byte[] byteToSend,_CommType commType)
        {
            switch(commType)
            {
                case _CommType.LINESIM:
                    if (train_linesim != null)
                        train_linesim.Send(byteToSend, byteToSend.Length, linesimRemoteIPEndPoint);
                    break;
                case _CommType.RBC:
                    if (train_rbcNS != null)
                        train_rbcNS.Write(byteToSend, 0, byteToSend.Length);
                    break;
                default:break;
            }  
        }
        public byte[] RecvMsg(_CommType commType)
        {
            byte[] recvBytes = null;
            switch (commType)
            {
                case _CommType.LINESIM:
                    if (train_linesim != null)
                        recvBytes = train_linesim.Receive(ref linesimRemoteIPEndPoint);
                    else Thread.Sleep(100);            //避免线程一直执行，占用CPU时间
                    break;
                case _CommType.RBC:
                    recvBytes = RecvFromRBC();
                    break;
            }
            return recvBytes;
        }
        private byte[] RecvFromRBC()
        {
            byte[] recvBytes = null;
            if (train_rbcNS == null)
                Connect(_CommType.RBC);
            int len = train_rbcNS.Read(buffer, 0, buffer.Length);
            if (len == 0)   //可能是通信已经断开
            {
                Disconnect(_CommType.RBC);
                Connect(_CommType.RBC);  //不一定连得上
                Thread.Sleep(100);
            }
            if (len > 0)
            {
                recvBytes = new byte[len];
                Array.Copy(buffer, recvBytes, len);
            }
            return recvBytes;
        }
    }
}