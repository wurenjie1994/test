using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Train.ShowMsg
{
    public partial class ShowMsgForm : Form
    {
        public ShowMsgForm(String msg)
        {
            InitializeComponent();
            this.tbMsg.Text = msg;
            this.Show();
        }

    }
}
