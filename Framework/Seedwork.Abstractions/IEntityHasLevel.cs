using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Seedwork.Abstractions;

public interface IEntityHasLevel
{
    /// <summary>
    /// Level
    /// </summary>
    [Column("Lvl")]
    short Level { get; }
}
