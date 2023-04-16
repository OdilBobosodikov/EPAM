using EPAM.Classes.Vehicle_Parts;

namespace EPAM.Classes.Vehicles
{
    internal class Truck : Vehicle
    {
        //Unique properties
        public string Cargo { get; private set; }
        public double TrunkVolume { get; private set; }

        public Truck(Chassis chassis, Engine engine, Transmission transmission) : base(chassis, engine, transmission)
        {
        }

        public void SetTruckProperties(string cargo, double trunkVolume)
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
