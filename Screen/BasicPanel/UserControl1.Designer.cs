namespace BasicPanel
{
    partial class UserControl1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UserControl1));
            this.equipStatusControl1 = new BasicPanel.EquipStatusControl();
            this.hostControl1 = new BasicPanel.HostControl();
            this.SuspendLayout();
            // 
            // equipStatusControl1
            // 
            this.equipStatusControl1.AlarmStatus = false;
            this.equipStatusControl1.BackColor = System.Drawing.Color.Transparent;
            this.equipStatusControl1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("equipStatusControl1.BackgroundImage")));
            this.equipStatusControl1.ButtonEnabled = false;
            this.equipStatusControl1.EquipStatus = "";
            this.equipStatusControl1.Location = new System.Drawing.Point(169, 16);
            this.equipStatusControl1.Margin = new System.Windows.Forms.Padding(0);
            this.equipStatusControl1.Name = "equipStatusControl1";
            this.equipStatusControl1.Size = new System.Drawing.Size(162, 72);
            this.equipStatusControl1.TabIndex = 0;
            // 
            // hostControl1
            // 
            this.hostControl1.BackColor = System.Drawing.Color.Transparent;
            this.hostControl1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("hostControl1.BackgroundImage")));
            this.hostControl1.ButtonEnabled = false;
            this.hostControl1.Communication = "";
            this.hostControl1.Connection = false;
            this.hostControl1.Control = "";
            this.hostControl1.Location = new System.Drawing.Point(936, 16);
            this.hostControl1.Margin = new System.Windows.Forms.Padding(0);
            this.hostControl1.Name = "hostControl1";
            this.hostControl1.Size = new System.Drawing.Size(213, 72);
            this.hostControl1.TabIndex = 1;
            // 
            // UserControl1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.hostControl1);
            this.Controls.Add(this.equipStatusControl1);
            this.Name = "UserControl1";
            this.ResumeLayout(false);

        }

        #endregion

        private EquipStatusControl equipStatusControl1;
        private HostControl hostControl1;
    }
}
