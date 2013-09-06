using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ImageOnOffUnknownAndTimer
{
    public partial class ImageOnOffUnknownAndTimer : IronControls.BaseControl
    {
        //Bitmap on = global::ImageOnOffUnknownAndTimer.Properties.Resources.이미지on;
        //Bitmap off = global::ImageOnOffUnknownAndTimer.Properties.Resources.이미지off;
        //Bitmap unknown = global::ImageOnOffUnknownAndTimer.Properties.Resources.이미지unknown;

        public ImageOnOffUnknownAndTimer()
        {
            InitializeComponent();
            pictureBox1.InitialImage  = Image_unknown;
            pictureBox1.BackgroundImage  = Image_unknown;
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
                        if (!Image_ratation) pictureBox1.BackgroundImage = Image_on;
                        else
                        {
                            if (!timer_image_rotation.Enabled)
                            {
                                pictureBox1.BackgroundImage = Image_on_rotation;
                                timer_image_rotation.Enabled = true;
                            }
                        }
                    }
                    else
                    {
                        if (timer_image_rotation.Enabled) timer_image_rotation.Enabled = false;
                        pictureBox1.BackgroundImage = Image_off;
                    }
                }

                catch
                {
                }
            }
        }

        public Bitmap Image_on
        {
            get;
            set;
        }

        public Bitmap Image_off
        {
            get;
            set;
        }

        public Bitmap Image_unknown
        {
            get;
            set;
        }

        public bool Image_ratation
        {
            get;
            set;
        }
        public Bitmap Image_on_rotation
        {
            get;
            set;
        }

        private bool bRotationOnOff = true;
        private void timer_image_rotation_Tick(object sender, EventArgs e)
        {
            if (bRotationOnOff)
            {
                pictureBox1.BackgroundImage = Image_on;
                bRotationOnOff = false;
            }
            else
            {
                pictureBox1.BackgroundImage = Image_on_rotation;
                bRotationOnOff = true;
            }
        }
    }
}
