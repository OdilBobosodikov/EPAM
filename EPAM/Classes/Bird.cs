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

            //To maintain high accuracy we convert the distance to M in the beginig
            //However it is not optimizated and may require to much time for calculation

            //double distance = GetDistance(coordinate) * 1000;

            //Thats why I devide the distance to the five parts and multiply seconds to 5, to reduce the calculation time
            //It is optimal choice, if we will take more accuracy will decrece 

            //For 13488 km difference is 1 sec between previously discribed approaches

            double distance = GetDistance(coordinate) * 200;
            int seconds = 0;
            double passedDistance = 0;

            while(passedDistance < distance){
                seconds++;
                passedDistance += Speed;
            }
            return TimeSpan.FromSeconds(5*seconds);
        }
        private void UpdateSpeed()
        { 
            Random rand = new Random();
            Speed = rand.NextDouble() * 20; 
        }
    }
}
