using EPAM.Classes.Vehicle_Parts;

namespace EPAM.Classes.Vehicles
{
    internal enum ScooterFuel
    {
        LPG,
        CNG,
        HICE
    }
    internal class Scooter : Vehicle
    {
        //Requested unique properties
        internal ScooterFuel Fuel { get; private set; }
        internal double MaxSpeed { get; private set; }

        internal Scooter(Chassis chassis, Engine engine, Transmission transmission) : base(chassis, engine, transmission)
        {}

        internal void SetScooterProperties(ScooterFuel fuel, double speed)
        {
            Fuel = fuel;
            MaxSpeed = speed;
            SetUniqueProperties = true;
        }

        public override string ToString()
        {
            if (!SetUniqueProperties)
            {
                return $"Unique Scooter properties have not set yet\n" + base.ToString();
            }
            return $"Unique Scooter properties: Scooter fuel - {Fuel}, Maximum speed - {MaxSpeed}\n" + base.ToString();
        }
    }
}
