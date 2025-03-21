using Newtonsoft.Json;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Seedwork.Abstractions;

public interface IEntityHasInsertUserIdGuid
{

    /// <summary>
    /// Inserted user Id
    /// </summary>
    System.Guid InsertUserId { get; }
    //void Create();
}

public interface IEntityHasInsertUserIdShort
{

    /// <summary>
    /// Inserted user Id
    /// </summary>
    System.Int16 InsertUserId { get; }

}

public interface IEntityHasInsertUserIdInt
{

    /// <summary>
    /// Inserted user Id
    /// </summary>
    System.Int32 InsertUserId { get; }

}

public interface IEntityHasInsertUserIdLong
{

    /// <summary>
    /// Inserted user Id
    /// </summary>
    System.Int64 InsertUserId { get; }

}
