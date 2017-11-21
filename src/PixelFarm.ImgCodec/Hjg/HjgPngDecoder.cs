//Apache2, 2010, Sebastian Stehle
// ===============================================================================
// Copyright (c) .NET Image Tools Development Group. 
// All rights reserved.
// ===============================================================================


using System.IO;
using Hjg.Pngcs;

namespace ImageTools.IO.Png
{

    public class HjgPngDecoder : IImageDecoder
    {
        public int HeaderSize
        {
            get { return 8; }
        }
        public void Decode(ExtendedImage image, Stream stream)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                PngReader reader = new PngReader(stream);
                for (int row = 0; row < reader.ImgInfo.Rows; row++)
                {
                    ImageLine line = reader.ReadRowByte(row);
                    //int[] scline1 = line.Scanline;
                    byte[] buffers = line.ScanlineB;
                    ms.Write(buffers, 0, buffers.Length);
                }
                ms.Flush();
                image.SetPixels(ms.ToArray());
                image.PixelHeight = reader.ImgInfo.Rows;
                image.PixelWidth = reader.ImgInfo.Cols;
                image.DensityXInt32 = image.DensityYInt32 = 96;
            }

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