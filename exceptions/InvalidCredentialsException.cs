namespace exceptions
{
    public class InvalidCredentialsException : Exception
    {
        public InvalidCredentialsException() : base("ERRORS.INVALID_CREDENTIALS") { }

        public InvalidCredentialsException(string message) : base(message) { }

        public InvalidCredentialsException(string message, Exception innerException) : base(message, innerException) { }
    }
}
