using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using WebApi.Core.Models.Entity;
using System.ComponentModel;
using Newtonsoft.Json;
using System;

namespace WebApi.Core.Models
{
    [Table("SettingGeneral")]
    public class SettingGenerals : IEntity
    {
        #region Base properties and methods(generated by  CodeGenerator)
        [Key]
        [Column("SettingGeneralID")]
        [JsonProperty("SettingGeneralID")]
        [Required(ErrorMessageResourceName = "RequiredField_Anot", ErrorMessageResourceType = typeof(Resources.Resources))]
        public int SettingGeneralID { get; set; }

        [Column("Version")]
        [JsonProperty("Version")]
        [Required(ErrorMessageResourceName = "RequiredField_Anot", ErrorMessageResourceType = typeof(Resources.Resources))]
        public string Version { get; set; }

        [Column("FactoryNameEn")]
        [JsonProperty("FactoryNameEn")]
        public string FactoryNameEn { get; set; }

        [Column("FactoryNameFa")]
        [JsonProperty("FactoryNameFa")]
        [MaxLength(50)]
        public string FactoryNameFa { get; set; }

        [Column("CalendarCultureInfo")]
        [JsonProperty("CalendarCultureInfo")]
        [MaxLength(5)]
        public string CalendarCultureInfo { get; set; }

        [Column("CurrencyDecimalSeparator")]
        [JsonProperty("CurrencyDecimalSeparator")]
        [MaxLength(1)]
        public string CurrencyDecimalSeparator { get; set; }

        [Column("ReportCustomerDraftFormCode")]
        [JsonProperty("ReportCustomerDraftFormCode")]
        [MaxLength(20)]
        public string ReportCustomerDraftFormCode { get; set; }

        [Column("LogOpeningForm")]
        [JsonProperty("LogOpeningForm")]
        public Nullable<bool> LogOpeningForm { get; set; }

        [Column("LogClosingForm")]
        [JsonProperty("LogClosingForm")]
        public Nullable<bool> LogClosingForm { get; set; }

        [Column("LogButtonsClick")]
        [JsonProperty("LogButtonsClick")]
        public Nullable<bool> LogButtonsClick { get; set; }

        [Column("FactoryCode")]
        [JsonProperty("FactoryCode")]
        [Required(ErrorMessageResourceName = "RequiredField_Anot", ErrorMessageResourceType = typeof(Resources.Resources))]
        public byte FactoryCode { get; set; }
        #endregion Base properties and methods(generated by  CodeGenerator)
    }
}