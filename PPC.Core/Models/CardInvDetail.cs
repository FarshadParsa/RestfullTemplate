using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using PPC.Core.Models.Entity;
using System.ComponentModel;
using Newtonsoft.Json;
using Microsoft.EntityFrameworkCore;

namespace PPC.Core.Models
{
    [Table("CardInvDetail")]
    public class CardInvDetails : IEntity
    {
        #region Base properties
        [Key]
        //[Key, Column("InvTypeID",Order = 0)]
        [Column("ID")]
        [JsonProperty("ID")]
        [Required(ErrorMessageResourceName = "pub_RequiredField", ErrorMessageResourceType = typeof(Resources.Resources))]
        public long ID { get; set; }

        //[Key]
        //[Key, Column("InvTypeID",Order = 0)]
        [Column("InvTypeID")]
        [JsonProperty("InvTypeID")]
        [Required(ErrorMessageResourceName = "pub_RequiredField", ErrorMessageResourceType = typeof(Resources.Resources))]
        public char InvTypeID { get; set; }

        //[Key]
        //[Key, Column("Year", Order = 1)]
        [Column("Year")]
        [JsonProperty("Year")]
        [Required(ErrorMessageResourceName = "pub_RequiredField", ErrorMessageResourceType = typeof(Resources.Resources))]
        public short Year { get; set; }

        //[Key]
        //[Key, Column("RawMaterialID")]
        [Column("RawMaterialID")]
        [JsonProperty("RawMaterialID")]
        [Required(ErrorMessageResourceName = "pub_RequiredField", ErrorMessageResourceType = typeof(Resources.Resources))]
        public int RawMaterialID { get; set; }

        //[Key]
        //[Key, Column("EntryDate")]
        [Column("EntryDate")]
        [JsonProperty("EntryDate")]
        [Required(ErrorMessageResourceName = "pub_RequiredField", ErrorMessageResourceType = typeof(Resources.Resources))]
        [MaxLength(10)]
        public string EntryDate { get; set; }

        //[Key]
        //[Key, Column("EntryTime")]
        [Column("EntryTime")]
        [JsonProperty("EntryTime")]
        [Required(ErrorMessageResourceName = "pub_RequiredField", ErrorMessageResourceType = typeof(Resources.Resources))]
        [MaxLength(5)]
        public string EntryTime { get; set; }

        [Column("Amount")]
        [JsonProperty("Amount")]
        [Required(ErrorMessageResourceName = "pub_RequiredField", ErrorMessageResourceType = typeof(Resources.Resources))]
        public decimal Amount { get; set; }

        [Column("CardTypeVal")]
        [JsonProperty("CardTypeVal")]
        [Required(ErrorMessageResourceName = "pub_RequiredField", ErrorMessageResourceType = typeof(Resources.Resources))]
        [MaxLength(1)]
        public char CardTypeVal { get; set; }

        [Column("IsEntry")]
        [JsonProperty("IsEntry")]
        [Required(ErrorMessageResourceName = "pub_RequiredField", ErrorMessageResourceType = typeof(Resources.Resources))]
        public bool IsEntry { get; set; }

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

        [Column("InsUserID")]
        [JsonProperty("InsUserID")]
        [Required(ErrorMessageResourceName = "pub_RequiredField", ErrorMessageResourceType = typeof(Resources.Resources))]
        public int InsUserID { get; set; }

        [Column("InvRawMaterialID")]
        [JsonProperty("InvRawMaterialID")]
        public int? InvRawMaterialID { get; set; }

        [Column("RawMaterialsDeliveredToProductionDetailID")]
        [JsonProperty("RawMaterialsDeliveredToProductionDetailID")]
        public int? RawMaterialsDeliveredToProductionDetailID { get; set; }

        [Column("InvProductionRawMaterialID")]
        [JsonProperty("InvProductionRawMaterialID")]
        public int? InvProductionRawMaterialID { get; set; }

        [Column("DataDosingDetailID")]
        [JsonProperty("DataDosingDetailID")]
        public int? DataDosingDetailID { get; set; }

        [Column("GroupRawId")]
        [JsonProperty("GroupRawId")]
        [Description("بمنظور شمارنده جهت ورود رکورد های یک گروه از داده")]
        public short? GroupRawId { get; set; }

        #endregion Base properties

    }
}