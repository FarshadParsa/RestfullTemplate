using Newtonsoft.Json;
using System.Collections.Generic;
using System;

namespace PPC.Response.DTOs
{
    public class UsersDTO
    {

        [JsonProperty("UserID")]
        public int UserID { get; set; }

        [JsonProperty("FullName")]
        public string FullName { get; set; } = string.Empty;

        [JsonProperty("Username")]
        public string Username { get; set; }

        [JsonProperty("Password")]
        public string Password { get; set; }

        [JsonProperty("Description")]
        public string Description { get; set; } = string.Empty;

        [JsonProperty("MessageSignature")]
        public string MessageSignature { get; set; } = string.Empty;

        [JsonProperty("CanLogin")]
        public bool CanLogin { get; set; } = false;

        [JsonProperty("IsActive")]
        public bool IsActive { get; set; } = true;

        [JsonProperty("Last")]
        public string Last { get; set; } = string.Empty;

        [JsonProperty("StationID")]
        public Nullable<int> StationID { get; set; }

        [JsonProperty("AuthenticationType")]
        public byte AuthenticationType { get; set; }

        [JsonProperty("DomainID")]
        public Nullable<byte> DomainID { get; set; }

        [JsonProperty("LoginType")]
        public byte LoginType { get; set; }

        [JsonProperty("IsEntered")]
        public bool IsEntered { get; set; } = false;

        [JsonProperty("IsAdmin")]
        public bool IsAdmin { get; set; } = false;

        [JsonProperty("IsSysAdmin")]
        public bool IsSysAdmin { get; set; } = false;

        [JsonProperty("IsManager")]
        public bool IsManager { get; set; } = false;

        [JsonProperty("IsSupervisor")]
        public bool IsSupervisor { get; set; } = false;

        [JsonProperty("IsExpert")]
        public bool IsExpert { get; set; } = false;

        [JsonProperty("IsOperator")]
        public bool IsOperator { get; set; } = false;

        [JsonProperty("IsSpecialUser")]
        public bool IsSpecialUser { get; set; } = false;

        [JsonProperty("GetUrgentRequest")]
        public bool GetUrgentRequest { get; set; } = false;

        [JsonProperty("InsDate")]
        public string InsDate { get; set; }

        [JsonProperty("InsTime")]
        public string InsTime { get; set; }

        [JsonProperty("InsUserID")]
        public Int32 InsUserID { get; set; }

        [JsonProperty("EditDate")]
        public string EditDate { get; set; }

        [JsonProperty("EditTime")]
        public string EditTime { get; set; }

        [JsonProperty("EditUserID")]
        public Int32 EditUserID { get; set; }


        public UsersDTO()
        {

        }
        //public Stations Stations { get; set; }
        public virtual ICollection<StationsDTO> Stations { get; set; }

    }
}
