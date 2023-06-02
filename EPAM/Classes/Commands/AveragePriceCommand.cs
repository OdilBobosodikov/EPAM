using EPAM.Interfaces;

namespace EPAM.Classes.Commands
{
    internal class AveragePriceCommand : IOrder
    {
        void IOrder.Execute(CarCollection carCollection)
        {
            Console.WriteLine($"Average car price is {carCollection.Cars.Average(x=>x.PricePerItem)}");
        }
    }
}
