using Newtonsoft.Json;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Seedwork.Abstractions;

public interface IEntityHasUpdateUserIdGuid
{
    /// <summary>
    /// Update user Id
    /// </summary>
    System.Guid UpdateUserId { get; }
}

public interface IEntityHasUpdateUserIdShort
{
    /// <summary>
    /// Update user Id
    /// </summary>
    System.Int16 UpdateUserId { get; }
}

public interface IEntityHasUpdateUserIdInt
{
    /// <summary>
    /// Update user Id
    /// </summary>
    System.Int32 UpdateUserId { get; }
}

public interface IEntityHasUpdateUserIdLong
{
    /// <summary>
    /// Update user Id
    /// </summary>
    System.Int64 UpdateUserId { get; }
}
