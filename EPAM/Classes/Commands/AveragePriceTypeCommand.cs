using EPAM.Interfaces;


namespace EPAM.Classes.Commands
{
    internal class AveragePriceTypeCommand : IOrder
    {
        void IOrder.Execute(CarCollection carCollection)
        {
            var brandCars = carCollection.Cars.Where(x => x.Brand.ToLower() == carCollection.BrandName.ToLower());
            if (brandCars.Any()) 
            {
                Console.WriteLine($"Average car price for {carCollection.BrandName} is {brandCars.Average(x => x.PricePerItem)}");
            }
            Console.WriteLine("There is no such a brand yet");
        }
    }
}
