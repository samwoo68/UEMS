using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace FlashBox
{
    public partial class FlashBox : IronControls.BaseControl
    {
        string command="lamp_setting1";
        string lamp ="";

        double power =0;
        string error ="";


        public FlashBox()
        {
            InitializeComponent();
        }

        public override void UpdateValue(int notificationID, object[] values)
        {
            try
            {
                int index = GetIndex(notificationID);

                if (index == 0)
                {
                    lamp = "1";
                    power = double.Parse(values[0].ToString());

                    axShockwaveFlash1.CallFunction("<invoke name=\"" + command + "\" returntype=\"xml\"><arguments><string>" + lamp + "</string><string>" + power.ToString() + "</string><string>" + error + "</string></arguments></invoke>");
                    error = "0";
                }
                else if (index == 1)
                {
                    lamp = "2";
                    power = double.Parse(values[0].ToString());

                    axShockwaveFlash1.CallFunction("<invoke name=\"" + command + "\" returntype=\"xml\"><arguments><string>" + lamp + "</string><string>" + power.ToString() + "</string><string>" + error + "</string></arguments></invoke>");
                    error = "0";
                }
                else if (index < 30)  // max=30ea
                {
                    index++;
                    lamp = index.ToString().Trim(); // "2";
                    power = double.Parse(values[0].ToString());

                    axShockwaveFlash1.CallFunction("<invoke name=\"" + command + "\" returntype=\"xml\"><arguments><string>" + lamp + "</string><string>" + power.ToString() + "</string><string>" + error + "</string></arguments></invoke>");
                    error = "0";
                }
            }
            catch
            {
            }
        }
        public void SetMovie(string movie)
        {
            FileInfo file = new FileInfo(movie);

            if (file.Exists)
            {
                axShockwaveFlash1.Movie = file.FullName;
            }
        }

    }
}
