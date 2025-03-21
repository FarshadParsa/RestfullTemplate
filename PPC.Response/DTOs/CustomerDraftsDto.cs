using Newtonsoft.Json;
using System.Collections.Generic;
namespace PPC.Response.DTOs
{
    public class CustomerDraftsDTO
    {

        #region Base properties
        [JsonProperty("CustomerDraftID")]
        public int CustomerDraftID { get; set; }

        [JsonProperty("DraftNo")]
        public string DraftNo { get; set; }

        [JsonProperty("FinancialDraftNo")]
        public string FinancialDraftNo { get; set; }

        [JsonProperty("CustomerID")]
        public int? CustomerID { get; set; }

        [JsonProperty("BarnameNo")]
        public string BarnameNo { get; set; }

        [JsonProperty("DriverName")]
        public string DriverName { get; set; }

        [JsonProperty("VehicleType")]
        public string VehicleType { get; set; }

        [JsonProperty("TransportOrg")]
        public string TransportOrg { get; set; }

        [JsonProperty("VehicleNo")]
        public string VehicleNo { get; set; }

        [JsonProperty("UserID")]
        public int? UserID { get; set; }

        [JsonProperty("StationID")]
        public int? StationID { get; set; }

        [JsonProperty("Describe")]
        public string Describe { get; set; }

        [JsonProperty("DraftDate")]
        public string DraftDate { get; set; }

        [JsonProperty("DraftTime")]
        public string DraftTime { get; set; }

        [JsonProperty("DriverTelNo")]
        public string DriverTelNo { get; set; }

        [JsonProperty("IsConfirmed")]
        public bool? IsConfirmed { get; set; }

        [JsonProperty("InsUserID")]
        public int InsUserID { get; set; }

        [JsonProperty("InsDate")]
        public string InsDate { get; set; }

        [JsonProperty("InsTime")]
        public string InsTime { get; set; }

        [JsonProperty("EditUserID")]
        public int EditUserID { get; set; }

        [JsonProperty("EditDate")]
        public string EditDate { get; set; }

        [JsonProperty("EditTime")]
        public string EditTime { get; set; }

        #endregion Base properties

        [JsonProperty("User_InsUser")]
        public UsersDTO User_InsUser { get; set; }

        [JsonProperty("User_EditUser")]
        public UsersDTO User_EditUser { get; set; }


        [JsonProperty("Customer")]
        public CustomersDTO Customer { get; set; }

        [JsonProperty("Station")]
        public StationsDTO Station { get; set; }

        [JsonProperty("User")]
        public UsersDTO User { get; set; }

        [JsonProperty("CustomerDraftPaletList")]
        public List<CustomerDraftPaletsDTO> CustomerDraftPaletList { get; set; }


    }
}