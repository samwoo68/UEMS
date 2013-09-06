using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace 검색_OBJ
{
    public partial class Search_UC : UserControl
    {
        public Search_UC()
        {
            InitializeComponent();
        }

        public string WhereStr()
        {
            string Rstr = "";
            string TempDTS = "";
            string TempDTE = "";
            DateTime TempDT;

            if (CB작성자.Checked == true)
            {
                Rstr = Rstr + " AND Mtb.작성자 = '" + TB작성자.Text.ToString().Trim() + "' ";
            }

            if (CB월.Checked == true)
            {
                TempDTS = DT월.Value.ToString("yyyy-MM") + "-01";
                TempDT = Convert.ToDateTime(TempDTS);
                TempDT = TempDT.AddMonths(1);
                TempDT = TempDT.AddDays(-1);
                TempDTE = TempDT.ToString("yyyy-MM-dd");

                Rstr = Rstr + " AND Mtb.작성일 >= '" + TempDTS + "' AND Mtb.작성일 <= '" + TempDTE + "' ";
            }

            if (CB일.Checked == true)
            {
                TempDTS = DTS일.Value.ToString("yyyy-MM-dd");
                TempDTE = DTE일.Value.ToString("yyyy-MM-dd");

                Rstr = Rstr + " AND Mtb.작성일 >= '" + TempDTS + "' AND Mtb.작성일 <= '" + TempDTE + "' ";
            }

            if (Rstr == "")
            {
                Rstr = "N";
            }

            return Rstr;
        }

        public bool SelectItem(ref string pWriter, ref DateTime pStartD, ref  DateTime pEndD)
        {
            string TempDTS = "";          
            DateTime TempDT;
            bool WhereTF = false;

            if (CB작성자.Checked == true)
            {
                pWriter = TB작성자.Text.ToString().Trim();
                WhereTF = true;                
            }

            if (CB월.Checked == true)
            {
                TempDTS = DT월.Value.ToString("yyyy-MM") + "-01";
                TempDT = Convert.ToDateTime(TempDTS);
                pStartD = TempDT;

                TempDT = TempDT.AddMonths(1);
                TempDT = TempDT.AddDays(-1);
                pEndD = TempDT;

                WhereTF = true;  
            }

            if (CB일.Checked == true)
            {
                pStartD = DTS일.Value;
                pEndD = DTE일.Value;

                WhereTF = true;  
            }

            return WhereTF;
        }

        private void CB월_CheckedChanged(object sender, EventArgs e)
        {
            if (CB월.Checked == true)
                CB일.Checked = false;
        }

        private void CB일_CheckedChanged(object sender, EventArgs e)
        {
            if (CB일.Checked == true)
                CB월.Checked = false;
        }
    }
}
