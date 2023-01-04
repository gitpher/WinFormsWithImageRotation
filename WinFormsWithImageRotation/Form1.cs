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

namespace WinFormsWithImageRotation
{
    public partial class ImageRotationForm : Form
    {
        public ImageRotationForm()
        {
            InitializeComponent();
        }

        [DllImport("RotateImg.dll")]
        public static extern byte[] readImg([MarshalAs(UnmanagedType.LPStr)]string imgPath);

        [DllImport("RotateImg.dll")]
        public static extern double getRadian(double angle);

        //////////////////////////////////////
        private string imgPath;
        
        private Image srcImg;
        private Image dstImg;

        private IntPtr srcImgPtr;
        private IntPtr dstImgPtr;

        private double angle;
        private double radian;
        //////////////////////////////////////

        private void Browse_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();

            openFileDialog.Title = "Open Image";

            openFileDialog.Filter = "Image Files(*.BMP;*.JPG;*.GIF)|*.BMP;*.JPG;*.GIF|All files (*.*)|*.*";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                imgPath = openFileDialog.FileName;
                
                ImagePathBox.Text = imgPath;

                byte[] bytes = readImg(imgPath);

                Bitmap bmp;
                using (var ms = new MemoryStream(bytes))
                {
                    bmp = new Bitmap(ms);
                }

                OriginalImage.Image = bmp;



            }
        }

        private void Rotate_Click(object sender, EventArgs e)
        {
            angle = (double) RotateDegreeNumericUpDown.Value;

            radian = getRadian(angle);

            //dstImg = createDstImg(srcImg, radian);

            //Mat filledDstImg = fillDstImg(dstImg, srcImg, radian);

            //RotatedImage.Image = OpenCvSharp.Extensions.BitmapConverter.ToBitmap(filledDstImg);
        }

        
    }
}
