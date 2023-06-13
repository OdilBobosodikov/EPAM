namespace EPAM.Classes.Exceptions
{
    internal class AddException : Exception
    {
        /// <summary>
        /// Exception when it is impossible to add a car instance
        /// </summary>
        public AddException() : base("Some of car properties are null.\nCar can't be added to XML doc")
        {}
    }
}
