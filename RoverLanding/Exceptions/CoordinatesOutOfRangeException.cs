using System;

namespace RoverLanding.Exceptions
{
    public class CoordinatesOutOfRangeException : Exception
    {
        public CoordinatesOutOfRangeException()
            : base(Constants.Message.CoordinatesOutOfRangeExceptionMessage)
        {
            
        }
    }
}
