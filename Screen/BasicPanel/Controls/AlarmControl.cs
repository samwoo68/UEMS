using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace BasicPanel
{
    public partial class AlarmControl : UserControl
    {
        public event EventHandler ButtonClick = null;

        bool buttonEnabled = false;
        bool alarmStatus = false;

        Bitmap enableImage = global::BasicPanel.Properties.Resources.Alarm_enable;
        Bitmap disableImage = global::BasicPanel.Properties.Resources.Alarm_disable;
        Bitmap pressImage = global::BasicPanel.Properties.Resources.Alarm_press;
        Bitmap blinkImage = global::BasicPanel.Properties.Resources.Alarm_blink;
        Bitmap currentImage = global::BasicPanel.Properties.Resources.Alarm_disable;

        public AlarmControl()
        {
            InitializeComponent();

            this.Size = new Size(currentImage.Size.Width, currentImage.Size.Height);
        }

        #region Property
        public bool ButtonEnabled
        {
            get
            {
                return buttonEnabled;
            }
            set
            {
                buttonEnabled = value;

                if (buttonEnabled)
                {
                    currentImage = enableImage;
                }
                else
                {
                    currentImage = disableImage;
                }

                InvalidateEx();
            }

        }

        public bool AlarmStatus
        {
            get
            {
                return alarmStatus;
            }
            set
            {
                alarmStatus = value;

                timer_blink.Enabled = alarmStatus;

                if (alarmStatus == false)
                {
                    if (buttonEnabled)
                    {
                        currentImage = enableImage;
                    }
                    else
                    {
                        currentImage = disableImage;
                    }

                    InvalidateEx();
                }
            }
        }
        #endregion

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

        private void StatusButton_MouseDown(object sender, MouseEventArgs e)
        {
            if (buttonEnabled)
            {
                currentImage = pressImage;
                InvalidateEx();
            }
        }

        private void StatusButton_MouseUp(object sender, MouseEventArgs e)
        {
            if (buttonEnabled)
            {
                if (alarmStatus)
                    currentImage = blinkImage;
                else
                    currentImage = enableImage;

                InvalidateEx();
            }
        }

        private void StatusButton_Click(object sender, EventArgs e)
        {
            if (buttonEnabled && ButtonClick != null)
            {
                ButtonClick(this, e);
            }
        }

        private void timer_blink_Tick(object sender, EventArgs e)
        {
            if (currentImage != blinkImage)
            {
                currentImage = blinkImage;
            }
            else
            {
                if (this.buttonEnabled)
                    currentImage = enableImage;
                else
                    currentImage = disableImage;
            }

            InvalidateEx();
        }
    }
}
