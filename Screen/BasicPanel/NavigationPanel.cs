using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace BasicPanel
{
    public partial class NavigationPanel : IronPanel.NavigationPanel
    {
        public bool Alarm_State=false;
        public bool TagTow = false;
        int[] diHandle = new int[200];
        bool[] EventResult = new bool[200];
  
        public NavigationPanel()
        {
            InitializeComponent();
        }
       

        public override void StartPanel()
        {

            base.StartPanel();            
            opcClient2.Connect();
            timer1.Enabled = true;

            TagEventConfig();
        }

        public override void StopPanel()
        {
            base.StopPanel();

            TagEventFree();

            opcClient2.Disconnect();
        }

        private void TagEventConfig()
        {
            diHandle[0] = opcClient2.Subscribe("PLC-XGK:M00945", CommLib.UpdateMode.OnChange, 1000, Callback_TagEvent);

            for (int i = 0; i < 200; i++)
            {
                EventResult[i] = false;

            }
        }

        private void TagEventFree()
        {
            opcClient2.Unsubscribe(diHandle[0]);
        }

        private void Callback_TagEvent(int notificationID, object[] value)
        {

            try
            {
                
                bool data = bool.Parse(value[0].ToString());

                if (EventResult[notificationID] == data)
                {
                    return;
                }
                else
                {
                    EventResult[notificationID] = data;
                }

                if (notificationID == diHandle[0] && data)
                {
                    TagTow = true;
                    //textBox1.Text = "타워에 재료가 없습니다. 재료를 투입하세요!!";
                    //textBox1.Visible = true;
                }
                else
                {
                    TagTow = false;
                    //textBox1.Visible = false;
                }
            }
            catch
            {
            }
        }

        public override void OccurAlarm(IronPanel.AlarmEventArgs e)
        {
            ListViewItem item = new ListViewItem(e.alid.ToString());

            item.Name = e.alid.ToString();
            item.SubItems.Add(e.time.ToString());
            item.SubItems.Add(e.message.ToString());
            item.SubItems.Add(e.recovery.ToString());
            item.SubItems.Add(e.note.ToString());

            listView_alarm.Items.Add(item);
            if (listView_alarm.Items.Count > 0)
            {
                textBox2.Visible = true;
                textBox2.Text = listView_alarm.Items[listView_alarm.Items.Count - 1].SubItems[2].Text.ToString().Replace("\t", "");
            }
        }

        public override void DisapperAlarm(IronPanel.AlarmEventArgs e)
        {
             listView_alarm.Items.RemoveByKey(e.alid.ToString());
             if (listView_alarm.Items.Count > 0)
             {
                 textBox2.Visible = true;
                 textBox2.Text = listView_alarm.Items[listView_alarm.Items.Count-1].SubItems[2].Text.ToString().Replace("\t", "");
             }
             else
             {
                 textBox2.Visible = false;
                 textBox2.Text = "";
             }
        }
        
        private void timer1_Tick(object sender, EventArgs e)
        {
            try
            {
                if (TagTow ==true)
                {
                    textBox1.Text = "타워에 재료가 없습니다. 재료를 투입하세요!!";
                    textBox1.Visible = !textBox1.Visible;
                }
                else
                {
                    textBox1.Visible = false;
                }
                //

            }
            catch (Exception)
            {
            }
        }
    }
}
