﻿using Newtonsoft.Json;

namespace WebApi.Response.DTOs
{
    public class TokenDto
    {
        [JsonProperty("Token")]
        public string Token { get; set; }

        //[JsonProperty("RefreshToken")]
        //public string RefreshToken { get; set; }
    }  
}
