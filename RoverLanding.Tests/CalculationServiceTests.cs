using RoverLanding.Constants;
using RoverLanding.Exceptions;
using RoverLanding.Services;
using System;
using Xunit;

namespace RoverLanding.Tests
{
    public class CalculationServiceTests
    {
        private readonly ICalculationService _calculationService;
        public CalculationServiceTests()
        {
            _calculationService = new CalculationService();
        }

        [Fact]
        public void CoordinatesValidation_NegativeCordinates_ThrowsCoordinatesOutOfRangeException()
        {
            Action testCoordinates = () => new Coordinate(-2, 5);

            var exception = Assert.Throws<CoordinatesOutOfRangeException>(testCoordinates);
            Assert.Equal(exception.Message, Message.CoordinatesOutOfRangeExceptionMessage);
        }

        [Fact]
        public void LandingPlatformValidation_InvalidBorders_ThrowsLandingPlatformOutOfRangeException()
        {
            var startingCoordinate = new Coordinate(40, 40);

            Action validateLandingPlatform = () => _calculationService.ValidateLandingPlatform(new LandingPlatform(startingCoordinate, 10, 61));

            var exception = Assert.Throws<LandingPlatformOutOfRangeException>(validateLandingPlatform);
            Assert.Equal(exception.Message, Message.LandingPlatformBordersOutOfRangeExceptionMessage);
        }

        [Fact]
        public void LandingPlatformValidation_InvalidWidthHeight_ThrowsLandingPlatformOutOfRangeException()
        {
            var startingCoordinate = new Coordinate(40, 40);

            Action validateLandingPlatform = () => _calculationService.ValidateLandingPlatform(new LandingPlatform(startingCoordinate, 0, 101));

            var exception = Assert.Throws<LandingPlatformOutOfRangeException>(validateLandingPlatform);
            Assert.Equal(exception.Message, Message.LandingPlatformInvalidWidthHeightExceptionMessage);
        }

        [Fact]
        public void LandingPlatformValidation_WithValidStartingCoordinatesAndBorders_DoesNotThrowException()
        {
            var startingCoordinate = new Coordinate(40, 40);

            var exception = Record.Exception(() => _calculationService.ValidateLandingPlatform(new LandingPlatform(startingCoordinate, 10, 10)));
            Assert.Null(exception);
        }

        [Fact]
        public void RoverLandingCoordinatesValidation_WithCordinatesOutOfPlatform_ThrowsRoverCheckinException()
        {
            var landingPlatformStartingCoordinate = new Coordinate(5, 5);
            var landingPlatform = new LandingPlatform(landingPlatformStartingCoordinate, 10, 10);
            var rover = Rover.Instance;
            rover.SetCoordinate(new Coordinate(16, 5));

            Action validateLandingCoordinates = () => _calculationService.ValidateRoverLandingCoordinates(rover, landingPlatform);

            var exception = Assert.Throws<RoverCheckinException>(validateLandingCoordinates);
            Assert.Equal(exception.Message, Message.RoverOutOfPlatformExceptionMessage);
        }

        [Fact]
        public void RoverLandingCoordinatesValidation_WithInBoundariesPreviousRover_ThrowsRoverCheckinException()
        {
            var landingPlatformStartingCoordinate = new Coordinate(5, 5);
            var landingPlatform = new LandingPlatform(landingPlatformStartingCoordinate, 10, 10);
            var rover = Rover.Instance;

            rover.SetCoordinate(new Coordinate(7, 7));
            _calculationService.ValidateRoverLandingCoordinates(rover, landingPlatform);

            rover.SetCoordinate(new Coordinate(6, 6));
            Action validateLandingCoordinates = () => _calculationService.ValidateRoverLandingCoordinates(rover, landingPlatform);

            rover.SetCoordinate(new Coordinate(7, 8));
            Action validateSecondLandingCoordinates = () => _calculationService.ValidateRoverLandingCoordinates(rover, landingPlatform);

            var exception = Assert.Throws<RoverCheckinException>(validateLandingCoordinates);
            Assert.Equal(exception.Message, Message.RoverClashExceptionMessage);

            exception = Assert.Throws<RoverCheckinException>(validateSecondLandingCoordinates);
            Assert.Equal(exception.Message, Message.RoverClashExceptionMessage);
        }

        [Fact]
        public void RoverLandingCoordinatesValidation_WithValidCoordinate_DoesNotThrowException()
        {
            var landingPlatformStartingCoordinate = new Coordinate(5, 5);
            var landingPlatform = new LandingPlatform(landingPlatformStartingCoordinate, 10, 10);
            var rover = Rover.Instance;
            rover.SetCoordinate(new Coordinate(5, 5));

            var exception = Record.Exception(() => _calculationService.ValidateRoverLandingCoordinates(rover, landingPlatform));
            Assert.Null(exception);
        }

    }
}
