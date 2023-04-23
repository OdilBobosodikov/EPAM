namespace EPAM.Classes.Vehicle_Parts
{
    internal class Chassis
    {
        internal short Wheels { get; private set; }
        internal double TireWidth { get; private set; }
        internal int LoadCapacity { get; private set; }


        internal Chassis(short wheels, double tireWidth, int loadCapacity)
        {
            Wheels = wheels;
            TireWidth = tireWidth;
            LoadCapacity = loadCapacity;
        }
    }
}
