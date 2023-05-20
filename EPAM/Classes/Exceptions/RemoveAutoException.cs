using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPAM.Classes.Exceptions
{
    internal class RemoveAutoException : Exception
    {
        /// <summary>
        /// Exception when it is impossible to delete element from Vehicle list
        /// </summary>
        public RemoveAutoException() : base("Provided object is not stored in the Vehicle list")
        {}
    }
}
