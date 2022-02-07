using System;

namespace RoverLanding
{
    public class Rover : IRover
    {
        public Coordinate Coordinate { get; set; }

        public Coordinate LastRoverCheckedinCoordinate { get; set; }

        private static readonly Lazy<Rover> _instance = new Lazy<Rover>(() => new Rover());

        private Rover()
        { 
        }

        public static Rover Instance
        {
            get { return _instance.Value; }
        }


        public void SetCoordinate(Coordinate coordinate)
        {
            Coordinate = coordinate;
        }
    }
}
