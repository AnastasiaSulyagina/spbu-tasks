using System;

namespace hw4.Exceptions
{
    public sealed class WrongCoupleException : Exception
    {
        public WrongCoupleException(String message) : base(message)
        { }
    }
}
