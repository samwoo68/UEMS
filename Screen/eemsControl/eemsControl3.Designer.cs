namespace eemsControl
{
    partial class eemsControl3
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(eemsControl3));
            this.timer_image_rotation = new System.Windows.Forms.Timer(this.components);
            this.pB_burner3 = new System.Windows.Forms.PictureBox();
            this.pB_burner2 = new System.Windows.Forms.PictureBox();
            this.pB_burner1 = new System.Windows.Forms.PictureBox();
            this.pB_furnace = new System.Windows.Forms.PictureBox();
            this.pB_heater1_off = new System.Windows.Forms.PictureBox();
            this.pB_bubbler = new System.Windows.Forms.PictureBox();
            this.pB_heater2_off = new System.Windows.Forms.PictureBox();
            this.pB_heater3_off = new System.Windows.Forms.PictureBox();
            this.pB_heater4_off = new System.Windows.Forms.PictureBox();
            this.pB_heater1 = new System.Windows.Forms.PictureBox();
            this.pB_heater2 = new System.Windows.Forms.PictureBox();
            this.pB_heater3 = new System.Windows.Forms.PictureBox();
            this.pB_heater4 = new System.Windows.Forms.PictureBox();
            this.pB_furnace1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pB_burner3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pB_burner2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pB_burner1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pB_furnace)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pB_heater1_off)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pB_bubbler)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pB_heater2_off)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pB_heater3_off)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pB_heater4_off)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pB_heater1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pB_heater2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pB_heater3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pB_heater4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pB_furnace1)).BeginInit();
            this.SuspendLayout();
            // 
            // timer_image_rotation
            // 
            this.timer_image_rotation.Interval = 500;
            this.timer_image_rotation.Tick += new System.EventHandler(this.timer_image_rotation_Tick);
            // 
            // pB_burner3
            // 
            this.pB_burner3.Image = global::eemsControl.Properties.Resources.불꽃2_아래로;
            this.pB_burner3.Location = new System.Drawing.Point(465, 213);
            this.pB_burner3.Name = "pB_burner3";
            this.pB_burner3.Size = new System.Drawing.Size(48, 122);
            this.pB_burner3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pB_burner3.TabIndex = 0;
            this.pB_burner3.TabStop = false;
            // 
            // pB_burner2
            // 
            this.pB_burner2.Image = global::eemsControl.Properties.Resources.불꽃2_아래로;
            this.pB_burner2.Location = new System.Drawing.Point(419, 213);
            this.pB_burner2.Name = "pB_burner2";
            this.pB_burner2.Size = new System.Drawing.Size(50, 128);
            this.pB_burner2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pB_burner2.TabIndex = 1;
            this.pB_burner2.TabStop = false;
            // 
            // pB_burner1
            // 
            this.pB_burner1.Image = global::eemsControl.Properties.Resources.불꽃1;
            this.pB_burner1.Location = new System.Drawing.Point(335, 279);
            this.pB_burner1.Name = "pB_burner1";
            this.pB_burner1.Size = new System.Drawing.Size(65, 60);
            this.pB_burner1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pB_burner1.TabIndex = 2;
            this.pB_burner1.TabStop = false;
            // 
            // pB_furnace
            // 
            this.pB_furnace.Image = global::eemsControl.Properties.Resources.투명이미지_용광로_기준레벨_프레임함께;
            this.pB_furnace.Location = new System.Drawing.Point(25, 353);
            this.pB_furnace.Name = "pB_furnace";
            this.pB_furnace.Size = new System.Drawing.Size(351, 89);
            this.pB_furnace.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pB_furnace.TabIndex = 3;
            this.pB_furnace.TabStop = false;
            // 
            // pB_heater1_off
            // 
            this.pB_heater1_off.Image = ((System.Drawing.Image)(resources.GetObject("pB_heater1_off.Image")));
            this.pB_heater1_off.Location = new System.Drawing.Point(51, 321);
            this.pB_heater1_off.Name = "pB_heater1_off";
            this.pB_heater1_off.Size = new System.Drawing.Size(24, 100);
            this.pB_heater1_off.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pB_heater1_off.TabIndex = 4;
            this.pB_heater1_off.TabStop = false;
            // 
            // pB_bubbler
            // 
            this.pB_bubbler.Image = global::eemsControl.Properties.Resources.투명이지미_버블러_온_그린;
            this.pB_bubbler.Location = new System.Drawing.Point(296, 400);
            this.pB_bubbler.Name = "pB_bubbler";
            this.pB_bubbler.Size = new System.Drawing.Size(25, 73);
            this.pB_bubbler.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pB_bubbler.TabIndex = 8;
            this.pB_bubbler.TabStop = false;
            // 
            // pB_heater2_off
            // 
            this.pB_heater2_off.Image = ((System.Drawing.Image)(resources.GetObject("pB_heater2_off.Image")));
            this.pB_heater2_off.Location = new System.Drawing.Point(95, 321);
            this.pB_heater2_off.Name = "pB_heater2_off";
            this.pB_heater2_off.Size = new System.Drawing.Size(24, 100);
            this.pB_heater2_off.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pB_heater2_off.TabIndex = 9;
            this.pB_heater2_off.TabStop = false;
            // 
            // pB_heater3_off
            // 
            this.pB_heater3_off.Image = ((System.Drawing.Image)(resources.GetObject("pB_heater3_off.Image")));
            this.pB_heater3_off.Location = new System.Drawing.Point(137, 321);
            this.pB_heater3_off.Name = "pB_heater3_off";
            this.pB_heater3_off.Size = new System.Drawing.Size(24, 100);
            this.pB_heater3_off.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pB_heater3_off.TabIndex = 10;
            this.pB_heater3_off.TabStop = false;
            // 
            // pB_heater4_off
            // 
            this.pB_heater4_off.Image = ((System.Drawing.Image)(resources.GetObject("pB_heater4_off.Image")));
            this.pB_heater4_off.Location = new System.Drawing.Point(161, 200);
            this.pB_heater4_off.Name = "pB_heater4_off";
            this.pB_heater4_off.Size = new System.Drawing.Size(24, 100);
            this.pB_heater4_off.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pB_heater4_off.TabIndex = 11;
            this.pB_heater4_off.TabStop = false;
            this.pB_heater4_off.Visible = false;
            // 
            // pB_heater1
            // 
            this.pB_heater1.Image = global::eemsControl.Properties.Resources.투명이미지_히터온;
            this.pB_heater1.Location = new System.Drawing.Point(51, 321);
            this.pB_heater1.Name = "pB_heater1";
            this.pB_heater1.Size = new System.Drawing.Size(24, 100);
            this.pB_heater1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pB_heater1.TabIndex = 12;
            this.pB_heater1.TabStop = false;
            this.pB_heater1.Visible = false;
            // 
            // pB_heater2
            // 
            this.pB_heater2.Image = global::eemsControl.Properties.Resources.투명이미지_히터온;
            this.pB_heater2.Location = new System.Drawing.Point(95, 321);
            this.pB_heater2.Name = "pB_heater2";
            this.pB_heater2.Size = new System.Drawing.Size(24, 100);
            this.pB_heater2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pB_heater2.TabIndex = 13;
            this.pB_heater2.TabStop = false;
            this.pB_heater2.Visible = false;
            // 
            // pB_heater3
            // 
            this.pB_heater3.Image = global::eemsControl.Properties.Resources.투명이미지_히터온;
            this.pB_heater3.Location = new System.Drawing.Point(137, 321);
            this.pB_heater3.Name = "pB_heater3";
            this.pB_heater3.Size = new System.Drawing.Size(24, 100);
            this.pB_heater3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pB_heater3.TabIndex = 14;
            this.pB_heater3.TabStop = false;
            this.pB_heater3.Visible = false;
            // 
            // pB_heater4
            // 
            this.pB_heater4.Image = global::eemsControl.Properties.Resources.투명이미지_히터온;
            this.pB_heater4.Location = new System.Drawing.Point(161, 200);
            this.pB_heater4.Name = "pB_heater4";
            this.pB_heater4.Size = new System.Drawing.Size(24, 100);
            this.pB_heater4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pB_heater4.TabIndex = 15;
            this.pB_heater4.TabStop = false;
            this.pB_heater4.Visible = false;
            // 
            // pB_furnace1
            // 
            this.pB_furnace1.Image = global::eemsControl.Properties.Resources.투명이미지_용광로_풀레벨_프레임함께;
            this.pB_furnace1.Location = new System.Drawing.Point(25, 353);
            this.pB_furnace1.Name = "pB_furnace1";
            this.pB_furnace1.Size = new System.Drawing.Size(354, 89);
            this.pB_furnace1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pB_furnace1.TabIndex = 17;
            this.pB_furnace1.TabStop = false;
            // 
            // eemsControl3
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.Transparent;
            this.BackgroundImage = global::eemsControl.Properties.Resources.투명이미지_용광로_비어있고_타워포함;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Controls.Add(this.pB_heater3);
            this.Controls.Add(this.pB_heater2);
            this.Controls.Add(this.pB_heater1);
            this.Controls.Add(this.pB_heater3_off);
            this.Controls.Add(this.pB_heater2_off);
            this.Controls.Add(this.pB_heater1_off);
            this.Controls.Add(this.pB_bubbler);
            this.Controls.Add(this.pB_furnace1);
            this.Controls.Add(this.pB_heater4);
            this.Controls.Add(this.pB_heater4_off);
            this.Controls.Add(this.pB_furnace);
            this.Controls.Add(this.pB_burner1);
            this.Controls.Add(this.pB_burner2);
            this.Controls.Add(this.pB_burner3);
            this.DoubleBuffered = true;
            this.Name = "eemsControl3";
            this.Size = new System.Drawing.Size(613, 473);
            ((System.ComponentModel.ISupportInitialize)(this.pB_burner3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pB_burner2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pB_burner1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pB_furnace)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pB_heater1_off)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pB_bubbler)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pB_heater2_off)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pB_heater3_off)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pB_heater4_off)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pB_heater1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pB_heater2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pB_heater3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pB_heater4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pB_furnace1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer timer_image_rotation;
        private System.Windows.Forms.PictureBox pB_burner3;
        private System.Windows.Forms.PictureBox pB_burner2;
        private System.Windows.Forms.PictureBox pB_burner1;
        private System.Windows.Forms.PictureBox pB_furnace;
        private System.Windows.Forms.PictureBox pB_heater1_off;
        private System.Windows.Forms.PictureBox pB_bubbler;
        private System.Windows.Forms.PictureBox pB_heater2_off;
        private System.Windows.Forms.PictureBox pB_heater3_off;
        private System.Windows.Forms.PictureBox pB_heater4_off;
        private System.Windows.Forms.PictureBox pB_heater1;
        private System.Windows.Forms.PictureBox pB_heater2;
        private System.Windows.Forms.PictureBox pB_heater3;
        private System.Windows.Forms.PictureBox pB_heater4;
        private System.Windows.Forms.PictureBox pB_furnace1;
    }
}
