using EPAM.Interfaces;
using EPAM.Structures;

namespace EPAM.Classes
{
    internal class Plane : FlyingObjects, IFlyable
    {
        internal override Coordinate CurrentPosition { get; set; } = new Coordinate { X = 0, Y = 0, Z = 0 };

        //Speed is in km/h format 
        internal double SpeedKm { get; private set; } = 200;
        internal double SpeedBoostKm { get; private set; } = 10;
        internal double DistanceKm { get; private set; } = 10;

        public void FlyTo(Coordinate coordinate)
        {
            CurrentPosition = coordinate;
        }

        public TimeSpan GetFlyTime(Coordinate coordinate)
        {
            double distance = GetDistance(coordinate) * 1000;
            //PassedDistance in m
            double passedDistance;
            double boostDistance = 0;
            double speedM = SpeedKmToMConverter(SpeedKm);
            double speedBoostM = SpeedKmToMConverter(SpeedBoostKm);
            double distanceM = DistanceKm * 1000;
            int seconds = 0;
            for(passedDistance = 0; passedDistance < distance; passedDistance+= speedM, boostDistance += speedM)
            {
                seconds++;
                double boostCheck = Math.Ceiling(boostDistance) % distanceM;
                if((boostCheck < boostDistance || boostCheck == 0) && passedDistance != 0)
                {
                    speedM += speedBoostM;
                    boostDistance = 0;
                }
            }
            return TimeSpan.FromSeconds(seconds);
        }
    }
}
