using EPAM.Classes.Vehicle_Parts;

namespace EPAM.Classes.Vehicles
{
    internal abstract class Vehicle
    {
        //Common properties
        internal Chassis Chassis { get; set; }
        internal Engine Engine { get;  set; }
        internal Transmission Transmission { get; set; }

        protected Vehicle(Chassis chassis, Engine engine, Transmission transmission)
        {
            Chassis = chassis;
            Engine = engine;
            Transmission = transmission;
        }

        public override string ToString()
        {
            return $"Chassis: Wheels - {Chassis.Wheels}, Load capacity - {Chassis.LoadCapacity}, Tire width - {Chassis.TireWidth}\n" +
                   $"Engine: Power - {Engine.Power}, Volume - {Engine.Volume}, Type - {Engine.Type}, Serial number - {Engine.SerialNumber}\n" +
                   $"Transmission: Manufacturer - {Transmission.Manufacturer}, Gears - {Transmission.Gears}, Type - {Transmission.Type}\n";
        }
    }
}
