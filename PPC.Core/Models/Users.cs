using Newtonsoft.Json;
using WebApi.Core.Models.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApi.Core.Models
{

    [Table("User")]
    public class Users : IEntity
    {
        [Key]
        [Column("UserID")]
        [JsonProperty("UserID")]
        public int UserID { get; set; }

        [Column("FullName")]
        [JsonProperty("FullName")]
        public string FullName { get; set; } = string.Empty;

        [Column("UserName")]
        [JsonProperty("UserName")]
        [Required]
        [MaxLength(100)]
        //[DisplayName(PPC.Core.Settings.TblAnot_Users_FullName)]
        public string Username { get; set; }

        [Column("Password")]
        [JsonProperty("Password")]
        public string Password { get; set; }

        [Column("Description")]
        [JsonProperty("Description")]
        public string Description { get; set; } = string.Empty;

        [Column("MessageSignature")]
        [JsonProperty("MessageSignature")]
        public string MessageSignature { get; set; } = string.Empty;

        [Column("CanLogin")]
        [JsonProperty("CanLogin")]
        public bool CanLogin { get; set; } = false;

        [Column("IsActive")]
        [JsonProperty("IsActive")]
        public bool IsActive { get; set; } = true;

        [Column("Last")]
        [JsonProperty("Last")]
        public string Last { get; set; } = string.Empty;

        [Column("StationID")]
        [JsonProperty("StationID")]
        public Nullable<int> StationID { get; set; }

        [Column("AuthenticationType")]
        [JsonProperty("AuthenticationType")]
        public byte AuthenticationType { get; set; }

        [Column("DomainID")]
        [JsonProperty("DomainID")]
        public Nullable<byte> DomainID { get; set; }

        [Column("LoginType")]
        [JsonProperty("LoginType")]
        public byte LoginType { get; set; }

        [Column("IsEntered")]
        [JsonProperty("IsEntered")]
        public bool IsEntered { get; set; } = false;

        [Column("IsAdmin")]
        [JsonProperty("IsAdmin")]
        public bool IsAdmin { get; set; } = false;

        [Column("IsSysAdmin")]
        [JsonProperty("IsSysAdmin")]
        public bool IsSysAdmin { get; set; } = false;

        [Column("IsManager")]
        [JsonProperty("IsManager")]
        public bool IsManager { get; set; } = false;

        [Column("IsSupervisor")]
        [JsonProperty("IsSupervisor")]
        public bool IsSupervisor { get; set; } = false;

        [Column("IsExpert")]
        [JsonProperty("IsExpert")]
        public bool IsExpert { get; set; } = false;

        [Column("IsOperator")]
        [JsonProperty("IsOperator")]
        public bool IsOperator { get; set; } = false;

        [Column("IsSpecialUser")]
        [JsonProperty("IsSpecialUser")]
        public bool IsSpecialUser { get; set; } = false;

        [Column("GetUrgentRequest")]
        [JsonProperty("GetUrgentRequest")]
        public bool GetUrgentRequest { get; set; } = false;

        [Column("InsDate")]
        [JsonProperty("InsDate")]
        public string InsDate { get; set; }

        [Column("InsTime")]
        [JsonProperty("InsTime")]
        public string InsTime { get; set; }

        [Column("InsUserID")]
        [JsonProperty("InsUserID")]
        public Int32 InsUserID { get; set; }

        [Column("EditDate")]
        [JsonProperty("EditDate")]
        public string EditDate { get; set; }

        [Column("EditTime")]
        [JsonProperty("EditTime")]
        public string EditTime { get; set; }

        [Column("EditUserID")]
        [JsonProperty("EditUserID")]
        public Int32 EditUserID { get; set; }

        public Users()
        {

        }


        [JsonProperty("User_EditUser")]
        [ForeignKey(nameof(EditUserID))]
        public Users User_EditUser { get; set; }


        #region Foreign Keys


        #endregion


        #region Children



        #endregion





    }
}
