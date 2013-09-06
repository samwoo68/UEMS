namespace SampleScreen
{
    partial class TrendScreen
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TrendScreen));
            this.selGraphViewC1 = new SelGraphView.SelGraphViewC();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.gB_Row_SumUnit = new System.Windows.Forms.GroupBox();
            this.rB_row_unit_day = new System.Windows.Forms.RadioButton();
            this.rB_row_unit_min = new System.Windows.Forms.RadioButton();
            this.rB_row_unit_hour = new System.Windows.Forms.RadioButton();
            this.rb_row_unit_month = new System.Windows.Forms.RadioButton();
            this.gB_Period_Unit = new System.Windows.Forms.GroupBox();
            this.rB_period = new System.Windows.Forms.RadioButton();
            this.rB_month = new System.Windows.Forms.RadioButton();
            this.rB_day = new System.Windows.Forms.RadioButton();
            this.rB_year = new System.Windows.Forms.RadioButton();
            this.imageLabelBox2 = new ImageLabelBox.ImageLabelBox();
            this.imageLabelBox1 = new ImageLabelBox.ImageLabelBox();
            this.dTP_search_end = new System.Windows.Forms.DateTimePicker();
            this.dTP_search_start = new System.Windows.Forms.DateTimePicker();
            this.bt_Load = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.gB_Row_SumUnit.SuspendLayout();
            this.gB_Period_Unit.SuspendLayout();
            this.SuspendLayout();
            // 
            // selGraphViewC1
            // 
            this.selGraphViewC1.AccessMode = IronControls.AccessModes.DirectMode;
            this.selGraphViewC1.CommComponent = null;
            this.selGraphViewC1.FirstTag = "";
            this.selGraphViewC1.Location = new System.Drawing.Point(583, 95);
            this.selGraphViewC1.Mode = IronControls._Mode.VALUE_DISPLAY;
            this.selGraphViewC1.Name = "selGraphViewC1";
            this.selGraphViewC1.SecondTag = "";
            this.selGraphViewC1.Size = new System.Drawing.Size(1184, 768);
            this.selGraphViewC1.TabIndex = 143;
            this.selGraphViewC1.Tags = ((System.Collections.Generic.List<string>)(resources.GetObject("selGraphViewC1.Tags")));
            this.selGraphViewC1.UpdateMode = CommLib.UpdateMode.OnChange;
            this.selGraphViewC1.UpdateTime = 500;
            this.selGraphViewC1.Visible = false;
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Controls.Add(this.gB_Row_SumUnit);
            this.groupBox1.Controls.Add(this.gB_Period_Unit);
            this.groupBox1.Controls.Add(this.imageLabelBox2);
            this.groupBox1.Controls.Add(this.imageLabelBox1);
            this.groupBox1.Controls.Add(this.dTP_search_end);
            this.groupBox1.Controls.Add(this.dTP_search_start);
            this.groupBox1.Controls.Add(this.bt_Load);
            this.groupBox1.Font = new System.Drawing.Font("굴림", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.groupBox1.ForeColor = System.Drawing.Color.Blue;
            this.groupBox1.Location = new System.Drawing.Point(73, 52);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(450, 276);
            this.groupBox1.TabIndex = 142;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "데이타 검색";
            // 
            // gB_Row_SumUnit
            // 
            this.gB_Row_SumUnit.Controls.Add(this.rB_row_unit_day);
            this.gB_Row_SumUnit.Controls.Add(this.rB_row_unit_min);
            this.gB_Row_SumUnit.Controls.Add(this.rB_row_unit_hour);
            this.gB_Row_SumUnit.Controls.Add(this.rb_row_unit_month);
            this.gB_Row_SumUnit.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.gB_Row_SumUnit.Location = new System.Drawing.Point(322, 26);
            this.gB_Row_SumUnit.Name = "gB_Row_SumUnit";
            this.gB_Row_SumUnit.Size = new System.Drawing.Size(111, 116);
            this.gB_Row_SumUnit.TabIndex = 106;
            this.gB_Row_SumUnit.TabStop = false;
            this.gB_Row_SumUnit.Text = "데이타단위";
            // 
            // rB_row_unit_day
            // 
            this.rB_row_unit_day.AutoSize = true;
            this.rB_row_unit_day.ForeColor = System.Drawing.Color.White;
            this.rB_row_unit_day.Location = new System.Drawing.Point(17, 68);
            this.rB_row_unit_day.Name = "rB_row_unit_day";
            this.rB_row_unit_day.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.rB_row_unit_day.Size = new System.Drawing.Size(73, 19);
            this.rB_row_unit_day.TabIndex = 102;
            this.rB_row_unit_day.TabStop = true;
            this.rB_row_unit_day.Text = "일단위";
            this.rB_row_unit_day.UseVisualStyleBackColor = true;
            // 
            // rB_row_unit_min
            // 
            this.rB_row_unit_min.AutoSize = true;
            this.rB_row_unit_min.ForeColor = System.Drawing.Color.White;
            this.rB_row_unit_min.Location = new System.Drawing.Point(17, 20);
            this.rB_row_unit_min.Name = "rB_row_unit_min";
            this.rB_row_unit_min.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.rB_row_unit_min.Size = new System.Drawing.Size(73, 19);
            this.rB_row_unit_min.TabIndex = 101;
            this.rB_row_unit_min.TabStop = true;
            this.rB_row_unit_min.Text = "분단위";
            this.rB_row_unit_min.UseVisualStyleBackColor = true;
            // 
            // rB_row_unit_hour
            // 
            this.rB_row_unit_hour.AutoSize = true;
            this.rB_row_unit_hour.ForeColor = System.Drawing.Color.White;
            this.rB_row_unit_hour.Location = new System.Drawing.Point(17, 42);
            this.rB_row_unit_hour.Name = "rB_row_unit_hour";
            this.rB_row_unit_hour.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.rB_row_unit_hour.Size = new System.Drawing.Size(73, 19);
            this.rB_row_unit_hour.TabIndex = 104;
            this.rB_row_unit_hour.TabStop = true;
            this.rB_row_unit_hour.Text = "시단위";
            this.rB_row_unit_hour.UseVisualStyleBackColor = true;
            // 
            // rb_row_unit_month
            // 
            this.rb_row_unit_month.AutoSize = true;
            this.rb_row_unit_month.ForeColor = System.Drawing.Color.White;
            this.rb_row_unit_month.Location = new System.Drawing.Point(17, 93);
            this.rb_row_unit_month.Name = "rb_row_unit_month";
            this.rb_row_unit_month.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.rb_row_unit_month.Size = new System.Drawing.Size(73, 19);
            this.rb_row_unit_month.TabIndex = 103;
            this.rb_row_unit_month.TabStop = true;
            this.rb_row_unit_month.Text = "월단위";
            this.rb_row_unit_month.UseVisualStyleBackColor = true;
            // 
            // gB_Period_Unit
            // 
            this.gB_Period_Unit.Controls.Add(this.rB_period);
            this.gB_Period_Unit.Controls.Add(this.rB_month);
            this.gB_Period_Unit.Controls.Add(this.rB_day);
            this.gB_Period_Unit.Controls.Add(this.rB_year);
            this.gB_Period_Unit.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.gB_Period_Unit.Location = new System.Drawing.Point(143, 24);
            this.gB_Period_Unit.Name = "gB_Period_Unit";
            this.gB_Period_Unit.Size = new System.Drawing.Size(155, 114);
            this.gB_Period_Unit.TabIndex = 105;
            this.gB_Period_Unit.TabStop = false;
            this.gB_Period_Unit.Text = "검색범위";
            // 
            // rB_period
            // 
            this.rB_period.AutoSize = true;
            this.rB_period.ForeColor = System.Drawing.Color.White;
            this.rB_period.Location = new System.Drawing.Point(6, 89);
            this.rB_period.Name = "rB_period";
            this.rB_period.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.rB_period.Size = new System.Drawing.Size(121, 19);
            this.rB_period.TabIndex = 101;
            this.rB_period.TabStop = true;
            this.rB_period.Text = "기간운전현황";
            this.rB_period.UseVisualStyleBackColor = true;
            // 
            // rB_month
            // 
            this.rB_month.AutoSize = true;
            this.rB_month.ForeColor = System.Drawing.Color.White;
            this.rB_month.Location = new System.Drawing.Point(6, 43);
            this.rB_month.Name = "rB_month";
            this.rB_month.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.rB_month.Size = new System.Drawing.Size(121, 19);
            this.rB_month.TabIndex = 99;
            this.rB_month.TabStop = true;
            this.rB_month.Text = "월간운전현황";
            this.rB_month.UseVisualStyleBackColor = true;
            // 
            // rB_day
            // 
            this.rB_day.AutoSize = true;
            this.rB_day.ForeColor = System.Drawing.Color.White;
            this.rB_day.Location = new System.Drawing.Point(6, 19);
            this.rB_day.Name = "rB_day";
            this.rB_day.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.rB_day.Size = new System.Drawing.Size(121, 19);
            this.rB_day.TabIndex = 98;
            this.rB_day.TabStop = true;
            this.rB_day.Text = "일간운전현황";
            this.rB_day.UseVisualStyleBackColor = true;
            // 
            // rB_year
            // 
            this.rB_year.AutoSize = true;
            this.rB_year.ForeColor = System.Drawing.Color.White;
            this.rB_year.Location = new System.Drawing.Point(6, 66);
            this.rB_year.Name = "rB_year";
            this.rB_year.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.rB_year.Size = new System.Drawing.Size(121, 19);
            this.rB_year.TabIndex = 100;
            this.rB_year.TabStop = true;
            this.rB_year.Text = "연간운전현황";
            this.rB_year.UseVisualStyleBackColor = true;
            // 
            // imageLabelBox2
            // 
            this.imageLabelBox2.BackColor = System.Drawing.Color.Transparent;
            this.imageLabelBox2.BackgroundImage = global::SampleScreen.Properties.Resources.투명이미지_버튼용_glossy_long_website_buttons;
            this.imageLabelBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.imageLabelBox2.Label_Color = System.Drawing.Color.Maroon;
            this.imageLabelBox2.Label_Font = new System.Drawing.Font("굴림", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.imageLabelBox2.Label_Location = new System.Drawing.Point(6999, 1376);
            this.imageLabelBox2.Label_Text = "종료";
            this.imageLabelBox2.Location = new System.Drawing.Point(25, 198);
            this.imageLabelBox2.Margin = new System.Windows.Forms.Padding(5);
            this.imageLabelBox2.Name = "imageLabelBox2";
            this.imageLabelBox2.Size = new System.Drawing.Size(72, 26);
            this.imageLabelBox2.TabIndex = 97;
            // 
            // imageLabelBox1
            // 
            this.imageLabelBox1.BackColor = System.Drawing.Color.Transparent;
            this.imageLabelBox1.BackgroundImage = global::SampleScreen.Properties.Resources.투명이미지_버튼용_glossy_long_website_buttons;
            this.imageLabelBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.imageLabelBox1.Label_Color = System.Drawing.Color.Maroon;
            this.imageLabelBox1.Label_Font = new System.Drawing.Font("굴림", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.imageLabelBox1.Label_Location = new System.Drawing.Point(6999, 1376);
            this.imageLabelBox1.Label_Text = "시작";
            this.imageLabelBox1.Location = new System.Drawing.Point(25, 165);
            this.imageLabelBox1.Margin = new System.Windows.Forms.Padding(4);
            this.imageLabelBox1.Name = "imageLabelBox1";
            this.imageLabelBox1.Size = new System.Drawing.Size(72, 25);
            this.imageLabelBox1.TabIndex = 96;
            // 
            // dTP_search_end
            // 
            this.dTP_search_end.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dTP_search_end.Location = new System.Drawing.Point(104, 198);
            this.dTP_search_end.Name = "dTP_search_end";
            this.dTP_search_end.Size = new System.Drawing.Size(113, 25);
            this.dTP_search_end.TabIndex = 95;
            // 
            // dTP_search_start
            // 
            this.dTP_search_start.CustomFormat = "\"yyyy-MM\"";
            this.dTP_search_start.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dTP_search_start.Location = new System.Drawing.Point(104, 166);
            this.dTP_search_start.Name = "dTP_search_start";
            this.dTP_search_start.Size = new System.Drawing.Size(113, 25);
            this.dTP_search_start.TabIndex = 13;
            // 
            // bt_Load
            // 
            this.bt_Load.Location = new System.Drawing.Point(15, 26);
            this.bt_Load.Name = "bt_Load";
            this.bt_Load.Size = new System.Drawing.Size(116, 43);
            this.bt_Load.TabIndex = 2;
            this.bt_Load.Text = "&데이타검색";
            this.bt_Load.UseVisualStyleBackColor = true;
            this.bt_Load.Click += new System.EventHandler(this.bt_Load_Click);
            // 
            // TrendScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(1840, 915);
            this.Controls.Add(this.selGraphViewC1);
            this.Controls.Add(this.groupBox1);
            this.Name = "TrendScreen";
            this.Resolution = IronPanel._Resolution.HD1080;
            this.Text = "Form1";
            this.groupBox1.ResumeLayout(false);
            this.gB_Row_SumUnit.ResumeLayout(false);
            this.gB_Row_SumUnit.PerformLayout();
            this.gB_Period_Unit.ResumeLayout(false);
            this.gB_Period_Unit.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private SelGraphView.SelGraphViewC selGraphViewC1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox gB_Row_SumUnit;
        private System.Windows.Forms.RadioButton rB_row_unit_day;
        private System.Windows.Forms.RadioButton rB_row_unit_min;
        private System.Windows.Forms.RadioButton rB_row_unit_hour;
        private System.Windows.Forms.RadioButton rb_row_unit_month;
        private System.Windows.Forms.GroupBox gB_Period_Unit;
        private System.Windows.Forms.RadioButton rB_period;
        private System.Windows.Forms.RadioButton rB_month;
        private System.Windows.Forms.RadioButton rB_day;
        private System.Windows.Forms.RadioButton rB_year;
        private ImageLabelBox.ImageLabelBox imageLabelBox2;
        private ImageLabelBox.ImageLabelBox imageLabelBox1;
        private System.Windows.Forms.DateTimePicker dTP_search_end;
        private System.Windows.Forms.DateTimePicker dTP_search_start;
        private System.Windows.Forms.Button bt_Load;

    }
}