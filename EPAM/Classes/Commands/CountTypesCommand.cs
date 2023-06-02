using EPAM.Interfaces;

namespace EPAM.Classes.Commands
{
    internal class CountTypesCommand : IOrder
    {
        void IOrder.Execute(CarCollection carCollection)
        {
            Console.WriteLine($"There are {carCollection.Cars.Select(x => new { x.Brand }).Distinct().ToList().Count} companies that manufacture supplied cars");
        }
    }
}
