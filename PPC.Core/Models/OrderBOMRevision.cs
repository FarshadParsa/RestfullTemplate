using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using PPC.Core.Models.Entity;
using System.ComponentModel;
using Newtonsoft.Json;

namespace PPC.Core.Models
{
    [Table("OrderBOMRevision")]
    public class OrderBOMRevisions : IEntity
    {
        #region Base properties
        [Key]
        [Column("OrderBOMReviseID")]
        [JsonProperty("OrderBOMReviseID")]
        [Required(ErrorMessageResourceName = "pub_RequiredField", ErrorMessageResourceType = typeof(Resources.Resources))]
        public int OrderBOMReviseID { get; set; }

        [Column("OrderDetailID")]
        [JsonProperty("OrderDetailID")]
        [Required(ErrorMessageResourceName = "pub_RequiredField", ErrorMessageResourceType = typeof(Resources.Resources))]
        public int OrderDetailID { get; set; }

        [Column("OldBOMID")]
        [JsonProperty("OldBOMID")]
        //[Required(ErrorMessageResourceName = "pub_RequiredField", ErrorMessageResourceType = typeof(Resources.Resources))]
        public int? OldBOMID { get; set; }

        [Column("NewBOMID")]
        [JsonProperty("NewBOMID")]
        [Required(ErrorMessageResourceName = "pub_RequiredField", ErrorMessageResourceType = typeof(Resources.Resources))]
        public int NewBOMID { get; set; }

        [Column("Describe")]
        [JsonProperty("Describe")]
        [MaxLength(250)]
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

        [Column("RowVer")]
        [JsonProperty("RowVer")]
        [Required(ErrorMessageResourceName = "pub_RequiredField", ErrorMessageResourceType = typeof(Resources.Resources))]
        [Timestamp]
        public byte[] RowVer { get; set; }
        #endregion Base properties


        [JsonProperty("OrderDetail")]
        [ForeignKey(nameof(OrderDetailID))]
        public OrderDetails OrderDetail { get; set; }

        [JsonProperty("BOM_OldBOM")]
        [ForeignKey(nameof(OldBOMID))]
        public BOM BOM_OldBOM { get; set; }

        [JsonProperty("BOM_NewBOM")]
        [ForeignKey(nameof(NewBOMID))]
        public BOM BOM_NewBOM { get; set; }


        [JsonProperty("User_InsUser")]
        [ForeignKey(nameof(InsUserID))]
        public Users User_InsUser { get; set; }

        [JsonProperty("User_EditUser")]
        [ForeignKey(nameof(EditUserID))]
        public Users User_EditUser { get; set; }



    }
}