using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO.Ports;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace img_reader
{
    public partial class Form1 : Form
    {
        SerialPort port;
        static string portName = "COM5";
        static string filePath = "C://captured-img.bmp";
        static int totalSize = 0;
        static int width = 160;
        static int height = 120;
        static int imageSize = width * height * 3;
        static byte[] imgData = new byte[imageSize];

        public Form1()
        {
            InitializeComponent();
            btn_saveImage.Enabled = false;

            port = new SerialPort();
            port.PortName = portName;
            port.BaudRate = 115200;
            port.DataReceived += new SerialDataReceivedEventHandler(DataReceived);
            port.Open();
        }

        private void DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            int count = port.BytesToRead;
            byte[] buffer = new byte[count];
            port.Read(buffer, 0, count);

            for (int i = totalSize, j = 0; i < totalSize + count; i++, j++)
            {
                imgData[i] = buffer[j];
            }

            totalSize += count;

            if (totalSize == imageSize)
            {
                btn_saveImage.Invoke((MethodInvoker)delegate
                {
                    btn_saveImage.Enabled = true;
                });
            }
        }

        private void btn_CaptureFrame_Click(object sender, EventArgs e)
        {
            totalSize = 0;
            Array.Clear(imgData, 0, imgData.Length);
            port.Write(new byte[] { 1 }, 0, 1);
            port.BaseStream.Flush();
        }

        private void btn_saveImage_Click(object sender, EventArgs e)
        {
            GenerateBMP(imgData, width, height).Save(filePath, ImageFormat.Bmp);
            btn_saveImage.Enabled = false;
        }

        public Image GenerateBMP(byte[] arr, int width, int height)
        {
            var output = new Bitmap(width, height, PixelFormat.Format24bppRgb);
            var rect = new Rectangle(0, 0, width, height);
            var bmpData = output.LockBits(rect, ImageLockMode.ReadWrite, output.PixelFormat);

            var arrRowLength = width * Image.GetPixelFormatSize(output.PixelFormat) / 8;
            var ptr = bmpData.Scan0;
            for (var i = 0; i < height; i++)
            {
                Marshal.Copy(arr, i * arrRowLength, ptr, arrRowLength);
                ptr += bmpData.Stride;
            }

            output.UnlockBits(bmpData);
            return output;
        }
    }
}
