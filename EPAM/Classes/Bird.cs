using EPAM.Interfaces;
using EPAM.Strctures;
using System.Data;

namespace EPAM.Classes
{
    internal class Bird : FlyingObjects, IFlyable
    {
        public override Coordinate CurrentPosition { get; set; } = new Coordinate { X = 0, Y = 0, Z = 0 };
        
        //Speed is in m/s formate
        public double Speed { get; private set; }

        public void FlyTo(Coordinate coordinate)
        {
            CurrentPosition = coordinate;
        }

        public TimeSpan GetFlyTime(Coordinate coordinate)
        {
            //Set new Speed each time method is called
            UpdateSpeed();

            //distance between current and new position
            //convert km to m
            double distance = GetDistance(coordinate) * 1000;
            
            int seconds = 0;
            double passedDistance = 0;

            while(passedDistance < distance){
                seconds++;
                passedDistance += Speed;
            }
            return TimeSpan.FromSeconds(seconds);
        }
        private void UpdateSpeed()
        { 
            Random rand = new Random();
            Speed = rand.NextDouble() * 20; 
        }
    }
}
