namespace SodaCompany.Common.Options
{
    public class JWTOptions
    {
        public const string JWT = "JWT";
        public string Key { get; set; }
        public string Issuer { get; set; }
    }
}
