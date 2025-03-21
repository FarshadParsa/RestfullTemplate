using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace PPC.Base
{
    public class AuthRequest
    {
        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }
    }
    public class Token
    {
        //[JsonPropertyName("refreshToken")]
        [Required]
        public string RefreshToken { get; set; }
    }
}