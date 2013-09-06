namespace BasicPanel
{
    partial class IntroPanel
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(IntroPanel));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.bt_MoveScreen = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(1840, 915);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // bt_MoveScreen
            // 
            this.bt_MoveScreen.BackColor = System.Drawing.SystemColors.HighlightText;
            this.bt_MoveScreen.Font = new System.Drawing.Font("굴림", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.bt_MoveScreen.Location = new System.Drawing.Point(1556, 2);
            this.bt_MoveScreen.Name = "bt_MoveScreen";
            this.bt_MoveScreen.Size = new System.Drawing.Size(286, 71);
            this.bt_MoveScreen.TabIndex = 193;
            this.bt_MoveScreen.Text = "운전 화면";
            this.bt_MoveScreen.UseVisualStyleBackColor = false;
            this.bt_MoveScreen.Visible = false;
            this.bt_MoveScreen.Click += new System.EventHandler(this.bt_MoveScreenbt_Click);
            // 
            // IntroPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1840, 915);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.bt_MoveScreen);
            this.Name = "IntroPanel";
            this.Resolution = IronPanel._Resolution.HD1080;
            this.Text = "IntroPanel";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button bt_MoveScreen;

    }
}