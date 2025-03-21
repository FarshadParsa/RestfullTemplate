using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using PPC.Core.Models.Entity;

namespace PPC.Core.Models
{

    [Table("sysUserAccounts")]
    public class SysUserAccount : IEntity
    {
        public SysUserAccount()
        {
            UserRoles = new HashSet<SysUserRole>();
            UserTokens = new HashSet<SysUserToken>();
        }

        [Key]
        [Column("ID")]
        public int ID { get; set; }
        [Column("FirstName")]
        public string FirstName { get; set; }
        [Column("LastName")]
        public string LastName { get; set; }
        [Column("Username")]
        public string Username { get; set; }

        [Column("Password")]
        public string Password { get; set; }

        [Column("IsActive")]
        public Boolean IsActive { get; set; }

        [Column("RowEditTime")]
        public DateTime? RowEditTime { get; set; }  
        
        [Column("LastLoginTime")]
        public DateTime? LastLoginTime { get; set; }

        [Column("SerialNumber")]
        public string SerialNumber { get; set; }

        public virtual ICollection<SysUserRole> UserRoles { get; set; }

        public virtual ICollection<SysUserToken> UserTokens { get; set; }

    }
}
