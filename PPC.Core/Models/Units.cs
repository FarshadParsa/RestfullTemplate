using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using PPC.Core.Models.Entity;
using System.ComponentModel;
using Newtonsoft.Json;

namespace PPC.Core.Models
{
    [Table("Unit")]
    public class Units : IEntity
    {
        [Key]
        [Column("UnitID")]
        [JsonProperty("UnitID")]
        [Required(ErrorMessageResourceName = "RequiredField_Anot", ErrorMessageResourceType = typeof(Resources.Resources))]

        public int UnitID { get; set; }

        [Column("UnitName")]
        [JsonProperty("UnitName")]
        [Required(ErrorMessageResourceName = "RequiredField_Anot", ErrorMessageResourceType = typeof(Resources.Resources))]
        [MaxLength(50)]
        public string UnitName { get; set; }

        [Column("UnitLatinName")]
        [JsonProperty("UnitLatinName")]
        [Required(ErrorMessageResourceName = "RequiredField_Anot", ErrorMessageResourceType = typeof(Resources.Resources))]
        [MaxLength(50)]
        public string UnitLatinName { get; set; }

        [Column("Abbreviation")]
        [JsonProperty("Abbreviation")]
        [Required(ErrorMessageResourceName = "RequiredField_Anot", ErrorMessageResourceType = typeof(Resources.Resources))]
        [MaxLength(10)]
        public string Abbreviation { get; set; }

    }
}
