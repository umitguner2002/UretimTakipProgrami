using System.Windows.Forms;

namespace UretimTakipProgrami.Forms
{
    partial class FrmProductionDefinitions
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
            DataGridViewCellStyle dataGridViewCellStyle15 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle16 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle13 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle14 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle17 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle18 = new DataGridViewCellStyle();
            panel1 = new Panel();
            tabControl1 = new TabControl();
            tabPage1 = new TabPage();
            grpboxTezgahTanimla = new GroupBox();
            panel4 = new Panel();
            btnKaydetMalzeme = new FontAwesome.Sharp.IconButton();
            txtMalzemeDelikCap = new NumericUpDown();
            txtMalzemeDisCap = new NumericUpDown();
            txtMalzemeBoy = new NumericUpDown();
            label13 = new Label();
            label12 = new Label();
            label11 = new Label();
            lblMalzemeSayisi = new Label();
            listMalzemeSekli = new ComboBox();
            listMalzemeTuru = new ComboBox();
            label14 = new Label();
            txtMalzemeAdi = new TextBox();
            label10 = new Label();
            label1 = new Label();
            panel3 = new Panel();
            txtMalzemeSekli = new TextBox();
            label16 = new Label();
            txtMalzemeTuru = new TextBox();
            label15 = new Label();
            btnKaydetMalzemeSekli = new FontAwesome.Sharp.IconButton();
            txtTezgahAdi = new TextBox();
            btnKaydetMalzemeTuru = new FontAwesome.Sharp.IconButton();
            lblMalzemeSekliSayisi = new Label();
            lblMalzemeTuruSayisi = new Label();
            lblTezgahSayisi = new Label();
            label8 = new Label();
            btnKaydetTezgah = new FontAwesome.Sharp.IconButton();
            pnlMachine = new Panel();
            btnFormuKapat1 = new FontAwesome.Sharp.IconButton();
            tabPage2 = new TabPage();
            groupBox1 = new GroupBox();
            panel2 = new Panel();
            panel9 = new Panel();
            panel12 = new Panel();
            listKod = new ListBox();
            panel11 = new Panel();
            btnKodDeğiştir = new FontAwesome.Sharp.IconButton();
            txtKodSatir = new TextBox();
            pnlCodeList = new Panel();
            panel13 = new Panel();
            dataListProgramDef = new DataGridView();
            pnlArama = new Panel();
            btnProgramAdiSil = new FontAwesome.Sharp.IconButton();
            txtProgramAra = new TextBox();
            btnProgramBul = new FontAwesome.Sharp.IconButton();
            lblKayitSayisi = new Label();
            label6 = new Label();
            panel10 = new Panel();
            btnProgramEkle = new FontAwesome.Sharp.IconButton();
            txtProgramAdi = new TextBox();
            label3 = new Label();
            txtProgramKodu = new TextBox();
            label2 = new Label();
            panel5 = new Panel();
            btnFormuKapat2 = new FontAwesome.Sharp.IconButton();
            btnProgramIptal = new FontAwesome.Sharp.IconButton();
            btnYeniProgram = new FontAwesome.Sharp.IconButton();
            btnProgramKaydet = new FontAwesome.Sharp.IconButton();
            lblProgramSayisi = new Label();
            btnProgramGuncelle = new FontAwesome.Sharp.IconButton();
            tabPage3 = new TabPage();
            splitContainer2 = new SplitContainer();
            groupBox2 = new GroupBox();
            dataListProgramKopyala = new DataGridView();
            panel6 = new Panel();
            txtArananProgram2 = new TextBox();
            btnDosyaAl = new FontAwesome.Sharp.IconButton();
            label4 = new Label();
            label5 = new Label();
            groupBox3 = new GroupBox();
            dataListHedef = new DataGridView();
            panel14 = new Panel();
            btnHedefYolSil = new FontAwesome.Sharp.IconButton();
            txtHedefYol = new TextBox();
            btnListeyiTemzile = new FontAwesome.Sharp.IconButton();
            btnListedenKaldir = new FontAwesome.Sharp.IconButton();
            btnDosyaGonder = new FontAwesome.Sharp.IconButton();
            btnKlasorSec = new FontAwesome.Sharp.IconButton();
            label7 = new Label();
            label9 = new Label();
            btnFormuKapat3 = new FontAwesome.Sharp.IconButton();
            panel1.SuspendLayout();
            tabControl1.SuspendLayout();
            tabPage1.SuspendLayout();
            grpboxTezgahTanimla.SuspendLayout();
            panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)txtMalzemeDelikCap).BeginInit();
            ((System.ComponentModel.ISupportInitialize)txtMalzemeDisCap).BeginInit();
            ((System.ComponentModel.ISupportInitialize)txtMalzemeBoy).BeginInit();
            panel3.SuspendLayout();
            pnlMachine.SuspendLayout();
            tabPage2.SuspendLayout();
            groupBox1.SuspendLayout();
            panel2.SuspendLayout();
            panel9.SuspendLayout();
            panel12.SuspendLayout();
            panel11.SuspendLayout();
            pnlCodeList.SuspendLayout();
            panel13.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataListProgramDef).BeginInit();
            pnlArama.SuspendLayout();
            panel10.SuspendLayout();
            panel5.SuspendLayout();
            tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer2).BeginInit();
            splitContainer2.Panel1.SuspendLayout();
            splitContainer2.Panel2.SuspendLayout();
            splitContainer2.SuspendLayout();
            groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataListProgramKopyala).BeginInit();
            panel6.SuspendLayout();
            groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataListHedef).BeginInit();
            panel14.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(tabControl1);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(1145, 567);
            panel1.TabIndex = 0;
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tabPage1);
            tabControl1.Controls.Add(tabPage2);
            tabControl1.Controls.Add(tabPage3);
            tabControl1.Dock = DockStyle.Fill;
            tabControl1.ItemSize = new Size(200, 40);
            tabControl1.Location = new Point(0, 0);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(1145, 567);
            tabControl1.TabIndex = 1;
            tabControl1.DrawItem += tabControl1_DrawItem;
            // 
            // tabPage1
            // 
            tabPage1.BackColor = Color.FromArgb(175, 174, 209);
            tabPage1.BorderStyle = BorderStyle.FixedSingle;
            tabPage1.Controls.Add(grpboxTezgahTanimla);
            tabPage1.Location = new Point(4, 44);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3);
            tabPage1.Size = new Size(1137, 519);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "Tezgah ve Malzeme Tanımla";
            // 
            // grpboxTezgahTanimla
            // 
            grpboxTezgahTanimla.BackColor = Color.FromArgb(175, 174, 209);
            grpboxTezgahTanimla.Controls.Add(panel4);
            grpboxTezgahTanimla.Controls.Add(panel3);
            grpboxTezgahTanimla.Controls.Add(pnlMachine);
            grpboxTezgahTanimla.Dock = DockStyle.Fill;
            grpboxTezgahTanimla.Font = new Font("Tahoma", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            grpboxTezgahTanimla.Location = new Point(3, 3);
            grpboxTezgahTanimla.Name = "grpboxTezgahTanimla";
            grpboxTezgahTanimla.Size = new Size(1129, 511);
            grpboxTezgahTanimla.TabIndex = 2;
            grpboxTezgahTanimla.TabStop = false;
            // 
            // panel4
            // 
            panel4.BorderStyle = BorderStyle.FixedSingle;
            panel4.Controls.Add(btnKaydetMalzeme);
            panel4.Controls.Add(txtMalzemeDelikCap);
            panel4.Controls.Add(txtMalzemeDisCap);
            panel4.Controls.Add(txtMalzemeBoy);
            panel4.Controls.Add(label13);
            panel4.Controls.Add(label12);
            panel4.Controls.Add(label11);
            panel4.Controls.Add(lblMalzemeSayisi);
            panel4.Controls.Add(listMalzemeSekli);
            panel4.Controls.Add(listMalzemeTuru);
            panel4.Controls.Add(label14);
            panel4.Controls.Add(txtMalzemeAdi);
            panel4.Controls.Add(label10);
            panel4.Controls.Add(label1);
            panel4.Dock = DockStyle.Top;
            panel4.Location = new Point(3, 239);
            panel4.Name = "panel4";
            panel4.Size = new Size(1123, 119);
            panel4.TabIndex = 11;
            // 
            // btnKaydetMalzeme
            // 
            btnKaydetMalzeme.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnKaydetMalzeme.BackColor = Color.FromArgb(66, 115, 29);
            btnKaydetMalzeme.Cursor = Cursors.Hand;
            btnKaydetMalzeme.FlatAppearance.BorderSize = 0;
            btnKaydetMalzeme.FlatStyle = FlatStyle.Flat;
            btnKaydetMalzeme.Font = new Font("Tahoma", 9F, FontStyle.Regular, GraphicsUnit.Point);
            btnKaydetMalzeme.ForeColor = Color.WhiteSmoke;
            btnKaydetMalzeme.IconChar = FontAwesome.Sharp.IconChar.Download;
            btnKaydetMalzeme.IconColor = Color.WhiteSmoke;
            btnKaydetMalzeme.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnKaydetMalzeme.IconSize = 20;
            btnKaydetMalzeme.Location = new Point(532, 80);
            btnKaydetMalzeme.Margin = new Padding(4, 3, 4, 3);
            btnKaydetMalzeme.Name = "btnKaydetMalzeme";
            btnKaydetMalzeme.Size = new Size(40, 22);
            btnKaydetMalzeme.TabIndex = 11;
            btnKaydetMalzeme.TextAlign = ContentAlignment.MiddleRight;
            btnKaydetMalzeme.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnKaydetMalzeme.UseVisualStyleBackColor = false;
            btnKaydetMalzeme.Click += btnKaydetMalzeme_Click;
            btnKaydetMalzeme.MouseHover += btnKaydetMalzeme_MouseHover;
            // 
            // txtMalzemeDelikCap
            // 
            txtMalzemeDelikCap.Font = new Font("Tahoma", 9F, FontStyle.Regular, GraphicsUnit.Point);
            txtMalzemeDelikCap.Location = new Point(254, 80);
            txtMalzemeDelikCap.Margin = new Padding(4, 3, 4, 3);
            txtMalzemeDelikCap.Maximum = new decimal(new int[] { 9999, 0, 0, 0 });
            txtMalzemeDelikCap.Name = "txtMalzemeDelikCap";
            txtMalzemeDelikCap.Size = new Size(85, 22);
            txtMalzemeDelikCap.TabIndex = 8;
            txtMalzemeDelikCap.ValueChanged += txtMalzemeDelikCap_ValueChanged;
            txtMalzemeDelikCap.Enter += txtMalzemeDelikCap_Enter;
            txtMalzemeDelikCap.Leave += txtMalzemeDelikCap_Leave;
            // 
            // txtMalzemeDisCap
            // 
            txtMalzemeDisCap.Font = new Font("Tahoma", 9F, FontStyle.Regular, GraphicsUnit.Point);
            txtMalzemeDisCap.Location = new Point(347, 80);
            txtMalzemeDisCap.Margin = new Padding(4, 3, 4, 3);
            txtMalzemeDisCap.Maximum = new decimal(new int[] { 9999, 0, 0, 0 });
            txtMalzemeDisCap.Name = "txtMalzemeDisCap";
            txtMalzemeDisCap.Size = new Size(85, 22);
            txtMalzemeDisCap.TabIndex = 9;
            txtMalzemeDisCap.ValueChanged += txtMalzemeDisCap_ValueChanged;
            txtMalzemeDisCap.Enter += txtMalzemeDisCap_Enter;
            // 
            // txtMalzemeBoy
            // 
            txtMalzemeBoy.Font = new Font("Tahoma", 9F, FontStyle.Regular, GraphicsUnit.Point);
            txtMalzemeBoy.Location = new Point(440, 80);
            txtMalzemeBoy.Margin = new Padding(4, 3, 4, 3);
            txtMalzemeBoy.Maximum = new decimal(new int[] { 9999, 0, 0, 0 });
            txtMalzemeBoy.Name = "txtMalzemeBoy";
            txtMalzemeBoy.Size = new Size(85, 22);
            txtMalzemeBoy.TabIndex = 10;
            txtMalzemeBoy.ValueChanged += txtMalzemeBoy_ValueChanged;
            txtMalzemeBoy.Enter += txtMalzemeBoy_Enter;
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Font = new Font("Tahoma", 9F, FontStyle.Regular, GraphicsUnit.Point);
            label13.Location = new Point(254, 63);
            label13.Margin = new Padding(4, 0, 4, 0);
            label13.Name = "label13";
            label13.Size = new Size(75, 14);
            label13.TabIndex = 11;
            label13.Text = "İç Çap (mm)";
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Font = new Font("Tahoma", 9F, FontStyle.Regular, GraphicsUnit.Point);
            label12.Location = new Point(347, 63);
            label12.Margin = new Padding(4, 0, 4, 0);
            label12.Name = "label12";
            label12.Size = new Size(80, 14);
            label12.TabIndex = 11;
            label12.Text = "Dış Çap (mm)";
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Font = new Font("Tahoma", 9F, FontStyle.Regular, GraphicsUnit.Point);
            label11.Location = new Point(440, 63);
            label11.Margin = new Padding(4, 0, 4, 0);
            label11.Name = "label11";
            label11.Size = new Size(61, 14);
            label11.TabIndex = 11;
            label11.Text = "Boy (mm)";
            // 
            // lblMalzemeSayisi
            // 
            lblMalzemeSayisi.AutoSize = true;
            lblMalzemeSayisi.BackColor = Color.Transparent;
            lblMalzemeSayisi.Font = new Font("Tahoma", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            lblMalzemeSayisi.ForeColor = Color.Black;
            lblMalzemeSayisi.Location = new Point(580, 83);
            lblMalzemeSayisi.Margin = new Padding(4, 0, 4, 0);
            lblMalzemeSayisi.Name = "lblMalzemeSayisi";
            lblMalzemeSayisi.Size = new Size(113, 16);
            lblMalzemeSayisi.TabIndex = 7;
            lblMalzemeSayisi.Text = "Malzeme Sayısı: ";
            // 
            // listMalzemeSekli
            // 
            listMalzemeSekli.Font = new Font("Tahoma", 9F, FontStyle.Regular, GraphicsUnit.Point);
            listMalzemeSekli.FormattingEnabled = true;
            listMalzemeSekli.Location = new Point(21, 80);
            listMalzemeSekli.Name = "listMalzemeSekli";
            listMalzemeSekli.Size = new Size(110, 22);
            listMalzemeSekli.TabIndex = 6;
            listMalzemeSekli.DropDown += listMalzemeSekli_DropDown;
            listMalzemeSekli.SelectedIndexChanged += listMalzemeSekli_SelectedIndexChanged;
            listMalzemeSekli.KeyPress += listMalzemeSekli_KeyPress;
            // 
            // listMalzemeTuru
            // 
            listMalzemeTuru.Font = new Font("Tahoma", 9F, FontStyle.Regular, GraphicsUnit.Point);
            listMalzemeTuru.FormattingEnabled = true;
            listMalzemeTuru.Location = new Point(137, 80);
            listMalzemeTuru.Name = "listMalzemeTuru";
            listMalzemeTuru.Size = new Size(110, 22);
            listMalzemeTuru.TabIndex = 7;
            listMalzemeTuru.DropDown += listMalzemeTuru_DropDown;
            listMalzemeTuru.SelectedIndexChanged += listMalzemeTuru_SelectedIndexChanged;
            listMalzemeTuru.KeyPress += listMalzemeTuru_KeyPress;
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.Font = new Font("Tahoma", 9F, FontStyle.Regular, GraphicsUnit.Point);
            label14.Location = new Point(21, 63);
            label14.Margin = new Padding(4, 0, 4, 0);
            label14.Name = "label14";
            label14.Size = new Size(81, 14);
            label14.TabIndex = 7;
            label14.Text = "Malzeme Şekli";
            // 
            // txtMalzemeAdi
            // 
            txtMalzemeAdi.BackColor = Color.LightYellow;
            txtMalzemeAdi.Enabled = false;
            txtMalzemeAdi.Font = new Font("Tahoma", 9F, FontStyle.Regular, GraphicsUnit.Point);
            txtMalzemeAdi.Location = new Point(20, 30);
            txtMalzemeAdi.Margin = new Padding(4, 3, 4, 3);
            txtMalzemeAdi.Name = "txtMalzemeAdi";
            txtMalzemeAdi.ReadOnly = true;
            txtMalzemeAdi.Size = new Size(504, 22);
            txtMalzemeAdi.TabIndex = 0;
            txtMalzemeAdi.TabStop = false;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new Font("Tahoma", 9F, FontStyle.Regular, GraphicsUnit.Point);
            label10.Location = new Point(137, 63);
            label10.Margin = new Padding(4, 0, 4, 0);
            label10.Name = "label10";
            label10.Size = new Size(83, 14);
            label10.TabIndex = 7;
            label10.Text = "Malzeme Türü";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Tahoma", 9F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(20, 13);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(74, 14);
            label1.TabIndex = 7;
            label1.Text = "Malzeme Adı";
            // 
            // panel3
            // 
            panel3.BorderStyle = BorderStyle.FixedSingle;
            panel3.Controls.Add(txtMalzemeSekli);
            panel3.Controls.Add(label16);
            panel3.Controls.Add(txtMalzemeTuru);
            panel3.Controls.Add(label15);
            panel3.Controls.Add(btnKaydetMalzemeSekli);
            panel3.Controls.Add(txtTezgahAdi);
            panel3.Controls.Add(btnKaydetMalzemeTuru);
            panel3.Controls.Add(lblMalzemeSekliSayisi);
            panel3.Controls.Add(lblMalzemeTuruSayisi);
            panel3.Controls.Add(lblTezgahSayisi);
            panel3.Controls.Add(label8);
            panel3.Controls.Add(btnKaydetTezgah);
            panel3.Dock = DockStyle.Top;
            panel3.Location = new Point(3, 54);
            panel3.Name = "panel3";
            panel3.Size = new Size(1123, 185);
            panel3.TabIndex = 10;
            // 
            // txtMalzemeSekli
            // 
            txtMalzemeSekli.Font = new Font("Tahoma", 9F, FontStyle.Regular, GraphicsUnit.Point);
            txtMalzemeSekli.Location = new Point(21, 135);
            txtMalzemeSekli.Margin = new Padding(4, 3, 4, 3);
            txtMalzemeSekli.Name = "txtMalzemeSekli";
            txtMalzemeSekli.Size = new Size(250, 22);
            txtMalzemeSekli.TabIndex = 4;
            // 
            // label16
            // 
            label16.AutoSize = true;
            label16.Font = new Font("Tahoma", 9F, FontStyle.Regular, GraphicsUnit.Point);
            label16.Location = new Point(21, 118);
            label16.Margin = new Padding(4, 0, 4, 0);
            label16.Name = "label16";
            label16.Size = new Size(177, 14);
            label16.TabIndex = 7;
            label16.Text = "Malzeme Şekli (Dolu, Delikli vb.)";
            // 
            // txtMalzemeTuru
            // 
            txtMalzemeTuru.Font = new Font("Tahoma", 9F, FontStyle.Regular, GraphicsUnit.Point);
            txtMalzemeTuru.Location = new Point(21, 85);
            txtMalzemeTuru.Margin = new Padding(4, 3, 4, 3);
            txtMalzemeTuru.Name = "txtMalzemeTuru";
            txtMalzemeTuru.Size = new Size(250, 22);
            txtMalzemeTuru.TabIndex = 2;
            // 
            // label15
            // 
            label15.AutoSize = true;
            label15.Font = new Font("Tahoma", 9F, FontStyle.Regular, GraphicsUnit.Point);
            label15.Location = new Point(21, 68);
            label15.Margin = new Padding(4, 0, 4, 0);
            label15.Name = "label15";
            label15.Size = new Size(185, 14);
            label15.TabIndex = 7;
            label15.Text = "Malzeme Türü (Demir, Pirinç vb.)";
            // 
            // btnKaydetMalzemeSekli
            // 
            btnKaydetMalzemeSekli.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnKaydetMalzemeSekli.BackColor = Color.FromArgb(66, 115, 29);
            btnKaydetMalzemeSekli.Cursor = Cursors.Hand;
            btnKaydetMalzemeSekli.FlatAppearance.BorderSize = 0;
            btnKaydetMalzemeSekli.FlatStyle = FlatStyle.Flat;
            btnKaydetMalzemeSekli.Font = new Font("Tahoma", 8.25F, FontStyle.Regular, GraphicsUnit.Point);
            btnKaydetMalzemeSekli.ForeColor = Color.WhiteSmoke;
            btnKaydetMalzemeSekli.IconChar = FontAwesome.Sharp.IconChar.Download;
            btnKaydetMalzemeSekli.IconColor = Color.WhiteSmoke;
            btnKaydetMalzemeSekli.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnKaydetMalzemeSekli.IconSize = 20;
            btnKaydetMalzemeSekli.Location = new Point(279, 135);
            btnKaydetMalzemeSekli.Margin = new Padding(4, 3, 4, 3);
            btnKaydetMalzemeSekli.Name = "btnKaydetMalzemeSekli";
            btnKaydetMalzemeSekli.Size = new Size(40, 22);
            btnKaydetMalzemeSekli.TabIndex = 5;
            btnKaydetMalzemeSekli.UseVisualStyleBackColor = false;
            btnKaydetMalzemeSekli.Click += btnKaydetMalzemeSekli_Click;
            btnKaydetMalzemeSekli.MouseHover += btnKaydetMalzemeSekli_MouseHover;
            // 
            // txtTezgahAdi
            // 
            txtTezgahAdi.Font = new Font("Tahoma", 9F, FontStyle.Regular, GraphicsUnit.Point);
            txtTezgahAdi.Location = new Point(21, 35);
            txtTezgahAdi.Margin = new Padding(4, 3, 4, 3);
            txtTezgahAdi.Name = "txtTezgahAdi";
            txtTezgahAdi.Size = new Size(250, 22);
            txtTezgahAdi.TabIndex = 0;
            // 
            // btnKaydetMalzemeTuru
            // 
            btnKaydetMalzemeTuru.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnKaydetMalzemeTuru.BackColor = Color.FromArgb(66, 115, 29);
            btnKaydetMalzemeTuru.Cursor = Cursors.Hand;
            btnKaydetMalzemeTuru.FlatAppearance.BorderSize = 0;
            btnKaydetMalzemeTuru.FlatStyle = FlatStyle.Flat;
            btnKaydetMalzemeTuru.Font = new Font("Tahoma", 8.25F, FontStyle.Regular, GraphicsUnit.Point);
            btnKaydetMalzemeTuru.ForeColor = Color.WhiteSmoke;
            btnKaydetMalzemeTuru.IconChar = FontAwesome.Sharp.IconChar.Download;
            btnKaydetMalzemeTuru.IconColor = Color.WhiteSmoke;
            btnKaydetMalzemeTuru.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnKaydetMalzemeTuru.IconSize = 20;
            btnKaydetMalzemeTuru.Location = new Point(279, 85);
            btnKaydetMalzemeTuru.Margin = new Padding(4, 3, 4, 3);
            btnKaydetMalzemeTuru.Name = "btnKaydetMalzemeTuru";
            btnKaydetMalzemeTuru.Size = new Size(40, 22);
            btnKaydetMalzemeTuru.TabIndex = 3;
            btnKaydetMalzemeTuru.UseVisualStyleBackColor = false;
            btnKaydetMalzemeTuru.Click += btnKaydetMalzemeTuru_Click;
            btnKaydetMalzemeTuru.MouseHover += btnKaydetMalzemeTuru_MouseHover;
            // 
            // lblMalzemeSekliSayisi
            // 
            lblMalzemeSekliSayisi.AutoSize = true;
            lblMalzemeSekliSayisi.BackColor = Color.Transparent;
            lblMalzemeSekliSayisi.Font = new Font("Tahoma", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            lblMalzemeSekliSayisi.ForeColor = Color.Black;
            lblMalzemeSekliSayisi.Location = new Point(327, 138);
            lblMalzemeSekliSayisi.Margin = new Padding(4, 0, 4, 0);
            lblMalzemeSekliSayisi.Name = "lblMalzemeSekliSayisi";
            lblMalzemeSekliSayisi.Size = new Size(146, 16);
            lblMalzemeSekliSayisi.TabIndex = 7;
            lblMalzemeSekliSayisi.Text = "Malzeme Şekli Sayısı: ";
            // 
            // lblMalzemeTuruSayisi
            // 
            lblMalzemeTuruSayisi.AutoSize = true;
            lblMalzemeTuruSayisi.BackColor = Color.Transparent;
            lblMalzemeTuruSayisi.Font = new Font("Tahoma", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            lblMalzemeTuruSayisi.ForeColor = Color.Black;
            lblMalzemeTuruSayisi.Location = new Point(327, 89);
            lblMalzemeTuruSayisi.Margin = new Padding(4, 0, 4, 0);
            lblMalzemeTuruSayisi.Name = "lblMalzemeTuruSayisi";
            lblMalzemeTuruSayisi.Size = new Size(146, 16);
            lblMalzemeTuruSayisi.TabIndex = 7;
            lblMalzemeTuruSayisi.Text = "Malzeme Türü Sayısı: ";
            // 
            // lblTezgahSayisi
            // 
            lblTezgahSayisi.AutoSize = true;
            lblTezgahSayisi.BackColor = Color.Transparent;
            lblTezgahSayisi.Font = new Font("Tahoma", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            lblTezgahSayisi.ForeColor = Color.Black;
            lblTezgahSayisi.Location = new Point(327, 39);
            lblTezgahSayisi.Margin = new Padding(4, 0, 4, 0);
            lblTezgahSayisi.Name = "lblTezgahSayisi";
            lblTezgahSayisi.Size = new Size(103, 16);
            lblTezgahSayisi.TabIndex = 7;
            lblTezgahSayisi.Text = "Tezgah Sayısı: ";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Tahoma", 9F, FontStyle.Regular, GraphicsUnit.Point);
            label8.Location = new Point(21, 18);
            label8.Margin = new Padding(4, 0, 4, 0);
            label8.Name = "label8";
            label8.Size = new Size(68, 14);
            label8.TabIndex = 7;
            label8.Text = "Tezgah Adı";
            // 
            // btnKaydetTezgah
            // 
            btnKaydetTezgah.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnKaydetTezgah.BackColor = Color.FromArgb(66, 115, 29);
            btnKaydetTezgah.Cursor = Cursors.Hand;
            btnKaydetTezgah.FlatAppearance.BorderSize = 0;
            btnKaydetTezgah.FlatStyle = FlatStyle.Flat;
            btnKaydetTezgah.Font = new Font("Tahoma", 8.25F, FontStyle.Regular, GraphicsUnit.Point);
            btnKaydetTezgah.ForeColor = Color.WhiteSmoke;
            btnKaydetTezgah.IconChar = FontAwesome.Sharp.IconChar.Download;
            btnKaydetTezgah.IconColor = Color.WhiteSmoke;
            btnKaydetTezgah.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnKaydetTezgah.IconSize = 20;
            btnKaydetTezgah.Location = new Point(279, 35);
            btnKaydetTezgah.Margin = new Padding(4, 3, 4, 3);
            btnKaydetTezgah.Name = "btnKaydetTezgah";
            btnKaydetTezgah.Size = new Size(40, 22);
            btnKaydetTezgah.TabIndex = 1;
            btnKaydetTezgah.UseVisualStyleBackColor = false;
            btnKaydetTezgah.Click += btnKaydetTezgah_Click;
            btnKaydetTezgah.MouseHover += btnKaydetTezgah_MouseHover;
            // 
            // pnlMachine
            // 
            pnlMachine.BackColor = Color.FromArgb(43, 84, 126);
            pnlMachine.Controls.Add(btnFormuKapat1);
            pnlMachine.Dock = DockStyle.Top;
            pnlMachine.Location = new Point(3, 19);
            pnlMachine.Name = "pnlMachine";
            pnlMachine.Size = new Size(1123, 35);
            pnlMachine.TabIndex = 9;
            // 
            // btnFormuKapat1
            // 
            btnFormuKapat1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnFormuKapat1.AutoSize = true;
            btnFormuKapat1.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnFormuKapat1.BackColor = Color.FromArgb(204, 85, 0);
            btnFormuKapat1.Cursor = Cursors.Hand;
            btnFormuKapat1.FlatAppearance.BorderSize = 0;
            btnFormuKapat1.FlatStyle = FlatStyle.Flat;
            btnFormuKapat1.Font = new Font("Tahoma", 9F, FontStyle.Regular, GraphicsUnit.Point);
            btnFormuKapat1.ForeColor = Color.WhiteSmoke;
            btnFormuKapat1.IconChar = FontAwesome.Sharp.IconChar.PowerOff;
            btnFormuKapat1.IconColor = Color.WhiteSmoke;
            btnFormuKapat1.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnFormuKapat1.IconSize = 23;
            btnFormuKapat1.Location = new Point(1032, 3);
            btnFormuKapat1.Margin = new Padding(4, 3, 4, 3);
            btnFormuKapat1.Name = "btnFormuKapat1";
            btnFormuKapat1.Size = new Size(87, 29);
            btnFormuKapat1.TabIndex = 12;
            btnFormuKapat1.Text = "Geri Dön";
            btnFormuKapat1.TextAlign = ContentAlignment.MiddleRight;
            btnFormuKapat1.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnFormuKapat1.UseVisualStyleBackColor = false;
            btnFormuKapat1.Visible = false;
            btnFormuKapat1.Click += btnFormuKapat1_Click;
            // 
            // tabPage2
            // 
            tabPage2.BackColor = Color.FromArgb(175, 174, 209);
            tabPage2.BorderStyle = BorderStyle.FixedSingle;
            tabPage2.Controls.Add(groupBox1);
            tabPage2.Location = new Point(4, 44);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3);
            tabPage2.Size = new Size(1137, 519);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "Tezgah Programı Tanımla";
            // 
            // groupBox1
            // 
            groupBox1.BackColor = Color.FromArgb(175, 174, 209);
            groupBox1.Controls.Add(panel2);
            groupBox1.Dock = DockStyle.Fill;
            groupBox1.Font = new Font("Tahoma", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            groupBox1.Location = new Point(3, 3);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(1129, 511);
            groupBox1.TabIndex = 1;
            groupBox1.TabStop = false;
            // 
            // panel2
            // 
            panel2.Controls.Add(panel9);
            panel2.Controls.Add(pnlCodeList);
            panel2.Controls.Add(panel5);
            panel2.Dock = DockStyle.Fill;
            panel2.Location = new Point(3, 19);
            panel2.Name = "panel2";
            panel2.Size = new Size(1123, 489);
            panel2.TabIndex = 10;
            // 
            // panel9
            // 
            panel9.BorderStyle = BorderStyle.FixedSingle;
            panel9.Controls.Add(panel12);
            panel9.Controls.Add(panel11);
            panel9.Dock = DockStyle.Fill;
            panel9.Location = new Point(481, 35);
            panel9.Name = "panel9";
            panel9.Size = new Size(642, 454);
            panel9.TabIndex = 11;
            // 
            // panel12
            // 
            panel12.Controls.Add(listKod);
            panel12.Dock = DockStyle.Fill;
            panel12.Location = new Point(0, 57);
            panel12.Name = "panel12";
            panel12.Size = new Size(640, 395);
            panel12.TabIndex = 4;
            // 
            // listKod
            // 
            listKod.Dock = DockStyle.Fill;
            listKod.Font = new Font("Tahoma", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            listKod.FormattingEnabled = true;
            listKod.ItemHeight = 18;
            listKod.Location = new Point(0, 0);
            listKod.Name = "listKod";
            listKod.Size = new Size(640, 395);
            listKod.TabIndex = 0;
            listKod.Click += listKod_Click;
            // 
            // panel11
            // 
            panel11.BackColor = Color.LightGray;
            panel11.Controls.Add(btnKodDeğiştir);
            panel11.Controls.Add(txtKodSatir);
            panel11.Dock = DockStyle.Top;
            panel11.Location = new Point(0, 0);
            panel11.Name = "panel11";
            panel11.Size = new Size(640, 57);
            panel11.TabIndex = 3;
            // 
            // btnKodDeğiştir
            // 
            btnKodDeğiştir.AutoSize = true;
            btnKodDeğiştir.BackColor = Color.Sienna;
            btnKodDeğiştir.Enabled = false;
            btnKodDeğiştir.FlatAppearance.BorderSize = 0;
            btnKodDeğiştir.FlatStyle = FlatStyle.Flat;
            btnKodDeğiştir.Font = new Font("Tahoma", 9F, FontStyle.Regular, GraphicsUnit.Point);
            btnKodDeğiştir.ForeColor = Color.WhiteSmoke;
            btnKodDeğiştir.IconChar = FontAwesome.Sharp.IconChar.Code;
            btnKodDeğiştir.IconColor = Color.WhiteSmoke;
            btnKodDeğiştir.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnKodDeğiştir.IconSize = 20;
            btnKodDeğiştir.Location = new Point(397, 15);
            btnKodDeğiştir.Name = "btnKodDeğiştir";
            btnKodDeğiştir.Size = new Size(183, 26);
            btnKodDeğiştir.TabIndex = 2;
            btnKodDeğiştir.Text = "Seçili Satır Değerini Değiştir";
            btnKodDeğiştir.TextAlign = ContentAlignment.MiddleRight;
            btnKodDeğiştir.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnKodDeğiştir.UseVisualStyleBackColor = false;
            btnKodDeğiştir.Click += btnKodDeğiştir_Click;
            // 
            // txtKodSatir
            // 
            txtKodSatir.Enabled = false;
            txtKodSatir.Font = new Font("Tahoma", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            txtKodSatir.Location = new Point(11, 15);
            txtKodSatir.Name = "txtKodSatir";
            txtKodSatir.Size = new Size(380, 26);
            txtKodSatir.TabIndex = 1;
            // 
            // pnlCodeList
            // 
            pnlCodeList.Controls.Add(panel13);
            pnlCodeList.Controls.Add(panel10);
            pnlCodeList.Dock = DockStyle.Left;
            pnlCodeList.Location = new Point(0, 35);
            pnlCodeList.Name = "pnlCodeList";
            pnlCodeList.Size = new Size(481, 454);
            pnlCodeList.TabIndex = 10;
            // 
            // panel13
            // 
            panel13.Controls.Add(dataListProgramDef);
            panel13.Controls.Add(pnlArama);
            panel13.Dock = DockStyle.Fill;
            panel13.Location = new Point(0, 116);
            panel13.Name = "panel13";
            panel13.Size = new Size(481, 338);
            panel13.TabIndex = 10;
            // 
            // dataListProgramDef
            // 
            dataListProgramDef.AllowUserToAddRows = false;
            dataListProgramDef.AllowUserToDeleteRows = false;
            dataListProgramDef.AllowUserToResizeRows = false;
            dataListProgramDef.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle15.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle15.BackColor = SystemColors.Control;
            dataGridViewCellStyle15.Font = new Font("Tahoma", 8F, FontStyle.Bold, GraphicsUnit.Point);
            dataGridViewCellStyle15.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle15.SelectionBackColor = SystemColors.Control;
            dataGridViewCellStyle15.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle15.WrapMode = DataGridViewTriState.True;
            dataListProgramDef.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle15;
            dataListProgramDef.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle16.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle16.BackColor = SystemColors.Window;
            dataGridViewCellStyle16.Font = new Font("Tahoma", 8F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle16.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle16.SelectionBackColor = Color.Orange;
            dataGridViewCellStyle16.SelectionForeColor = Color.Black;
            dataGridViewCellStyle16.WrapMode = DataGridViewTriState.False;
            dataListProgramDef.DefaultCellStyle = dataGridViewCellStyle16;
            dataListProgramDef.Dock = DockStyle.Fill;
            dataListProgramDef.EnableHeadersVisualStyles = false;
            dataListProgramDef.Font = new Font("Tahoma", 8F, FontStyle.Regular, GraphicsUnit.Point);
            dataListProgramDef.Location = new Point(0, 67);
            dataListProgramDef.MultiSelect = false;
            dataListProgramDef.Name = "dataListProgramDef";
            dataListProgramDef.ReadOnly = true;
            dataListProgramDef.RowHeadersVisible = false;
            dataListProgramDef.RowTemplate.Height = 25;
            dataListProgramDef.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataListProgramDef.Size = new Size(481, 271);
            dataListProgramDef.TabIndex = 0;
            dataListProgramDef.CellClick += dataListProgramDef_CellClick;
            // 
            // pnlArama
            // 
            pnlArama.BackColor = Color.FromArgb(43, 84, 126);
            pnlArama.Controls.Add(btnProgramAdiSil);
            pnlArama.Controls.Add(txtProgramAra);
            pnlArama.Controls.Add(btnProgramBul);
            pnlArama.Controls.Add(lblKayitSayisi);
            pnlArama.Controls.Add(label6);
            pnlArama.Dock = DockStyle.Top;
            pnlArama.Location = new Point(0, 0);
            pnlArama.Name = "pnlArama";
            pnlArama.Size = new Size(481, 67);
            pnlArama.TabIndex = 2;
            // 
            // btnProgramAdiSil
            // 
            btnProgramAdiSil.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnProgramAdiSil.BackColor = Color.FromArgb(43, 84, 126);
            btnProgramAdiSil.Cursor = Cursors.Hand;
            btnProgramAdiSil.FlatAppearance.BorderSize = 0;
            btnProgramAdiSil.FlatStyle = FlatStyle.Flat;
            btnProgramAdiSil.Font = new Font("Tahoma", 9F, FontStyle.Regular, GraphicsUnit.Point);
            btnProgramAdiSil.ForeColor = Color.WhiteSmoke;
            btnProgramAdiSil.IconChar = FontAwesome.Sharp.IconChar.Xmark;
            btnProgramAdiSil.IconColor = Color.WhiteSmoke;
            btnProgramAdiSil.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnProgramAdiSil.IconSize = 18;
            btnProgramAdiSil.Location = new Point(312, 28);
            btnProgramAdiSil.Margin = new Padding(4, 3, 4, 3);
            btnProgramAdiSil.Name = "btnProgramAdiSil";
            btnProgramAdiSil.Size = new Size(23, 23);
            btnProgramAdiSil.TabIndex = 3;
            btnProgramAdiSil.TextAlign = ContentAlignment.MiddleRight;
            btnProgramAdiSil.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnProgramAdiSil.UseVisualStyleBackColor = false;
            btnProgramAdiSil.Click += btnProgramAdiSil_Click;
            // 
            // txtProgramAra
            // 
            txtProgramAra.Font = new Font("Tahoma", 9F, FontStyle.Regular, GraphicsUnit.Point);
            txtProgramAra.Location = new Point(11, 28);
            txtProgramAra.Name = "txtProgramAra";
            txtProgramAra.Size = new Size(299, 22);
            txtProgramAra.TabIndex = 6;
            // 
            // btnProgramBul
            // 
            btnProgramBul.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnProgramBul.BackColor = Color.FromArgb(66, 115, 29);
            btnProgramBul.Cursor = Cursors.Hand;
            btnProgramBul.FlatAppearance.BorderSize = 0;
            btnProgramBul.FlatStyle = FlatStyle.Flat;
            btnProgramBul.Font = new Font("Tahoma", 9F, FontStyle.Regular, GraphicsUnit.Point);
            btnProgramBul.ForeColor = Color.WhiteSmoke;
            btnProgramBul.IconChar = FontAwesome.Sharp.IconChar.MagnifyingGlass;
            btnProgramBul.IconColor = Color.WhiteSmoke;
            btnProgramBul.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnProgramBul.IconSize = 18;
            btnProgramBul.Location = new Point(343, 27);
            btnProgramBul.Margin = new Padding(4, 3, 4, 3);
            btnProgramBul.Name = "btnProgramBul";
            btnProgramBul.Size = new Size(120, 22);
            btnProgramBul.TabIndex = 8;
            btnProgramBul.Text = "Bul ";
            btnProgramBul.TextAlign = ContentAlignment.MiddleRight;
            btnProgramBul.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnProgramBul.UseVisualStyleBackColor = false;
            btnProgramBul.Click += btnProgramBul_Click;
            // 
            // lblKayitSayisi
            // 
            lblKayitSayisi.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblKayitSayisi.AutoSize = true;
            lblKayitSayisi.Font = new Font("Tahoma", 9F, FontStyle.Regular, GraphicsUnit.Point);
            lblKayitSayisi.ForeColor = Color.Gainsboro;
            lblKayitSayisi.Location = new Point(1206, 11);
            lblKayitSayisi.Margin = new Padding(4, 0, 4, 0);
            lblKayitSayisi.Name = "lblKayitSayisi";
            lblKayitSayisi.Size = new Size(69, 14);
            lblKayitSayisi.TabIndex = 2;
            lblKayitSayisi.Text = "Kayıt Sayısı:";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Tahoma", 9F, FontStyle.Regular, GraphicsUnit.Point);
            label6.ForeColor = Color.Gainsboro;
            label6.Location = new Point(11, 11);
            label6.Margin = new Padding(4, 0, 4, 0);
            label6.Name = "label6";
            label6.Size = new Size(77, 14);
            label6.TabIndex = 2;
            label6.Text = "Program Adı:";
            // 
            // panel10
            // 
            panel10.BorderStyle = BorderStyle.FixedSingle;
            panel10.Controls.Add(btnProgramEkle);
            panel10.Controls.Add(txtProgramAdi);
            panel10.Controls.Add(label3);
            panel10.Controls.Add(txtProgramKodu);
            panel10.Controls.Add(label2);
            panel10.Dock = DockStyle.Top;
            panel10.Location = new Point(0, 0);
            panel10.Name = "panel10";
            panel10.Size = new Size(481, 116);
            panel10.TabIndex = 9;
            // 
            // btnProgramEkle
            // 
            btnProgramEkle.AutoSize = true;
            btnProgramEkle.BackColor = Color.FromArgb(66, 115, 29);
            btnProgramEkle.Cursor = Cursors.Hand;
            btnProgramEkle.Enabled = false;
            btnProgramEkle.FlatAppearance.BorderSize = 0;
            btnProgramEkle.FlatStyle = FlatStyle.Flat;
            btnProgramEkle.Font = new Font("Tahoma", 9F, FontStyle.Regular, GraphicsUnit.Point);
            btnProgramEkle.ForeColor = Color.WhiteSmoke;
            btnProgramEkle.IconChar = FontAwesome.Sharp.IconChar.FileCode;
            btnProgramEkle.IconColor = Color.WhiteSmoke;
            btnProgramEkle.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnProgramEkle.IconSize = 16;
            btnProgramEkle.Location = new Point(316, 77);
            btnProgramEkle.Margin = new Padding(4, 3, 4, 3);
            btnProgramEkle.Name = "btnProgramEkle";
            btnProgramEkle.Size = new Size(157, 24);
            btnProgramEkle.TabIndex = 2;
            btnProgramEkle.Text = "Program Ara";
            btnProgramEkle.TextAlign = ContentAlignment.MiddleRight;
            btnProgramEkle.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnProgramEkle.UseVisualStyleBackColor = false;
            btnProgramEkle.Click += btnProgramEkle_Click;
            // 
            // txtProgramAdi
            // 
            txtProgramAdi.Enabled = false;
            txtProgramAdi.Font = new Font("Tahoma", 9F, FontStyle.Regular, GraphicsUnit.Point);
            txtProgramAdi.Location = new Point(10, 79);
            txtProgramAdi.Margin = new Padding(4, 3, 4, 3);
            txtProgramAdi.Name = "txtProgramAdi";
            txtProgramAdi.Size = new Size(300, 22);
            txtProgramAdi.TabIndex = 1;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Tahoma", 9F, FontStyle.Regular, GraphicsUnit.Point);
            label3.Location = new Point(10, 62);
            label3.Margin = new Padding(4, 0, 4, 0);
            label3.Name = "label3";
            label3.Size = new Size(73, 14);
            label3.TabIndex = 7;
            label3.Text = "Program Adı";
            // 
            // txtProgramKodu
            // 
            txtProgramKodu.Enabled = false;
            txtProgramKodu.Font = new Font("Tahoma", 9F, FontStyle.Regular, GraphicsUnit.Point);
            txtProgramKodu.Location = new Point(10, 29);
            txtProgramKodu.Margin = new Padding(4, 3, 4, 3);
            txtProgramKodu.Name = "txtProgramKodu";
            txtProgramKodu.Size = new Size(300, 22);
            txtProgramKodu.TabIndex = 0;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Tahoma", 9F, FontStyle.Regular, GraphicsUnit.Point);
            label2.Location = new Point(10, 12);
            label2.Margin = new Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new Size(84, 14);
            label2.TabIndex = 7;
            label2.Text = "Program Kodu";
            // 
            // panel5
            // 
            panel5.BackColor = Color.FromArgb(43, 84, 126);
            panel5.Controls.Add(btnFormuKapat2);
            panel5.Controls.Add(btnProgramIptal);
            panel5.Controls.Add(btnYeniProgram);
            panel5.Controls.Add(btnProgramKaydet);
            panel5.Controls.Add(lblProgramSayisi);
            panel5.Controls.Add(btnProgramGuncelle);
            panel5.Dock = DockStyle.Top;
            panel5.Location = new Point(0, 0);
            panel5.Name = "panel5";
            panel5.Size = new Size(1123, 35);
            panel5.TabIndex = 9;
            // 
            // btnFormuKapat2
            // 
            btnFormuKapat2.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnFormuKapat2.AutoSize = true;
            btnFormuKapat2.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnFormuKapat2.BackColor = Color.FromArgb(204, 85, 0);
            btnFormuKapat2.Cursor = Cursors.Hand;
            btnFormuKapat2.FlatAppearance.BorderSize = 0;
            btnFormuKapat2.FlatStyle = FlatStyle.Flat;
            btnFormuKapat2.Font = new Font("Tahoma", 9F, FontStyle.Regular, GraphicsUnit.Point);
            btnFormuKapat2.ForeColor = Color.WhiteSmoke;
            btnFormuKapat2.IconChar = FontAwesome.Sharp.IconChar.PowerOff;
            btnFormuKapat2.IconColor = Color.WhiteSmoke;
            btnFormuKapat2.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnFormuKapat2.IconSize = 23;
            btnFormuKapat2.Location = new Point(1032, 3);
            btnFormuKapat2.Margin = new Padding(4, 3, 4, 3);
            btnFormuKapat2.Name = "btnFormuKapat2";
            btnFormuKapat2.Size = new Size(87, 29);
            btnFormuKapat2.TabIndex = 5;
            btnFormuKapat2.Text = "Geri Dön";
            btnFormuKapat2.TextAlign = ContentAlignment.MiddleRight;
            btnFormuKapat2.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnFormuKapat2.UseVisualStyleBackColor = false;
            btnFormuKapat2.Visible = false;
            btnFormuKapat2.Click += btnFormuKapat1_Click;
            // 
            // btnProgramIptal
            // 
            btnProgramIptal.AutoSize = true;
            btnProgramIptal.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnProgramIptal.BackColor = Color.FromArgb(43, 84, 126);
            btnProgramIptal.Cursor = Cursors.Hand;
            btnProgramIptal.Enabled = false;
            btnProgramIptal.FlatAppearance.BorderSize = 0;
            btnProgramIptal.FlatStyle = FlatStyle.Flat;
            btnProgramIptal.Font = new Font("Tahoma", 9F, FontStyle.Regular, GraphicsUnit.Point);
            btnProgramIptal.ForeColor = Color.WhiteSmoke;
            btnProgramIptal.IconChar = FontAwesome.Sharp.IconChar.Xmark;
            btnProgramIptal.IconColor = Color.WhiteSmoke;
            btnProgramIptal.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnProgramIptal.IconSize = 23;
            btnProgramIptal.Location = new Point(246, 3);
            btnProgramIptal.Margin = new Padding(4, 3, 4, 3);
            btnProgramIptal.Name = "btnProgramIptal";
            btnProgramIptal.Size = new Size(64, 29);
            btnProgramIptal.TabIndex = 3;
            btnProgramIptal.Text = "İptal";
            btnProgramIptal.TextAlign = ContentAlignment.MiddleRight;
            btnProgramIptal.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnProgramIptal.UseVisualStyleBackColor = false;
            btnProgramIptal.Click += btnProgramIptal_Click;
            // 
            // btnYeniProgram
            // 
            btnYeniProgram.AutoSize = true;
            btnYeniProgram.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnYeniProgram.BackColor = Color.FromArgb(43, 84, 126);
            btnYeniProgram.Cursor = Cursors.Hand;
            btnYeniProgram.FlatAppearance.BorderSize = 0;
            btnYeniProgram.FlatStyle = FlatStyle.Flat;
            btnYeniProgram.Font = new Font("Tahoma", 9F, FontStyle.Regular, GraphicsUnit.Point);
            btnYeniProgram.ForeColor = Color.WhiteSmoke;
            btnYeniProgram.IconChar = FontAwesome.Sharp.IconChar.FolderPlus;
            btnYeniProgram.IconColor = Color.WhiteSmoke;
            btnYeniProgram.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnYeniProgram.IconSize = 23;
            btnYeniProgram.Location = new Point(3, 3);
            btnYeniProgram.Margin = new Padding(4, 3, 4, 3);
            btnYeniProgram.Name = "btnYeniProgram";
            btnYeniProgram.Size = new Size(64, 29);
            btnYeniProgram.TabIndex = 3;
            btnYeniProgram.Text = "Yeni";
            btnYeniProgram.TextAlign = ContentAlignment.MiddleRight;
            btnYeniProgram.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnYeniProgram.UseVisualStyleBackColor = false;
            btnYeniProgram.Click += btnYeniProgram_Click;
            // 
            // btnProgramKaydet
            // 
            btnProgramKaydet.AutoSize = true;
            btnProgramKaydet.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnProgramKaydet.BackColor = Color.FromArgb(43, 84, 126);
            btnProgramKaydet.Cursor = Cursors.Hand;
            btnProgramKaydet.Enabled = false;
            btnProgramKaydet.FlatAppearance.BorderSize = 0;
            btnProgramKaydet.FlatStyle = FlatStyle.Flat;
            btnProgramKaydet.Font = new Font("Tahoma", 9F, FontStyle.Regular, GraphicsUnit.Point);
            btnProgramKaydet.ForeColor = Color.WhiteSmoke;
            btnProgramKaydet.IconChar = FontAwesome.Sharp.IconChar.FloppyDisk;
            btnProgramKaydet.IconColor = Color.WhiteSmoke;
            btnProgramKaydet.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnProgramKaydet.IconSize = 23;
            btnProgramKaydet.Location = new Point(163, 3);
            btnProgramKaydet.Margin = new Padding(4, 3, 4, 3);
            btnProgramKaydet.Name = "btnProgramKaydet";
            btnProgramKaydet.Size = new Size(78, 29);
            btnProgramKaydet.TabIndex = 3;
            btnProgramKaydet.Text = "Kaydet";
            btnProgramKaydet.TextAlign = ContentAlignment.MiddleRight;
            btnProgramKaydet.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnProgramKaydet.UseVisualStyleBackColor = false;
            btnProgramKaydet.Click += btnProgramKaydet_Click;
            // 
            // lblProgramSayisi
            // 
            lblProgramSayisi.AutoSize = true;
            lblProgramSayisi.BackColor = Color.Transparent;
            lblProgramSayisi.Font = new Font("Tahoma", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
            lblProgramSayisi.ForeColor = Color.Goldenrod;
            lblProgramSayisi.Location = new Point(345, 8);
            lblProgramSayisi.Margin = new Padding(4, 0, 4, 0);
            lblProgramSayisi.Name = "lblProgramSayisi";
            lblProgramSayisi.Size = new Size(122, 18);
            lblProgramSayisi.TabIndex = 7;
            lblProgramSayisi.Text = "Program Sayısı";
            lblProgramSayisi.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // btnProgramGuncelle
            // 
            btnProgramGuncelle.AutoSize = true;
            btnProgramGuncelle.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnProgramGuncelle.BackColor = Color.FromArgb(43, 84, 126);
            btnProgramGuncelle.Cursor = Cursors.Hand;
            btnProgramGuncelle.FlatAppearance.BorderSize = 0;
            btnProgramGuncelle.FlatStyle = FlatStyle.Flat;
            btnProgramGuncelle.Font = new Font("Tahoma", 9F, FontStyle.Regular, GraphicsUnit.Point);
            btnProgramGuncelle.ForeColor = Color.WhiteSmoke;
            btnProgramGuncelle.IconChar = FontAwesome.Sharp.IconChar.PenToSquare;
            btnProgramGuncelle.IconColor = Color.WhiteSmoke;
            btnProgramGuncelle.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnProgramGuncelle.IconSize = 23;
            btnProgramGuncelle.Location = new Point(72, 3);
            btnProgramGuncelle.Margin = new Padding(4, 3, 4, 3);
            btnProgramGuncelle.Name = "btnProgramGuncelle";
            btnProgramGuncelle.Size = new Size(86, 29);
            btnProgramGuncelle.TabIndex = 3;
            btnProgramGuncelle.Text = "Güncelle";
            btnProgramGuncelle.TextAlign = ContentAlignment.MiddleRight;
            btnProgramGuncelle.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnProgramGuncelle.UseVisualStyleBackColor = false;
            btnProgramGuncelle.Click += btnProgramGuncelle_Click;
            // 
            // tabPage3
            // 
            tabPage3.BackColor = Color.FromArgb(175, 174, 209);
            tabPage3.BorderStyle = BorderStyle.FixedSingle;
            tabPage3.Controls.Add(splitContainer2);
            tabPage3.Location = new Point(4, 44);
            tabPage3.Name = "tabPage3";
            tabPage3.Padding = new Padding(3);
            tabPage3.Size = new Size(1137, 519);
            tabPage3.TabIndex = 2;
            tabPage3.Text = "Tezgah Programı Aktarma";
            // 
            // splitContainer2
            // 
            splitContainer2.Dock = DockStyle.Fill;
            splitContainer2.Location = new Point(3, 3);
            splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            splitContainer2.Panel1.Controls.Add(groupBox2);
            splitContainer2.Panel1MinSize = 450;
            // 
            // splitContainer2.Panel2
            // 
            splitContainer2.Panel2.Controls.Add(groupBox3);
            splitContainer2.Panel2MinSize = 300;
            splitContainer2.Size = new Size(1129, 511);
            splitContainer2.SplitterDistance = 558;
            splitContainer2.TabIndex = 0;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(dataListProgramKopyala);
            groupBox2.Controls.Add(panel6);
            groupBox2.Dock = DockStyle.Fill;
            groupBox2.Font = new Font("Tahoma", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            groupBox2.Location = new Point(0, 0);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(558, 511);
            groupBox2.TabIndex = 0;
            groupBox2.TabStop = false;
            groupBox2.Text = "Aktarılacak Program Seçimi";
            // 
            // dataListProgramKopyala
            // 
            dataListProgramKopyala.AllowUserToAddRows = false;
            dataListProgramKopyala.AllowUserToDeleteRows = false;
            dataListProgramKopyala.AllowUserToResizeRows = false;
            dataListProgramKopyala.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataListProgramKopyala.BackgroundColor = SystemColors.Window;
            dataGridViewCellStyle13.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle13.BackColor = SystemColors.Control;
            dataGridViewCellStyle13.Font = new Font("Tahoma", 8F, FontStyle.Bold, GraphicsUnit.Point);
            dataGridViewCellStyle13.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle13.SelectionBackColor = SystemColors.Control;
            dataGridViewCellStyle13.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle13.WrapMode = DataGridViewTriState.True;
            dataListProgramKopyala.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle13;
            dataListProgramKopyala.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle14.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle14.BackColor = SystemColors.Window;
            dataGridViewCellStyle14.Font = new Font("Tahoma", 8F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle14.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle14.SelectionBackColor = Color.Orange;
            dataGridViewCellStyle14.SelectionForeColor = Color.Black;
            dataGridViewCellStyle14.WrapMode = DataGridViewTriState.False;
            dataListProgramKopyala.DefaultCellStyle = dataGridViewCellStyle14;
            dataListProgramKopyala.Dock = DockStyle.Fill;
            dataListProgramKopyala.EnableHeadersVisualStyles = false;
            dataListProgramKopyala.Font = new Font("Tahoma", 8F, FontStyle.Regular, GraphicsUnit.Point);
            dataListProgramKopyala.Location = new Point(3, 142);
            dataListProgramKopyala.MultiSelect = false;
            dataListProgramKopyala.Name = "dataListProgramKopyala";
            dataListProgramKopyala.ReadOnly = true;
            dataListProgramKopyala.RowHeadersVisible = false;
            dataListProgramKopyala.RowTemplate.Height = 25;
            dataListProgramKopyala.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataListProgramKopyala.Size = new Size(552, 366);
            dataListProgramKopyala.TabIndex = 3;
            dataListProgramKopyala.CellClick += dataListProgramKopyala_CellClick;
            // 
            // panel6
            // 
            panel6.BackColor = Color.FromArgb(43, 84, 126);
            panel6.Controls.Add(btnFormuKapat3);
            panel6.Controls.Add(txtArananProgram2);
            panel6.Controls.Add(btnDosyaAl);
            panel6.Controls.Add(label4);
            panel6.Controls.Add(label5);
            panel6.Dock = DockStyle.Top;
            panel6.Location = new Point(3, 19);
            panel6.Name = "panel6";
            panel6.Size = new Size(552, 123);
            panel6.TabIndex = 4;
            // 
            // txtArananProgram2
            // 
            txtArananProgram2.Font = new Font("Tahoma", 9F, FontStyle.Regular, GraphicsUnit.Point);
            txtArananProgram2.Location = new Point(11, 28);
            txtArananProgram2.Name = "txtArananProgram2";
            txtArananProgram2.Size = new Size(329, 22);
            txtArananProgram2.TabIndex = 6;
            txtArananProgram2.TextChanged += txtArananProgram2_TextChanged;
            // 
            // btnDosyaAl
            // 
            btnDosyaAl.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnDosyaAl.BackColor = Color.FromArgb(66, 115, 29);
            btnDosyaAl.Cursor = Cursors.Hand;
            btnDosyaAl.FlatAppearance.BorderSize = 0;
            btnDosyaAl.FlatStyle = FlatStyle.Flat;
            btnDosyaAl.Font = new Font("Tahoma", 9F, FontStyle.Regular, GraphicsUnit.Point);
            btnDosyaAl.ForeColor = Color.WhiteSmoke;
            btnDosyaAl.IconChar = FontAwesome.Sharp.IconChar.RightToBracket;
            btnDosyaAl.IconColor = Color.WhiteSmoke;
            btnDosyaAl.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnDosyaAl.IconSize = 18;
            btnDosyaAl.Location = new Point(11, 56);
            btnDosyaAl.Margin = new Padding(4, 3, 4, 3);
            btnDosyaAl.Name = "btnDosyaAl";
            btnDosyaAl.Size = new Size(329, 23);
            btnDosyaAl.TabIndex = 8;
            btnDosyaAl.Text = "Seçili Dosyayı Al";
            btnDosyaAl.TextAlign = ContentAlignment.MiddleRight;
            btnDosyaAl.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnDosyaAl.UseVisualStyleBackColor = false;
            btnDosyaAl.Click += btnDosyaAl_Click;
            // 
            // label4
            // 
            label4.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label4.AutoSize = true;
            label4.Font = new Font("Tahoma", 9F, FontStyle.Regular, GraphicsUnit.Point);
            label4.ForeColor = Color.Gainsboro;
            label4.Location = new Point(1573, 11);
            label4.Margin = new Padding(4, 0, 4, 0);
            label4.Name = "label4";
            label4.Size = new Size(69, 14);
            label4.TabIndex = 2;
            label4.Text = "Kayıt Sayısı:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Tahoma", 9F, FontStyle.Regular, GraphicsUnit.Point);
            label5.ForeColor = Color.Gainsboro;
            label5.Location = new Point(11, 11);
            label5.Margin = new Padding(4, 0, 4, 0);
            label5.Name = "label5";
            label5.Size = new Size(77, 14);
            label5.TabIndex = 2;
            label5.Text = "Program Adı:";
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(dataListHedef);
            groupBox3.Controls.Add(panel14);
            groupBox3.Dock = DockStyle.Fill;
            groupBox3.Font = new Font("Tahoma", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            groupBox3.Location = new Point(0, 0);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(567, 511);
            groupBox3.TabIndex = 0;
            groupBox3.TabStop = false;
            groupBox3.Text = "Aktarılacak Hedef Klasör / Hafıza Kartı";
            // 
            // dataListHedef
            // 
            dataListHedef.AllowUserToAddRows = false;
            dataListHedef.AllowUserToDeleteRows = false;
            dataListHedef.AllowUserToResizeRows = false;
            dataListHedef.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataListHedef.BackgroundColor = SystemColors.Window;
            dataGridViewCellStyle17.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle17.BackColor = SystemColors.Control;
            dataGridViewCellStyle17.Font = new Font("Tahoma", 8F, FontStyle.Bold, GraphicsUnit.Point);
            dataGridViewCellStyle17.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle17.SelectionBackColor = SystemColors.Control;
            dataGridViewCellStyle17.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle17.WrapMode = DataGridViewTriState.True;
            dataListHedef.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle17;
            dataListHedef.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle18.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle18.BackColor = SystemColors.Window;
            dataGridViewCellStyle18.Font = new Font("Tahoma", 8F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle18.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle18.SelectionBackColor = Color.Orange;
            dataGridViewCellStyle18.SelectionForeColor = Color.Black;
            dataGridViewCellStyle18.WrapMode = DataGridViewTriState.False;
            dataListHedef.DefaultCellStyle = dataGridViewCellStyle18;
            dataListHedef.Dock = DockStyle.Fill;
            dataListHedef.EnableHeadersVisualStyles = false;
            dataListHedef.Font = new Font("Tahoma", 8F, FontStyle.Regular, GraphicsUnit.Point);
            dataListHedef.Location = new Point(3, 142);
            dataListHedef.MultiSelect = false;
            dataListHedef.Name = "dataListHedef";
            dataListHedef.ReadOnly = true;
            dataListHedef.RowHeadersVisible = false;
            dataListHedef.RowTemplate.Height = 25;
            dataListHedef.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataListHedef.Size = new Size(561, 366);
            dataListHedef.TabIndex = 6;
            dataListHedef.CellClick += dataListHedef_CellClick;
            // 
            // panel14
            // 
            panel14.BackColor = Color.FromArgb(43, 84, 126);
            panel14.Controls.Add(btnHedefYolSil);
            panel14.Controls.Add(txtHedefYol);
            panel14.Controls.Add(btnListeyiTemzile);
            panel14.Controls.Add(btnListedenKaldir);
            panel14.Controls.Add(btnDosyaGonder);
            panel14.Controls.Add(btnKlasorSec);
            panel14.Controls.Add(label7);
            panel14.Controls.Add(label9);
            panel14.Dock = DockStyle.Top;
            panel14.Location = new Point(3, 19);
            panel14.Name = "panel14";
            panel14.Size = new Size(561, 123);
            panel14.TabIndex = 5;
            // 
            // btnHedefYolSil
            // 
            btnHedefYolSil.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnHedefYolSil.BackColor = Color.FromArgb(43, 84, 126);
            btnHedefYolSil.Cursor = Cursors.Hand;
            btnHedefYolSil.FlatAppearance.BorderSize = 0;
            btnHedefYolSil.FlatStyle = FlatStyle.Flat;
            btnHedefYolSil.Font = new Font("Tahoma", 9F, FontStyle.Regular, GraphicsUnit.Point);
            btnHedefYolSil.ForeColor = Color.WhiteSmoke;
            btnHedefYolSil.IconChar = FontAwesome.Sharp.IconChar.Xmark;
            btnHedefYolSil.IconColor = Color.WhiteSmoke;
            btnHedefYolSil.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnHedefYolSil.IconSize = 18;
            btnHedefYolSil.Location = new Point(525, 28);
            btnHedefYolSil.Margin = new Padding(4, 3, 4, 3);
            btnHedefYolSil.Name = "btnHedefYolSil";
            btnHedefYolSil.Size = new Size(23, 23);
            btnHedefYolSil.TabIndex = 3;
            btnHedefYolSil.TextAlign = ContentAlignment.MiddleRight;
            btnHedefYolSil.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnHedefYolSil.UseVisualStyleBackColor = false;
            btnHedefYolSil.Click += btnHedefYolSil_Click;
            // 
            // txtHedefYol
            // 
            txtHedefYol.Enabled = false;
            txtHedefYol.Font = new Font("Tahoma", 9F, FontStyle.Regular, GraphicsUnit.Point);
            txtHedefYol.Location = new Point(11, 28);
            txtHedefYol.Name = "txtHedefYol";
            txtHedefYol.Size = new Size(513, 22);
            txtHedefYol.TabIndex = 6;
            // 
            // btnListeyiTemzile
            // 
            btnListeyiTemzile.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnListeyiTemzile.BackColor = Color.FromArgb(145, 95, 109);
            btnListeyiTemzile.Cursor = Cursors.Hand;
            btnListeyiTemzile.FlatAppearance.BorderSize = 0;
            btnListeyiTemzile.FlatStyle = FlatStyle.Flat;
            btnListeyiTemzile.Font = new Font("Tahoma", 9F, FontStyle.Regular, GraphicsUnit.Point);
            btnListeyiTemzile.ForeColor = Color.WhiteSmoke;
            btnListeyiTemzile.IconChar = FontAwesome.Sharp.IconChar.Broom;
            btnListeyiTemzile.IconColor = Color.WhiteSmoke;
            btnListeyiTemzile.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnListeyiTemzile.IconSize = 18;
            btnListeyiTemzile.Location = new Point(369, 56);
            btnListeyiTemzile.Margin = new Padding(4, 3, 4, 3);
            btnListeyiTemzile.Name = "btnListeyiTemzile";
            btnListeyiTemzile.Size = new Size(155, 26);
            btnListeyiTemzile.TabIndex = 8;
            btnListeyiTemzile.Text = "Listeyi Temizle";
            btnListeyiTemzile.TextAlign = ContentAlignment.MiddleRight;
            btnListeyiTemzile.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnListeyiTemzile.UseVisualStyleBackColor = false;
            btnListeyiTemzile.Click += btnListeyiTemzile_Click;
            // 
            // btnListedenKaldir
            // 
            btnListedenKaldir.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnListedenKaldir.BackColor = Color.FromArgb(227, 66, 52);
            btnListedenKaldir.Cursor = Cursors.Hand;
            btnListedenKaldir.FlatAppearance.BorderSize = 0;
            btnListedenKaldir.FlatStyle = FlatStyle.Flat;
            btnListedenKaldir.Font = new Font("Tahoma", 9F, FontStyle.Regular, GraphicsUnit.Point);
            btnListedenKaldir.ForeColor = Color.WhiteSmoke;
            btnListedenKaldir.IconChar = FontAwesome.Sharp.IconChar.Trash;
            btnListedenKaldir.IconColor = Color.WhiteSmoke;
            btnListedenKaldir.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnListedenKaldir.IconSize = 18;
            btnListedenKaldir.Location = new Point(206, 56);
            btnListedenKaldir.Margin = new Padding(4, 3, 4, 3);
            btnListedenKaldir.Name = "btnListedenKaldir";
            btnListedenKaldir.Size = new Size(155, 26);
            btnListedenKaldir.TabIndex = 8;
            btnListedenKaldir.Text = "Seçili Dosyayı Kaldır";
            btnListedenKaldir.TextAlign = ContentAlignment.MiddleRight;
            btnListedenKaldir.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnListedenKaldir.UseVisualStyleBackColor = false;
            btnListedenKaldir.Click += btnListedenKaldir_Click;
            // 
            // btnDosyaGonder
            // 
            btnDosyaGonder.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnDosyaGonder.BackColor = Color.FromArgb(66, 115, 29);
            btnDosyaGonder.Cursor = Cursors.Hand;
            btnDosyaGonder.FlatAppearance.BorderSize = 0;
            btnDosyaGonder.FlatStyle = FlatStyle.Flat;
            btnDosyaGonder.Font = new Font("Tahoma", 9F, FontStyle.Regular, GraphicsUnit.Point);
            btnDosyaGonder.ForeColor = Color.WhiteSmoke;
            btnDosyaGonder.IconChar = FontAwesome.Sharp.IconChar.ArrowsTurnRight;
            btnDosyaGonder.IconColor = Color.WhiteSmoke;
            btnDosyaGonder.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnDosyaGonder.IconSize = 18;
            btnDosyaGonder.Location = new Point(11, 88);
            btnDosyaGonder.Margin = new Padding(4, 3, 4, 3);
            btnDosyaGonder.Name = "btnDosyaGonder";
            btnDosyaGonder.Size = new Size(513, 26);
            btnDosyaGonder.TabIndex = 8;
            btnDosyaGonder.Text = "Tüm Dosyaları Gönder";
            btnDosyaGonder.TextAlign = ContentAlignment.MiddleRight;
            btnDosyaGonder.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnDosyaGonder.UseVisualStyleBackColor = false;
            btnDosyaGonder.Click += btnDosyaGonder_Click;
            // 
            // btnKlasorSec
            // 
            btnKlasorSec.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnKlasorSec.BackColor = Color.FromArgb(59, 113, 202);
            btnKlasorSec.Cursor = Cursors.Hand;
            btnKlasorSec.FlatAppearance.BorderSize = 0;
            btnKlasorSec.FlatStyle = FlatStyle.Flat;
            btnKlasorSec.Font = new Font("Tahoma", 9F, FontStyle.Regular, GraphicsUnit.Point);
            btnKlasorSec.ForeColor = Color.WhiteSmoke;
            btnKlasorSec.IconChar = FontAwesome.Sharp.IconChar.FolderBlank;
            btnKlasorSec.IconColor = Color.WhiteSmoke;
            btnKlasorSec.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnKlasorSec.IconSize = 18;
            btnKlasorSec.Location = new Point(11, 56);
            btnKlasorSec.Margin = new Padding(4, 3, 4, 3);
            btnKlasorSec.Name = "btnKlasorSec";
            btnKlasorSec.Size = new Size(155, 26);
            btnKlasorSec.TabIndex = 8;
            btnKlasorSec.Text = "Klasör Seç";
            btnKlasorSec.TextAlign = ContentAlignment.MiddleRight;
            btnKlasorSec.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnKlasorSec.UseVisualStyleBackColor = false;
            btnKlasorSec.Click += btnKlasorSec_Click;
            // 
            // label7
            // 
            label7.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label7.AutoSize = true;
            label7.Font = new Font("Tahoma", 9F, FontStyle.Regular, GraphicsUnit.Point);
            label7.ForeColor = Color.Gainsboro;
            label7.Location = new Point(1824, 11);
            label7.Margin = new Padding(4, 0, 4, 0);
            label7.Name = "label7";
            label7.Size = new Size(69, 14);
            label7.TabIndex = 2;
            label7.Text = "Kayıt Sayısı:";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Tahoma", 9F, FontStyle.Regular, GraphicsUnit.Point);
            label9.ForeColor = Color.Gainsboro;
            label9.Location = new Point(11, 11);
            label9.Margin = new Padding(4, 0, 4, 0);
            label9.Name = "label9";
            label9.Size = new Size(155, 14);
            label9.TabIndex = 2;
            label9.Text = "Kopyalanacak Hedef Klasör:";
            // 
            // btnFormuKapat3
            // 
            btnFormuKapat3.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnFormuKapat3.AutoSize = true;
            btnFormuKapat3.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnFormuKapat3.BackColor = Color.FromArgb(204, 85, 0);
            btnFormuKapat3.Cursor = Cursors.Hand;
            btnFormuKapat3.FlatAppearance.BorderSize = 0;
            btnFormuKapat3.FlatStyle = FlatStyle.Flat;
            btnFormuKapat3.Font = new Font("Tahoma", 9F, FontStyle.Regular, GraphicsUnit.Point);
            btnFormuKapat3.ForeColor = Color.WhiteSmoke;
            btnFormuKapat3.IconChar = FontAwesome.Sharp.IconChar.PowerOff;
            btnFormuKapat3.IconColor = Color.WhiteSmoke;
            btnFormuKapat3.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnFormuKapat3.IconSize = 23;
            btnFormuKapat3.Location = new Point(461, 24);
            btnFormuKapat3.Margin = new Padding(4, 3, 4, 3);
            btnFormuKapat3.Name = "btnFormuKapat3";
            btnFormuKapat3.Size = new Size(87, 29);
            btnFormuKapat3.TabIndex = 9;
            btnFormuKapat3.Text = "Geri Dön";
            btnFormuKapat3.TextAlign = ContentAlignment.MiddleRight;
            btnFormuKapat3.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnFormuKapat3.UseVisualStyleBackColor = false;
            btnFormuKapat3.Visible = false;
            btnFormuKapat3.Click += btnFormuKapat3_Click;
            // 
            // FrmProductionDefinitions
            // 
            AutoScaleDimensions = new SizeF(7F, 14F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(175, 174, 209);
            ClientSize = new Size(1145, 567);
            Controls.Add(panel1);
            Font = new Font("Tahoma", 9F, FontStyle.Regular, GraphicsUnit.Point);
            Name = "FrmProductionDefinitions";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Tezgah ve Operatör Tanımlama";
            FormClosed += FrmProductionDefinitions_FormClosed;
            Load += FrmProductionDefinitions_Load;
            panel1.ResumeLayout(false);
            tabControl1.ResumeLayout(false);
            tabPage1.ResumeLayout(false);
            grpboxTezgahTanimla.ResumeLayout(false);
            panel4.ResumeLayout(false);
            panel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)txtMalzemeDelikCap).EndInit();
            ((System.ComponentModel.ISupportInitialize)txtMalzemeDisCap).EndInit();
            ((System.ComponentModel.ISupportInitialize)txtMalzemeBoy).EndInit();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            pnlMachine.ResumeLayout(false);
            pnlMachine.PerformLayout();
            tabPage2.ResumeLayout(false);
            groupBox1.ResumeLayout(false);
            panel2.ResumeLayout(false);
            panel9.ResumeLayout(false);
            panel12.ResumeLayout(false);
            panel11.ResumeLayout(false);
            panel11.PerformLayout();
            pnlCodeList.ResumeLayout(false);
            panel13.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataListProgramDef).EndInit();
            pnlArama.ResumeLayout(false);
            pnlArama.PerformLayout();
            panel10.ResumeLayout(false);
            panel10.PerformLayout();
            panel5.ResumeLayout(false);
            panel5.PerformLayout();
            tabPage3.ResumeLayout(false);
            splitContainer2.Panel1.ResumeLayout(false);
            splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer2).EndInit();
            splitContainer2.ResumeLayout(false);
            groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataListProgramKopyala).EndInit();
            panel6.ResumeLayout(false);
            panel6.PerformLayout();
            groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataListHedef).EndInit();
            panel14.ResumeLayout(false);
            panel14.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private TabControl tabControl1;
        private TabPage tabPage1;
        private TabPage tabPage2;
        private GroupBox groupBox1;
        private DataGridView dataListProgramDef;
        private Panel panel2;
        private TextBox txtProgramKodu;
        private Label label2;
        private Panel panel5;
        private FontAwesome.Sharp.IconButton btnProgramIptal;
        private FontAwesome.Sharp.IconButton btnYeniProgram;
        private FontAwesome.Sharp.IconButton btnProgramKaydet;
        private FontAwesome.Sharp.IconButton btnProgramGuncelle;
        private Panel pnlCodeList;
        private TextBox txtProgramAdi;
        private Label label3;
        private TabPage tabPage3;
        private Panel panel9;
        private Panel panel10;
        private FontAwesome.Sharp.IconButton btnProgramEkle;
        private ListBox listKod;
        private TextBox txtKodSatir;
        private FontAwesome.Sharp.IconButton btnKodDeğiştir;
        private Panel panel12;
        private Panel panel11;
        private Panel panel13;
        private Panel pnlArama;
        private FontAwesome.Sharp.IconButton btnProgramAdiSil;
        private TextBox txtProgramAra;
        private FontAwesome.Sharp.IconButton btnProgramBul;
        private Label lblKayitSayisi;
        private Label label6;
        private SplitContainer splitContainer2;
        private GroupBox groupBox2;
        private DataGridView dataListProgramKopyala;
        private Panel panel6;
        private TextBox txtArananProgram2;
        private FontAwesome.Sharp.IconButton btnDosyaAl;
        private Label label4;
        private Label label5;
        private GroupBox groupBox3;
        private Panel panel14;
        private FontAwesome.Sharp.IconButton btnHedefYolSil;
        private TextBox txtHedefYol;
        private FontAwesome.Sharp.IconButton btnKlasorSec;
        private Label label7;
        private Label label9;
        private FontAwesome.Sharp.IconButton btnDosyaGonder;
        private DataGridView dataGridView1;
        private DataGridView dataListHedef;
        private FontAwesome.Sharp.IconButton btnListedenKaldir;
        private FontAwesome.Sharp.IconButton btnListeyiTemzile;
        private GroupBox grpboxTezgahTanimla;
        private Panel panel3;
        private TextBox txtTezgahAdi;
        private Label label8;
        private FontAwesome.Sharp.IconButton btnKaydetTezgah;
        private FontAwesome.Sharp.IconButton btnFormuKapat1;
        private FontAwesome.Sharp.IconButton btnFormuKapat2;
        private Panel pnlMachine;
        private TextBox txtMalzemeSekli;
        private Label label16;
        private TextBox txtMalzemeTuru;
        private Label label15;
        private FontAwesome.Sharp.IconButton btnKaydetMalzemeSekli;
        private FontAwesome.Sharp.IconButton btnKaydetMalzemeTuru;
        private Panel panel4;
        private FontAwesome.Sharp.IconButton btnKaydetMalzeme;
        private NumericUpDown txtMalzemeDelikCap;
        private NumericUpDown txtMalzemeDisCap;
        private NumericUpDown txtMalzemeBoy;
        private Label label13;
        private Label label12;
        private Label label11;
        private ComboBox listMalzemeSekli;
        private ComboBox listMalzemeTuru;
        private Label label14;
        private TextBox txtMalzemeAdi;
        private Label label10;
        private Label label1;
        private Label lblTezgahSayisi;
        private Label lblMalzemeTuruSayisi;
        private Label lblMalzemeSekliSayisi;
        private Label lblMalzemeSayisi;
        private Label lblProgramSayisi;
        private FontAwesome.Sharp.IconButton btnFormuKapat3;
    }
}