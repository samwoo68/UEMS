namespace UEMScreen
{
    partial class ConfigScreen
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ConfigScreen));
            this.ironSANClient1 = new IronSANAdapter.IronSANClient();
            this.bt_save = new System.Windows.Forms.Button();
            this.sb_Path_Log = new IronControls.StringBox();
            this.textBox21 = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.textBox6 = new System.Windows.Forms.TextBox();
            this.sb_ReferenceTime_Workday = new IronControls.StringBox();
            this.bt_readXML = new System.Windows.Forms.Button();
            this.textBox7 = new System.Windows.Forms.TextBox();
            this.textBox9 = new System.Windows.Forms.TextBox();
            this.textBox10 = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.stringBox4 = new IronControls.StringBox();
            this.textBox22 = new System.Windows.Forms.TextBox();
            this.stringBox3 = new IronControls.StringBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.analogBox4 = new IronControls.AnalogBox();
            this.analogBox3 = new IronControls.AnalogBox();
            this.analogBox2 = new IronControls.AnalogBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.analogBox5 = new IronControls.AnalogBox();
            this.analogBox6 = new IronControls.AnalogBox();
            this.analogBox7 = new IronControls.AnalogBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.analogBox16 = new IronControls.AnalogBox();
            this.analogBox15 = new IronControls.AnalogBox();
            this.analogBox14 = new IronControls.AnalogBox();
            this.analogBox13 = new IronControls.AnalogBox();
            this.analogBox12 = new IronControls.AnalogBox();
            this.analogBox11 = new IronControls.AnalogBox();
            this.textBox8 = new System.Windows.Forms.TextBox();
            this.textBox11 = new System.Windows.Forms.TextBox();
            this.textBox17 = new System.Windows.Forms.TextBox();
            this.textBox19 = new System.Windows.Forms.TextBox();
            this.textBox18 = new System.Windows.Forms.TextBox();
            this.textBox20 = new System.Windows.Forms.TextBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.analogBox10 = new IronControls.AnalogBox();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.analogBox9 = new IronControls.AnalogBox();
            this.analogBox8 = new IronControls.AnalogBox();
            this.textBox16 = new System.Windows.Forms.TextBox();
            this.textBox15 = new System.Windows.Forms.TextBox();
            this.timer_work_data = new System.Windows.Forms.Timer(this.components);
            this.opcClient2 = new OPCAdapter.OPCClient();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.analogBox17 = new IronControls.AnalogBox();
            this.stringBox1 = new IronControls.StringBox();
            this.textBox13 = new System.Windows.Forms.TextBox();
            this.textBox14 = new System.Windows.Forms.TextBox();
            this.bt_PLC_EXEC = new System.Windows.Forms.Button();
            this.groupBox8 = new System.Windows.Forms.GroupBox();
            this.analogBox1 = new IronControls.AnalogBox();
            this.analogBox18 = new IronControls.AnalogBox();
            this.textBox23 = new System.Windows.Forms.TextBox();
            this.textBox24 = new System.Windows.Forms.TextBox();
            this.groupBox9 = new System.Windows.Forms.GroupBox();
            this.analogBox19 = new IronControls.AnalogBox();
            this.analogBox20 = new IronControls.AnalogBox();
            this.textBox12 = new System.Windows.Forms.TextBox();
            this.textBox25 = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.groupBox7.SuspendLayout();
            this.groupBox8.SuspendLayout();
            this.groupBox9.SuspendLayout();
            this.SuspendLayout();
            // 
            // ironSANClient1
            // 
            this.ironSANClient1.ProjectPath = "";
            this.ironSANClient1.ScriptEnable = false;
            this.ironSANClient1.SynchronizingObject = this;
            // 
            // bt_save
            // 
            this.bt_save.BackgroundImage = global::UEMScreen.Properties.Resources._파랑_대;
            this.bt_save.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.bt_save.Font = new System.Drawing.Font("굴림", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.bt_save.ForeColor = System.Drawing.Color.Yellow;
            this.bt_save.Location = new System.Drawing.Point(1596, 98);
            this.bt_save.Name = "bt_save";
            this.bt_save.Size = new System.Drawing.Size(154, 48);
            this.bt_save.TabIndex = 19;
            this.bt_save.Text = "설정저장";
            this.bt_save.UseVisualStyleBackColor = true;
            this.bt_save.Click += new System.EventHandler(this.bt_save_Click);
            // 
            // sb_Path_Log
            // 
            this.sb_Path_Log.AccessMode = IronControls.AccessModes.DirectMode;
            this.sb_Path_Log.BoxName = "";
            this.sb_Path_Log.CommComponent = this.ironSANClient1;
            this.sb_Path_Log.Data = "";
            this.sb_Path_Log.Description = "String IO";
            this.sb_Path_Log.EnableWrite = true;
            this.sb_Path_Log.FirstTag = "SO.EEMS-R1.Path_Log";
            this.sb_Path_Log.Font = new System.Drawing.Font("굴림체", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.sb_Path_Log.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.sb_Path_Log.Location = new System.Drawing.Point(252, 46);
            this.sb_Path_Log.Mode = IronControls._Mode.VALUE_DISPLAY;
            this.sb_Path_Log.Name = "sb_Path_Log";
            this.sb_Path_Log.SecondTag = "";
            this.sb_Path_Log.Size = new System.Drawing.Size(233, 26);
            this.sb_Path_Log.TabIndex = 21;
            this.sb_Path_Log.Tags = ((System.Collections.Generic.List<string>)(resources.GetObject("sb_Path_Log.Tags")));
            this.sb_Path_Log.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.sb_Path_Log.TimeMode = false;
            this.sb_Path_Log.Type = IronControls.IOType.OUTPUT;
            this.sb_Path_Log.UpdateMode = CommLib.UpdateMode.OnChange;
            this.sb_Path_Log.UpdateTime = 500;
            // 
            // textBox21
            // 
            this.textBox21.BackColor = System.Drawing.Color.Yellow;
            this.textBox21.Font = new System.Drawing.Font("굴림체", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.textBox21.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.textBox21.Location = new System.Drawing.Point(21, 46);
            this.textBox21.Multiline = true;
            this.textBox21.Name = "textBox21";
            this.textBox21.Size = new System.Drawing.Size(215, 31);
            this.textBox21.TabIndex = 94;
            this.textBox21.Text = "데이타 로깅 경로";
            this.textBox21.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.Color.Yellow;
            this.textBox1.Font = new System.Drawing.Font("굴림체", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.textBox1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.textBox1.Location = new System.Drawing.Point(23, 50);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(215, 30);
            this.textBox1.TabIndex = 96;
            this.textBox1.Text = "적산전력계 최대값";
            this.textBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox2
            // 
            this.textBox2.BackColor = System.Drawing.Color.Yellow;
            this.textBox2.Font = new System.Drawing.Font("굴림체", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.textBox2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.textBox2.Location = new System.Drawing.Point(23, 46);
            this.textBox2.Multiline = true;
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(207, 31);
            this.textBox2.TabIndex = 97;
            this.textBox2.Text = "가스 계량기 최대값";
            this.textBox2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox3
            // 
            this.textBox3.BackColor = System.Drawing.Color.Yellow;
            this.textBox3.Font = new System.Drawing.Font("굴림체", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.textBox3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.textBox3.Location = new System.Drawing.Point(23, 89);
            this.textBox3.Multiline = true;
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(207, 30);
            this.textBox3.TabIndex = 98;
            this.textBox3.Text = "펄스/m3";
            this.textBox3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox4
            // 
            this.textBox4.BackColor = System.Drawing.Color.Yellow;
            this.textBox4.Font = new System.Drawing.Font("굴림체", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.textBox4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.textBox4.Location = new System.Drawing.Point(23, 139);
            this.textBox4.Multiline = true;
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(215, 29);
            this.textBox4.TabIndex = 99;
            this.textBox4.Text = "KRW/Kwh";
            this.textBox4.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox5
            // 
            this.textBox5.BackColor = System.Drawing.Color.Yellow;
            this.textBox5.Font = new System.Drawing.Font("굴림체", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.textBox5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.textBox5.Location = new System.Drawing.Point(23, 93);
            this.textBox5.Multiline = true;
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new System.Drawing.Size(215, 33);
            this.textBox5.TabIndex = 100;
            this.textBox5.Text = "PLC적산값/적산전력값";
            this.textBox5.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox6
            // 
            this.textBox6.BackColor = System.Drawing.Color.Yellow;
            this.textBox6.Font = new System.Drawing.Font("굴림체", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.textBox6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.textBox6.Location = new System.Drawing.Point(21, 89);
            this.textBox6.Multiline = true;
            this.textBox6.Name = "textBox6";
            this.textBox6.Size = new System.Drawing.Size(215, 30);
            this.textBox6.TabIndex = 101;
            this.textBox6.Text = "데이타 저장 기간";
            this.textBox6.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // sb_ReferenceTime_Workday
            // 
            this.sb_ReferenceTime_Workday.AccessMode = IronControls.AccessModes.DirectMode;
            this.sb_ReferenceTime_Workday.BoxName = "";
            this.sb_ReferenceTime_Workday.CommComponent = this.ironSANClient1;
            this.sb_ReferenceTime_Workday.Data = "";
            this.sb_ReferenceTime_Workday.Description = "String IO";
            this.sb_ReferenceTime_Workday.EnableWrite = true;
            this.sb_ReferenceTime_Workday.FirstTag = "SO.EEMS-R1.ReferenceTime_Workday";
            this.sb_ReferenceTime_Workday.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.sb_ReferenceTime_Workday.Location = new System.Drawing.Point(252, 89);
            this.sb_ReferenceTime_Workday.Mode = IronControls._Mode.VALUE_DISPLAY;
            this.sb_ReferenceTime_Workday.Name = "sb_ReferenceTime_Workday";
            this.sb_ReferenceTime_Workday.SecondTag = "";
            this.sb_ReferenceTime_Workday.Size = new System.Drawing.Size(233, 30);
            this.sb_ReferenceTime_Workday.TabIndex = 102;
            this.sb_ReferenceTime_Workday.Tags = ((System.Collections.Generic.List<string>)(resources.GetObject("sb_ReferenceTime_Workday.Tags")));
            this.sb_ReferenceTime_Workday.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.sb_ReferenceTime_Workday.TimeMode = false;
            this.sb_ReferenceTime_Workday.Type = IronControls.IOType.OUTPUT;
            this.sb_ReferenceTime_Workday.UpdateMode = CommLib.UpdateMode.OnChange;
            this.sb_ReferenceTime_Workday.UpdateTime = 500;
            // 
            // bt_readXML
            // 
            this.bt_readXML.BackgroundImage = global::UEMScreen.Properties.Resources._녹색_대;
            this.bt_readXML.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.bt_readXML.Font = new System.Drawing.Font("굴림", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.bt_readXML.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.bt_readXML.Location = new System.Drawing.Point(1445, 98);
            this.bt_readXML.Name = "bt_readXML";
            this.bt_readXML.Size = new System.Drawing.Size(154, 48);
            this.bt_readXML.TabIndex = 103;
            this.bt_readXML.Text = "설정읽기";
            this.bt_readXML.UseVisualStyleBackColor = true;
            this.bt_readXML.Click += new System.EventHandler(this.bt_readXML_Click);
            // 
            // textBox7
            // 
            this.textBox7.BackColor = System.Drawing.Color.Yellow;
            this.textBox7.Font = new System.Drawing.Font("굴림체", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.textBox7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.textBox7.Location = new System.Drawing.Point(23, 134);
            this.textBox7.Multiline = true;
            this.textBox7.Name = "textBox7";
            this.textBox7.Size = new System.Drawing.Size(207, 28);
            this.textBox7.TabIndex = 107;
            this.textBox7.Text = "KRW/m3";
            this.textBox7.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox9
            // 
            this.textBox9.BackColor = System.Drawing.Color.Yellow;
            this.textBox9.Font = new System.Drawing.Font("굴림체", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.textBox9.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.textBox9.Location = new System.Drawing.Point(21, 42);
            this.textBox9.Multiline = true;
            this.textBox9.Name = "textBox9";
            this.textBox9.Size = new System.Drawing.Size(221, 30);
            this.textBox9.TabIndex = 113;
            this.textBox9.Text = "Ingot Station 수";
            this.textBox9.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox10
            // 
            this.textBox10.BackColor = System.Drawing.Color.Yellow;
            this.textBox10.Font = new System.Drawing.Font("굴림체", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.textBox10.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.textBox10.Location = new System.Drawing.Point(21, 134);
            this.textBox10.Multiline = true;
            this.textBox10.Name = "textBox10";
            this.textBox10.Size = new System.Drawing.Size(215, 28);
            this.textBox10.TabIndex = 114;
            this.textBox10.Text = "FTP-ID";
            this.textBox10.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Controls.Add(this.stringBox4);
            this.groupBox1.Controls.Add(this.textBox22);
            this.groupBox1.Controls.Add(this.stringBox3);
            this.groupBox1.Controls.Add(this.sb_ReferenceTime_Workday);
            this.groupBox1.Controls.Add(this.sb_Path_Log);
            this.groupBox1.Controls.Add(this.textBox21);
            this.groupBox1.Controls.Add(this.textBox6);
            this.groupBox1.Controls.Add(this.textBox10);
            this.groupBox1.Font = new System.Drawing.Font("굴림체", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.groupBox1.ForeColor = System.Drawing.Color.Yellow;
            this.groupBox1.Location = new System.Drawing.Point(81, 169);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(504, 230);
            this.groupBox1.TabIndex = 120;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "데이타관리 설정";
            // 
            // stringBox4
            // 
            this.stringBox4.AccessMode = IronControls.AccessModes.DirectMode;
            this.stringBox4.BoxName = "";
            this.stringBox4.CommComponent = this.ironSANClient1;
            this.stringBox4.Data = "";
            this.stringBox4.Description = "String IO";
            this.stringBox4.EnableWrite = true;
            this.stringBox4.FirstTag = "SO.EEMS-R1.Path_Log";
            this.stringBox4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.stringBox4.Location = new System.Drawing.Point(252, 176);
            this.stringBox4.Mode = IronControls._Mode.VALUE_DISPLAY;
            this.stringBox4.Name = "stringBox4";
            this.stringBox4.SecondTag = "";
            this.stringBox4.Size = new System.Drawing.Size(233, 29);
            this.stringBox4.TabIndex = 117;
            this.stringBox4.Tags = ((System.Collections.Generic.List<string>)(resources.GetObject("stringBox4.Tags")));
            this.stringBox4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.stringBox4.TimeMode = false;
            this.stringBox4.Type = IronControls.IOType.OUTPUT;
            this.stringBox4.UpdateMode = CommLib.UpdateMode.OnChange;
            this.stringBox4.UpdateTime = 500;
            // 
            // textBox22
            // 
            this.textBox22.BackColor = System.Drawing.Color.Yellow;
            this.textBox22.Font = new System.Drawing.Font("굴림체", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.textBox22.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.textBox22.Location = new System.Drawing.Point(21, 176);
            this.textBox22.Multiline = true;
            this.textBox22.Name = "textBox22";
            this.textBox22.Size = new System.Drawing.Size(215, 29);
            this.textBox22.TabIndex = 116;
            this.textBox22.Text = "FTP-PASS";
            this.textBox22.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // stringBox3
            // 
            this.stringBox3.AccessMode = IronControls.AccessModes.DirectMode;
            this.stringBox3.BoxName = "";
            this.stringBox3.CommComponent = this.ironSANClient1;
            this.stringBox3.Data = "";
            this.stringBox3.Description = "String IO";
            this.stringBox3.EnableWrite = true;
            this.stringBox3.FirstTag = "SO.EEMS-R1.Path_Log";
            this.stringBox3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.stringBox3.Location = new System.Drawing.Point(252, 134);
            this.stringBox3.Mode = IronControls._Mode.VALUE_DISPLAY;
            this.stringBox3.Name = "stringBox3";
            this.stringBox3.SecondTag = "";
            this.stringBox3.Size = new System.Drawing.Size(233, 28);
            this.stringBox3.TabIndex = 115;
            this.stringBox3.Tags = ((System.Collections.Generic.List<string>)(resources.GetObject("stringBox3.Tags")));
            this.stringBox3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.stringBox3.TimeMode = false;
            this.stringBox3.Type = IronControls.IOType.OUTPUT;
            this.stringBox3.UpdateMode = CommLib.UpdateMode.OnChange;
            this.stringBox3.UpdateTime = 500;
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.Transparent;
            this.groupBox2.Controls.Add(this.analogBox4);
            this.groupBox2.Controls.Add(this.analogBox3);
            this.groupBox2.Controls.Add(this.analogBox2);
            this.groupBox2.Controls.Add(this.textBox2);
            this.groupBox2.Controls.Add(this.textBox3);
            this.groupBox2.Controls.Add(this.textBox7);
            this.groupBox2.Font = new System.Drawing.Font("굴림체", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.groupBox2.ForeColor = System.Drawing.Color.Yellow;
            this.groupBox2.Location = new System.Drawing.Point(610, 169);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(504, 192);
            this.groupBox2.TabIndex = 121;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "가스기록 설정";
            // 
            // analogBox4
            // 
            this.analogBox4.AccessMode = IronControls.AccessModes.DirectMode;
            this.analogBox4.BoxName = "";
            this.analogBox4.CommComponent = this.ironSANClient1;
            this.analogBox4.Data = 0D;
            this.analogBox4.DecimalPlace = 2;
            this.analogBox4.Description = "Analog IO";
            this.analogBox4.Exponent = false;
            this.analogBox4.FirstTag = "AO.EEMS-R1.gas_per_KRW";
            this.analogBox4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.analogBox4.Gain = 1D;
            this.analogBox4.GroupSeparator = false;
            this.analogBox4.Location = new System.Drawing.Point(246, 134);
            this.analogBox4.Max = 999999999;
            this.analogBox4.Min = 0;
            this.analogBox4.Mode = IronControls._Mode.VALUE_DISPLAY;
            this.analogBox4.Name = "analogBox4";
            this.analogBox4.Offset = 0D;
            this.analogBox4.Round = false;
            this.analogBox4.SecondTag = "";
            this.analogBox4.Size = new System.Drawing.Size(240, 28);
            this.analogBox4.TabIndex = 128;
            this.analogBox4.Tags = ((System.Collections.Generic.List<string>)(resources.GetObject("analogBox4.Tags")));
            this.analogBox4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.analogBox4.Type = IronControls.IOType.OUTPUT;
            this.analogBox4.Unit = "";
            this.analogBox4.UpdateMode = CommLib.UpdateMode.OnChange;
            this.analogBox4.UpdateTime = 500;
            // 
            // analogBox3
            // 
            this.analogBox3.AccessMode = IronControls.AccessModes.DirectMode;
            this.analogBox3.BoxName = "";
            this.analogBox3.CommComponent = this.ironSANClient1;
            this.analogBox3.Data = 0D;
            this.analogBox3.DecimalPlace = 2;
            this.analogBox3.Description = "Analog IO";
            this.analogBox3.Exponent = false;
            this.analogBox3.FirstTag = "AO.EEMS-R1.pulse_per_gas";
            this.analogBox3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.analogBox3.Gain = 1D;
            this.analogBox3.GroupSeparator = false;
            this.analogBox3.Location = new System.Drawing.Point(246, 89);
            this.analogBox3.Max = 999999999;
            this.analogBox3.Min = 0;
            this.analogBox3.Mode = IronControls._Mode.VALUE_DISPLAY;
            this.analogBox3.Name = "analogBox3";
            this.analogBox3.Offset = 0D;
            this.analogBox3.Round = false;
            this.analogBox3.SecondTag = "";
            this.analogBox3.Size = new System.Drawing.Size(240, 30);
            this.analogBox3.TabIndex = 127;
            this.analogBox3.Tags = ((System.Collections.Generic.List<string>)(resources.GetObject("analogBox3.Tags")));
            this.analogBox3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.analogBox3.Type = IronControls.IOType.OUTPUT;
            this.analogBox3.Unit = "";
            this.analogBox3.UpdateMode = CommLib.UpdateMode.OnChange;
            this.analogBox3.UpdateTime = 500;
            // 
            // analogBox2
            // 
            this.analogBox2.AccessMode = IronControls.AccessModes.DirectMode;
            this.analogBox2.BoxName = "";
            this.analogBox2.CommComponent = this.ironSANClient1;
            this.analogBox2.Data = 0D;
            this.analogBox2.DecimalPlace = 0;
            this.analogBox2.Description = "Analog IO";
            this.analogBox2.Exponent = false;
            this.analogBox2.FirstTag = "AO.EEMS-R1.PLC_Max_Gas";
            this.analogBox2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.analogBox2.Gain = 1D;
            this.analogBox2.GroupSeparator = false;
            this.analogBox2.Location = new System.Drawing.Point(246, 46);
            this.analogBox2.Max = 999999999;
            this.analogBox2.Min = 0;
            this.analogBox2.Mode = IronControls._Mode.VALUE_DISPLAY;
            this.analogBox2.Name = "analogBox2";
            this.analogBox2.Offset = 0D;
            this.analogBox2.Round = false;
            this.analogBox2.SecondTag = "";
            this.analogBox2.Size = new System.Drawing.Size(240, 31);
            this.analogBox2.TabIndex = 126;
            this.analogBox2.Tags = ((System.Collections.Generic.List<string>)(resources.GetObject("analogBox2.Tags")));
            this.analogBox2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.analogBox2.Type = IronControls.IOType.OUTPUT;
            this.analogBox2.Unit = "";
            this.analogBox2.UpdateMode = CommLib.UpdateMode.OnChange;
            this.analogBox2.UpdateTime = 500;
            // 
            // groupBox3
            // 
            this.groupBox3.BackColor = System.Drawing.Color.Transparent;
            this.groupBox3.Controls.Add(this.analogBox5);
            this.groupBox3.Controls.Add(this.textBox1);
            this.groupBox3.Controls.Add(this.analogBox6);
            this.groupBox3.Controls.Add(this.textBox4);
            this.groupBox3.Controls.Add(this.analogBox7);
            this.groupBox3.Controls.Add(this.textBox5);
            this.groupBox3.Font = new System.Drawing.Font("굴림체", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.groupBox3.ForeColor = System.Drawing.Color.Yellow;
            this.groupBox3.Location = new System.Drawing.Point(610, 383);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(504, 189);
            this.groupBox3.TabIndex = 122;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "적산전력 설정";
            // 
            // analogBox5
            // 
            this.analogBox5.AccessMode = IronControls.AccessModes.DirectMode;
            this.analogBox5.BoxName = "";
            this.analogBox5.CommComponent = this.ironSANClient1;
            this.analogBox5.Data = 0D;
            this.analogBox5.DecimalPlace = 2;
            this.analogBox5.Description = "Analog IO";
            this.analogBox5.Exponent = false;
            this.analogBox5.FirstTag = "AO.EEMS-R1.pc_watt_per_KRW";
            this.analogBox5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.analogBox5.Gain = 1D;
            this.analogBox5.GroupSeparator = false;
            this.analogBox5.Location = new System.Drawing.Point(252, 139);
            this.analogBox5.Max = 999999999;
            this.analogBox5.Min = 0;
            this.analogBox5.Mode = IronControls._Mode.VALUE_DISPLAY;
            this.analogBox5.Name = "analogBox5";
            this.analogBox5.Offset = 0D;
            this.analogBox5.Round = false;
            this.analogBox5.SecondTag = "";
            this.analogBox5.Size = new System.Drawing.Size(234, 33);
            this.analogBox5.TabIndex = 131;
            this.analogBox5.Tags = ((System.Collections.Generic.List<string>)(resources.GetObject("analogBox5.Tags")));
            this.analogBox5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.analogBox5.Type = IronControls.IOType.OUTPUT;
            this.analogBox5.Unit = "";
            this.analogBox5.UpdateMode = CommLib.UpdateMode.OnChange;
            this.analogBox5.UpdateTime = 500;
            this.analogBox5.Load += new System.EventHandler(this.analogBox5_Load);
            // 
            // analogBox6
            // 
            this.analogBox6.AccessMode = IronControls.AccessModes.DirectMode;
            this.analogBox6.BoxName = "";
            this.analogBox6.CommComponent = this.ironSANClient1;
            this.analogBox6.Data = 0D;
            this.analogBox6.DecimalPlace = 2;
            this.analogBox6.Description = "Analog IO";
            this.analogBox6.Exponent = false;
            this.analogBox6.FirstTag = "AO.EEMS-R1.plc_watt_per_pc_watt";
            this.analogBox6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.analogBox6.Gain = 1D;
            this.analogBox6.GroupSeparator = false;
            this.analogBox6.Location = new System.Drawing.Point(252, 93);
            this.analogBox6.Max = 999999999;
            this.analogBox6.Min = 0;
            this.analogBox6.Mode = IronControls._Mode.VALUE_DISPLAY;
            this.analogBox6.Name = "analogBox6";
            this.analogBox6.Offset = 0D;
            this.analogBox6.Round = false;
            this.analogBox6.SecondTag = "";
            this.analogBox6.Size = new System.Drawing.Size(234, 33);
            this.analogBox6.TabIndex = 130;
            this.analogBox6.Tags = ((System.Collections.Generic.List<string>)(resources.GetObject("analogBox6.Tags")));
            this.analogBox6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.analogBox6.Type = IronControls.IOType.OUTPUT;
            this.analogBox6.Unit = "";
            this.analogBox6.UpdateMode = CommLib.UpdateMode.OnChange;
            this.analogBox6.UpdateTime = 500;
            // 
            // analogBox7
            // 
            this.analogBox7.AccessMode = IronControls.AccessModes.DirectMode;
            this.analogBox7.BoxName = "";
            this.analogBox7.CommComponent = this.ironSANClient1;
            this.analogBox7.Data = 0D;
            this.analogBox7.DecimalPlace = 0;
            this.analogBox7.Description = "Analog IO";
            this.analogBox7.Exponent = false;
            this.analogBox7.FirstTag = "AO.EEMS-R1.PLC_Max_Watt";
            this.analogBox7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.analogBox7.Gain = 1D;
            this.analogBox7.GroupSeparator = false;
            this.analogBox7.Location = new System.Drawing.Point(252, 50);
            this.analogBox7.Max = 999999999;
            this.analogBox7.Min = 0;
            this.analogBox7.Mode = IronControls._Mode.VALUE_DISPLAY;
            this.analogBox7.Name = "analogBox7";
            this.analogBox7.Offset = 0D;
            this.analogBox7.Round = false;
            this.analogBox7.SecondTag = "";
            this.analogBox7.Size = new System.Drawing.Size(234, 30);
            this.analogBox7.TabIndex = 129;
            this.analogBox7.Tags = ((System.Collections.Generic.List<string>)(resources.GetObject("analogBox7.Tags")));
            this.analogBox7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.analogBox7.Type = IronControls.IOType.OUTPUT;
            this.analogBox7.Unit = "";
            this.analogBox7.UpdateMode = CommLib.UpdateMode.OnChange;
            this.analogBox7.UpdateTime = 500;
            // 
            // groupBox4
            // 
            this.groupBox4.BackColor = System.Drawing.Color.Transparent;
            this.groupBox4.Controls.Add(this.analogBox16);
            this.groupBox4.Controls.Add(this.analogBox15);
            this.groupBox4.Controls.Add(this.analogBox14);
            this.groupBox4.Controls.Add(this.analogBox13);
            this.groupBox4.Controls.Add(this.analogBox12);
            this.groupBox4.Controls.Add(this.analogBox11);
            this.groupBox4.Controls.Add(this.textBox8);
            this.groupBox4.Controls.Add(this.textBox11);
            this.groupBox4.Controls.Add(this.textBox17);
            this.groupBox4.Controls.Add(this.textBox19);
            this.groupBox4.Controls.Add(this.textBox18);
            this.groupBox4.Controls.Add(this.textBox20);
            this.groupBox4.Font = new System.Drawing.Font("굴림체", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.groupBox4.ForeColor = System.Drawing.Color.Yellow;
            this.groupBox4.Location = new System.Drawing.Point(1142, 386);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(504, 354);
            this.groupBox4.TabIndex = 123;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "엘레베이터 설정";
            // 
            // analogBox16
            // 
            this.analogBox16.AccessMode = IronControls.AccessModes.DirectMode;
            this.analogBox16.BoxName = "";
            this.analogBox16.CommComponent = this.ironSANClient1;
            this.analogBox16.Data = 0D;
            this.analogBox16.DecimalPlace = 0;
            this.analogBox16.Description = "Analog IO";
            this.analogBox16.Exponent = false;
            this.analogBox16.FirstTag = "AO.EEMS-R1.gas_per_KRW         ";
            this.analogBox16.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.analogBox16.Gain = 1D;
            this.analogBox16.GroupSeparator = false;
            this.analogBox16.Location = new System.Drawing.Point(258, 245);
            this.analogBox16.Max = 999999999;
            this.analogBox16.Min = 0;
            this.analogBox16.Mode = IronControls._Mode.VALUE_DISPLAY;
            this.analogBox16.Name = "analogBox16";
            this.analogBox16.Offset = 0D;
            this.analogBox16.Round = false;
            this.analogBox16.SecondTag = "";
            this.analogBox16.Size = new System.Drawing.Size(227, 29);
            this.analogBox16.TabIndex = 137;
            this.analogBox16.Tags = ((System.Collections.Generic.List<string>)(resources.GetObject("analogBox16.Tags")));
            this.analogBox16.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.analogBox16.Type = IronControls.IOType.OUTPUT;
            this.analogBox16.Unit = "";
            this.analogBox16.UpdateMode = CommLib.UpdateMode.OnChange;
            this.analogBox16.UpdateTime = 500;
            // 
            // analogBox15
            // 
            this.analogBox15.AccessMode = IronControls.AccessModes.DirectMode;
            this.analogBox15.BoxName = "";
            this.analogBox15.CommComponent = this.ironSANClient1;
            this.analogBox15.Data = 0D;
            this.analogBox15.DecimalPlace = 0;
            this.analogBox15.Description = "Analog IO";
            this.analogBox15.Exponent = false;
            this.analogBox15.FirstTag = "AO.EEMS-R1.gas_per_KRW         ";
            this.analogBox15.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.analogBox15.Gain = 1D;
            this.analogBox15.GroupSeparator = false;
            this.analogBox15.Location = new System.Drawing.Point(258, 207);
            this.analogBox15.Max = 999999999;
            this.analogBox15.Min = 0;
            this.analogBox15.Mode = IronControls._Mode.VALUE_DISPLAY;
            this.analogBox15.Name = "analogBox15";
            this.analogBox15.Offset = 0D;
            this.analogBox15.Round = false;
            this.analogBox15.SecondTag = "";
            this.analogBox15.Size = new System.Drawing.Size(227, 31);
            this.analogBox15.TabIndex = 136;
            this.analogBox15.Tags = ((System.Collections.Generic.List<string>)(resources.GetObject("analogBox15.Tags")));
            this.analogBox15.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.analogBox15.Type = IronControls.IOType.OUTPUT;
            this.analogBox15.Unit = "";
            this.analogBox15.UpdateMode = CommLib.UpdateMode.OnChange;
            this.analogBox15.UpdateTime = 500;
            // 
            // analogBox14
            // 
            this.analogBox14.AccessMode = IronControls.AccessModes.DirectMode;
            this.analogBox14.BoxName = "";
            this.analogBox14.CommComponent = this.ironSANClient1;
            this.analogBox14.Data = 0D;
            this.analogBox14.DecimalPlace = 0;
            this.analogBox14.Description = "Analog IO";
            this.analogBox14.Exponent = false;
            this.analogBox14.FirstTag = "AO.EEMS-R1.gas_per_KRW         ";
            this.analogBox14.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.analogBox14.Gain = 1D;
            this.analogBox14.GroupSeparator = false;
            this.analogBox14.Location = new System.Drawing.Point(258, 170);
            this.analogBox14.Max = 999999999;
            this.analogBox14.Min = 0;
            this.analogBox14.Mode = IronControls._Mode.VALUE_DISPLAY;
            this.analogBox14.Name = "analogBox14";
            this.analogBox14.Offset = 0D;
            this.analogBox14.Round = false;
            this.analogBox14.SecondTag = "";
            this.analogBox14.Size = new System.Drawing.Size(227, 31);
            this.analogBox14.TabIndex = 135;
            this.analogBox14.Tags = ((System.Collections.Generic.List<string>)(resources.GetObject("analogBox14.Tags")));
            this.analogBox14.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.analogBox14.Type = IronControls.IOType.OUTPUT;
            this.analogBox14.Unit = "";
            this.analogBox14.UpdateMode = CommLib.UpdateMode.OnChange;
            this.analogBox14.UpdateTime = 500;
            // 
            // analogBox13
            // 
            this.analogBox13.AccessMode = IronControls.AccessModes.DirectMode;
            this.analogBox13.BoxName = "";
            this.analogBox13.CommComponent = this.ironSANClient1;
            this.analogBox13.Data = 0D;
            this.analogBox13.DecimalPlace = 0;
            this.analogBox13.Description = "Analog IO";
            this.analogBox13.Exponent = false;
            this.analogBox13.FirstTag = "AO.EEMS-R1.gas_per_KRW         ";
            this.analogBox13.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.analogBox13.Gain = 1D;
            this.analogBox13.GroupSeparator = false;
            this.analogBox13.Location = new System.Drawing.Point(258, 128);
            this.analogBox13.Max = 999999999;
            this.analogBox13.Min = 0;
            this.analogBox13.Mode = IronControls._Mode.VALUE_DISPLAY;
            this.analogBox13.Name = "analogBox13";
            this.analogBox13.Offset = 0D;
            this.analogBox13.Round = false;
            this.analogBox13.SecondTag = "";
            this.analogBox13.Size = new System.Drawing.Size(227, 32);
            this.analogBox13.TabIndex = 134;
            this.analogBox13.Tags = ((System.Collections.Generic.List<string>)(resources.GetObject("analogBox13.Tags")));
            this.analogBox13.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.analogBox13.Type = IronControls.IOType.OUTPUT;
            this.analogBox13.Unit = "";
            this.analogBox13.UpdateMode = CommLib.UpdateMode.OnChange;
            this.analogBox13.UpdateTime = 500;
            // 
            // analogBox12
            // 
            this.analogBox12.AccessMode = IronControls.AccessModes.DirectMode;
            this.analogBox12.BoxName = "";
            this.analogBox12.CommComponent = this.ironSANClient1;
            this.analogBox12.Data = 0D;
            this.analogBox12.DecimalPlace = 0;
            this.analogBox12.Description = "Analog IO";
            this.analogBox12.Exponent = false;
            this.analogBox12.FirstTag = "AO.EEMS-R1.gas_per_KRW         ";
            this.analogBox12.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.analogBox12.Gain = 1D;
            this.analogBox12.GroupSeparator = false;
            this.analogBox12.Location = new System.Drawing.Point(258, 88);
            this.analogBox12.Max = 999999999;
            this.analogBox12.Min = 0;
            this.analogBox12.Mode = IronControls._Mode.VALUE_DISPLAY;
            this.analogBox12.Name = "analogBox12";
            this.analogBox12.Offset = 0D;
            this.analogBox12.Round = false;
            this.analogBox12.SecondTag = "";
            this.analogBox12.Size = new System.Drawing.Size(227, 31);
            this.analogBox12.TabIndex = 133;
            this.analogBox12.Tags = ((System.Collections.Generic.List<string>)(resources.GetObject("analogBox12.Tags")));
            this.analogBox12.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.analogBox12.Type = IronControls.IOType.OUTPUT;
            this.analogBox12.Unit = "";
            this.analogBox12.UpdateMode = CommLib.UpdateMode.OnChange;
            this.analogBox12.UpdateTime = 500;
            // 
            // analogBox11
            // 
            this.analogBox11.AccessMode = IronControls.AccessModes.DirectMode;
            this.analogBox11.BoxName = "";
            this.analogBox11.CommComponent = this.ironSANClient1;
            this.analogBox11.Data = 0D;
            this.analogBox11.DecimalPlace = 0;
            this.analogBox11.Description = "Analog IO";
            this.analogBox11.Exponent = false;
            this.analogBox11.FirstTag = "AO.EEMS-R1.gas_per_KRW         ";
            this.analogBox11.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.analogBox11.Gain = 1D;
            this.analogBox11.GroupSeparator = false;
            this.analogBox11.Location = new System.Drawing.Point(258, 44);
            this.analogBox11.Max = 999999999;
            this.analogBox11.Min = 0;
            this.analogBox11.Mode = IronControls._Mode.VALUE_DISPLAY;
            this.analogBox11.Name = "analogBox11";
            this.analogBox11.Offset = 0D;
            this.analogBox11.Round = false;
            this.analogBox11.SecondTag = "";
            this.analogBox11.Size = new System.Drawing.Size(227, 33);
            this.analogBox11.TabIndex = 132;
            this.analogBox11.Tags = ((System.Collections.Generic.List<string>)(resources.GetObject("analogBox11.Tags")));
            this.analogBox11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.analogBox11.Type = IronControls.IOType.OUTPUT;
            this.analogBox11.Unit = "";
            this.analogBox11.UpdateMode = CommLib.UpdateMode.OnChange;
            this.analogBox11.UpdateTime = 500;
            // 
            // textBox8
            // 
            this.textBox8.BackColor = System.Drawing.Color.Yellow;
            this.textBox8.Font = new System.Drawing.Font("굴림체", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.textBox8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.textBox8.Location = new System.Drawing.Point(21, 245);
            this.textBox8.Multiline = true;
            this.textBox8.Name = "textBox8";
            this.textBox8.Size = new System.Drawing.Size(221, 29);
            this.textBox8.TabIndex = 126;
            this.textBox8.Text = "인고트스크랩이동";
            this.textBox8.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox11
            // 
            this.textBox11.BackColor = System.Drawing.Color.Yellow;
            this.textBox11.Font = new System.Drawing.Font("굴림체", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.textBox11.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.textBox11.Location = new System.Drawing.Point(21, 207);
            this.textBox11.Multiline = true;
            this.textBox11.Name = "textBox11";
            this.textBox11.Size = new System.Drawing.Size(221, 31);
            this.textBox11.TabIndex = 125;
            this.textBox11.Text = "스크랩인고트이동";
            this.textBox11.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox17
            // 
            this.textBox17.BackColor = System.Drawing.Color.Yellow;
            this.textBox17.Font = new System.Drawing.Font("굴림체", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.textBox17.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.textBox17.Location = new System.Drawing.Point(21, 44);
            this.textBox17.Multiline = true;
            this.textBox17.Name = "textBox17";
            this.textBox17.Size = new System.Drawing.Size(221, 33);
            this.textBox17.TabIndex = 117;
            this.textBox17.Text = "인고트상승시간";
            this.textBox17.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox19
            // 
            this.textBox19.BackColor = System.Drawing.Color.Yellow;
            this.textBox19.Font = new System.Drawing.Font("굴림체", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.textBox19.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.textBox19.Location = new System.Drawing.Point(21, 169);
            this.textBox19.Multiline = true;
            this.textBox19.Name = "textBox19";
            this.textBox19.Size = new System.Drawing.Size(221, 31);
            this.textBox19.TabIndex = 123;
            this.textBox19.Text = "스크랩하강시간";
            this.textBox19.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox18
            // 
            this.textBox18.BackColor = System.Drawing.Color.Yellow;
            this.textBox18.Font = new System.Drawing.Font("굴림체", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.textBox18.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.textBox18.Location = new System.Drawing.Point(21, 88);
            this.textBox18.Multiline = true;
            this.textBox18.Name = "textBox18";
            this.textBox18.Size = new System.Drawing.Size(221, 31);
            this.textBox18.TabIndex = 119;
            this.textBox18.Text = "스크랩상승시간";
            this.textBox18.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox20
            // 
            this.textBox20.BackColor = System.Drawing.Color.Yellow;
            this.textBox20.Font = new System.Drawing.Font("굴림체", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.textBox20.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.textBox20.Location = new System.Drawing.Point(21, 128);
            this.textBox20.Multiline = true;
            this.textBox20.Name = "textBox20";
            this.textBox20.Size = new System.Drawing.Size(221, 32);
            this.textBox20.TabIndex = 121;
            this.textBox20.Text = "인고트하강시간";
            this.textBox20.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // groupBox5
            // 
            this.groupBox5.BackColor = System.Drawing.Color.Transparent;
            this.groupBox5.Controls.Add(this.analogBox10);
            this.groupBox5.Controls.Add(this.textBox9);
            this.groupBox5.Font = new System.Drawing.Font("굴림체", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.groupBox5.ForeColor = System.Drawing.Color.Yellow;
            this.groupBox5.Location = new System.Drawing.Point(1142, 775);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(504, 93);
            this.groupBox5.TabIndex = 124;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "컨베이어 설정";
            // 
            // analogBox10
            // 
            this.analogBox10.AccessMode = IronControls.AccessModes.DirectMode;
            this.analogBox10.BoxName = "";
            this.analogBox10.CommComponent = this.ironSANClient1;
            this.analogBox10.Data = 0D;
            this.analogBox10.DecimalPlace = 0;
            this.analogBox10.Description = "Analog IO";
            this.analogBox10.Exponent = false;
            this.analogBox10.FirstTag = "AO.EEMS-R1.gas_per_KRW         ";
            this.analogBox10.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.analogBox10.Gain = 1D;
            this.analogBox10.GroupSeparator = false;
            this.analogBox10.Location = new System.Drawing.Point(258, 42);
            this.analogBox10.Max = 999999999;
            this.analogBox10.Min = 0;
            this.analogBox10.Mode = IronControls._Mode.VALUE_DISPLAY;
            this.analogBox10.Name = "analogBox10";
            this.analogBox10.Offset = 0D;
            this.analogBox10.Round = false;
            this.analogBox10.SecondTag = "";
            this.analogBox10.Size = new System.Drawing.Size(227, 31);
            this.analogBox10.TabIndex = 131;
            this.analogBox10.Tags = ((System.Collections.Generic.List<string>)(resources.GetObject("analogBox10.Tags")));
            this.analogBox10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.analogBox10.Type = IronControls.IOType.OUTPUT;
            this.analogBox10.Unit = "";
            this.analogBox10.UpdateMode = CommLib.UpdateMode.OnChange;
            this.analogBox10.UpdateTime = 500;
            // 
            // groupBox6
            // 
            this.groupBox6.BackColor = System.Drawing.Color.Transparent;
            this.groupBox6.Controls.Add(this.analogBox9);
            this.groupBox6.Controls.Add(this.analogBox8);
            this.groupBox6.Controls.Add(this.textBox16);
            this.groupBox6.Controls.Add(this.textBox15);
            this.groupBox6.Font = new System.Drawing.Font("굴림체", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.groupBox6.ForeColor = System.Drawing.Color.Yellow;
            this.groupBox6.Location = new System.Drawing.Point(1142, 169);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(504, 145);
            this.groupBox6.TabIndex = 124;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "타워 설정";
            // 
            // analogBox9
            // 
            this.analogBox9.AccessMode = IronControls.AccessModes.DirectMode;
            this.analogBox9.BoxName = "";
            this.analogBox9.CommComponent = this.ironSANClient1;
            this.analogBox9.Data = 0D;
            this.analogBox9.DecimalPlace = 0;
            this.analogBox9.Description = "Analog IO";
            this.analogBox9.Exponent = false;
            this.analogBox9.FirstTag = "AO.EEMS-R1.gas_per_KRW         ";
            this.analogBox9.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.analogBox9.Gain = 1D;
            this.analogBox9.GroupSeparator = false;
            this.analogBox9.Location = new System.Drawing.Point(258, 89);
            this.analogBox9.Max = 999999999;
            this.analogBox9.Min = 0;
            this.analogBox9.Mode = IronControls._Mode.VALUE_DISPLAY;
            this.analogBox9.Name = "analogBox9";
            this.analogBox9.Offset = 0D;
            this.analogBox9.Round = false;
            this.analogBox9.SecondTag = "";
            this.analogBox9.Size = new System.Drawing.Size(227, 30);
            this.analogBox9.TabIndex = 130;
            this.analogBox9.Tags = ((System.Collections.Generic.List<string>)(resources.GetObject("analogBox9.Tags")));
            this.analogBox9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.analogBox9.Type = IronControls.IOType.OUTPUT;
            this.analogBox9.Unit = "";
            this.analogBox9.UpdateMode = CommLib.UpdateMode.OnChange;
            this.analogBox9.UpdateTime = 500;
            // 
            // analogBox8
            // 
            this.analogBox8.AccessMode = IronControls.AccessModes.DirectMode;
            this.analogBox8.BoxName = "";
            this.analogBox8.CommComponent = this.ironSANClient1;
            this.analogBox8.Data = 0D;
            this.analogBox8.DecimalPlace = 0;
            this.analogBox8.Description = "Analog IO";
            this.analogBox8.Exponent = false;
            this.analogBox8.FirstTag = "";
            this.analogBox8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.analogBox8.Gain = 1D;
            this.analogBox8.GroupSeparator = false;
            this.analogBox8.Location = new System.Drawing.Point(258, 46);
            this.analogBox8.Max = 999999999;
            this.analogBox8.Min = 0;
            this.analogBox8.Mode = IronControls._Mode.VALUE_DISPLAY;
            this.analogBox8.Name = "analogBox8";
            this.analogBox8.Offset = 0D;
            this.analogBox8.Round = true;
            this.analogBox8.SecondTag = "";
            this.analogBox8.Size = new System.Drawing.Size(227, 31);
            this.analogBox8.TabIndex = 129;
            this.analogBox8.Tags = ((System.Collections.Generic.List<string>)(resources.GetObject("analogBox8.Tags")));
            this.analogBox8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.analogBox8.Type = IronControls.IOType.OUTPUT;
            this.analogBox8.Unit = "";
            this.analogBox8.UpdateMode = CommLib.UpdateMode.OnChange;
            this.analogBox8.UpdateTime = 500;
            // 
            // textBox16
            // 
            this.textBox16.BackColor = System.Drawing.Color.Yellow;
            this.textBox16.Font = new System.Drawing.Font("굴림체", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.textBox16.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.textBox16.Location = new System.Drawing.Point(21, 89);
            this.textBox16.Multiline = true;
            this.textBox16.Name = "textBox16";
            this.textBox16.Size = new System.Drawing.Size(221, 30);
            this.textBox16.TabIndex = 118;
            this.textBox16.Text = "타워닫힘시간[sec]";
            this.textBox16.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox15
            // 
            this.textBox15.BackColor = System.Drawing.Color.Yellow;
            this.textBox15.Font = new System.Drawing.Font("굴림체", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.textBox15.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.textBox15.Location = new System.Drawing.Point(21, 46);
            this.textBox15.Multiline = true;
            this.textBox15.Name = "textBox15";
            this.textBox15.Size = new System.Drawing.Size(221, 31);
            this.textBox15.TabIndex = 117;
            this.textBox15.Text = "타워열림시간[sec]";
            this.textBox15.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // timer_work_data
            // 
            this.timer_work_data.Interval = 1000;
            this.timer_work_data.Tick += new System.EventHandler(this.timer_work_data_Tick);
            // 
            // opcClient2
            // 
            this.opcClient2.Group = "MyGroup";
            this.opcClient2.Server = "Intellution.LSEOPC";
            this.opcClient2.SynchronizingObject = this;
            this.opcClient2.Topic = "";
            // 
            // groupBox7
            // 
            this.groupBox7.BackColor = System.Drawing.Color.Transparent;
            this.groupBox7.Controls.Add(this.analogBox17);
            this.groupBox7.Controls.Add(this.stringBox1);
            this.groupBox7.Controls.Add(this.textBox13);
            this.groupBox7.Controls.Add(this.textBox14);
            this.groupBox7.Font = new System.Drawing.Font("굴림체", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.groupBox7.ForeColor = System.Drawing.Color.Yellow;
            this.groupBox7.Location = new System.Drawing.Point(81, 450);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(504, 148);
            this.groupBox7.TabIndex = 126;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "운전기준 설정";
            // 
            // analogBox17
            // 
            this.analogBox17.AccessMode = IronControls.AccessModes.DirectMode;
            this.analogBox17.BoxName = "";
            this.analogBox17.CommComponent = this.ironSANClient1;
            this.analogBox17.Data = 0D;
            this.analogBox17.DecimalPlace = 0;
            this.analogBox17.Description = "Analog IO";
            this.analogBox17.Exponent = false;
            this.analogBox17.FirstTag = "AO.EEMS-R1.Num_Of_Workgroups";
            this.analogBox17.Font = new System.Drawing.Font("굴림체", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.analogBox17.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.analogBox17.Gain = 1D;
            this.analogBox17.GroupSeparator = false;
            this.analogBox17.Location = new System.Drawing.Point(252, 93);
            this.analogBox17.Max = 24;
            this.analogBox17.Min = 0;
            this.analogBox17.Mode = IronControls._Mode.VALUE_DISPLAY;
            this.analogBox17.Name = "analogBox17";
            this.analogBox17.Offset = 0D;
            this.analogBox17.Round = true;
            this.analogBox17.SecondTag = "";
            this.analogBox17.Size = new System.Drawing.Size(233, 29);
            this.analogBox17.TabIndex = 125;
            this.analogBox17.Tags = ((System.Collections.Generic.List<string>)(resources.GetObject("analogBox17.Tags")));
            this.analogBox17.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.analogBox17.Type = IronControls.IOType.OUTPUT;
            this.analogBox17.Unit = "";
            this.analogBox17.UpdateMode = CommLib.UpdateMode.OnChange;
            this.analogBox17.UpdateTime = 500;
            // 
            // stringBox1
            // 
            this.stringBox1.AccessMode = IronControls.AccessModes.DirectMode;
            this.stringBox1.BoxName = "";
            this.stringBox1.CommComponent = this.ironSANClient1;
            this.stringBox1.Data = "";
            this.stringBox1.Description = "String IO";
            this.stringBox1.EnableWrite = true;
            this.stringBox1.FirstTag = "SO.EEMS-R1.ReferenceTime_Workday";
            this.stringBox1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.stringBox1.Location = new System.Drawing.Point(252, 47);
            this.stringBox1.Mode = IronControls._Mode.VALUE_DISPLAY;
            this.stringBox1.Name = "stringBox1";
            this.stringBox1.SecondTag = "";
            this.stringBox1.Size = new System.Drawing.Size(233, 30);
            this.stringBox1.TabIndex = 102;
            this.stringBox1.Tags = ((System.Collections.Generic.List<string>)(resources.GetObject("stringBox1.Tags")));
            this.stringBox1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.stringBox1.TimeMode = false;
            this.stringBox1.Type = IronControls.IOType.OUTPUT;
            this.stringBox1.UpdateMode = CommLib.UpdateMode.OnChange;
            this.stringBox1.UpdateTime = 500;
            // 
            // textBox13
            // 
            this.textBox13.BackColor = System.Drawing.Color.Yellow;
            this.textBox13.Font = new System.Drawing.Font("굴림체", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.textBox13.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.textBox13.Location = new System.Drawing.Point(21, 47);
            this.textBox13.Multiline = true;
            this.textBox13.Name = "textBox13";
            this.textBox13.Size = new System.Drawing.Size(215, 30);
            this.textBox13.TabIndex = 101;
            this.textBox13.Text = "일일작업 기준시간";
            this.textBox13.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox14
            // 
            this.textBox14.BackColor = System.Drawing.Color.Yellow;
            this.textBox14.Font = new System.Drawing.Font("굴림체", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.textBox14.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.textBox14.Location = new System.Drawing.Point(21, 93);
            this.textBox14.Multiline = true;
            this.textBox14.Name = "textBox14";
            this.textBox14.Size = new System.Drawing.Size(215, 29);
            this.textBox14.TabIndex = 114;
            this.textBox14.Text = "작업조";
            this.textBox14.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // bt_PLC_EXEC
            // 
            this.bt_PLC_EXEC.Font = new System.Drawing.Font("굴림", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.bt_PLC_EXEC.Location = new System.Drawing.Point(81, 713);
            this.bt_PLC_EXEC.Name = "bt_PLC_EXEC";
            this.bt_PLC_EXEC.Size = new System.Drawing.Size(228, 71);
            this.bt_PLC_EXEC.TabIndex = 192;
            this.bt_PLC_EXEC.Text = "TO PLC";
            this.bt_PLC_EXEC.UseVisualStyleBackColor = true;
            this.bt_PLC_EXEC.Click += new System.EventHandler(this.bt_PLC_EXEC_Click);
            // 
            // groupBox8
            // 
            this.groupBox8.BackColor = System.Drawing.Color.Transparent;
            this.groupBox8.Controls.Add(this.analogBox1);
            this.groupBox8.Controls.Add(this.analogBox18);
            this.groupBox8.Controls.Add(this.textBox23);
            this.groupBox8.Controls.Add(this.textBox24);
            this.groupBox8.Font = new System.Drawing.Font("굴림체", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.groupBox8.ForeColor = System.Drawing.Color.Yellow;
            this.groupBox8.Location = new System.Drawing.Point(610, 596);
            this.groupBox8.Name = "groupBox8";
            this.groupBox8.Size = new System.Drawing.Size(504, 144);
            this.groupBox8.TabIndex = 193;
            this.groupBox8.TabStop = false;
            this.groupBox8.Text = "계량값 설정";
            // 
            // analogBox1
            // 
            this.analogBox1.AccessMode = IronControls.AccessModes.DirectMode;
            this.analogBox1.BoxName = "";
            this.analogBox1.CommComponent = this.ironSANClient1;
            this.analogBox1.Data = 0D;
            this.analogBox1.DecimalPlace = 2;
            this.analogBox1.Description = "Analog IO";
            this.analogBox1.Exponent = false;
            this.analogBox1.FirstTag = "AO.EEMS-R1.scrap_per_kg";
            this.analogBox1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.analogBox1.Gain = 1D;
            this.analogBox1.GroupSeparator = false;
            this.analogBox1.Location = new System.Drawing.Point(252, 87);
            this.analogBox1.Max = 999999999;
            this.analogBox1.Min = 0;
            this.analogBox1.Mode = IronControls._Mode.VALUE_DISPLAY;
            this.analogBox1.Name = "analogBox1";
            this.analogBox1.Offset = 0D;
            this.analogBox1.Round = false;
            this.analogBox1.SecondTag = "";
            this.analogBox1.Size = new System.Drawing.Size(234, 33);
            this.analogBox1.TabIndex = 131;
            this.analogBox1.Tags = ((System.Collections.Generic.List<string>)(resources.GetObject("analogBox1.Tags")));
            this.analogBox1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.analogBox1.Type = IronControls.IOType.OUTPUT;
            this.analogBox1.Unit = "";
            this.analogBox1.UpdateMode = CommLib.UpdateMode.OnChange;
            this.analogBox1.UpdateTime = 500;
            // 
            // analogBox18
            // 
            this.analogBox18.AccessMode = IronControls.AccessModes.DirectMode;
            this.analogBox18.BoxName = "";
            this.analogBox18.CommComponent = this.ironSANClient1;
            this.analogBox18.Data = 0D;
            this.analogBox18.DecimalPlace = 2;
            this.analogBox18.Description = "Analog IO";
            this.analogBox18.Exponent = false;
            this.analogBox18.FirstTag = "AO.EEMS-R1.ingot_per_kg";
            this.analogBox18.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.analogBox18.Gain = 1D;
            this.analogBox18.GroupSeparator = false;
            this.analogBox18.Location = new System.Drawing.Point(252, 45);
            this.analogBox18.Max = 999999999;
            this.analogBox18.Min = 0;
            this.analogBox18.Mode = IronControls._Mode.VALUE_DISPLAY;
            this.analogBox18.Name = "analogBox18";
            this.analogBox18.Offset = 0D;
            this.analogBox18.Round = false;
            this.analogBox18.SecondTag = "";
            this.analogBox18.Size = new System.Drawing.Size(234, 31);
            this.analogBox18.TabIndex = 130;
            this.analogBox18.Tags = ((System.Collections.Generic.List<string>)(resources.GetObject("analogBox18.Tags")));
            this.analogBox18.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.analogBox18.Type = IronControls.IOType.OUTPUT;
            this.analogBox18.Unit = "";
            this.analogBox18.UpdateMode = CommLib.UpdateMode.OnChange;
            this.analogBox18.UpdateTime = 500;
            // 
            // textBox23
            // 
            this.textBox23.BackColor = System.Drawing.Color.Yellow;
            this.textBox23.Font = new System.Drawing.Font("굴림체", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.textBox23.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.textBox23.Location = new System.Drawing.Point(23, 87);
            this.textBox23.Multiline = true;
            this.textBox23.Name = "textBox23";
            this.textBox23.Size = new System.Drawing.Size(215, 33);
            this.textBox23.TabIndex = 99;
            this.textBox23.Text = "스크랩 변환설정";
            this.textBox23.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox24
            // 
            this.textBox24.BackColor = System.Drawing.Color.Yellow;
            this.textBox24.Font = new System.Drawing.Font("굴림체", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.textBox24.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.textBox24.Location = new System.Drawing.Point(23, 45);
            this.textBox24.Multiline = true;
            this.textBox24.Name = "textBox24";
            this.textBox24.Size = new System.Drawing.Size(215, 31);
            this.textBox24.TabIndex = 100;
            this.textBox24.Text = "인고트 변환설정";
            this.textBox24.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // groupBox9
            // 
            this.groupBox9.BackColor = System.Drawing.Color.Transparent;
            this.groupBox9.Controls.Add(this.analogBox19);
            this.groupBox9.Controls.Add(this.analogBox20);
            this.groupBox9.Controls.Add(this.textBox12);
            this.groupBox9.Controls.Add(this.textBox25);
            this.groupBox9.Font = new System.Drawing.Font("굴림체", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.groupBox9.ForeColor = System.Drawing.Color.Yellow;
            this.groupBox9.Location = new System.Drawing.Point(610, 762);
            this.groupBox9.Name = "groupBox9";
            this.groupBox9.Size = new System.Drawing.Size(504, 141);
            this.groupBox9.TabIndex = 194;
            this.groupBox9.TabStop = false;
            this.groupBox9.Text = "온도값 설정";
            // 
            // analogBox19
            // 
            this.analogBox19.AccessMode = IronControls.AccessModes.DirectMode;
            this.analogBox19.BoxName = "";
            this.analogBox19.CommComponent = this.ironSANClient1;
            this.analogBox19.Data = 0D;
            this.analogBox19.DecimalPlace = 2;
            this.analogBox19.Description = "Analog IO";
            this.analogBox19.Exponent = false;
            this.analogBox19.FirstTag = "AO.EEMS-R1.furnace_temp_factor";
            this.analogBox19.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.analogBox19.Gain = 1D;
            this.analogBox19.GroupSeparator = false;
            this.analogBox19.Location = new System.Drawing.Point(252, 85);
            this.analogBox19.Max = 999999999;
            this.analogBox19.Min = 0;
            this.analogBox19.Mode = IronControls._Mode.VALUE_DISPLAY;
            this.analogBox19.Name = "analogBox19";
            this.analogBox19.Offset = 0D;
            this.analogBox19.Round = false;
            this.analogBox19.SecondTag = "";
            this.analogBox19.Size = new System.Drawing.Size(234, 35);
            this.analogBox19.TabIndex = 131;
            this.analogBox19.Tags = ((System.Collections.Generic.List<string>)(resources.GetObject("analogBox19.Tags")));
            this.analogBox19.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.analogBox19.Type = IronControls.IOType.OUTPUT;
            this.analogBox19.Unit = "";
            this.analogBox19.UpdateMode = CommLib.UpdateMode.OnChange;
            this.analogBox19.UpdateTime = 500;
            // 
            // analogBox20
            // 
            this.analogBox20.AccessMode = IronControls.AccessModes.DirectMode;
            this.analogBox20.BoxName = "";
            this.analogBox20.CommComponent = this.ironSANClient1;
            this.analogBox20.Data = 0D;
            this.analogBox20.DecimalPlace = 2;
            this.analogBox20.Description = "Analog IO";
            this.analogBox20.Exponent = false;
            this.analogBox20.FirstTag = "AO.EEMS-R1.tower_temp_factor";
            this.analogBox20.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.analogBox20.Gain = 1D;
            this.analogBox20.GroupSeparator = false;
            this.analogBox20.Location = new System.Drawing.Point(252, 41);
            this.analogBox20.Max = 999999999;
            this.analogBox20.Min = 0;
            this.analogBox20.Mode = IronControls._Mode.VALUE_DISPLAY;
            this.analogBox20.Name = "analogBox20";
            this.analogBox20.Offset = 0D;
            this.analogBox20.Round = false;
            this.analogBox20.SecondTag = "";
            this.analogBox20.Size = new System.Drawing.Size(234, 33);
            this.analogBox20.TabIndex = 130;
            this.analogBox20.Tags = ((System.Collections.Generic.List<string>)(resources.GetObject("analogBox20.Tags")));
            this.analogBox20.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.analogBox20.Type = IronControls.IOType.OUTPUT;
            this.analogBox20.Unit = "";
            this.analogBox20.UpdateMode = CommLib.UpdateMode.OnChange;
            this.analogBox20.UpdateTime = 500;
            // 
            // textBox12
            // 
            this.textBox12.BackColor = System.Drawing.Color.Yellow;
            this.textBox12.Font = new System.Drawing.Font("굴림체", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.textBox12.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.textBox12.Location = new System.Drawing.Point(23, 85);
            this.textBox12.Multiline = true;
            this.textBox12.Name = "textBox12";
            this.textBox12.Size = new System.Drawing.Size(215, 35);
            this.textBox12.TabIndex = 99;
            this.textBox12.Text = "용탕온도 변환설정";
            this.textBox12.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox25
            // 
            this.textBox25.BackColor = System.Drawing.Color.Yellow;
            this.textBox25.Font = new System.Drawing.Font("굴림체", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.textBox25.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.textBox25.Location = new System.Drawing.Point(23, 41);
            this.textBox25.Multiline = true;
            this.textBox25.Name = "textBox25";
            this.textBox25.Size = new System.Drawing.Size(215, 33);
            this.textBox25.TabIndex = 100;
            this.textBox25.Text = "타워온도 변환설정";
            this.textBox25.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("굴림", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.button1.Location = new System.Drawing.Point(69, 40);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(228, 71);
            this.button1.TabIndex = 195;
            this.button1.Text = "test";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Visible = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // ConfigScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(1840, 915);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.groupBox9);
            this.Controls.Add(this.groupBox8);
            this.Controls.Add(this.bt_PLC_EXEC);
            this.Controls.Add(this.groupBox7);
            this.Controls.Add(this.groupBox6);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.bt_readXML);
            this.Controls.Add(this.bt_save);
            this.Name = "ConfigScreen";
            this.Resolution = IronPanel._Resolution.HD1080;
            this.Text = "ConfigScreen";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.groupBox7.ResumeLayout(false);
            this.groupBox7.PerformLayout();
            this.groupBox8.ResumeLayout(false);
            this.groupBox8.PerformLayout();
            this.groupBox9.ResumeLayout(false);
            this.groupBox9.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private IronSANAdapter.IronSANClient ironSANClient1;
        private System.Windows.Forms.Button bt_save;
        private IronControls.StringBox sb_Path_Log;
        private System.Windows.Forms.TextBox textBox21;
        private IronControls.StringBox sb_ReferenceTime_Workday;
        private System.Windows.Forms.TextBox textBox6;
        private System.Windows.Forms.TextBox textBox5;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button bt_readXML;
        private System.Windows.Forms.TextBox textBox10;
        private System.Windows.Forms.TextBox textBox9;
        private System.Windows.Forms.TextBox textBox7;
        private IronControls.AnalogBox analogBox2;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.TextBox textBox16;
        private System.Windows.Forms.TextBox textBox15;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.TextBox textBox17;
        private System.Windows.Forms.TextBox textBox19;
        private System.Windows.Forms.TextBox textBox18;
        private System.Windows.Forms.TextBox textBox20;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox1;
        private IronControls.AnalogBox analogBox9;
        private IronControls.AnalogBox analogBox8;
        private IronControls.AnalogBox analogBox10;
        private IronControls.AnalogBox analogBox16;
        private IronControls.AnalogBox analogBox15;
        private IronControls.AnalogBox analogBox14;
        private IronControls.AnalogBox analogBox13;
        private IronControls.AnalogBox analogBox12;
        private IronControls.AnalogBox analogBox11;
        private System.Windows.Forms.TextBox textBox8;
        private System.Windows.Forms.TextBox textBox11;
        private IronControls.AnalogBox analogBox5;
        private IronControls.AnalogBox analogBox6;
        private IronControls.AnalogBox analogBox7;
        private IronControls.AnalogBox analogBox4;
        private IronControls.AnalogBox analogBox3;
        private System.Windows.Forms.Timer timer_work_data;
        private OPCAdapter.OPCClient opcClient2;
        private System.Windows.Forms.GroupBox groupBox7;
        private IronControls.AnalogBox analogBox17;
        private IronControls.StringBox stringBox1;
        private System.Windows.Forms.TextBox textBox13;
        private System.Windows.Forms.TextBox textBox14;
        private IronControls.StringBox stringBox4;
        private System.Windows.Forms.TextBox textBox22;
        private IronControls.StringBox stringBox3;
        private System.Windows.Forms.Button bt_PLC_EXEC;
        private System.Windows.Forms.GroupBox groupBox8;
        private IronControls.AnalogBox analogBox1;
        private IronControls.AnalogBox analogBox18;
        private System.Windows.Forms.TextBox textBox23;
        private System.Windows.Forms.TextBox textBox24;
        private System.Windows.Forms.GroupBox groupBox9;
        private IronControls.AnalogBox analogBox19;
        private IronControls.AnalogBox analogBox20;
        private System.Windows.Forms.TextBox textBox12;
        private System.Windows.Forms.TextBox textBox25;
        private System.Windows.Forms.Button button1;
    }
}