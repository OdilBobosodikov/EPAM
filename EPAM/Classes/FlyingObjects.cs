﻿using EPAM.Structures;

namespace EPAM.Classes
{
    internal abstract class FlyingObjects
    {
        internal abstract Coordinate CurrentPosition { get; set; }

        //To make proper calculations we should consider unit of the destance same for all cases
        //So the distance will be in km format
        internal double GetDistance(Coordinate NewPosition)
        {
            return Math.Sqrt(Math.Pow(NewPosition.X - CurrentPosition.X, 2) +
                Math.Pow(NewPosition.Y - CurrentPosition.Y, 2) +
                Math.Pow(NewPosition.Z - CurrentPosition.Z, 2));
        }
        protected double SpeedKmToMConverter(double val)
        {
            return val * 5 / 18;
        }
    }
}
