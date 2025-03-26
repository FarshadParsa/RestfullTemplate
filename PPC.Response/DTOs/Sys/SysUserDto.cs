using Newtonsoft.Json;

namespace WebApi.Response.DTOs
{
    public class SysUserDto
    {
        [JsonProperty("FirstName")]
        public string FirstName { get; set; }
        [JsonProperty("LastName")]
        public string LastName { get; set; }
        [JsonProperty("Username")]
        public string Username { get; set; }

        [JsonProperty("IsActive")]
        public bool IsActive { get; set; }
    }
}
