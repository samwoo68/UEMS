using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.IO;
using System.Configuration;

using System.Xml;
using System.Collections.Specialized;

//using NationalInstruments.UI.AnnotationCaptionAlignment;

namespace SelGraphView
{
    public partial class SelGraphViewC : IronControls.BaseControl
    {
        ContextMenuStrip cms = new ContextMenuStrip();
        
        DataTable TempDataTabel;
        CheckBox[] ItemCb;
        Label[] ItemLb;
        Label[] TempLaName;
        Label[] TempLaColor;
        int ItemCount;
        string File_Name;
        string ProjectPath;
       

        public SelGraphViewC()
        {
            InitializeComponent();

            cms.Items.Add("속성 설정");
            cms.Items[0].Click += new EventHandler(Item_Select);
            scatterGraph1.ContextMenuStrip = cms;    
        }

        public NationalInstruments.UI.IScatterGraph ScatterGraphC
        {
            get { return scatterGraph1; }
            // set { listView1 = value; }
        }

        public void GraphViewItem(DataTable ListDataTable, string pFile_Name, string pProjectPath)
        {
            File_Name = pFile_Name;
            ProjectPath = pProjectPath;            
            ItemCount = ListDataTable.Columns.Count;


            ItemCb = new CheckBox[ItemCount];
            ItemLb = new Label[ItemCount];
            Item_Create(ListDataTable);

            TempDataTabel = ListDataTable;
            att_panel.Visible = true;
            LoadTableIntoList_HMI(TempDataTabel);
            att_panel.Visible = false;
        }

        private void Item_Select(object sender, EventArgs e)
        {
            try
            {
                string Path_filename = this.ProjectPath + "\\Config\\" + File_Name;

                if (!File.Exists(Path_filename))
                {
                    CreteWriteXML(TempDataTabel);
                }

                ReadXML(false);
                Range_Pan.Visible = true;
                att_panel.Visible = true;
                OK_Panel.Visible = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        private void Item_Create(DataTable table)
        {
            try
            {
                string Path_filename = this.ProjectPath + "\\Config\\" + File_Name;

                if (!File.Exists(Path_filename))
                {
                    CreteWriteXML(table);
                }        

                ReadXML(true);            
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            //att_panel.Controls.Clear();
            //Font TempFont = new Font("굴림", 12);

            //for (int i = 0; i < ItemCount; i++)
            //{
            //    ItemCb[i] = new CheckBox();
            //    ItemLb[i] = new Label();

            //    ItemCb[i].Font = TempFont;

            //    ItemCb[i].Text = table.Columns[i].ColumnName.ToString();

            //    ItemLb[i].Tag = i.ToString();

            //    ItemCb[i].AutoSize = true;

            //    ItemLb[i].Enabled = true;

            //    if (i == 0 || i == ItemCount - 1 )
            //    {
            //        ItemCb[i].Visible = false;
            //        ItemLb[i].Visible = false;
            //    }
            //    else
            //    {
            //        ItemCb[i].Visible = true;
            //        ItemLb[i].Visible = true;
            //    }

            //    ItemCb[i].BackColor = Color.Transparent;
            //    ItemLb[i].BackColor = scatterGraph1.Plots[i].LineColor;

            //    if (i == 2 || i == 4 || i == 6 || i == 8 || i == 10 || i == 12 || i == 14 || i == 16 || i == 18 || i == 20 || i == 22 || i == 24 || i == 26 || i == 28)
            //    {
            //        ItemCb[i].Checked = true;
            //    }
            //    else
            //    {
            //        ItemCb[i].Checked = false;
            //    }

            //    ItemLb[i].Size = new Size(100, 21);

            //    Point TempPo = new Point();
            //    TempPo.X = 10;
            //    TempPo.Y = 40 * (i + 1);

            //    Point TempPoTe = new Point();
            //    TempPoTe.X = 250;
            //    TempPoTe.Y = 40 * (i + 1);

            //    ItemCb[i].Location = TempPo;
            //    ItemLb[i].Location = TempPoTe;

            //    ItemLb[i].Click += new System.EventHandler(this.button_ColorC_Click);

            //    att_panel.Controls.Add(ItemCb[i]);
            //    att_panel.Controls.Add(ItemLb[i]);
            //}
        }

        private void button_ColorC_Click(object sender, EventArgs e)
        {
            try
            {
                Label TempLb = (Label)sender;
                ColorDialog SelColor = new ColorDialog();
                DialogResult RCheck = new DialogResult();
                RCheck = SelColor.ShowDialog();
                if (RCheck == DialogResult.OK)
                {
                    TempLb.BackColor = SelColor.Color;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        private void LoadTableIntoList_HMI(DataTable table)
        {
            try
            {
                       
             scatterGraph1.ClearData();
             
        
             double TempVal;
             double TempDTdb;
             DateTime TempDT;

             if (table.Rows.Count > 0)
             {
                 List<double> x = new List<double>();
                 List<List<double>> y = new List<List<double>>();

                 int cnt_y = 0;
                 for (cnt_y = 0; cnt_y <  table.Columns.Count ; cnt_y++)
                 {
                     y.Add(new List<double>());
                 }



                 for (int i = 0; i < table.Rows.Count-1; i++)
                 {

                     DataRow row = table.Rows[i];

                     if (row[0].ToString() == "")
                     {
                         continue;
                     }
                     string TempDateStr = row[0].ToString();

                     switch (TempDateStr.Length)
                     {
                         case 13:
                             TempDateStr = TempDateStr + ":00";
                             break;
                         case 10:
                            TempDateStr = TempDateStr + " 00:00";
                             break;
                         case 7:
                             TempDateStr = TempDateStr + "-01 00:00";
                             break;
                         case 4:
                             TempDateStr = TempDateStr + "-01-01 00:00";
                             break;
                         case 16:                           
                             break;
                         default:                           
                             break;
                     }

                     TempDT = Convert.ToDateTime(TempDateStr);
                     
                     TempDTdb = (double)NationalInstruments.DataConverter.Convert(TempDT, typeof(double));
                     
                     x.Add(TempDTdb);
                     //x.Add(i);
                     for (cnt_y = 0; cnt_y < table.Columns.Count; cnt_y++)
                     {
                         if (ItemCb[cnt_y].Checked == true)
                         {
                             if (row[cnt_y].ToString() == "")
                             {
                                 row[cnt_y] = "0";
                             }

                             if (double.TryParse(row[cnt_y].ToString(), out TempVal))
                             {
                                 y[cnt_y].Add(Convert.ToDouble(row[cnt_y].ToString()));
                             }
                         }
                     }
                 }

                 scatterGraph1.BeginUpdate();
                 for (cnt_y = 0; cnt_y < table.Columns.Count ; cnt_y++)
                 {
                     if (ItemCb[cnt_y].Checked == true)
                     {
                         
                         scatterGraph1.Plots[cnt_y].PlotXYAppend(x.ToArray(), y[cnt_y].ToArray());
                     }
                 }

                
                 scatterGraph1.EndUpdate();
             }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            
        }

        private void bt_Load_Click(object sender, EventArgs e)
        {
            int MinVal = 0;
            int MaxVal = 20;
            bool Result = false;
            try
            {
                if (Fix_check.Checked == true)
                {
                    if (int.TryParse(MinR_tb.Text, out MinVal) && int.TryParse(MaxR_tb.Text, out MaxVal))
                    {
                        if (MaxVal > MinVal)
                            Result = true;
                        else
                            Result = false;
                    }
                }
                else
                {
                    Result = true;
                }

                if (Result == false)
                {
                    MessageBox.Show("고정값을 사용하시려면 범위를 정확히 넣어야합니다.");
                    return;
                }

                SaveWriteXML();

                ReadXML(true);

                LoadTableIntoList_HMI(TempDataTabel);

                att_panel.Visible = false;
                OK_Panel.Visible = false;
                Range_Pan.Visible = false;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        
        }

        private void C_bt_Click(object sender, EventArgs e)
        {
            Range_Pan.Visible = false;
            att_panel.Visible = false;            
            OK_Panel.Visible = false;
        }

        private void CreateXML()
        {
        }

        private void CreteWriteXML(DataTable table)
        {
            try
            {
                string Path_filename = this.ProjectPath + "\\Config\\" + File_Name;

                int RColorStr;

                // 생성할 XML 파일 경로와 이름, 인코딩 방식을 설정합니다.
                XmlTextWriter textWriter = new XmlTextWriter(Path_filename, Encoding.UTF8);

                // 들여쓰기 설정
                textWriter.Formatting = Formatting.Indented;

                // 문서에 쓰기를 시작합니다.
                textWriter.WriteStartDocument();
                textWriter.WriteStartElement("root");

                textWriter.WriteStartElement("Item");

                textWriter.WriteStartElement("Key");
                textWriter.WriteStartElement("string");
                textWriter.WriteString("-1");
                textWriter.WriteEndElement();
                textWriter.WriteEndElement();

                textWriter.WriteStartElement("name");
                textWriter.WriteStartElement("string");
                textWriter.WriteString("Range");
                textWriter.WriteEndElement();
                textWriter.WriteEndElement();

                textWriter.WriteStartElement("checked");
                textWriter.WriteStartElement("string");
                textWriter.WriteString("false");
                textWriter.WriteEndElement();
                textWriter.WriteEndElement();

                textWriter.WriteStartElement("MinVal");
                textWriter.WriteStartElement("string");
                textWriter.WriteString("0");
                textWriter.WriteEndElement();
                textWriter.WriteEndElement();

                textWriter.WriteStartElement("MaxVal");
                textWriter.WriteStartElement("string");
                textWriter.WriteString("100");
                textWriter.WriteEndElement();
                textWriter.WriteEndElement();

                textWriter.WriteStartElement("BackColor");
                textWriter.WriteStartElement("string");
                RColorStr = BackColor_La.BackColor.ToArgb();
                //RColorStr = RColorStr.Replace("Color [", "");
                //RColorStr = RColorStr.Replace("]", "");
                textWriter.WriteString(RColorStr.ToString());
                textWriter.WriteEndElement();
                textWriter.WriteEndElement();

                textWriter.WriteEndElement();
               
                for (int i = 0; i < ItemCount; i++)
                {
                    textWriter.WriteStartElement("Item");

                    textWriter.WriteStartElement("Key");
                    textWriter.WriteStartElement("string");
                    textWriter.WriteString(i.ToString());
                    textWriter.WriteEndElement();
                    textWriter.WriteEndElement();

                    textWriter.WriteStartElement("name");
                    textWriter.WriteStartElement("string");
                    textWriter.WriteString(table.Columns[i].ColumnName.ToString());
                    textWriter.WriteEndElement();
                    textWriter.WriteEndElement();

                    if (i == 0 || i == ItemCount - 1)
                    {
                        textWriter.WriteStartElement("visible");
                        textWriter.WriteStartElement("string");
                        textWriter.WriteString("false");
                        textWriter.WriteEndElement();
                        textWriter.WriteEndElement();

                        textWriter.WriteStartElement("checked");
                        textWriter.WriteStartElement("string");
                        textWriter.WriteString("false");
                        textWriter.WriteEndElement();
                        textWriter.WriteEndElement();
                    }
                    else
                    {
                        textWriter.WriteStartElement("visible");
                        textWriter.WriteStartElement("string");
                        textWriter.WriteString("true");
                        textWriter.WriteEndElement();
                        textWriter.WriteEndElement();

                        textWriter.WriteStartElement("checked");
                        textWriter.WriteStartElement("string");
                        textWriter.WriteString("true");
                        textWriter.WriteEndElement();
                        textWriter.WriteEndElement();
                    }
                    
                    textWriter.WriteStartElement("Color");
                    textWriter.WriteStartElement("string");
                    RColorStr = scatterGraph1.Plots[i].LineColor.ToArgb();
                    //RColorStr = RColorStr.Replace("Color [", "");
                    //RColorStr = RColorStr.Replace("]", "");
                    textWriter.WriteString(RColorStr.ToString());
                    textWriter.WriteEndElement();
                    textWriter.WriteEndElement();

                    textWriter.WriteEndElement();
                }
                             

                textWriter.WriteEndElement();

                textWriter.WriteEndDocument();
                textWriter.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        private void SaveWriteXML()
        {
            try
            {
                string Path_filename = this.ProjectPath + "\\Config\\" + File_Name;

                int RColorStr;

                // 생성할 XML 파일 경로와 이름, 인코딩 방식을 설정합니다.
                XmlTextWriter textWriter = new XmlTextWriter(Path_filename, Encoding.UTF8);

                // 들여쓰기 설정
                textWriter.Formatting = Formatting.Indented;

                // 문서에 쓰기를 시작합니다.
                textWriter.WriteStartDocument();
                textWriter.WriteStartElement("root");

                textWriter.WriteStartElement("Item");

                textWriter.WriteStartElement("Key");
                textWriter.WriteStartElement("string");
                textWriter.WriteString("-1");
                textWriter.WriteEndElement();
                textWriter.WriteEndElement();

                textWriter.WriteStartElement("name");
                textWriter.WriteStartElement("string");
                textWriter.WriteString("Range");
                textWriter.WriteEndElement();
                textWriter.WriteEndElement();

                textWriter.WriteStartElement("checked");
                textWriter.WriteStartElement("string");
                textWriter.WriteString(Fix_check.Checked.ToString());
                textWriter.WriteEndElement();
                textWriter.WriteEndElement();

                textWriter.WriteStartElement("MinVal");
                textWriter.WriteStartElement("string");
                textWriter.WriteString(MinR_tb.Text.ToString());
                textWriter.WriteEndElement();
                textWriter.WriteEndElement();

                textWriter.WriteStartElement("MaxVal");
                textWriter.WriteStartElement("string");
                textWriter.WriteString(MaxR_tb.Text.ToString());
                textWriter.WriteEndElement();
                textWriter.WriteEndElement();

                textWriter.WriteStartElement("BackColor");
                textWriter.WriteStartElement("string");
                RColorStr = BackColor_La.BackColor.ToArgb();
                //RColorStr = RColorStr.Replace("Color [", "");
                //RColorStr = RColorStr.Replace("]", "");
                textWriter.WriteString(RColorStr.ToString());
                textWriter.WriteEndElement();
                textWriter.WriteEndElement();

                textWriter.WriteEndElement();

                for (int i = 0; i < ItemCount; i++)
                {
                    textWriter.WriteStartElement("Item");

                    textWriter.WriteStartElement("Key");
                    textWriter.WriteStartElement("string");
                    textWriter.WriteString(i.ToString());
                    textWriter.WriteEndElement();
                    textWriter.WriteEndElement();

                    textWriter.WriteStartElement("name");
                    textWriter.WriteStartElement("string");
                    textWriter.WriteString(ItemCb[i].Tag.ToString());
                    textWriter.WriteEndElement();
                    textWriter.WriteEndElement();
                  
                    textWriter.WriteStartElement("visible");
                    textWriter.WriteStartElement("string");
                    textWriter.WriteString(ItemCb[i].Visible.ToString());
                    textWriter.WriteEndElement();
                    textWriter.WriteEndElement();

                    textWriter.WriteStartElement("checked");
                    textWriter.WriteStartElement("string");
                    textWriter.WriteString(ItemCb[i].Checked.ToString());
                    textWriter.WriteEndElement();
                    textWriter.WriteEndElement();
                   
                  
                    textWriter.WriteStartElement("Color");
                    textWriter.WriteStartElement("string");
                    RColorStr = ItemLb[i].BackColor.ToArgb();
                    //RColorStr = RColorStr.Replace("Color [", "");
                    //RColorStr = RColorStr.Replace("]", "");
                    textWriter.WriteString(RColorStr.ToString());
                    textWriter.WriteEndElement();
                    textWriter.WriteEndElement();

                    textWriter.WriteEndElement();
                }




                textWriter.WriteEndElement();

                textWriter.WriteEndDocument();
                textWriter.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        private void ReadXML(bool Check_Redw)
        {
            try
            {
                int SelCount = 1;
                XmlDocument xmldoc = new XmlDocument();

                xmldoc.Load(this.ProjectPath + "\\Config\\" +File_Name);
                XmlElement root = xmldoc.DocumentElement;

                // 노드 요소들
                XmlNodeList nodes = root.ChildNodes;

                int ItemCount = nodes.Count;
                ItemCb = new CheckBox[ItemCount];
                ItemLb = new Label[ItemCount];

                TempLaName = new Label[ItemCount];
                TempLaColor = new Label[ItemCount];

                Color Tempcolor = new Color();

                att_panel.Controls.Clear();
                TempPanel.Controls.Clear();
              
                Font TempFont = new Font("굴림", 12);

                // 노드 요소의 값을 읽어 옵니다.
                foreach (XmlNode node in nodes)
                {

                    int Key = int.Parse(node.ChildNodes[0].InnerText);

                    if (Key < 0)
                    {
                        if (node.ChildNodes[1].InnerText == "Range")
                        {
                            Fix_check.Checked = bool.Parse(node.ChildNodes[2].InnerText);
                            MinR_tb.Text = node.ChildNodes[3].InnerText;
                            MaxR_tb.Text = node.ChildNodes[4].InnerText;
                         
                            Tempcolor = Color.FromArgb(int.Parse(node.ChildNodes[5].InnerText));
                            BackColor_La.BackColor  = Tempcolor;
                        }
                    }
                    else
                    {
                        ItemCb[Key] = new CheckBox();
                        ItemLb[Key] = new Label();

                        ItemCb[Key].Font = TempFont;
                        
                        string ReName = node.ChildNodes[1].InnerText;

                        if (ReName != "작업일시" && ReName != "구분")
                        {
                            int PLCCheck = 0;

                            PLCCheck = ReName.IndexOf("PLC");

                            if (PLCCheck < 0)
                            {
                                ReName = ReName + "(PC)";
                            }
                            else
                            {
                                ReName = ReName.Replace("_PLC", "") + "(PLC)";
                            }

                            ReName = ReName.Replace("인고트", "인고트중량");
                            ReName = ReName.Replace("스크랩", "스크랩중량");
                            //ReName = ReName.Replace("타워", "용해실");

                        }

                        ItemCb[Key].Text = ReName;

                        ItemLb[Key].Tag = node.ChildNodes[1].InnerText;

                        ItemCb[Key].Tag = node.ChildNodes[1].InnerText;

                        ItemCb[Key].AutoSize = true;

                        ItemCb[Key].Visible = bool.Parse(node.ChildNodes[2].InnerText);
                        ItemLb[Key].Visible = bool.Parse(node.ChildNodes[2].InnerText);

                        ItemCb[Key].Checked = bool.Parse(node.ChildNodes[3].InnerText);

                        ItemCb[Key].BackColor = Color.Transparent;
                        Tempcolor = Color.FromArgb(int.Parse(node.ChildNodes[4].InnerText));
                        ItemLb[Key].BackColor = Tempcolor;

                        ItemLb[Key].Size = new Size(100, 21);

                        Point TempPo = new Point();
                        TempPo.X = 10;
                        TempPo.Y = 40 * (Key + 1);

                        Point TempPoTe = new Point();
                        TempPoTe.X = 250;
                        TempPoTe.Y = 40 * (Key + 1);

                        ItemCb[Key].Location = TempPo;
                        ItemLb[Key].Location = TempPoTe;

                        ItemLb[Key].Click += new System.EventHandler(this.button_ColorC_Click);

                        if (ItemCb[Key].Checked == true)
                        {
                            TempLaName[Key] = new Label();
                            TempLaColor[Key] = new Label();

                            TempLaName[Key].Font = TempFont;

                            TempLaName[Key].BackColor = Color.Transparent;
                            TempLaColor[Key].BackColor = ItemLb[Key].BackColor;

                            TempLaName[Key].AutoSize =true;
                            TempLaColor[Key].Size = new Size(30, 21);

                            TempLaName[Key].Text = ItemCb[Key].Text;
                            TempLaColor[Key].Text = "";

                            TempLaName[Key].Visible = true;
                            TempLaColor[Key].Visible = true;

                            Point TempLaPN = new Point();
                            TempLaPN.X = 10;
                            TempLaPN.Y = 40 * (SelCount + 1);

                            Point TempLaPC = new Point();
                            TempLaPC.X = 200;
                            TempLaPC.Y = 40 * (SelCount + 1);

                            TempLaName[Key].Location = TempLaPN;
                            TempLaColor[Key].Location = TempLaPC;

                            SelCount = SelCount + 1;

                            TempPanel.Controls.Add(TempLaColor[Key]);
                            TempPanel.Controls.Add(TempLaName[Key]);
                           
                        }        

                        att_panel.Controls.Add(ItemCb[Key]);
                        att_panel.Controls.Add(ItemLb[Key]);
                        
                    }
                }
              
                if (Check_Redw == true)
                {
                    
                    scatterGraph1.PlotAreaColor = BackColor_La.BackColor;
                    Font AnnFont = new Font("굴림", 18);
                    scatterGraph1.XAxes[0].MajorDivisions.GridVisible = true;
                    scatterGraph1.YAxes[0].MajorDivisions.GridVisible = true;

                    scatterGraph1.XAxes[0].MajorDivisions.GridLineStyle = NationalInstruments.UI.LineStyle.Dot;
                    scatterGraph1.YAxes[0].MajorDivisions.GridLineStyle = NationalInstruments.UI.LineStyle.Dot;
                    for (int i = 0; i < 30; i++)
                    {                        
                        scatterGraph1.Plots[i].Visible = false;
                        scatterGraph1.Plots[i].LineWidth = 2;
                        scatterGraph1.Annotations[i].Visible = false;
                        scatterGraph1.Annotations[i].InteractionMode = NationalInstruments.UI.AnnotationInteractionMode.None;
                        scatterGraph1.Annotations[i].CaptionFont = AnnFont;
                        scatterGraph1.Annotations[i].CaptionVisible = false;
                        scatterGraph1.Annotations[i].ArrowVisible = false;
                        NationalInstruments.UI.AnnotationCaptionAlignment AnnCaptionA = new NationalInstruments.UI.AnnotationCaptionAlignment(NationalInstruments.UI.BoundsAlignment.TopLeft,0 ,0);
                        scatterGraph1.Annotations[i].CaptionAlignment = AnnCaptionA;   
                    }

                    int AnnCount = 0;

                    for (int i = 0; i < ItemCount; i++)
                    {
                        if (ItemLb[i] != null)
                        {
                            scatterGraph1.Plots[i].LineColor = ItemLb[i].BackColor;
                            scatterGraph1.Plots[i].Visible = ItemCb[i].Checked;

                            scatterGraph1.Annotations[i].Visible = ItemCb[i].Checked;
                            scatterGraph1.Annotations[i].Caption = ItemCb[i].Text;
                            scatterGraph1.Annotations[i].CaptionForeColor = ItemLb[i].BackColor;
                            scatterGraph1.Annotations[i].CaptionVisible = ItemCb[i].Checked;                           
                            NationalInstruments.UI.AnnotationCaptionAlignment AnnCaptionA = new NationalInstruments.UI.AnnotationCaptionAlignment(NationalInstruments.UI.BoundsAlignment.TopLeft, 10, (AnnCount * 30) +10);
                            scatterGraph1.Annotations[i].CaptionAlignment = AnnCaptionA;
                            if (ItemCb[i].Checked == true)
                            {
                                AnnCount = AnnCount + 1;
                            }
                        }
                    }

                    int MinVal = 0;
                    int MaxVal = 20;
                    bool Result = false;

                    if (Fix_check.Checked == true)
                    {
                        if (int.TryParse(MinR_tb.Text, out MinVal) && int.TryParse(MaxR_tb.Text, out MaxVal))
                        {
                            if (MaxVal > MinVal)
                                Result = true;
                            else
                                Result = false;
                        }
                    }
                    else
                    {
                        Result = true;
                    }

                    if (Result == true)
                    {
                        if (Fix_check.Checked == true)
                        {
                            scatterGraph1.YAxes[0].Range = new NationalInstruments.UI.Range(MinVal, MaxVal);
                            scatterGraph1.YAxes[0].Mode = NationalInstruments.UI.AxisMode.Fixed;

                        }
                        else
                        {
                            scatterGraph1.YAxes[0].Range = new NationalInstruments.UI.Range(0, 20);
                            scatterGraph1.YAxes[0].Mode = NationalInstruments.UI.AxisMode.AutoScaleLoose;
                        }
                    }
                    else
                    {
                        MessageBox.Show("고정값 설정이 잘 못 되었습니다. 설정을 확인하여 주세요.");
                        return;
                    }
                }
                 
           
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        private void Fix_check_CheckedChanged(object sender, EventArgs e)
        {
            MaxR_tb.Enabled = Fix_check.Checked;
            MinR_tb.Enabled = Fix_check.Checked;
        }

       
    }
}
