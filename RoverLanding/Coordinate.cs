using RoverLanding.Constants;
using RoverLanding.Exceptions;
using System;
using System.Collections.Generic;
using System.Text;

namespace RoverLanding
{
    public class Coordinate
    {
        public int X { get; set; }
        public int Y { get; set; }

        public Coordinate(int x, int y)
        {
            if (x < Boundary.LandingAreaStartingCoordinateX || x > Boundary.LandingAreaEndingCoordinateX || 
                y < Boundary.LandingAreaStartingCoordinateY || y > Boundary.LandingAreaEndingCoordinateY)
            {
                throw new CoordinatesOutOfRangeException();
            }

            X = x;
            Y = y;
        }
    }
}
