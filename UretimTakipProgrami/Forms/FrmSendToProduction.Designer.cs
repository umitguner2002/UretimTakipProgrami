namespace UretimTakipProgrami.Forms
{
    partial class FrmSendToProduction
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
            btnKaydet = new FontAwesome.Sharp.IconButton();
            listTezgah = new ComboBox();
            listAyarOperator = new ComboBox();
            label1 = new Label();
            label8 = new Label();
            panel1 = new Panel();
            btnUygunTezgahSec = new FontAwesome.Sharp.IconButton();
            label2 = new Label();
            panel1.SuspendLayout();
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
            btnIptal.Location = new Point(204, 176);
            btnIptal.Margin = new Padding(4, 3, 4, 3);
            btnIptal.Name = "btnIptal";
            btnIptal.Size = new Size(165, 29);
            btnIptal.TabIndex = 9;
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
            btnKaydet.Location = new Point(12, 176);
            btnKaydet.Margin = new Padding(4, 3, 4, 3);
            btnKaydet.Name = "btnKaydet";
            btnKaydet.Size = new Size(165, 29);
            btnKaydet.TabIndex = 8;
            btnKaydet.TabStop = false;
            btnKaydet.Text = "Kaydet";
            btnKaydet.TextAlign = ContentAlignment.MiddleRight;
            btnKaydet.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnKaydet.UseVisualStyleBackColor = false;
            btnKaydet.Click += btnKaydet_Click;
            // 
            // listTezgah
            // 
            listTezgah.BackColor = SystemColors.Window;
            listTezgah.Font = new Font("Tahoma", 9F, FontStyle.Regular, GraphicsUnit.Point);
            listTezgah.FormattingEnabled = true;
            listTezgah.Location = new Point(11, 85);
            listTezgah.Name = "listTezgah";
            listTezgah.Size = new Size(358, 22);
            listTezgah.TabIndex = 4;
            listTezgah.KeyPress += listTezgah_KeyPress;
            // 
            // listAyarOperator
            // 
            listAyarOperator.BackColor = SystemColors.Window;
            listAyarOperator.Font = new Font("Tahoma", 9F, FontStyle.Regular, GraphicsUnit.Point);
            listAyarOperator.FormattingEnabled = true;
            listAyarOperator.Location = new Point(11, 138);
            listAyarOperator.Name = "listAyarOperator";
            listAyarOperator.Size = new Size(358, 22);
            listAyarOperator.TabIndex = 4;
            listAyarOperator.KeyPress += listAyarOperator_KeyPress;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Tahoma", 9F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(11, 68);
            label1.Name = "label1";
            label1.Size = new Size(71, 14);
            label1.TabIndex = 1;
            label1.Text = "Tezgah Seç";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.BackColor = Color.Transparent;
            label8.Font = new Font("Tahoma", 9F, FontStyle.Regular, GraphicsUnit.Point);
            label8.Location = new Point(11, 122);
            label8.Name = "label8";
            label8.Size = new Size(157, 14);
            label8.TabIndex = 1;
            label8.Text = "Ayar Yapacak Operatör Seç";
            // 
            // panel1
            // 
            panel1.BorderStyle = BorderStyle.FixedSingle;
            panel1.Controls.Add(btnUygunTezgahSec);
            panel1.Controls.Add(btnIptal);
            panel1.Controls.Add(listAyarOperator);
            panel1.Controls.Add(btnKaydet);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(listTezgah);
            panel1.Controls.Add(label8);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(382, 227);
            panel1.TabIndex = 10;
            // 
            // btnUygunTezgahSec
            // 
            btnUygunTezgahSec.BackColor = Color.SaddleBrown;
            btnUygunTezgahSec.Cursor = Cursors.Hand;
            btnUygunTezgahSec.FlatAppearance.BorderSize = 0;
            btnUygunTezgahSec.FlatStyle = FlatStyle.Flat;
            btnUygunTezgahSec.Font = new Font("Tahoma", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            btnUygunTezgahSec.ForeColor = Color.WhiteSmoke;
            btnUygunTezgahSec.IconChar = FontAwesome.Sharp.IconChar.ChartPie;
            btnUygunTezgahSec.IconColor = Color.WhiteSmoke;
            btnUygunTezgahSec.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnUygunTezgahSec.IconSize = 23;
            btnUygunTezgahSec.ImageAlign = ContentAlignment.MiddleRight;
            btnUygunTezgahSec.Location = new Point(204, 54);
            btnUygunTezgahSec.Name = "btnUygunTezgahSec";
            btnUygunTezgahSec.Size = new Size(165, 28);
            btnUygunTezgahSec.TabIndex = 10;
            btnUygunTezgahSec.Text = "Uygun Tezgah Seç";
            btnUygunTezgahSec.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnUygunTezgahSec.UseVisualStyleBackColor = false;
            btnUygunTezgahSec.Click += btnUygunTezgahSec_Click;
            btnUygunTezgahSec.MouseHover += btnUygunTezgahSec_MouseHover;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.Transparent;
            label2.Font = new Font("Tahoma", 12.75F, FontStyle.Bold, GraphicsUnit.Point);
            label2.Location = new Point(11, 8);
            label2.Name = "label2";
            label2.Size = new Size(358, 21);
            label2.TabIndex = 1;
            label2.Text = "Tezgah ve Ayar Yapacak Operatör Seçimi";
            label2.Click += label2_Click;
            // 
            // FrmSendToProduction
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(115, 147, 179);
            ClientSize = new Size(382, 227);
            Controls.Add(panel1);
            Name = "FrmSendToProduction";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "FrmSendToProduction";
            Load += FrmSendToProduction_Load;
            KeyPress += FrmSendToProduction_KeyPress;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
        private ComboBox listTezgah;
        private ComboBox listAyarOperator;
        private Label label8;
        private Label label1;
        private FontAwesome.Sharp.IconButton btnIptal;
        private FontAwesome.Sharp.IconButton btnKaydet;
        private Panel panel1;
        private Label label2;
        private FontAwesome.Sharp.IconButton btnUygunTezgahSec;
    }
}