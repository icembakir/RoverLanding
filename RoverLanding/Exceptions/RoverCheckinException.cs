using System;
using System.Collections.Generic;
using System.Text;

namespace RoverLanding.Exceptions
{
    public class RoverCheckinException : Exception
    {
        public RoverCheckinException(string message)
            : base(message)
        {

        }
    }
}
