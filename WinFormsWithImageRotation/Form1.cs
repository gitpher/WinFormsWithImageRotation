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

        [StructLayout(LayoutKind.Sequential)]
        struct IMAGE
        {
            public int width;
            public int height;
            public int channels;
            public IntPtr data; 
        }

        [DllImport("RotateImg.dll")]
        public static extern IntPtr readImg([MarshalAs(UnmanagedType.LPStr)] string imgPath);

        [DllImport("RotateImg.dll")]
        public static extern double getRadian(double angle);

        [DllImport("RotateImg.dll")]
        public static extern IntPtr createDstImg(int rows, int cols, double angle);

        [DllImport("RotateImg.dll")]
        public static extern IntPtr fillDstImg(IntPtr dstImg, IntPtr srcImg, double radian);

        [DllImport("RotateImg.dll")]
        public static extern IntPtr happyDay();

        IntPtr srcImgPtr;

        private void Browse_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();

            openFileDialog.Title = "Open Image";

            openFileDialog.Filter = "Image Files(*.BMP;*.JPG;*.GIF)|*.BMP;*.JPG;*.GIF|All files (*.*)|*.*";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string imgPath = openFileDialog.FileName;
                
                ImagePathBox.Text = imgPath;

                srcImgPtr = readImg(imgPath);

                unsafe
                {
                    IMAGE* srcImg = (IMAGE*) srcImgPtr.ToPointer();

                    Bitmap srcImgbmp = new Bitmap(srcImg->width, srcImg->height, srcImg->width * 4, PixelFormat.Format32bppArgb, srcImg->data);

                    OriginalImage.Image = srcImgbmp;
                }
            }
        }

        private void Rotate_Click(object sender, EventArgs e)
        {
            double angle = (double) RotateDegreeNumericUpDown.Value;

            double radian = getRadian(angle);

            IntPtr dstImgPtr = createDstImg(378, 378, angle);

            // dstImgPtr = fillDstImg(dstImgPtr, srcImgPtr, radian);

            Bitmap dstImgBmp = new Bitmap(378, 378, 378 * 4, PixelFormat.Format32bppArgb, dstImgPtr);

            RotatedImage.Image= dstImgBmp;
        }
    }
}
