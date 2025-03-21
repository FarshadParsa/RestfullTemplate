using System;

namespace Seedwork.Abstractions;

public interface IEntityHasIsSynced
{
	bool IsSynced { get; }

	DateTimeOffset? SyncDateTime { get; }

	void Sync();
}
