namespace BasicPanel
{
    partial class TestControl
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TestControl));
            this.imageButton1 = new InputControls.ImageButton();
            this.navigationPanel1 = new BasicPanel.NavigationPanel();
            this.SuspendLayout();
            // 
            // imageButton1
            // 
            this.imageButton1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.imageButton1.DisableImage = global::BasicPanel.Properties.Resources.Alarm_disable;
            this.imageButton1.EnableImage = global::BasicPanel.Properties.Resources.Alarm_enable;
            this.imageButton1.FocusImage = global::BasicPanel.Properties.Resources.Alarm_press;
            this.imageButton1.Location = new System.Drawing.Point(259, 3);
            this.imageButton1.Name = "imageButton1";
            this.imageButton1.PressImage = null;
            this.imageButton1.PushState = false;
            this.imageButton1.Size = new System.Drawing.Size(141, 72);
            this.imageButton1.TabIndex = 2;
            this.imageButton1.Text = "imageButton1";
            this.imageButton1.Use = false;
            // 
            // navigationPanel1
            // 
            this.navigationPanel1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("navigationPanel1.BackgroundImage")));
            this.navigationPanel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.navigationPanel1.ButtonCount = 0;
            this.navigationPanel1.Location = new System.Drawing.Point(0, 0);
            this.navigationPanel1.Name = "navigationPanel1";
            this.navigationPanel1.ProjectPath = "C:\\IronTools";
            this.navigationPanel1.Resolution = IronPanel._Resolution.SXGA;
            this.navigationPanel1.SelectedIndex = -1;
            this.navigationPanel1.Size = new System.Drawing.Size(1280, 77);
            this.navigationPanel1.TabIndex = 0;
            this.navigationPanel1.UseQuitButton = true;
            // 
            // TestControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.imageButton1);
            this.Controls.Add(this.navigationPanel1);
            this.Name = "TestControl";
            this.ResumeLayout(false);

        }

        #endregion

        private NavigationPanel navigationPanel1;
        private InputControls.ImageButton imageButton1;
    }
}
