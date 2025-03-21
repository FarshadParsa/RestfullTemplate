﻿using Newtonsoft.Json;

namespace PPC.Response.DTOs
{
    public class StationsDTO
    {
        #region Base properties and methods(generated by  CodeGenerator)
        [JsonProperty("StationID")]
        public int StationID { get; set; }

        [JsonProperty("StationName")]
        public string StationName { get; set; }

        [JsonProperty("StationLatinName")]
        public string StationLatinName { get; set; }

        [JsonProperty("StationTypeID")]
        public int StationTypeID { get; set; }

        [JsonProperty("FWWidth")]
        public int? FWWidth { get; set; }

        [JsonProperty("AllowableStopsInDay")]
        public int? AllowableStopsInDay { get; set; }

        [JsonProperty("MinNoOfEmptyBobins")]
        public int? MinNoOfEmptyBobins { get; set; }

        [JsonProperty("SpeedMMin")]
        public int? SpeedMMin { get; set; }

        [JsonProperty("BarcodeSign")]
        public string BarcodeSign { get; set; }

        [JsonProperty("IsActive")]
        public bool IsActive { get; set; }

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
        #endregion Base properties and methods(generated by  CodeGenerator)


        [JsonProperty("StationType")]
        public StationTypesDTO StationType { get; set; }

        [JsonProperty("User_InsUser")]
        public UsersDTO User_InsUser { get; set; }

        [JsonProperty("User_EditUser")]
        public UsersDTO User_EditUser { get; set; }

    }
}
