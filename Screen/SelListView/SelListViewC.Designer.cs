namespace SelListView
{
    partial class SelListViewC
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
            this.listView1 = new System.Windows.Forms.ListView();
            this.att_panel = new System.Windows.Forms.Panel();
            this.bt_Load = new System.Windows.Forms.Button();
            this.OK_Panel = new System.Windows.Forms.Panel();
            this.C_bt = new System.Windows.Forms.Button();
            this.OK_Panel.SuspendLayout();
            this.SuspendLayout();
            // 
            // listView1
            // 
            this.listView1.AllowColumnReorder = true;
            this.listView1.AllowDrop = true;
            this.listView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listView1.Font = new System.Drawing.Font("굴림", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.listView1.FullRowSelect = true;
            this.listView1.GridLines = true;
            this.listView1.Location = new System.Drawing.Point(0, 0);
            this.listView1.Name = "listView1";
            this.listView1.ShowGroups = false;
            this.listView1.ShowItemToolTips = true;
            this.listView1.Size = new System.Drawing.Size(877, 523);
            this.listView1.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.listView1.TabIndex = 124;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            this.listView1.DrawColumnHeader += new System.Windows.Forms.DrawListViewColumnHeaderEventHandler(this.listView1_DrawColumnHeader);
            // 
            // att_panel
            // 
            this.att_panel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.att_panel.AutoScroll = true;
            this.att_panel.BackgroundImage = global::SelListView.Properties.Resources.이미지_바탕배경;
            this.att_panel.Location = new System.Drawing.Point(1, 0);
            this.att_panel.Name = "att_panel";
            this.att_panel.Size = new System.Drawing.Size(216, 458);
            this.att_panel.TabIndex = 125;
            this.att_panel.Visible = false;
            // 
            // bt_Load
            // 
            this.bt_Load.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.bt_Load.BackColor = System.Drawing.Color.Transparent;
            this.bt_Load.Font = new System.Drawing.Font("굴림", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.bt_Load.ForeColor = System.Drawing.Color.Blue;
            this.bt_Load.Location = new System.Drawing.Point(5, 10);
            this.bt_Load.Name = "bt_Load";
            this.bt_Load.Size = new System.Drawing.Size(104, 43);
            this.bt_Load.TabIndex = 3;
            this.bt_Load.Text = "&데이타 선택";
            this.bt_Load.UseVisualStyleBackColor = false;
            this.bt_Load.Click += new System.EventHandler(this.bt_Load_Click);
            // 
            // OK_Panel
            // 
            this.OK_Panel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.OK_Panel.AutoScroll = true;
            this.OK_Panel.BackgroundImage = global::SelListView.Properties.Resources.이미지_바탕배경;
            this.OK_Panel.Controls.Add(this.C_bt);
            this.OK_Panel.Controls.Add(this.bt_Load);
            this.OK_Panel.Location = new System.Drawing.Point(0, 458);
            this.OK_Panel.Name = "OK_Panel";
            this.OK_Panel.Size = new System.Drawing.Size(216, 65);
            this.OK_Panel.TabIndex = 126;
            this.OK_Panel.Visible = false;
            // 
            // C_bt
            // 
            this.C_bt.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.C_bt.BackColor = System.Drawing.Color.Transparent;
            this.C_bt.Font = new System.Drawing.Font("굴림", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.C_bt.ForeColor = System.Drawing.Color.Blue;
            this.C_bt.Location = new System.Drawing.Point(109, 10);
            this.C_bt.Name = "C_bt";
            this.C_bt.Size = new System.Drawing.Size(104, 43);
            this.C_bt.TabIndex = 4;
            this.C_bt.Text = "&취   소";
            this.C_bt.UseVisualStyleBackColor = false;
            this.C_bt.Click += new System.EventHandler(this.C_bt_Click);
            // 
            // SelListViewC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.OK_Panel);
            this.Controls.Add(this.att_panel);
            this.Controls.Add(this.listView1);
            this.Name = "SelListViewC";
            this.Size = new System.Drawing.Size(877, 523);
            this.OK_Panel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.Panel att_panel;
        private System.Windows.Forms.Button bt_Load;
        private System.Windows.Forms.Panel OK_Panel;
        private System.Windows.Forms.Button C_bt;
    }
}
