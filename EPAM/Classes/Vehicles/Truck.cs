using EPAM.Classes.Vehicle_Parts;

namespace EPAM.Classes.Vehicles
{
    internal class Truck : Vehicle
    {
        //Requested unique properties
        internal string Cargo { get; private set; }
        internal double TrunkVolume { get; private set; }

        internal Truck(Chassis chassis, Engine engine, Transmission transmission, string cargo, double trunkVolume) : base(chassis, engine, transmission)
        {
            Cargo = cargo;
            TrunkVolume = trunkVolume;
        }

        public override string ToString()
        {
            return $"Unique Truck properties: Cargo - {Cargo}, Trunk volume - {TrunkVolume}\n" + base.ToString();
        }
    }
}
