using EPAM.Classes;

namespace EPAM
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Bird bird = new Bird();
            Console.WriteLine(bird.GetFlyTime(new Strctures.Coordinate(2, 4, 5)));
        }
    }
}