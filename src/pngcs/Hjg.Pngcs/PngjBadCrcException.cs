//Apache2, 2012, Hernan J. González, (https://github.com/leonbloy)
//Apache2, 2017, WinterDev
namespace Hjg.Pngcs
{

    using System;

    /// <summary>
    /// Exception for CRC check
    /// </summary>
    [Serializable]
    public class PngjBadCrcException : PngjException
    {
        private const long serialVersionUID = 1L;

        public PngjBadCrcException(String message, Exception cause)
            : base(message, cause)
        {
        }

        public PngjBadCrcException(String message)
            : base(message)
        {
        }

        public PngjBadCrcException(Exception cause)
            : base(cause)
        {
        }
    }
}
