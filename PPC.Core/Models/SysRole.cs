using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using PPC.Core.Models.Entity;
using System.Text;

namespace PPC.Core.Models
{
    [Table("SysRoles")]
    public class SysRole : IEntity
    {
        public SysRole()
        {
            UserRoles = new HashSet<SysUserRole>();
        }

        [Key]
        [Column("ID")]
        public int ID { get; set; }

        [Column("Name")]
        public string Name { get; set; }

        public virtual ICollection<SysUserRole> UserRoles { get; set; }
    }
}
