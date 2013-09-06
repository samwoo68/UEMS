using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;

namespace UEMScreen
{
    public partial class AlarmHistory : IronPanel.InformationPanel
    {
        public AlarmHistory()
        {
            InitializeComponent();
        }

        private void button_search_Click(object sender, EventArgs e)
        {
            this.alarmHistoryTableAdapter.Fill(this.alarmHistoryDataSet.AlarmHistory);

            DateTime end = new DateTime(dateTimePicker_end.Value.Year, dateTimePicker_end.Value.Month, dateTimePicker_end.Value.Day);

            end = end.AddDays(1);

            listView_history.ListViewItemSorter = null;

            listView_history.Items.Clear();

            try
            {
                string strCMD = "ExceptionTime >= #" + dateTimePicker_start.Value.Date.ToString("MM-dd-yy HH:mm:ss") + "# AND ExceptionTime < #" + end.ToString("MM-dd-yy HH:mm:ss") + "#";

                DataRow[] rows = alarmHistoryDataSet.AlarmHistory.Select(strCMD, "ExceptionTime DESC"); // Aarm 정렬방향설정

                int index = 1;

                listView_history.BeginUpdate();

                foreach (AlarmHistoryDataSet.AlarmHistoryRow row in rows)
                {
                    ListViewItem item = new ListViewItem(index.ToString());

                    item.SubItems.Add(row.IsExceptionTimeNull() ? "" : row.ExceptionTime.ToString());
                    item.SubItems.Add(row.IsRecoveryTimeNull() ? "" : row.RecoveryTime.ToString());
                    item.SubItems.Add(""); //Level;
                    item.SubItems.Add(""); //Module;
                    item.SubItems.Add(row.ExceptionID.ToString());
                    item.SubItems.Add(row.IsExceptionMsgNull() ? "" : row.ExceptionMsg.ToString());

                    listView_history.Items.Add(item);
                    index++;
                }

                listView_history.EndUpdate();

                ColumnClickEventArgs ClickEvent = new ColumnClickEventArgs(1);

                listView_history_ColumnClick(sender, ClickEvent);
            }
            catch (SystemException ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void button_delete_Click(object sender, EventArgs e)
        {
            DateTime end = new DateTime(dateTimePicker_delEnd.Value.Year, dateTimePicker_delEnd.Value.Month, dateTimePicker_delEnd.Value.Day + 1);

            listView_history.Items.Clear();

            try
            {
                string strCMD = "ExceptionTime >= #" + dateTimePicker_start.Value.Date.ToString("MM-dd-yy HH:mm:ss") + "# AND ExceptionTime < #" + end.ToString("MM-dd-yy HH:mm:ss") + "#";

                DataRow[] rows = alarmHistoryDataSet.AlarmHistory.Select(strCMD, "ExceptionTime ASC");


                foreach (AlarmHistoryDataSet.AlarmHistoryRow row in rows)
                {
                    row.Delete();
                }

                alarmHistoryTableAdapter.Update(alarmHistoryDataSet);
            }
            catch (SystemException ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void listView_history_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            if (listView_history.Sorting == SortOrder.Ascending || listView_history.Sorting == SortOrder.None)
            {
                listView_history.ListViewItemSorter = new ListViewItemCompare(e.Column, "desc");
                listView_history.Sorting = SortOrder.Descending;
            }
            else
            {
                listView_history.ListViewItemSorter = new ListViewItemCompare(e.Column, "asc");
                listView_history.Sorting = SortOrder.Ascending;
            }
            listView_history.Sort();


        }

        private void dateTimePicker_start_MouseDown(object sender, MouseEventArgs e)
        {
            dateTimePicker_start.Focus();
            SendKeys.SendWait("{F4}");
        }

        private void dateTimePicker_end_MouseDown(object sender, MouseEventArgs e)
        {
            dateTimePicker_end.Focus();
            SendKeys.SendWait("{F4}");
        }

        private void dateTimePicker_delStart_MouseDown(object sender, MouseEventArgs e)
        {
            dateTimePicker_delStart.Focus();
            SendKeys.SendWait("{F4}");
        }

        private void dateTimePicker_delEnd_MouseDown(object sender, MouseEventArgs e)
        {
            dateTimePicker_delEnd.Focus();
            SendKeys.SendWait("{F4}");
        }

        private void AlarmHistory_Load(object sender, EventArgs e)
        {
            this.alarmHistoryTableAdapter.Fill(this.alarmHistoryDataSet.AlarmHistory);
        }
    }

    class ListViewItemCompare : IComparer
    {
        private int nCol;
        public string szSort = "asc";

        public ListViewItemCompare()
        {
            nCol = 0;
        }

        public ListViewItemCompare(int nColumn, string szSort)
        {
            nCol = nColumn;
            this.szSort = szSort;
        }

        public int Compare(object x, object y)
        {
            int chk = 1;

            try
            {
                if (szSort == "asc")
                    chk = 1;
                else
                    chk = -1;

                if (Convert.ToInt32(((ListViewItem)x).SubItems[nCol].Text) > Convert.ToInt32(((ListViewItem)y).SubItems[nCol].Text))
                    return chk;
                else
                    return -chk;

            }
            catch (Exception)
            {
                if (szSort == "asc")
                    return String.Compare(((ListViewItem)x).SubItems[nCol].Text, ((ListViewItem)y).SubItems[nCol].Text);
                else
                    return String.Compare(((ListViewItem)y).SubItems[nCol].Text, ((ListViewItem)x).SubItems[nCol].Text);
            }
        }
    }
}
