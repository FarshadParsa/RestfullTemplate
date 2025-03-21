using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using PPC.Core.Models.Entity;
using System.ComponentModel;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace PPC.Core.Models
{
    [Table("CustomerDossier")]
    public class CustomerDossier : IEntity
    {
        #region Base properties and methods(generated by  CodeGenerator)
        [Key]
        [Column("CustomerDossierID")]
        [JsonProperty("CustomerDossierID")]
        [Required(ErrorMessageResourceName = "pub_RequiredField", ErrorMessageResourceType = typeof(Resources.Resources))]

        public int CustomerDossierID { get; set; }

        [Column("DossierNo")]
        [JsonProperty("DossierNo")]
        [Required(ErrorMessageResourceName = "pub_RequiredField", ErrorMessageResourceType = typeof(Resources.Resources))]
        public int DossierNo { get; set; }

        [Column("RefDossierID")]
        [JsonProperty("RefDossierID")]



        public int? RefDossierID { get; set; }

        [Column("CustomerID")]
        [JsonProperty("CustomerID")]
        [Required(ErrorMessageResourceName = "pub_RequiredField", ErrorMessageResourceType = typeof(Resources.Resources))]


        public int CustomerID { get; set; }

        [Column("ProductID")]
        [JsonProperty("ProductID")]
        [Required(ErrorMessageResourceName = "pub_RequiredField", ErrorMessageResourceType = typeof(Resources.Resources))]


        public int ProductID { get; set; }

        [Column("DefaultBOMID")]
        [JsonProperty("DefaultBOMID")]
        [Required(ErrorMessageResourceName = "pub_RequiredField", ErrorMessageResourceType = typeof(Resources.Resources))]


        public int DefaultBOMID { get; set; }

        [Column("IsActive")]
        [JsonProperty("IsActive")]
        [Required(ErrorMessageResourceName = "pub_RequiredField", ErrorMessageResourceType = typeof(Resources.Resources))]


        public bool IsActive { get; set; }

        [Column("IsDraft")]
        [JsonProperty("IsDraft")]
        [Required(ErrorMessageResourceName = "pub_RequiredField", ErrorMessageResourceType = typeof(Resources.Resources))]


        public bool IsDraft { get; set; }

        [Column("TestPlanAssignID")]
        [JsonProperty("TestPlanAssignID")]
        [Required(ErrorMessageResourceName = "pub_RequiredField", ErrorMessageResourceType = typeof(Resources.Resources))]


        public int TestPlanAssignID { get; set; }

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

        [Column("Describe")]
        [JsonProperty("Describe")]
        [MaxLength(600)]
        public string Describe { get; set; }

        [Column("Status")]
        [JsonProperty("Status")]


        public byte Status { get; set; }
        #endregion Base properties and methods(generated by  CodeGenerator)


        [JsonProperty("RefDossier")]
        [ForeignKey(nameof(RefDossierID))]
        public CustomerDossier RefDossier { get; set; }

        [JsonProperty("Product")]
        [ForeignKey(nameof(ProductID))]
        public Products Product { get; set; }

        [JsonProperty("Customer")]
        [ForeignKey(nameof(CustomerID))]
        public Customers Customer { get; set; }

        [JsonProperty("DefaultBOM")]
        [ForeignKey(nameof(DefaultBOMID))]
        public BOM DefaultBOM { get; set; }

        [JsonProperty("User_InsUser")]
        [ForeignKey(nameof(InsUserID))]
        public Users User_InsUser { get; set; }

        [JsonProperty("User_EditUser")]
        [ForeignKey(nameof(EditUserID))]
        public Users User_EditUser { get; set; }

        [NotMapped]
        [JsonProperty("CustomerDossierBOMList")]
        public List<CustomerDossierBOMs> CustomerDossierBOMList { get; set; }


    }
}