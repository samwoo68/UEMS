using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace fbElevator
{
    public partial class fbElevator : IronControls.BaseControl
    {
        string command="Elevator_1";
        string elv_attr_name ="1";

        double elv_attr_value =0.0;
        string error ="";


        public fbElevator()
        {
            InitializeComponent();
        }

        public override void UpdateValue(int notificationID, object[] values)
        {
            try
            {
                int index = GetIndex(notificationID);

                // index = 0; stop
                // index = 1: play
                // index = 2 : top position

                // index = 0; scrap position
                // index = 1: ingot position
                // index = 2 : top position
                
                if (index < 30)  // max=30ea
                {
                    index++;
                    elv_attr_name = index.ToString().Trim(); //  인덱스 번호를 Flash로 넘기는 속성이름으로 "2";
                    elv_attr_value = double.Parse(values[0].ToString());

                    axShockwaveFlash1.CallFunction("<invoke name=\"" + command + "\" returntype=\"xml\"><arguments><string>" + elv_attr_name + "</string><string>" + elv_attr_value.ToString() + "</string><string>" + error + "</string></arguments></invoke>");
                    //MessageBox.Show("<invoke name=\"" + command + "\" returntype=\"xml\"><arguments><string>" + elv_attr_name + "</string><string>" + elv_attr_value.ToString() + "</string><string>" + error + "</string></arguments></invoke>");
                    error = "0";
                }
                else 
                {
                    //MessageBox.Show("Unknown ID");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                //MessageBox.Show("error");
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
