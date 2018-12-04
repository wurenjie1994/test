using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Windows.Forms;
using Train.MessageHandlers;
using Train.Messages;

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
            AbstractMessageHandler.Handling(AbstractMessage.GetMessage(b));
            MessageBox.Show("UnitTest");
        }
    }
}
