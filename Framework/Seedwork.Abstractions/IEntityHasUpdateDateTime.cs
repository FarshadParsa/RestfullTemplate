using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Seedwork.Abstractions;

public interface IEntityHasUpdateDateTime
{

    /// <summary>
    /// Record update dateTime
    /// </summary>
    [Column("UpdateDateTime")]
    [JsonProperty("UpdateDateTime")]
    [Required(ErrorMessageResourceName = "pub_RequiredField", ErrorMessageResourceType = typeof(Resources.Resources))]
    System.DateTime UpdateDateTime { get; }

    //void Update();
}
