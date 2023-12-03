namespace UretimTakipProgrami.Forms
{
    partial class FrmDailyProductionUpdate
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
            label1 = new Label();
            txtUretimMiktarı = new NumericUpDown();
            label2 = new Label();
            txtDefoluMiktarı = new NumericUpDown();
            panel1 = new Panel();
            txtSifre = new TextBox();
            txtKullaniciAdi = new TextBox();
            dateTimePicker1 = new DateTimePicker();
            btnIptal = new FontAwesome.Sharp.IconButton();
            btnKaydet = new FontAwesome.Sharp.IconButton();
            label4 = new Label();
            label3 = new Label();
            label5 = new Label();
            ((System.ComponentModel.ISupportInitialize)txtUretimMiktarı).BeginInit();
            ((System.ComponentModel.ISupportInitialize)txtDefoluMiktarı).BeginInit();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Tahoma", 9F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(35, 23);
            label1.Name = "label1";
            label1.Size = new Size(81, 14);
            label1.TabIndex = 0;
            label1.Text = "Üretim Miktarı";
            // 
            // txtUretimMiktarı
            // 
            txtUretimMiktarı.Font = new Font("Tahoma", 12F, FontStyle.Regular, GraphicsUnit.Point);
            txtUretimMiktarı.Location = new Point(35, 41);
            txtUretimMiktarı.Maximum = new decimal(new int[] { 9999, 0, 0, 0 });
            txtUretimMiktarı.Name = "txtUretimMiktarı";
            txtUretimMiktarı.Size = new Size(118, 27);
            txtUretimMiktarı.TabIndex = 1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Tahoma", 9F, FontStyle.Regular, GraphicsUnit.Point);
            label2.Location = new Point(161, 23);
            label2.Name = "label2";
            label2.Size = new Size(80, 14);
            label2.TabIndex = 0;
            label2.Text = "Defolu Miktarı";
            // 
            // txtDefoluMiktarı
            // 
            txtDefoluMiktarı.Font = new Font("Tahoma", 12F, FontStyle.Regular, GraphicsUnit.Point);
            txtDefoluMiktarı.Location = new Point(159, 41);
            txtDefoluMiktarı.Maximum = new decimal(new int[] { 9999, 0, 0, 0 });
            txtDefoluMiktarı.Name = "txtDefoluMiktarı";
            txtDefoluMiktarı.Size = new Size(120, 27);
            txtDefoluMiktarı.TabIndex = 1;
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(175, 174, 209);
            panel1.BorderStyle = BorderStyle.FixedSingle;
            panel1.Controls.Add(txtSifre);
            panel1.Controls.Add(txtKullaniciAdi);
            panel1.Controls.Add(dateTimePicker1);
            panel1.Controls.Add(btnIptal);
            panel1.Controls.Add(btnKaydet);
            panel1.Controls.Add(txtUretimMiktarı);
            panel1.Controls.Add(label4);
            panel1.Controls.Add(txtDefoluMiktarı);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(label5);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(label2);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(317, 338);
            panel1.TabIndex = 2;
            // 
            // txtSifre
            // 
            txtSifre.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            txtSifre.Location = new Point(35, 228);
            txtSifre.Name = "txtSifre";
            txtSifre.Size = new Size(244, 29);
            txtSifre.TabIndex = 7;
            txtSifre.UseSystemPasswordChar = true;
            // 
            // txtKullaniciAdi
            // 
            txtKullaniciAdi.Enabled = false;
            txtKullaniciAdi.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            txtKullaniciAdi.Location = new Point(35, 168);
            txtKullaniciAdi.Name = "txtKullaniciAdi";
            txtKullaniciAdi.Size = new Size(244, 29);
            txtKullaniciAdi.TabIndex = 7;
            // 
            // dateTimePicker1
            // 
            dateTimePicker1.CustomFormat = "dd/MM/yyyy HH:mm:ss";
            dateTimePicker1.Enabled = false;
            dateTimePicker1.Font = new Font("Tahoma", 12F, FontStyle.Regular, GraphicsUnit.Point);
            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.Location = new Point(35, 99);
            dateTimePicker1.Name = "dateTimePicker1";
            dateTimePicker1.Size = new Size(244, 27);
            dateTimePicker1.TabIndex = 6;
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
            btnIptal.Location = new Point(161, 282);
            btnIptal.Margin = new Padding(4, 3, 4, 3);
            btnIptal.Name = "btnIptal";
            btnIptal.Size = new Size(118, 29);
            btnIptal.TabIndex = 4;
            btnIptal.TabStop = false;
            btnIptal.Text = "İptal";
            btnIptal.TextAlign = ContentAlignment.MiddleRight;
            btnIptal.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnIptal.UseVisualStyleBackColor = false;
            btnIptal.Click += btnIptal_Click;
            // 
            // btnKaydet
            // 
            btnKaydet.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnKaydet.BackColor = Color.FromArgb(66, 115, 29);
            btnKaydet.Cursor = Cursors.Hand;
            btnKaydet.FlatAppearance.BorderSize = 0;
            btnKaydet.FlatStyle = FlatStyle.Flat;
            btnKaydet.Font = new Font("Tahoma", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            btnKaydet.ForeColor = Color.WhiteSmoke;
            btnKaydet.IconChar = FontAwesome.Sharp.IconChar.FloppyDisk;
            btnKaydet.IconColor = Color.WhiteSmoke;
            btnKaydet.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnKaydet.IconSize = 23;
            btnKaydet.Location = new Point(35, 282);
            btnKaydet.Margin = new Padding(4, 3, 4, 3);
            btnKaydet.Name = "btnKaydet";
            btnKaydet.Size = new Size(118, 29);
            btnKaydet.TabIndex = 5;
            btnKaydet.TabStop = false;
            btnKaydet.Text = "Kaydet";
            btnKaydet.TextAlign = ContentAlignment.MiddleRight;
            btnKaydet.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnKaydet.UseVisualStyleBackColor = false;
            btnKaydet.Click += btnKaydet_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Tahoma", 9F, FontStyle.Regular, GraphicsUnit.Point);
            label4.Location = new Point(35, 211);
            label4.Name = "label4";
            label4.Size = new Size(31, 14);
            label4.TabIndex = 0;
            label4.Text = "Şifre";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Tahoma", 9F, FontStyle.Regular, GraphicsUnit.Point);
            label3.Location = new Point(35, 151);
            label3.Name = "label3";
            label3.Size = new Size(134, 14);
            label3.TabIndex = 0;
            label3.Text = "Üretim Yapan Operatör";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Tahoma", 9F, FontStyle.Regular, GraphicsUnit.Point);
            label5.Location = new Point(35, 82);
            label5.Name = "label5";
            label5.Size = new Size(68, 14);
            label5.TabIndex = 0;
            label5.Text = "Üretim Bitiş";
            // 
            // FrmDailyProductionUpdate
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(317, 338);
            Controls.Add(panel1);
            Name = "FrmDailyProductionUpdate";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "FrmDailyProductionUpdate";
            Load += FrmDailyProductionUpdate_Load;
            Shown += FrmDailyProductionUpdate_Shown;
            ((System.ComponentModel.ISupportInitialize)txtUretimMiktarı).EndInit();
            ((System.ComponentModel.ISupportInitialize)txtDefoluMiktarı).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Label label1;
        private NumericUpDown txtUretimMiktarı;
        private Label label2;
        private NumericUpDown txtDefoluMiktarı;
        private Panel panel1;
        private FontAwesome.Sharp.IconButton btnIptal;
        private FontAwesome.Sharp.IconButton btnKaydet;
        private DateTimePicker dateTimePicker1;
        private Label label3;
        private TextBox txtSifre;
        private TextBox txtKullaniciAdi;
        private Label label4;
        private Label label5;
    }
}