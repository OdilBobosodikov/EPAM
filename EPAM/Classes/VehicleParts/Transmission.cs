namespace EPAM.Classes.VehicleParts
{
    internal class Transmission
    {
        private readonly short maxGears = 15;
        private readonly short minGears = 0;

        internal TransmissionTypes Type { get; private set; }
        internal short Gears { get; private set; }
        internal string Manufacturer { get; private set; }


        //Some Vehicles do not have gears, thats why gears is 0 by default 
        internal Transmission(TransmissionTypes type, string manufacturer, short gears = 0)
        {
            if ((gears > maxGears || gears < minGears) || string.IsNullOrEmpty(manufacturer))
            {
                throw new ArgumentException();
            }
            Gears = gears;
            Manufacturer = manufacturer;
            Type = type;
        }
    }
}
