using PPC.Core.Models;
using System;

namespace PPC.Core.Repository
{
    [ServiceMapTo(typeof(RepositoryFactory))]
    public class RepositoryFactory : IRepositoryFactory
    {
        private PPCDbContext _context;

        public RepositoryFactory(PPCDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context)); 
        }

        public BaseRepository<SysAuditData> SysAuditData => new BaseRepository<SysAuditData>(_context);
        public BaseRepository<SysUserAccount> SysUserAccounts => new BaseRepository<SysUserAccount>(_context);
        public BaseRepository<SysRole> SysRoles => new BaseRepository<SysRole>(_context);
        public BaseRepository<SysUserRole> SysUserRoles => new BaseRepository<SysUserRole>(_context);
        public BaseRepository<SysUserToken> SysUserTokens => new BaseRepository<SysUserToken>(_context);
        public BaseRepository<Users> Users => new BaseRepository<Users>(_context);
        public BaseRepository<Units> Units => new BaseRepository<Units>(_context);
        public BaseRepository<Provinces> Provinces => new BaseRepository<Provinces>(_context);
        public BaseRepository<Domain> Domain => new BaseRepository<Domain>(_context);
        public BaseRepository<Countries> Countries => new BaseRepository<Countries>(_context);
        public BaseRepository<Settings> Settings => new BaseRepository<Settings>(_context);
        public BaseRepository<SettingUpdates> SettingUpdates => new BaseRepository<SettingUpdates>(_context);
        public BaseRepository<SettingGenerals> SettingGenerals => new BaseRepository<SettingGenerals>(_context);
        public BaseRepository<MenuAccessStates> MenuAccessStates => new BaseRepository<MenuAccessStates>(_context);
        public BaseRepository<DenyAccesses> DenyAccesses => new BaseRepository<DenyAccesses>(_context);
        public BaseRepository<LoginLogs> LoginLogs => new BaseRepository<LoginLogs>(_context);
        public BaseRepository<Logs> Logs => new BaseRepository<Logs>(_context);
        public BaseRepository<AutoCompleteField> AutoCompleteField => new BaseRepository<AutoCompleteField>(_context);
        public BaseRepository<ExcelExportSetting> ExcelExportSetting => new BaseRepository<ExcelExportSetting>(_context);
        public BaseRepository<ExcelExportSettingDetail> ExcelExportSettingDetail => new BaseRepository<ExcelExportSettingDetail>(_context);
        //public BaseRepository<>  => new BaseRepository<>(_context);  
        //public BaseRepository<>  => new BaseRepository<>(_context);  
        //public BaseRepository<>  => new BaseRepository<>(_context);  
        //public BaseRepository<>  => new BaseRepository<>(_context);  
        //public BaseRepository<>  => new BaseRepository<>(_context);  
        public BaseRepository<Test> Test => new BaseRepository<Test>(_context);


    }
}
