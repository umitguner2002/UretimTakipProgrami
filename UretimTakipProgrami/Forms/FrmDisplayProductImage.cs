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
        public FrmDisplayProductImage(string imagePath)
        {
            InitializeComponent();

            pictureBox1.SizeMode = PictureBoxSizeMode.CenterImage;
            pictureBox1.ImageLocation = imagePath;

            this.Text = Path.GetFileName(imagePath);
        }
    }
}
