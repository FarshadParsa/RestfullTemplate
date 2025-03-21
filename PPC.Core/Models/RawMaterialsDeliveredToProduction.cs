using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using PPC.Core.Models.Entity;
using System.ComponentModel;
using Newtonsoft.Json;
using System.Reflection.PortableExecutable;
using System.Collections.Generic;

namespace PPC.Core.Models
{
    [Table("RawMaterialsDeliveredToProduction")]
    public class RawMaterialsDeliveredToProduction : IEntity
    {
        #region Base properties
        [Key]
        [Column("RawMaterialsDeliveredToProductionID")]
        [JsonProperty("RawMaterialsDeliveredToProductionID")]
        [Required(ErrorMessageResourceName = "pub_RequiredField", ErrorMessageResourceType = typeof(Resources.Resources))]
        public int RawMaterialsDeliveredToProductionID { get; set; }


        [Column("DeliveryRawMaterialToProductionID")]
        [JsonProperty("DeliveryRawMaterialToProductionID")]
        [Required(ErrorMessageResourceName = "pub_RequiredField", ErrorMessageResourceType = typeof(Resources.Resources))]
        public int DeliveryRawMaterialToProductionID { get; set; }

        [Column("DeliverDate")]
        [JsonProperty("DeliverDate")]
        [Required(ErrorMessageResourceName = "pub_RequiredField", ErrorMessageResourceType = typeof(Resources.Resources))]
        public string DeliverDate { get; set; }

        [Column("DeliverTime")]
        [JsonProperty("DeliverTime")]
        [Required(ErrorMessageResourceName = "pub_RequiredField", ErrorMessageResourceType = typeof(Resources.Resources))]
        [MaxLength(5)]
        public string DeliverTime { get; set; }

        [Column("DeliveryUserID")]
        [JsonProperty("DeliveryUserID")]
        [Required(ErrorMessageResourceName = "pub_RequiredField", ErrorMessageResourceType = typeof(Resources.Resources))]
        public int DeliveryUserID { get; set; }

        [Column("ReceivingUserID")]
        [JsonProperty("ReceivingUserID")]
        [Required(ErrorMessageResourceName = "pub_RequiredField", ErrorMessageResourceType = typeof(Resources.Resources))]
        public int ReceivingUserID { get; set; }

        [Column("Describe")]
        [JsonProperty("Describe")]
        [MaxLength(150)]
        public string Describe { get; set; }

        [Column("Status")]
        [JsonProperty("Status")]
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
        ////[Required(ErrorMessageResourceName = "pub_RequiredField", ErrorMessageResourceType = typeof(Resources.Resources))]
        //[Timestamp]
        //public byte[]? RowVer { get; set; }

        #endregion Base properties

        [JsonProperty("DeliveryRawMaterialToProduction")]
        [ForeignKey(nameof(DeliveryRawMaterialToProductionID))]
        public DeliveryRawMaterialToProduction DeliveryRawMaterialToProduction { get; set; }

        [JsonProperty("DeliveryUser")]
        [ForeignKey(nameof(DeliveryUserID))]
        public Users DeliveryUser { get; set; }

        [JsonProperty("ReceivingUser")]
        [ForeignKey(nameof(ReceivingUserID))]
        public Users ReceivingUser { get; set; }

        [JsonProperty("User_InsUser")]
        [ForeignKey(nameof(InsUserID))]
        public Users User_InsUser { get; set; }

        [JsonProperty("User_EditUser")]
        [ForeignKey(nameof(EditUserID))]
        public Users User_EditUser { get; set; }

        [JsonProperty("RawMaterialsDeliveredToProductionDetailList")]
        public List<RawMaterialsDeliveredToProductionDetail> RawMaterialsDeliveredToProductionDetailList { get; set; }

    }
}
