﻿namespace EPAM.Classes.Exceptions
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
