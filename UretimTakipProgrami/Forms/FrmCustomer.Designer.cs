namespace UretimTakipProgrami.Forms
{
    partial class FrmCustomer
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
            groupBox2 = new GroupBox();
            dataGridView1 = new DataGridView();
            pnlArama = new Panel();
            btnKayitTarihiSil = new FontAwesome.Sharp.IconButton();
            btnUrunAdiSil = new FontAwesome.Sharp.IconButton();
            btnBulTarih = new FontAwesome.Sharp.IconButton();
            txtKayitTarihiAra = new TextBox();
            txtMusteriAdiAra = new TextBox();
            btnMusteriBul = new FontAwesome.Sharp.IconButton();
            lblKayitSayisi = new Label();
            label7 = new Label();
            label6 = new Label();
            monthCalendar1 = new MonthCalendar();
            txtMail = new TextBox();
            panel5 = new Panel();
            btnGeriDon = new FontAwesome.Sharp.IconButton();
            btnSil = new FontAwesome.Sharp.IconButton();
            btnIptal = new FontAwesome.Sharp.IconButton();
            btnYeni = new FontAwesome.Sharp.IconButton();
            btnKaydet = new FontAwesome.Sharp.IconButton();
            btnDuzenle = new FontAwesome.Sharp.IconButton();
            txtAdres = new TextBox();
            panel1 = new Panel();
            groupBox1 = new GroupBox();
            txtTelefon2 = new MaskedTextBox();
            txtTelefon1 = new MaskedTextBox();
            txtMusteriAdi = new TextBox();
            label3 = new Label();
            label5 = new Label();
            label1 = new Label();
            label4 = new Label();
            label2 = new Label();
            panel2 = new Panel();
            panel3 = new Panel();
            groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            pnlArama.SuspendLayout();
            panel5.SuspendLayout();
            panel1.SuspendLayout();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox2
            // 
            groupBox2.BackColor = Color.FromArgb(175, 174, 209);
            groupBox2.Controls.Add(dataGridView1);
            groupBox2.Controls.Add(pnlArama);
            groupBox2.Controls.Add(monthCalendar1);
            groupBox2.Dock = DockStyle.Fill;
            groupBox2.Font = new Font("Tahoma", 9F, FontStyle.Bold, GraphicsUnit.Point);
            groupBox2.Location = new Point(0, 243);
            groupBox2.Margin = new Padding(4, 3, 4, 3);
            groupBox2.Name = "groupBox2";
            groupBox2.Padding = new Padding(4, 3, 4, 3);
            groupBox2.Size = new Size(1055, 410);
            groupBox2.TabIndex = 7;
            groupBox2.TabStop = false;
            groupBox2.Text = "Müşteri Ara";
            // 
            // dataGridView1
            // 
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.AllowUserToResizeRows = false;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = SystemColors.Control;
            dataGridViewCellStyle1.Font = new Font("Tahoma", 8F, FontStyle.Bold, GraphicsUnit.Point);
            dataGridViewCellStyle1.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Control;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = SystemColors.Window;
            dataGridViewCellStyle2.Font = new Font("Tahoma", 8F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle2.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = Color.Orange;
            dataGridViewCellStyle2.SelectionForeColor = Color.Black;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            dataGridView1.DefaultCellStyle = dataGridViewCellStyle2;
            dataGridView1.Dock = DockStyle.Fill;
            dataGridView1.EnableHeadersVisualStyles = false;
            dataGridView1.Font = new Font("Tahoma", 8F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridView1.Location = new Point(4, 53);
            dataGridView1.MultiSelect = false;
            dataGridView1.Name = "dataGridView1";
            dataGridView1.ReadOnly = true;
            dataGridView1.RowHeadersVisible = false;
            dataGridView1.RowTemplate.Height = 25;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.Size = new Size(1047, 354);
            dataGridView1.TabIndex = 0;
            dataGridView1.CellClick += dataGridView1_CellClick;
            // 
            // pnlArama
            // 
            pnlArama.BackColor = Color.FromArgb(43, 84, 126);
            pnlArama.Controls.Add(btnKayitTarihiSil);
            pnlArama.Controls.Add(btnUrunAdiSil);
            pnlArama.Controls.Add(btnBulTarih);
            pnlArama.Controls.Add(txtKayitTarihiAra);
            pnlArama.Controls.Add(txtMusteriAdiAra);
            pnlArama.Controls.Add(btnMusteriBul);
            pnlArama.Controls.Add(lblKayitSayisi);
            pnlArama.Controls.Add(label7);
            pnlArama.Controls.Add(label6);
            pnlArama.Dock = DockStyle.Top;
            pnlArama.Location = new Point(4, 18);
            pnlArama.Name = "pnlArama";
            pnlArama.Size = new Size(1047, 35);
            pnlArama.TabIndex = 1;
            // 
            // btnKayitTarihiSil
            // 
            btnKayitTarihiSil.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnKayitTarihiSil.BackColor = Color.FromArgb(43, 84, 126);
            btnKayitTarihiSil.Cursor = Cursors.Hand;
            btnKayitTarihiSil.FlatAppearance.BorderSize = 0;
            btnKayitTarihiSil.FlatStyle = FlatStyle.Flat;
            btnKayitTarihiSil.Font = new Font("Tahoma", 9F, FontStyle.Regular, GraphicsUnit.Point);
            btnKayitTarihiSil.ForeColor = Color.WhiteSmoke;
            btnKayitTarihiSil.IconChar = FontAwesome.Sharp.IconChar.Xmark;
            btnKayitTarihiSil.IconColor = Color.WhiteSmoke;
            btnKayitTarihiSil.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnKayitTarihiSil.IconSize = 18;
            btnKayitTarihiSil.Location = new Point(554, 7);
            btnKayitTarihiSil.Margin = new Padding(4, 3, 4, 3);
            btnKayitTarihiSil.Name = "btnKayitTarihiSil";
            btnKayitTarihiSil.Size = new Size(23, 23);
            btnKayitTarihiSil.TabIndex = 3;
            btnKayitTarihiSil.TextAlign = ContentAlignment.MiddleRight;
            btnKayitTarihiSil.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnKayitTarihiSil.UseVisualStyleBackColor = false;
            btnKayitTarihiSil.Click += btnKayitTarihiSil_Click;
            // 
            // btnUrunAdiSil
            // 
            btnUrunAdiSil.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnUrunAdiSil.BackColor = Color.FromArgb(43, 84, 126);
            btnUrunAdiSil.Cursor = Cursors.Hand;
            btnUrunAdiSil.FlatAppearance.BorderSize = 0;
            btnUrunAdiSil.FlatStyle = FlatStyle.Flat;
            btnUrunAdiSil.Font = new Font("Tahoma", 9F, FontStyle.Regular, GraphicsUnit.Point);
            btnUrunAdiSil.ForeColor = Color.WhiteSmoke;
            btnUrunAdiSil.IconChar = FontAwesome.Sharp.IconChar.Xmark;
            btnUrunAdiSil.IconColor = Color.WhiteSmoke;
            btnUrunAdiSil.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnUrunAdiSil.IconSize = 18;
            btnUrunAdiSil.Location = new Point(288, 7);
            btnUrunAdiSil.Margin = new Padding(4, 3, 4, 3);
            btnUrunAdiSil.Name = "btnUrunAdiSil";
            btnUrunAdiSil.Size = new Size(23, 23);
            btnUrunAdiSil.TabIndex = 3;
            btnUrunAdiSil.TextAlign = ContentAlignment.MiddleRight;
            btnUrunAdiSil.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnUrunAdiSil.UseVisualStyleBackColor = false;
            btnUrunAdiSil.Click += btnUrunAdiSil_Click;
            // 
            // btnBulTarih
            // 
            btnBulTarih.BackColor = SystemColors.Window;
            btnBulTarih.FlatAppearance.BorderSize = 0;
            btnBulTarih.FlatStyle = FlatStyle.Flat;
            btnBulTarih.IconChar = FontAwesome.Sharp.IconChar.Calendar;
            btnBulTarih.IconColor = Color.Black;
            btnBulTarih.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnBulTarih.IconSize = 20;
            btnBulTarih.Location = new Point(531, 8);
            btnBulTarih.Name = "btnBulTarih";
            btnBulTarih.Size = new Size(20, 20);
            btnBulTarih.TabIndex = 4;
            btnBulTarih.UseVisualStyleBackColor = false;
            btnBulTarih.Click += btnBulTarih_Click;
            // 
            // txtKayitTarihiAra
            // 
            txtKayitTarihiAra.Font = new Font("Tahoma", 9F, FontStyle.Regular, GraphicsUnit.Point);
            txtKayitTarihiAra.Location = new Point(430, 7);
            txtKayitTarihiAra.Name = "txtKayitTarihiAra";
            txtKayitTarihiAra.Size = new Size(125, 22);
            txtKayitTarihiAra.TabIndex = 6;
            // 
            // txtMusteriAdiAra
            // 
            txtMusteriAdiAra.Font = new Font("Tahoma", 9F, FontStyle.Regular, GraphicsUnit.Point);
            txtMusteriAdiAra.Location = new Point(89, 7);
            txtMusteriAdiAra.Name = "txtMusteriAdiAra";
            txtMusteriAdiAra.Size = new Size(200, 22);
            txtMusteriAdiAra.TabIndex = 5;
            // 
            // btnMusteriBul
            // 
            btnMusteriBul.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnMusteriBul.BackColor = Color.FromArgb(66, 115, 29);
            btnMusteriBul.Cursor = Cursors.Hand;
            btnMusteriBul.FlatAppearance.BorderSize = 0;
            btnMusteriBul.FlatStyle = FlatStyle.Flat;
            btnMusteriBul.Font = new Font("Tahoma", 9F, FontStyle.Regular, GraphicsUnit.Point);
            btnMusteriBul.ForeColor = Color.WhiteSmoke;
            btnMusteriBul.IconChar = FontAwesome.Sharp.IconChar.MagnifyingGlass;
            btnMusteriBul.IconColor = Color.WhiteSmoke;
            btnMusteriBul.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnMusteriBul.IconSize = 18;
            btnMusteriBul.Location = new Point(627, 7);
            btnMusteriBul.Margin = new Padding(4, 3, 4, 3);
            btnMusteriBul.Name = "btnMusteriBul";
            btnMusteriBul.Size = new Size(100, 22);
            btnMusteriBul.TabIndex = 7;
            btnMusteriBul.Text = "Müşteri Bul ";
            btnMusteriBul.TextAlign = ContentAlignment.MiddleRight;
            btnMusteriBul.TextImageRelation = TextImageRelation.TextBeforeImage;
            btnMusteriBul.UseVisualStyleBackColor = false;
            btnMusteriBul.Click += btnMusteriBul_Click;
            // 
            // lblKayitSayisi
            // 
            lblKayitSayisi.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblKayitSayisi.AutoSize = true;
            lblKayitSayisi.Font = new Font("Tahoma", 9F, FontStyle.Regular, GraphicsUnit.Point);
            lblKayitSayisi.ForeColor = Color.Gainsboro;
            lblKayitSayisi.Location = new Point(949, 11);
            lblKayitSayisi.Margin = new Padding(4, 0, 4, 0);
            lblKayitSayisi.Name = "lblKayitSayisi";
            lblKayitSayisi.Size = new Size(69, 14);
            lblKayitSayisi.TabIndex = 2;
            lblKayitSayisi.Text = "Kayıt Sayısı:";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Tahoma", 9F, FontStyle.Regular, GraphicsUnit.Point);
            label7.ForeColor = Color.Gainsboro;
            label7.Location = new Point(353, 11);
            label7.Margin = new Padding(4, 0, 4, 0);
            label7.Name = "label7";
            label7.Size = new Size(70, 14);
            label7.TabIndex = 2;
            label7.Text = "Kayıt Tarihi:";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Tahoma", 9F, FontStyle.Regular, GraphicsUnit.Point);
            label6.ForeColor = Color.Gainsboro;
            label6.Location = new Point(11, 11);
            label6.Margin = new Padding(4, 0, 4, 0);
            label6.Name = "label6";
            label6.Size = new Size(71, 14);
            label6.TabIndex = 2;
            label6.Text = "Müşteri Adı:";
            // 
            // monthCalendar1
            // 
            monthCalendar1.Location = new Point(325, 52);
            monthCalendar1.MaxSelectionCount = 1;
            monthCalendar1.Name = "monthCalendar1";
            monthCalendar1.TabIndex = 7;
            monthCalendar1.TabStop = false;
            monthCalendar1.DateSelected += monthCalendar1_DateSelected;
            // 
            // txtMail
            // 
            txtMail.Enabled = false;
            txtMail.Font = new Font("Tahoma", 9F, FontStyle.Regular, GraphicsUnit.Point);
            txtMail.Location = new Point(307, 85);
            txtMail.Margin = new Padding(4, 3, 4, 3);
            txtMail.Name = "txtMail";
            txtMail.Size = new Size(280, 22);
            txtMail.TabIndex = 3;
            // 
            // panel5
            // 
            panel5.BackColor = Color.FromArgb(43, 84, 126);
            panel5.Controls.Add(btnGeriDon);
            panel5.Controls.Add(btnSil);
            panel5.Controls.Add(btnIptal);
            panel5.Controls.Add(btnYeni);
            panel5.Controls.Add(btnKaydet);
            panel5.Controls.Add(btnDuzenle);
            panel5.Dock = DockStyle.Top;
            panel5.Location = new Point(4, 18);
            panel5.Name = "panel5";
            panel5.Size = new Size(1047, 35);
            panel5.TabIndex = 6;
            // 
            // btnGeriDon
            // 
            btnGeriDon.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnGeriDon.AutoSize = true;
            btnGeriDon.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnGeriDon.BackColor = Color.FromArgb(204, 85, 0);
            btnGeriDon.Cursor = Cursors.Hand;
            btnGeriDon.FlatAppearance.BorderSize = 0;
            btnGeriDon.FlatStyle = FlatStyle.Flat;
            btnGeriDon.Font = new Font("Tahoma", 9F, FontStyle.Regular, GraphicsUnit.Point);
            btnGeriDon.ForeColor = Color.WhiteSmoke;
            btnGeriDon.IconChar = FontAwesome.Sharp.IconChar.PowerOff;
            btnGeriDon.IconColor = Color.WhiteSmoke;
            btnGeriDon.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnGeriDon.IconSize = 23;
            btnGeriDon.Location = new Point(956, 3);
            btnGeriDon.Margin = new Padding(4, 3, 4, 3);
            btnGeriDon.Name = "btnGeriDon";
            btnGeriDon.Size = new Size(87, 29);
            btnGeriDon.TabIndex = 5;
            btnGeriDon.Text = "Geri Dön";
            btnGeriDon.TextAlign = ContentAlignment.MiddleRight;
            btnGeriDon.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnGeriDon.UseVisualStyleBackColor = false;
            btnGeriDon.Visible = false;
            btnGeriDon.Click += btnGeriDon_Click;
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
            btnSil.Location = new Point(381, 3);
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
            btnIptal.Location = new Point(317, 3);
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
            btnYeni.Size = new Size(107, 29);
            btnYeni.TabIndex = 3;
            btnYeni.TabStop = false;
            btnYeni.Text = "Yeni Müşteri";
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
            btnKaydet.FlatAppearance.BorderSize = 0;
            btnKaydet.FlatStyle = FlatStyle.Flat;
            btnKaydet.Font = new Font("Tahoma", 9F, FontStyle.Regular, GraphicsUnit.Point);
            btnKaydet.ForeColor = Color.WhiteSmoke;
            btnKaydet.IconChar = FontAwesome.Sharp.IconChar.FloppyDisk;
            btnKaydet.IconColor = Color.WhiteSmoke;
            btnKaydet.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnKaydet.IconSize = 23;
            btnKaydet.Location = new Point(239, 3);
            btnKaydet.Margin = new Padding(4, 3, 4, 3);
            btnKaydet.Name = "btnKaydet";
            btnKaydet.Size = new Size(78, 29);
            btnKaydet.TabIndex = 3;
            btnKaydet.TabStop = false;
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
            btnDuzenle.Enabled = false;
            btnDuzenle.FlatAppearance.BorderSize = 0;
            btnDuzenle.FlatStyle = FlatStyle.Flat;
            btnDuzenle.Font = new Font("Tahoma", 9F, FontStyle.Regular, GraphicsUnit.Point);
            btnDuzenle.ForeColor = Color.WhiteSmoke;
            btnDuzenle.IconChar = FontAwesome.Sharp.IconChar.PenToSquare;
            btnDuzenle.IconColor = Color.WhiteSmoke;
            btnDuzenle.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnDuzenle.IconSize = 23;
            btnDuzenle.Location = new Point(110, 3);
            btnDuzenle.Margin = new Padding(4, 3, 4, 3);
            btnDuzenle.Name = "btnDuzenle";
            btnDuzenle.Size = new Size(129, 29);
            btnDuzenle.TabIndex = 3;
            btnDuzenle.TabStop = false;
            btnDuzenle.Text = "Müşteri Güncelle";
            btnDuzenle.TextAlign = ContentAlignment.MiddleRight;
            btnDuzenle.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnDuzenle.UseVisualStyleBackColor = false;
            btnDuzenle.Click += btnDuzenle_Click;
            // 
            // txtAdres
            // 
            txtAdres.Enabled = false;
            txtAdres.Font = new Font("Tahoma", 9F, FontStyle.Regular, GraphicsUnit.Point);
            txtAdres.Location = new Point(307, 135);
            txtAdres.Margin = new Padding(4, 3, 4, 3);
            txtAdres.Multiline = true;
            txtAdres.Name = "txtAdres";
            txtAdres.Size = new Size(280, 72);
            txtAdres.TabIndex = 4;
            // 
            // panel1
            // 
            panel1.Controls.Add(groupBox1);
            panel1.Controls.Add(panel2);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(1055, 243);
            panel1.TabIndex = 8;
            // 
            // groupBox1
            // 
            groupBox1.BackColor = Color.FromArgb(175, 174, 209);
            groupBox1.Controls.Add(txtTelefon2);
            groupBox1.Controls.Add(txtTelefon1);
            groupBox1.Controls.Add(txtMusteriAdi);
            groupBox1.Controls.Add(txtMail);
            groupBox1.Controls.Add(txtAdres);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(label5);
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(panel3);
            groupBox1.Controls.Add(panel5);
            groupBox1.Dock = DockStyle.Fill;
            groupBox1.Font = new Font("Tahoma", 9F, FontStyle.Bold, GraphicsUnit.Point);
            groupBox1.Location = new Point(0, 10);
            groupBox1.Margin = new Padding(4, 3, 4, 3);
            groupBox1.Name = "groupBox1";
            groupBox1.Padding = new Padding(4, 3, 4, 3);
            groupBox1.Size = new Size(1055, 233);
            groupBox1.TabIndex = 5;
            groupBox1.TabStop = false;
            groupBox1.Text = "Müşteri Tanımlama";
            // 
            // txtTelefon2
            // 
            txtTelefon2.Font = new Font("Tahoma", 9F, FontStyle.Regular, GraphicsUnit.Point);
            txtTelefon2.Location = new Point(20, 185);
            txtTelefon2.Mask = "9 (999) 000 00 00";
            txtTelefon2.Name = "txtTelefon2";
            txtTelefon2.Size = new Size(280, 22);
            txtTelefon2.TabIndex = 2;
            // 
            // txtTelefon1
            // 
            txtTelefon1.Font = new Font("Tahoma", 9F, FontStyle.Regular, GraphicsUnit.Point);
            txtTelefon1.Location = new Point(20, 135);
            txtTelefon1.Mask = "9 (999) 000 00 00";
            txtTelefon1.Name = "txtTelefon1";
            txtTelefon1.Size = new Size(280, 22);
            txtTelefon1.TabIndex = 1;
            // 
            // txtMusteriAdi
            // 
            txtMusteriAdi.Enabled = false;
            txtMusteriAdi.Font = new Font("Tahoma", 9F, FontStyle.Regular, GraphicsUnit.Point);
            txtMusteriAdi.Location = new Point(20, 85);
            txtMusteriAdi.Margin = new Padding(4, 3, 4, 3);
            txtMusteriAdi.Name = "txtMusteriAdi";
            txtMusteriAdi.Size = new Size(280, 22);
            txtMusteriAdi.TabIndex = 0;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Tahoma", 9F, FontStyle.Regular, GraphicsUnit.Point);
            label3.Location = new Point(307, 68);
            label3.Margin = new Padding(4, 0, 4, 0);
            label3.Name = "label3";
            label3.Size = new Size(37, 14);
            label3.TabIndex = 2;
            label3.Text = "E-Mail";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Tahoma", 9F, FontStyle.Regular, GraphicsUnit.Point);
            label5.Location = new Point(20, 168);
            label5.Margin = new Padding(4, 0, 4, 0);
            label5.Name = "label5";
            label5.Size = new Size(60, 14);
            label5.TabIndex = 2;
            label5.Text = "Telefon 2";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Tahoma", 9F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(20, 68);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(116, 14);
            label1.TabIndex = 2;
            label1.Text = "Müşteri Adı / Unvanı";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Tahoma", 9F, FontStyle.Regular, GraphicsUnit.Point);
            label4.Location = new Point(20, 118);
            label4.Margin = new Padding(4, 0, 4, 0);
            label4.Name = "label4";
            label4.Size = new Size(60, 14);
            label4.TabIndex = 2;
            label4.Text = "Telefon 1";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Tahoma", 9F, FontStyle.Regular, GraphicsUnit.Point);
            label2.Location = new Point(307, 118);
            label2.Margin = new Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new Size(38, 14);
            label2.TabIndex = 2;
            label2.Text = "Adres";
            // 
            // panel2
            // 
            panel2.BackColor = Color.FromArgb(175, 174, 209);
            panel2.Dock = DockStyle.Top;
            panel2.Location = new Point(0, 0);
            panel2.Name = "panel2";
            panel2.Size = new Size(1055, 10);
            panel2.TabIndex = 6;
            // 
            // panel3
            // 
            panel3.BorderStyle = BorderStyle.FixedSingle;
            panel3.Dock = DockStyle.Fill;
            panel3.Location = new Point(4, 53);
            panel3.Name = "panel3";
            panel3.Size = new Size(1047, 177);
            panel3.TabIndex = 7;
            // 
            // FrmCustomer
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1055, 653);
            Controls.Add(groupBox2);
            Controls.Add(panel1);
            MinimumSize = new Size(800, 300);
            Name = "FrmCustomer";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Müşteriler";
            FormClosed += FrmCustomer_FormClosed;
            Load += FrmCustomer_Load;
            groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            pnlArama.ResumeLayout(false);
            pnlArama.PerformLayout();
            panel5.ResumeLayout(false);
            panel5.PerformLayout();
            panel1.ResumeLayout(false);
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBox2;
        private MonthCalendar monthCalendar1;
        private DataGridView dataGridView1;
        private Panel pnlArama;
        private FontAwesome.Sharp.IconButton btnKayitTarihiSil;
        private FontAwesome.Sharp.IconButton btnUrunAdiSil;
        private FontAwesome.Sharp.IconButton btnBulTarih;
        private TextBox txtKayitTarihiAra;
        private TextBox txtMusteriAdiAra;
        private FontAwesome.Sharp.IconButton btnMusteriBul;
        private Label lblKayitSayisi;
        private Label label7;
        private Label label6;
        private TextBox txtMail;
        private Panel panel5;
        private FontAwesome.Sharp.IconButton btnSil;
        private FontAwesome.Sharp.IconButton btnIptal;
        private FontAwesome.Sharp.IconButton btnYeni;
        private FontAwesome.Sharp.IconButton btnKaydet;
        private FontAwesome.Sharp.IconButton btnDuzenle;
        private TextBox txtAdres;
        private Panel panel1;
        private GroupBox groupBox1;
        private TextBox txtMusteriAdi;
        private Label label3;
        private Label label5;
        private Label label1;
        private Label label4;
        private Label label2;
        private Panel panel2;
        private MaskedTextBox txtTelefon2;
        private MaskedTextBox txtTelefon1;
        private FontAwesome.Sharp.IconButton btnGeriDon;
        private Panel panel3;
    }
}