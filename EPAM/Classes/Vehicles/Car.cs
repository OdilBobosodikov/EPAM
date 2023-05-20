using EPAM.Classes.Vehicle_Parts;
using EPAM.Classes.Exceptions;
namespace EPAM.Classes.Vehicles
{
    internal enum CarTypes
    {
        NotSelected,
        SportCar,
        SuperCar,
        Universal,
        Cabriolet,
        Crossover
    }

    internal class Car : Vehicle
    {
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
            CarType = type;
            HasCruiseControl = hasCruiseControl;
            Seats = numberOfSeats;
            Model = model;

            var properties = this.GetType().GetProperties().ToList();
            
            foreach (var prop in properties)
            {
                if(prop.GetValue(this) == null)
                {
                    throw new InitializationException();
                }
            }
        }
        public override string ToString()
        {
            return $"Unique Car properties: Model - {Model}, Type - {CarType}, Has cruise control - {HasCruiseControl.ToString()}, Seats - {Seats}\n" + base.ToString();
        }
    }
}
