using System.Windows.Forms;

namespace UretimTakipProgrami.Forms
{
    partial class FrmProduct
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmProduct));
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            txtUrunAdi = new TextBox();
            label1 = new Label();
            btnKaydet = new FontAwesome.Sharp.IconButton();
            groupBox1 = new GroupBox();
            listMalzeme = new ComboBox();
            listProgramAdi = new ComboBox();
            label3 = new Label();
            label4 = new Label();
            panel3 = new Panel();
            btnOpenFormProgram = new Button();
            btnOpenFormMaterial = new Button();
            resimKutusu = new PictureBox();
            btnResimKaldir = new FontAwesome.Sharp.IconButton();
            btnResimEkle = new FontAwesome.Sharp.IconButton();
            panel5 = new Panel();
            btnGeriDon = new FontAwesome.Sharp.IconButton();
            btnIptal = new FontAwesome.Sharp.IconButton();
            btnYeni = new FontAwesome.Sharp.IconButton();
            btnDuzenle = new FontAwesome.Sharp.IconButton();
            label6 = new Label();
            grpboxUrunAra = new GroupBox();
            dataGridView1 = new DataGridView();
            pnlArama = new Panel();
            btnMalzemeAdiSil = new FontAwesome.Sharp.IconButton();
            btnUrunAdiSil = new FontAwesome.Sharp.IconButton();
            txtMalzemeAra = new TextBox();
            txtUrunAdiAra = new TextBox();
            btnUrunBul = new FontAwesome.Sharp.IconButton();
            lblKayitSayisi = new Label();
            label2 = new Label();
            panel1 = new Panel();
            panel2 = new Panel();
            groupBox1.SuspendLayout();
            panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)resimKutusu).BeginInit();
            panel5.SuspendLayout();
            grpboxUrunAra.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            pnlArama.SuspendLayout();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // txtUrunAdi
            // 
            txtUrunAdi.Enabled = false;
            txtUrunAdi.Font = new Font("Tahoma", 9F, FontStyle.Regular, GraphicsUnit.Point);
            txtUrunAdi.Location = new Point(20, 85);
            txtUrunAdi.Margin = new Padding(4, 3, 4, 3);
            txtUrunAdi.Name = "txtUrunAdi";
            txtUrunAdi.Size = new Size(360, 22);
            txtUrunAdi.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Tahoma", 9F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(20, 68);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(54, 14);
            label1.TabIndex = 2;
            label1.Text = "Ürün Adı";
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
            btnKaydet.Location = new Point(213, 3);
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
            // groupBox1
            // 
            groupBox1.Controls.Add(listMalzeme);
            groupBox1.Controls.Add(listProgramAdi);
            groupBox1.Controls.Add(txtUrunAdi);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(panel3);
            groupBox1.Controls.Add(panel5);
            groupBox1.Dock = DockStyle.Fill;
            groupBox1.Font = new Font("Tahoma", 9F, FontStyle.Bold, GraphicsUnit.Point);
            groupBox1.Location = new Point(0, 10);
            groupBox1.Margin = new Padding(4, 3, 4, 3);
            groupBox1.Name = "groupBox1";
            groupBox1.Padding = new Padding(4, 3, 4, 3);
            groupBox1.Size = new Size(1024, 329);
            groupBox1.TabIndex = 5;
            groupBox1.TabStop = false;
            groupBox1.Text = "Ürün Tanımlama";
            // 
            // listMalzeme
            // 
            listMalzeme.Enabled = false;
            listMalzeme.Font = new Font("Tahoma", 9F, FontStyle.Regular, GraphicsUnit.Point);
            listMalzeme.FormattingEnabled = true;
            listMalzeme.Location = new Point(20, 135);
            listMalzeme.Name = "listMalzeme";
            listMalzeme.Size = new Size(360, 22);
            listMalzeme.TabIndex = 7;
            // 
            // listProgramAdi
            // 
            listProgramAdi.Enabled = false;
            listProgramAdi.Font = new Font("Tahoma", 9F, FontStyle.Regular, GraphicsUnit.Point);
            listProgramAdi.FormattingEnabled = true;
            listProgramAdi.Location = new Point(20, 185);
            listProgramAdi.Name = "listProgramAdi";
            listProgramAdi.Size = new Size(360, 22);
            listProgramAdi.TabIndex = 7;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Tahoma", 9F, FontStyle.Regular, GraphicsUnit.Point);
            label3.Location = new Point(20, 168);
            label3.Margin = new Padding(4, 0, 4, 0);
            label3.Name = "label3";
            label3.Size = new Size(98, 14);
            label3.TabIndex = 2;
            label3.Text = "Tezgah Programı";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Tahoma", 9F, FontStyle.Regular, GraphicsUnit.Point);
            label4.Location = new Point(20, 118);
            label4.Margin = new Padding(4, 0, 4, 0);
            label4.Name = "label4";
            label4.Size = new Size(108, 14);
            label4.TabIndex = 2;
            label4.Text = "İşlenecek Malzeme";
            // 
            // panel3
            // 
            panel3.BorderStyle = BorderStyle.FixedSingle;
            panel3.Controls.Add(btnOpenFormProgram);
            panel3.Controls.Add(btnOpenFormMaterial);
            panel3.Controls.Add(resimKutusu);
            panel3.Controls.Add(btnResimKaldir);
            panel3.Controls.Add(btnResimEkle);
            panel3.Dock = DockStyle.Fill;
            panel3.Location = new Point(4, 53);
            panel3.Name = "panel3";
            panel3.Size = new Size(1016, 273);
            panel3.TabIndex = 9;
            // 
            // btnOpenFormProgram
            // 
            btnOpenFormProgram.Enabled = false;
            btnOpenFormProgram.Font = new Font("Tahoma", 6.75F, FontStyle.Regular, GraphicsUnit.Point);
            btnOpenFormProgram.Location = new Point(376, 130);
            btnOpenFormProgram.Name = "btnOpenFormProgram";
            btnOpenFormProgram.Size = new Size(26, 24);
            btnOpenFormProgram.TabIndex = 8;
            btnOpenFormProgram.Text = "...";
            btnOpenFormProgram.UseVisualStyleBackColor = true;
            btnOpenFormProgram.Click += btnOpenFormProgram_Click;
            // 
            // btnOpenFormMaterial
            // 
            btnOpenFormMaterial.BackColor = Color.FromArgb(43, 84, 126);
            btnOpenFormMaterial.Enabled = false;
            btnOpenFormMaterial.FlatAppearance.BorderSize = 0;
            btnOpenFormMaterial.FlatStyle = FlatStyle.System;
            btnOpenFormMaterial.Font = new Font("Tahoma", 6.75F, FontStyle.Regular, GraphicsUnit.Point);
            btnOpenFormMaterial.Location = new Point(376, 80);
            btnOpenFormMaterial.Name = "btnOpenFormMaterial";
            btnOpenFormMaterial.Size = new Size(26, 24);
            btnOpenFormMaterial.TabIndex = 8;
            btnOpenFormMaterial.Text = "...";
            btnOpenFormMaterial.UseVisualStyleBackColor = false;
            btnOpenFormMaterial.Click += btnOpenFormMaterial_Click;
            // 
            // resimKutusu
            // 
            resimKutusu.BackColor = Color.Gray;
            resimKutusu.BackgroundImage = (Image)resources.GetObject("resimKutusu.BackgroundImage");
            resimKutusu.BackgroundImageLayout = ImageLayout.Stretch;
            resimKutusu.BorderStyle = BorderStyle.FixedSingle;
            resimKutusu.InitialImage = null;
            resimKutusu.Location = new Point(413, 31);
            resimKutusu.Name = "resimKutusu";
            resimKutusu.Size = new Size(230, 230);
            resimKutusu.SizeMode = PictureBoxSizeMode.StretchImage;
            resimKutusu.TabIndex = 0;
            resimKutusu.TabStop = false;
            resimKutusu.DoubleClick += resimKutusu_DoubleClick;
            // 
            // btnResimKaldir
            // 
            btnResimKaldir.AutoSize = true;
            btnResimKaldir.BackColor = Color.FromArgb(43, 84, 126);
            btnResimKaldir.Cursor = Cursors.Hand;
            btnResimKaldir.Enabled = false;
            btnResimKaldir.FlatAppearance.BorderSize = 0;
            btnResimKaldir.FlatStyle = FlatStyle.Flat;
            btnResimKaldir.Font = new Font("Tahoma", 9F, FontStyle.Regular, GraphicsUnit.Point);
            btnResimKaldir.ForeColor = Color.WhiteSmoke;
            btnResimKaldir.IconChar = FontAwesome.Sharp.IconChar.SquareFull;
            btnResimKaldir.IconColor = Color.WhiteSmoke;
            btnResimKaldir.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnResimKaldir.IconSize = 20;
            btnResimKaldir.Location = new Point(650, 62);
            btnResimKaldir.Margin = new Padding(4, 3, 4, 3);
            btnResimKaldir.Name = "btnResimKaldir";
            btnResimKaldir.Size = new Size(112, 26);
            btnResimKaldir.TabIndex = 5;
            btnResimKaldir.Text = "Çizim Kaldır";
            btnResimKaldir.TextAlign = ContentAlignment.MiddleRight;
            btnResimKaldir.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnResimKaldir.UseVisualStyleBackColor = false;
            btnResimKaldir.Click += btnResimKaldir_Click;
            // 
            // btnResimEkle
            // 
            btnResimEkle.AutoSize = true;
            btnResimEkle.BackColor = Color.FromArgb(43, 84, 126);
            btnResimEkle.Cursor = Cursors.Hand;
            btnResimEkle.Enabled = false;
            btnResimEkle.FlatAppearance.BorderSize = 0;
            btnResimEkle.FlatStyle = FlatStyle.Flat;
            btnResimEkle.Font = new Font("Tahoma", 9F, FontStyle.Regular, GraphicsUnit.Point);
            btnResimEkle.ForeColor = Color.WhiteSmoke;
            btnResimEkle.IconChar = FontAwesome.Sharp.IconChar.Images;
            btnResimEkle.IconColor = Color.WhiteSmoke;
            btnResimEkle.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnResimEkle.IconSize = 20;
            btnResimEkle.Location = new Point(650, 31);
            btnResimEkle.Margin = new Padding(4, 3, 4, 3);
            btnResimEkle.Name = "btnResimEkle";
            btnResimEkle.Size = new Size(112, 26);
            btnResimEkle.TabIndex = 5;
            btnResimEkle.Text = "Çizim Ekle";
            btnResimEkle.TextAlign = ContentAlignment.MiddleRight;
            btnResimEkle.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnResimEkle.UseVisualStyleBackColor = false;
            btnResimEkle.Click += btnResimEkle_Click;
            // 
            // panel5
            // 
            panel5.BackColor = Color.FromArgb(43, 84, 126);
            panel5.Controls.Add(btnGeriDon);
            panel5.Controls.Add(btnIptal);
            panel5.Controls.Add(btnYeni);
            panel5.Controls.Add(btnKaydet);
            panel5.Controls.Add(btnDuzenle);
            panel5.Dock = DockStyle.Top;
            panel5.Location = new Point(4, 18);
            panel5.Name = "panel5";
            panel5.Size = new Size(1016, 35);
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
            btnGeriDon.Location = new Point(925, 3);
            btnGeriDon.Margin = new Padding(4, 3, 4, 3);
            btnGeriDon.Name = "btnGeriDon";
            btnGeriDon.Size = new Size(87, 29);
            btnGeriDon.TabIndex = 4;
            btnGeriDon.Text = "Geri Dön";
            btnGeriDon.TextAlign = ContentAlignment.MiddleRight;
            btnGeriDon.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnGeriDon.UseVisualStyleBackColor = false;
            btnGeriDon.Visible = false;
            btnGeriDon.Click += btnGeriDon_Click;
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
            btnIptal.Location = new Point(291, 3);
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
            btnYeni.Size = new Size(94, 29);
            btnYeni.TabIndex = 3;
            btnYeni.TabStop = false;
            btnYeni.Text = "Yeni Ürün";
            btnYeni.TextAlign = ContentAlignment.MiddleRight;
            btnYeni.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnYeni.UseVisualStyleBackColor = false;
            btnYeni.Click += btnYeni_Click;
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
            btnDuzenle.Location = new Point(97, 3);
            btnDuzenle.Margin = new Padding(4, 3, 4, 3);
            btnDuzenle.Name = "btnDuzenle";
            btnDuzenle.Size = new Size(116, 29);
            btnDuzenle.TabIndex = 3;
            btnDuzenle.TabStop = false;
            btnDuzenle.Text = "Ürün Güncelle";
            btnDuzenle.TextAlign = ContentAlignment.MiddleRight;
            btnDuzenle.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnDuzenle.UseVisualStyleBackColor = false;
            btnDuzenle.Click += btnDuzenle_Click;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Tahoma", 9F, FontStyle.Regular, GraphicsUnit.Point);
            label6.ForeColor = Color.Gainsboro;
            label6.Location = new Point(66, 11);
            label6.Margin = new Padding(4, 0, 4, 0);
            label6.Name = "label6";
            label6.Size = new Size(58, 14);
            label6.TabIndex = 2;
            label6.Text = "Ürün Adı:";
            // 
            // grpboxUrunAra
            // 
            grpboxUrunAra.Controls.Add(dataGridView1);
            grpboxUrunAra.Controls.Add(pnlArama);
            grpboxUrunAra.Dock = DockStyle.Fill;
            grpboxUrunAra.Font = new Font("Tahoma", 9F, FontStyle.Bold, GraphicsUnit.Point);
            grpboxUrunAra.Location = new Point(0, 339);
            grpboxUrunAra.Margin = new Padding(4, 3, 4, 3);
            grpboxUrunAra.Name = "grpboxUrunAra";
            grpboxUrunAra.Padding = new Padding(4, 3, 4, 3);
            grpboxUrunAra.Size = new Size(1024, 361);
            grpboxUrunAra.TabIndex = 5;
            grpboxUrunAra.TabStop = false;
            grpboxUrunAra.Text = "Ürün Ara";
            // 
            // dataGridView1
            // 
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = SystemColors.Control;
            dataGridViewCellStyle1.Font = new Font("Tahoma", 8F, FontStyle.Bold, GraphicsUnit.Point);
            dataGridViewCellStyle1.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Control;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
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
            dataGridView1.Location = new Point(4, 83);
            dataGridView1.MultiSelect = false;
            dataGridView1.Name = "dataGridView1";
            dataGridView1.ReadOnly = true;
            dataGridView1.RowHeadersVisible = false;
            dataGridView1.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridView1.RowTemplate.Height = 25;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.Size = new Size(1016, 275);
            dataGridView1.TabIndex = 0;
            dataGridView1.CellClick += dataGridView1_CellClick;
            // 
            // pnlArama
            // 
            pnlArama.BackColor = Color.FromArgb(43, 84, 126);
            pnlArama.Controls.Add(btnMalzemeAdiSil);
            pnlArama.Controls.Add(btnUrunAdiSil);
            pnlArama.Controls.Add(txtMalzemeAra);
            pnlArama.Controls.Add(txtUrunAdiAra);
            pnlArama.Controls.Add(btnUrunBul);
            pnlArama.Controls.Add(lblKayitSayisi);
            pnlArama.Controls.Add(label2);
            pnlArama.Controls.Add(label6);
            pnlArama.Dock = DockStyle.Top;
            pnlArama.Location = new Point(4, 18);
            pnlArama.Name = "pnlArama";
            pnlArama.Size = new Size(1016, 65);
            pnlArama.TabIndex = 1;
            // 
            // btnMalzemeAdiSil
            // 
            btnMalzemeAdiSil.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnMalzemeAdiSil.BackColor = Color.FromArgb(43, 84, 126);
            btnMalzemeAdiSil.Cursor = Cursors.Hand;
            btnMalzemeAdiSil.FlatAppearance.BorderSize = 0;
            btnMalzemeAdiSil.FlatStyle = FlatStyle.Flat;
            btnMalzemeAdiSil.Font = new Font("Tahoma", 9F, FontStyle.Regular, GraphicsUnit.Point);
            btnMalzemeAdiSil.ForeColor = Color.WhiteSmoke;
            btnMalzemeAdiSil.IconChar = FontAwesome.Sharp.IconChar.Xmark;
            btnMalzemeAdiSil.IconColor = Color.WhiteSmoke;
            btnMalzemeAdiSil.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnMalzemeAdiSil.IconSize = 18;
            btnMalzemeAdiSil.Location = new Point(419, 35);
            btnMalzemeAdiSil.Margin = new Padding(4, 3, 4, 3);
            btnMalzemeAdiSil.Name = "btnMalzemeAdiSil";
            btnMalzemeAdiSil.Size = new Size(23, 23);
            btnMalzemeAdiSil.TabIndex = 3;
            btnMalzemeAdiSil.TextAlign = ContentAlignment.MiddleRight;
            btnMalzemeAdiSil.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnMalzemeAdiSil.UseVisualStyleBackColor = false;
            btnMalzemeAdiSil.Click += btnMalzemeAdiSil_Click;
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
            btnUrunAdiSil.Location = new Point(419, 7);
            btnUrunAdiSil.Margin = new Padding(4, 3, 4, 3);
            btnUrunAdiSil.Name = "btnUrunAdiSil";
            btnUrunAdiSil.Size = new Size(23, 23);
            btnUrunAdiSil.TabIndex = 3;
            btnUrunAdiSil.TextAlign = ContentAlignment.MiddleRight;
            btnUrunAdiSil.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnUrunAdiSil.UseVisualStyleBackColor = false;
            btnUrunAdiSil.Click += btnUrunAdiSil_Click;
            // 
            // txtMalzemeAra
            // 
            txtMalzemeAra.Font = new Font("Tahoma", 9F, FontStyle.Regular, GraphicsUnit.Point);
            txtMalzemeAra.Location = new Point(131, 35);
            txtMalzemeAra.Name = "txtMalzemeAra";
            txtMalzemeAra.Size = new Size(287, 22);
            txtMalzemeAra.TabIndex = 6;
            // 
            // txtUrunAdiAra
            // 
            txtUrunAdiAra.Font = new Font("Tahoma", 9F, FontStyle.Regular, GraphicsUnit.Point);
            txtUrunAdiAra.Location = new Point(131, 7);
            txtUrunAdiAra.Name = "txtUrunAdiAra";
            txtUrunAdiAra.Size = new Size(287, 22);
            txtUrunAdiAra.TabIndex = 6;
            // 
            // btnUrunBul
            // 
            btnUrunBul.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnUrunBul.BackColor = Color.FromArgb(66, 115, 29);
            btnUrunBul.Cursor = Cursors.Hand;
            btnUrunBul.FlatAppearance.BorderSize = 0;
            btnUrunBul.FlatStyle = FlatStyle.Flat;
            btnUrunBul.Font = new Font("Tahoma", 9F, FontStyle.Regular, GraphicsUnit.Point);
            btnUrunBul.ForeColor = Color.WhiteSmoke;
            btnUrunBul.IconChar = FontAwesome.Sharp.IconChar.MagnifyingGlass;
            btnUrunBul.IconColor = Color.WhiteSmoke;
            btnUrunBul.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnUrunBul.IconSize = 18;
            btnUrunBul.Location = new Point(474, 7);
            btnUrunBul.Margin = new Padding(4, 3, 4, 3);
            btnUrunBul.Name = "btnUrunBul";
            btnUrunBul.Size = new Size(100, 22);
            btnUrunBul.TabIndex = 8;
            btnUrunBul.Text = "Ürün Bul ";
            btnUrunBul.TextAlign = ContentAlignment.MiddleRight;
            btnUrunBul.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnUrunBul.UseVisualStyleBackColor = false;
            btnUrunBul.Click += btnUrunBul_Click;
            // 
            // lblKayitSayisi
            // 
            lblKayitSayisi.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblKayitSayisi.AutoSize = true;
            lblKayitSayisi.Font = new Font("Tahoma", 9F, FontStyle.Regular, GraphicsUnit.Point);
            lblKayitSayisi.ForeColor = Color.Gainsboro;
            lblKayitSayisi.Location = new Point(925, 11);
            lblKayitSayisi.Margin = new Padding(4, 0, 4, 0);
            lblKayitSayisi.Name = "lblKayitSayisi";
            lblKayitSayisi.Size = new Size(69, 14);
            lblKayitSayisi.TabIndex = 2;
            lblKayitSayisi.Text = "Kayıt Sayısı:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Tahoma", 9F, FontStyle.Regular, GraphicsUnit.Point);
            label2.ForeColor = Color.Gainsboro;
            label2.Location = new Point(12, 38);
            label2.Margin = new Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new Size(112, 14);
            label2.TabIndex = 2;
            label2.Text = "İşlenecek Malzeme:";
            // 
            // panel1
            // 
            panel1.Controls.Add(groupBox1);
            panel1.Controls.Add(panel2);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(1024, 339);
            panel1.TabIndex = 6;
            // 
            // panel2
            // 
            panel2.Dock = DockStyle.Top;
            panel2.Location = new Point(0, 0);
            panel2.Name = "panel2";
            panel2.Size = new Size(1024, 10);
            panel2.TabIndex = 6;
            // 
            // FrmProduct
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(175, 174, 209);
            ClientSize = new Size(1024, 700);
            Controls.Add(grpboxUrunAra);
            Controls.Add(panel1);
            Margin = new Padding(4, 3, 4, 3);
            Name = "FrmProduct";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Ürünler";
            FormClosed += FrmProduct_FormClosed;
            Load += FrmProduct_Load;
            Resize += FrmProduct_Resize;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)resimKutusu).EndInit();
            panel5.ResumeLayout(false);
            panel5.PerformLayout();
            grpboxUrunAra.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            pnlArama.ResumeLayout(false);
            pnlArama.PerformLayout();
            panel1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion
        private TextBox txtUrunAdi;
        private Label label1;
        private FontAwesome.Sharp.IconButton btnKaydet;
        private GroupBox groupBox1;
        private GroupBox grpboxUrunAra;
        private Panel panel1;
        private Panel panel2;
        private FontAwesome.Sharp.IconButton btnYeni;
        private Panel pnlArama;
        private DataGridView dataGridView1;
        private TextBox txtUrunAdiAra;
        private Label lblKayitSayisi;
        private FontAwesome.Sharp.IconButton btnDuzenle;
        private FontAwesome.Sharp.IconButton btnIptal;
        private Panel panel5;
        private Label label6;
        private FontAwesome.Sharp.IconButton btnResimEkle;
        private FontAwesome.Sharp.IconButton btnUrunBul;
        private Label label3;
        private FontAwesome.Sharp.IconButton btnUrunAdiSil;
        private FontAwesome.Sharp.IconButton btnResimKaldir;
        private ComboBox listProgramAdi;
        private ComboBox listMalzeme;
        private Label label4;
        private Button btnOpenFormProgram;
        private Button btnOpenFormMaterial;
        private FontAwesome.Sharp.IconButton btnGeriDon;
        private FontAwesome.Sharp.IconButton btnMalzemeAdiSil;
        private TextBox txtMalzemeAra;
        private Label label2;
        private Panel panel3;
        private PictureBox resimKutusu;
    }
}