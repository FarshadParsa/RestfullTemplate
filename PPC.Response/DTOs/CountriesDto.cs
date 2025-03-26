using Newtonsoft.Json;
namespace WebApi.Response.DTOs
{
    public class CountriesDTO
    {

        #region Base properties and methods(generated by  CodeGenerator)
        [JsonProperty("CountryID")]
        public short CountryID { get; set; }

        [JsonProperty("CountryName")]
        public string CountryName { get; set; }

        [JsonProperty("CountryLatinName")]
        public string CountryLatinName { get; set; }

        [JsonProperty("IsActive")]
        public bool IsActive { get; set; }
        #endregion Base properties and methods(generated by  CodeGenerator)

    }
}