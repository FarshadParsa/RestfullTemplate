using Microsoft.EntityFrameworkCore;
using PPC.Core.Models;

namespace PPC.Core
{
    public class PPCDbContext : DbContext
    {
        public PPCDbContext()
        {

        }

        public PPCDbContext(DbContextOptions<PPCDbContext> options)
           : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            optionsBuilder.UseDatabase();

            //optionsBuilder.UseLazyLoadingProxies(); // فعال کردن Lazy Loading
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

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

            //modelBuilder.Entity<CardInvDetails>(entity =>
            //{
            //    entity.HasKey(e => new { e.InvTypeID, e.Year, e.RawMaterialID, e.EntryDate, e.EntryTime });
            //});
            modelBuilder.Entity<CardInv>(entity =>
            {
                entity.HasKey(e => new { e.InvTypeID, e.Year, e.RawMaterialID });
            });

            #region Relationships

            #region Palet => RevertPalets

            ///Palet
            modelBuilder.Entity<Palets>()
               .HasMany(a => a.RevertPaletsList)
               .WithOne(b => b.Palet)
               .HasForeignKey(b => b.PaletID);

            #endregion

            #region palet => RevertNewPaletsList

            //new palet
            modelBuilder.Entity<Palets>()
               .HasMany(a => a.RevertNewPaletsList)
               .WithOne(b => b.NewPalet)
               .HasForeignKey(b => b.NewPaletID);

            #endregion





            #endregion


        }


        public virtual DbSet<SysUserAccount> SysUserAccounts { get; set; }
        public virtual DbSet<SysRole> SysRoles { get; set; }
        public virtual DbSet<SysUserRole> SysUserRoles { get; set; }
        public virtual DbSet<SysUserToken> SysUserTokens { get; set; }
        public virtual DbSet<SysAuditData> SysAuditData { get; set; }
        public virtual DbSet<Users> Users { get; set; }
        public virtual DbSet<Stations> Stations { get; set; }
        public virtual DbSet<StationTypes> StationTypes { get; set; }
        public virtual DbSet<Units> Unit { get; set; }
        public virtual DbSet<RawMaterialGroups> RawMaterialGroups { get; set; }
        public virtual DbSet<Provinces> Provinces { get; set; }
        public virtual DbSet<Customers> Customers { get; set; }
        public virtual DbSet<Domain> Domain { get; set; }
        public virtual DbSet<CustomerGrades> CustomerGrades { get; set; }
        public virtual DbSet<SaleAgents> SaleAgents { get; set; }
        public virtual DbSet<PrintingTechniques> PrintingTechniques { get; set; }
        public virtual DbSet<ProductGroupTypes> ProductGroupTypes { get; set; }
        public virtual DbSet<ProductGroups> ProductGroups { get; set; }
        public virtual DbSet<ProductTypes> ProductTypes { get; set; }
        public virtual DbSet<ProductSeries> ProductSeries { get; set; }
        public virtual DbSet<Products> Products { get; set; }
        public virtual DbSet<ProductSerieTechniqueAssigns> ProductSerieTechniqueAssigns { get; set; }
        public virtual DbSet<RawMaterialGroupTypes> RawMaterialGroupTypes { get; set; }
        public virtual DbSet<RawMaterials> RawMaterials { get; set; }
        public virtual DbSet<Suppliers> Suppliers { get; set; }
        public virtual DbSet<TestPlanGroups> TestPlanGroups { get; set; }
        public virtual DbSet<TestPlanIndexes> TestPlanIndexes { get; set; }
        public virtual DbSet<Countries> Countries { get; set; }
        public virtual DbSet<Instructions> Instructions { get; set; }
        public virtual DbSet<TestPlans> TestPlans { get; set; }
        public virtual DbSet<TestPlanDetails> TestPlanDetails { get; set; }
        public virtual DbSet<TestPlanGroupTypeAssigns> TestPlanGroupTypeAssigns { get; set; }
        public virtual DbSet<Settings> Settings { get; set; }
        public virtual DbSet<SettingUpdates> SettingUpdates { get; set; }
        public virtual DbSet<SettingGenerals> SettingGenerals { get; set; }
        public virtual DbSet<MenuAccessStates> MenuAccessStates { get; set; }
        public virtual DbSet<DenyAccesses> DenyAccesses { get; set; }
        public virtual DbSet<LoginLogs> LoginLogs { get; set; }
        public virtual DbSet<Logs> Logs { get; set; }
        public virtual DbSet<UserGroups> UserGroups { get; set; }
        public virtual DbSet<UserGroupStations> UserGroupStations { get; set; }
        public virtual DbSet<UserGroupAssigns> UserGroupAssigns { get; set; }
        public virtual DbSet<PackagingPlans> PackagingPlans { get; set; }
        public virtual DbSet<Orders> Orders { get; set; }
        public virtual DbSet<OrderDetails> OrderDetails { get; set; }
        public virtual DbSet<DensityOfProducts> DensityOfProducts { get; set; }
        public virtual DbSet<RawMaterialLotNumbers> RawMaterialLotNumbers { get; set; }
        public virtual DbSet<TestPlanAssign> TestPlanAssign { get; set; }
        public virtual DbSet<TestPlanAssignDetail> TestPlanAssignDetail { get; set; }
        public virtual DbSet<PackagingTypes> PackagingTypes { get; set; }
        public virtual DbSet<InvRawMaterials> InvRawMaterials { get; set; }
        public virtual DbSet<InvRawMaterialLots> InvRawMaterialLots { get; set; }
        public virtual DbSet<TestPlanCodeChar> TestPlanCodeChar { get; set; }
        public virtual DbSet<OrderDetailPackagings> OrderDetailPackagings { get; set; }
        public virtual DbSet<AutoCompleteField> AutoCompleteField { get; set; }
        public virtual DbSet<TestPlanBasicIndex> TestPlanBasicIndex { get; set; }
        public virtual DbSet<RMWhiteLists> RMWhiteLists { get; set; }
        public virtual DbSet<RawMaterialWhiteListAssign> RawMaterialWhiteListAssign { get; set; }
        public virtual DbSet<RawMaterialConfirmation> RawMaterialConfirmation { get; set; }
        public virtual DbSet<BOM> BOM { get; set; }
        public virtual DbSet<BOMDetail> BOMDetail { get; set; }
        public virtual DbSet<BOMComplementary> BOMComplementary { get; set; }
        public virtual DbSet<CustomerDossier> CustomerDossier { get; set; }
        public virtual DbSet<CustomerDossierBOMs> CustomerDossierBOMs { get; set; }
        public virtual DbSet<ProductionPlanPatilsCapacity> ProductionPlanPatilsCapacity { get; set; }
        public virtual DbSet<ProductionPlanPackaging> ProductionPlanPackaging { get; set; }
        public virtual DbSet<ProductionPlans> ProductionPlans { get; set; }
        public virtual DbSet<ProductionPlanPatils> ProductionPlanPatils { get; set; }
        public virtual DbSet<DeliveryRawMaterialToProduction> DeliveryRawMaterialToProduction { get; set; }
        public virtual DbSet<DeliveryRawMaterialToProductionDetail> DeliveryRawMaterialToProductionDetail { get; set; }
        public virtual DbSet<DeliveryRawMaterialToProductionPatils> DeliveryRawMaterialToProductionPatils { get; set; }
        public virtual DbSet<RawMaterialsDeliveredToProduction> RawMaterialsDeliveredToProduction { get; set; }
        public virtual DbSet<RawMaterialsDeliveredToProductionDetail> RawMaterialsDeliveredToProductionDetail { get; set; }
        public virtual DbSet<DataProduction> DataProduction { get; set; }
        public virtual DbSet<DataGrindingDetail> DataGrindingDetail { get; set; }
        public virtual DbSet<DataDosingDetail> DataDosingDetail { get; set; }
        public virtual DbSet<Patils> Patils { get; set; }
        public virtual DbSet<WeightingProducts> WeightingProducts { get; set; }
        public virtual DbSet<WeightingProductDetail> WeightingProductDetail { get; set; }
        public virtual DbSet<InvProducts> InvProducts { get; set; }
        public virtual DbSet<Label> Label { get; set; }
        public virtual DbSet<Palets> Palets { get; set; }
        public virtual DbSet<PaletDetail> PaletDetail { get; set; }
        public virtual DbSet<CustomerDrafts> CustomerDrafts { get; set; }
        public virtual DbSet<CustomerDraftPalets> CustomerDraftPalets { get; set; }
        public virtual DbSet<OrderBOMRevisions> OrderBOMRevisions { get; set; }
        public virtual DbSet<ProductionPlanBOMDetail> ProductionPlanBOMDetail { get; set; }
        public virtual DbSet<ProductionPlanBOMDetailRevised> ProductionPlanBOMDetailRevised { get; set; }
        public virtual DbSet<ExcelExportSetting> ExcelExportSetting { get; set; }
        public virtual DbSet<ExcelExportSettingDetail> ExcelExportSettingDetail { get; set; }
        public virtual DbSet<InvTypes> InvTypes { get; set; }
        public virtual DbSet<CardInvDetails> CardInvDetails { get; set; }
        public virtual DbSet<CardTypes> CardTypes { get; set; }
        public virtual DbSet<InvProductionRawMaterials> InvProductionRawMaterials { get; set; }
        public virtual DbSet<CardInv> CardInv { get; set; }
        public virtual DbSet<RawMaterialLotsInventory> RawMaterialLotsInventory { get; set; }
        public virtual DbSet<ProductionPlanReworks> ProductionPlanReworks { get; set; }
        public virtual DbSet<ProductionPlanReworkDetails> ProductionPlanReworkDetails { get; set; }
        public virtual DbSet<Reverts> Reverts { get; set; }
        public virtual DbSet<RevertPalets> RevertPalets { get; set; }
        public virtual DbSet<RevertProducts> RevertProducts { get; set; }
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

    }
}















