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
        //Unique properties
        public bool HasCruiseControl { get; private set; } = false;
        public CarTypes Type { get; private set; }
        public byte Seats { get; private set; }

        public Car(Chassis chassis, Engine engine, Transmission transmission) : base(chassis, engine, transmission)
        {
        }

        public void SetCarTypes(CarTypes type, bool hasCruiseControl, byte numberOfSeats)
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
