namespace SampleScreen
{
    partial class AlarmHistory
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AlarmHistory));
            this.listView_history = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader7 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.button_delete = new InputControls.BitmapButton();
            this.dateTimePicker_delEnd = new System.Windows.Forms.DateTimePicker();
            this.label6 = new System.Windows.Forms.Label();
            this.dateTimePicker_delStart = new System.Windows.Forms.DateTimePicker();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.panel6 = new System.Windows.Forms.Panel();
            this.panel7 = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.dateTimePicker_start = new System.Windows.Forms.DateTimePicker();
            this.dateTimePicker_end = new System.Windows.Forms.DateTimePicker();
            this.button_search = new InputControls.BitmapButton();
            this.alarmHistoryDataSet = new SampleScreen.AlarmHistoryDataSet();
            this.bindingSource_alarmHistory = new System.Windows.Forms.BindingSource(this.components);
            this.alarmHistoryTableAdapter = new SampleScreen.AlarmHistoryDataSetTableAdapters.AlarmHistoryTableAdapter();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.alarmHistoryDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource_alarmHistory)).BeginInit();
            this.SuspendLayout();
            // 
            // listView_history
            // 
            this.listView_history.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader5,
            this.columnHeader6,
            this.columnHeader7});
            this.listView_history.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.listView_history.FullRowSelect = true;
            this.listView_history.GridLines = true;
            this.listView_history.Location = new System.Drawing.Point(3, 4);
            this.listView_history.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.listView_history.Name = "listView_history";
            this.listView_history.Size = new System.Drawing.Size(1346, 867);
            this.listView_history.Sorting = System.Windows.Forms.SortOrder.Descending;
            this.listView_history.TabIndex = 0;
            this.listView_history.UseCompatibleStateImageBehavior = false;
            this.listView_history.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "순번";
            this.columnHeader1.Width = 50;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "발생 시간";
            this.columnHeader2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader2.Width = 224;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "해지 시간";
            this.columnHeader3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader3.Width = 211;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "등급";
            this.columnHeader4.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader4.Width = 83;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "분류";
            this.columnHeader5.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader5.Width = 100;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "알람 번호";
            this.columnHeader6.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader6.Width = 116;
            // 
            // columnHeader7
            // 
            this.columnHeader7.Text = "알람 명칭";
            this.columnHeader7.Width = 461;
            // 
            // panel1
            // 
            this.panel1.AutoSize = true;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.listView_history);
            this.panel1.Location = new System.Drawing.Point(50, 5);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1358, 879);
            this.panel1.TabIndex = 355;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.ControlLight;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel2.Controls.Add(this.label7);
            this.panel2.Controls.Add(this.label8);
            this.panel2.Controls.Add(this.panel4);
            this.panel2.Controls.Add(this.button_delete);
            this.panel2.Controls.Add(this.dateTimePicker_delEnd);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.dateTimePicker_delStart);
            this.panel2.Location = new System.Drawing.Point(1448, 210);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(270, 173);
            this.panel2.TabIndex = 358;
            // 
            // label7
            // 
            this.label7.BackColor = System.Drawing.SystemColors.ControlLight;
            this.label7.Font = new System.Drawing.Font("맑은 고딕", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label7.Location = new System.Drawing.Point(4, 78);
            this.label7.Margin = new System.Windows.Forms.Padding(0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(101, 30);
            this.label7.TabIndex = 222;
            this.label7.Text = "끝 일자";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label8
            // 
            this.label8.BackColor = System.Drawing.SystemColors.ControlLight;
            this.label8.Font = new System.Drawing.Font("맑은 고딕", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label8.Location = new System.Drawing.Point(4, 44);
            this.label8.Margin = new System.Windows.Forms.Padding(0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(101, 30);
            this.label8.TabIndex = 221;
            this.label8.Text = "시작 일자";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel4.Location = new System.Drawing.Point(6, 25);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(60, 2);
            this.panel4.TabIndex = 213;
            // 
            // button_delete
            // 
            this.button_delete.BorderColor = System.Drawing.Color.DarkBlue;
            this.button_delete.FocusRectangleEnabled = true;
            this.button_delete.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.button_delete.Image = null;
            this.button_delete.ImageBorderColor = System.Drawing.Color.Chocolate;
            this.button_delete.ImageBorderEnabled = true;
            this.button_delete.ImageDropShadow = true;
            this.button_delete.ImageFocused = null;
            this.button_delete.ImageInactive = null;
            this.button_delete.ImageMouseOver = null;
            this.button_delete.ImageNormal = null;
            this.button_delete.ImagePressed = null;
            this.button_delete.InnerBorderColor = System.Drawing.Color.LightGray;
            this.button_delete.InnerBorderColor_Focus = System.Drawing.Color.LightBlue;
            this.button_delete.InnerBorderColor_MouseOver = System.Drawing.Color.Gold;
            this.button_delete.Location = new System.Drawing.Point(108, 114);
            this.button_delete.Name = "button_delete";
            this.button_delete.OffsetPressedContent = true;
            this.button_delete.Size = new System.Drawing.Size(153, 45);
            this.button_delete.StretchImage = false;
            this.button_delete.TabIndex = 37;
            this.button_delete.Text = "삭   제";
            this.button_delete.TextDropShadow = true;
            this.button_delete.UseVisualStyleBackColor = true;
            this.button_delete.Click += new System.EventHandler(this.button_delete_Click);
            // 
            // dateTimePicker_delEnd
            // 
            this.dateTimePicker_delEnd.CalendarFont = new System.Drawing.Font("굴림", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.dateTimePicker_delEnd.Font = new System.Drawing.Font("굴림", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.dateTimePicker_delEnd.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker_delEnd.Location = new System.Drawing.Point(108, 77);
            this.dateTimePicker_delEnd.Name = "dateTimePicker_delEnd";
            this.dateTimePicker_delEnd.Size = new System.Drawing.Size(154, 32);
            this.dateTimePicker_delEnd.TabIndex = 36;
            this.dateTimePicker_delEnd.MouseDown += new System.Windows.Forms.MouseEventHandler(this.dateTimePicker_delEnd_MouseDown);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("맑은 고딕", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label6.Location = new System.Drawing.Point(3, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(71, 25);
            this.label6.TabIndex = 212;
            this.label6.Text = "삭   제";
            // 
            // dateTimePicker_delStart
            // 
            this.dateTimePicker_delStart.CalendarFont = new System.Drawing.Font("굴림", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.dateTimePicker_delStart.Font = new System.Drawing.Font("굴림", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.dateTimePicker_delStart.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker_delStart.Location = new System.Drawing.Point(108, 41);
            this.dateTimePicker_delStart.Name = "dateTimePicker_delStart";
            this.dateTimePicker_delStart.Size = new System.Drawing.Size(155, 32);
            this.dateTimePicker_delStart.TabIndex = 35;
            this.dateTimePicker_delStart.MouseDown += new System.Windows.Forms.MouseEventHandler(this.dateTimePicker_delStart_MouseDown);
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.SystemColors.ControlLight;
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel3.Controls.Add(this.label3);
            this.panel3.Controls.Add(this.label4);
            this.panel3.Controls.Add(this.panel6);
            this.panel3.Controls.Add(this.panel7);
            this.panel3.Controls.Add(this.label5);
            this.panel3.Controls.Add(this.dateTimePicker_start);
            this.panel3.Controls.Add(this.dateTimePicker_end);
            this.panel3.Controls.Add(this.button_search);
            this.panel3.Location = new System.Drawing.Point(1448, 26);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(270, 178);
            this.panel3.TabIndex = 357;
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.SystemColors.ControlLight;
            this.label3.Font = new System.Drawing.Font("맑은 고딕", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label3.Location = new System.Drawing.Point(7, 75);
            this.label3.Margin = new System.Windows.Forms.Padding(0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(101, 30);
            this.label3.TabIndex = 220;
            this.label3.Text = "끝 일자";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.SystemColors.ControlLight;
            this.label4.Font = new System.Drawing.Font("맑은 고딕", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label4.Location = new System.Drawing.Point(7, 41);
            this.label4.Margin = new System.Windows.Forms.Padding(0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(101, 30);
            this.label4.TabIndex = 219;
            this.label4.Text = "시작 일자";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel6
            // 
            this.panel6.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.panel6.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel6.Location = new System.Drawing.Point(6, 25);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(63, 2);
            this.panel6.TabIndex = 213;
            // 
            // panel7
            // 
            this.panel7.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel7.Location = new System.Drawing.Point(11, 31);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(142, 2);
            this.panel7.TabIndex = 214;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("맑은 고딕", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label5.Location = new System.Drawing.Point(3, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(71, 25);
            this.label5.TabIndex = 212;
            this.label5.Text = "검   색";
            // 
            // dateTimePicker_start
            // 
            this.dateTimePicker_start.CalendarFont = new System.Drawing.Font("굴림", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.dateTimePicker_start.CustomFormat = "";
            this.dateTimePicker_start.Font = new System.Drawing.Font("굴림", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.dateTimePicker_start.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker_start.Location = new System.Drawing.Point(108, 38);
            this.dateTimePicker_start.Name = "dateTimePicker_start";
            this.dateTimePicker_start.Size = new System.Drawing.Size(155, 32);
            this.dateTimePicker_start.TabIndex = 30;
            this.dateTimePicker_start.MouseDown += new System.Windows.Forms.MouseEventHandler(this.dateTimePicker_start_MouseDown);
            // 
            // dateTimePicker_end
            // 
            this.dateTimePicker_end.CalendarFont = new System.Drawing.Font("굴림", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.dateTimePicker_end.Font = new System.Drawing.Font("굴림", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.dateTimePicker_end.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker_end.Location = new System.Drawing.Point(108, 75);
            this.dateTimePicker_end.Name = "dateTimePicker_end";
            this.dateTimePicker_end.Size = new System.Drawing.Size(154, 32);
            this.dateTimePicker_end.TabIndex = 31;
            this.dateTimePicker_end.MouseDown += new System.Windows.Forms.MouseEventHandler(this.dateTimePicker_end_MouseDown);
            // 
            // button_search
            // 
            this.button_search.BorderColor = System.Drawing.Color.DarkBlue;
            this.button_search.FocusRectangleEnabled = true;
            this.button_search.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.button_search.Image = null;
            this.button_search.ImageBorderColor = System.Drawing.Color.Chocolate;
            this.button_search.ImageBorderEnabled = true;
            this.button_search.ImageDropShadow = true;
            this.button_search.ImageFocused = null;
            this.button_search.ImageInactive = null;
            this.button_search.ImageMouseOver = null;
            this.button_search.ImageNormal = null;
            this.button_search.ImagePressed = null;
            this.button_search.InnerBorderColor = System.Drawing.Color.LightGray;
            this.button_search.InnerBorderColor_Focus = System.Drawing.Color.LightBlue;
            this.button_search.InnerBorderColor_MouseOver = System.Drawing.Color.Gold;
            this.button_search.Location = new System.Drawing.Point(108, 115);
            this.button_search.Name = "button_search";
            this.button_search.OffsetPressedContent = true;
            this.button_search.Size = new System.Drawing.Size(154, 45);
            this.button_search.StretchImage = false;
            this.button_search.TabIndex = 32;
            this.button_search.Text = "검   색";
            this.button_search.TextDropShadow = true;
            this.button_search.UseVisualStyleBackColor = true;
            this.button_search.Click += new System.EventHandler(this.button_search_Click);
            // 
            // alarmHistoryDataSet
            // 
            this.alarmHistoryDataSet.DataSetName = "AlarmHistoryDataSet";
            this.alarmHistoryDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // bindingSource_alarmHistory
            // 
            this.bindingSource_alarmHistory.DataMember = "AlarmHistory";
            this.bindingSource_alarmHistory.DataSource = this.alarmHistoryDataSet;
            // 
            // alarmHistoryTableAdapter
            // 
            this.alarmHistoryTableAdapter.ClearBeforeFill = true;
            // 
            // AlarmHistory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(1840, 915);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel1);
            this.Name = "AlarmHistory";
            this.Resolution = IronPanel._Resolution.HD1080;
            this.Text = "AlarmHistory";
            this.Load += new System.EventHandler(this.AlarmHistory_Load);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.alarmHistoryDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource_alarmHistory)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView listView_history;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.ColumnHeader columnHeader7;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Panel panel4;
        private InputControls.BitmapButton button_delete;
        private System.Windows.Forms.DateTimePicker dateTimePicker_delEnd;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DateTimePicker dateTimePicker_delStart;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DateTimePicker dateTimePicker_start;
        private System.Windows.Forms.DateTimePicker dateTimePicker_end;
        private InputControls.BitmapButton button_search;
        private AlarmHistoryDataSet alarmHistoryDataSet;
        private System.Windows.Forms.BindingSource bindingSource_alarmHistory;
        private AlarmHistoryDataSetTableAdapters.AlarmHistoryTableAdapter alarmHistoryTableAdapter;
    }
}