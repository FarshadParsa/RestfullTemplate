using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using PPC.Core.Models.Entity;
using System.ComponentModel;
using Newtonsoft.Json;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace PPC.Core.Models
{
    [Table("ProductionPlanRework")]
    public class ProductionPlanReworks : IEntity
    {
        #region Base properties
        [Key]
        [Column("ProductionPlanReworkID")]
        [JsonProperty("ProductionPlanReworkID")]
        [Required(ErrorMessageResourceName = "pub_RequiredField", ErrorMessageResourceType = typeof(Resources.Resources))]

        public int ProductionPlanReworkID { get; set; }

        [Column("ProductionPlanPatilID")]
        [JsonProperty("ProductionPlanPatilID")]
        [Required(ErrorMessageResourceName = "pub_RequiredField", ErrorMessageResourceType = typeof(Resources.Resources))]


        public int ProductionPlanPatilID { get; set; }

        [Column("LevelNo")]
        [JsonProperty("LevelNo")]
        [Required(ErrorMessageResourceName = "pub_RequiredField", ErrorMessageResourceType = typeof(Resources.Resources))]


        public byte LevelNo { get; set; }

        [Column("ProductID")]
        [JsonProperty("ProductID")]
        [Required(ErrorMessageResourceName = "pub_RequiredField", ErrorMessageResourceType = typeof(Resources.Resources))]


        public int ProductID { get; set; }

        [Column("CorrectiveActionType")]
        [JsonProperty("CorrectiveActionType")]
        [Required(ErrorMessageResourceName = "pub_RequiredField", ErrorMessageResourceType = typeof(Resources.Resources))]


        public byte CorrectiveActionType { get; set; }

        [Column("Describe")]
        [JsonProperty("Describe")]

        [MaxLength(300)]

        public string Describe { get; set; }

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


        [Column("DelUserID")]
        [JsonProperty("DelUserID")]
        public int? DelUserID { get; set; }

        [Column("DelDate")]
        [JsonProperty("DelDate")]
        public string DelDate { get; set; }

        [Column("DelTime")]
        [JsonProperty("DelTime")]
        public string DelTime { get; set; }


        [Column("ProductionPlanLastStatus")]
        [JsonProperty("ProductionPlanLastStatus")]
        [Required(ErrorMessageResourceName = "pub_RequiredField", ErrorMessageResourceType = typeof(Resources.Resources))]
        public byte ProductionPlanLastStatus { get; set; }

        #endregion Base properties

        [JsonProperty("User_InsUser")]
        [ForeignKey(nameof(InsUserID))]
        public Users User_InsUser { get; set; }

        [JsonProperty("User_EditUser")]
        [ForeignKey(nameof(EditUserID))]
        public Users User_EditUser { get; set; }

        [JsonProperty("User_DelUser")]
        [ForeignKey(nameof(DelUserID))]
        public Users User_DelUser { get; set; }


        [JsonProperty("Product")]
        [ForeignKey(nameof(ProductID))]
        public Products Product { get; set; }

        [JsonProperty("ProductionPlanPatil")]
        public ProductionPlanPatils ProductionPlanPatil { get; set; }

        [JsonProperty("ProductionPlanReworkDetailList")]
        [ForeignKey(nameof(ProductionPlanReworkID))]
        public virtual System.Collections.Generic.List<ProductionPlanReworkDetails> ProductionPlanReworkDetailList { get; set; }

    }
}