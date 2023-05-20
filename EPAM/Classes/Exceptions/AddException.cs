using EPAM.Classes.Vehicles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPAM.Classes.Exceptions
{
    internal class AddException : Exception
    {
        /// <summary>
        /// Exception when it is impossible to add a car instance
        /// </summary>
        public AddException(Car car) : base("Some of car properties are null.\nCar can't be added to XML doc")
        {
            
        }
    }
}
