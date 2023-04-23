using EPAM.Classes.Vehicle_Parts;

namespace EPAM.Classes.Vehicles
{
    internal class Truck : Vehicle
    {
        //Requested unique properties
        internal string Cargo { get; private set; }
        internal double TrunkVolume { get; private set; }

        internal Truck(Chassis chassis, Engine engine, Transmission transmission) : base(chassis, engine, transmission)
        {}

        internal void SetTruckProperties(string cargo, double trunkVolume)
        {
            Cargo = cargo;
            TrunkVolume = trunkVolume;
            SetUniqueProperties = true;
        }

        public override string ToString()
        {
            if (!SetUniqueProperties)
            {
                return $"Unique Truck properties have not set yet\n" + base.ToString();
            }
            return $"Unique Truck properties: Cargo - {Cargo}, Trunk volume - {TrunkVolume}\n" + base.ToString();
        }
    }
}
