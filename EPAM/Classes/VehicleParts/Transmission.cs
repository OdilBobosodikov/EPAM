namespace EPAM.Classes.VehicleParts
{

    internal class Transmission
    {
        private readonly short MaxGearNo = 18;
        private readonly short MinGearNo = 0;

        internal TransmissionTypes Type { get; private set; }
        internal short Gears { get; private set; }
        internal string Manufacturer { get; private set; }


        //Some Vehicles do not have gears, thats why gears is 0 by default 
        internal Transmission(TransmissionTypes type, string manufacturer, short gears = 0)
        {
            if(!IsValid(manufacturer, gears))
            {
                throw new ArgumentException();
            }
            Gears = gears;
            Manufacturer = manufacturer;
            Type = type;
        }

        private bool IsValid(string manufacturer, short gears)
        {
            if((gears > MaxGearNo || gears < MinGearNo) || string.IsNullOrEmpty(manufacturer))
            {
                return false;
            }
            return true;
        }
    }
}
