using EPAM.Interfaces;

namespace EPAM.Classes
{
    internal class CountTypesCommand : IOrder
    {
        void IOrder.Execute(List<CarSuply> cars)
        {
            var test = cars.Select(x => new { x.ManufacturingCompany }).Distinct();
            Console.WriteLine($"There are {test.ToList().Count} companies that manufacture supplied cars"); 
        }
    }
}
