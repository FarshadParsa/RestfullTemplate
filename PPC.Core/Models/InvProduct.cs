using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using PPC.Core.Models.Entity;
using System.ComponentModel;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace PPC.Core.Models
{
    [Table("InvProduct")]
    public class InvProducts : IEntity
    {
        #region Base properties
        [Key]
        [Column("InvProductID")]
        [JsonProperty("InvProductID")]
        [Required(ErrorMessageResourceName = "pub_RequiredField", ErrorMessageResourceType = typeof(Resources.Resources))]
        public int InvProductID { get; set; }

        [Column("InvProductCode")]
        [JsonProperty("InvProductCode")]
        [Required(ErrorMessageResourceName = "pub_RequiredField", ErrorMessageResourceType = typeof(Resources.Resources))]
        public string InvProductCode { get; set; }

        [Column("DataProductionID")]
        [JsonProperty("DataProductionID")]
        public int? DataProductionID { get; set; }

        [Column("ProductID")]
        [JsonProperty("ProductID")]
        [Required(ErrorMessageResourceName = "pub_RequiredField", ErrorMessageResourceType = typeof(Resources.Resources))]
        public int ProductID { get; set; }

        [Column("WeightingProductDetailID")]
        [JsonProperty("WeightingProductDetailID")]
        public int? WeightingProductDetailID { get; set; }

        [Column("Weight")]
        [JsonProperty("Weight")]
        [Required(ErrorMessageResourceName = "pub_RequiredField", ErrorMessageResourceType = typeof(Resources.Resources))]
        public decimal Weight { get; set; }

        [Column("NetWeight")]
        [JsonProperty("NetWeight")]
        [Required(ErrorMessageResourceName = "pub_RequiredField", ErrorMessageResourceType = typeof(Resources.Resources))]
        public decimal NetWeight { get; set; }

        [Column("EntryDate")]
        [JsonProperty("EntryDate")]
        [Required(ErrorMessageResourceName = "pub_RequiredField", ErrorMessageResourceType = typeof(Resources.Resources))]
        [MaxLength(10)]

        public string EntryDate { get; set; }

        [Column("ProducedDate")]
        [JsonProperty("ProducedDate")]
        [Required(ErrorMessageResourceName = "pub_RequiredField", ErrorMessageResourceType = typeof(Resources.Resources))]
        [MaxLength(10)]

        public string ProducedDate { get; set; }

        [Column("ExpireDate")]
        [JsonProperty("ExpireDate")]
        [Required(ErrorMessageResourceName = "pub_RequiredField", ErrorMessageResourceType = typeof(Resources.Resources))]
        [MaxLength(10)]

        public string ExpireDate { get; set; }

        [Column("ShelfLife")]
        [JsonProperty("ShelfLife")]
        [Required(ErrorMessageResourceName = "pub_RequiredField", ErrorMessageResourceType = typeof(Resources.Resources))]
        [MaxLength(10)]

        public string ShelfLife { get; set; }

        [Column("EnProducedDate")]
        [JsonProperty("EnProducedDate")]
        [Required(ErrorMessageResourceName = "pub_RequiredField", ErrorMessageResourceType = typeof(Resources.Resources))]
        [MaxLength(10)]

        public string EnProducedDate { get; set; }

        [Column("EnExpireDate")]
        [JsonProperty("EnExpireDate")]
        [Required(ErrorMessageResourceName = "pub_RequiredField", ErrorMessageResourceType = typeof(Resources.Resources))]
        [MaxLength(10)]

        public string EnExpireDate { get; set; }

        [Column("EnShelfLife")]
        [JsonProperty("EnShelfLife")]
        [Required(ErrorMessageResourceName = "pub_RequiredField", ErrorMessageResourceType = typeof(Resources.Resources))]
        [MaxLength(10)]

        public string EnShelfLife { get; set; }

        [Column("PackagingPlanID")]
        [JsonProperty("PackagingPlanID")]
        [Required(ErrorMessageResourceName = "pub_RequiredField", ErrorMessageResourceType = typeof(Resources.Resources))]
        public int PackagingPlanID { get; set; }

        [Column("SupplierID")]
        [JsonProperty("SupplierID")]
        public short? SupplierID { get; set; }

        [Column("Remark")]
        [JsonProperty("Remark")]

        [MaxLength(300)]

        public string Remark { get; set; }

        [Column("Status")]
        [JsonProperty("Status")]
        [Required(ErrorMessageResourceName = "pub_RequiredField", ErrorMessageResourceType = typeof(Resources.Resources))]


        public byte Status { get; set; }

        [Column("QcStatus")]
        [JsonProperty("QcStatus")]
        [Required(ErrorMessageResourceName = "pub_RequiredField", ErrorMessageResourceType = typeof(Resources.Resources))]
        public byte QcStatus { get; set; }

        [Column("PaletID")]
        [JsonProperty("PaletID")]
        public int? PaletID { get; set; }

        [Column("ParentID")]
        [JsonProperty("ParentID")]
        public int? ParentID { get; set; }

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

        [JsonProperty("DataProduction")]
        [ForeignKey(nameof(DataProductionID))]
        public DataProduction DataProduction { get; set; }

        [JsonProperty("Product")]
        [ForeignKey(nameof(ProductID))]
        public Products Product { get; set; }

        [JsonProperty("WeightingProductDetail")]
        [ForeignKey(nameof(WeightingProductDetailID))]
        public WeightingProductDetail WeightingProductDetail { get; set; }

        [JsonProperty("PackagingType")]
        [ForeignKey(nameof(PackagingPlanID))]
        public PackagingTypes PackagingType { get; set; }

        [JsonProperty("Supplier")]
        [ForeignKey(nameof(SupplierID))]
        public Suppliers Supplier { get; set; }

        [JsonProperty("Palet")]
        [ForeignKey(nameof(PaletID))]
        public Palets Palet { get; set; }

        [JsonProperty("Parent")]
        [ForeignKey(nameof(ParentID))]
        public InvProducts Parent  { get; set; }

        [JsonProperty("User_InsUser")]
        [ForeignKey(nameof(InsUserID))]
        public Users User_InsUser { get; set; }

        [JsonProperty("User_EditUser")]
        [ForeignKey(nameof(EditUserID))]
        public Users User_EditUser { get; set; }




    }
}