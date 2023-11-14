namespace UretimTakipProgrami.Services.Messages.MessageForms
{
    partial class FrmSaveMessage
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
            ıconPictureBox1 = new FontAwesome.Sharp.IconPictureBox();
            label1 = new Label();
            btnTamam = new Button();
            ((System.ComponentModel.ISupportInitialize)ıconPictureBox1).BeginInit();
            SuspendLayout();
            // 
            // ıconPictureBox1
            // 
            ıconPictureBox1.BackColor = Color.FromArgb(25, 135, 84);
            ıconPictureBox1.ForeColor = Color.Gainsboro;
            ıconPictureBox1.IconChar = FontAwesome.Sharp.IconChar.CheckCircle;
            ıconPictureBox1.IconColor = Color.Gainsboro;
            ıconPictureBox1.IconFont = FontAwesome.Sharp.IconFont.Auto;
            ıconPictureBox1.IconSize = 102;
            ıconPictureBox1.Location = new Point(109, 30);
            ıconPictureBox1.Name = "ıconPictureBox1";
            ıconPictureBox1.Size = new Size(107, 102);
            ıconPictureBox1.TabIndex = 0;
            ıconPictureBox1.TabStop = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Tahoma", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            label1.ForeColor = Color.Gainsboro;
            label1.Location = new Point(100, 140);
            label1.Name = "label1";
            label1.Size = new Size(132, 23);
            label1.TabIndex = 1;
            label1.Text = "Kayıt Başarılı...";
            // 
            // btnTamam
            // 
            btnTamam.BackColor = Color.Gainsboro;
            btnTamam.FlatAppearance.BorderSize = 0;
            btnTamam.FlatStyle = FlatStyle.Flat;
            btnTamam.Font = new Font("Tahoma", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            btnTamam.Location = new Point(95, 184);
            btnTamam.Name = "btnTamam";
            btnTamam.Size = new Size(132, 29);
            btnTamam.TabIndex = 2;
            btnTamam.Text = "Tamam";
            btnTamam.UseVisualStyleBackColor = false;
            btnTamam.Click += btnTamam_Click;
            // 
            // SaveMessageForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(25, 135, 84);
            ClientSize = new Size(315, 237);
            Controls.Add(btnTamam);
            Controls.Add(label1);
            Controls.Add(ıconPictureBox1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "SaveMessageForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "SaveMessageForm";
            ((System.ComponentModel.ISupportInitialize)ıconPictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private FontAwesome.Sharp.IconPictureBox ıconPictureBox1;
        private Label label1;
        private Button btnTamam;
    }
}