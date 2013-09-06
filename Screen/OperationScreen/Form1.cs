using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace OperationScreen
{
    public partial class Form1 : Form
    {
        public Form1(string path)
        {
            InitializeComponent();

            ironSANClient1.ProjectPath = path;
            ironSANClient1.Connect();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            ironSANClient1.Disconnect();
        }
    }
}
