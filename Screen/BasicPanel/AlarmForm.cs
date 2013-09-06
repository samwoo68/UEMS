using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using System.Data.OleDb;


namespace BasicPanel
{
    public partial class AlarmForm : IronPanel.AlarmForm
    {
        OleDbConnection connection;

        public AlarmForm()
        {
            InitializeComponent();
        }
        public DataSet CreateCmdsAndUpdate(string connectionString, string queryString, string tableName)
        {
            try
            {
                //using (OleDbConnection connection = new OleDbConnection(connectionString))
                using (connection = new OleDbConnection(connectionString))
                {

                    OleDbDataAdapter adapter = new OleDbDataAdapter();

                    adapter.SelectCommand = new OleDbCommand(queryString, connection);

                    OleDbCommandBuilder builder = new OleDbCommandBuilder(adapter);

                    connection.Open();

                    DataSet customers = new DataSet();

                    adapter.Fill(customers, tableName); //code to modify data in dataset here

                    //adapter.Update(customers, tableName);

                    return customers;

                }
            }
            catch (Exception)
            {
                DataSet customers = new DataSet();
                return customers;
            }
        }
        private void Alarm_Remove_Item()
        {
            int CheitemCount = listView_alarm.Items.Count;
            for (int i = 0; i < CheitemCount; i++)
            {
                if (listView_alarm.Items[i].ForeColor != Color.Red)
                {
                    listView_alarm.Items[i].Remove();
                    CheitemCount = CheitemCount - 1;
                    i = i - 1;
                }
            }
        }
        private void Alarm_Add_Item()
        {
            string strQuery = "SELECT Top 17 ExceptionID, ExceptionTime, ExceptionMsg, RecoveryAction FROM AlarmHistory WHERE RecoveryAction <> '' Order By ExceptionTime DESC";
            DataSet ds1 = CreateCmdsAndUpdate(@"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + "C:\\EEMS-R1\\Database\\AlarmHistory.mdb", strQuery, "AlarmHistory");

            int itemCount = listView_alarm.Items.Count;

            for (int i = 0; i < ds1.Tables[0].Rows.Count - itemCount; i++)
            {
                ListViewItem item2 = new ListViewItem(ds1.Tables[0].Rows[i][0].ToString());
                //item2.Name = ds1.Tables[0].Rows[i][0].ToString();
                item2.SubItems.Add(ds1.Tables[0].Rows[i][1].ToString());
                item2.SubItems.Add(ds1.Tables[0].Rows[i][2].ToString());
                item2.SubItems.Add("false");
                item2.SubItems.Add("");
                item2.ForeColor = Color.Black;
                listView_alarm.Items.Add(item2);
            }
        }

        private void AlarmForm_RaiseAlarm(object sender, IronPanel.AlarmEventArgs e)
        {
            Alarm_Remove_Item();

            ListViewItem item = new ListViewItem(e.alid.ToString());
            
            item.Name = e.alid.ToString();
            item.SubItems.Add(e.time.ToString());
            item.SubItems.Add(e.message.ToString());
            item.SubItems.Add(e.recovery.ToString());
            item.SubItems.Add(e.note.ToString());
            item.ForeColor = Color.Red;
            listView_alarm.Items.Add(item);

            Alarm_Add_Item();
            
        }

        private void AlarmForm_ClearAlarm(object sender, IronPanel.AlarmEventArgs e)
        {
            listView_alarm.Items.RemoveByKey(e.alid.ToString());
        }

        private void listView_alarm_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listView_alarm.SelectedIndices.Count > 0)
            {
                if (bool.Parse(listView_alarm.SelectedItems[0].SubItems[3].Text))
                {
                    button_abort.Visible = true;
                    button_resume.Visible = true;
                    button_retry.Visible = true;
                }
                else
                {
                    if (listView_alarm.SelectedItems[0].ForeColor == Color.Red)
                    {
                        button_confirm.Visible = true;
                    }
                    else
                    {
                        button_confirm.Visible = false;
                    }
                }

                richTextBox_description.Text = listView_alarm.SelectedItems[0].SubItems[4].Text;
            }
            else
            {
                button_confirm.Visible = false;
                button_abort.Visible = false;
                button_resume.Visible = false;
                button_retry.Visible = false;
                richTextBox_description.Text = "";
            }
        }

        private void button_retry_Click(object sender, EventArgs e)
        {
            if (listView_alarm.SelectedItems.Count > 0)
            {
                ListViewItem item = listView_alarm.SelectedItems[0];
                int alid = int.Parse(item.Text);

                RemoveAlarm(alid, IronPanel._AlarmStatus.Retry);

                Alarm_Remove_Item();
                Alarm_Add_Item();
            }

            button_retry.Visible = false;
            button_resume.Visible = false;
            button_abort.Visible = false;
            button_confirm.Visible = false;
        }

        private void button_resume_Click(object sender, EventArgs e)
        {
            if (listView_alarm.SelectedItems.Count > 0)
            {
                ListViewItem item = listView_alarm.SelectedItems[0];
                int alid = int.Parse(item.Text);

                RemoveAlarm(alid, IronPanel._AlarmStatus.Resume);
                Alarm_Remove_Item();
                Alarm_Add_Item();
            }

            button_retry.Visible = false;
            button_resume.Visible = false;
            button_abort.Visible = false;
            button_confirm.Visible = false;
        }

        private void button_abort_Click(object sender, EventArgs e)
        {
            if (listView_alarm.SelectedItems.Count > 0)
            {
                ListViewItem item = listView_alarm.SelectedItems[0];

                int alid = int.Parse(item.Text);

                RemoveAlarm(alid, IronPanel._AlarmStatus.Abort);
                Alarm_Remove_Item();
                Alarm_Add_Item();
            }

            button_retry.Visible = false;
            button_resume.Visible = false;
            button_abort.Visible = false;
            button_confirm.Visible = false;
        }

        private void button_confirm_Click(object sender, EventArgs e)
        {
            if (listView_alarm.SelectedItems.Count > 0)
            {
                int alid = int.Parse(listView_alarm.SelectedItems[0].Text);

                RemoveAlarm(alid, IronPanel._AlarmStatus.Confirm);
                Alarm_Remove_Item();
                Alarm_Add_Item();
            }

            button_retry.Visible = false;
            button_resume.Visible = false;
            button_abort.Visible = false;
            button_confirm.Visible = false;
        }

        private void button_close_Click(object sender, EventArgs e)
        {
            //button_retry.Visible = false;
            //button_resume.Visible = false;
            //button_abort.Visible = false;
            //button_confirm.Visible = false;
            //richTextBox_description.Text = "";

            this.Hide();
        }

        private void AlarmForm_Leave(object sender, EventArgs e)
        {
            button_confirm.Visible = false;
            button_resume.Visible = false;
            button_abort.Visible = false;
            button_retry.Visible = false;
            richTextBox_description.Text = "";
        }

        private void AlarmForm_Load(object sender, EventArgs e)
        {
        }

        private void AlarmForm_Activated(object sender, EventArgs e)
        {
            Alarm_Remove_Item();
            Alarm_Add_Item();
        }
      
    }
}