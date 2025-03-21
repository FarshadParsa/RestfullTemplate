using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using PPC.Core.Models.Entity;
using System.ComponentModel;
using Newtonsoft.Json;

namespace PPC.Core.Models
{
    [Table("CustomerDraft")]
    public class CustomerDrafts : IEntity
    {
        #region Base properties
        [Key]
        [Column("CustomerDraftID")]
        [JsonProperty("CustomerDraftID")]
        [Required(ErrorMessageResourceName = "pub_RequiredField", ErrorMessageResourceType = typeof(Resources.Resources))]

        public int CustomerDraftID { get; set; }

        [Column("DraftNo")]
        [JsonProperty("DraftNo")]
        [Required(ErrorMessageResourceName = "pub_RequiredField", ErrorMessageResourceType = typeof(Resources.Resources))]
        [MaxLength(20)]
        public string DraftNo { get; set; }

        [Column("FinancialDraftNo")]
        [JsonProperty("FinancialDraftNo")]
        [MaxLength(20)]
        public string FinancialDraftNo { get; set; }

        [Column("CustomerID")]
        [JsonProperty("CustomerID")]
        [Required(ErrorMessageResourceName = "pub_RequiredField", ErrorMessageResourceType = typeof(Resources.Resources))]


        public int CustomerID { get; set; }

        [Column("BarnameNo")]
        [JsonProperty("BarnameNo")]
        [Required(ErrorMessageResourceName = "pub_RequiredField", ErrorMessageResourceType = typeof(Resources.Resources))]
        [MaxLength(50)]

        public string BarnameNo { get; set; }

        [Column("DriverName")]
        [JsonProperty("DriverName")]

        [MaxLength(100)]

        public string DriverName { get; set; }

        [Column("VehicleType")]
        [JsonProperty("VehicleType")]

        [MaxLength(50)]

        public string VehicleType { get; set; }

        [Column("TransportOrg")]
        [JsonProperty("TransportOrg")]

        [MaxLength(50)]
        public string TransportOrg { get; set; }

        [Column("VehicleNo")]
        [JsonProperty("VehicleNo")]
        [MaxLength(50)]
        public string VehicleNo { get; set; }

        [Column("UserID")]
        [JsonProperty("UserID")]
        [Required(ErrorMessageResourceName = "pub_RequiredField", ErrorMessageResourceType = typeof(Resources.Resources))]
        public int UserID { get; set; }

        [Column("StationID")]
        [JsonProperty("StationID")]
        [Required(ErrorMessageResourceName = "pub_RequiredField", ErrorMessageResourceType = typeof(Resources.Resources))]


        public int StationID { get; set; }

        [Column("Describe")]
        [JsonProperty("Describe")]
        [MaxLength(200)]
        public string Describe { get; set; }


        [Column("DraftDate")]
        [JsonProperty("DraftDate")]
        [Required(ErrorMessageResourceName = "pub_RequiredField", ErrorMessageResourceType = typeof(Resources.Resources))]
        [MaxLength(10)]

        public string DraftDate { get; set; }

        [Column("DraftTime")]
        [JsonProperty("DraftTime")]
        [Required(ErrorMessageResourceName = "pub_RequiredField", ErrorMessageResourceType = typeof(Resources.Resources))]
        [MaxLength(5)]

        public string DraftTime { get; set; }

        [Column("DriverTelNo")]
        [JsonProperty("DriverTelNo")]

        [MaxLength(20)]

        public string DriverTelNo { get; set; }

        [Column("IsConfirmed")]
        [JsonProperty("IsConfirmed")]
        public bool? IsConfirmed { get; set; }

        [Column("InsUserID")]
        [JsonProperty("InsUserID")]
        [Required(ErrorMessageResourceName = "pub_RequiredField", ErrorMessageResourceType = typeof(Resources.Resources))]
        public int InsUserID { get; set; }

        [Column("InsDate")]
        [JsonProperty("InsDate")]
        [Required(ErrorMessageResourceName = "pub_RequiredField", ErrorMessageResourceType = typeof(Resources.Resources))]
        [MaxLength(10)]
        public string InsDate { get; set; }

        [Column("InsTime")]
        [JsonProperty("InsTime")]
        [Required(ErrorMessageResourceName = "pub_RequiredField", ErrorMessageResourceType = typeof(Resources.Resources))]
        [MaxLength(5)]
        public string InsTime { get; set; }

        [Column("EditUserID")]
        [JsonProperty("EditUserID")]
        [Required(ErrorMessageResourceName = "pub_RequiredField", ErrorMessageResourceType = typeof(Resources.Resources))]
        public int EditUserID { get; set; }

        [Column("EditDate")]
        [JsonProperty("EditDate")]
        [Required(ErrorMessageResourceName = "pub_RequiredField", ErrorMessageResourceType = typeof(Resources.Resources))]
        [MaxLength(10)]
        public string EditDate { get; set; }

        [Column("EditTime")]
        [JsonProperty("EditTime")]
        [Required(ErrorMessageResourceName = "pub_RequiredField", ErrorMessageResourceType = typeof(Resources.Resources))]
        [MaxLength(5)]
        public string EditTime { get; set; }


        #endregion Base properties

        [JsonProperty("User_InsUser")]
        [ForeignKey(nameof(InsUserID))]
        public Users User_InsUser { get; set; }

        [JsonProperty("User_EditUser")]
        [ForeignKey(nameof(EditUserID))]
        public Users User_EditUser { get; set; }



        [JsonProperty("Customer")]
        [ForeignKey(nameof(CustomerID))]
        public Customers Customer { get; set; }

        [JsonProperty("Station")]
        [ForeignKey(nameof(StationID))]
        public Stations Station { get; set; }

        [JsonProperty("User")]
        [ForeignKey(nameof(UserID))]
        public Users User { get; set; }

        [JsonProperty("CustomerDraftPaletList")]
        public System.Collections.Generic.List<CustomerDraftPalets> CustomerDraftPaletList { get; set; }


    }
}