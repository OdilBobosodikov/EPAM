namespace EPAM.Classes.VehicleParts
{
    internal class Chassis
    {
        #region readonly fields for validation purposes
        private readonly short maxWheels = 20;
        private readonly short minWheels = 2;

        private readonly double maxTireWidth = 690;
        private readonly double minTireWidth = 65;

        private readonly int maxLoadCapacity = 15000;
        private readonly int minLoadCapacity = 90;
        #endregion

        internal short Wheels { get; private set; }
        internal double TireWidth { get; private set; }
        internal int LoadCapacity { get; private set; }


        internal Chassis(short wheels, double tireWidth, int loadCapacity)
        {
            if (!IsValid(wheels, tireWidth, loadCapacity))
            {
                throw new ArgumentException();
            }
            Wheels = wheels;
            TireWidth = tireWidth;
            LoadCapacity = loadCapacity;
        }

        private bool IsValid(short wheels, double tireWidth, int loadCapacity)
        {
            if ((wheels > maxWheels || wheels < minWheels)
                || (tireWidth > maxTireWidth || tireWidth < minTireWidth)
                || (loadCapacity > maxLoadCapacity || loadCapacity < minLoadCapacity))
            {
                return false;
            }
            return true;
        }
    }
}
