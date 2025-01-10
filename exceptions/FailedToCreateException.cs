namespace exceptions
{
    public class FailedToCreateException : Exception
    {
        public FailedToCreateException() : base("ERRORS.FAILED_TO_CREATE") { }

        public FailedToCreateException(string message) : base(message) { }

        public FailedToCreateException(string message, Exception innerException) : base(message, innerException) { }
    }
}
