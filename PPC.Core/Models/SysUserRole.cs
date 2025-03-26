using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WebApi.Core.Models.Entity;

namespace WebApi.Core.Models
{
    [Table("SysUserRoles")]
    public class SysUserRole : IEntity
    {
        public SysUserRole()
        {

        }
        [Key]
        [Column("UserId")]
        public int UserId { get; set; }

        [Key]
        [Column("RoleId")]
        public int RoleId { get; set; }

        public virtual SysUserAccount SysUserAccount { get; set; }
        public virtual SysRole SysRole { get; set; }
    }
}
