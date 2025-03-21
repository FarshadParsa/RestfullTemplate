using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Seedwork.Abstractions;

public interface IEntityHasCodeString
{
    /// <summary>
    /// Property Code
    /// </summary>
    [Column("Code")]
    [JsonProperty("Code")]
    [Required(ErrorMessageResourceName = "pub_RequiredField", ErrorMessageResourceType = typeof(Resources.Resources))]
    String Code { get; }
}
