using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.Remoting.Channels;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using OpenCvSharp;
using OpenCvSharp.Extensions;

namespace WinFormsWithImageRotation
{
    public partial class ImageRotationForm : Form
    {
        public ImageRotationForm()
        {
            InitializeComponent();
        }

        [DllImport("RotateImg.dll")]
        public static extern IntPtr readImg([MarshalAs(UnmanagedType.LPStr)]string imgPath);

        [DllImport("RotateImg.dll")]
        public static extern double getRadian(double angle);

        private void Browse_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();

            openFileDialog.Title = "Open Image";

            openFileDialog.Filter = "Image Files(*.BMP;*.JPG;*.GIF)|*.BMP;*.JPG;*.GIF|All files (*.*)|*.*";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string imgPath = openFileDialog.FileName;
                
                ImagePathBox.Text = imgPath;

                IntPtr srcImgPtr = readImg(imgPath);

                Bitmap srcImgbmp = new Bitmap(400, 400, 400 * 3, PixelFormat.Format24bppRgb, srcImgPtr);

                OriginalImage.Image= srcImgbmp;
            }
        }

        private void Rotate_Click(object sender, EventArgs e)
        {
            double angle = (double) RotateDegreeNumericUpDown.Value;

            double radian = getRadian(angle);
        }
    }
}
