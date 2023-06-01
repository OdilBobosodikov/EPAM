using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPAM.Classes
{
    internal class CarSuply
    {
        internal string? ManufacturingCompany { get; set; }
        internal string? CarModel { get; set; }
        internal int Quantity { get; set; }
        internal double PricePerItem { get; set; }

        public CarSuply(string company, string carModel, int quantity, double price)
        {
            ManufacturingCompany = company;
            CarModel = carModel;
            Quantity = quantity;
            PricePerItem = price;
        }
    }
}
