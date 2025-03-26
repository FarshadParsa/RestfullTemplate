using Microsoft.EntityFrameworkCore;
using WebApi.Core.Models;

namespace WebApi.Core
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext()
        {

        }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
           : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            optionsBuilder.UseDatabase();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            #region SysUserRole Configuration

            modelBuilder.Entity<SysUserRole>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.RoleId });
                entity.HasIndex(e => e.UserId);
                entity.HasIndex(e => e.RoleId);
                entity.Property(e => e.UserId);
                entity.Property(e => e.RoleId);
                entity.HasOne(d => d.SysRole).WithMany(p => p.UserRoles).HasForeignKey(d => d.RoleId);
                entity.HasOne(d => d.SysUserAccount).WithMany(p => p.UserRoles).HasForeignKey(d => d.UserId);
            });

            #endregion
          

            #region Relationships




            #endregion


        }

        #region DbSet


        public virtual DbSet<SysUserAccount> SysUserAccounts { get; set; }
        public virtual DbSet<SysRole> SysRoles { get; set; }
        public virtual DbSet<SysUserRole> SysUserRoles { get; set; }
        public virtual DbSet<SysUserToken> SysUserTokens { get; set; }
        public virtual DbSet<SysAuditData> SysAuditData { get; set; }
        public virtual DbSet<Users> Users { get; set; }
        public virtual DbSet<Units> Unit { get; set; }
        public virtual DbSet<Provinces> Provinces { get; set; }
        public virtual DbSet<Domain> Domain { get; set; }
        public virtual DbSet<Countries> Countries { get; set; }
        public virtual DbSet<Settings> Settings { get; set; }
        public virtual DbSet<SettingUpdates> SettingUpdates { get; set; }
        public virtual DbSet<SettingGenerals> SettingGenerals { get; set; }
        public virtual DbSet<MenuAccessStates> MenuAccessStates { get; set; }
        public virtual DbSet<DenyAccesses> DenyAccesses { get; set; }
        public virtual DbSet<LoginLogs> LoginLogs { get; set; }
        public virtual DbSet<Logs> Logs { get; set; }
        public virtual DbSet<AutoCompleteField> AutoCompleteField { get; set; }
        public virtual DbSet<ExcelExportSetting> ExcelExportSetting { get; set; }
        public virtual DbSet<ExcelExportSettingDetail> ExcelExportSettingDetail { get; set; }
        //public virtual DbSet<>  { get; set; }
        //public virtual DbSet<>  { get; set; }
        //public virtual DbSet<>  { get; set; }
        //public virtual DbSet<>  { get; set; }
        //public virtual DbSet<>  { get; set; }
        //public virtual DbSet<>  { get; set; }
        //public virtual DbSet<>  { get; set; }
        //public virtual DbSet<>  { get; set; }
        //public virtual DbSet<>  { get; set; }
        //public virtual DbSet<>  { get; set; }
        //public virtual DbSet<>  { get; set; }
        //public virtual DbSet<>  { get; set; }
        //public virtual DbSet<>  { get; set; }
        //public virtual DbSet<>  { get; set; }
        //public virtual DbSet<>  { get; set; }

        #endregion



    }
}


