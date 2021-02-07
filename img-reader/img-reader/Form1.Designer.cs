
namespace img_reader
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
            this.btn_CaptureFrame = new System.Windows.Forms.Button();
            this.btn_saveImage = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btn_CaptureFrame
            // 
            this.btn_CaptureFrame.Location = new System.Drawing.Point(110, 43);
            this.btn_CaptureFrame.Name = "btn_CaptureFrame";
            this.btn_CaptureFrame.Size = new System.Drawing.Size(90, 50);
            this.btn_CaptureFrame.TabIndex = 0;
            this.btn_CaptureFrame.Text = "Capture Frame";
            this.btn_CaptureFrame.UseVisualStyleBackColor = true;
            this.btn_CaptureFrame.Click += new System.EventHandler(this.btn_CaptureFrame_Click);
            // 
            // btn_saveImage
            // 
            this.btn_saveImage.Location = new System.Drawing.Point(110, 128);
            this.btn_saveImage.Name = "btn_saveImage";
            this.btn_saveImage.Size = new System.Drawing.Size(90, 50);
            this.btn_saveImage.TabIndex = 2;
            this.btn_saveImage.Text = "Save Image";
            this.btn_saveImage.UseVisualStyleBackColor = true;
            this.btn_saveImage.Click += new System.EventHandler(this.btn_saveImage_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(324, 247);
            this.Controls.Add(this.btn_saveImage);
            this.Controls.Add(this.btn_CaptureFrame);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn_CaptureFrame;
        private System.Windows.Forms.Button btn_saveImage;
    }
}

