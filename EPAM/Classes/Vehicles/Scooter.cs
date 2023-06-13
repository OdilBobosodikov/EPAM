using EPAM.Classes.VehicleParts;

namespace EPAM.Classes.Vehicles
{

    internal class Scooter : Vehicle
    {
        //Requested unique properties
        internal ScooterFuelTypes Fuel { get; private set; }
        internal double MaxSpeed { get; private set; }

        internal Scooter(Chassis chassis, Engine engine, Transmission transmission, ScooterFuelTypes fuel, double speed) : base(chassis, engine, transmission)
        {
            if (speed < 0)
            {
                throw new ArgumentException();
            }

            Fuel = fuel;
            MaxSpeed = speed;
        }

        public override string ToString()
        {
            return $"Unique Scooter properties: Scooter fuel - {Fuel}, Maximum speed - {MaxSpeed}\n" + base.ToString();
        }
    }
}
