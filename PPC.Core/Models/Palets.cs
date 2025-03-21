using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using PPC.Core.Models.Entity;
using System.ComponentModel;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace PPC.Core.Models
{
    [Table("Palets")]
    public class Palets : IEntity
    {
        #region Base properties
        [Key]
        [Column("PaletID")]
        [JsonProperty("PaletID")]
        [Required(ErrorMessageResourceName = "pub_RequiredField", ErrorMessageResourceType = typeof(Resources.Resources))]
        public int PaletID { get; set; }

        [Column("PaletNo")]
        [JsonProperty("PaletNo")]
        [MaxLength(50)]

        public string PaletNo { get; set; }

        [Column("CustomerID")]
        [JsonProperty("CustomerID")]
        public int? CustomerID { get; set; }

        [Column("OrderDetailID")]
        [JsonProperty("OrderDetailID")]
        public int? OrderDetailID { get; set; }

        [Column("ProductID")]
        [JsonProperty("ProductID")]
        [Required(ErrorMessageResourceName = "pub_RequiredField", ErrorMessageResourceType = typeof(Resources.Resources))]


        public int ProductID { get; set; }

        [Column("NetWeight")]
        [JsonProperty("NetWeight")]
        [Required(ErrorMessageResourceName = "pub_RequiredField", ErrorMessageResourceType = typeof(Resources.Resources))]


        public decimal NetWeight { get; set; }

        [Column("Weight")]
        [JsonProperty("Weight")]
        [Required(ErrorMessageResourceName = "pub_RequiredField", ErrorMessageResourceType = typeof(Resources.Resources))]


        public decimal Weight { get; set; }

        [Column("QTY")]
        [JsonProperty("QTY")]
        [Required(ErrorMessageResourceName = "pub_RequiredField", ErrorMessageResourceType = typeof(Resources.Resources))]


        public short QTY { get; set; }

        [Column("PaletDate")]
        [JsonProperty("PaletDate")]
        [Required(ErrorMessageResourceName = "pub_RequiredField", ErrorMessageResourceType = typeof(Resources.Resources))]
        [MaxLength(12)]

        public string PaletDate { get; set; }

        [Column("PaletTime")]
        [JsonProperty("PaletTime")]
        [Required(ErrorMessageResourceName = "pub_RequiredField", ErrorMessageResourceType = typeof(Resources.Resources))]
        [MaxLength(5)]

        public string PaletTime { get; set; }

        [Column("UserID")]
        [JsonProperty("UserID")]
        [Required(ErrorMessageResourceName = "pub_RequiredField", ErrorMessageResourceType = typeof(Resources.Resources))]


        public int UserID { get; set; }

        [Column("StationID")]
        [JsonProperty("StationID")]
        [Required(ErrorMessageResourceName = "pub_RequiredField", ErrorMessageResourceType = typeof(Resources.Resources))]
        public int StationID { get; set; }

        [Column("QualityClass")]
        [JsonProperty("QualityClass")]

        [MaxLength(5)]

        public string QualityClass { get; set; }

        [Column("Status")]
        [JsonProperty("Status")]
        [Required(ErrorMessageResourceName = "pub_RequiredField", ErrorMessageResourceType = typeof(Resources.Resources))]


        public byte Status { get; set; }

        [Column("ProductsQuality")]
        [JsonProperty("ProductsQuality")]

        [MaxLength(100)]

        public string ProductsQuality { get; set; }

        [Column("Remarks")]
        [JsonProperty("Remarks")]

        [MaxLength(300)]

        public string Remarks { get; set; }

        [Column("QcStatus")]
        [JsonProperty("QcStatus")]
        public byte? QcStatus { get; set; }
        #endregion Base properties

        [JsonProperty("Customer")]
        [ForeignKey(nameof(CustomerID))]
        public Customers Customer { get; set; }


        [JsonProperty("OrderDetail")]
        [ForeignKey(nameof(OrderDetailID))]
        public OrderDetails OrderDetail { get; set; }


        [JsonProperty("Product")]
        [ForeignKey(nameof(ProductID))]
        public Products Product { get; set; }


        [JsonProperty("User")]
        [ForeignKey(nameof(UserID))]
        public Users User { get; set; }


        [JsonProperty("Station")]
        [ForeignKey(nameof(StationID))]
        public Stations Station { get; set; }


        [JsonProperty("PaletDetailList")]
        public List<PaletDetail> PaletDetailList { get; set; }


        #region Foreign Keys


        #endregion


        #region Children

        #region RevertPalets


        /// <summary>
        /// List<Palet>
        /// </summary>
        //[ForeignKey(nameof(PaletID))]
        public virtual List<RevertPalets> RevertPaletsList { get; set; }

        #endregion

        #region RevertPalets


        /// <summary>
        /// List<Palet>
        /// </summary>
        //[ForeignKey("NewPaletID")]
        public virtual List<RevertPalets> RevertNewPaletsList { get; set; }

        #endregion

        #endregion



    }
}