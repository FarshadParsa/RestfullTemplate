using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using PPC.Core.Models.Entity;
using System.ComponentModel;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace PPC.Core.Models
{
    [Table("WeightingProductDetail")]
    public class WeightingProductDetail : IEntity
    {
        #region Base properties
        [Key]
        [Column("WeightingProductDetailID")]
        [JsonProperty("WeightingProductDetailID")]
        [Required(ErrorMessageResourceName = "pub_RequiredField", ErrorMessageResourceType = typeof(Resources.Resources))]
        public int WeightingProductDetailID { get; set; }

        [Column("WeightingProductID")]
        [JsonProperty("WeightingProductID")]
        [Required(ErrorMessageResourceName = "pub_RequiredField", ErrorMessageResourceType = typeof(Resources.Resources))]
        public int WeightingProductID { get; set; }

        [Column("PackagingPlanID")]
        [JsonProperty("PackagingPlanID")]
        [Required(ErrorMessageResourceName = "pub_RequiredField", ErrorMessageResourceType = typeof(Resources.Resources))]
        public int PackagingPlanID { get; set; }

        [Column("QTY")]
        [JsonProperty("QTY")]
        [Required(ErrorMessageResourceName = "pub_RequiredField", ErrorMessageResourceType = typeof(Resources.Resources))]
        public short QTY { get; set; }

        [Column("EmptyWeight")]
        [JsonProperty("EmptyWeight")]
        [Required(ErrorMessageResourceName = "pub_RequiredField", ErrorMessageResourceType = typeof(Resources.Resources))]
        public decimal EmptyWeight { get; set; }

        [Column("NetWeight")]
        [JsonProperty("NetWeight")]
        [Required(ErrorMessageResourceName = "pub_RequiredField", ErrorMessageResourceType = typeof(Resources.Resources))]
        public decimal NetWeight { get; set; }
        #endregion Base properties


        [JsonProperty("WeightingProduct")]
        [ForeignKey(nameof(WeightingProductID))]
        public WeightingProducts WeightingProduct { get; set; }

        //[JsonProperty("PackagingPlan")]
        //[ForeignKey(nameof(PackagingPlanID))]
        //public PackagingPlans PackagingPlan { get; set; }

        [JsonProperty("PackagingType")]
        [ForeignKey(nameof(PackagingPlanID))]
        public PackagingTypes PackagingType { get; set; }


        [JsonProperty("InvProductList")]
        public List<InvProducts> InvProductList { get; set; }


    }
}