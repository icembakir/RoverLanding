using RoverLanding.Constants;
using RoverLanding.Exceptions;
using System;

namespace RoverLanding.Services
{
    public class CalculationService : ICalculationService
    {
        public const string RoverCheckinSuccessMessage = "OK for landing";

        public void ValidateLandingPlatform(ILandingPlatform landingPlatform)
        {
            if (landingPlatform.Width < 1 || landingPlatform.Width > Boundary.LandingAreaWidth ||
                landingPlatform.Height < 1 || landingPlatform.Height > Boundary.LandingAreaHeight)
            {
                throw new LandingPlatformOutOfRangeException(Message.LandingPlatformInvalidWidthHeightExceptionMessage);
            }

            if (landingPlatform.Coordinate.X + landingPlatform.Width > Boundary.LandingAreaWidth ||
                landingPlatform.Coordinate.Y + landingPlatform.Height > Boundary.LandingAreaHeight)
            {
                throw new LandingPlatformOutOfRangeException(Message.LandingPlatformBordersOutOfRangeExceptionMessage);
            }
        }

        public string ValidateRoverLandingCoordinates(IRover rover, ILandingPlatform landingPlatform)
        {
            if (rover.Coordinate.X < landingPlatform.Coordinate.X ||
                rover.Coordinate.Y < landingPlatform.Coordinate.Y ||
                rover.Coordinate.X >= landingPlatform.Coordinate.X + landingPlatform.Width ||
                rover.Coordinate.Y >= landingPlatform.Coordinate.Y + landingPlatform.Height)
            {
                throw new RoverCheckinException(Message.RoverOutOfPlatformExceptionMessage);
            }

            if (rover.LastRoverCheckedinCoordinate != null &&
                rover.Coordinate.X < rover.LastRoverCheckedinCoordinate.X + 2 &&
                rover.Coordinate.Y < rover.LastRoverCheckedinCoordinate.Y + 2 &&
                rover.Coordinate.X > rover.LastRoverCheckedinCoordinate.X - 2 &&
                rover.Coordinate.Y > rover.LastRoverCheckedinCoordinate.Y - 2)
            {
                throw new RoverCheckinException(Message.RoverClashExceptionMessage);
            }

            rover.LastRoverCheckedinCoordinate = rover.Coordinate;
            return Message.RoverCheckinSuccessMessage;

        }
    }
}
