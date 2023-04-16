using EPAM.Strctures;

namespace EPAM.Interfaces
{
    internal interface IFlyable
    {
        public void FlyTo(Coordinate coordinate);
        public TimeSpan GetFlyTime(Coordinate coordinate);
    }
}
