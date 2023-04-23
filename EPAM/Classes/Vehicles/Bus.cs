using EPAM.Classes.Vehicle_Parts;

namespace EPAM.Classes.Vehicles
{
    internal enum BusType
    {
        School,
        Mini,
        Electric,
        Transit
    }
    internal class Bus : Vehicle
    {
        //Requested unique properties
        internal int MaximumPeopleCapacity { get; private set; }
        internal int Number { get; private set; }
        internal double Fare { get; private set; }
        internal BusType BusType { get; private set; }


        internal Bus(Chassis chassis, Engine engine, Transmission transmission) : base(chassis, engine, transmission)
        {}

        internal void SetBusProperties(int peopleCapacity,
                int number,
                double fare,
                BusType busType)
        {
            MaximumPeopleCapacity = peopleCapacity;
            Number = number;
            Fare = fare;
            BusType = busType;
            SetUniqueProperties = true;
        }

        public override string ToString()
        {
            if (!SetUniqueProperties)
            {
                return $"Unique Bus properties have not set yet\n" + base.ToString();
            }
            return $"Unique Bus properties: People capacity - {MaximumPeopleCapacity}, Number - {Number}, Fare - {Fare}, Bus type - {BusType}\n" + base.ToString();
        }
    }
}
