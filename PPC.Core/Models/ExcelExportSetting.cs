using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using PPC.Core.Models.Entity;
using System.ComponentModel;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace PPC.Core.Models
{
    [Table("ExcelExportSetting")]
    public class ExcelExportSetting : IEntity
    {
        #region Base properties
        [Key]
        [Column("ExcelExportSettingID")]
        [JsonProperty("ExcelExportSettingID")]
        [Required(ErrorMessageResourceName = "pub_RequiredField", ErrorMessageResourceType = typeof(Resources.Resources))]
        public int ExcelExportSettingID { get; set; }

        [Column("FormButtonName")]
        [JsonProperty("FormButtonName")]
        [Required(ErrorMessageResourceName = "pub_RequiredField", ErrorMessageResourceType = typeof(Resources.Resources))]
        public string FormButtonName { get; set; }

        [Column("FileName")]
        [JsonProperty("FileName")]
        [Required(ErrorMessageResourceName = "pub_RequiredField", ErrorMessageResourceType = typeof(Resources.Resources))]
        public string FileName { get; set; }

        [Column("Path")]
        [JsonProperty("Path")]
        [Required(ErrorMessageResourceName = "pub_RequiredField", ErrorMessageResourceType = typeof(Resources.Resources))]
        [MaxLength(250)]
        public string Path { get; set; }

        [Column("ConcatDateTimeToFileName")]
        [JsonProperty("ConcatDateTimeToFileName")]
        [Required(ErrorMessageResourceName = "pub_RequiredField", ErrorMessageResourceType = typeof(Resources.Resources))]
        public bool ConcatDateTimeToFileName { get; set; }

        [Column("UserID")]
        [JsonProperty("UserID")]
        [Required(ErrorMessageResourceName = "pub_RequiredField", ErrorMessageResourceType = typeof(Resources.Resources))]
        public int UserID { get; set; }
        #endregion Base properties

        [NotMapped]
        [JsonProperty("ExcelExportSettingDetailList")]
        public List<ExcelExportSettingDetail> ExcelExportSettingDetailList { get; set; }

    }
}