using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UretimTakipProgrami.Forms
{
    public partial class FrmDisplayProductImage : Form
    {
        private int screenHeight = 0;
        private int screenWidth = 0;

        public FrmDisplayProductImage(string imagePath)
        {
            InitializeComponent();

            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.ImageLocation = imagePath;

            this.MouseWheel += FrmDisplayProductImage_MouseWheel;

            this.Text = Path.GetFileName(imagePath);

            screenHeight = System.Windows.Forms.SystemInformation.PrimaryMonitorSize.Height;
            screenWidth = System.Windows.Forms.SystemInformation.PrimaryMonitorSize.Width;
        }

        private void FrmDisplayProductImage_MouseWheel(object? sender, MouseEventArgs e)
        {

            if (e.Delta > 0)
            {
                if (this.Width < screenWidth && this.Height < screenHeight)
                {
                    this.Width = this.Width + 30;
                    this.Height = this.Height + 30;
                }
            }
            else
            {
                if (this.Height > 400)
                {
                    this.Width = this.Width - 30;
                    this.Height = this.Height - 30;
                }
            }
        }

        private void FrmDisplayProductImage_Load(object sender, EventArgs e)
        {

        }
    }
}
