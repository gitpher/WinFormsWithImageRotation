using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
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
            public int Width;
            public int Height;
            public int Channels;
            public IntPtr Data;
        }

        [DllImport("RotateImg.dll")]
        public static extern IntPtr readImg([MarshalAs(UnmanagedType.LPStr)] string imgPath);

        [DllImport("RotateImg.dll")]
        public static extern IntPtr RotateImg(IntPtr srcImg, double angle);

        [DllImport("RotateImg.dll")]
        public static extern void deleteImg(IntPtr img);

        private string _imgPath;
        private IntPtr _srcImgPtr;
        private IntPtr _dstImgPtr;

        private Rectangle _defaultOriginalImageSizeRectangle;
        private Rectangle _defaultRotatedImageSizeRectangle;
        private Rectangle _defaultImageRotationFormSizeRectangle;
        private Rectangle _defaultOriginalImageLabelSizeRectangle;
        private Rectangle _defaultRotatedImageLabelSizeRectangle;

        private void Browse_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();

            openFileDialog.Title = "Open Image";

            openFileDialog.Filter = "Image Files(*.BMP;*.JPG;*.GIF)|*.BMP;*.JPG;*.GIF|All files (*.*)|*.*";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                if (_srcImgPtr != IntPtr.Zero) deleteImg(_srcImgPtr);

                _imgPath = openFileDialog.FileName;

                ImagePathBox.Text = _imgPath;

                _srcImgPtr = readImg(_imgPath);

                unsafe
                {
                    IMAGE* srcImg = (IMAGE*)_srcImgPtr.ToPointer();

                    Bitmap srcImgbmp = new Bitmap(srcImg->Width, srcImg->Height, srcImg->Width * srcImg->Channels, PixelFormat.Format32bppArgb, srcImg->Data);

                    ImageRotationForm_Resize(sender, e);

                    OriginalImage.Image = srcImgbmp;
                }

                RotatedImage.Hide();

                RotateDegreeNumericUpDown.Value = 0;
            }
        }

        private void Rotate_Click(object sender, EventArgs e)
        {
            if (_dstImgPtr != IntPtr.Zero) deleteImg(_dstImgPtr);
            if (_srcImgPtr != IntPtr.Zero)
            {
                RotatedImage.Show();

                double angle = (double)RotateDegreeNumericUpDown.Value;

                _dstImgPtr = RotateImg(_srcImgPtr, angle);

                unsafe
                {
                    IMAGE* dstImg = (IMAGE*)_dstImgPtr.ToPointer();

                    Bitmap dstImgBmp = new Bitmap(dstImg->Width, dstImg->Height, dstImg->Width * dstImg->Channels, PixelFormat.Format32bppArgb, dstImg->Data);

                    ImageRotationForm_Resize(sender, e);

                    RotatedImage.Image = dstImgBmp;
                }
            }
        }

        private void ImageRotationForm_Load(object sender, EventArgs e)
        {
            _defaultImageRotationFormSizeRectangle = new Rectangle(this.Location.X, this.Location.Y, this.Width, this.Height);
            _defaultOriginalImageSizeRectangle = new Rectangle(OriginalImage.Location.X, OriginalImage.Location.Y, OriginalImage.Width, OriginalImage.Height);
            _defaultRotatedImageSizeRectangle = new Rectangle(RotatedImage.Location.X, RotatedImage.Location.Y, RotatedImage.Width, RotatedImage.Height);
            _defaultOriginalImageLabelSizeRectangle = new Rectangle(OriginalImageLabel.Location.X, OriginalImageLabel.Location.Y, OriginalImageLabel.Width, OriginalImageLabel.Height);
            _defaultRotatedImageLabelSizeRectangle = new Rectangle(RotatedImageLabel.Location.X, RotatedImageLabel.Location.Y, RotatedImageLabel.Width, RotatedImageLabel.Height);
        }

        private void ImageRotationForm_Resize(object sender, EventArgs e)
        {
            Resize_Control(_defaultOriginalImageSizeRectangle, OriginalImage);
            Resize_Control(_defaultRotatedImageSizeRectangle, RotatedImage);
            Reposition_Control(_defaultOriginalImageLabelSizeRectangle, OriginalImageLabel);
            Reposition_Control(_defaultRotatedImageLabelSizeRectangle, RotatedImageLabel);

            unsafe
            {
                if (_srcImgPtr != IntPtr.Zero)
                {
                    IMAGE* srcImg = (IMAGE*)_srcImgPtr.ToPointer();
                    Shrink_PictureBox(srcImg->Width, srcImg->Height, OriginalImage);
                }

                if (_dstImgPtr != IntPtr.Zero)
                {
                    IMAGE* dstImg = (IMAGE*)_dstImgPtr.ToPointer();
                    Shrink_PictureBox(dstImg->Width, dstImg->Height, RotatedImage);
                }
            }
        }

        private void Resize_Control(Rectangle rect, Control ctrl)
        {
            double horizontalRatio = this.Width / (double)_defaultImageRotationFormSizeRectangle.Width;
            double verticalRatio = this.Height / (double)_defaultImageRotationFormSizeRectangle.Height;

            int newX = (int)(rect.Location.X * horizontalRatio);
            int newY = rect.Location.Y;

            int newWidth = (int)(rect.Width * horizontalRatio);
            int newHeight = (int)(rect.Height * verticalRatio);

            ctrl.Location = new System.Drawing.Point(newX, newY);
            ctrl.Size = new System.Drawing.Size(newWidth, newHeight);
        }

        private void Reposition_Control(Rectangle rect, Control ctrl)
        {
            double horizontalRatio = this.Width / (double)_defaultImageRotationFormSizeRectangle.Width;

            int newX = (int)(rect.Location.X * horizontalRatio);
            int newY = rect.Location.Y;

            ctrl.Location = new System.Drawing.Point(newX, newY);
        }

        private void Shrink_PictureBox(int width, int height, Control ctrl)
        {
            double aspectRatio = width / (double)height;

            if (aspectRatio > 1)
            {
                ctrl.Height = (int)(ctrl.Width / aspectRatio);
            }
            else
            {
                ctrl.Width = (int)(ctrl.Height * aspectRatio);
            }
        }

        private void Download_Click(object sender, EventArgs e)
        {
            double rotatedDegree = (double)RotateDegreeNumericUpDown.Value;
            string fileLocation = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + "\\Downloads\\";
            string filename = Path.GetFileNameWithoutExtension(_imgPath) + "(" + rotatedDegree + "도 회전).png";

            RotatedImage.Image.Save(fileLocation + filename, ImageFormat.Png);

            string title = "이미지 저장 성공";
            string message = "이미지가 저장되었습니다." + "\n"
                            + "\n" +
                            "다운로드 위치: " + fileLocation + filename;

            MessageBox.Show(message, title);
        }
    }
}
