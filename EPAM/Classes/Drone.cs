using EPAM.Interfaces;
using EPAM.Structures;

namespace EPAM.Classes
{
    internal class Drone : FlyingObjects, IFlyable
    {
        /// <summary>
        /// Additional restrictions
        /// Drone has a battery with a paricular amount of energy
        /// If battary is 0, drone stops the flight and lends on the particular position\
        /// To update battery value use Recharge method
        /// </summary>

        internal override Coordinate CurrentPosition { get; set; } = new Coordinate { X = 0, Y = 0, Z = 0 };
        internal double SpeedKm { get; set; } = 150;
        internal double Battery { get; set; } = 100;

        //Both properties in sec
        internal double TimeToStop { get; set; } = 60;
        internal double TimeBeforeStop { get; set; } = 600;

        public void FlyTo(Coordinate coordinate)
        {
            if (Battery == 0)
            {
                Console.WriteLine("No charge left");
                return;
            }
            double distance = GetDistance(coordinate) * 1000;
            double speedM = SpeedKmToMConverter(SpeedKm);
            double distancePassed;
            for (distancePassed = 0; distancePassed < distance; distancePassed += speedM)
            {
                //We are checking the battary status to stop program on time and set new coordinates
                if (Battery <= 0)
                {
                    Battery = 0;
                    UpdateCoordinates(coordinate, distance, distancePassed);
                    Console.WriteLine("Your drone's battery ran out of the energy");
                    PrintPosition();
                    return;
                }
                UpdateBattery(speedM);
            }
            CurrentPosition = coordinate;
        }

        internal void Recharge(double energy = 100)
        {
           Battery = energy;
        }

        public TimeSpan GetFlyTime(Coordinate coordinate)
        {
            double distance = GetDistance(coordinate) * 200;
            double speedM = SpeedKmToMConverter(SpeedKm);
            double distancePassed;
            double seconds = 0;
            for(distancePassed = 0; distancePassed < distance; distancePassed += speedM)
            {
                if (seconds % (TimeBeforeStop) == 0 && seconds != 0)
                {
                    seconds += TimeToStop;
                }
                else
                {
                    seconds++;
                }
            }
            return TimeSpan.FromSeconds(5*seconds);
        }

        private void PrintPosition()
        {
            Console.WriteLine($"Your drone lended on {CurrentPosition} position\n");
        }

        private void UpdateBattery(double speed)
        {
            //Random formula to steadly decrease battery
            Battery -= speed * 0.001 / 2;
        }

        private void UpdateCoordinates(Coordinate newCoordinate, double distance, double distancePassed)
        {
            //Formula: https://math.stackexchange.com/questions/1735994/position-of-point-between-2-points-in-3d-space

            double s = distancePassed / distance;

            Coordinate V3 = new Coordinate(Math.Round(CurrentPosition.X + s * (newCoordinate.X - CurrentPosition.X),3),
                Math.Round(CurrentPosition.Y + s * (newCoordinate.Y - CurrentPosition.Y), 3),
                Math.Round(CurrentPosition.Z + s * (newCoordinate.Z - CurrentPosition.Z), 3));

            CurrentPosition = V3;
        }
    }
}
