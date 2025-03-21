using PPC.Core.Models;
using System;

namespace PPC.Core.Repository
{
    [ServiceMapTo(typeof(RepositoryFactory))]
    public class RepositoryFactory : IRepositoryFactory
    {
        private PPCDbContext _context;

        //public Microsoft.EntityFrameworkCore.Infrastructure.DatabaseFacade Database {
        //    get { 

        //        return _context.Database;
        //    }
        //    set

        //    {
        //        _context.Database = value;
        //    }
        //}

        public RepositoryFactory(PPCDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context)); 
            // _context.Entry<ProductionPlans>(ProductionPlans).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
        }

        public BaseRepository<SysAuditData> SysAuditData => new BaseRepository<SysAuditData>(_context);
        public BaseRepository<SysUserAccount> SysUserAccounts => new BaseRepository<SysUserAccount>(_context);
        public BaseRepository<SysRole> SysRoles => new BaseRepository<SysRole>(_context);
        public BaseRepository<SysUserRole> SysUserRoles => new BaseRepository<SysUserRole>(_context);
        public BaseRepository<SysUserToken> SysUserTokens => new BaseRepository<SysUserToken>(_context);
        public BaseRepository<Users> Users => new BaseRepository<Users>(_context);
        public BaseRepository<Stations> Stations => new BaseRepository<Stations>(_context);
        public BaseRepository<StationTypes> StationTypes => new BaseRepository<StationTypes>(_context);
        public BaseRepository<Units> Units => new BaseRepository<Units>(_context);
        public BaseRepository<RawMaterialGroups> RawMaterialGroups => new BaseRepository<RawMaterialGroups>(_context);
        public BaseRepository<Provinces> Provinces => new BaseRepository<Provinces>(_context);
        public BaseRepository<Customers> Customers => new BaseRepository<Customers>(_context);
        public BaseRepository<Domain> Domain => new BaseRepository<Domain>(_context);
        //public BaseRepository<SettingGeneral> SettingGeneral => new BaseRepository<SettingGeneral>(_context);  
        public BaseRepository<CustomerGrades> CustomerGrades => new BaseRepository<CustomerGrades>(_context);
        public BaseRepository<SaleAgents> SaleAgents => new BaseRepository<SaleAgents>(_context);
        public BaseRepository<PrintingTechniques> PrintingTechniques => new BaseRepository<PrintingTechniques>(_context);
        public BaseRepository<ProductGroupTypes> ProductGroupTypes => new BaseRepository<ProductGroupTypes>(_context);
        public BaseRepository<ProductGroups> ProductGroups => new BaseRepository<ProductGroups>(_context);
        public BaseRepository<ProductTypes> ProductTypes => new BaseRepository<ProductTypes>(_context);
        public BaseRepository<ProductSeries> ProductSeries => new BaseRepository<ProductSeries>(_context);
        public BaseRepository<Products> Products => new BaseRepository<Products>(_context);
        public BaseRepository<ProductSerieTechniqueAssigns> ProductSerieTechniqueAssigns => new BaseRepository<ProductSerieTechniqueAssigns>(_context);
        public BaseRepository<RawMaterialGroupTypes> RawMaterialGroupTypes => new BaseRepository<RawMaterialGroupTypes>(_context);
        public BaseRepository<RawMaterials> RawMaterials => new BaseRepository<RawMaterials>(_context);
        public BaseRepository<Suppliers> Suppliers => new BaseRepository<Suppliers>(_context);
        public BaseRepository<TestPlanGroups> TestPlanGroups => new BaseRepository<TestPlanGroups>(_context);
        public BaseRepository<TestPlanIndexes> TestPlanIndexes => new BaseRepository<TestPlanIndexes>(_context);
        public BaseRepository<Countries> Countries => new BaseRepository<Countries>(_context);
        public BaseRepository<Instructions> Instructions => new BaseRepository<Instructions>(_context);
        public BaseRepository<TestPlans> TestPlans => new BaseRepository<TestPlans>(_context);
        public BaseRepository<TestPlanDetails> TestPlanDetails => new BaseRepository<TestPlanDetails>(_context);
        public BaseRepository<TestPlanGroupTypeAssigns> TestPlanGroupTypeAssigns => new BaseRepository<TestPlanGroupTypeAssigns>(_context);
        public BaseRepository<Settings> Settings => new BaseRepository<Settings>(_context);
        public BaseRepository<SettingUpdates> SettingUpdates => new BaseRepository<SettingUpdates>(_context);
        public BaseRepository<SettingGenerals> SettingGenerals => new BaseRepository<SettingGenerals>(_context);
        public BaseRepository<MenuAccessStates> MenuAccessStates => new BaseRepository<MenuAccessStates>(_context);
        public BaseRepository<DenyAccesses> DenyAccesses => new BaseRepository<DenyAccesses>(_context);
        public BaseRepository<LoginLogs> LoginLogs => new BaseRepository<LoginLogs>(_context);
        public BaseRepository<Logs> Logs => new BaseRepository<Logs>(_context);
        public BaseRepository<UserGroups> UserGroups => new BaseRepository<UserGroups>(_context);
        public BaseRepository<UserGroupStations> UserGroupStations => new BaseRepository<UserGroupStations>(_context);
        public BaseRepository<UserGroupAssigns> UserGroupAssigns => new BaseRepository<UserGroupAssigns>(_context);
        public BaseRepository<PackagingPlans> PackagingPlans => new BaseRepository<PackagingPlans>(_context);
        public BaseRepository<Orders> Orders => new BaseRepository<Orders>(_context);
        public BaseRepository<OrderDetails> OrderDetails => new BaseRepository<OrderDetails>(_context);
        public BaseRepository<DensityOfProducts> DensityOfProducts => new BaseRepository<DensityOfProducts>(_context);
        public BaseRepository<RawMaterialLotNumbers> RawMaterialLotNumbers => new BaseRepository<RawMaterialLotNumbers>(_context);
        public BaseRepository<TestPlanAssign> TestPlanAssign => new BaseRepository<TestPlanAssign>(_context);
        public BaseRepository<TestPlanAssignDetail> TestPlanAssignDetail => new BaseRepository<TestPlanAssignDetail>(_context);
        public BaseRepository<PackagingTypes> PackagingTypes => new BaseRepository<PackagingTypes>(_context);
        public BaseRepository<InvRawMaterials> InvRawMaterials => new BaseRepository<InvRawMaterials>(_context);
        public BaseRepository<InvRawMaterialLots> InvRawMaterialLots => new BaseRepository<InvRawMaterialLots>(_context);
        public BaseRepository<TestPlanCodeChar> TestPlanCodeChar => new BaseRepository<TestPlanCodeChar>(_context);
        public BaseRepository<OrderDetailPackagings> OrderDetailPackagings => new BaseRepository<OrderDetailPackagings>(_context);
        public BaseRepository<AutoCompleteField> AutoCompleteField => new BaseRepository<AutoCompleteField>(_context);
        public BaseRepository<TestPlanBasicIndex> TestPlanBasicIndex => new BaseRepository<TestPlanBasicIndex>(_context);
        public BaseRepository<RMWhiteLists> RMWhiteLists => new BaseRepository<RMWhiteLists>(_context);
        public BaseRepository<RawMaterialWhiteListAssign> RawMaterialWhiteListAssign => new BaseRepository<RawMaterialWhiteListAssign>(_context);
        public BaseRepository<RawMaterialConfirmation> RawMaterialConfirmation => new BaseRepository<RawMaterialConfirmation>(_context);
        public BaseRepository<BOM> BOM => new BaseRepository<BOM>(_context);
        public BaseRepository<BOMDetail> BOMDetail => new BaseRepository<BOMDetail>(_context);
        public BaseRepository<BOMComplementary> BOMComplementary => new BaseRepository<BOMComplementary>(_context);
        public BaseRepository<CustomerDossier> CustomerDossier => new BaseRepository<CustomerDossier>(_context);
        public BaseRepository<CustomerDossierBOMs> CustomerDossierBOMs => new BaseRepository<CustomerDossierBOMs>(_context);
        public BaseRepository<ProductionPlanPatilsCapacity> ProductionPlanPatilsCapacity => new BaseRepository<ProductionPlanPatilsCapacity>(_context);
        public BaseRepository<ProductionPlanPackaging> ProductionPlanPackaging => new BaseRepository<ProductionPlanPackaging>(_context);
        public BaseRepository<ProductionPlans> ProductionPlans => new BaseRepository<ProductionPlans>(_context);
        public BaseRepository<ProductionPlanBOMDetail> ProductionPlanBOMDetail => new BaseRepository<ProductionPlanBOMDetail>(_context);
        public BaseRepository<ProductionPlanBOMDetailRevised> ProductionPlanBOMDetailRevised => new BaseRepository<ProductionPlanBOMDetailRevised>(_context);
        public BaseRepository<ProductionPlanPatils> ProductionPlanPatils => new BaseRepository<ProductionPlanPatils>(_context);
        public BaseRepository<DeliveryRawMaterialToProduction> DeliveryRawMaterialToProduction => new BaseRepository<DeliveryRawMaterialToProduction>(_context);
        public BaseRepository<DeliveryRawMaterialToProductionDetail> DeliveryRawMaterialToProductionDetail => new BaseRepository<DeliveryRawMaterialToProductionDetail>(_context);
        public BaseRepository<DeliveryRawMaterialToProductionPatils> DeliveryRawMaterialToProductionPatils => new BaseRepository<DeliveryRawMaterialToProductionPatils>(_context);
        public BaseRepository<RawMaterialsDeliveredToProduction> RawMaterialsDeliveredToProduction => new BaseRepository<RawMaterialsDeliveredToProduction>(_context);
        public BaseRepository<RawMaterialsDeliveredToProductionDetail> RawMaterialsDeliveredToProductionDetail => new BaseRepository<RawMaterialsDeliveredToProductionDetail>(_context);
        public BaseRepository<DataProduction> DataProduction => new BaseRepository<DataProduction>(_context);
        public BaseRepository<DataGrindingDetail> DataGrindingDetail => new BaseRepository<DataGrindingDetail>(_context);
        public BaseRepository<DataDosingDetail> DataDosingDetail => new BaseRepository<DataDosingDetail>(_context);
        public BaseRepository<Patils> Patils => new BaseRepository<Patils>(_context);
        public BaseRepository<WeightingProducts> WeightingProducts => new BaseRepository<WeightingProducts>(_context);
        public BaseRepository<WeightingProductDetail> WeightingProductDetail => new BaseRepository<WeightingProductDetail>(_context);
        public BaseRepository<InvProducts> InvProducts => new BaseRepository<InvProducts>(_context);
        public BaseRepository<Label> Label => new BaseRepository<Label>(_context);
        public BaseRepository<Palets> Palets => new BaseRepository<Palets>(_context);
        public BaseRepository<PaletDetail> PaletDetail => new BaseRepository<PaletDetail>(_context);
        public BaseRepository<CustomerDrafts> CustomerDrafts => new BaseRepository<CustomerDrafts>(_context);
        public BaseRepository<CustomerDraftPalets> CustomerDraftPalets => new BaseRepository<CustomerDraftPalets>(_context);
        public BaseRepository<OrderBOMRevisions> OrderBOMRevisions => new BaseRepository<OrderBOMRevisions>(_context);
        public BaseRepository<ExcelExportSetting> ExcelExportSetting => new BaseRepository<ExcelExportSetting>(_context);
        public BaseRepository<ExcelExportSettingDetail> ExcelExportSettingDetail => new BaseRepository<ExcelExportSettingDetail>(_context);
        public BaseRepository<InvTypes> InvTypes => new BaseRepository<InvTypes>(_context);
        public BaseRepository<CardInvDetails> CardInvDetails => new BaseRepository<CardInvDetails>(_context);
        public BaseRepository<CardTypes> CardTypes => new BaseRepository<CardTypes>(_context);
        public BaseRepository<InvProductionRawMaterials> InvProductionRawMaterials => new BaseRepository<InvProductionRawMaterials>(_context);
        public BaseRepository<CardInv> CardInv => new BaseRepository<CardInv>(_context);
        public BaseRepository<RawMaterialLotsInventory>  RawMaterialLotsInventory=> new BaseRepository<RawMaterialLotsInventory>(_context);  
        public BaseRepository<ProductionPlanReworks> ProductionPlanReworks => new BaseRepository<ProductionPlanReworks>(_context);  
        public BaseRepository<ProductionPlanReworkDetails> ProductionPlanReworkDetails => new BaseRepository<ProductionPlanReworkDetails>(_context);
        public BaseRepository<Reverts> Reverts => new BaseRepository<Reverts>(_context);  
        public BaseRepository<RevertPalets> RevertPalets => new BaseRepository<RevertPalets>(_context);  
        public BaseRepository<RevertProducts> RevertProducts => new BaseRepository<RevertProducts>(_context);  
        //public BaseRepository<>  => new BaseRepository<>(_context);  
        //public BaseRepository<>  => new BaseRepository<>(_context);  
        //public BaseRepository<>  => new BaseRepository<>(_context);  
        //public BaseRepository<>  => new BaseRepository<>(_context);  
        //public BaseRepository<>  => new BaseRepository<>(_context);  
        public BaseRepository<Test> Test => new BaseRepository<Test>(_context);


    }
}
