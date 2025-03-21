using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Seedwork.Abstractions;

public interface IEntityHasTitle
{
    /// <summary>
    /// عنوان
    /// <summary>
    [Column("Title")]
    [JsonProperty("Title")]
    [Required(ErrorMessageResourceName = "pub_RequiredField", ErrorMessageResourceType = typeof(Resources.Resources))]
    string Title { get; }
}
