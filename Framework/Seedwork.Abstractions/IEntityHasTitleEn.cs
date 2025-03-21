using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Seedwork.Abstractions;

public interface IEntityHasTitleEn
{
    /// <summary>
    /// Propery English Name (Propery English Title)
    /// </summary>
    [Column("TitleEn")]
    [JsonProperty("TitleEn")]
    [Required(ErrorMessageResourceName = "pub_RequiredField", ErrorMessageResourceType = typeof(Resources.Resources))]
    string? TitleEn { get; }
}
