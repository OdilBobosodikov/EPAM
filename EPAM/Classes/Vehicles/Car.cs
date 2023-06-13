using EPAM.Classes.VehicleParts;

namespace EPAM.Classes.Vehicles
{
    internal class Car : Vehicle
    {
        private readonly byte minSeats = 2;
        private readonly byte maxSeats = 8;
        
        internal bool HasCruiseControl { get; private set; } = false;
        internal CarTypes Type { get; private set; }
        internal byte Seats { get; private set; }

        internal Car(Chassis chassis, Engine engine, Transmission transmission) : base(chassis, engine, transmission)
        {}

        internal void SetCarProperties(CarTypes type, bool hasCruiseControl, byte numberOfSeats)
        {

            if (!IsValid(numberOfSeats))
            {
                throw new ArgumentException();
            }
            Type = type;
            HasCruiseControl = hasCruiseControl;
            Seats = numberOfSeats;
            SetUniqueProperties = true;
        }

        private bool IsValid(byte seats)
        {
            return seats < maxSeats || seats > minSeats;
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
