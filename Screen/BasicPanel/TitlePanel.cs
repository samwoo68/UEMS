using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
namespace BasicPanel
{
    public partial class TitlePanel : IronPanel.TitlePanel
    {
        public TitlePanel()
        {
            InitializeComponent();
            //StartPanel();
        }

        public override void StartPanel()
        {
            string ProjectPath2 = "C:\\IronTools";

            string filepath2 = ProjectPath2 + "\\Image\\Intro\\SLogo.PNG";
            if (File.Exists(filepath2))
                pictureBox2.Image = Image.FromFile(filepath2);


            string filepath;
            filepath = ProjectPath2 + "\\Image\\Intro\\Logo-3.PNG";
            if (File.Exists(filepath))
            {
                pictureBox4.Image = Image.FromFile(filepath);
                pictureBox4.Visible = true;
                Point PLocation = new Point(1757, 16);
                pictureBox4.Location = PLocation;
                Size PSize = new Size(69, 69);
                pictureBox4.Size = PSize;
                return;
            }

            filepath = ProjectPath2 + "\\Image\\Intro\\Logo-1.PNG";
            if (File.Exists(filepath))
            {
                pictureBox4.Image = Image.FromFile(filepath);
                pictureBox4.Visible = true;
                Point PLocation = new Point(1662, 16);
                pictureBox4.Location = PLocation;
                Size PSize = new Size(255, 69);
                pictureBox4.Size = PSize;
                return;
            }

            filepath = ProjectPath2 + "\\Image\\Intro\\Logo-2.PNG";
            if (File.Exists(filepath))
            {
                pictureBox4.Image = Image.FromFile(filepath);
                pictureBox4.Visible = true;
                Point PLocation = new Point(1662, 16);
                pictureBox4.Location = PLocation;
                Size PSize = new Size(255, 69);
                pictureBox4.Size = PSize;
                return;
            }          
        }

        public override bool Alarm
        {
            set
            {
                alarmControl.AlarmStatus = value;
                    
                signalControl.RedStatus = value ? SignalStatus.Blink  : SignalStatus.Off;
            }
        }
        
        public override void ChangeLogin(bool login)
        {
            hostControl.ButtonEnabled = login;
            equipStatusControl.ButtonEnabled = login;
            alarmControl.ButtonEnabled = login;
        }

        private void loginControl_LoginClick(object sender, EventArgs e)
        {
            bool login = LoginControl("", "");

            hostControl.ButtonEnabled = login;
            equipStatusControl.ButtonEnabled = login;
            alarmControl.ButtonEnabled = login;
        }

        private void alarmControl_ButtonClick(object sender, EventArgs e)
        {
            AlarmControl();
        }

        private void hostControl_ButtonClick(object sender, EventArgs e)
        {
            HostControl();
        }      
    }
}
