#nullable disable

namespace TA.Framework.Authorization
{
    public class LocalJwtConfig
    {
        public const string jwt = "JWT";

        public string Key { get; set; }

        public string Issuer { get; set; }

        public string Audience { get; set; }
    }
}
