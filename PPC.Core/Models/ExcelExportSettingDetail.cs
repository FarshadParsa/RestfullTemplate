using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using PPC.Core.Models.Entity;
using System.ComponentModel;
using Newtonsoft.Json;

namespace PPC.Core.Models
{
    [Table("ExcelExportSettingDetail")]
    public class ExcelExportSettingDetail : IEntity
    {
        #region Base properties
        [Key]
        [Column("ExcelExportSettingDetailID")]
        [JsonProperty("ExcelExportSettingDetailID")]
        [Required(ErrorMessageResourceName = "pub_RequiredField", ErrorMessageResourceType = typeof(Resources.Resources))]
        public long ExcelExportSettingDetailID { get; set; }

        [Column("Priority")]
        [JsonProperty("Priority")]
        public int Priority { get; set; }

        [Column("ExcelExportSettingID")]
        [JsonProperty("ExcelExportSettingID")]
        public int ExcelExportSettingID { get; set; }

        [Column("FieldName")]
        [JsonProperty("FieldName")]
        [MaxLength(50)]
        public string FieldName { get; set; }

        [Column("DisplayName")]
        [JsonProperty("DisplayName")]
        [MaxLength(50)]
        public string DisplayName { get; set; }

        [Column("Visible")]
        [JsonProperty("Visible")]
        public bool Visible { get; set; }
        #endregion Base properties


        [JsonProperty("ExcelExportSetting")]
        [ForeignKey(nameof(ExcelExportSettingID))]
        public ExcelExportSetting ExcelExportSetting { get; set; }


    }
}