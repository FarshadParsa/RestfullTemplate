using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Seedwork.Abstractions;

public interface IEntityHasDescription
{
    /// <summary>
    /// Description
    /// </summary>
    [Column("Description")]
    [JsonProperty("Description")]
    string? Description { get; }
}
