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
    public partial class TrendScreen : IronPanel.InformationPanel
    {
        public TrendScreen()
        {
            InitializeComponent();
        }

        public override void StartPanel(string name)
        {
            //// 트렌드 화면에서 이 화면의 컨트롤 값들을 가져갈 수 있도록
            //LogDataScreen lds = new LogDataScreen();
            //lds.Owner = this;
            //lds.Show();
        }
        public override void StopPanel()
        {
            
        }



        private void bt_Load_Click(object sender, EventArgs e)
        {

        }
    }
}
