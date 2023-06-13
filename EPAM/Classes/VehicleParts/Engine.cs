namespace EPAM.Classes.VehicleParts
{

    internal class Engine
    {
        #region readonly fields for validation purposes
        private readonly int digitNo = 6;
        private readonly double maxVolume = 15.8;
        private readonly int maxHorsePower = 700;
        private readonly int minVolume = 0;
        private readonly int minHorsePower = 0;
        #endregion 

        internal double Power { get; private set; }
        internal double Volume { get; private set; }
        internal EngineTypes Type { get; private set; }
        internal int SerialNumber { get; private set; }


        internal Engine(double power, double volume, EngineTypes type, int serialNumber)
        {
            if (!IsValid(power, volume, serialNumber))
            {
                throw new ArgumentException();
            }
            Power = power;
            Volume = volume;
            Type = type;
            SerialNumber = serialNumber;
        }

        private bool IsValid(double power, double volume, int serialNumber)
        {
            EnoughDigits(serialNumber);
            if ((power > maxHorsePower
                || power < minHorsePower)
                || (volume > maxVolume
                || volume < minVolume))
            {
                return false;
            }
            return true;
        }

        private void EnoughDigits(int serialNumber)
        {
            int count = 0;
            while (serialNumber > 0)
            {
                serialNumber = serialNumber / 10;
                count++;
            }
            if (count != digitNo)
            {
                throw new ArgumentException();
            }
        }
    }
}
