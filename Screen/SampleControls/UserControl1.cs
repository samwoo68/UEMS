using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SampleControls
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

        private void button1_Click(object sender, EventArgs e)
        {
            InputControls.Numpad pad = new InputControls.Numpad();

            if (pad.ShowDialog() == DialogResult.OK)
            {
                CommComponent.WriteData(FirstTag, pad.Value);
            }
        }
    }
}
