namespace BasicPanel
{
    partial class EquipStatusControl
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
            this.timer_blink = new System.Windows.Forms.Timer(this.components);
            this.label_status = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // timer_blink
            // 
            this.timer_blink.Interval = 500;
            this.timer_blink.Tick += new System.EventHandler(this.timer_blink_Tick);
            // 
            // label_status
            // 
            this.label_status.BackColor = System.Drawing.Color.Transparent;
            this.label_status.Font = new System.Drawing.Font("Arial", 9F);
            this.label_status.Location = new System.Drawing.Point(9, 48);
            this.label_status.Name = "label_status";
            this.label_status.Size = new System.Drawing.Size(141, 16);
            this.label_status.TabIndex = 6;
            this.label_status.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // EquipStatusControl
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.Transparent;
            this.BackgroundImage = global::BasicPanel.Properties.Resources.EquipStatus_disable;
            this.Controls.Add(this.label_status);
            this.DoubleBuffered = true;
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "EquipStatusControl";
            this.Size = new System.Drawing.Size(162, 72);
            this.Click += new System.EventHandler(this.StatusButton_Click);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.StatusButton_MouseDown);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.StatusButton_MouseUp);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer timer_blink;
        private System.Windows.Forms.Label label_status;
    }
}
