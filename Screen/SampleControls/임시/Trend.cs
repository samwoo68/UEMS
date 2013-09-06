using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Printing;

namespace SampleControls
{
    public partial class Trend : IronControls.BaseControl
    {
        DateTime startTime = DateTime.Now;
        DateTime endTime = DateTime.Now;
        bool charting;

        public Trend()
        {
            InitializeComponent();
        }

        public int HistoryCapacity
        {
            get
            {
                return scatterPlot1.HistoryCapacity;
            }
            set
            {
                scatterPlot1.HistoryCapacity = value;
            }
        }

        public string YAxisCaption
        {
            get
            {
                return yAxis1.Caption;
            }
            set
            {
                yAxis1.Caption = value;
            }
        }

        public double YAxisMax
        {
            get
            {
                return yAxis1.Range.Maximum;
            }
            set
            {
                yAxis1.Range = new NationalInstruments.UI.Range(yAxis1.Range.Minimum, value);
            }
        }

        public double YAxisMin
        {
            get
            {
                return yAxis1.Range.Minimum;
            }
            set
            {
                yAxis1.Range = new NationalInstruments.UI.Range(value, yAxis1.Range.Maximum);
            }
        }

        public Color LineColor
        {
            get
            {
                return scatterPlot1.LineColor;
            }
            set
            {
                scatterPlot1.LineColor = value;
            }
        }

        public bool Charting
        {
            get
            {
                return charting;
            }
            set
            {
                charting = value;
            }
        }

        public void ClearPloter()
        {
            for (int i = 0; i < 10; i++)
            {
                scatterGraph.Plots[i].ClearData();
            }

            Tags.Clear();
        }

        public override void UpdateValue(int notificationID, object[] values)
        {
            try
            {
                if (charting)
                {
                    int index = GetIndex(notificationID);
                    double data = double.Parse(values[0].ToString());
                    double time = (double)NationalInstruments.DataConverter.Convert((DateTime)values[1], typeof(double));
                    endTime = DateTime.Now;
                    startTime = endTime.Subtract(new TimeSpan(dateTimePicker1.Value.Hour, dateTimePicker1.Value.Minute, dateTimePicker1.Value.Second));

                    xAxis1.Range = new NationalInstruments.UI.Range(startTime, endTime);

                    scatterGraph.Plots[index].PlotXYAppend(time, data);
                }
            }
            catch
            {
            }
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            startTime = endTime.Subtract(new TimeSpan(dateTimePicker1.Value.Hour, dateTimePicker1.Value.Minute, dateTimePicker1.Value.Second));

            if (startTime < endTime)
            {
                xAxis1.Range = new NationalInstruments.UI.Range(startTime, endTime);
            }
        }

        private void button_print_Click(object sender, EventArgs e)
        {
            PrintDocument docToPrint = new PrintDocument();
            PageSettings ps = new PageSettings();

            ps.Margins = new Margins(10, 10, 10, 10);

            docToPrint.DefaultPageSettings = ps;

            PrintPreviewDialog pd = new PrintPreviewDialog();

            pd.ClientSize = new Size(500, 500);
            pd.UseAntiAlias = true;

            docToPrint.PrintPage += new PrintPageEventHandler(docToPrint_PrintPage);

            pd.Document = docToPrint;
            pd.Show();
        }

        void docToPrint_PrintPage(object sender, PrintPageEventArgs e)
        {
            SaveTransparentGIF converter = new SaveTransparentGIF();
            
            converter.SaveImage(".\\test.gif", Color.Tomato, scatterGraph);

            Image img = Image.FromFile(".\\test.gif");
            e.Graphics.DrawImage(img, 0, 0, scatterGraph.Width, scatterGraph.Height);
        }
    }
}
