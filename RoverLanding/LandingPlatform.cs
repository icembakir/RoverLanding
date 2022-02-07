using RoverLanding.Exceptions;
using System;

namespace RoverLanding
{
    public class LandingPlatform : ILandingPlatform
    {
        public const int x = 3;
        public int LandingAreaWidth { get; } = 100;

        public int LandingAreaHeight { get; } = 100;

        public Coordinate Coordinate { get; set; }

        public int Height { get; set; }

        public int Width { get; set; }

        public LandingPlatform(Coordinate coordinate, int width, int height)
        {
            Coordinate = coordinate;
            Width = width;
            Height = height;            
        }
    }
}
