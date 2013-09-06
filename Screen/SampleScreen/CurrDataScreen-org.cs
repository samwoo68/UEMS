using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SampleScreen
{
    public partial class CurrDataScreen : IronPanel.InformationPanel
    {
        public CurrDataScreen()
        {
            InitializeComponent();
            ////ironSANClient1.ProjectPath = path;
            ironSANClient1.Connect();
            opcClient1.Connect();
            opcClient2.Connect();
        }

        private void CurrDataDisplay_FormClosing(object sender, FormClosingEventArgs e)
        {
            ironSANClient1.Disconnect ();
            opcClient1.Disconnect();
            opcClient2.Disconnect();
        }

        private void CurrDataScreen_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

    
        
    }
}
