using EPAM.Classes.VehicleParts;

namespace EPAM.Classes.Vehicles
{

    internal class Bus : Vehicle
    {

        internal int MaximumPeopleCapacity { get; private set; }
        internal int Number { get; private set; }
        internal double Fare { get; private set; }
        internal BusTypes BusType { get; private set; }


        internal Bus(Chassis chassis, Engine engine, Transmission transmission) : base(chassis, engine, transmission)
        {}

        internal void SetBusProperties(int peopleCapacity,
                int number,
                double fare,
                BusTypes busType)
        {
            if (HasnegativeValue(peopleCapacity, number, fare))
            {
                throw new ArgumentException();
            }
            MaximumPeopleCapacity = peopleCapacity;
            Number = number;
            Fare = fare;
            BusType = busType;
            SetUniqueProperties = true;
        }

        private bool HasnegativeValue(params double[] val)
        {
            foreach (double i in val)
            {
                if (i < 0)
                {
                    return true;
                }
            }
            return false;
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
