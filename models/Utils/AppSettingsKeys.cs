namespace models.Utils
{
    public class AppSettingsKeys
    {
        public const string JWT_SECRET_KEY = "Authorization:secretKey";
        public const string JWT_ISSUER_KEY = "Authorization:issuer";
        public const string JWT_AUDIENCE_KEY = "Authorization:audience";
        public const string DB_CONNECTION_STRING = "ConnectionStrings:mssql";
    }
}
