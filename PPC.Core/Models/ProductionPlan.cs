using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using PPC.Core.Models.Entity;
using System.ComponentModel;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace PPC.Core.Models
{
    [Table("ProductionPlan")]
    public class ProductionPlans : IEntity
    {
        #region Base properties
        [Key]
        [Column("ProductionPlanID")]
        [JsonProperty("ProductionPlanID")]
        [Required(ErrorMessageResourceName = "pub_RequiredField", ErrorMessageResourceType = typeof(Resources.Resources))]
        public int ProductionPlanID { get; set; }

        [Column("OrderDetailID")]
        [JsonProperty("OrderDetailID")]
        [Required(ErrorMessageResourceName = "pub_RequiredField", ErrorMessageResourceType = typeof(Resources.Resources))]
        public int OrderDetailID { get; set; }

        [Column("ProducibleQuantity")]
        [JsonProperty("ProducibleQuantity")]
        [Required(ErrorMessageResourceName = "pub_RequiredField", ErrorMessageResourceType = typeof(Resources.Resources))]
        public int ProducibleQuantity { get; set; }

        [Column("StartDate")]
        [JsonProperty("StartDate")]
        [Required(ErrorMessageResourceName = "pub_RequiredField", ErrorMessageResourceType = typeof(Resources.Resources))]
        [MaxLength(10)]
        public string StartDate { get; set; }

        [Column("EndDate")]
        [JsonProperty("EndDate")]
        [Required(ErrorMessageResourceName = "pub_RequiredField", ErrorMessageResourceType = typeof(Resources.Resources))]
        [MaxLength(10)]
        public string EndDate { get; set; }

        [Column("BatchNo")]
        [JsonProperty("BatchNo")]
        [Required(ErrorMessageResourceName = "pub_RequiredField", ErrorMessageResourceType = typeof(Resources.Resources))]
        [MaxLength(14)]
        public string BatchNo { get; set; }

        [Column("ProductionProcessCirculation")]
        [JsonProperty("ProductionProcessCirculation")]
        [Required(ErrorMessageResourceName = "pub_RequiredField", ErrorMessageResourceType = typeof(Resources.Resources))]
        public byte ProductionProcessCirculation { get; set; }

        [Column("ProductionProcessType")]
        [JsonProperty("ProductionProcessType")]
        public byte? ProductionProcessType { get; set; }

        [Column("TransferToInvRM")]
        [JsonProperty("TransferToInvRM")]
        public bool TransferToInvRM { get; set; }

        [Column("TransferToWarehouse")]
        [JsonProperty("TransferToWarehouse")]
        public bool TransferToWarehouse { get; set; }

        [Column("Describe")]
        [JsonProperty("Describe")]
        [MaxLength(150)]
        public string Describe { get; set; }

        [Column("Status")]
        [JsonProperty("Status")]
        [Required(ErrorMessageResourceName = "pub_RequiredField", ErrorMessageResourceType = typeof(Resources.Resources))]
        public byte Status { get; set; }

        [Column("IsDraft")]
        [JsonProperty("IsDraft")]
        [Required(ErrorMessageResourceName = "pub_RequiredField", ErrorMessageResourceType = typeof(Resources.Resources))]
        public bool IsDraft { get; set; }

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

        [JsonProperty("OrderDetail")]
        [ForeignKey(nameof(OrderDetailID))]
        public OrderDetails OrderDetail { get; set; }

        [JsonProperty("User_InsUser")]
        [ForeignKey(nameof(InsUserID))]
        public Users User_InsUser { get; set; }

        [JsonProperty("User_EditUser")]
        [ForeignKey(nameof(EditUserID))]
        public Users User_EditUser { get; set; }

        //[NotMapped]
        [JsonProperty("ProductionPlanPackagingList")]
        public List<ProductionPlanPackaging> ProductionPlanPackagingList { get; set; }

        //[NotMapped]
        [JsonProperty("ProductionPlanPatilsCapacityList")]
        public List<ProductionPlanPatilsCapacity> ProductionPlanPatilsCapacityList { get; set; }

        [JsonProperty("ProductionPlanBOMDetailList")]
        [ForeignKey(nameof(ProductionPlanID))]
        public List<ProductionPlanBOMDetail> ProductionPlanBOMDetailList { get; set; }

        [JsonProperty("ProductionPlanBOMDetailRevisedList")]
        [ForeignKey(nameof(ProductionPlanID))]
        public List<ProductionPlanBOMDetailRevised> ProductionPlanBOMDetailRevisedList { get; set; }

        [JsonProperty("ProductionPlanPatilList")]
        public List<ProductionPlanPatils> ProductionPlanPatilList { get; set; }


    }
}