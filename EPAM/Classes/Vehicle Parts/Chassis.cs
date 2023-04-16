namespace EPAM.Classes.Vehicle_Parts
{
    internal class Chassis
    {
        //fields wheels, id, loadCapacity
        //No information is given about methods for this class
        public short Wheels { get; private set; }
        public double TireWidth { get; private set; }
        public int LoadCapacity { get; private set; }


        public Chassis(short wheels, double tireWidth, int loadCapacity)
        {
            Wheels = wheels;
            TireWidth = tireWidth;
            LoadCapacity = loadCapacity;
        }
    }
}
