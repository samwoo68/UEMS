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
    public partial class GasFlowScreen : IronPanel.InformationPanel
    {
        public GasFlowScreen()
        {
            InitializeComponent();
        }
        #region Start and stop panel

        public override void StartPanel(string name)
        {          
            opcClient2.Connect();  // OPC-HUB         
        }

        public override void StopPanel()
        {           
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

        private void eemsControl1_Click(object sender, EventArgs e)
        {
            // 운전화면으로 메뉴이동하기 : 네비게이션
            MoveScreen(0, 0);
        }

        private void bt_PLC_EXEC_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("C:\\XG5000\\XG5000.exe");
        }     
    }
}
