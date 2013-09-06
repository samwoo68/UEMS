namespace BasicPanel
{
	partial class AlarmForm
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

		#region Windows Form 디자이너에서 생성한 코드

		/// <summary>
		/// 디자이너 지원에 필요한 메서드입니다.
		/// 이 메서드의 내용을 코드 편집기로 수정하지 마십시오.
		/// </summary>
		private void InitializeComponent()
		{
            this.listView_alarm = new System.Windows.Forms.ListView();
            this.columnHeader_id = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader_time = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader_message = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.richTextBox_description = new System.Windows.Forms.RichTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.button_retry = new System.Windows.Forms.Button();
            this.button_abort = new System.Windows.Forms.Button();
            this.button_close = new System.Windows.Forms.Button();
            this.button_confirm = new System.Windows.Forms.Button();
            this.button_resume = new System.Windows.Forms.Button();
            this.SuspendLayout();
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
            this.listView_alarm.Location = new System.Drawing.Point(12, 12);
            this.listView_alarm.MultiSelect = false;
            this.listView_alarm.Name = "listView_alarm";
            this.listView_alarm.Size = new System.Drawing.Size(668, 455);
            this.listView_alarm.TabIndex = 0;
            this.listView_alarm.UseCompatibleStateImageBehavior = false;
            this.listView_alarm.View = System.Windows.Forms.View.Details;
            this.listView_alarm.SelectedIndexChanged += new System.EventHandler(this.listView_alarm_SelectedIndexChanged);
            // 
            // columnHeader_id
            // 
            this.columnHeader_id.Text = "번호";
            this.columnHeader_id.Width = 50;
            // 
            // columnHeader_time
            // 
            this.columnHeader_time.Text = "발생시간";
            this.columnHeader_time.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader_time.Width = 108;
            // 
            // columnHeader_message
            // 
            this.columnHeader_message.Text = "알  람  명  칭";
            this.columnHeader_message.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader_message.Width = 495;
            // 
            // richTextBox_description
            // 
            this.richTextBox_description.Location = new System.Drawing.Point(9, 494);
            this.richTextBox_description.Name = "richTextBox_description";
            this.richTextBox_description.ReadOnly = true;
            this.richTextBox_description.Size = new System.Drawing.Size(671, 151);
            this.richTextBox_description.TabIndex = 1;
            this.richTextBox_description.Text = "";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.SystemColors.Control;
            this.label1.Font = new System.Drawing.Font("굴림", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label1.Location = new System.Drawing.Point(12, 470);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(139, 19);
            this.label1.TabIndex = 5;
            this.label1.Text = "Troubleshooting";
            // 
            // button_retry
            // 
            this.button_retry.Location = new System.Drawing.Point(299, 660);
            this.button_retry.Name = "button_retry";
            this.button_retry.Size = new System.Drawing.Size(90, 40);
            this.button_retry.TabIndex = 11;
            this.button_retry.Text = "Retry";
            this.button_retry.UseVisualStyleBackColor = true;
            this.button_retry.Click += new System.EventHandler(this.button_retry_Click);
            // 
            // button_abort
            // 
            this.button_abort.Location = new System.Drawing.Point(491, 660);
            this.button_abort.Name = "button_abort";
            this.button_abort.Size = new System.Drawing.Size(90, 40);
            this.button_abort.TabIndex = 12;
            this.button_abort.Text = "Abort";
            this.button_abort.UseVisualStyleBackColor = true;
            this.button_abort.Visible = false;
            this.button_abort.Click += new System.EventHandler(this.button_abort_Click);
            // 
            // button_close
            // 
            this.button_close.Location = new System.Drawing.Point(587, 660);
            this.button_close.Name = "button_close";
            this.button_close.Size = new System.Drawing.Size(90, 40);
            this.button_close.TabIndex = 13;
            this.button_close.Text = "Close";
            this.button_close.UseVisualStyleBackColor = true;
            this.button_close.Click += new System.EventHandler(this.button_close_Click);
            // 
            // button_confirm
            // 
            this.button_confirm.Location = new System.Drawing.Point(491, 660);
            this.button_confirm.Name = "button_confirm";
            this.button_confirm.Size = new System.Drawing.Size(90, 40);
            this.button_confirm.TabIndex = 14;
            this.button_confirm.Text = "Confirm";
            this.button_confirm.UseVisualStyleBackColor = true;
            this.button_confirm.Visible = false;
            this.button_confirm.Click += new System.EventHandler(this.button_confirm_Click);
            // 
            // button_resume
            // 
            this.button_resume.Location = new System.Drawing.Point(395, 660);
            this.button_resume.Name = "button_resume";
            this.button_resume.Size = new System.Drawing.Size(90, 40);
            this.button_resume.TabIndex = 15;
            this.button_resume.Text = "Resume";
            this.button_resume.UseVisualStyleBackColor = true;
            this.button_resume.Click += new System.EventHandler(this.button_resume_Click);
            // 
            // AlarmForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(737, 711);
            this.Controls.Add(this.button_confirm);
            this.Controls.Add(this.button_close);
            this.Controls.Add(this.button_abort);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.richTextBox_description);
            this.Controls.Add(this.listView_alarm);
            this.Controls.Add(this.button_resume);
            this.Controls.Add(this.button_retry);
            this.Name = "AlarmForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.ClearAlarm += new IronPanel.AlarmEventHandler(this.AlarmForm_ClearAlarm);
            this.RaiseAlarm += new IronPanel.AlarmEventHandler(this.AlarmForm_RaiseAlarm);
            this.Activated += new System.EventHandler(this.AlarmForm_Activated);
            this.Load += new System.EventHandler(this.AlarmForm_Load);
            this.Leave += new System.EventHandler(this.AlarmForm_Leave);
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.ListView listView_alarm;
        private System.Windows.Forms.RichTextBox richTextBox_description;
		private System.Windows.Forms.ColumnHeader columnHeader_id;
		private System.Windows.Forms.ColumnHeader columnHeader_time;
		private System.Windows.Forms.ColumnHeader columnHeader_message;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button_retry;
        private System.Windows.Forms.Button button_abort;
        private System.Windows.Forms.Button button_close;
        private System.Windows.Forms.Button button_confirm;
        private System.Windows.Forms.Button button_resume;
	}
}