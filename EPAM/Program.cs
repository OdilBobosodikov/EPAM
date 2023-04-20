using EPAM.Classes;
using EPAM.Strctures;

namespace EPAM
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool programStopped = false;
            Coordinate newCoordinates;
            do {
                Console.WriteLine("Which flying object you would like to choose: ");
                Console.WriteLine("1 for bird");
                Console.WriteLine("2 for palne");
                Console.WriteLine("3 for drone");
                Console.WriteLine("4 to exit");
                Console.Write("-- ");
                if(int.TryParse(Console.ReadLine(), out int ch) && ch > 0 && ch < 5)
                {
                    switch (ch)
                    {
                        case 1:
                            Bird bird = new Bird();
                            newCoordinates = TakeCoordinates();
                            TimeSpan birdFlyTime = bird.GetFlyTime(newCoordinates);

                            Console.WriteLine($"bird initial position is " + newCoordinates);

                            Console.WriteLine($"Bird will fly {Math.Round(bird.GetDistance(new Strctures.Coordinate(12, 2, 4)))} km distance\n" +
                            $"Under {birdFlyTime.Days} days {birdFlyTime.Hours} hours {birdFlyTime.Minutes} minutes {birdFlyTime.Seconds} seconds\n" +
                            $"With {bird.Speed} speed\n");
                            
                            Console.Write("Do You want to set this position to bird? ");
                            
                            if(Console.ReadLine().ToLower().Equals("yes")){
                                bird.FlyTo(newCoordinates);
                            }
                            break;
                        case 2:
                            Plane plane = new Plane();
                            newCoordinates = TakeCoordinates();
                            TimeSpan palneFlyTime = plane.GetFlyTime(newCoordinates);

                            Console.WriteLine($"plane initial position is " + newCoordinates);

                            Console.WriteLine($"Plane will fly {Math.Round(plane.GetDistance(new Strctures.Coordinate(12, 2, 4)))} km distance\n" +
                                $"Under {palneFlyTime.Days} days {palneFlyTime.Hours} hours {palneFlyTime.Minutes} minutes {palneFlyTime.Seconds} seconds\n" +
                                $"with {plane.SpeedKm} speed that will be increased by {plane.SpeedBoostKm} km/h each time plane passed {plane.DistanceKm} km\n");
                            
                            Console.Write("Do You want to set this position to plane? ");
                            
                            if (Console.ReadLine().ToLower().Equals("yes")){
                                plane.FlyTo(newCoordinates);
                            }
                            break;
                        case 3:
                            Drone drone = new Drone();
                            newCoordinates = TakeCoordinates();
                            TimeSpan droneFlyTime = drone.GetFlyTime(newCoordinates);

                            Console.WriteLine($"drone initial position is " + newCoordinates);

                            Console.WriteLine($"Drone will fly {Math.Round(drone.GetDistance(new Strctures.Coordinate(12, 2, 4)))} km distance\n" +
                                $"Under {droneFlyTime.Days} days {droneFlyTime.Hours} hours {droneFlyTime.Minutes} minutes {droneFlyTime.Seconds} seconds\n" +
                                $"With {drone.SpeedKm} speed\n");

                            Console.Write("Do You want to set this position to plane? ");

                            if (Console.ReadLine().ToLower().Equals("yes"))
                            {
                                drone.FlyTo(newCoordinates);
                            }
                            break;
                        case 4:
                            programStopped = !programStopped;
                        break;
                    }
                }
                
            } while (!programStopped);

            Console.WriteLine("Bye");
        }

        public static Coordinate TakeCoordinates()
        {
            bool coordinatesTaken = false;

            while(!coordinatesTaken)
            {
                Console.WriteLine("Input X: ");
                if (double.TryParse(Console.ReadLine(), out double X) && X > 0)
                {
                    Console.WriteLine("Input Y: ");
                    if (double.TryParse(Console.ReadLine(), out double Y) && Y > 0)
                    {
                        Console.WriteLine("Input Z: ");
                        if (double.TryParse(Console.ReadLine(), out double Z) && Z > 0)
                        {
                            return new Coordinate(X, Y, Z);
                        }
                    }
                } 
            }
            return new Coordinate();
        }
    }
}