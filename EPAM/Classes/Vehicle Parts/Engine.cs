namespace EPAM.Classes.Vehicle_Parts
{
    internal class Engine
    {
        //fields power, volume, type, serial number
        //No information is given about methods for this class
        public double Power { get; private set; }
        public double Volume { get; private set; }
        public string Type { get; private set; }
        public int SerialNumber { get; private set; }

        public Engine(double power, double volume, string type, int serialNumber)
        {
            Power = power;
            Volume = volume;
            Type = type;
            SerialNumber = serialNumber;
        }
    }
}
