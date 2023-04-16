

using EPAM.Interfaces;
using EPAM.Strctures;

namespace EPAM.Classes
{
    internal class Plane : FlyingObjects, IFlyable
    {
        public override Coordinate CurrentPosition { get; set; } = new Coordinate { X = 0, Y = 0, Z = 0 };
        
        //Speed is in km/h format 
        public double Speed { get; private set; } = 200;

        //Acceleration is in km/h^2 format 
        public double Acceleration { get; private set; } = 10;

        public void FlyTo(Coordinate coordinate)
        {
            CurrentPosition = coordinate;
        }
        public Plane(double speed, double acceleration)
        {
            Speed = speed;
            Acceleration = acceleration;
        }
        public TimeSpan GetFlyTime(Coordinate coordinate)
        {
            //distance between current and new position
            //convert km to m
            double distance = GetDistance(coordinate) * 1000;

            int minutes = 0;
            double passedDistance = 0;

            while (passedDistance < distance)
            {
                minutes++;
                passedDistance += Speed;
            }
            return TimeSpan.FromSeconds(minutes);
        }
    }
}
