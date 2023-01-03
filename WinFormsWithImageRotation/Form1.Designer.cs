namespace WinFormsWithImageRotation
{
    partial class Form1
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
            this.OriginalImage = new System.Windows.Forms.PictureBox();
            this.RotatedImage = new System.Windows.Forms.PictureBox();
            this.OriginalImageLabel = new System.Windows.Forms.Label();
            this.RotatedImageLabel = new System.Windows.Forms.Label();
            this.RotateDegreeNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.ImagePathBox = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.OriginalImage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RotatedImage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RotateDegreeNumericUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // Browse
            // 
            this.Browse.Location = new System.Drawing.Point(543, 77);
            this.Browse.Name = "Browse";
            this.Browse.Size = new System.Drawing.Size(75, 23);
            this.Browse.TabIndex = 0;
            this.Browse.Text = "Browse";
            this.Browse.UseVisualStyleBackColor = true;
            this.Browse.Click += new System.EventHandler(this.Browse_Click);
            // 
            // Rotate
            // 
            this.Rotate.Location = new System.Drawing.Point(543, 117);
            this.Rotate.Name = "Rotate";
            this.Rotate.Size = new System.Drawing.Size(75, 23);
            this.Rotate.TabIndex = 1;
            this.Rotate.Text = "Rotate";
            this.Rotate.UseVisualStyleBackColor = true;
            this.Rotate.Click += new System.EventHandler(this.Rotate_Click);
            // 
            // OriginalImage
            // 
            this.OriginalImage.Location = new System.Drawing.Point(100, 210);
            this.OriginalImage.Name = "OriginalImage";
            this.OriginalImage.Size = new System.Drawing.Size(232, 168);
            this.OriginalImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.OriginalImage.TabIndex = 2;
            this.OriginalImage.TabStop = false;
            // 
            // RotatedImage
            // 
            this.RotatedImage.Location = new System.Drawing.Point(415, 210);
            this.RotatedImage.Name = "RotatedImage";
            this.RotatedImage.Size = new System.Drawing.Size(218, 168);
            this.RotatedImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.RotatedImage.TabIndex = 3;
            this.RotatedImage.TabStop = false;
            // 
            // OriginalImageLabel
            // 
            this.OriginalImageLabel.AutoSize = true;
            this.OriginalImageLabel.Location = new System.Drawing.Point(179, 188);
            this.OriginalImageLabel.Name = "OriginalImageLabel";
            this.OriginalImageLabel.Size = new System.Drawing.Size(74, 13);
            this.OriginalImageLabel.TabIndex = 4;
            this.OriginalImageLabel.Text = "Original Image";
            // 
            // RotatedImageLabel
            // 
            this.RotatedImageLabel.AutoSize = true;
            this.RotatedImageLabel.Location = new System.Drawing.Point(483, 188);
            this.RotatedImageLabel.Name = "RotatedImageLabel";
            this.RotatedImageLabel.Size = new System.Drawing.Size(77, 13);
            this.RotatedImageLabel.TabIndex = 5;
            this.RotatedImageLabel.Text = "Rotated Image";
            // 
            // RotateDegreeNumericUpDown
            // 
            this.RotateDegreeNumericUpDown.DecimalPlaces = 1;
            this.RotateDegreeNumericUpDown.Location = new System.Drawing.Point(417, 117);
            this.RotateDegreeNumericUpDown.Maximum = new decimal(new int[] {
            360,
            0,
            0,
            0});
            this.RotateDegreeNumericUpDown.Minimum = new decimal(new int[] {
            360,
            0,
            0,
            -2147483648});
            this.RotateDegreeNumericUpDown.Name = "RotateDegreeNumericUpDown";
            this.RotateDegreeNumericUpDown.Size = new System.Drawing.Size(120, 20);
            this.RotateDegreeNumericUpDown.TabIndex = 7;
            // 
            // ImagePathBox
            // 
            this.ImagePathBox.Location = new System.Drawing.Point(122, 77);
            this.ImagePathBox.Name = "ImagePathBox";
            this.ImagePathBox.Size = new System.Drawing.Size(415, 20);
            this.ImagePathBox.TabIndex = 8;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(750, 470);
            this.Controls.Add(this.ImagePathBox);
            this.Controls.Add(this.RotateDegreeNumericUpDown);
            this.Controls.Add(this.RotatedImageLabel);
            this.Controls.Add(this.OriginalImageLabel);
            this.Controls.Add(this.RotatedImage);
            this.Controls.Add(this.OriginalImage);
            this.Controls.Add(this.Rotate);
            this.Controls.Add(this.Browse);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.OriginalImage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RotatedImage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RotateDegreeNumericUpDown)).EndInit();
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
    }
}

