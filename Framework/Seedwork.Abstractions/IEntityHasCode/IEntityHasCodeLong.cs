using System.ComponentModel.DataAnnotations;

namespace Seedwork.Abstractions;

public interface IEntityHasCodeLong
{
    long Code { get; }
}
