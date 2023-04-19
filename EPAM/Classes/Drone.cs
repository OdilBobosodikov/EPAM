using EPAM.Interfaces;
using EPAM.Strctures;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPAM.Classes
{
    internal class Drone : FlyingObjects, IFlyable
    {
        public override Coordinate CurrentPosition { get; set; } = new Coordinate { X = 0, Y = 0, Z = 0 };
        public double SpeedKm { get; set; } = 150;

        //additional restrictions
        //drone has a battery amount of battary
        //if battary is 0, drone stops the flight
        public double Battery { get; set; } = 100;
        
        //bothe properties in sec
        public double TimeToStop { get; set; } = 60;
        public double TimeBeforeStop { get; set; } = 600;
        

        public void FlyTo(Coordinate coordinate)
        {
            CurrentPosition = coordinate;
        }
        public void Recharge()
        {
           Battery = 100;
        }

        public TimeSpan GetFlyTime(Coordinate coordinate)
        {
            if(Battery == 0)
            {
                Console.WriteLine("No charge left");
                return TimeSpan.Zero;
            }
            //Convert to km
            double distance = GetDistance(coordinate) * 1000;
            double speedM = SpeedKmToMConverter(SpeedKm);
            double distancePassed;
            double seconds = 0;
            for(distancePassed = 0; distancePassed < distance; distancePassed += speedM)
            {
                if(Battery <= 0)
                {
                    Battery = 0;
                    Coordinate c = UpdateCoordinates(coordinate, distance, distancePassed);
                    PrintPosition(c);
                    return TimeSpan.FromSeconds(seconds);
                }
                if (seconds % (TimeBeforeStop) == 0 && seconds != 0)
                {
                    seconds += TimeToStop;
                    UpdateBattery(speedM, TimeToStop);
                }
                else
                {
                    UpdateBattery(speedM);
                    seconds++;
                }
            }
            return TimeSpan.FromSeconds(seconds);
        }
        public void PrintPosition(Coordinate c)
        {
            Console.WriteLine($"Your drone lended on ({c.X},{c.Y},{c.Z}) position\n");
        }
        private double SpeedKmToMConverter(double val)
        {
            return val * 5 / 18;
        }
        private void UpdateBattery(double speed,double timeSpan = 1)
        {
            Battery -= timeSpan * (speed * 0.001) / 2;
        }
        private Coordinate UpdateCoordinates(Coordinate newCoordinate, double distance, double distancePassed)
        {
            //formula: https://math.stackexchange.com/questions/1735994/position-of-point-between-2-points-in-3d-space

            double s = distancePassed / distance;

            Coordinate V3 = new Coordinate(CurrentPosition.X + s*(newCoordinate.X-CurrentPosition.X),
                CurrentPosition.Y + s * (newCoordinate.Y - CurrentPosition.Y),
                CurrentPosition.Z + s * (newCoordinate.Z - CurrentPosition.Z)); 
          
            FlyTo(V3);
            return V3;
        }
    }
}
