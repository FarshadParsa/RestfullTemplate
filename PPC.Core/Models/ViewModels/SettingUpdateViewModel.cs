using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PPC.Core.Models;

namespace PPC.Core.Models
{
    public class SettingUpdateViewModel
    {
        [JsonProperty("SettingID")]
        public int SettingID { get; set; }

        [JsonProperty("LastVersion")]
        public string LastVersion { get; set; }

        [JsonProperty("LastVersionWarninType")]
        public byte LastVersionWarninType { get; set; }

        [JsonProperty("UserID")]
        public Nullable<int> UserID { get; set; }

        [JsonProperty("StationID")]
        public Nullable<int> StationID { get; set; }

        [JsonProperty("IsActive")]
        public bool IsActive { get; set; }


        [JsonProperty("UpdateID")]
        public int UpdateID { get; set; }

        [JsonProperty("Version")]
        public string Version { get; set; }

        [JsonProperty("ServerMap")]
        public string ServerMap { get; set; }

        [JsonProperty("FilesName")]
        public string FilesName { get; set; }

        [JsonProperty("Date")]
        public string Date { get; set; }

        [JsonProperty("Describe")]
        public string Describe { get; set; }


        [JsonProperty("User")]
        [ForeignKey(nameof(UserID))]
        public Users User { get; set; }

        [JsonProperty("Station")]
        [ForeignKey(nameof(StationID))]
        public Stations Station { get; set; }

        [JsonProperty("Users")]
        public List<SettingUserViewModel> Users { get; set; }

        [JsonProperty("Stations")]
        public List<SettingStationViewModel> Stations { get; set; }

    }

    public class SettingUserViewModel
    {
        //[JsonProperty("SettingID")]
        //public int SettingID { get; set; }

        [JsonProperty("LastVersion")]
        public string LastVersion { get; set; }

        [JsonProperty("UserID")]
        public int UserID { get; set; }

        [JsonProperty("FullName")]
        public string FullName { get; set; }

        [JsonProperty("LastVersionWarninType")]
        public byte LastVersionWarninType { get; set; }

        [JsonProperty("IsActive")]
        public bool IsActive { get; set; }


    }

    public class SettingStationViewModel
    {
        //[JsonProperty("SettingID")]
        //public int SettingID { get; set; }

        [JsonProperty("StationID")]
        public int StationID { get; set; }

        [JsonProperty("StationName")]
        public string StationName { get; set; }

        [JsonProperty("LastVersionWarninType")]
        public byte LastVersionWarninType { get; set; }

        [JsonProperty("IsActive")]
        public bool IsActive { get; set; }

    }

}




