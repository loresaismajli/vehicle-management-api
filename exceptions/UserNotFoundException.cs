namespace exceptions
{
    public class UserNotFoundException : Exception
    {
        public UserNotFoundException() :base("ERRORS.USER_NOT_FOUND") { }

        public UserNotFoundException(string message) : base(message) { }

        public UserNotFoundException(string message, Exception innerException) : base(message, innerException) { }
    }
}
