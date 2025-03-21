using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using PPC.Core.Models.Entity;
using System.ComponentModel;
using Newtonsoft.Json;
using System.Collections.Generic;
using PPC.Core.Services;
namespace PPC.Core.Models
{
    [Table("DeliveryRawMaterialToProduction")]
    public class DeliveryRawMaterialToProduction : IEntity
    {
        #region Base properties
        [Key]
        [Column("DeliveryRawMaterialToProductionID")]
        [JsonProperty("DeliveryRawMaterialToProductionID")]
        [Required(ErrorMessageResourceName = "pub_RequiredField", ErrorMessageResourceType = typeof(Resources.Resources))]
        public int DeliveryRawMaterialToProductionID { get; set; }

        [Column("RequestNo")]
        [JsonProperty("RequestNo")]
        [Required(ErrorMessageResourceName = "pub_RequiredField", ErrorMessageResourceType = typeof(Resources.Resources))]
        public int RequestNo { get; set; }

        [Column("RequestDate")]
        [JsonProperty("RequestDate")]
        [Required(ErrorMessageResourceName = "pub_RequiredField", ErrorMessageResourceType = typeof(Resources.Resources))]
        public string RequestDate { get; set; }

        [Column("RequesterID")]
        [JsonProperty("RequesterID")]
        [Required(ErrorMessageResourceName = "pub_RequiredField", ErrorMessageResourceType = typeof(Resources.Resources))]
        public int RequesterID { get; set; }

        [Column("ProductionPlanID")]
        [JsonProperty("ProductionPlanID")]
        [Required(ErrorMessageResourceName = "pub_RequiredField", ErrorMessageResourceType = typeof(Resources.Resources))]
        public int ProductionPlanID { get; set; }

        [JsonProperty("Status")]
        [Column("Status")]
        [Required(ErrorMessageResourceName = "pub_RequiredField", ErrorMessageResourceType = typeof(Resources.Resources))]
        public byte Status { get; set; }


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

        [Column("IsDraft")]
        [JsonProperty("IsDraft")]
        [Required(ErrorMessageResourceName = "pub_RequiredField", ErrorMessageResourceType = typeof(Resources.Resources))]
        public bool IsDraft { get; set; }

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

        //[Column("RowVer")]
        //[JsonProperty("RowVer")]
        //[Timestamp]
        //public byte[] RowVer { get; set; }

        #endregion Base properties

        [JsonProperty("ProductionPlan")]
        [ForeignKey(nameof(ProductionPlanID))]
        public ProductionPlans ProductionPlan { get; set; }

        [JsonProperty("Requester")]
        [ForeignKey(nameof(RequesterID))]
        public Users Requester { get; set; }

        [JsonProperty("User_InsUser")]
        [ForeignKey(nameof(InsUserID))]
        public  Users User_InsUser    { get; set; }

        [JsonProperty("User_EditUser")]
        [ForeignKey(nameof(EditUserID))]
        public  Users User_EditUser    { get; set; }

        [JsonProperty("DeliveryRawMaterialToProductionDetailList")]
        public  List<DeliveryRawMaterialToProductionDetail> DeliveryRawMaterialToProductionDetailList { get; set; }

        [JsonProperty("DeliveryRawMaterialToProductionPatilList")]
        public List<DeliveryRawMaterialToProductionPatils> DeliveryRawMaterialToProductionPatilList { get; set; }



    }
}