using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace UEMScreen
{
    public partial class TempSet : Form
    {
        public TempSet()
        {
            InitializeComponent();
            opcClient2.Connect();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //opcClient2.Disconnect();
            this.Hide();
        }

        private void button13_Click(object sender, EventArgs e)
        {
            opcClient2.WriteData(this.Tag.ToString(), 1);

            System.Threading.Thread.Sleep(500);

            opcClient2.WriteData(this.Tag.ToString(), 0);

           
            this.Hide();
            
        }

        private void TempSet_FormClosing(object sender, FormClosingEventArgs e)
        {
            opcClient2.Disconnect();
            opcClient2.Dispose();
        }
    }
}
