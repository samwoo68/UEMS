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
    public partial class HostControl : UserControl
    {
        public event EventHandler ButtonClick = null;

        bool connection = false;
        bool buttonEnabled = false;

        Bitmap enableImage = global::BasicPanel.Properties.Resources.HostCommDisconn_enable;
        Bitmap disableImage = global::BasicPanel.Properties.Resources.HostCommDisconn_disable;
        Bitmap pressImage = global::BasicPanel.Properties.Resources.HostCommDisconn_press;
        Bitmap currentImage = global::BasicPanel.Properties.Resources.HostCommDisconn_disable;

        public HostControl()
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

        public bool Connection
        {
            get
            {
                return connection;
            }
            set
            {
                connection = value;

                if (connection)
                {
                    enableImage = global::BasicPanel.Properties.Resources.HostCommConn_enable;
                    disableImage = global::BasicPanel.Properties.Resources.HostCommConn_disable;
                    pressImage = global::BasicPanel.Properties.Resources.HostCommConn_press;
                }
                else
                {
                    enableImage = global::BasicPanel.Properties.Resources.HostCommDisconn_enable;
                    disableImage = global::BasicPanel.Properties.Resources.HostCommDisconn_disable;
                    pressImage = global::BasicPanel.Properties.Resources.HostCommDisconn_press;
                }

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

        public string Communication
        {
            get
            {
                return label_communication.Text;
            }
            set
            {
                label_communication.Text = value;
            }
        }

        public string Control
        {
            get
            {
                return label_online.Text;
            }
            set
            {
                label_online.Text = value;
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

        private void HostButton_MouseDown(object sender, MouseEventArgs e)
        {
            if (buttonEnabled)
            {
                currentImage = pressImage;

                Point pos = label_online.Location;
                pos.X += 3;
                pos.Y += 2;
                label_online.Location = pos;

                pos = label_communication.Location;
                pos.X += 3;
                pos.Y += 2;
                label_communication.Location = pos;

                InvalidateEx();
            }
        }

        private void HostButton_MouseUp(object sender, MouseEventArgs e)
        {
            if (buttonEnabled)
            {
                currentImage = enableImage;

                Point pos = label_online.Location;
                pos.X -= 3;
                pos.Y -= 2;
                label_online.Location = pos;

                pos = label_communication.Location;
                pos.X -= 3;
                pos.Y -= 2;
                label_communication.Location = pos;

                InvalidateEx();
            }
        }

        private void HostButton_Click(object sender, EventArgs e)
        {
            if (buttonEnabled && ButtonClick != null)
            {
                ButtonClick(this, e);
            }
        }
    }
}
