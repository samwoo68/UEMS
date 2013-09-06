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
    public partial class LoginControl : UserControl
    {
        public event EventHandler LoginClick = null;

        Bitmap enableImage = global::BasicPanel.Properties.Resources.Login_enable;
        Bitmap pressImage = global::BasicPanel.Properties.Resources.Login_press;
        Bitmap currentImage = global::BasicPanel.Properties.Resources.Login_enable;

        string userID = "";
        string authority = "";

        public LoginControl()
        {
            InitializeComponent();
        }

        #region Property
        public string UserID
        {
            get
            {
                return userID;
            }
            set
            {
                userID = value;

                if (userID.Length > 0)
                {
                    Bitmap enableImage = global::BasicPanel.Properties.Resources.Logout_enable;
                    Bitmap pressImage = global::BasicPanel.Properties.Resources.Logout_press;
                }
                else
                {
                    Bitmap enableImage = global::BasicPanel.Properties.Resources.Login_enable;
                    Bitmap pressImage = global::BasicPanel.Properties.Resources.Login_press;
                }
            }
        }

        public string Authority
        {
            get
            {
                return authority;
            }
            set
            {
                authority = value;
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

        private void LoginControl_MouseDown(object sender, MouseEventArgs e)
        {
            currentImage = pressImage;
            InvalidateEx();
        }

        private void LoginControl_MouseUp(object sender, MouseEventArgs e)
        {
            currentImage = enableImage;
            InvalidateEx();
        }

        private void LoginControl_Click(object sender, EventArgs e)
        {
            if (LoginClick != null)
            {
                LoginClick(this, e);
            }
        }
    }
}
