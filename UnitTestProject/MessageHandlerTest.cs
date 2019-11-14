using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Train.MessageHandlers;
using Train.Messages;
using Train;
using System.Threading;

namespace UnitTestProject
{
    [TestClass]
    public class MessageHandlerTest     //class must be public?
    {
        [TestMethod]
        public void TestEBMH()
        {
            MessageHandler mh = new MessageHandler(_CommType.RBC);
            MessageHandler.mainForm = new MainForm();
            Thread.Sleep(2000);     //使窗口句柄创建完毕
            EB_MH mhEB = new EB_MH(mh);
            
            mhEB.Solve(new Message016());
        }
    }
}
