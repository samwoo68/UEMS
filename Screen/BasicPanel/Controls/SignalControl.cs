using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Reflection;
using Microsoft.Win32;

namespace BasicPanel
{
    public enum SignalStatus { Off, On, Blink }

    public partial class SignalControl : UserControl
    {
        SignalStatus red = SignalStatus.Off;
        SignalStatus yellow = SignalStatus.Off;
        SignalStatus blue = SignalStatus.Off;

        Bitmap currentImage = global::BasicPanel.Properties.Resources.SignalTower;

        public SignalControl()
        {
            InitializeComponent();

            this.Size = new Size(currentImage.Size.Width, currentImage.Size.Height);
            InvalidateEx();
        }

        public SignalStatus RedStatus
        {
            get { return red; }
            set
            {
                red = value;

                timer_red.Enabled = red != SignalStatus.Off;
            }
        }

        public SignalStatus YellowStatus
        {
            get { return red; }
            set { red = value; }
        }

        public SignalStatus BlueStatus
        {
            get { return red; }
            set { red = value; }
        }
        
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= 0x00000020; //WS_EX_TRANSPARENT 
                return cp;
            }
        }

        protected void InvalidateEx()
        {
            if (Parent == null)
                return;

            Rectangle rc = new Rectangle(this.Location, this.Size);
            Parent.Invalidate(rc, true);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            Rectangle rect = this.ClientRectangle;

            e.Graphics.DrawImage(currentImage, rect);
        }

        private void timer_blink_Tick(object sender, EventArgs e)
        {
            if (yellow == SignalStatus.On)
            {
                pictureBox_yellow.Visible = true;
            }
            else if (yellow == SignalStatus.Blink)
            {
                pictureBox_yellow.Visible = !pictureBox_yellow.Visible;
            }
            else
            {
                pictureBox_yellow.Visible = false;
            }
                        
            if (blue == SignalStatus.On)
            {
                pictureBox_blue.Visible = true;
            }
            else if (blue == SignalStatus.Blink)
            {
                pictureBox_blue.Visible = !pictureBox_blue.Visible;
            }
            else
            {
                pictureBox_blue.Visible = false;
            }
        }

        private void timer_red_Tick(object sender, EventArgs e)
        {
            if (red == SignalStatus.On)
            {
                pictureBox_red.Visible = true;
            }
            else if (red == SignalStatus.Blink)
            {
                pictureBox_red.Visible = !pictureBox_red.Visible;
            }
            else
            {
                pictureBox_red.Visible = false;
            }
        }
    }
}
