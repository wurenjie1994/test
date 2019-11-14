using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Train.Utilities;
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
            byte[] msg = { 1, 2, 3 };
            //byte[] send = XmlParser.SendData(msg);
            MessageBox.Show(Convert.ToBase64String(msg));
            String str = "2UCt0HJwZ5xjAA==";
            byte[] decode = Convert.FromBase64String(str);

            string s = "";
            for (int i = 0; i < decode.Length; i++) s += decode[i] + ",";
            MessageBox.Show(s);

        }
        [TestMethod]
        public void TestMethod2()
        {
            object o= 12325454365465;
            ulong t = 12325454365465;
            MessageBox.Show(string.Format("{0:x}", o));
        }
    }
}
