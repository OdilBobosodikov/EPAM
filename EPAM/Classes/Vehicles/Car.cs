using EPAM.Classes.VehicleParts;
using EPAM.Classes.Exceptions;

namespace EPAM.Classes.Vehicles
{
    internal class Car : Vehicle
    {
        private readonly short maxSeats = 8;
        private readonly short minSeats = 2;

        public bool HasCruiseControl { get; set; } = false;
        public CarTypes CarType { get;  set; } = CarTypes.NotSelected;
        public byte Seats { get;  set; }
        public string Model { get; set; }


        internal Car(Chassis chassis, Engine engine,
                Transmission transmission,
                CarTypes type,
                bool hasCruiseControl,
                byte numberOfSeats, string model) : base(chassis, engine, transmission)
        {
            if (numberOfSeats > maxSeats || numberOfSeats < minSeats || string.IsNullOrEmpty(model))
            {
                throw new InitializationException();
            }

            CarType = type;
            HasCruiseControl = hasCruiseControl;
            Seats = numberOfSeats;
            Model = model;
        }
        public override string ToString()
        {
            return $"Unique Car properties: Model - {Model}, Type - {CarType}, Has cruise control - {HasCruiseControl}, Seats - {Seats}\n" + base.ToString();
        }
    }
}
