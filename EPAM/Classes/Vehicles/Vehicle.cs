using EPAM.Classes.Vehicle_Parts;

namespace EPAM.Classes.Vehicles
{
    internal class Vehicle
    { 
        //Common properties
        public Chassis Chassis { get; private set; }
        public Engine Engine { get; private set; }
        public Transmission Transmission { get; private set; }

        //Checks if se set unique properties for child classes
        protected bool SetUniqueProperties = false;
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
