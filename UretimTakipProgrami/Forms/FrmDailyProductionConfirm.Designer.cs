namespace UretimTakipProgrami.Forms
{
    partial class FrmDailyProductionConfirm
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
            btnIptal = new FontAwesome.Sharp.IconButton();
            btnTamam = new FontAwesome.Sharp.IconButton();
            label1 = new Label();
            txtKullaniciAdi = new TextBox();
            label2 = new Label();
            txtSifre = new TextBox();
            SuspendLayout();
            // 
            // btnIptal
            // 
            btnIptal.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnIptal.BackColor = Color.FromArgb(43, 84, 126);
            btnIptal.Cursor = Cursors.Hand;
            btnIptal.FlatAppearance.BorderSize = 0;
            btnIptal.FlatStyle = FlatStyle.Flat;
            btnIptal.Font = new Font("Tahoma", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            btnIptal.ForeColor = Color.WhiteSmoke;
            btnIptal.IconChar = FontAwesome.Sharp.IconChar.Xmark;
            btnIptal.IconColor = Color.WhiteSmoke;
            btnIptal.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnIptal.IconSize = 23;
            btnIptal.Location = new Point(156, 142);
            btnIptal.Margin = new Padding(4, 3, 4, 3);
            btnIptal.Name = "btnIptal";
            btnIptal.Size = new Size(118, 29);
            btnIptal.TabIndex = 3;
            btnIptal.TabStop = false;
            btnIptal.Text = "İptal";
            btnIptal.TextAlign = ContentAlignment.MiddleRight;
            btnIptal.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnIptal.UseVisualStyleBackColor = false;
            btnIptal.Click += btnIptal_Click;
            // 
            // btnTamam
            // 
            btnTamam.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnTamam.BackColor = Color.FromArgb(66, 115, 29);
            btnTamam.Cursor = Cursors.Hand;
            btnTamam.FlatAppearance.BorderSize = 0;
            btnTamam.FlatStyle = FlatStyle.Flat;
            btnTamam.Font = new Font("Tahoma", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            btnTamam.ForeColor = Color.WhiteSmoke;
            btnTamam.IconChar = FontAwesome.Sharp.IconChar.FloppyDisk;
            btnTamam.IconColor = Color.WhiteSmoke;
            btnTamam.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnTamam.IconSize = 23;
            btnTamam.Location = new Point(30, 142);
            btnTamam.Margin = new Padding(4, 3, 4, 3);
            btnTamam.Name = "btnTamam";
            btnTamam.Size = new Size(118, 29);
            btnTamam.TabIndex = 2;
            btnTamam.TabStop = false;
            btnTamam.Text = "Tamam";
            btnTamam.TextAlign = ContentAlignment.MiddleRight;
            btnTamam.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnTamam.UseVisualStyleBackColor = false;
            btnTamam.Click += btnTamam_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Tahoma", 9F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(30, 23);
            label1.Name = "label1";
            label1.Size = new Size(69, 14);
            label1.TabIndex = 8;
            label1.Text = "Kullanıcı Adı";
            // 
            // txtKullaniciAdi
            // 
            txtKullaniciAdi.Location = new Point(30, 40);
            txtKullaniciAdi.Name = "txtKullaniciAdi";
            txtKullaniciAdi.Size = new Size(244, 23);
            txtKullaniciAdi.TabIndex = 0;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Tahoma", 9F, FontStyle.Regular, GraphicsUnit.Point);
            label2.Location = new Point(30, 77);
            label2.Name = "label2";
            label2.Size = new Size(31, 14);
            label2.TabIndex = 8;
            label2.Text = "Şifre";
            // 
            // txtSifre
            // 
            txtSifre.Location = new Point(30, 94);
            txtSifre.Name = "txtSifre";
            txtSifre.Size = new Size(244, 23);
            txtSifre.TabIndex = 1;
            txtSifre.UseSystemPasswordChar = true;
            txtSifre.KeyPress += txtSifre_KeyPress;
            // 
            // FrmDailyProductionConfirm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(115, 147, 179);
            ClientSize = new Size(308, 195);
            Controls.Add(txtSifre);
            Controls.Add(label2);
            Controls.Add(txtKullaniciAdi);
            Controls.Add(label1);
            Controls.Add(btnIptal);
            Controls.Add(btnTamam);
            Name = "FrmDailyProductionConfirm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "FrmDailyProductionConfirm";
            Load += FrmDailyProductionConfirm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private FontAwesome.Sharp.IconButton btnIptal;
        private FontAwesome.Sharp.IconButton btnTamam;
        private Label label1;
        private TextBox txtKullaniciAdi;
        private Label label2;
        private TextBox txtSifre;
    }
}