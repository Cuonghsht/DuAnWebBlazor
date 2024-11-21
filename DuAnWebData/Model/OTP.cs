using Newtonsoft.Json;

namespace DuAnWebAPI.Services.OtpEmail
{
    public class OTP
    {
            [JsonProperty("message")]
            public string mess { get; set; }
            [JsonProperty("code")]
            public string codes { get; set; }
        
    }
}
