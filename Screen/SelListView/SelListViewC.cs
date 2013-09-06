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

namespace SelListView
{
    public partial class SelListViewC : IronControls.BaseControl
    {
        ContextMenuStrip cms = new ContextMenuStrip();

        DataTable TempDataTabel;
        CheckBox[] ItemCb;
      
        int ItemCount;

        string File_Name;
        string ProjectPath;

        public SelListViewC()
        {
            InitializeComponent();
            cms.Items.Add("속성 설정");
            cms.Items[0].Click += new EventHandler(Item_Select);
            listView1.ContextMenuStrip = cms;           
        }

        public Font ListViewItem_Font
        {
            get { return listView1.Font as Font; }
            set { listView1.Font = value; }
        }

        public ListView ListViewC
        {
            get { return listView1; }
           // set { listView1 = value; }
        }

        public void ListViewItem(DataTable ListDataTable, string pFile_Name, string pProjectPath)
        {
            File_Name = pFile_Name;
            ProjectPath = pProjectPath;            
            ItemCount = ListDataTable.Columns.Count;
            ItemCb = new CheckBox[ItemCount];
            Item_Create(ListDataTable);

            TempDataTabel = ListDataTable;

            att_panel.Visible = true;
            LoadTableIntoList_HMI(listView1, TempDataTabel);
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

                ReadXML();
                att_panel.Visible = true;
                OK_Panel.Visible = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        private void Item_Create( DataTable table)
        {
            try
            {
                string Path_filename = this.ProjectPath + "\\Config\\" + File_Name;

                if (!File.Exists(Path_filename))
                {
                    CreteWriteXML(table);
                }

                ReadXML();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            //att_panel.Controls.Clear();
            //Font TempFont = new Font("굴림", 14);

            //for (int i = 0; i < ItemCount; i++)
            //{
            //    ItemCb[i] = new CheckBox();          

            //    ItemCb[i].Font = TempFont;
            //    ItemCb[i].Text = table.Columns[i].ColumnName.ToString();
            //    ItemCb[i].AutoSize = true;
            //    ItemCb[i].Visible = true;
            //    ItemCb[i].BackColor = Color.Transparent;
            //    if (i == 0 || i == 2 || i == 4 || i == 6 || i == 8 || i == 10 || i == 12 || i == 14 || i == 16 || i == 18 || i == 20 || i == 22 || i == 24 || i == 26 || i == 28 )
            //    {
            //        ItemCb[i].Checked = true;
            //    }
            //    else
            //    {
            //        ItemCb[i].Checked = false;
            //    }
            //    Point TempPo = new Point();
            //    TempPo.X = 10;
            //    TempPo.Y = 40*(i+1);
            //    ItemCb[i].Location = TempPo;
            //    att_panel.Controls.Add(ItemCb[i]);
            //}
        }

        private void LoadTableIntoList_HMI(ListView lv, DataTable table)
        {

            try
            {
                lv.Items.Clear();

                int ind = 0;

                lv.Columns.Clear();

               
                lv.Columns.Add(table.Columns[0].ColumnName.ToString(), 200, HorizontalAlignment.Center);

                foreach (DataColumn dc in table.Columns)
                {
                    if (ItemCb[ind].Checked == true && ind != 0)
                    {
                        lv.Columns.Add(ItemCb[ind].Text, 200, HorizontalAlignment.Center);

                    }
                    ind++;
                }

                lv.BeginUpdate();

                ind = 0;
                foreach (DataRow row in table.Rows)
                {
                    ListViewItem lvi = new ListViewItem();

                    //lvi.ImageIndex = Int32.Parse(row[1].ToString());
                    if (row[table.Columns.Count - 1].ToString() == "SUM")
                    {
                        lvi.Text = "종   합";
                    }
                    else
                    {
                        lvi.Text = row[0].ToString();
                    }

                    for (int i = 1; i < table.Columns.Count; i++)
                    {
                        double TempVal;
                        bool result;

                        if (ItemCb[i].Checked == true)
                        {
                            result = double.TryParse(row[i].ToString(), out TempVal);

                            if (result == true)
                            {
                                TempVal = Math.Floor((TempVal * 100)) / 100;
                                lvi.SubItems.Add(TempVal.ToString());
                            }
                            else
                            {
                                lvi.SubItems.Add(row[i].ToString());
                            }

                        }

                    }

                    lvi.Font = new Font("굴림", 18);
                    if (lvi.Text ==  "종   합")
                    {
                        lvi.ForeColor = Color.Red;

                    }

                    if (ind % 2 == 0)
                    {
                        lv.Items.Add(lvi).BackColor = Color.WhiteSmoke;
                    }
                    else
                    {
                        lv.Items.Add(lvi).BackColor = Color.DarkGray;
                    }


                    ind++;                  


                }

                lv.EndUpdate();

                lv.TopItem = lv.Items[lv.Items.Count-1];
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        private void bt_Load_Click(object sender, EventArgs e)
        {
            try
            {
                SaveWriteXML();

                ReadXML();
                LoadTableIntoList_HMI(listView1, TempDataTabel);

                att_panel.Visible = false;
                OK_Panel.Visible = false;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        private void C_bt_Click(object sender, EventArgs e)
        {
            att_panel.Visible = false;
            OK_Panel.Visible = false;
        }

        private void listView1_DrawColumnHeader(object sender, DrawListViewColumnHeaderEventArgs e)
        {
            using (Font headerFont = new Font("굴림", 18, FontStyle.Bold))
            {
                e.Graphics.DrawString(e.Header.Text, headerFont, Brushes.Black, e.Bounds);
            }

        }

        private void CreateXML()
        {
        }

        private void CreteWriteXML(DataTable table)
        {
            try
            {
                string Path_filename = this.ProjectPath + "\\Config\\" + File_Name;


                // 생성할 XML 파일 경로와 이름, 인코딩 방식을 설정합니다.
                XmlTextWriter textWriter = new XmlTextWriter(Path_filename, Encoding.UTF8);

                // 들여쓰기 설정
                textWriter.Formatting = Formatting.Indented;

                // 문서에 쓰기를 시작합니다.
                textWriter.WriteStartDocument();
                textWriter.WriteStartElement("root");



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

                    textWriter.WriteStartElement("visible");
                    textWriter.WriteStartElement("string");
                    textWriter.WriteString("true");
                    textWriter.WriteEndElement();
                    textWriter.WriteEndElement();
                   

                    if (i == ItemCount - 1)
                    {     
                        textWriter.WriteStartElement("checked");
                        textWriter.WriteStartElement("string");
                        textWriter.WriteString("false");
                        textWriter.WriteEndElement();
                        textWriter.WriteEndElement();
                    }
                    else
                    {
                       

                        textWriter.WriteStartElement("checked");
                        textWriter.WriteStartElement("string");
                        textWriter.WriteString("true");
                        textWriter.WriteEndElement();
                        textWriter.WriteEndElement();
                    }

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


                // 생성할 XML 파일 경로와 이름, 인코딩 방식을 설정합니다.
                XmlTextWriter textWriter = new XmlTextWriter(Path_filename, Encoding.UTF8);

                // 들여쓰기 설정
                textWriter.Formatting = Formatting.Indented;

                // 문서에 쓰기를 시작합니다.
                textWriter.WriteStartDocument();
                textWriter.WriteStartElement("root");



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

        private void ReadXML()
        {
            try
            {
                XmlDocument xmldoc = new XmlDocument();

                xmldoc.Load(this.ProjectPath + "\\Config\\" + File_Name);
                XmlElement root = xmldoc.DocumentElement;

                // 노드 요소들
                XmlNodeList nodes = root.ChildNodes;

                int ItemCount = nodes.Count;
                ItemCb = new CheckBox[ItemCount];   

                att_panel.Controls.Clear();
                Font TempFont = new Font("굴림", 12);

                // 노드 요소의 값을 읽어 옵니다.
                foreach (XmlNode node in nodes)
                {

                    int Key = int.Parse(node.ChildNodes[0].InnerText);

                    ItemCb[Key] = new CheckBox();
                   
                    ItemCb[Key].Font = TempFont;

                    ItemCb[Key].Tag = node.ChildNodes[1].InnerText;        

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

                    ItemCb[Key].AutoSize = true;

                    ItemCb[Key].BackColor = Color.Transparent;

                    ItemCb[Key].Visible = bool.Parse(node.ChildNodes[2].InnerText);

                    ItemCb[Key].Checked = bool.Parse(node.ChildNodes[3].InnerText);
                    
                    Point TempPo = new Point();
                    TempPo.X = 10;
                    TempPo.Y = 40 * (Key + 1);

                   
                    ItemCb[Key].Location = TempPo;                    

                    att_panel.Controls.Add(ItemCb[Key]);                   
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
       
    }
}
