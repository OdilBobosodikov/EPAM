using EPAM.Classes.VehicleParts;
using System.ComponentModel.DataAnnotations;

namespace EPAM.Classes.Vehicles
{
    internal class Car : Vehicle
    {
        private readonly short maxSeats = 8;
        private readonly short minSeats = 2;
                
        internal bool HasCruiseControl { get; private set; } = false;
        internal CarTypes CarType { get; private set; }
        internal byte Seats { get; private set; }

        internal Car(Chassis chassis, Engine engine, Transmission transmission, CarTypes type, bool hasCruiseControl, byte numberOfSeats) : base(chassis, engine, transmission)
        {
            if (numberOfSeats > maxSeats || numberOfSeats < minSeats)
            {
                throw new ArgumentException();
            }
            CarType = type;
            HasCruiseControl = hasCruiseControl;
            Seats = numberOfSeats;
        }

        public override string ToString()
        {
            return $"Unique Car properties: Type - {CarType}, Has cruise control - {HasCruiseControl}, Seats - {Seats}\n" + base.ToString();
        }
    }
}
