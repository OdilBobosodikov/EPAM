namespace EPAM.Classes.Exceptions 
{
    internal class InitializationException : Exception
    {
        /// <summary>
        /// Exception when it is impossible to instantiate a car object
        /// </summary>
        /// <param name="car"></param>
        public InitializationException() : base($"Car model can't be Initializated")
        {}
    }
}
