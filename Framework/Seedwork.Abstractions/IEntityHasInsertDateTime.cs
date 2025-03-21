using Newtonsoft.Json;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Seedwork.Abstractions;

public interface IEntityHasInsertDateTime
{

    /// <summary>
    /// Record insert dateTime
    /// </summary>
    [Column("InsertDateTime")]
    [JsonProperty("InsertDateTime")]
    [Required(ErrorMessageResourceName = "pub_RequiredField", ErrorMessageResourceType = typeof(Resources.Resources))]
    DateTime InsertDateTime { get; }

	//void Create();
}
