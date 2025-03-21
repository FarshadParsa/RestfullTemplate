using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Seedwork.Abstractions;

public interface IEntityHasStatus
{
    /// <summary>
    /// Level
    /// </summary>
    [Column("Status")]
    byte Status { get; }

}
