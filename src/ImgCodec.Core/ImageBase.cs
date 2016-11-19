// ===============================================================================
// ImageBase.cs
// .NET Image Tools
// ===============================================================================
// Copyright (c) .NET Image Tools Development Group. 
// All rights reserved.
// ===============================================================================

using System; 
using ImageTools.Helpers;

namespace ImageTools
{
    /// <summary>
    /// Base classes for all Images.
    /// </summary> 
    public partial class ImageBase
    {


        /// <summary>
        /// The default animation speed, when the image is animated.
        /// </summary>
        public const int DefaultDelayTime = 10;


        #region Invariant

#if !WINDOWS_PHONE

        private void ImageBaseInvariantMethod()
        {
            //Contract.Invariant(!_isFilled || _pixels != null);
            //Contract.Invariant(!_isFilled || _pixelWidth >= 0);
            //Contract.Invariant(!_isFilled || _pixelHeight >= 0);
        }
#endif

        #endregion

        #region Properties

        private int _delayTime;
        /// <summary>
        /// If not 0, this field specifies the number of hundredths (1/100) of a second to 
        /// wait before continuing with the processing of the Data Stream. 
        /// The clock starts ticking immediately after the graphic is rendered. 
        /// This field may be used in conjunction with the User Input Flag field. 
        /// </summary>

        public int DelayTime
        {
            get
            {
                int delayTime = _delayTime;

                if (delayTime <= 0)
                {
                    delayTime = DefaultDelayTime;
                }

                return delayTime;
            }
            set { _delayTime = value; }
        }

        private bool _isFilled;
        /// <summary>
        /// Gets or sets a value indicating whether this image has been loaded.
        /// </summary>
        /// <value><c>true</c> if this image has been loaded; otherwise, <c>false</c>.</value>

        public bool IsFilled
        {
            get
            {
                return _isFilled;
            }
        }

        private byte[] _pixels;
        /// <summary>
        /// Returns all pixels of the image as simple byte array.
        /// </summary>
        /// <value>All image pixels as byte array.</value>
        /// <remarks>The returned array has a length of Width * Length * 4 bytes
        /// and stores the red, the green, the blue and the alpha value for
        /// each pixel in this order.</remarks>

        public byte[] Pixels
        {
            get
            {  //Contract.Ensures(!IsFilled || Contract.Result<byte[]>() != null);
                return _pixels;
            }
        }

        private int _pixelHeight;
        /// <summary>
        /// Gets the height of this <see cref="ExtendedImage"/> in pixels.
        /// </summary>
        /// <value>The height of this image.</value>
        /// <remarks>The height will be initialized by the constructor
        /// or when the data will be pixel data will set.</remarks>
        public int PixelHeight
        {
            get
            {
                // Contract.Ensures(!IsFilled || Contract.Result<int>() > 0);
                return _pixelHeight;
            }
        }

        private int _pixelWidth;
        /// <summary>
        /// Gets the width of this <see cref="ExtendedImage"/> in pixels.
        /// </summary>
        /// <value>The width of this image.</value>
        /// <remarks>The width will be initialized by the constructor
        /// or when the data will be pixel data will set.</remarks>
        public int PixelWidth
        {
            get
            {
                // Contract.Ensures(!IsFilled || Contract.Result<int>() > 0);
                return _pixelWidth;
            }
        }

        /// <summary>
        /// Gets the ratio between the width and the height of this <see cref="ImageBase"/> instance.
        /// </summary>
        /// <value>The ratio between the width and the height.</value>
        public double PixelRatio
        {
            get
            {
                //Contract.Ensures(!IsFilled || Contract.Result<double>() > 0); 
                if (IsFilled)
                {
                    return (double)PixelWidth / PixelHeight;
                }
                else
                {
                    return 0;
                }
            }
        }
        
        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="ImageBase"/> class
        /// with the height and the width of the image.
        /// </summary>
        /// <param name="width">The width of the image in pixels.</param>
        /// <param name="height">The height of the image in pixels.</param>
        /// <exception cref="ArgumentException">
        ///     <para><paramref name="width"/> is equals or less than zero.</para>
        ///     <para>- or -</para>
        ///     <para><paramref name="height"/> is equals or less than zero.</para>
        /// </exception>
        public ImageBase(int width, int height)
        {
            //Contract.Requires<ArgumentException>(width >= 0, "Width must be greater or equals than zero.");
            //Contract.Requires<ArgumentException>(height >= 0, "Height must be greater or equals than zero.");
            //Contract.Ensures(IsFilled);

            _pixelWidth = width;
            _pixelHeight = height;

            _pixels = new byte[PixelWidth * PixelHeight * 4];

            _isFilled = true;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ImageBase"/> class
        /// by making a copy from another image.
        /// </summary>
        /// <param name="other">The other, where the clone should be made from.</param>
        /// <exception cref="ArgumentNullException"><paramref name="other"/> is null
        /// (Nothing in Visual Basic).</exception>
        /// <exception cref="ArgumentException"><paramref name="other"/> is not loaded.</exception>
        public ImageBase(ImageBase other)
        {
            //Contract.Requires<ArgumentNullException>(other != null, "Other image cannot be null.");
            //Contract.Requires<ArgumentException>(other.IsFilled, "Other image has not been loaded.");
            //Contract.Ensures(IsFilled);

            byte[] pixels = other.Pixels;

            _pixelWidth = other.PixelWidth;
            _pixelHeight = other.PixelHeight;
            _pixels = new byte[pixels.Length];

            Array.Copy(pixels, _pixels, pixels.Length);

            _isFilled = other.IsFilled;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ImageBase"/> class.
        /// </summary>
        public ImageBase()
        {
        }

        #endregion

        #region Methods

        /// <summary>
        /// Sets the pixel array of the image.
        /// </summary>
        /// <param name="width">The new width of the image.
        /// Must be greater than zero.</param>
        /// <param name="height">The new height of the image.
        /// Must be greater than zero.</param>
        /// <param name="pixels">The array with colors. Must be a multiple
        /// of four, width and height.</param>
        /// <exception cref="ArgumentException">
        /// 	<para><paramref name="width"/> is smaller than zero.</para>
        /// 	<para>- or -</para>
        /// 	<para><paramref name="height"/> is smaller than zero.</para>
        /// 	<para>- or -</para>
        /// 	<para><paramref name="pixels"/> is not a multiple of four, 
        /// 	width and height.</para>
        /// </exception>
        /// <exception cref="ArgumentNullException"><paramref name="pixels"/> is null.</exception>
        public void SetPixels(int width, int height, byte[] pixels)
        {
            //Contract.Requires<ArgumentException>(width >= 0, "Width must be greater than zero.");
            //Contract.Requires<ArgumentException>(height >= 0, "Height must be greater than zero.");
            //Contract.Requires<ArgumentNullException>(pixels != null, "Pixels cannot be null.");
            //Contract.Ensures(IsFilled);

            if (pixels.Length != width * height * 4)
            {
                throw new ArgumentException(
                    "Pixel array must have the length of width * height * 4.",
                    "pixels");
            }

            _pixelWidth = width;
            _pixelHeight = height;
            _pixels = pixels;

            _isFilled = true;
        }

        #endregion
    }
}
