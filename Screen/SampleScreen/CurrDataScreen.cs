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
     
            ironSANClient1.Connect();        
            opcClient2.Connect();
        }

        private void CurrDataDisplay_FormClosing(object sender, FormClosingEventArgs e)
        {
            ironSANClient1.Disconnect ();           
            opcClient2.Disconnect();
        }

        public override void ShowPanel(string user, int level)
        {
            opcClient2.ItemUpdate = true;
        }

        public override void HidePanel()
        {
            opcClient2.ItemUpdate = false;
        }

        private void pictureBox28_DoubleClick(object sender, EventArgs e)
        {
            if (analogBox32.Visible == true)
            {
                analogBox32.Visible = false;
                analogBox33.Visible = false;
                analogBox34.Visible = false;
                analogBox35.Visible = false;
                analogBox36.Visible = false;
                analogBox37.Visible = false;
            }
            else
            {
                analogBox32.Visible = true;
                analogBox33.Visible = true;
                analogBox34.Visible = true;
                analogBox35.Visible = true;
                analogBox36.Visible = true;
                analogBox37.Visible = true;
            }
        }

    
        
    }
}
