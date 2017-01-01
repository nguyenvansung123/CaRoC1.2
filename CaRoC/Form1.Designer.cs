namespace CaRoC
{
    partial class frmCaro
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
            this.pnBanCo = new System.Windows.Forms.Panel();
            this.tmThongTin = new System.Windows.Forms.Timer(this.components);
            this.pnThongTin = new System.Windows.Forms.Panel();
            this.lblChuoiChu = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.gAMEToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.NguoivsNguoiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.NguoivsMayToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ThoatGameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ThongtinToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.HuongdanToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.prcbCoolDown = new System.Windows.Forms.ProgressBar();
            this.label1 = new System.Windows.Forms.Label();
            this.tmCoolDown = new System.Windows.Forms.Timer(this.components);
            this.timerImages = new System.Windows.Forms.Timer(this.components);
            this.imageGif = new System.Windows.Forms.PictureBox();
            this.pcChoi = new System.Windows.Forms.PictureBox();
            this.pcNhac = new System.Windows.Forms.PictureBox();
            this.pcthoat = new System.Windows.Forms.PictureBox();
            this.ptchoigame = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label_HienThiTen = new System.Windows.Forms.Label();
            this.pnThongTin.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imageGif)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcChoi)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcNhac)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcthoat)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptchoigame)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pnBanCo
            // 
            this.pnBanCo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.pnBanCo.Location = new System.Drawing.Point(277, 64);
            this.pnBanCo.Name = "pnBanCo";
            this.pnBanCo.Size = new System.Drawing.Size(520, 520);
            this.pnBanCo.TabIndex = 1;
            this.pnBanCo.Paint += new System.Windows.Forms.PaintEventHandler(this.pnBanCo_Paint);
            this.pnBanCo.MouseClick += new System.Windows.Forms.MouseEventHandler(this.pnBanCo_MouseClick);
            // 
            // tmThongTin
            // 
            this.tmThongTin.Interval = 25;
            this.tmThongTin.Tick += new System.EventHandler(this.tmThongTin_Tick);
            // 
            // pnThongTin
            // 
            this.pnThongTin.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnThongTin.Controls.Add(this.lblChuoiChu);
            this.pnThongTin.Location = new System.Drawing.Point(12, 438);
            this.pnThongTin.Name = "pnThongTin";
            this.pnThongTin.Size = new System.Drawing.Size(240, 173);
            this.pnThongTin.TabIndex = 7;
            // 
            // lblChuoiChu
            // 
            this.lblChuoiChu.AutoSize = true;
            this.lblChuoiChu.Location = new System.Drawing.Point(4, 199);
            this.lblChuoiChu.Name = "lblChuoiChu";
            this.lblChuoiChu.Size = new System.Drawing.Size(0, 13);
            this.lblChuoiChu.TabIndex = 1;
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.MediumSpringGreen;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.gAMEToolStripMenuItem,
            this.ThongtinToolStripMenuItem,
            this.HuongdanToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(845, 24);
            this.menuStrip1.TabIndex = 9;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // gAMEToolStripMenuItem
            // 
            this.gAMEToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripSeparator1,
            this.NguoivsNguoiToolStripMenuItem,
            this.NguoivsMayToolStripMenuItem,
            this.ThoatGameToolStripMenuItem});
            this.gAMEToolStripMenuItem.Name = "gAMEToolStripMenuItem";
            this.gAMEToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.G)));
            this.gAMEToolStripMenuItem.Size = new System.Drawing.Size(52, 20);
            this.gAMEToolStripMenuItem.Text = "GAME";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(195, 6);
            // 
            // NguoivsNguoiToolStripMenuItem
            // 
            this.NguoivsNguoiToolStripMenuItem.Name = "NguoivsNguoiToolStripMenuItem";
            this.NguoivsNguoiToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Y)));
            this.NguoivsNguoiToolStripMenuItem.Size = new System.Drawing.Size(198, 22);
            this.NguoivsNguoiToolStripMenuItem.Text = "Người vs Người";
            this.NguoivsNguoiToolStripMenuItem.Click += new System.EventHandler(this.NguoivsNguoiToolStripMenuItem_Click);
            // 
            // NguoivsMayToolStripMenuItem
            // 
            this.NguoivsMayToolStripMenuItem.Name = "NguoivsMayToolStripMenuItem";
            this.NguoivsMayToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.P)));
            this.NguoivsMayToolStripMenuItem.Size = new System.Drawing.Size(198, 22);
            this.NguoivsMayToolStripMenuItem.Text = "Người vs Máy";
            this.NguoivsMayToolStripMenuItem.Click += new System.EventHandler(this.NguoivsMayToolStripMenuItem_Click);
            // 
            // ThoatGameToolStripMenuItem
            // 
            this.ThoatGameToolStripMenuItem.Name = "ThoatGameToolStripMenuItem";
            this.ThoatGameToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.Q)));
            this.ThoatGameToolStripMenuItem.Size = new System.Drawing.Size(198, 22);
            this.ThoatGameToolStripMenuItem.Text = "Thoát";
            this.ThoatGameToolStripMenuItem.Click += new System.EventHandler(this.ThoatGameToolStripMenuItem_Click_1);
            // 
            // ThongtinToolStripMenuItem
            // 
            this.ThongtinToolStripMenuItem.ForeColor = System.Drawing.Color.Black;
            this.ThongtinToolStripMenuItem.Name = "ThongtinToolStripMenuItem";
            this.ThongtinToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.I)));
            this.ThongtinToolStripMenuItem.Size = new System.Drawing.Size(83, 20);
            this.ThongtinToolStripMenuItem.Text = "THÔNG TIN";
            this.ThongtinToolStripMenuItem.Click += new System.EventHandler(this.ThongtinToolStripMenuItem_Click);
            // 
            // HuongdanToolStripMenuItem
            // 
            this.HuongdanToolStripMenuItem.Name = "HuongdanToolStripMenuItem";
            this.HuongdanToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.H)));
            this.HuongdanToolStripMenuItem.Size = new System.Drawing.Size(90, 20);
            this.HuongdanToolStripMenuItem.Text = "HƯỚNG DẪN";
            this.HuongdanToolStripMenuItem.Click += new System.EventHandler(this.HuongdanToolStripMenuItem_Click);
            // 
            // prcbCoolDown
            // 
            this.prcbCoolDown.Location = new System.Drawing.Point(383, 9);
            this.prcbCoolDown.Name = "prcbCoolDown";
            this.prcbCoolDown.Size = new System.Drawing.Size(399, 11);
            this.prcbCoolDown.TabIndex = 12;
            this.prcbCoolDown.Click += new System.EventHandler(this.prcbCoolDown_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.MediumSpringGreen;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label1.Location = new System.Drawing.Point(274, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(103, 16);
            this.label1.TabIndex = 13;
            this.label1.Text = "Thời gian còn lại";
            // 
            // tmCoolDown
            // 
            this.tmCoolDown.Tick += new System.EventHandler(this.tmCoolDown_Tick);
            // 
            // timerImages
            // 
            this.timerImages.Interval = 5;
            this.timerImages.Tick += new System.EventHandler(this.timerImages_Tick);
            // 
            // imageGif
            // 
            this.imageGif.Location = new System.Drawing.Point(183, 243);
            this.imageGif.Name = "imageGif";
            this.imageGif.Size = new System.Drawing.Size(79, 50);
            this.imageGif.TabIndex = 14;
            this.imageGif.TabStop = false;
            this.imageGif.Click += new System.EventHandler(this.imageGif_Click);
            // 
            // pcChoi
            // 
            this.pcChoi.Image = global::CaRoC.Properties.Resources.btn_NvsN;
            this.pcChoi.Location = new System.Drawing.Point(1, 243);
            this.pcChoi.Name = "pcChoi";
            this.pcChoi.Size = new System.Drawing.Size(160, 72);
            this.pcChoi.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pcChoi.TabIndex = 11;
            this.pcChoi.TabStop = false;
            this.pcChoi.Click += new System.EventHandler(this.pcChoi_Click);
            this.pcChoi.MouseLeave += new System.EventHandler(this.NvsN_ReChuotRa);
            this.pcChoi.MouseMove += new System.Windows.Forms.MouseEventHandler(this.NvsN_ReChuotVao);
            // 
            // pcNhac
            // 
            this.pcNhac.BackColor = System.Drawing.Color.Transparent;
            this.pcNhac.BackgroundImage = global::CaRoC.Properties.Resources.btnOnMusic;
            this.pcNhac.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pcNhac.Location = new System.Drawing.Point(178, 165);
            this.pcNhac.Name = "pcNhac";
            this.pcNhac.Size = new System.Drawing.Size(74, 69);
            this.pcNhac.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pcNhac.TabIndex = 10;
            this.pcNhac.TabStop = false;
            this.pcNhac.Click += new System.EventHandler(this.pcNhac_Click);
            // 
            // pcthoat
            // 
            this.pcthoat.Image = global::CaRoC.Properties.Resources.btn_ThoatGame;
            this.pcthoat.Location = new System.Drawing.Point(1, 321);
            this.pcthoat.Name = "pcthoat";
            this.pcthoat.Size = new System.Drawing.Size(160, 72);
            this.pcthoat.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pcthoat.TabIndex = 0;
            this.pcthoat.TabStop = false;
            this.pcthoat.Click += new System.EventHandler(this.pcthoat_Click);
            this.pcthoat.MouseLeave += new System.EventHandler(this.ThoatGame_ReChuotRa);
            this.pcthoat.MouseMove += new System.Windows.Forms.MouseEventHandler(this.ThoatGame_ReChuotVao);
            // 
            // ptchoigame
            // 
            this.ptchoigame.Image = global::CaRoC.Properties.Resources.btn_NvsM;
            this.ptchoigame.Location = new System.Drawing.Point(1, 165);
            this.ptchoigame.Name = "ptchoigame";
            this.ptchoigame.Size = new System.Drawing.Size(160, 72);
            this.ptchoigame.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.ptchoigame.TabIndex = 0;
            this.ptchoigame.TabStop = false;
            this.ptchoigame.Click += new System.EventHandler(this.ptchoigame_Click);
            this.ptchoigame.MouseLeave += new System.EventHandler(this.NvsM_ReChuotRa);
            this.ptchoigame.MouseMove += new System.Windows.Forms.MouseEventHandler(this.NvsM_ReChuotVao);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::CaRoC.Properties.Resources.Untitled_1;
            this.pictureBox1.Location = new System.Drawing.Point(1, 26);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(255, 133);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 8;
            this.pictureBox1.TabStop = false;
            // 
            // label_HienThiTen
            // 
            this.label_HienThiTen.AutoSize = true;
            this.label_HienThiTen.Font = new System.Drawing.Font("Broadway", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_HienThiTen.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.label_HienThiTen.Location = new System.Drawing.Point(426, 25);
            this.label_HienThiTen.Name = "label_HienThiTen";
            this.label_HienThiTen.Size = new System.Drawing.Size(0, 36);
            this.label_HienThiTen.TabIndex = 15;
            // 
            // frmCaro
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(845, 623);
            this.Controls.Add(this.label_HienThiTen);
            this.Controls.Add(this.imageGif);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.prcbCoolDown);
            this.Controls.Add(this.pcChoi);
            this.Controls.Add(this.pcNhac);
            this.Controls.Add(this.pcthoat);
            this.Controls.Add(this.ptchoigame);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.pnThongTin);
            this.Controls.Add(this.pnBanCo);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "frmCaro";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CaRo_AI";
            this.Load += new System.EventHandler(this.frmCaro_Load);
            this.pnThongTin.ResumeLayout(false);
            this.pnThongTin.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imageGif)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcChoi)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcNhac)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcthoat)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptchoigame)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Panel pnBanCo;
        private System.Windows.Forms.Timer tmThongTin;
        private System.Windows.Forms.Panel pnThongTin;
        private System.Windows.Forms.Label lblChuoiChu;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem gAMEToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ThongtinToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem HuongdanToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ThoatGameToolStripMenuItem;
        private System.Windows.Forms.PictureBox ptchoigame;
        private System.Windows.Forms.PictureBox pcthoat;
        private System.Windows.Forms.PictureBox pcNhac;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.PictureBox pcChoi;
        private System.Windows.Forms.ProgressBar prcbCoolDown;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Timer tmCoolDown;
        private System.Windows.Forms.Timer timerImages;
        private System.Windows.Forms.PictureBox imageGif;
        private System.Windows.Forms.ToolStripMenuItem NguoivsNguoiToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem NguoivsMayToolStripMenuItem;
        private System.Windows.Forms.Label label_HienThiTen;
    }
}

