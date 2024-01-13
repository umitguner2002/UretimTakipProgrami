using System.Drawing;

namespace UretimTakipProgrami
{
    partial class FrmLogin
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmLogin));
            btnGiris = new Button();
            txtKullaniciAdi = new TextBox();
            label1 = new Label();
            txtSifre = new TextBox();
            label2 = new Label();
            label3 = new Label();
            btnIptal = new Button();
            panel1 = new Panel();
            label4 = new Label();
            pictureBox1 = new PictureBox();
            panel2 = new Panel();
            ıconPictureBox2 = new FontAwesome.Sharp.IconPictureBox();
            ıconPictureBox3 = new FontAwesome.Sharp.IconPictureBox();
            ıconPictureBox1 = new FontAwesome.Sharp.IconPictureBox();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)ıconPictureBox2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)ıconPictureBox3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)ıconPictureBox1).BeginInit();
            SuspendLayout();
            // 
            // btnGiris
            // 
            btnGiris.BackColor = Color.FromArgb(66, 115, 29);
            btnGiris.FlatAppearance.BorderColor = Color.SteelBlue;
            btnGiris.FlatAppearance.BorderSize = 0;
            btnGiris.FlatStyle = FlatStyle.Flat;
            btnGiris.Font = new Font("Tahoma", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            btnGiris.ForeColor = Color.Transparent;
            btnGiris.Location = new Point(49, 281);
            btnGiris.Margin = new Padding(4, 3, 4, 3);
            btnGiris.Name = "btnGiris";
            btnGiris.Size = new Size(279, 40);
            btnGiris.TabIndex = 0;
            btnGiris.Text = "Giriş";
            btnGiris.UseVisualStyleBackColor = false;
            btnGiris.Click += btnGiris_Click;
            // 
            // txtKullaniciAdi
            // 
            txtKullaniciAdi.BorderStyle = BorderStyle.FixedSingle;
            txtKullaniciAdi.Cursor = Cursors.IBeam;
            txtKullaniciAdi.Font = new Font("Tahoma", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            txtKullaniciAdi.Location = new Point(49, 171);
            txtKullaniciAdi.Margin = new Padding(4, 3, 4, 3);
            txtKullaniciAdi.Name = "txtKullaniciAdi";
            txtKullaniciAdi.Size = new Size(280, 23);
            txtKullaniciAdi.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Tahoma", 18F, FontStyle.Regular, GraphicsUnit.Point);
            label1.ForeColor = Color.White;
            label1.Location = new Point(84, 328);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(173, 29);
            label1.TabIndex = 2;
            label1.Text = "Takip Programı";
            // 
            // txtSifre
            // 
            txtSifre.Font = new Font("Tahoma", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            txtSifre.Location = new Point(49, 231);
            txtSifre.Margin = new Padding(4, 3, 4, 3);
            txtSifre.Name = "txtSifre";
            txtSifre.Size = new Size(279, 23);
            txtSifre.TabIndex = 1;
            txtSifre.UseSystemPasswordChar = true;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Tahoma", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            label2.ForeColor = Color.DarkBlue;
            label2.Location = new Point(49, 152);
            label2.Margin = new Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new Size(75, 16);
            label2.TabIndex = 3;
            label2.Text = "Kullanıcı Adı";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Tahoma", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            label3.ForeColor = Color.DarkBlue;
            label3.Location = new Point(49, 212);
            label3.Margin = new Padding(4, 0, 4, 0);
            label3.Name = "label3";
            label3.Size = new Size(34, 16);
            label3.TabIndex = 3;
            label3.Text = "Şifre";
            // 
            // btnIptal
            // 
            btnIptal.BackColor = Color.FromArgb(59, 113, 202);
            btnIptal.FlatAppearance.BorderColor = Color.SteelBlue;
            btnIptal.FlatAppearance.BorderSize = 0;
            btnIptal.FlatStyle = FlatStyle.Flat;
            btnIptal.Font = new Font("Tahoma", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            btnIptal.ForeColor = Color.Transparent;
            btnIptal.Location = new Point(49, 328);
            btnIptal.Margin = new Padding(4, 3, 4, 3);
            btnIptal.Name = "btnIptal";
            btnIptal.Size = new Size(279, 40);
            btnIptal.TabIndex = 0;
            btnIptal.Text = "İptal";
            btnIptal.UseVisualStyleBackColor = false;
            btnIptal.Click += btnIptal_Click;
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(31, 30, 68);
            panel1.Controls.Add(label4);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(pictureBox1);
            panel1.Dock = DockStyle.Left;
            panel1.Location = new Point(0, 0);
            panel1.Margin = new Padding(4, 3, 4, 3);
            panel1.Name = "panel1";
            panel1.Size = new Size(341, 396);
            panel1.TabIndex = 4;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Tahoma", 18F, FontStyle.Regular, GraphicsUnit.Point);
            label4.ForeColor = Color.White;
            label4.Location = new Point(60, 292);
            label4.Margin = new Padding(4, 0, 4, 0);
            label4.Name = "label4";
            label4.Size = new Size(221, 29);
            label4.TabIndex = 2;
            label4.Text = "CNC Tezgah Üretim";
            // 
            // pictureBox1
            // 
            pictureBox1.BorderStyle = BorderStyle.FixedSingle;
            pictureBox1.Dock = DockStyle.Top;
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(0, 0);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(341, 256);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 3;
            pictureBox1.TabStop = false;
            // 
            // panel2
            // 
            panel2.BackColor = Color.FromArgb(192, 210, 235);
            panel2.Controls.Add(label3);
            panel2.Controls.Add(btnGiris);
            panel2.Controls.Add(label2);
            panel2.Controls.Add(btnIptal);
            panel2.Controls.Add(txtKullaniciAdi);
            panel2.Controls.Add(txtSifre);
            panel2.Controls.Add(ıconPictureBox2);
            panel2.Controls.Add(ıconPictureBox3);
            panel2.Controls.Add(ıconPictureBox1);
            panel2.Dock = DockStyle.Fill;
            panel2.Location = new Point(341, 0);
            panel2.Margin = new Padding(4, 3, 4, 3);
            panel2.Name = "panel2";
            panel2.Size = new Size(349, 396);
            panel2.TabIndex = 4;
            // 
            // ıconPictureBox2
            // 
            ıconPictureBox2.BackColor = Color.FromArgb(192, 210, 235);
            ıconPictureBox2.ForeColor = Color.DarkBlue;
            ıconPictureBox2.IconChar = FontAwesome.Sharp.IconChar.Key;
            ıconPictureBox2.IconColor = Color.DarkBlue;
            ıconPictureBox2.IconFont = FontAwesome.Sharp.IconFont.Auto;
            ıconPictureBox2.IconSize = 25;
            ıconPictureBox2.Location = new Point(22, 231);
            ıconPictureBox2.Name = "ıconPictureBox2";
            ıconPictureBox2.Size = new Size(25, 25);
            ıconPictureBox2.TabIndex = 4;
            ıconPictureBox2.TabStop = false;
            // 
            // ıconPictureBox3
            // 
            ıconPictureBox3.BackColor = Color.FromArgb(192, 210, 235);
            ıconPictureBox3.BackgroundImageLayout = ImageLayout.Center;
            ıconPictureBox3.ForeColor = Color.SteelBlue;
            ıconPictureBox3.IconChar = FontAwesome.Sharp.IconChar.UserLock;
            ıconPictureBox3.IconColor = Color.SteelBlue;
            ıconPictureBox3.IconFont = FontAwesome.Sharp.IconFont.Auto;
            ıconPictureBox3.IconSize = 80;
            ıconPictureBox3.Location = new Point(138, 46);
            ıconPictureBox3.Name = "ıconPictureBox3";
            ıconPictureBox3.Size = new Size(80, 80);
            ıconPictureBox3.TabIndex = 4;
            ıconPictureBox3.TabStop = false;
            // 
            // ıconPictureBox1
            // 
            ıconPictureBox1.BackColor = Color.FromArgb(192, 210, 235);
            ıconPictureBox1.ForeColor = Color.DarkBlue;
            ıconPictureBox1.IconChar = FontAwesome.Sharp.IconChar.UserAlt;
            ıconPictureBox1.IconColor = Color.DarkBlue;
            ıconPictureBox1.IconFont = FontAwesome.Sharp.IconFont.Auto;
            ıconPictureBox1.IconSize = 25;
            ıconPictureBox1.Location = new Point(22, 171);
            ıconPictureBox1.Name = "ıconPictureBox1";
            ıconPictureBox1.Size = new Size(25, 25);
            ıconPictureBox1.TabIndex = 4;
            ıconPictureBox1.TabStop = false;
            // 
            // FrmLogin
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSizeMode = AutoSizeMode.GrowAndShrink;
            BackColor = Color.FromArgb(202, 224, 252);
            ClientSize = new Size(690, 396);
            Controls.Add(panel2);
            Controls.Add(panel1);
            ForeColor = Color.Transparent;
            FormBorderStyle = FormBorderStyle.None;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(4, 3, 4, 3);
            Name = "FrmLogin";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Kullanıcı Girişi";
            Load += FrmLogin_Load;
            Shown += FrmLogin_Shown;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)ıconPictureBox2).EndInit();
            ((System.ComponentModel.ISupportInitialize)ıconPictureBox3).EndInit();
            ((System.ComponentModel.ISupportInitialize)ıconPictureBox1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Button btnGiris;
        private TextBox txtKullaniciAdi;
        private Label label1;
        private TextBox txtSifre;
        private Label label2;
        private Label label3;
        private Button btnIptal;
        private Panel panel1;
        private Panel panel2;
        private FontAwesome.Sharp.IconPictureBox ıconPictureBox1;
        private FontAwesome.Sharp.IconPictureBox ıconPictureBox2;
        private FontAwesome.Sharp.IconPictureBox ıconPictureBox3;
        private PictureBox pictureBox1;
        private Label label4;
    }
}

