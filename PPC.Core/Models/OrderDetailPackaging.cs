using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using PPC.Core.Models.Entity;
using System.ComponentModel;
using Newtonsoft.Json;

namespace PPC.Core.Models
{
    [Table("OrderDetailPackaging")]
    public class OrderDetailPackagings : IEntity
    {
        #region Base properties and methods(generated by  CodeGenerator)
        [Key]
        [Column("OrderDetailPackagingID")]
        [JsonProperty("OrderDetailPackagingID")]
        [Required(ErrorMessageResourceName = "pub_RequiredField", ErrorMessageResourceType = typeof(Resources.Resources))]

        public int OrderDetailPackagingID { get; set; }

        [Column("OrderDetailID")]
        [JsonProperty("OrderDetailID")]
        [Required(ErrorMessageResourceName = "pub_RequiredField", ErrorMessageResourceType = typeof(Resources.Resources))]
        public int OrderDetailID { get; set; }

        [Column("PackagingPlanID")]
        [JsonProperty("PackagingPlanID")]
        [Required(ErrorMessageResourceName = "pub_RequiredField", ErrorMessageResourceType = typeof(Resources.Resources))]


        public int PackagingPlanID { get; set; }

        [Column("Priority")]
        [JsonProperty("Priority")]
        [Required(ErrorMessageResourceName = "pub_RequiredField", ErrorMessageResourceType = typeof(Resources.Resources))]
        public byte Priority { get; set; }
        #endregion Base properties and methods(generated by  CodeGenerator)

        [JsonProperty("OrderDetail")]
        [ForeignKey(nameof(OrderDetailID))]
        public OrderDetails OrderDetail { get; set; }


    }
}