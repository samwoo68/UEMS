using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ImageOnOffUnknownAndTimerA
{
    public partial class ImageOnOffUnknownAndTimerA : IronControls.BaseControl
    {
        //Bitmap on = global::ImageOnOffUnknownAndTimer.Properties.Resources.이미지on;
        //Bitmap off = global::ImageOnOffUnknownAndTimer.Properties.Resources.이미지off;
        //Bitmap unknown = global::ImageOnOffUnknownAndTimer.Properties.Resources.이미지unknown;
        double iGain = 0;
        int iDep = 0;
        string sDep = "f0";

        public ImageOnOffUnknownAndTimerA()
        {
            InitializeComponent();           
            //pictureBox1.InitialImage  = Image_unknown;
            //pictureBox1.BackgroundImage  = Image_unknown;
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
                    double data = double.Parse(values[0].ToString());
                    data = iGain * data;
                 

                    if (data > 1.0)
                    {
                        if (!Image_ratation)
                        {
                            timer_image_rotation.Enabled = false;
                            splitContainer1.Panel2.BackgroundImage = Image_on;  
                            label1.Text = data.ToString(sDep);
                            this.Visible = true;
                        }
                        else
                        {
                            if (!timer_image_rotation.Enabled)
                            {
                                splitContainer1.Panel2.BackgroundImage = Image_on_rotation;
                                timer_image_rotation.Enabled = true;
                                label1.Text = data.ToString(sDep);
                                this.Visible = true;
                            }
                        }
                    }
                    else
                    {
                        if (timer_image_rotation.Enabled) timer_image_rotation.Enabled = false;
                        splitContainer1.Panel2.BackgroundImage = Image_off;
                        label1.Text = data.ToString(sDep);
                        this.Visible = false;
                    }
                }

                catch
                {
                }
            }
        }
        public double Gain
        {
            get
            {
                return iGain;

            }
            set
            {
                try
                {
                    iGain = value;                    
                }
                catch
                {
                    iGain = 1;
                }
            }
        }

        public int DecimalPlace
        {
            get
            {
                return iDep;

            }
            set
            {
                try
                {
                    iDep = value;
                    sDep = "f" + iDep.ToString();
                }
                catch
                {
                    iDep = 0;
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
                splitContainer1.Panel2.BackgroundImage = Image_on;
                bRotationOnOff = false;
            }
            else
            {
                splitContainer1.Panel2.BackgroundImage = Image_on_rotation;
                bRotationOnOff = true;
            }
        }

        private void ImageOnOffUnknownAndTimerA_BackgroundImageChanged(object sender, EventArgs e)
        {
            Image TempImg;
            if (this.BackgroundImage != null)
            {
                TempImg = this.BackgroundImage;
                splitContainer1.Panel2.BackgroundImage = TempImg;
                this.BackgroundImage = null;
            }
        }
    }
}
