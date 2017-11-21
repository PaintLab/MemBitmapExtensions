using System;
namespace ZkImgs
{
    public class InvalidDataException : Exception
    {
        public InvalidDataException(string msg) : base(msg) { }
    }
    public class AggregateException : Exception
    {
        public AggregateException(string msg) : base(msg) { }
    }

}