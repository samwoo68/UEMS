namespace TLV_OBJ
{
    partial class TLV_UC
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
            this.DTLV = new BrightIdeasSoftware.DataTreeListView();
            ((System.ComponentModel.ISupportInitialize)(this.DTLV)).BeginInit();
            this.SuspendLayout();
            // 
            // DTLV
            // 
            this.DTLV.CheckBoxes = true;
            this.DTLV.DataSource = null;
            this.DTLV.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DTLV.FullRowSelect = true;
            this.DTLV.GridLines = true;
            this.DTLV.HeaderUsesThemes = false;
            this.DTLV.HideSelection = false;
            this.DTLV.KeyAspectName = "Id";
            this.DTLV.Location = new System.Drawing.Point(0, 0);
            this.DTLV.Name = "DTLV";
            this.DTLV.OwnerDraw = true;
            this.DTLV.ParentKeyAspectName = "PId";
            this.DTLV.PersistentCheckBoxes = false;
            this.DTLV.RootKeyValueString = "";
            this.DTLV.ShowGroups = false;
            this.DTLV.ShowImagesOnSubItems = true;
            this.DTLV.ShowKeyColumns = false;
            this.DTLV.Size = new System.Drawing.Size(864, 539);
            this.DTLV.TabIndex = 254;
            this.DTLV.UseCompatibleStateImageBehavior = false;
            this.DTLV.UseFilterIndicator = true;
            this.DTLV.UseFiltering = true;
            this.DTLV.View = System.Windows.Forms.View.Details;
            this.DTLV.VirtualMode = true;
            // 
            // TLV_UC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.DTLV);
            this.Name = "TLV_UC";
            this.Size = new System.Drawing.Size(864, 539);
            ((System.ComponentModel.ISupportInitialize)(this.DTLV)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private BrightIdeasSoftware.DataTreeListView DTLV;
    }
}
