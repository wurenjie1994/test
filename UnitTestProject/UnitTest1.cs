using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Windows.Forms;
using Train.MessageHandlers;
using Train.Messages;
using Train.Utilities;
using System.Diagnostics;
using System.Reflection;
using Train;
using Train.Packets;
using Train.Data;

namespace UnitTestProject
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            AbstractMessageHandler.Init(new MainForm());
            byte[] b = new byte[1024];
            b[0] = 16;
            AbstractMessageHandler.Handling(AbstractRecvMessage.GetMessage(b));
            MessageBox.Show(DateTime.Now.ToString());
            MessageBox.Show("MessageBox Test");
        }
        [TestMethod]
        public void TestMethod2()
        {
            CircularQueue<int> queue = new CircularQueue<int>();
            for (int i = 0; i < 111; i++) queue.Push(i);
            int cnt = -1;
            uint c = (uint)cnt;
            Console.WriteLine("cnt=" + cnt);
            foreach (int i in queue)
            {
                Console.Write(i + " ");
                cnt++;
                if (cnt % 10 == 0)
                    Console.WriteLine("");
            }
        }
        [TestMethod]
        public void GetFields()
        {
            AbstractPacket ap = new Packet003();
            Type t = ap.GetType();
            Database.Init();
            AbstractSendMessage arm = new Message129();
            ((Message129)arm).SetPacket0or1(new Packet000());
            arm.Resolve();
            t = arm.GetType();
            string s = "";
            FieldInfo[] f = t.GetFields(BindingFlags.Instance | BindingFlags.NonPublic);
            foreach(FieldInfo fi in f)
            {
                if (fi.FieldType.IsArray)
                    s += string.Join(",", fi.GetValue(arm) as int[])+"\r\n";
                s += fi.Name + ":" + fi.GetValue(arm) + "\r\n";
            }
            MessageBox.Show(arm.ToString());
        }

        [TestMethod]
        public void TestBuffer()
        {
            byte[] buffer = new byte[100];
            for (int i = 0; i < 20; i++)
                buffer[i] =(byte)i;
            int left = 15;
            Array.Copy(buffer, left, buffer, 0, left);
            string s="";
            for (int i = 0; i < 20; i++)
                s += buffer[i] + ", ";
            MessageBox.Show(s);
        }

        [TestMethod]
        public void TestDatabase()
        {
            Database db = new Database();
            db.Connect();
        }
        [TestMethod]
        public void TestEnum()
        {
            object obj = _ControlLevel.CTCS_2;
            if (obj is _ControlLevel)
                MessageBox.Show(obj.ToString());
            obj = new RadioButton();
            MessageBox.Show(obj.ToString());
        }
    }
}
