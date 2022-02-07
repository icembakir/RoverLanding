using RoverLanding.Exceptions;
using RoverLanding.Services;

namespace RoverLanding
{
    /// <summary>
    /// This class shows how to use CalculationService.
    /// Unit tests aren't written for this one.
    /// </summary>
    public class SpaceAdministration : ISpaceAdministration
    {
        private readonly ICalculationService _calculationService;
        private readonly ILandingPlatform _landingPlatform;
        private readonly IRover _rover;

        public SpaceAdministration(ICalculationService calculationService, ILandingPlatform landingPlatform, IRover rover)
        {
            _calculationService = calculationService;
            _landingPlatform = landingPlatform;
            _rover = rover;
        }
        public void ValidateLandingPlatform()
        {
            try
            {
                _calculationService.ValidateLandingPlatform(_landingPlatform);
            }
            catch (LandingPlatformOutOfRangeException ex)
            {

                throw ex;
            }

        }

        public void CheckinRover()
        {
            try
            {
                _calculationService.ValidateRoverLandingCoordinates(_rover, _landingPlatform);
            }
            catch (RoverCheckinException ex)
            {

                throw ex;
            }

        }
    }
}
