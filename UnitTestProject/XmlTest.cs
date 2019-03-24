using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using Train.XmlResolve;
using System.Windows.Forms;

namespace UnitTestProject
{
    [TestClass]
    public class XmlTest
    {
        [TestMethod]
        public void TestMethod()
        {
            //MessageBox.Show("dfs");
            byte[] msg = { 1, 2, 3 };
            byte[] send = XmlParser.SendData(msg);
            //byte[] recv = XmlParser.RecvData(send);
            //MessageBox.Show(""+recv[0]+" "+recv[1]+" "+recv[2]);
        }
    }
}
