namespace WinFormsWithImageRotation
{
    partial class ImageRotationForm
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
            this.Browse = new System.Windows.Forms.Button();
            this.Rotate = new System.Windows.Forms.Button();
            this.OriginalImageLabel = new System.Windows.Forms.Label();
            this.RotatedImageLabel = new System.Windows.Forms.Label();
            this.RotateDegreeNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.ImagePathBox = new System.Windows.Forms.TextBox();
            this.DownloadButton = new System.Windows.Forms.Button();
            this.Degree = new System.Windows.Forms.Label();
            this.RotatedImage = new System.Windows.Forms.PictureBox();
            this.OriginalImage = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.RotateDegreeNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RotatedImage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.OriginalImage)).BeginInit();
            this.SuspendLayout();
            // 
            // Browse
            // 
            this.Browse.Location = new System.Drawing.Point(618, 27);
            this.Browse.Name = "Browse";
            this.Browse.Size = new System.Drawing.Size(75, 23);
            this.Browse.TabIndex = 0;
            this.Browse.Text = "파일 열기";
            this.Browse.UseVisualStyleBackColor = true;
            this.Browse.Click += new System.EventHandler(this.Browse_Click);
            // 
            // Rotate
            // 
            this.Rotate.Location = new System.Drawing.Point(618, 55);
            this.Rotate.Name = "Rotate";
            this.Rotate.Size = new System.Drawing.Size(75, 23);
            this.Rotate.TabIndex = 1;
            this.Rotate.Text = "회전";
            this.Rotate.UseVisualStyleBackColor = true;
            this.Rotate.Click += new System.EventHandler(this.Rotate_Click);
            // 
            // OriginalImageLabel
            // 
            this.OriginalImageLabel.AutoSize = true;
            this.OriginalImageLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.OriginalImageLabel.Location = new System.Drawing.Point(173, 117);
            this.OriginalImageLabel.Name = "OriginalImageLabel";
            this.OriginalImageLabel.Size = new System.Drawing.Size(74, 20);
            this.OriginalImageLabel.TabIndex = 4;
            this.OriginalImageLabel.Text = "원본 이미지";
            // 
            // RotatedImageLabel
            // 
            this.RotatedImageLabel.AutoSize = true;
            this.RotatedImageLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RotatedImageLabel.Location = new System.Drawing.Point(501, 117);
            this.RotatedImageLabel.Name = "RotatedImageLabel";
            this.RotatedImageLabel.Size = new System.Drawing.Size(86, 20);
            this.RotatedImageLabel.TabIndex = 5;
            this.RotatedImageLabel.Text = "회전된 이미지";
            // 
            // RotateDegreeNumericUpDown
            // 
            this.RotateDegreeNumericUpDown.DecimalPlaces = 1;
            this.RotateDegreeNumericUpDown.Location = new System.Drawing.Point(541, 56);
            this.RotateDegreeNumericUpDown.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.RotateDegreeNumericUpDown.Minimum = new decimal(new int[] {
            1000,
            0,
            0,
            -2147483648});
            this.RotateDegreeNumericUpDown.Name = "RotateDegreeNumericUpDown";
            this.RotateDegreeNumericUpDown.Size = new System.Drawing.Size(70, 20);
            this.RotateDegreeNumericUpDown.TabIndex = 7;
            // 
            // ImagePathBox
            // 
            this.ImagePathBox.Location = new System.Drawing.Point(58, 29);
            this.ImagePathBox.Name = "ImagePathBox";
            this.ImagePathBox.Size = new System.Drawing.Size(554, 20);
            this.ImagePathBox.TabIndex = 8;
            // 
            // DownloadButton
            // 
            this.DownloadButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.DownloadButton.Location = new System.Drawing.Point(618, 458);
            this.DownloadButton.Name = "DownloadButton";
            this.DownloadButton.Size = new System.Drawing.Size(75, 23);
            this.DownloadButton.TabIndex = 9;
            this.DownloadButton.Text = "다운로드";
            this.DownloadButton.UseVisualStyleBackColor = true;
            this.DownloadButton.Click += new System.EventHandler(this.Download_Click);
            // 
            // Degree
            // 
            this.Degree.AutoSize = true;
            this.Degree.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Degree.Location = new System.Drawing.Point(504, 58);
            this.Degree.Name = "Degree";
            this.Degree.Size = new System.Drawing.Size(34, 15);
            this.Degree.TabIndex = 10;
            this.Degree.Text = "각도:";
            // 
            // RotatedImage
            // 
            this.RotatedImage.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.RotatedImage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.RotatedImage.Cursor = System.Windows.Forms.Cursors.Hand;
            this.RotatedImage.Location = new System.Drawing.Point(393, 143);
            this.RotatedImage.Name = "RotatedImage";
            this.RotatedImage.Size = new System.Drawing.Size(300, 300);
            this.RotatedImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.RotatedImage.TabIndex = 3;
            this.RotatedImage.TabStop = false;
            // 
            // OriginalImage
            // 
            this.OriginalImage.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.OriginalImage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.OriginalImage.Cursor = System.Windows.Forms.Cursors.Hand;
            this.OriginalImage.Location = new System.Drawing.Point(58, 143);
            this.OriginalImage.Name = "OriginalImage";
            this.OriginalImage.Size = new System.Drawing.Size(300, 300);
            this.OriginalImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.OriginalImage.TabIndex = 2;
            this.OriginalImage.TabStop = false;
            // 
            // ImageRotationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(749, 498);
            this.Controls.Add(this.Degree);
            this.Controls.Add(this.DownloadButton);
            this.Controls.Add(this.ImagePathBox);
            this.Controls.Add(this.RotateDegreeNumericUpDown);
            this.Controls.Add(this.RotatedImageLabel);
            this.Controls.Add(this.OriginalImageLabel);
            this.Controls.Add(this.RotatedImage);
            this.Controls.Add(this.OriginalImage);
            this.Controls.Add(this.Rotate);
            this.Controls.Add(this.Browse);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.Name = "ImageRotationForm";
            this.Text = "ImageRotationForm";
            this.Load += new System.EventHandler(this.ImageRotationForm_Load);
            this.Resize += new System.EventHandler(this.ImageRotationForm_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.RotateDegreeNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RotatedImage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.OriginalImage)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Browse;
        private System.Windows.Forms.Button Rotate;
        private System.Windows.Forms.PictureBox OriginalImage;
        private System.Windows.Forms.PictureBox RotatedImage;
        private System.Windows.Forms.Label OriginalImageLabel;
        private System.Windows.Forms.Label RotatedImageLabel;
        private System.Windows.Forms.NumericUpDown RotateDegreeNumericUpDown;
        private System.Windows.Forms.TextBox ImagePathBox;
        private System.Windows.Forms.Button DownloadButton;
        private System.Windows.Forms.Label Degree;
    }
}

