using EPAM.Classes;
using EPAM.Classes.Vehicle_Parts;
using EPAM.Classes.Vehicles;


namespace EPAM
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {

                List<Vehicle> vehicles = new List<Vehicle>()
            {
                new Car(new Chassis(3, 70, 1500),
                    new Engine(200, 4.2, EngineTypes.MHEV, 64315),
                    new Transmission(TransmissionTypes.Manual, "Pro Shift", 8),
                    CarTypes.Universal, false, 6, "Chevrolet"),
                new Car(new Chassis(4, 90, 1500),
                    new Engine(200, 2.55, EngineTypes.MHEV, 66315),
                    new Transmission(TransmissionTypes.Manual, "Pro Shift", 6),
                    CarTypes.Universal, true, 5, "Mustang"),
                new Scooter(new Chassis(3, 10, 500),
                    new Engine(80, 1.49, EngineTypes.ESS, 54315),
                    new Transmission(TransmissionTypes.Automatic, "Pro Shift"),
                    ScooterFuel.CNG, 86),
                new Scooter(new Chassis(4, 8, 600),
                    new Engine(65, 1.59, EngineTypes.ESS, 223145),
                    new Transmission(TransmissionTypes.Automatic, "Emco Gears"),
                    ScooterFuel.CNG, 86),
                new Truck(new Chassis(18, 682.2, 12000),
                    new Engine(350, 12, EngineTypes.DSL, 14441),
                    new Transmission(TransmissionTypes.Automatic, "Green Rubber-Kennedy AG, LP", 12),
                    "Wheat", 5000),
            };

                XMLDoc doc = new XMLDoc(vehicles);
                Car auto = new Car(new Chassis(4, 90, 1500),
                    new Engine(200, 2.55, EngineTypes.MHEV, 66315),
                    new Transmission(TransmissionTypes.Manual, "Pro Shift", 6),
                    CarTypes.SuperCar, false, 3, "Tesla");

                Console.WriteLine(doc.GetAutoByParameter("Model", "Mustang"));


                doc.UpdateAuto(auto, "Model", "Mustang");
                Console.WriteLine(doc.GetAutoByParameter("Model", "Tesla"));

                doc.RemoveAuto("Model", "Tesla");

                doc.ShowVehicles();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

    }
}