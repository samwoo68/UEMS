using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;

namespace TLV_OBJ
{
    public partial class TLV_UC : UserControl
    {
        public SqlConnection conn;

        public string EMessage = "";

        DataSet ds;       
        DataRow[] dr_data;

        string TableN = "N";
        string Table_InfoN = "N";
        string Str_Search_Where = "N";
        bool Search_Op;

        public TLV_UC()
        {
            InitializeComponent();
        }

        public bool Set_Conn(SqlConnection Pconn, string PTableN, string PTable_InfoN, bool PSerch_Op, string PStr_Search_Where)
        {
            EMessage = "Set Conn Error";
            try
            {
                conn = Pconn;
                TableN = PTableN;
                Table_InfoN = PTable_InfoN;
                Search_Op = PSerch_Op;
                Str_Search_Where = PStr_Search_Where;

                if (conn == null)                
                    return false;

                if (TableN == "N")
                    return false;

                if (Table_InfoN == "N")
                    return false;
                
                if (conn.Database != "UBI_ORDER_REAL")
                    return false;

                if (Search_Col(TableN) == false)
                    return false;
            }
            catch (Exception ex)
            {
                EMessage = ex.ToString();               
                return false;
            }

            EMessage = "";
            return true;
        }

        private bool Search_Col(string PTableN)
        {
            DataColumn DC;
            string select = "select COLUMN_NAME, DATA_TYPE, CHARACTER_MAXIMUM_LENGTH from INFORMATION_SCHEMA.COLUMNS where table_name ='" + TableN + "'";
            
            SqlDataAdapter da = new SqlDataAdapter(select,conn);
            DataSet Colds = new DataSet();
            da.Fill(Colds, "CoLName");

            dr_data = Colds.Tables["CoLName"].Select();            

            ds = new DataSet("Data");
            ds.Tables.Add(TableN);

            

            if (dr_data[0][0].ToString().Trim() == "ID")
            {
                DC = new DataColumn("Id");
                DC.DataType = System.Type.GetType("System.UInt32");
                ds.Tables[0].Columns.Add(DC);                
            }
            else
            {
                return false;
            }

            DC = new DataColumn("PId");
            DC.DataType = System.Type.GetType("System.UInt32");
            ds.Tables[0].Columns.Add(DC);                 
            
            return true;
        }

        public bool Set_TLV()
        {
            try
            {
                EMessage = "Set TLV Error";

                string SelectStr = "";
                SelectStr = SelectStr + "Select Mtb.Id AS Id, Mtb.PID AS PId, ";
                
                for (int i = 1; i < dr_data.Length; i++)
                {
                    SelectStr = SelectStr + "Mtb." + dr_data[i][0].ToString().Trim() + " AS " + dr_data[i][0].ToString().Trim() + ", ";
                }

                SelectStr = SelectStr + " Mtb.Qty AS Qty, Mtb.Id AS Id2, Mtb.PID AS PId2, Mtb.Check_P AS Check_P, ISNULL(Stb.Check_C , 0 ) AS Check_C ";

                SelectStr = SelectStr + " From ";
                SelectStr = SelectStr + " ( Select tb.ID AS Id, ISNULL(tb2.Pid , 0) AS PId, ";

                for (int i = 1; i < dr_data.Length; i++)
                {
                    SelectStr = SelectStr + "tb." + dr_data[i][0].ToString().Trim() + " AS " + dr_data[i][0].ToString().Trim() + ", ";
                }
                
                SelectStr = SelectStr + " ISNULL(tb2.Pid,0) AS Check_P, ISNULL(tb2.Qty,0) AS Qty";
                SelectStr = SelectStr + " From  " + TableN + " AS tb ";
                SelectStr = SelectStr + "  Full Join " + Table_InfoN + " AS tb2";
                SelectStr = SelectStr + "   On tb.ID = tb2.CID ";

              //  if (Str_Search_Where != "N")
              //      SelectStr = SelectStr + "       " + Str_Search_Where;

                SelectStr = SelectStr + "  ) AS Mtb";
                
                SelectStr = SelectStr + " Left Outer Join  ( ";
                SelectStr = SelectStr + "    Select Distinct tb3.PId AS Check_C ";
                SelectStr = SelectStr + "       From " + Table_InfoN + " AS tb3 ) ";
                SelectStr = SelectStr + "  AS Stb ";

                SelectStr = SelectStr + " On Mtb.id = Stb.Check_C ";
 
                
                if ( Search_Op == true )
                {
                    if (Str_Search_Where !=  "N")
                        SelectStr = SelectStr + "              Where Mtb.ID > 0" + Str_Search_Where ;
                }
                else
                {
                    if (Str_Search_Where != "N")
                        SelectStr = SelectStr + "              Where (Mtb.Check_P <> 0  OR Stb.Check_C <> 0) " + Str_Search_Where ;
                    else
                        SelectStr = SelectStr + "              Where (Mtb.Check_P <> 0  OR Stb.Check_C <> 0) ";
                }
                
                SqlDataAdapter da = new SqlDataAdapter(SelectStr, conn);

                da.Fill(ds, "_2정보");
                ds.Tables[0].Columns.Remove("Check_P");
                ds.Tables[0].Columns.Remove("Check_C");
              
                DTLV.RootKeyValue = 0u;
                DTLV.DataMember = TableN;
                DTLV.DataSource = ds;

                DTLV.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
              
                DTLV.Columns["Id2"].Width = 30;
                DTLV.Columns["PId2"].Width = 30;

                DTLV.UseSubItemCheckBoxes = true;
             
            }
            catch (Exception ex)
            {
                EMessage = ex.ToString();
                return false;
            }
            EMessage = "";
            return true;
        }

        public bool Select_Item(string pWriter, DateTime pStartD, DateTime pEndD)
        {       
            bool RemoveCheck = false;
            DateTime TmepDate;

            //DTLV.VirtualMode = false;
            DTLV.Items.RemoveAt(DTLV.SelectedIndices[0]);
            //DTLV.VirtualMode = true;

            for (int i = 0; i < DTLV.Items.Count; i++)
            {
                if (DTLV.Items[i].SubItems[10].Text.ToString().Trim() == "0")
                {
                    RemoveCheck = false;

                    if (pWriter != "")
                    {
                        if (DTLV.Items[i].SubItems[6].Text.ToString().Trim() != pWriter)
                        {
                            RemoveCheck = true;
                        }
                    }

                    if (RemoveCheck == false)
                    {
                        if (pStartD != DateTime.MinValue && pEndD != DateTime.MinValue)
                        {
                            TmepDate = DateTime.Parse(DTLV.Items[i].SubItems[5].Text.ToString().Trim());

                            if (pStartD > TmepDate || TmepDate > pEndD)
                            {
                                RemoveCheck = true;
                            }
                        }
                    }                    
                }

                if (RemoveCheck == true)
                {
                    DTLV.VirtualMode = false;
                    DTLV.Items.Remove(DTLV.Items[i]);
                    //DTLV.Items[i].Remove();
                    i = i - 1;
                    DTLV.VirtualMode = true;
                    //return true;
                }
            }


            
            return true;
        }

        public DataSet Get_Select_ID()
        {
            DataSet GetID_ds;
            GetID_ds = new DataSet("Data");
            GetID_ds.Tables.Add("Item");   
        
            DataSet RGetID_ds;
            RGetID_ds = new DataSet("Data");                 

            DataColumn DC = new DataColumn("Id");
            DC.DataType = System.Type.GetType("System.UInt32");
            GetID_ds.Tables[0].Columns.Add(DC);

          

            for (int i = 0; i < DTLV.Items.Count; i++)
            {               
                if (DTLV.Items[i].Checked == true)
                {
                    DataRow CheckID = GetID_ds.Tables["Item"].NewRow();
                    CheckID["id"] = DTLV.Items[i].SubItems[dr_data.Length - 1].Text.ToString().Trim();
                    GetID_ds.Tables["Item"].Rows.Add(CheckID);
                }
            }
          
            RGetID_ds.Tables.Add( GetID_ds.Tables[0].DefaultView.ToTable(true,"id"));    

            return RGetID_ds;
        }

        public DataSet Get_Select_PID()
        {
            string[] CoulN = new string[] {"ID","PID"};

            DataSet GetID_ds;
            GetID_ds = new DataSet("Data");
            GetID_ds.Tables.Add("Item");

            DataSet RGetID_ds;
            RGetID_ds = new DataSet("Data");         

            DataColumn DC = new DataColumn("Id");
            DC.DataType = System.Type.GetType("System.UInt32");
            GetID_ds.Tables[0].Columns.Add(DC);

            DC = new DataColumn("PId");
            DC.DataType = System.Type.GetType("System.UInt32");
            GetID_ds.Tables[0].Columns.Add(DC);
                       
            for (int i = 0; i < DTLV.Items.Count; i++)
            {
                if (DTLV.Items[i].Checked == true)
                {
                    DataRow CheckID = GetID_ds.Tables["Item"].NewRow();
                    CheckID["Id"] = DTLV.Items[i].SubItems[dr_data.Length-1].Text.ToString().Trim();
                    CheckID["PId"] = DTLV.Items[i].SubItems[dr_data.Length].Text.ToString().Trim();
                    GetID_ds.Tables["Item"].Rows.Add(CheckID);
                }
            }

            RGetID_ds.Tables.Add(GetID_ds.Tables[0].DefaultView.ToTable(true, CoulN));

            return RGetID_ds;
            
        }
    }
}
