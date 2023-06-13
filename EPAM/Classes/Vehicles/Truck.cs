using EPAM.Classes.VehicleParts;

namespace EPAM.Classes.Vehicles
{
    internal class Truck : Vehicle
    {
        //Requested unique properties
        internal string Cargo { get; private set; }
        internal double TrunkVolume { get; private set; }

        internal Truck(Chassis chassis, Engine engine, Transmission transmission, string cargo, double trunkVolume) : base(chassis, engine, transmission)
        {
            if (string.IsNullOrEmpty(cargo) || trunkVolume < 0)
            {
                throw new ArgumentException();
            }
            Cargo = cargo;
            TrunkVolume = trunkVolume;
        }

        public override string ToString()
        {
            return $"Unique Truck properties: Cargo - {Cargo}, Trunk volume - {TrunkVolume}\n" + base.ToString();
        }
    }
}
