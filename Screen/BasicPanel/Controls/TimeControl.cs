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
    public partial class TimeControl : UserControl
    {
        Bitmap currentImage = global::BasicPanel.Properties.Resources.DateTime;

        public TimeControl()
        {
            InitializeComponent();

            this.Size = new Size(currentImage.Size.Width, currentImage.Size.Height);
            InvalidateEx();
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

        private void timer_disp_Tick(object sender, EventArgs e)
        {
            System.DateTime date = System.DateTime.Now;

            label_time.Text = date.ToString("MM-dd HH:mm:ss");
        }
    }
}
