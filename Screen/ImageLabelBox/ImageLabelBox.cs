using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ImageLabelBox
{
    public partial class ImageLabelBox : UserControl
    {
        public ImageLabelBox()
        {
            InitializeComponent();
        }

        public string Label_Text
        {
            get { return label1.Text as string; }
            set { label1.Text = value; }
        }

        public Font Label_Font
        {
            get { return label1.Font  as Font; }
            set { label1.Font = value; }
        }

        public Color Label_Color
        {
            get { return label1.ForeColor; }
            set { label1.ForeColor = value; }
        }

        public Point Label_Location
        {
            get { return label1.Location; }
            set { label1.Location = value; }
        }
    }
}
