using EPAM.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPAM.Classes.Commands
{
    internal class CountAllCommand : IOrder
    {
        void IOrder.Execute(CarCollection carCollection)
        {
            Console.WriteLine($"There are {carCollection.Cars.Sum(x=>x.Quantity)}");
        }
    }
}
