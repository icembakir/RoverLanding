namespace RoverLanding
{
    public interface IRover
    {
        Coordinate Coordinate { get; set; }
        Coordinate LastRoverCheckedinCoordinate { get; set; }
    }
}