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
        //Unique properties
        public int MaximumPeopleCapacity { get; private set; }
        public int Number { get; private set; }
        public double Fare { get; private set; }
        public BusType BusType { get; private set; }


        public Bus(Chassis chassis, Engine engine, Transmission transmission) : base(chassis, engine, transmission)
        {
        }

        public void SetBusProperties(int peopleCapacity, int number, double fare, BusType busType)
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
