using System;
using System.Collections.Generic;
using System.Threading;
using System.Windows.Forms;
using Train.Utilities;

namespace Train
{
    public enum _CommType
    {
        RBC,
        NRBC,
    }
    public class Communication
    {
        #region 通信参数配置
        //IP
        private static string trainIP;
        private static string rbcIP;
        private static string nrbcIP;
        //Port
        private static string train_rbcLocalPort;                //本端列车对RBC端口号
        private static string train_nrbcLocalPort;            //本端列车对NRBC端口号
        private static string rbcRemotePort;                      //对端RBC端口号
        private static string nrbcRemotePort;                //对端NRBC端口号
        //
        static Client train_rbc;
        static Client train_nrbc;
        #endregion

      
        //读取通信配置文件
        public static void ReadIniFile(string fileName)
        {
            IniFile file = new IniFile(fileName);
            if (file.ExistINIFile())
            {
                //IP
                trainIP = file.IniReadValue("IP", "TrainIP");
                rbcIP = file.IniReadValue("IP", "RBCIP");
                nrbcIP = file.IniReadValue("IP", "NRBCIP");
                //Port
                train_rbcLocalPort = file.IniReadValue("Port", "Train_RBCPort");
                rbcRemotePort = file.IniReadValue("Port", "RBCPort");
                train_nrbcLocalPort = file.IniReadValue("Port", "Train_NRBCPort");
                nrbcRemotePort = file.IniReadValue("Port", "NRBCPort");
            }
            else
            {
                MessageBox.Show("通信配置文件不存在，请确认配置文件路径是否正确");
            }
        }
        //初始化通信连接
        public static void Init(string fileName)
        {
            ReadIniFile(fileName);
            train_rbc = new Client(trainIP, int.Parse(train_rbcLocalPort), rbcIP, int.Parse(rbcRemotePort));
            train_nrbc = new Client(trainIP, int.Parse(train_nrbcLocalPort), nrbcIP, int.Parse(nrbcRemotePort));
        }

        public static void Close()
        {
            Disconnect(_CommType.NRBC);
            Disconnect(_CommType.RBC);
        }
        public static void Connect(_CommType commType)
        {
            Client client = GetClient(commType);
            if (client != null) client.Connect();
        }
       
        public static bool IsConnected(_CommType commType)
        {
            Client client = GetClient(commType);
            if (client != null) return client.Connected();
            return false;
        }
        public static void Disconnect(_CommType commType)
        {
            Client client = GetClient(commType);
            if (client != null) client.Disconnect();
        }


        public static void SendMsg(byte[] byteToSend,_CommType commType)
        {
            Client client = GetClient(commType);
            if (client != null)  client.SendMsg(byteToSend);
        }
       
        public static byte[] RecvMsg(_CommType commType)
        {
            Client client = GetClient(commType);
            if (client != null) return client.RecvMsg();
            return null;
        }

        private static Client GetClient(_CommType commType)
        {
            switch (commType)
            {
                case _CommType.NRBC:
                    return train_nrbc;
                case _CommType.RBC:
                    return train_rbc;
            }
            return null;
        }

    }
}