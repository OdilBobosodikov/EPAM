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

        internal Scooter(Chassis chassis, Engine engine, Transmission transmission, ScooterFuel fuel, double speed) : base(chassis, engine, transmission)
        {
            Fuel = fuel;
            MaxSpeed = speed;
        }



        public override string ToString()
        {
            return $"Unique Scooter properties: Scooter fuel - {Fuel}, Maximum speed - {MaxSpeed}\n" + base.ToString();
        }
    }
}
