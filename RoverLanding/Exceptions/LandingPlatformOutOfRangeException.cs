using System;
using System.Collections.Generic;
using System.Text;

namespace RoverLanding.Exceptions
{
    public class LandingPlatformOutOfRangeException : Exception
    {
        public LandingPlatformOutOfRangeException(string message) 
            : base(message)
        {

        }
    }
}
