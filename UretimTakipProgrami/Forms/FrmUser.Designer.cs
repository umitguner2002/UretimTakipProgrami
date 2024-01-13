using System.Windows.Forms;

namespace UretimTakipProgrami.Forms
{
    partial class FrmUser
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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            grpboxTezgahTanimla = new GroupBox();
            pnlArama = new Panel();
            dataGridView1 = new DataGridView();
            panel3 = new Panel();
            groupUserInfo = new GroupBox();
            txtAdiSoyadi = new TextBox();
            label8 = new Label();
            txtTelefon = new MaskedTextBox();
            label2 = new Label();
            txtEmail = new TextBox();
            label3 = new Label();
            groupUserAuth = new GroupBox();
            groupBox3 = new GroupBox();
            checkAdmin = new CheckBox();
            checkManager = new CheckBox();
            checkOperator = new CheckBox();
            checkActive = new CheckBox();
            txtKullaniciAdi = new TextBox();
            label5 = new Label();
            label4 = new Label();
            txtSifre = new TextBox();
            label1 = new Label();
            pnlMachine = new Panel();
            btnSil = new FontAwesome.Sharp.IconButton();
            btnIptal = new FontAwesome.Sharp.IconButton();
            btnYeni = new FontAwesome.Sharp.IconButton();
            btnKaydet = new FontAwesome.Sharp.IconButton();
            btnDuzenle = new FontAwesome.Sharp.IconButton();
            panel1 = new Panel();
            panel2 = new Panel();
            grpboxTezgahTanimla.SuspendLayout();
            pnlArama.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            panel3.SuspendLayout();
            groupUserInfo.SuspendLayout();
            groupUserAuth.SuspendLayout();
            groupBox3.SuspendLayout();
            pnlMachine.SuspendLayout();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // grpboxTezgahTanimla
            // 
            grpboxTezgahTanimla.BackColor = Color.FromArgb(175, 174, 209);
            grpboxTezgahTanimla.Controls.Add(pnlArama);
            grpboxTezgahTanimla.Controls.Add(panel3);
            grpboxTezgahTanimla.Controls.Add(pnlMachine);
            grpboxTezgahTanimla.Dock = DockStyle.Fill;
            grpboxTezgahTanimla.Font = new Font("Tahoma", 9F, FontStyle.Bold, GraphicsUnit.Point);
            grpboxTezgahTanimla.Location = new Point(0, 0);
            grpboxTezgahTanimla.Name = "grpboxTezgahTanimla";
            grpboxTezgahTanimla.Size = new Size(982, 565);
            grpboxTezgahTanimla.TabIndex = 1;
            grpboxTezgahTanimla.TabStop = false;
            grpboxTezgahTanimla.Text = "Kullanıcı Tanımla";
            // 
            // pnlArama
            // 
            pnlArama.Controls.Add(dataGridView1);
            pnlArama.Dock = DockStyle.Fill;
            pnlArama.Location = new Point(3, 238);
            pnlArama.Name = "pnlArama";
            pnlArama.Size = new Size(976, 324);
            pnlArama.TabIndex = 11;
            // 
            // dataGridView1
            // 
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = SystemColors.Control;
            dataGridViewCellStyle1.Font = new Font("Tahoma", 9F, FontStyle.Bold, GraphicsUnit.Point);
            dataGridViewCellStyle1.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Control;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = SystemColors.Window;
            dataGridViewCellStyle2.Font = new Font("Tahoma", 9F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle2.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = Color.Orange;
            dataGridViewCellStyle2.SelectionForeColor = Color.Black;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            dataGridView1.DefaultCellStyle = dataGridViewCellStyle2;
            dataGridView1.Dock = DockStyle.Fill;
            dataGridView1.EnableHeadersVisualStyles = false;
            dataGridView1.Font = new Font("Tahoma", 9F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridView1.Location = new Point(0, 0);
            dataGridView1.MultiSelect = false;
            dataGridView1.Name = "dataGridView1";
            dataGridView1.ReadOnly = true;
            dataGridView1.RowHeadersVisible = false;
            dataGridView1.RowTemplate.Height = 25;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.Size = new Size(976, 324);
            dataGridView1.TabIndex = 0;
            dataGridView1.CellClick += dataGridView1_CellClick;
            // 
            // panel3
            // 
            panel3.Controls.Add(groupUserInfo);
            panel3.Controls.Add(groupUserAuth);
            panel3.Dock = DockStyle.Top;
            panel3.Location = new Point(3, 53);
            panel3.Name = "panel3";
            panel3.Size = new Size(976, 185);
            panel3.TabIndex = 10;
            // 
            // groupUserInfo
            // 
            groupUserInfo.Controls.Add(txtAdiSoyadi);
            groupUserInfo.Controls.Add(label8);
            groupUserInfo.Controls.Add(txtTelefon);
            groupUserInfo.Controls.Add(label2);
            groupUserInfo.Controls.Add(txtEmail);
            groupUserInfo.Controls.Add(label3);
            groupUserInfo.Enabled = false;
            groupUserInfo.Font = new Font("Tahoma", 9F, FontStyle.Bold, GraphicsUnit.Point);
            groupUserInfo.Location = new Point(9, 6);
            groupUserInfo.Name = "groupUserInfo";
            groupUserInfo.Size = new Size(324, 170);
            groupUserInfo.TabIndex = 12;
            groupUserInfo.TabStop = false;
            groupUserInfo.Text = "Kullanıcı Bilgileri";
            // 
            // txtAdiSoyadi
            // 
            txtAdiSoyadi.Font = new Font("Tahoma", 9F, FontStyle.Regular, GraphicsUnit.Point);
            txtAdiSoyadi.Location = new Point(81, 26);
            txtAdiSoyadi.Margin = new Padding(4, 3, 4, 3);
            txtAdiSoyadi.Name = "txtAdiSoyadi";
            txtAdiSoyadi.Size = new Size(230, 22);
            txtAdiSoyadi.TabIndex = 0;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Tahoma", 9F, FontStyle.Regular, GraphicsUnit.Point);
            label8.Location = new Point(6, 29);
            label8.Margin = new Padding(4, 0, 4, 0);
            label8.Name = "label8";
            label8.Size = new Size(67, 14);
            label8.TabIndex = 7;
            label8.Text = "Adı Soyadı:";
            // 
            // txtTelefon
            // 
            txtTelefon.Font = new Font("Tahoma", 9F, FontStyle.Regular, GraphicsUnit.Point);
            txtTelefon.Location = new Point(81, 54);
            txtTelefon.Name = "txtTelefon";
            txtTelefon.Size = new Size(230, 22);
            txtTelefon.TabIndex = 1;
            txtTelefon.Enter += txtTelefon_Enter;
            txtTelefon.Leave += txtTelefon_Leave;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Tahoma", 9F, FontStyle.Regular, GraphicsUnit.Point);
            label2.Location = new Point(32, 86);
            label2.Margin = new Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new Size(41, 14);
            label2.TabIndex = 7;
            label2.Text = "E-Mail:";
            // 
            // txtEmail
            // 
            txtEmail.Font = new Font("Tahoma", 9F, FontStyle.Regular, GraphicsUnit.Point);
            txtEmail.Location = new Point(81, 82);
            txtEmail.Margin = new Padding(4, 3, 4, 3);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(230, 22);
            txtEmail.TabIndex = 2;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Tahoma", 9F, FontStyle.Regular, GraphicsUnit.Point);
            label3.Location = new Point(20, 57);
            label3.Margin = new Padding(4, 0, 4, 0);
            label3.Name = "label3";
            label3.Size = new Size(53, 14);
            label3.TabIndex = 7;
            label3.Text = "Telefon:";
            // 
            // groupUserAuth
            // 
            groupUserAuth.Controls.Add(groupBox3);
            groupUserAuth.Controls.Add(checkActive);
            groupUserAuth.Controls.Add(txtKullaniciAdi);
            groupUserAuth.Controls.Add(label5);
            groupUserAuth.Controls.Add(label4);
            groupUserAuth.Controls.Add(txtSifre);
            groupUserAuth.Controls.Add(label1);
            groupUserAuth.Enabled = false;
            groupUserAuth.Font = new Font("Tahoma", 9F, FontStyle.Bold, GraphicsUnit.Point);
            groupUserAuth.Location = new Point(339, 6);
            groupUserAuth.Name = "groupUserAuth";
            groupUserAuth.Size = new Size(343, 170);
            groupUserAuth.TabIndex = 11;
            groupUserAuth.TabStop = false;
            groupUserAuth.Text = "Kullanıcı İşlemleri";
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(checkAdmin);
            groupBox3.Controls.Add(checkManager);
            groupBox3.Controls.Add(checkOperator);
            groupBox3.Location = new Point(13, 116);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(320, 48);
            groupBox3.TabIndex = 11;
            groupBox3.TabStop = false;
            groupBox3.Text = "Yetkilendirme";
            // 
            // checkAdmin
            // 
            checkAdmin.AutoSize = true;
            checkAdmin.Font = new Font("Tahoma", 9F, FontStyle.Regular, GraphicsUnit.Point);
            checkAdmin.Location = new Point(10, 21);
            checkAdmin.Name = "checkAdmin";
            checkAdmin.Size = new Size(70, 18);
            checkAdmin.TabIndex = 6;
            checkAdmin.Text = "Yönetici";
            checkAdmin.UseVisualStyleBackColor = true;
            // 
            // checkManager
            // 
            checkManager.AutoSize = true;
            checkManager.Font = new Font("Tahoma", 9F, FontStyle.Regular, GraphicsUnit.Point);
            checkManager.Location = new Point(97, 21);
            checkManager.Name = "checkManager";
            checkManager.Size = new Size(122, 18);
            checkManager.TabIndex = 7;
            checkManager.Text = "Üretim Sorumlusu";
            checkManager.UseVisualStyleBackColor = true;
            // 
            // checkOperator
            // 
            checkOperator.AutoSize = true;
            checkOperator.Font = new Font("Tahoma", 9F, FontStyle.Regular, GraphicsUnit.Point);
            checkOperator.Location = new Point(235, 21);
            checkOperator.Name = "checkOperator";
            checkOperator.Size = new Size(75, 18);
            checkOperator.TabIndex = 8;
            checkOperator.Text = "Operatör";
            checkOperator.UseVisualStyleBackColor = true;
            // 
            // checkActive
            // 
            checkActive.AutoSize = true;
            checkActive.Font = new Font("Tahoma", 9F, FontStyle.Regular, GraphicsUnit.Point);
            checkActive.Location = new Point(103, 84);
            checkActive.Name = "checkActive";
            checkActive.Size = new Size(51, 18);
            checkActive.TabIndex = 5;
            checkActive.Text = "Aktif";
            checkActive.UseVisualStyleBackColor = true;
            // 
            // txtKullaniciAdi
            // 
            txtKullaniciAdi.Font = new Font("Tahoma", 9F, FontStyle.Regular, GraphicsUnit.Point);
            txtKullaniciAdi.Location = new Point(103, 26);
            txtKullaniciAdi.Margin = new Padding(4, 3, 4, 3);
            txtKullaniciAdi.Name = "txtKullaniciAdi";
            txtKullaniciAdi.Size = new Size(230, 22);
            txtKullaniciAdi.TabIndex = 3;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Tahoma", 9F, FontStyle.Regular, GraphicsUnit.Point);
            label5.Location = new Point(8, 86);
            label5.Margin = new Padding(4, 0, 4, 0);
            label5.Name = "label5";
            label5.Size = new Size(92, 14);
            label5.TabIndex = 7;
            label5.Text = "Kullanıcı Durum:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Tahoma", 9F, FontStyle.Regular, GraphicsUnit.Point);
            label4.Location = new Point(13, 57);
            label4.Margin = new Padding(4, 0, 4, 0);
            label4.Name = "label4";
            label4.Size = new Size(87, 14);
            label4.TabIndex = 7;
            label4.Text = "Kullanıcı Şifresi:";
            // 
            // txtSifre
            // 
            txtSifre.Font = new Font("Tahoma", 9F, FontStyle.Regular, GraphicsUnit.Point);
            txtSifre.Location = new Point(103, 54);
            txtSifre.Margin = new Padding(4, 3, 4, 3);
            txtSifre.Name = "txtSifre";
            txtSifre.Size = new Size(230, 22);
            txtSifre.TabIndex = 4;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Tahoma", 9F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(27, 29);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(73, 14);
            label1.TabIndex = 7;
            label1.Text = "Kullanıcı Adı:";
            // 
            // pnlMachine
            // 
            pnlMachine.BackColor = Color.FromArgb(43, 84, 126);
            pnlMachine.Controls.Add(btnSil);
            pnlMachine.Controls.Add(btnIptal);
            pnlMachine.Controls.Add(btnYeni);
            pnlMachine.Controls.Add(btnKaydet);
            pnlMachine.Controls.Add(btnDuzenle);
            pnlMachine.Dock = DockStyle.Top;
            pnlMachine.Location = new Point(3, 18);
            pnlMachine.Name = "pnlMachine";
            pnlMachine.Size = new Size(976, 35);
            pnlMachine.TabIndex = 9;
            // 
            // btnSil
            // 
            btnSil.AutoSize = true;
            btnSil.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnSil.BackColor = Color.FromArgb(43, 84, 126);
            btnSil.Cursor = Cursors.Hand;
            btnSil.FlatAppearance.BorderSize = 0;
            btnSil.FlatStyle = FlatStyle.Flat;
            btnSil.Font = new Font("Tahoma", 9F, FontStyle.Regular, GraphicsUnit.Point);
            btnSil.ForeColor = Color.WhiteSmoke;
            btnSil.IconChar = FontAwesome.Sharp.IconChar.TrashAlt;
            btnSil.IconColor = Color.WhiteSmoke;
            btnSil.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnSil.IconSize = 23;
            btnSil.Location = new Point(315, 3);
            btnSil.Margin = new Padding(4, 3, 4, 3);
            btnSil.Name = "btnSil";
            btnSil.Size = new Size(51, 29);
            btnSil.TabIndex = 3;
            btnSil.TabStop = false;
            btnSil.Text = "Sil";
            btnSil.TextAlign = ContentAlignment.MiddleRight;
            btnSil.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnSil.UseVisualStyleBackColor = false;
            btnSil.Click += btnSil_Click;
            // 
            // btnIptal
            // 
            btnIptal.AutoSize = true;
            btnIptal.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnIptal.BackColor = Color.FromArgb(43, 84, 126);
            btnIptal.Cursor = Cursors.Hand;
            btnIptal.Enabled = false;
            btnIptal.FlatAppearance.BorderSize = 0;
            btnIptal.FlatStyle = FlatStyle.Flat;
            btnIptal.Font = new Font("Tahoma", 9F, FontStyle.Regular, GraphicsUnit.Point);
            btnIptal.ForeColor = Color.WhiteSmoke;
            btnIptal.IconChar = FontAwesome.Sharp.IconChar.Xmark;
            btnIptal.IconColor = Color.WhiteSmoke;
            btnIptal.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnIptal.IconSize = 23;
            btnIptal.Location = new Point(246, 3);
            btnIptal.Margin = new Padding(4, 3, 4, 3);
            btnIptal.Name = "btnIptal";
            btnIptal.Size = new Size(64, 29);
            btnIptal.TabIndex = 3;
            btnIptal.TabStop = false;
            btnIptal.Text = "İptal";
            btnIptal.TextAlign = ContentAlignment.MiddleRight;
            btnIptal.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnIptal.UseVisualStyleBackColor = false;
            btnIptal.Click += btnIptal_Click;
            // 
            // btnYeni
            // 
            btnYeni.AutoSize = true;
            btnYeni.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnYeni.BackColor = Color.FromArgb(43, 84, 126);
            btnYeni.Cursor = Cursors.Hand;
            btnYeni.FlatAppearance.BorderSize = 0;
            btnYeni.FlatStyle = FlatStyle.Flat;
            btnYeni.Font = new Font("Tahoma", 9F, FontStyle.Regular, GraphicsUnit.Point);
            btnYeni.ForeColor = Color.WhiteSmoke;
            btnYeni.IconChar = FontAwesome.Sharp.IconChar.FolderPlus;
            btnYeni.IconColor = Color.WhiteSmoke;
            btnYeni.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnYeni.IconSize = 23;
            btnYeni.Location = new Point(3, 3);
            btnYeni.Margin = new Padding(4, 3, 4, 3);
            btnYeni.Name = "btnYeni";
            btnYeni.Size = new Size(64, 29);
            btnYeni.TabIndex = 3;
            btnYeni.TabStop = false;
            btnYeni.Text = "Yeni";
            btnYeni.TextAlign = ContentAlignment.MiddleRight;
            btnYeni.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnYeni.UseVisualStyleBackColor = false;
            btnYeni.Click += btnYeni_Click;
            // 
            // btnKaydet
            // 
            btnKaydet.AutoSize = true;
            btnKaydet.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnKaydet.BackColor = Color.FromArgb(43, 84, 126);
            btnKaydet.Cursor = Cursors.Hand;
            btnKaydet.Enabled = false;
            btnKaydet.FlatAppearance.BorderSize = 0;
            btnKaydet.FlatStyle = FlatStyle.Flat;
            btnKaydet.Font = new Font("Tahoma", 9F, FontStyle.Regular, GraphicsUnit.Point);
            btnKaydet.ForeColor = Color.WhiteSmoke;
            btnKaydet.IconChar = FontAwesome.Sharp.IconChar.FloppyDisk;
            btnKaydet.IconColor = Color.WhiteSmoke;
            btnKaydet.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnKaydet.IconSize = 23;
            btnKaydet.Location = new Point(163, 3);
            btnKaydet.Margin = new Padding(4, 3, 4, 3);
            btnKaydet.Name = "btnKaydet";
            btnKaydet.Size = new Size(78, 29);
            btnKaydet.TabIndex = 9;
            btnKaydet.Text = "Kaydet";
            btnKaydet.TextAlign = ContentAlignment.MiddleRight;
            btnKaydet.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnKaydet.UseVisualStyleBackColor = false;
            btnKaydet.Click += btnKaydet_Click;
            // 
            // btnDuzenle
            // 
            btnDuzenle.AutoSize = true;
            btnDuzenle.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnDuzenle.BackColor = Color.FromArgb(43, 84, 126);
            btnDuzenle.Cursor = Cursors.Hand;
            btnDuzenle.FlatAppearance.BorderSize = 0;
            btnDuzenle.FlatStyle = FlatStyle.Flat;
            btnDuzenle.Font = new Font("Tahoma", 9F, FontStyle.Regular, GraphicsUnit.Point);
            btnDuzenle.ForeColor = Color.WhiteSmoke;
            btnDuzenle.IconChar = FontAwesome.Sharp.IconChar.PenToSquare;
            btnDuzenle.IconColor = Color.WhiteSmoke;
            btnDuzenle.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnDuzenle.IconSize = 23;
            btnDuzenle.Location = new Point(72, 3);
            btnDuzenle.Margin = new Padding(4, 3, 4, 3);
            btnDuzenle.Name = "btnDuzenle";
            btnDuzenle.Size = new Size(86, 29);
            btnDuzenle.TabIndex = 3;
            btnDuzenle.TabStop = false;
            btnDuzenle.Text = "Güncelle";
            btnDuzenle.TextAlign = ContentAlignment.MiddleRight;
            btnDuzenle.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnDuzenle.UseVisualStyleBackColor = false;
            btnDuzenle.Click += btnDuzenle_Click;
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(175, 174, 209);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(982, 10);
            panel1.TabIndex = 2;
            // 
            // panel2
            // 
            panel2.Controls.Add(grpboxTezgahTanimla);
            panel2.Dock = DockStyle.Fill;
            panel2.Location = new Point(0, 10);
            panel2.Name = "panel2";
            panel2.Size = new Size(982, 565);
            panel2.TabIndex = 3;
            // 
            // FrmUser
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(982, 575);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Name = "FrmUser";
            Text = "FrmUser";
            Load += FrmUser_Load;
            Shown += FrmUser_Shown;
            grpboxTezgahTanimla.ResumeLayout(false);
            pnlArama.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            panel3.ResumeLayout(false);
            groupUserInfo.ResumeLayout(false);
            groupUserInfo.PerformLayout();
            groupUserAuth.ResumeLayout(false);
            groupUserAuth.PerformLayout();
            groupBox3.ResumeLayout(false);
            groupBox3.PerformLayout();
            pnlMachine.ResumeLayout(false);
            pnlMachine.PerformLayout();
            panel2.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private GroupBox grpboxTezgahTanimla;
        private Panel panel3;
        private Panel pnlMachine;
        private FontAwesome.Sharp.IconButton btnSil;
        private FontAwesome.Sharp.IconButton btnIptal;
        private FontAwesome.Sharp.IconButton btnYeni;
        private FontAwesome.Sharp.IconButton btnKaydet;
        private FontAwesome.Sharp.IconButton btnDuzenle;
        private Panel panel1;
        private Panel panel2;
        private Panel pnlArama;
        private MaskedTextBox txtTelefon;
        private TextBox txtEmail;
        private Label label3;
        private Label label2;
        private TextBox txtSifre;
        private Label label4;
        private TextBox txtKullaniciAdi;
        private Label label1;
        private TextBox txtAdiSoyadi;
        private Label label8;
        private DataGridView dataGridView1;
        private GroupBox groupUserAuth;
        private CheckBox checkAdmin;
        private CheckBox checkOperator;
        private CheckBox checkManager;
        private GroupBox groupUserInfo;
        private GroupBox groupBox3;
        private CheckBox checkActive;
        private Label label5;
    }
}