using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
namespace BasicPanel
{
    public partial class IntroPanel : IronPanel.InformationPanel
    {        
        public IntroPanel()
        {
            InitializeComponent();
            StartPanel("IntroPanel");
        }
        public override void StartPanel(string name)
        {
            string filepath;
            filepath = ProjectPath + "\\Image\\Intro\\IntroS-1.PNG";
            if (File.Exists(filepath))
            {
                pictureBox1.Image = Image.FromFile(filepath);
                return;
            }

            filepath = ProjectPath + "\\Image\\Intro\\IntroS-2.PNG";
            if (File.Exists(filepath))
            {
                pictureBox1.Image = Image.FromFile(filepath);
                return;
            }

            filepath = ProjectPath + "\\Image\\Intro\\IntroS-3.PNG";
            if (File.Exists(filepath))
            {
                pictureBox1.Image = Image.FromFile(filepath);
                return;
            }
        }

        public override void StopPanel()
        {
            base.StopPanel();          
        }
       

        private void bt_MoveScreenbt_Click(object sender, EventArgs e)
        {         
            MoveScreen(0, 0);
        }
    }
}
