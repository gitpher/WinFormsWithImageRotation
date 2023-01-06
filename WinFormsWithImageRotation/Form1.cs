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
using System.Windows.Forms.VisualStyles;
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
        public static extern IntPtr RotateImg(IntPtr srcImg, double angle);

        [DllImport("RotateImg.dll")]
        public static extern void deleteImg(IntPtr img);

        int pictureBoxDefaultWidth = 300;
        int pictureBoxDefaultHeight = 300;
        string imgPath;
        IntPtr srcImgPtr;
        IntPtr dstImgPtr;

        private void Browse_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();

            openFileDialog.Title = "Open Image";

            openFileDialog.Filter = "Image Files(*.BMP;*.JPG;*.GIF)|*.BMP;*.JPG;*.GIF|All files (*.*)|*.*";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                if (srcImgPtr != IntPtr.Zero) deleteImg(srcImgPtr);

                imgPath = openFileDialog.FileName;

                ImagePathBox.Text = imgPath;

                OriginalImage.Size = new System.Drawing.Size(pictureBoxDefaultWidth, pictureBoxDefaultHeight);
                RotatedImage.Size = new System.Drawing.Size(pictureBoxDefaultWidth, pictureBoxDefaultHeight);

                srcImgPtr = readImg(imgPath);

                unsafe
                {
                    IMAGE* srcImg = (IMAGE*) srcImgPtr.ToPointer();

                    Bitmap srcImgbmp = new Bitmap(srcImg->width, srcImg->height, srcImg->width * srcImg->channels, PixelFormat.Format32bppArgb, srcImg->data);

                    OriginalImage.Image = srcImgbmp;

                    RotatedImage.Image = srcImgbmp;

                    double aspectRatio = srcImg->width / (double)srcImg->height;

                    if (aspectRatio > 1)
                    {
                        OriginalImage.Height = (int)(OriginalImage.Width / aspectRatio);
                        RotatedImage.Height = (int)(RotatedImage.Width / aspectRatio);
                    }
                    else
                    {
                        OriginalImage.Width = (int)(OriginalImage.Height * aspectRatio);
                        RotatedImage.Width = (int)(RotatedImage.Height * aspectRatio);
                    }

                    RotateDegreeNumericUpDown.Value = 0;
                }
            }
        }

        private void Rotate_Click(object sender, EventArgs e)
        {
            if (dstImgPtr != IntPtr.Zero) deleteImg(dstImgPtr);

            double angle = (double) RotateDegreeNumericUpDown.Value;

            dstImgPtr = RotateImg(srcImgPtr, angle);

            unsafe
            {
                IMAGE* dstImg = (IMAGE*) dstImgPtr.ToPointer();

                Bitmap dstImgBmp = new Bitmap(dstImg->width, dstImg->height, dstImg->width * dstImg->channels, PixelFormat.Format32bppArgb, dstImg->data);

                double aspectRatio = dstImg->width / (double)dstImg->height;

                if (aspectRatio > 1)
                {
                    RotatedImage.Width = pictureBoxDefaultWidth;
                    RotatedImage.Height = (int)(RotatedImage.Width / aspectRatio);
                }
                else
                {
                    RotatedImage.Height = pictureBoxDefaultHeight;
                    RotatedImage.Width = (int)(RotatedImage.Height * aspectRatio);
                }

                RotatedImage.Image = dstImgBmp;
            }
        }

        private void Download_Click(object sender, EventArgs e)
        {
            double rotatedDegree = (double)RotateDegreeNumericUpDown.Value;
            string filename = Path.GetFileNameWithoutExtension(imgPath) + "(" + rotatedDegree + "도 회전).png";
            string location = @"C:\Users\jun_c\Downloads\";

            RotatedImage.Image.Save(location + filename, ImageFormat.Png);

            string title = "이미지 저장 성공";
            string message = "이미지가 저장되었습니다." + "\n" +
                            "(다운로드 위치: " + location + filename + ")";

            MessageBox.Show(message, title);
        }
    }
}
