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
        private double originalWidth = 0;
        private double originalHeight = 0;
        private double totalSize = 0;

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
            originalWidth = pictureBox1.Image.Width;
            originalHeight = pictureBox1.Image.Height;
            totalSize = originalWidth + originalHeight;

            if (e.Delta > 0)
            {
                if (this.Width < screenWidth && this.Height < screenHeight)
                {
                    this.Width = this.Width + Convert.ToInt32((originalWidth / totalSize) * 100);
                    this.Height = this.Height + Convert.ToInt32((originalHeight / totalSize) * 100);
                }
            }
            else
            {
                if (this.Height > 400)
                {
                    this.Width = this.Width - Convert.ToInt32((originalWidth / totalSize) * 100);
                    this.Height = this.Height - Convert.ToInt32((originalHeight / totalSize) * 100);
                }
            }
        }

        private void FrmDisplayProductImage_Load(object sender, EventArgs e)
        {

        }

        private void FrmDisplayProductImage_Shown(object sender, EventArgs e)
        {

        }

        private void pictureBox1_LoadCompleted(object sender, AsyncCompletedEventArgs e)
        {
            if(pictureBox1.Image.Width > screenWidth || pictureBox1.Image.Height > screenHeight)
            {
                this.Width = pictureBox1.Image.Width / 2;
                this.Height = pictureBox1.Image.Height / 2;
            }
            else
            {
                this.Width = pictureBox1.Image.Width;
                this.Height = pictureBox1.Image.Height;
            }
            
        }
    }
}
