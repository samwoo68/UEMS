using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace LedOnly
{
    public partial class LedOnly : IronControls.BaseControl
    {
        Bitmap on = global::LedOnly.Properties.Resources.연한적색;
        Bitmap off = global::LedOnly.Properties.Resources.연한녹색;
        Bitmap unknown = global::LedOnly.Properties.Resources.연한분홍;

        

        public LedOnly()
        {
            InitializeComponent();
        }

        public override void UpdateValue(int notificationID, object[] values)
        {
            int index = GetIndex(notificationID);

            if (index == 0) // Input1
            {
                //try
                //{
                //    switch (int.Parse(values[0].ToString()))
                //    {
                //        case 0: pictureBox1.BackgroundImage = unknown; break;
                //        case 1: pictureBox1.BackgroundImage = on; break;
                //        case 2: pictureBox1.BackgroundImage = off; break;
                //        default: break;
                //    }
                //}

                try
                {
                    bool data = bool.Parse(values[0].ToString());

                    if (data)
                    {
                        pictureBox1.BackgroundImage = on;
                    }
                    else
                    {
                        pictureBox1.BackgroundImage = off;
                    }
                }

                catch
                {
                }
            }
        }
    }
}
