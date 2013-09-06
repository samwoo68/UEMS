using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace LedOnButton
{
    public partial class LedOnButton : IronControls.BaseControl
    {
        Bitmap on = global::LedOnButton.Properties.Resources.연한적색;
        Bitmap off = global::LedOnButton.Properties.Resources.연한녹색;
        Bitmap unknown = global::LedOnButton.Properties.Resources.연한분홍;

        int data1 = 0;
        int data2 = 0;

        public LedOnButton()
        {
            InitializeComponent();
        }

        public override string Text
        {
            get
            {
                return button.Text;
            }
            set
            {
                button.Text = value;
            }
        }


        public override void UpdateValue(int notificationID, object[] values)
        {
            int index = GetIndex(notificationID);

            if (index == 0) // Input1
            {
                data1 = int.Parse(values[0].ToString());
            }
            else if (index == 1) //Input2
            {
                data2 = int.Parse(values[0].ToString());
            }

            if (data1 > 0 && data2 == 0)
            {
                pictureBox1.BackgroundImage = on;
            }
            else if (data1 == 0 && data2 > 0)
            {
                pictureBox1.BackgroundImage = off;
            }
            else
            {
                pictureBox1.BackgroundImage = unknown;
            }
        }

        private void button_Click(object sender, EventArgs e)
        {
            if (Tags.Count > 2)
            {
                if (data1 > 0 && data2 == 0)
                {
                    this.CommComponent.WriteData(Tags[2], 0);
                }
                else
                {
                    this.CommComponent.WriteData(Tags[2], 1);
                }
            }
        }
    }
}
