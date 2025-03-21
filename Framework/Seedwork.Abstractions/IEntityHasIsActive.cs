using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Seedwork.Abstractions;

public interface IEntityHasIsActive
{

    /// <summary>
    /// Record is active?
    /// </summary>
    [Column("IsActive")]
    [JsonProperty("IsActive")]
    [Required(ErrorMessageResourceName = "pub_RequiredField", ErrorMessageResourceType = typeof(Resources.Resources))]
    bool IsActive { get; }
}
