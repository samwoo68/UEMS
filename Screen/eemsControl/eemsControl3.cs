using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace eemsControl
{
    public partial class eemsControl3 : IronControls.BaseControl
    {
        //Bitmap on = global::eemsControl.Properties.Resources.이미지on;
        //Bitmap off = global::eemsControl.Properties.Resources.이미지off;
        //Bitmap unknown = global::eemsControl.Properties.Resources.이미지unknown;

        public eemsControl3()
        {
            InitializeComponent();
        }
        public override void UpdateValue(int notificationID, object[] values)
        {
            int index = GetIndex(notificationID);

            try
            {
                bool b_data = bool.Parse(values[0].ToString());
                if (index == 0) // Input1 : burner1
                {
                
                    

                    //if (data)
                    //{
                    //    if (!Image_ratation) pictureBox1.BackgroundImage = Image_on;
                    //    else
                    //    {
                    //        if (!timer_image_rotation.Enabled)
                    //        {
                    //            pictureBox1.BackgroundImage = Image_on_rotation;
                    //            timer_image_rotation.Enabled = true;
                    //        }
                    //    }
                    //}
                    //else
                    //{
                    //    if (timer_image_rotation.Enabled) timer_image_rotation.Enabled = false;
                    //    pictureBox1.BackgroundImage = Image_off;
                    //}
                    if (b_data) pB_burner1.Visible = true;
                    else pB_burner1.Visible = false;
                }
                else if (index == 1) // Input2 : burner2
                {
                    if (b_data) pB_burner2.Visible = true;
                    else pB_burner2.Visible = false;
                }
                else if (index == 2) // Input3 : burner3
                {
                    if (b_data) pB_burner3.Visible = true;
                    else pB_burner3.Visible = false;
                }
                else if (index == 3) // Input4 : bubbler
                {
                    if (b_data) pB_bubbler.Visible = true;
                    else pB_bubbler.Visible = false;
                }
                else if (index == 4) // Input5 : heater1
                {
                    if (b_data) pB_heater1.Visible = true;
                    else pB_heater1.Visible = false;
                }
                else if (index == 5) // Input6 : heater2
                {
                    if (b_data) pB_heater2.Visible = true;
                    else pB_heater2.Visible = false;
                }
                else if (index == 6) // Input7 : heater3
                {
                    if (b_data) pB_heater3.Visible = true;
                    else pB_heater3.Visible = false;
                }
                else if (index == 7) // Input8 : heater4
                {
                    //if (b_data) pB_heater4.Visible = false;
                    //else pB_heater4.Visible = false;
                }
                else if (index == 8) // Input9 : furnace_refer_level
                {
                    if (b_data)
                    {
                        pB_furnace.Visible = false;
                        pB_furnace1.Visible = false;
                    }
                }
                else if (index == 9) // Input9 : furnace_refer_level
                {
                    if (b_data)
                    {
                        pB_furnace.Visible = false;
                        pB_furnace1.Visible = true;
                    }
                }
                else if (index == 10) // Input9 : furnace_refer_level
                {
                    if (b_data)
                    {
                        pB_furnace.Visible = true;
                        pB_furnace1.Visible = false;
                    }
                }

            }
            catch
            {
            }
        }

        //public Bitmap Image_on
        //{
        //    get;
        //    set;
        //}

        //public Bitmap Image_off
        //{
        //    get;
        //    set;
        //}

        //public Bitmap Image_unknown
        //{
        //    get;
        //    set;
        //}

        //public bool Image_ratation
        //{
        //    get;
        //    set;
        //}
        //public Bitmap Image_on_rotation
        //{
        //    get;
        //    set;
        //}

       

        //private bool bRotationOnOff = true;
        private void timer_image_rotation_Tick(object sender, EventArgs e)
        {
            //if (bRotationOnOff)
            //{
            //    pictureBox1.BackgroundImage = Image_on;
            //    bRotationOnOff = false;
            //}
            //else
            //{
            //    pictureBox1.BackgroundImage = Image_on_rotation;
            //    bRotationOnOff = true;
            //}
        }
    }
}
