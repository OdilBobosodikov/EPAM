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


        internal Bus(Chassis chassis, Engine engine, Transmission transmission, int peopleCapacity, int number, double fare, BusType busType) : base(chassis, engine, transmission)
        {
            MaximumPeopleCapacity = peopleCapacity;
            Number = number;
            Fare = fare;
            BusType = busType;
        }

        public override string ToString()
        {
            return $"Unique Bus properties: People capacity - {MaximumPeopleCapacity}, Number - {Number}, Fare - {Fare}, Bus type - {BusType}\n" + base.ToString();
        }
    }
}
