using EPAM.Structures;

namespace EPAM.Interfaces
{
    internal interface IFlyable
    {
        internal void FlyTo(Coordinate coordinate);
        internal TimeSpan GetFlyTime(Coordinate coordinate);
    }
}
