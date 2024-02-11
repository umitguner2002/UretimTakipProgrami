namespace UretimTakipProgrami.Forms
{
    partial class FrmTransferOrderToDifferentMachine
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
            listTezgah = new ComboBox();
            btnIptal = new FontAwesome.Sharp.IconButton();
            btnKaydet = new FontAwesome.Sharp.IconButton();
            label2 = new Label();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Tahoma", 9F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(12, 64);
            label1.Name = "label1";
            label1.Size = new Size(71, 14);
            label1.TabIndex = 5;
            label1.Text = "Tezgah Seç";
            // 
            // listTezgah
            // 
            listTezgah.BackColor = SystemColors.Window;
            listTezgah.Font = new Font("Tahoma", 9F, FontStyle.Regular, GraphicsUnit.Point);
            listTezgah.FormattingEnabled = true;
            listTezgah.Location = new Point(12, 81);
            listTezgah.Name = "listTezgah";
            listTezgah.Size = new Size(358, 22);
            listTezgah.TabIndex = 6;
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
            btnIptal.Location = new Point(204, 125);
            btnIptal.Margin = new Padding(4, 3, 4, 3);
            btnIptal.Name = "btnIptal";
            btnIptal.Size = new Size(165, 29);
            btnIptal.TabIndex = 12;
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
            btnKaydet.Location = new Point(12, 125);
            btnKaydet.Margin = new Padding(4, 3, 4, 3);
            btnKaydet.Name = "btnKaydet";
            btnKaydet.Size = new Size(165, 29);
            btnKaydet.TabIndex = 11;
            btnKaydet.TabStop = false;
            btnKaydet.Text = "Kaydet";
            btnKaydet.TextAlign = ContentAlignment.MiddleRight;
            btnKaydet.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnKaydet.UseVisualStyleBackColor = false;
            btnKaydet.Click += btnKaydet_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.Transparent;
            label2.Font = new Font("Tahoma", 12.75F, FontStyle.Bold, GraphicsUnit.Point);
            label2.Location = new Point(42, 20);
            label2.Name = "label2";
            label2.Size = new Size(297, 21);
            label2.TabIndex = 10;
            label2.Text = "İş Emri Aktarılacak Tezgah Seçimi";
            // 
            // FrmTransferOrderToDifferentMachine
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(115, 147, 179);
            ClientSize = new Size(382, 175);
            Controls.Add(btnIptal);
            Controls.Add(btnKaydet);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(listTezgah);
            Name = "FrmTransferOrderToDifferentMachine";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "FrmTransferOrderToDifferentMachine";
            Load += FrmTransferOrderToDifferentMachine_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private ComboBox listTezgah;
        private FontAwesome.Sharp.IconButton btnIptal;
        private FontAwesome.Sharp.IconButton btnKaydet;
        private Label label2;
    }
}