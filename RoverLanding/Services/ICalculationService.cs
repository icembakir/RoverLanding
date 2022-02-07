using System;
using System.Collections.Generic;
using System.Text;

namespace RoverLanding.Services
{
    public interface ICalculationService
    {
        public void ValidateLandingPlatform(ILandingPlatform landingPlatform);
        public string ValidateRoverLandingCoordinates(IRover rover, ILandingPlatform landingPlatform);
    }
}
