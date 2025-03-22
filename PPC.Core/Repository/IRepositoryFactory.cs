using PPC.Core.Models;

namespace PPC.Core.Repository
{
    public interface IRepositoryFactory
    {
        BaseRepository<SysAuditData> SysAuditData { get; }
        BaseRepository<SysUserAccount> SysUserAccounts { get; }

        BaseRepository<SysRole> SysRoles { get; }
        BaseRepository<SysUserRole> SysUserRoles { get; }
        BaseRepository<SysUserToken> SysUserTokens { get; }

    }
}