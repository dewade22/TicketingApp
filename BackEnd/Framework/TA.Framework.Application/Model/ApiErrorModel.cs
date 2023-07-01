using Newtonsoft.Json;

namespace TA.Framework.Application.Model
{
#nullable disable
    public class ApiErrorModel
    {
        [JsonProperty("errorMessages")]
        public string[] ErrorMessages { get; set; }
    }
}
