namespace EPAM.Classes.Vehicle_Parts
{
    internal class Transmission
    {
        //fields type, gears, manufacturer
        //No information is given about methods for this class
        public string Type { get; private set; }
        public short Gears { get; private set; }
        public string Manufacturer { get; private set; }

        //Some Vehicles do not have gears, thats why gears is 0 by default 
        public Transmission(string type, string manufacturer, short gears = 0)
        {
            Gears = gears;
            Manufacturer = manufacturer;
            Type = type;
        }
    }
}
