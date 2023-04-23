namespace EPAM.Classes.Vehicle_Parts
{
    internal class Engine
    {
        internal double Power { get; private set; }
        internal double Volume { get; private set; }
        internal string Type { get; private set; }
        internal int SerialNumber { get; private set; }


        internal Engine(double power, double volume, string type, int serialNumber)
        {
            Power = power;
            Volume = volume;
            Type = type;
            SerialNumber = serialNumber;
        }
    }
}
