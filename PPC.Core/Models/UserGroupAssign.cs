using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using PPC.Core.Models.Entity;
using System.ComponentModel;
using Newtonsoft.Json;

namespace PPC.Core.Models
{
    [Table("UserGroupAssign")]
    public class UserGroupAssigns : IEntity
    {
        #region Base properties and methods(generated by  CodeGenerator)
        [Key]
        [Column("UserGroupAssignID")]
        [JsonProperty("UserGroupAssignID")]
        [Required(ErrorMessageResourceName = "RequiredField_Anot", ErrorMessageResourceType = typeof(Resources.Resources))]

        public int UserGroupAssignID { get; set; }

        [Column("UserID")]
        [JsonProperty("UserID")]
        [Required(ErrorMessageResourceName = "RequiredField_Anot", ErrorMessageResourceType = typeof(Resources.Resources))]


        public int UserID { get; set; }

        [Column("UserGroupID")]
        [JsonProperty("UserGroupID")]
        [Required(ErrorMessageResourceName = "RequiredField_Anot", ErrorMessageResourceType = typeof(Resources.Resources))]


        public int UserGroupID { get; set; }
        #endregion Base properties and methods(generated by  CodeGenerator)


        [JsonProperty("User")]
        [ForeignKey(nameof(UserID))]
        public Users User { get; set; }


        [JsonProperty("UserGroup")]
        [ForeignKey(nameof(UserGroupID))]
        public UserGroups UserGroup { get; set; }

    }

}