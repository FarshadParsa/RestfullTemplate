using PPC.Core.Models.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace PPC.Core.Models
{
    [Table("SysAuditData")]
    public class SysAuditData : IEntity
    {
        [Key]
        [Column("ID")]
        public int ID { get; set; }
        [Column("ActionName")]
        public string ActionName { get; set; }
        [Column("ControllerName")]
        public string ControllerName { get; set; }
        [Column("IpAddress")]
        public string IpAddress { get; set; }
        [Column("LoggedInAt")]
        public DateTime? LoggedInAt { get; set; }

        [Column("ServiceAccessed")]
        public string ServiceAccessed { get; set; }

        [Column("UserId")]
        public int UserId { get; set; }
    }
}
