using EPAM.Strctures;

namespace EPAM.Classes
{
    internal abstract class FlyingObjects
    {
        public abstract Coordinate CurrentPosition { get; set; }


        //To make proper calculations we should consider unit of the destance same for all cases
        //So the distance will be in km format
        public double GetDistance(Coordinate NewPosition)
        {
            return Math.Sqrt(Math.Pow(NewPosition.X - CurrentPosition.X, 2) 
                + Math.Pow(NewPosition.Y - CurrentPosition.Y, 2) 
                + Math.Pow(NewPosition.Z - CurrentPosition.Z, 2));
        }
    }
}
