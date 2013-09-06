namespace BasicPanel
{
    partial class NavigationPanel
    {
        /// <summary> 
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 구성 요소 디자이너에서 생성한 코드

        /// <summary> 
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마십시오.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.opcClient2 = new OPCAdapter.OPCClient();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.listView_alarm = new System.Windows.Forms.ListView();
            this.columnHeader_id = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader_time = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader_message = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("굴림", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.textBox1.ForeColor = System.Drawing.Color.Red;
            this.textBox1.Location = new System.Drawing.Point(421, 14);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(412, 50);
            this.textBox1.TabIndex = 1;
            this.textBox1.Text = "타워에 재료가 없습니다. 재료를 투입하세요!!";
            // 
            // opcClient2
            // 
            this.opcClient2.Group = "MyGroup";
            this.opcClient2.ItemUpdate = true;
            this.opcClient2.Server = "Intellution.LSEOPC";
            this.opcClient2.SynchronizingObject = this;
            this.opcClient2.Topic = "";
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // textBox2
            // 
            this.textBox2.Font = new System.Drawing.Font("굴림", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.textBox2.ForeColor = System.Drawing.Color.Red;
            this.textBox2.Location = new System.Drawing.Point(1079, 14);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(660, 50);
            this.textBox2.TabIndex = 2;
            this.textBox2.Visible = false;
            // 
            // listView_alarm
            // 
            this.listView_alarm.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader_id,
            this.columnHeader_time,
            this.columnHeader_message});
            this.listView_alarm.Font = new System.Drawing.Font("굴림", 14F);
            this.listView_alarm.FullRowSelect = true;
            this.listView_alarm.GridLines = true;
            this.listView_alarm.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.listView_alarm.Location = new System.Drawing.Point(839, 14);
            this.listView_alarm.MultiSelect = false;
            this.listView_alarm.Name = "listView_alarm";
            this.listView_alarm.Size = new System.Drawing.Size(61, 50);
            this.listView_alarm.TabIndex = 3;
            this.listView_alarm.UseCompatibleStateImageBehavior = false;
            this.listView_alarm.View = System.Windows.Forms.View.Details;
            this.listView_alarm.Visible = false;
            // 
            // columnHeader_id
            // 
            this.columnHeader_id.Text = "ID";
            this.columnHeader_id.Width = 50;
            // 
            // columnHeader_time
            // 
            this.columnHeader_time.Text = "Time";
            this.columnHeader_time.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader_time.Width = 108;
            // 
            // columnHeader_message
            // 
            this.columnHeader_message.Text = "Message";
            this.columnHeader_message.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader_message.Width = 495;
            // 
            // NavigationPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.listView_alarm);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Name = "NavigationPanel";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox1;
        private OPCAdapter.OPCClient opcClient2;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.ListView listView_alarm;
        private System.Windows.Forms.ColumnHeader columnHeader_id;
        private System.Windows.Forms.ColumnHeader columnHeader_time;
        private System.Windows.Forms.ColumnHeader columnHeader_message;
    }
}
