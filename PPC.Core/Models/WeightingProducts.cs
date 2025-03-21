using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using PPC.Core.Models.Entity;
using System.ComponentModel;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace PPC.Core.Models
{
    [Table("WeightingProducts")]
    public class WeightingProducts : IEntity
    {
        #region Base properties
        [Key]
        [Column("WeightingProductID")]
        [JsonProperty("WeightingProductID")]
        [Required(ErrorMessageResourceName = "pub_RequiredField", ErrorMessageResourceType = typeof(Resources.Resources))]
        public int WeightingProductID { get; set; }



        [Column("ProductionPlanPatilID")]
        [JsonProperty("ProductionPlanPatilID")]
        //[Required(ErrorMessageResourceName = "pub_RequiredField", ErrorMessageResourceType = typeof(Resources.Resources))]
        public int? ProductionPlanPatilID { get; set; }

        [Column("InvProductID")]
        [JsonProperty("InvProductID")]
        //[Required(ErrorMessageResourceName = "pub_RequiredField", ErrorMessageResourceType = typeof(Resources.Resources))]
        public int? InvProductID { get; set; }

        [Column("StartDate")]
        [JsonProperty("StartDate")]
        [Required(ErrorMessageResourceName = "pub_RequiredField", ErrorMessageResourceType = typeof(Resources.Resources))]
        [MaxLength(10)]

        public string StartDate { get; set; }

        [Column("StartTime")]
        [JsonProperty("StartTime")]
        [Required(ErrorMessageResourceName = "pub_RequiredField", ErrorMessageResourceType = typeof(Resources.Resources))]
        [MaxLength(5)]

        public string StartTime { get; set; }

        [Column("EndDate")]
        [JsonProperty("EndDate")]
        [Required(ErrorMessageResourceName = "pub_RequiredField", ErrorMessageResourceType = typeof(Resources.Resources))]
        [MaxLength(10)]

        public string EndDate { get; set; }

        [Column("EndTime")]
        [JsonProperty("EndTime")]
        [Required(ErrorMessageResourceName = "pub_RequiredField", ErrorMessageResourceType = typeof(Resources.Resources))]
        [MaxLength(5)]

        public string EndTime { get; set; }

        [Column("EntryWeight")]
        [JsonProperty("EntryWeight")]
        [Required(ErrorMessageResourceName = "pub_RequiredField", ErrorMessageResourceType = typeof(Resources.Resources))]


        public decimal EntryWeight { get; set; }

        [Column("PackagedWeight")]
        [JsonProperty("PackagedWeight")]
        [Required(ErrorMessageResourceName = "pub_RequiredField", ErrorMessageResourceType = typeof(Resources.Resources))]


        public decimal PackagedWeight { get; set; }

        [Column("Waste")]
        [JsonProperty("Waste")]
        [Required(ErrorMessageResourceName = "pub_RequiredField", ErrorMessageResourceType = typeof(Resources.Resources))]


        public decimal Waste { get; set; }

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

        [Column("RowVer")]
        [JsonProperty("RowVer")]
        [Required(ErrorMessageResourceName = "pub_RequiredField", ErrorMessageResourceType = typeof(Resources.Resources))]

        [Timestamp]
        public byte[] RowVer { get; set; }
        #endregion Base properties


        [JsonProperty("ProductionPlanPatil")]
        [ForeignKey(nameof(ProductionPlanPatilID))]
        public ProductionPlanPatils ProductionPlanPatil { get; set; }

        [JsonProperty("InvProduct")]
        [ForeignKey(nameof(InvProductID))]
        public InvProducts InvProduct { get; set; }

        [JsonProperty("User_InsUser")]
        [ForeignKey(nameof(InsUserID))]
        public Users User_InsUser { get; set; }

        [JsonProperty("User_EditUser")]
        [ForeignKey(nameof(EditUserID))]
        public Users User_EditUser { get; set; }

        [JsonProperty("WeightingProductDetailList")]
        public List<WeightingProductDetail> WeightingProductDetailList { get; set; }




    }
}