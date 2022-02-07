using System;
using System.Collections.Generic;
using System.Text;

namespace RoverLanding.Constants
{
    public static class Message
    {
        public const string RoverCheckinSuccessMessage = "OK for landing";
        public const string RoverClashExceptionMessage = "Clash";
        public const string RoverOutOfPlatformExceptionMessage = "Out of platform";        
        public const string CoordinatesOutOfRangeExceptionMessage = "Coordinates(X,Y) must be between 0 and 100";
        public const string LandingPlatformBordersOutOfRangeExceptionMessage = "Platform's borders are out of landing area";
        public const string LandingPlatformInvalidWidthHeightExceptionMessage = 
            "Platform's width/height must be beetween 1 and 100 depending on platform's starting coordinate";
        
    }
}
