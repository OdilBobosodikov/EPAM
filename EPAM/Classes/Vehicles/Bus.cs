using EPAM.Classes.VehicleParts;

namespace EPAM.Classes.Vehicles
{
    internal class Bus : Vehicle
    {
        //Requested unique properties
        internal int MaximumPeopleCapacity { get; private set; }
        internal int Number { get; private set; }
        internal double Fare { get; private set; }
        internal BusTypes BusType { get; private set; }


        internal Bus(Chassis chassis, Engine engine, Transmission transmission, int peopleCapacity, int number, double fare, BusTypes busType) : base(chassis, engine, transmission)
        {
            if(HasNegativeNumber(peopleCapacity, number, fare))
            {
                throw new ArgumentException();
            }
            MaximumPeopleCapacity = peopleCapacity;
            Number = number;
            Fare = fare;
            BusType = busType;
        }

        private bool HasNegativeNumber(params double[] values)
        {
            foreach (double num in values)
            {
                if(num < 0)
                {
                    return true;
                }
            }
            return false;
        }

        public override string ToString()
        {
            return $"Unique Bus properties: People capacity - {MaximumPeopleCapacity}, Number - {Number}, Fare - {Fare}, Bus type - {BusType}\n" + base.ToString();
        }
    }
}
