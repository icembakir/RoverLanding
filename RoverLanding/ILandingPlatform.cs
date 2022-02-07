namespace RoverLanding
{
    public interface ILandingPlatform
    {
        Coordinate Coordinate { get; set; }

        int Height { get; set; }

        int LandingAreaHeight { get; }

        int LandingAreaWidth { get; }

        int Width { get; set; }
    }
}