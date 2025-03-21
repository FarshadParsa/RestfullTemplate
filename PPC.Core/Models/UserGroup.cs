using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using PPC.Core.Models.Entity;
using System.ComponentModel;
using Newtonsoft.Json;

namespace PPC.Core.Models
{
    [Table("UserGroup")]
    public class UserGroups : IEntity
    {
        #region Base properties and methods(generated by  CodeGenerator)
        [Key]
        [Column("UserGroupID")]
        [JsonProperty("UserGroupID")]
        [Required(ErrorMessageResourceName = "RequiredField_Anot", ErrorMessageResourceType = typeof(Resources.Resources))]

        public int UserGroupID { get; set; }

        [Column("UserGroupName")]
        [JsonProperty("UserGroupName")]
        [Required(ErrorMessageResourceName = "RequiredField_Anot", ErrorMessageResourceType = typeof(Resources.Resources))]


        public string UserGroupName { get; set; }

        [Column("Describe")]
        [JsonProperty("Describe")]



        public string Describe { get; set; }
        #endregion Base properties and methods(generated by  CodeGenerator)
    }
}