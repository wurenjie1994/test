﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Train.Utilities
{
    class Client
    {
        string localIP, remoteIP;
        int localPort, remotePort;
        IPEndPoint localEP, remoteEP;
        TcpClient tcpClient;
        NetworkStream networkStream;
        const int BUFFER_SIZE = 1024;
        byte[] buffer = new byte[BUFFER_SIZE];

        public Client(string localIP,int localPort, string remoteIP,int remotePort)
        {
            this.localIP = localIP;
            this.localPort = localPort;
            this.remoteIP = remoteIP;
            this.remotePort = remotePort;
            localEP = new IPEndPoint(IPAddress.Parse(localIP), localPort);
            remoteEP = new IPEndPoint(IPAddress.Parse(remoteIP), remotePort);
        }

        public void SendMsg(byte[] byteToSend)
        {
            if (networkStream != null)
                networkStream.Write(byteToSend, 0, byteToSend.Length);
        }

        public byte[] RecvMsg()
        {
            byte[] recvBytes = null;
            while(networkStream == null) Connect();
            int len = networkStream.Read(buffer, 0, buffer.Length);
            if (len == 0)   //可能是通信已经断开
            {
                Disconnect();
                Connect();  //不一定连得上
                Thread.Sleep(100);
            }
            if (len > 0)
            {
                recvBytes = new byte[len];
                Array.Copy(buffer, recvBytes, len);
            }
            return recvBytes;
        }

        public void Connect()
        {
            if (tcpClient != null) Disconnect();
            try
            {
                //如果EP已经被使用，则会报错：AddressAlreadyInUse，ErrorCode：10048
                tcpClient = new TcpClient(localEP);
                //如果Server端未开启，则会报错：ConnectionRefused，ErrorCode：10061
                tcpClient.Connect(remoteEP);
            }
            catch (SocketException se)
            {
                MessageBox.Show(se.Message,"错误",MessageBoxButtons.OK,MessageBoxIcon.Error);
                return ;
            }
            networkStream = tcpClient.GetStream();
        }
        public void Disconnect()
        {
            if (networkStream != null)
            {
                networkStream.Close();networkStream = null;
            }
            if (tcpClient != null)
            {
                tcpClient.Close();
                tcpClient = null;
            }
        }
        public bool Connected()
        {
            if (tcpClient != null) return tcpClient.Connected;
            return false;
        }
    }
}