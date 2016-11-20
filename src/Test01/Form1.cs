using System;
using System.Collections.Generic;
using System.ComponentModel;

using System.Drawing;
using System.Text;
using System.Windows.Forms;

using System.IO;

using ImageTools;
using ImageTools.IO.Png;
using ImageTools.IO.Jpeg;
namespace Test01
{
    public partial class Form1 : Form
    {
        PngDecoder pngDecode = new PngDecoder();
        JpegDecoder jpgDecode = new JpegDecoder();
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ExtendedImage extImg = new ExtendedImage();
            using (FileStream fs = new FileStream("d:\\WImageTest\\ab1.jpg", FileMode.Open))
            {
                extImg.Load(fs, jpgDecode); 
                //copy decoded pixels to new bmp
                System.Drawing.Bitmap newBmp = new Bitmap(extImg.PixelWidth, extImg.PixelHeight,
                     System.Drawing.Imaging.PixelFormat.Format32bppArgb);
                var bmpdata = newBmp.LockBits(
                    new System.Drawing.Rectangle(0, 0, extImg.PixelWidth, extImg.PixelHeight),
                     System.Drawing.Imaging.ImageLockMode.ReadWrite, System.Drawing.Imaging.PixelFormat.Format32bppArgb);

                System.Runtime.InteropServices.Marshal.Copy(
                    extImg.Pixels, 0,
                    bmpdata.Scan0,
                       extImg.Pixels.Length);

                newBmp.UnlockBits(bmpdata);
                newBmp.Save("d:\\WImageTest\\img_tools_test.jpg");

                fs.Close();
            }

            using (FileStream fs = new FileStream("d:\\WImageTest\\a01_4_1.png", FileMode.Open))
            {
                extImg.Load(fs, pngDecode);

                //copy decoded pixels to new bmp
                System.Drawing.Bitmap newBmp = new Bitmap(extImg.PixelWidth, extImg.PixelHeight,
                     System.Drawing.Imaging.PixelFormat.Format32bppArgb);
                var bmpdata = newBmp.LockBits(
                    new System.Drawing.Rectangle(0, 0, extImg.PixelWidth, extImg.PixelHeight),
                     System.Drawing.Imaging.ImageLockMode.ReadWrite, System.Drawing.Imaging.PixelFormat.Format32bppArgb);

                System.Runtime.InteropServices.Marshal.Copy(
                    extImg.Pixels, 0,
                    bmpdata.Scan0,
                       extImg.Pixels.Length);

                newBmp.UnlockBits(bmpdata);
                newBmp.Save("d:\\WImageTest\\img_tools_test.png");

                fs.Close();
            }

        }
    }
}
