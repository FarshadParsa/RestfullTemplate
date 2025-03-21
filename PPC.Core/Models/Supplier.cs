using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using PPC.Core.Models.Entity;
using System.ComponentModel;
using Newtonsoft.Json;

namespace PPC.Core.Models
{
    [Table("Supplier")]
    public class Suppliers : IEntity
    {
        #region Base properties and methods(generated by  CodeGenerator)
        [Key]
        [Column("SupplierID")]
        [JsonProperty("SupplierID")]
        [Required(ErrorMessageResourceName = "RequiredField_Anot", ErrorMessageResourceType = typeof(Resources.Resources))]

        public short SupplierID { get; set; }

        [Column("SupplierCode")]
        [JsonProperty("SupplierCode")]
        [Required(ErrorMessageResourceName = "RequiredField_Anot", ErrorMessageResourceType = typeof(Resources.Resources))]


        public string SupplierCode { get; set; }

        [Column("SupplierName")]
        [JsonProperty("SupplierName")]
        [Required(ErrorMessageResourceName = "RequiredField_Anot", ErrorMessageResourceType = typeof(Resources.Resources))]


        public string SupplierName { get; set; }

        [Column("SupplierLatinName")]
        [JsonProperty("SupplierLatinName")]
        [Required(ErrorMessageResourceName = "RequiredField_Anot", ErrorMessageResourceType = typeof(Resources.Resources))]
        [MaxLength(100)]

        public string SupplierLatinName { get; set; }

        [Column("SupplierOriginName")]
        [JsonProperty("SupplierOriginName")]

        [MaxLength(100)]

        public string SupplierOriginName { get; set; }

        [Column("ContactPerson")]
        [JsonProperty("ContactPerson")]

        [MaxLength(50)]

        public string ContactPerson { get; set; }

        [Column("ProvinceID")]
        [JsonProperty("ProvinceID")]
        //[Required(ErrorMessageResourceName = "RequiredField_Anot", ErrorMessageResourceType = typeof(Resources.Resources))]
        public short? ProvinceID { get; set; }

        [Column("Tel")]
        [JsonProperty("Tel")]

        [MaxLength(100)]

        public string Tel { get; set; }

        [Column("Address")]
        [JsonProperty("Address")]

        [MaxLength(300)]

        public string Address { get; set; }

        [Column("ZipCode")]
        [JsonProperty("ZipCode")]

        [MaxLength(15)]

        public string ZipCode { get; set; }

        [Column("NationalIdentity")]
        [JsonProperty("NationalIdentity")]

        [MaxLength(20)]

        public string NationalIdentity { get; set; }

        [Column("RegistrationNumber")]
        [JsonProperty("RegistrationNumber")]

        [MaxLength(20)]

        public string RegistrationNumber { get; set; }

        [Column("EconomicCode")]
        [JsonProperty("EconomicCode")]

        [MaxLength(20)]

        public string EconomicCode { get; set; }

        [Column("Rating")]
        [JsonProperty("Rating")]
        [Required(ErrorMessageResourceName = "RequiredField_Anot", ErrorMessageResourceType = typeof(Resources.Resources))]


        public decimal Rating { get; set; }

        [Column("CustomerGradeID")]
        [JsonProperty("CustomerGradeID")]
        [Required(ErrorMessageResourceName = "RequiredField_Anot", ErrorMessageResourceType = typeof(Resources.Resources))]


        public short CustomerGradeID { get; set; }

        [Column("StartDate")]
        [JsonProperty("StartDate")]

        [MaxLength(10)]

        public string StartDate { get; set; }

        [Column("CEO")]
        [JsonProperty("CEO")]

        [MaxLength(30)]

        public string CEO { get; set; }

        [Column("InsUserID")]
        [JsonProperty("InsUserID")]
        [Required(ErrorMessageResourceName = "RequiredField_Anot", ErrorMessageResourceType = typeof(Resources.Resources))]


        public int InsUserID { get; set; }

        [Column("InsDate")]
        [JsonProperty("InsDate")]
        [Required(ErrorMessageResourceName = "RequiredField_Anot", ErrorMessageResourceType = typeof(Resources.Resources))]
        [MaxLength(10)]

        public string InsDate { get; set; }

        [Column("InsTime")]
        [JsonProperty("InsTime")]
        [Required(ErrorMessageResourceName = "RequiredField_Anot", ErrorMessageResourceType = typeof(Resources.Resources))]
        [MaxLength(5)]

        public string InsTime { get; set; }

        [Column("EditUserID")]
        [JsonProperty("EditUserID")]
        [Required(ErrorMessageResourceName = "RequiredField_Anot", ErrorMessageResourceType = typeof(Resources.Resources))]

       //[Display(Name = "TblAnot_Supplier_EditUserID", ResourceType = typeof(Resources.Resources))]
        public int EditUserID { get; set; }

        [Column("EditDate")]
        [JsonProperty("EditDate")]
        [Required(ErrorMessageResourceName = "RequiredField_Anot", ErrorMessageResourceType = typeof(Resources.Resources))]
        [MaxLength(10)]

        public string EditDate { get; set; }

        [Column("EditTime")]
        [JsonProperty("EditTime")]
        [Required(ErrorMessageResourceName = "RequiredField_Anot", ErrorMessageResourceType = typeof(Resources.Resources))]
        [MaxLength(5)]

        public string EditTime { get; set; }

        [Column("IsForeign")]
        [JsonProperty("IsForeign")]
        [Required(ErrorMessageResourceName = "RequiredField_Anot", ErrorMessageResourceType = typeof(Resources.Resources))]


        public bool IsForeign { get; set; }

        [Column("IsActive")]
        [JsonProperty("IsActive")]
        [Required(ErrorMessageResourceName = "RequiredField_Anot", ErrorMessageResourceType = typeof(Resources.Resources))]


        public bool IsActive { get; set; }

        #endregion Base properties and methods(generated by  CodeGenerator)

        [ForeignKey(nameof(ProvinceID))]
        public Provinces Province { get; set; }

        [ForeignKey(nameof(CustomerGradeID))]
        public CustomerGrades CustomerGrade { get; set; }


        [JsonProperty("User_InsUser")]
        [ForeignKey(nameof(InsUserID))]
        public Users User_InsUser { get; set; }

        [JsonProperty("User_EditUser")]
        [ForeignKey(nameof(EditUserID))]
        public Users User_EditUser { get; set; }



    }
}