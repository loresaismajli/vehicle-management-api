namespace exceptions
{
    public class DatabaseException : Exception
    {
        public DatabaseException() : base("ERRORS.DATABASE") { }

        public DatabaseException(Exception ex) : base("ERRORS.DATABASE", ex) { }

        public DatabaseException(string message) : base(message) { }

        public DatabaseException(string message, Exception innerException) : base(message, innerException) { }
    }
}
