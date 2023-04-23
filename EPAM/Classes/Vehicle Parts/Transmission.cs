namespace EPAM.Classes.Vehicle_Parts
{
    internal class Transmission
    {
        internal string Type { get; private set; }
        internal short Gears { get; private set; }
        internal string Manufacturer { get; private set; }


        //Some Vehicles do not have gears, thats why gears is 0 by default 
        internal Transmission(string type, string manufacturer, short gears = 0)
        {
            Gears = gears;
            Manufacturer = manufacturer;
            Type = type;
        }
    }
}
