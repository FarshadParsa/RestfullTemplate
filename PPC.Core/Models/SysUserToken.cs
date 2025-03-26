using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WebApi.Core.Models.Entity;

namespace WebApi.Core.Models
{
    [Table("SysUserTokens")]
    public class SysUserToken : IEntity
    {

        [Key]
        [Column("ID")]
        public int ID { get; set; }

        [Column("AccessTokenHash")]
        public string AccessTokenHash { get; set; }

        [Column("AccessTokenExpiresDateTime")]
        public DateTimeOffset AccessTokenExpiresDateTime { get; set; }

        [Column("RefreshTokenIdHash")]
        public string RefreshTokenIdHash { get; set; }
        
        [Column("RefreshTokenIdHashSource")]
        public string RefreshTokenIdHashSource { get; set; }

        [Column("RefreshTokenExpiresDateTime")]
        public DateTimeOffset RefreshTokenExpiresDateTime { get; set; }

        [Column("UserId")]
        public int UserId { get; set; }
        public virtual SysUserAccount User { get; set; }
    }
}
