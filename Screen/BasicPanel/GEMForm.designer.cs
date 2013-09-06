namespace BasicPanel
{
	partial class GEMForm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GEMForm));
            this.textBox_Connection = new System.Windows.Forms.TextBox();
            this.textBox_Control = new System.Windows.Forms.TextBox();
            this.textBox_enable = new System.Windows.Forms.TextBox();
            this.textBox_communication = new System.Windows.Forms.TextBox();
            this.textBox_online = new System.Windows.Forms.TextBox();
            this.textBox_remote = new System.Windows.Forms.TextBox();
            this.button_enable = new System.Windows.Forms.Button();
            this.button_online = new System.Windows.Forms.Button();
            this.button_remote = new System.Windows.Forms.Button();
            this.richTextBox_Msg = new System.Windows.Forms.RichTextBox();
            this.button_send = new System.Windows.Forms.Button();
            this.timer_commDelay = new System.Windows.Forms.Timer(this.components);
            this.bindingSource_variable = new System.Windows.Forms.BindingSource(this.components);
            this.variableDictionaryTableAdapter = new BasicPanel.VariableDataSetTableAdapters.VariableDictionaryTableAdapter();
            this.bindingSource_collection = new System.Windows.Forms.BindingSource(this.components);
            this.collectionEventTableAdapter = new BasicPanel.VariableDataSetTableAdapters.CollectionEventTableAdapter();
            this.button_parameter = new System.Windows.Forms.Button();
            this.button_close = new System.Windows.Forms.Button();
            this.bindingSource_equipmentConstant = new System.Windows.Forms.BindingSource(this.components);
            this.variableDataSet = new BasicPanel.VariableDataSet();
            this.equipmentConstantTableAdapter = new BasicPanel.VariableDataSetTableAdapters.EquipmentConstantTableAdapter();
            this.timer_S1F13 = new System.Windows.Forms.Timer(this.components);
            this.timer_change = new System.Windows.Forms.Timer(this.components);
            this.button_clear = new System.Windows.Forms.Button();
            this.SECSControl = new AxXPRO_XELib.AxXPRO_XE();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource_variable)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource_collection)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource_equipmentConstant)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.variableDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SECSControl)).BeginInit();
            this.SuspendLayout();
            // 
            // textBox_Connection
            // 
            this.textBox_Connection.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.textBox_Connection.Location = new System.Drawing.Point(178, 43);
            this.textBox_Connection.Name = "textBox_Connection";
            this.textBox_Connection.ReadOnly = true;
            this.textBox_Connection.Size = new System.Drawing.Size(170, 26);
            this.textBox_Connection.TabIndex = 3;
            this.textBox_Connection.Text = "NOT CONNECTED";
            this.textBox_Connection.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox_Control
            // 
            this.textBox_Control.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.textBox_Control.Location = new System.Drawing.Point(178, 81);
            this.textBox_Control.Name = "textBox_Control";
            this.textBox_Control.ReadOnly = true;
            this.textBox_Control.Size = new System.Drawing.Size(170, 26);
            this.textBox_Control.TabIndex = 4;
            this.textBox_Control.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox_enable
            // 
            this.textBox_enable.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.textBox_enable.Location = new System.Drawing.Point(178, 153);
            this.textBox_enable.Name = "textBox_enable";
            this.textBox_enable.ReadOnly = true;
            this.textBox_enable.Size = new System.Drawing.Size(170, 26);
            this.textBox_enable.TabIndex = 5;
            this.textBox_enable.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox_communication
            // 
            this.textBox_communication.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.textBox_communication.Location = new System.Drawing.Point(178, 191);
            this.textBox_communication.Name = "textBox_communication";
            this.textBox_communication.ReadOnly = true;
            this.textBox_communication.Size = new System.Drawing.Size(170, 26);
            this.textBox_communication.TabIndex = 6;
            this.textBox_communication.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox_online
            // 
            this.textBox_online.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.textBox_online.Location = new System.Drawing.Point(178, 263);
            this.textBox_online.Name = "textBox_online";
            this.textBox_online.ReadOnly = true;
            this.textBox_online.Size = new System.Drawing.Size(170, 26);
            this.textBox_online.TabIndex = 7;
            this.textBox_online.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox_remote
            // 
            this.textBox_remote.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.textBox_remote.Location = new System.Drawing.Point(178, 301);
            this.textBox_remote.Name = "textBox_remote";
            this.textBox_remote.ReadOnly = true;
            this.textBox_remote.Size = new System.Drawing.Size(170, 26);
            this.textBox_remote.TabIndex = 8;
            this.textBox_remote.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // button_enable
            // 
            this.button_enable.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.button_enable.Location = new System.Drawing.Point(27, 153);
            this.button_enable.Name = "button_enable";
            this.button_enable.Size = new System.Drawing.Size(120, 26);
            this.button_enable.TabIndex = 9;
            this.button_enable.Text = "Enable";
            this.button_enable.UseVisualStyleBackColor = true;
            this.button_enable.Click += new System.EventHandler(this.button_enable_Click);
            // 
            // button_online
            // 
            this.button_online.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.button_online.Location = new System.Drawing.Point(27, 263);
            this.button_online.Name = "button_online";
            this.button_online.Size = new System.Drawing.Size(120, 26);
            this.button_online.TabIndex = 10;
            this.button_online.Text = "ON-LINE";
            this.button_online.UseVisualStyleBackColor = true;
            this.button_online.Click += new System.EventHandler(this.button_online_Click);
            // 
            // button_remote
            // 
            this.button_remote.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.button_remote.Location = new System.Drawing.Point(27, 300);
            this.button_remote.Name = "button_remote";
            this.button_remote.Size = new System.Drawing.Size(120, 26);
            this.button_remote.TabIndex = 11;
            this.button_remote.Text = "REMOTE";
            this.button_remote.UseVisualStyleBackColor = true;
            this.button_remote.Click += new System.EventHandler(this.button_remote_Click);
            // 
            // richTextBox_Msg
            // 
            this.richTextBox_Msg.Location = new System.Drawing.Point(27, 374);
            this.richTextBox_Msg.MaxLength = 1024;
            this.richTextBox_Msg.Name = "richTextBox_Msg";
            this.richTextBox_Msg.Size = new System.Drawing.Size(321, 76);
            this.richTextBox_Msg.TabIndex = 12;
            this.richTextBox_Msg.Text = "";
            // 
            // button_send
            // 
            this.button_send.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.button_send.Location = new System.Drawing.Point(228, 454);
            this.button_send.Name = "button_send";
            this.button_send.Size = new System.Drawing.Size(120, 26);
            this.button_send.TabIndex = 13;
            this.button_send.Text = "Send";
            this.button_send.UseVisualStyleBackColor = true;
            this.button_send.Click += new System.EventHandler(this.button_send_Click);
            // 
            // timer_commDelay
            // 
            this.timer_commDelay.Tick += new System.EventHandler(this.timer_commDelay_Tick);
            // 
            // variableDictionaryTableAdapter
            // 
            this.variableDictionaryTableAdapter.ClearBeforeFill = true;
            // 
            // collectionEventTableAdapter
            // 
            this.collectionEventTableAdapter.ClearBeforeFill = true;
            // 
            // button_parameter
            // 
            this.button_parameter.Location = new System.Drawing.Point(12, 500);
            this.button_parameter.Name = "button_parameter";
            this.button_parameter.Size = new System.Drawing.Size(116, 35);
            this.button_parameter.TabIndex = 2;
            this.button_parameter.Text = "HSMS Param";
            this.button_parameter.UseVisualStyleBackColor = true;
            this.button_parameter.Click += new System.EventHandler(this.button_parameter_Click);
            // 
            // button_close
            // 
            this.button_close.Location = new System.Drawing.Point(278, 500);
            this.button_close.Name = "button_close";
            this.button_close.Size = new System.Drawing.Size(90, 35);
            this.button_close.TabIndex = 1;
            this.button_close.Text = "Close";
            this.button_close.UseVisualStyleBackColor = true;
            this.button_close.Click += new System.EventHandler(this.button_close_Click);
            // 
            // bindingSource_equipmentConstant
            // 
            this.bindingSource_equipmentConstant.DataMember = "EquipmentConstant";
            this.bindingSource_equipmentConstant.DataSource = this.variableDataSet;
            // 
            // variableDataSet
            // 
            this.variableDataSet.DataSetName = "VariableDataSet";
            this.variableDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // equipmentConstantTableAdapter
            // 
            this.equipmentConstantTableAdapter.ClearBeforeFill = true;
            // 
            // timer_S1F13
            // 
            this.timer_S1F13.Tick += new System.EventHandler(this.timer_S1F13_Tick);
            // 
            // timer_change
            // 
            this.timer_change.Enabled = true;
            this.timer_change.Tick += new System.EventHandler(this.timer_change_Tick);
            // 
            // button_clear
            // 
            this.button_clear.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.button_clear.Location = new System.Drawing.Point(102, 454);
            this.button_clear.Name = "button_clear";
            this.button_clear.Size = new System.Drawing.Size(120, 26);
            this.button_clear.TabIndex = 15;
            this.button_clear.Text = "Clear";
            this.button_clear.UseVisualStyleBackColor = true;
            this.button_clear.Click += new System.EventHandler(this.button_clear_Click);
            // 
            // SECSControl
            // 
            this.SECSControl.Enabled = true;
            this.SECSControl.Location = new System.Drawing.Point(184, 507);
            this.SECSControl.Name = "SECSControl";
            this.SECSControl.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("SECSControl.OcxState")));
            this.SECSControl.Size = new System.Drawing.Size(32, 32);
            this.SECSControl.TabIndex = 16;
            this.SECSControl.OnSelected += new System.EventHandler(this.FACtrl_OnSelected);
            this.SECSControl.OnSecsMsg += new AxXPRO_XELib._DXPRO_XEEvents_OnSecsMsgEventHandler(this.FACtrl_OnSecsMsg);
            this.SECSControl.OnDisconnected += new System.EventHandler(this.FACtrl_OnDisconnected);
            this.SECSControl.OnSecsTimeOut += new AxXPRO_XELib._DXPRO_XEEvents_OnSecsTimeOutEventHandler(this.FACtrl_OnSecsTimeOut);
            // 
            // GEMForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackgroundImage = global::BasicPanel.Properties.Resources.GemForm;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ClientSize = new System.Drawing.Size(380, 550);
            this.ControlBox = false;
            this.Controls.Add(this.SECSControl);
            this.Controls.Add(this.button_clear);
            this.Controls.Add(this.button_send);
            this.Controls.Add(this.richTextBox_Msg);
            this.Controls.Add(this.button_remote);
            this.Controls.Add(this.button_online);
            this.Controls.Add(this.button_enable);
            this.Controls.Add(this.textBox_remote);
            this.Controls.Add(this.textBox_online);
            this.Controls.Add(this.textBox_communication);
            this.Controls.Add(this.textBox_enable);
            this.Controls.Add(this.textBox_Control);
            this.Controls.Add(this.textBox_Connection);
            this.Controls.Add(this.button_parameter);
            this.Controls.Add(this.button_close);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "GEMForm";
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "SECS Communication";
            this.Load += new System.EventHandler(this.GemForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource_variable)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource_collection)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource_equipmentConstant)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.variableDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SECSControl)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button button_close;
		private System.Windows.Forms.Button button_parameter;
		private System.Windows.Forms.TextBox textBox_Connection;
		private System.Windows.Forms.TextBox textBox_Control;
		private System.Windows.Forms.TextBox textBox_enable;
		private System.Windows.Forms.TextBox textBox_communication;
		private System.Windows.Forms.TextBox textBox_online;
		private System.Windows.Forms.TextBox textBox_remote;
		private System.Windows.Forms.Button button_enable;
		private System.Windows.Forms.Button button_online;
		private System.Windows.Forms.Button button_remote;
		private System.Windows.Forms.RichTextBox richTextBox_Msg;
		private System.Windows.Forms.Button button_send;
		private System.Windows.Forms.Timer timer_commDelay;
		private System.Windows.Forms.BindingSource bindingSource_variable;
        private VariableDataSetTableAdapters.VariableDictionaryTableAdapter variableDictionaryTableAdapter;
		private System.Windows.Forms.BindingSource bindingSource_collection;
        private VariableDataSetTableAdapters.CollectionEventTableAdapter collectionEventTableAdapter;
		private System.Windows.Forms.BindingSource bindingSource_equipmentConstant;
        private VariableDataSet variableDataSet;
        private VariableDataSetTableAdapters.EquipmentConstantTableAdapter equipmentConstantTableAdapter;
		private System.Windows.Forms.Timer timer_S1F13;
		private System.Windows.Forms.Timer timer_change;
        private System.Windows.Forms.Button button_clear;
        private AxXPRO_XELib.AxXPRO_XE SECSControl;
	}
}