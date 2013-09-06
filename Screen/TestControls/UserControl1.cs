using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TestControls
{
    public partial class UserControl1 : IronControls.BaseControl
    {
        public UserControl1()
        {
            InitializeComponent();
        }

        public override void UpdateValue(int notificationID, object[] values)
        {
            int data = int.Parse(values[0].ToString());

            if (data > 0)
            {
                this.BackColor = Color.Yellow;

            }
            else
            {
                this.BackColor = SystemColors.Control;
            }
        }
    }
}
