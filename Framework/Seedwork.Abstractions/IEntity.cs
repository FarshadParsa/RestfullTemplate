using Newtonsoft.Json;
using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Seedwork.Abstractions;

public interface IEntityGuid
{
    /// <summary>
    /// ID(key)
    /// </summary>
    [Key]
    [Column("Id")]
    [JsonProperty("Id")]
    [Required(ErrorMessageResourceName = "pub_RequiredField", ErrorMessageResourceType = typeof(Resources.Resources))]
    Guid Id { get; }
}

public interface IEntityLong
{
    /// <summary>
    /// ID(key)
    /// </summary>
    [Key]
    [Column("Id")]
    [JsonProperty("Id")]
    [Required(ErrorMessageResourceName = "pub_RequiredField", ErrorMessageResourceType = typeof(Resources.Resources))]
    long Id { get; }
}

public interface IEntityInt
{
    /// <summary>
    /// ID(key)
    /// </summary>
    [Key]
    [Column("Id")]
    [JsonProperty("Id")]
    [Required(ErrorMessageResourceName = "pub_RequiredField", ErrorMessageResourceType = typeof(Resources.Resources))]
    int Id { get; }
}

public interface IEntityShort
{
    /// <summary>
    /// ID(key)
    /// </summary>
    [Key]
    [Column("Id")]
    [JsonProperty("Id")]
    [Required(ErrorMessageResourceName = "pub_RequiredField", ErrorMessageResourceType = typeof(Resources.Resources))]
    short Id { get; }
}

public interface IEntityByte
{
    /// <summary>
    /// ID(key)
    /// </summary>
    [Key]
    [Column("Id")]
    [JsonProperty("Id")]
    [Required(ErrorMessageResourceName = "pub_RequiredField", ErrorMessageResourceType = typeof(Resources.Resources))]
    byte Id { get; }
}

