namespace EPAM.Classes.Exceptions
{
    internal class GetAutoByParameterException : Exception
    {
        /// <summary>
        /// Exception when it is impossible to find the instance of Car class by the given parameter.
        /// </summary>
        /// <param name="prop"></param>
        /// <param name="value"></param>
        public GetAutoByParameterException(string prop, string value) :
            base($"There is no car that has {prop} with value {value}")
        { }

        public GetAutoByParameterException() :
        base("There is no car that has this property")
        { }
    }
}
