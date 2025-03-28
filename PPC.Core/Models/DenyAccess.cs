using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using WebApi.Core.Models.Entity;
using System.ComponentModel;
using Newtonsoft.Json;
using System;

namespace WebApi.Core.Models
{
    [Table("DenyAccess")]
    public class DenyAccesses : IEntity
    {
        #region Base properties and methods(generated by  CodeGenerator)
        [Key]
        [Column("DenyAccessID")]
        [JsonProperty("DenyAccessID")]
        [Required(ErrorMessageResourceName = "RequiredField_Anot", ErrorMessageResourceType = typeof(Resources.Resources))]

        public int DenyAccessID { get; set; }

        [Column("UserID")]
        [JsonProperty("UserID")]



        public int UserID { get; set; }

        [Column("StationID")]
        [JsonProperty("StationID")]



        public int StationID { get; set; }

        [Column("MenuGroupID")]
        [JsonProperty("MenuGroupID")]
        [Required(ErrorMessageResourceName = "RequiredField_Anot", ErrorMessageResourceType = typeof(Resources.Resources))]


        public byte MenuGroupID { get; set; }

        [Column("MenuID")]
        [JsonProperty("MenuID")]
        [Required(ErrorMessageResourceName = "RequiredField_Anot", ErrorMessageResourceType = typeof(Resources.Resources))]
        public Int16 MenuID { get; set; }

        [Column("MenuName")]
        [JsonProperty("MenuName")]
        [Required(ErrorMessageResourceName = "RequiredField_Anot", ErrorMessageResourceType = typeof(Resources.Resources))]
        [MaxLength(300)]
        public string MenuName { get; set; }

        [Column("Caption")]
        [JsonProperty("Caption")]
        [Required(ErrorMessageResourceName = "RequiredField_Anot", ErrorMessageResourceType = typeof(Resources.Resources))]
        [MaxLength(120)]
        public string Caption { get; set; }

        [Column("CaptionPath")]
        [JsonProperty("CaptionPath")]
        [Required(ErrorMessageResourceName = "RequiredField_Anot", ErrorMessageResourceType = typeof(Resources.Resources))]
        [MaxLength(120)]
        public string CaptionPath { get; set; }

        [Column("State")]
        [JsonProperty("State")]
        [Required(ErrorMessageResourceName = "RequiredField_Anot", ErrorMessageResourceType = typeof(Resources.Resources))]
        public decimal State { get; set; }

        #endregion Base properties and methods(generated by  CodeGenerator)

    }
}