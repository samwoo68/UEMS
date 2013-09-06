namespace BasicPanel
{
    partial class HostControl
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
            this.label_communication = new System.Windows.Forms.Label();
            this.label_online = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label_communication
            // 
            this.label_communication.AutoEllipsis = true;
            this.label_communication.BackColor = System.Drawing.Color.Transparent;
            this.label_communication.Font = new System.Drawing.Font("Arial Narrow", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_communication.Location = new System.Drawing.Point(8, 47);
            this.label_communication.Name = "label_communication";
            this.label_communication.Size = new System.Drawing.Size(109, 16);
            this.label_communication.TabIndex = 5;
            this.label_communication.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label_online
            // 
            this.label_online.AutoEllipsis = true;
            this.label_online.BackColor = System.Drawing.Color.Transparent;
            this.label_online.Font = new System.Drawing.Font("Arial Narrow", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_online.Location = new System.Drawing.Point(112, 47);
            this.label_online.Name = "label_online";
            this.label_online.Size = new System.Drawing.Size(91, 16);
            this.label_online.TabIndex = 4;
            this.label_online.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // HostControl
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.Transparent;
            this.BackgroundImage = global::BasicPanel.Properties.Resources.HostCommDisconn_disable;
            this.Controls.Add(this.label_communication);
            this.Controls.Add(this.label_online);
            this.DoubleBuffered = true;
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "HostControl";
            this.Size = new System.Drawing.Size(213, 72);
            this.Click += new System.EventHandler(this.HostButton_Click);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.HostButton_MouseDown);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.HostButton_MouseUp);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label_communication;
        private System.Windows.Forms.Label label_online;
    }
}
