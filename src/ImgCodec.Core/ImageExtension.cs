namespace ImageTools
{
    public static class ImgExtensionMethods
    {
        public static double GetInchWidth(this ExtendedImage img)
        {
            double densityX = img.DensityX;

            if (densityX <= 0)
            {
                densityX = ExtendedImage.DefaultDensityX;
            }

            return img.PixelWidth / densityX;
        }
        public static double GetInchHeight(this ExtendedImage img)
        {
            double densityY = img.DensityY;

            if (densityY <= 0)
            {
                densityY = ExtendedImage.DefaultDensityY;
            } 
            return img.PixelHeight / densityY;
        } 
    }
}