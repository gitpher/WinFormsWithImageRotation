using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
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

        // Are there any better way to import dll? Where should I place these arguments?
        [DllImport("RotateImg.dll")]
        public extern static Mat readImage([MarshalAs(UnmanagedType.LPStr)]string imgPath); // 

        [DllImport("RotateImg.dll")]
        public extern static double getRadian(double angle);

        [DllImport("RotateImg.dll")]
        public extern static Mat createDstImg(Mat srcImg, double angle); // 

        [DllImport("RotateImg.dll")]
        public extern static Mat fillDstImg(Mat dstImg, Mat srcImg, double radian); // 

        // Not sure this is the right way to do it
        // byte array
        string imgPath;
        Image srcImg; // 
        Image dstImg; //
        double angle;
        double radian;

        private void Browse_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();

            openFileDialog.Title = "Open Image";

            openFileDialog.Filter = "Image Files(*.BMP;*.JPG;*.GIF)|*.BMP;*.JPG;*.GIF|All files (*.*)|*.*";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                imgPath = openFileDialog.FileName;
                
                ImagePathBox.Text = imgPath;

                Image srcImg = Image.FromFile(imgPath);

                var ms = new MemoryStream(); // deposit bytes here

                srcImg.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg); // save bytes to ms

                var bytes = ms.ToArray();

                ////////////
                ////
                ///

                var imageMemoryStream = new MemoryStream(bytes);

                Image imgFromStream = Image.FromStream(imageMemoryStream);





                OriginalImage.Image = srcImg;
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
