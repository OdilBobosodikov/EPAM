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
        //Unique properties
        public ScooterFuel Fuel { get; private set; }
        public double MaxSpeed { get; private set; }

        public Scooter(Chassis chassis, Engine engine, Transmission transmission) : base(chassis, engine, transmission)
        {

        }

        public void SetScooterProperties(ScooterFuel fuel, double speed)
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
