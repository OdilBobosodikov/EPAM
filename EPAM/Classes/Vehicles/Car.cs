using EPAM.Classes.Vehicle_Parts;

namespace EPAM.Classes.Vehicles
{
    internal enum CarTypes
    {
        SportCar,
        SuperCar,
        Universal,
        Cabriolet,
        Crossover
    }

    internal class Car : Vehicle
    {
        //Requested unique properties
        internal bool HasCruiseControl { get; private set; } = false;
        internal CarTypes Type { get; private set; }
        internal byte Seats { get; private set; }

        internal Car(Chassis chassis, Engine engine, Transmission transmission) : base(chassis, engine, transmission)
        {}

        internal void SetCarProperties(CarTypes type, bool hasCruiseControl, byte numberOfSeats)
        {
            Type = type;
            HasCruiseControl = hasCruiseControl;
            Seats = numberOfSeats;
            SetUniqueProperties = true;
        }

        public override string ToString()
        {

            if (!SetUniqueProperties)
            {
                return $"Unique Car properties have not set yet\n" + base.ToString();
            }
            return $"Unique Car properties: Type - {Type}, Has cruise control - {HasCruiseControl.ToString()}, Seats - {Seats}\n" + base.ToString();
        }
    }
}
