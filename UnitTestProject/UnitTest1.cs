using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Windows.Forms;
using Train.MessageHandlers;
using Train.Messages;
using Train.Utilities;
using System.Diagnostics;

namespace UnitTestProject
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            AbstractMessageHandler.Init();
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
    }
}
