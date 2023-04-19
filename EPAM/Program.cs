using EPAM.Classes;

namespace EPAM
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Bird bird = new Bird();
            TimeSpan birdFlyTime = bird.GetFlyTime(new Strctures.Coordinate(12, 2, 4));
            Console.WriteLine($"Bird has flown {Math.Round(bird.GetDistance(new Strctures.Coordinate(12, 2, 4)))} km" +
                $" distance under {birdFlyTime.Days} days" +
                $" {birdFlyTime.Hours}:{birdFlyTime.Minutes}:{birdFlyTime.Seconds}" +
                $" with {bird.Speed} speed");
            Plane plane = new Plane();
            Console.WriteLine(plane.GetFlyTime(new Strctures.Coordinate(12244, 5541, 1152)));
            Drone drone = new Drone();
            Console.WriteLine(drone.GetFlyTime(new Strctures.Coordinate(44, 11, 82)));
            Console.WriteLine(drone.Battery);
        }
    }
}