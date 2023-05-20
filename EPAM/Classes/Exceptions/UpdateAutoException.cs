namespace EPAM.Classes.Exceptions
{
    internal class UpdateAutoException : Exception
    {
        /// <summary>
        /// Exception when it is impossible to Update instance of the Car in Vehicle list
        /// </summary>
        public UpdateAutoException() : base("provided Car object is inappropriate")
        {}
    }
}
