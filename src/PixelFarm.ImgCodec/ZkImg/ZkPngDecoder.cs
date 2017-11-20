//Apache2, 2010, Sebastian Stehle
// ===============================================================================
// Copyright (c) .NET Image Tools Development Group. 
// All rights reserved.
// ===============================================================================


using System;
using System.IO;
using ZkImgSharp.PNG;

namespace ImageTools.IO.Png
{

    public class ZkPngDecoder : IImageDecoder
    {
        public int HeaderSize
        {
            get { return 8; }
        }
        public void Decode(ExtendedImage image, Stream stream)
        {
            //read all file
            //using (MemoryStream ms = new MemoryStream())
            //{   
            //    BinaryReader reader = new BinaryReader(stream);
            //    byte[] buffer = new byte[1024];
            //    int byteRead = reader.Read(buffer, 0, 1024);
            //    while (byteRead > 0)
            //    {

            //    }
            //}
            if (stream is FileStream)
            {
                FileStream fs = (FileStream)stream;
                int len = (int)fs.Length;
                byte[] output = new byte[len];
                fs.Read(output, 0, len);
                var pngImage2 = new PngImage(File.ReadAllBytes("d:\\WImageTest\\emoji_01.png"));
                var pngImage = new PngImage(output);

            }
           
            throw new NotImplementedException();
        }

        public bool IsSupportedFileExtension(string extension)
        {
            return extension.ToUpper() == "PNG";
        }

        public bool IsSupportedFileFormat(byte[] header)
        {
            //temp
            return true;
        }
    }
}