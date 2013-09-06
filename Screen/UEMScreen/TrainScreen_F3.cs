using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.Data.OleDb; 

using System.IO;                // 파일 첨부
using System.Configuration;
using ADOX;


namespace UEMScreen
{
    public partial class TrainScreen_F3 : IronPanel.InformationPanel
    {
        #region Screen Initialize     

      
        //온도 설정form
        TempSet Temp_Set = new TempSet();

        public TrainScreen_F3()
        {
            InitializeComponent();
        }

        #endregion
        
        #region Start and stop panel

        public override void StartPanel(string name)
        {           
            ironSANClient1.ProjectPath = this.ProjectPath;
            ironSANClient1.Connect();
          
            opcClient2.Connect();  // OPC-HUB          

            DateTime bdt = DateTime.Today; // periodic logging time init.
        }

        public override void StopPanel()
        {
            ironSANClient1.Disconnect();
           
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

        #endregion

        private void button13_Click(object sender, EventArgs e)
        {            
            Temp_Set.Tag = "PLC-XGK:M00021";
            Temp_Set.Show();
        }

        private void button14_Click(object sender, EventArgs e)
        {           
            Temp_Set.Tag = "PLC-XGK:M00020";
            Temp_Set.Show();
        }
    }
}
