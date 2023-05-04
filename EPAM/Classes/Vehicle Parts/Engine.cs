namespace EPAM.Classes.Vehicle_Parts
{
    internal enum EngineTypes
    {
        ESS,
        DSL,
        MHEV,
        HEV,
        PHEV
    }
    internal class Engine
    {
        internal double Power { get; private set; }
        internal double Volume { get; private set; }
        internal EngineTypes Type { get; private set; }
        internal int SerialNumber { get; private set; }


        internal Engine(double power, double volume, EngineTypes type, int serialNumber)
        {
            Power = power;
            Volume = volume;
            Type = type;
            SerialNumber = serialNumber;
        }
    }
}
