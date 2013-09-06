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
    public partial class ImageOnOffUnknownAndTimer2 : IronControls.BaseControl
    {
        //Bitmap on = global::ImageOnOffUnknownAndTimer.Properties.Resources.이미지on;
        //Bitmap off = global::ImageOnOffUnknownAndTimer.Properties.Resources.이미지off;
        //Bitmap unknown = global::ImageOnOffUnknownAndTimer.Properties.Resources.이미지unknown;
        bool inputResult1 = false;
        bool inputResult2 = false;
        Bitmap MainImg = null;

        public ImageOnOffUnknownAndTimer2()
        {
            InitializeComponent();
            pictureBox1.InitialImage = Image_unknown;
            pictureBox1.BackgroundImage = Image_unknown;
            MainImg = Image_unknown;
        }
        public override void UpdateValue(int notificationID, object[] values)
        {
            int index = GetIndex(notificationID);

            if (index == 0) // Input1
            {
                try
                {
                    bool data = bool.Parse(values[0].ToString());

                    if (data)
                    {
                        if (!Image_ratation)
                        {
                            pictureBox1.BackgroundImage = Image_on1;
                        }
                        else
                        {
                            if (!timer_image_rotation.Enabled)
                            {
                                pictureBox1.BackgroundImage = Image_on_rotation;
                                timer_image_rotation.Enabled = true;
                            }
                        }
                    }
                    MainImg = Image_on1;
                    inputResult1 = data;
                    
                }
                catch
                {
                }
            }
            else if (index == 1) //input2
            {
                try
                {
                    bool data = bool.Parse(values[0].ToString());

                    if (data)
                    {
                        if (!Image_ratation)
                        {
                            pictureBox1.BackgroundImage = Image_on2;
                        }
                        else
                        {
                            if (!timer_image_rotation.Enabled)
                            {
                                pictureBox1.BackgroundImage = Image_on_rotation;
                                timer_image_rotation.Enabled = true;
                            }
                        }
                    }
                    MainImg = Image_on2;
                    inputResult2 = data;
                }
                catch
                {
                }
            }

            if (inputResult1 == false && inputResult2 == false)
            {
                if (timer_image_rotation.Enabled) timer_image_rotation.Enabled = false;
                pictureBox1.BackgroundImage = Image_off;
                MainImg = Image_off;
            }
        }

        public Bitmap Image_on1
        {
            get;
            set;
        }
        public Bitmap Image_on2
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
                pictureBox1.BackgroundImage = MainImg;
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