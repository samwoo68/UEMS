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
    public partial class ExtMonitor : Form
    {
        public ExtMonitor(string path)
        {
            InitializeComponent();

            ironSANClient1.ProjectPath = path;
            ironSANClient1.Connect();         
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            ironSANClient1.Disconnect();            
        }

        private void digitalBox5_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox17_Click(object sender, EventArgs e)
        {

        }
    }
}
