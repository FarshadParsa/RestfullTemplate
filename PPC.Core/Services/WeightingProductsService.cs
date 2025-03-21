using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Threading.Tasks;
using AtlasCellData.ADO;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.VisualBasic;
using PPC.Common;
//using PPC.Common;
using PPC.Core.Interface;
using PPC.Core.Models;
using PPC.Core.Repository;
namespace PPC.Core.Services
{
    //[ObsoleteAttribute]

    public partial class WeightingProductsService : BaseService, IWeightingProductsService
    {
        //IUnitOfWork _unitOfWork;
        //public WeightingProductsService()
        //{
        //}

        public WeightingProductsService(RepositoryFactory repositoryFactory,
            IUnitOfWork unitOfWork)
        {
            _repositoryFactory = repositoryFactory;
            _unitOfWork = unitOfWork;
        }


        public List<WeightingProducts> GetAll()
        {
            try
            {
                var weightingProducts = _repositoryFactory.WeightingProducts.Table.ToList();

                return weightingProducts;
            }
            catch
            {
                throw;
            }
        }

        public async Task<List<WeightingProducts>> GetAllAsync(string startDate, string endDate)
        {
            try
            {
                var weightingProducts = await _repositoryFactory.WeightingProducts.Table
                    .Where(x => (string.Compare(x.InsDate, startDate) >= 0 && string.Compare(x.InsDate, endDate) <= 0))
                    .Include(x => x.ProductionPlanPatil)
                    .Include(x => x.ProductionPlanPatil).ThenInclude(x => x.ProductionPlan).ThenInclude(x => x.OrderDetail).ThenInclude(x => x.Product)
                    .Include(x => x.User_InsUser)
                    .Include(x => x.User_EditUser)
                    .Include(x => x.WeightingProductDetailList).ThenInclude(x => x.PackagingType)
                    .Include(x => x.WeightingProductDetailList).ThenInclude(x => x.InvProductList)
                    .Include(x => x.InvProduct).ThenInclude(x => x.DataProduction).ThenInclude(x => x.ProductionPlanPatil).ThenInclude(x => x.ProductionPlan).ThenInclude(x => x.OrderDetail).ThenInclude(x => x.Product)
                    //.Include(x => x.WeightingProductDetailList).ThenInclude(x => x.InvProduct)
                    .ToListAsync();

                //weightingProducts.ForEach(x=>x.WeightingProductDetailList.)

                return weightingProducts;
            }
            catch (System.Exception ex)
            {
                throw;
            }
        }

        public WeightingProducts GetWeightingProductsById(int weightingProductID)
        {
            try
            {
                var weightingProducts = _repositoryFactory.WeightingProducts.Table
                    //.Include(x => x.WeightingProductDetailList).ThenInclude(x => x.PackagingPlan)
                    .Include(x => x.WeightingProductDetailList).ThenInclude(x => x.PackagingType)
                    .FirstOrDefault(x => x.WeightingProductID == weightingProductID);

                return weightingProducts;
            }
            catch
            {
                throw;
            }
        }

        public async Task<WeightingProducts> GetWeightingProductsByIdAsync(int weightingProductID)
        {
            try
            {
                var weightingProducts = await _repositoryFactory.WeightingProducts.Table
                    //.Include(x => x.WeightingProductDetailList).ThenInclude(x => x.PackagingPlan)
                    .Include(x => x.WeightingProductDetailList).ThenInclude(x => x.PackagingType)
                    .FirstOrDefaultAsync(x => x.WeightingProductID == weightingProductID);

                return weightingProducts;
            }
            catch
            {
                throw;
            }
        }

        public int Append(WeightingProducts weightingProducts)
        {
            using (var t = _unitOfWork.StartTransaction())
            {
                try
                {
                    bool status = true;
                    short groupRawId = 1;

                    var productId = int.MinValue;
                    ProductionPlans productionPlans = null;
                    if (weightingProducts.ProductionPlanPatilID != null)
                    {
                        productionPlans = _repositoryFactory.ProductionPlanPatils.Table
                        .Include(x => x.ProductionPlan).ThenInclude(x => x.OrderDetail)
                        .FirstOrDefault(x => x.ProductionPlanPatilID == weightingProducts.ProductionPlanPatilID).ProductionPlan;

                        productId = productionPlans.OrderDetail.ProductID;
                    }
                    else
                    {
                        productId = _repositoryFactory.InvProducts
                        .FirstOrDefault(x => x.InvProductID == weightingProducts.InvProductID).ProductID;

                    }

                    var newBarCode = GetInvProductLastCode();
                    var firstPartCode = newBarCode.FirstPartCode;
                    var counter = newBarCode.Counter;
                    weightingProducts.WeightingProductDetailList.ForEach(x =>
                    {
                        WeightingProductDetail WeightingProductDetail;
                        DataProduction dataProduction = null;
                        InvProducts prvInvProduct = null;

                        List<InvProducts> newInvProductList = new List<InvProducts>();

                        #region production weighting


                        if (weightingProducts.ProductionPlanPatilID != null && weightingProducts.ProductionPlanPatilID > 0)
                        {
                            dataProduction = _repositoryFactory.DataProduction.Table
                            .Include(x => x.ProductionPlanPatil).ThenInclude(x => x.ProductionPlan)
                            .FirstOrDefault(x => x.ProductionPlanPatilID == weightingProducts.ProductionPlanPatilID)
                            ;

                            #region Append new invProduct

                            var invStatus = productionPlans == null || (!productionPlans.TransferToInvRM && !productionPlans.TransferToWarehouse)
                            ? (byte)InvProductStatus.Weighted
                            : productionPlans.TransferToInvRM ? (byte)InvProductStatus.TransferToInvRM : (byte)InvProductStatus.TransferToWarehouse;

                            for (int i = 0; i < x.QTY; i++)
                            {
                                var newInvProduct = new InvProducts()
                                {
                                    InvProductCode = $"{firstPartCode}{(++counter).ToString("000")}",
                                    DataProductionID = dataProduction.DataProductionID,
                                    ProductID = productId,
                                    Weight = x.EmptyWeight + x.NetWeight,
                                    NetWeight = x.NetWeight,
                                    EntryDate = General.CurrentDateString,
                                    ProducedDate = weightingProducts.StartDate,
                                    ExpireDate = "1402/00/00",
                                    ShelfLife = "1402/00/00",
                                    EnProducedDate = (new PersianLibrary.PersianCalendar()).ToDateTime(weightingProducts.StartDate).ToString("yyyy/MM/dd"),
                                    EnExpireDate = "2023/00/00",
                                    EnShelfLife = "2023/00/00",
                                    PackagingPlanID = x.PackagingPlanID,
                                    SupplierID = null,
                                    Remark = null,
                                    Status = invStatus,
                                    QcStatus = (byte)QcStatus.Normal,
                                    ParentID = null,
                                    InsUserID = weightingProducts.InsUserID,
                                    InsDate = weightingProducts.InsDate,
                                    InsTime = weightingProducts.InsTime,
                                    EditUserID = weightingProducts.EditUserID,
                                    EditDate = weightingProducts.EditDate,
                                    EditTime = weightingProducts.EditTime,
                                };

                                _repositoryFactory.InvProducts.Add(newInvProduct);

                                status &= _unitOfWork.Commit() > 0;

                                newInvProductList.Add(newInvProduct);

                                #endregion

                                #region TransferToInvRM

                                //var tmp1 = _repositoryFactory.Products.Table.FirstOrDefault(x => x.ProductID == productId);

                                if (invStatus == (byte)InvProductStatus.TransferToInvRM)
                                {
                                    var rawMaterialID = (int)_repositoryFactory.Products.Table.FirstOrDefault(x => x.ProductID == productId).Final_RawMaterialID;

                                    var _newInvRawMaterial = new InvRawMaterials
                                    {
                                        InvRawMaterialID = 0,//invRawMaterials.InvRawMaterialID,
                                        RawMaterialID = rawMaterialID,
                                        //LotNo = newInvProduct.InvProductCode,
                                        FinancialRequestNo = "0",
                                        InvProductID = newInvProduct.InvProductID,
                                        EntryDate = newInvProduct.EntryDate,
                                        //Weight = newInvProduct.Weight,
                                        //NetWeight = newInvProduct.NetWeight,
                                        //PalletQty = 1,
                                        //ProducedDate = newInvProduct.ProducedDate,
                                        //EnProducedDate = newInvProduct.EnProducedDate,
                                        //ExpireDate = newInvProduct.ExpireDate,
                                        //EnExpireDate = newInvProduct.EnExpireDate,
                                        //ShelfLife = newInvProduct.ShelfLife,
                                        //EnShelfLife = newInvProduct.EnShelfLife,
                                        //PackagingTypeID = newInvProduct.PackagingPlanID,
                                        SupplierID = null,
                                        Describe = "Atlas cellulose production(Planning....)",
                                        IsSample = false,
                                        Status = InvRawMaterialStatus.Saved,
                                        //QcStatus = (byte)QcStatus.Normal,
                                        InsUserID = newInvProduct.InsUserID,
                                        InsDate = newInvProduct.InsDate,
                                        InsTime = newInvProduct.InsTime,
                                        EditUserID = newInvProduct.EditUserID,
                                        EditDate = newInvProduct.EditDate,
                                        EditTime = newInvProduct.EditTime,
                                    };

                                    _repositoryFactory.InvRawMaterials.Add(_newInvRawMaterial);

                                    status &= _unitOfWork.Commit() > 0;

                                    #region Append into cardex

                                    CardInvDetailsService cardInvDetailsService = new CardInvDetailsService(_repositoryFactory, _unitOfWork);
                                    cardInvDetailsService.AppendCardInvDetails(_newInvRawMaterial, _newInvRawMaterial.InvRawMaterialID, groupRawId++);

                                    #endregion


                                    //درصورتی که ماده نیمه ساخته باشد
                                    //مطابق اینکه باید به انبار مواد منتقل شود یا انبار محصول
                                    //وضعیت در جدول انبار محصول تعیین میشود
                                    //و پس از ثبت باید در جدول
                                    //انبار مواد اولیه
                                    //InvRawMaterial
                                    //ثبت گردد و کلید انبار محصول نیز در آن ثبت شود


                                    //بخش قابل تامل این است که اگر مواد نیمه ساخته قابل فروش باشد
                                    //چگونه با نبار منتقل شود
                                    //درحالی که وزن شده و به انبار منتقل شده چگونه مجددا منتقل شود؟


                                    // تست برنامه انجام شود


                                }

                                #endregion

                                #region TransferToInvRM

                                else if (invStatus == (byte)InvProductStatus.TransferToWarehouse)
                                {
                                    //برای انبار محصول نیز انجام شود
                                }

                                #endregion
                            }

                        }
                        #endregion

                        #region Inv product weighting

                        else if (weightingProducts.InvProductID != null && weightingProducts.InvProductID > 0)
                        {
                            prvInvProduct = _repositoryFactory.InvProducts.Table.AsNoTracking().FirstOrDefault(x => x.InvProductID == weightingProducts.InvProductID);

                            #region Append new invProduct

                            for (int i = 0; i < x.QTY; i++)
                            {

                                newInvProductList.Add(new InvProducts()
                                {
                                    //InvProductCode = GetInvProductNewCode(prvInvProduct.InvProductCode.Substring(0,6)),
                                    InvProductCode = $"{firstPartCode}{(++counter).ToString("000")}",
                                    DataProductionID = prvInvProduct.DataProductionID,
                                    ProductID = prvInvProduct.ProductID,
                                    //WeightingProductDetailID = x.WeightingProductDetailID,
                                    Weight = x.EmptyWeight + x.NetWeight,
                                    NetWeight = x.NetWeight,
                                    EntryDate = General.CurrentDateString,
                                    ProducedDate = prvInvProduct.ProducedDate,
                                    ExpireDate = prvInvProduct.ExpireDate,
                                    ShelfLife = prvInvProduct.ShelfLife,
                                    EnProducedDate = prvInvProduct.EnProducedDate,
                                    EnExpireDate = prvInvProduct.EnExpireDate,
                                    EnShelfLife = prvInvProduct.EnShelfLife,
                                    PackagingPlanID = x.PackagingPlanID,
                                    SupplierID = prvInvProduct.SupplierID,
                                    Remark = prvInvProduct.Remark,
                                    Status = (byte)InvProductStatus.Weighted,
                                    QcStatus = (byte)QcStatus.Normal,
                                    ParentID = null,
                                    InsUserID = weightingProducts.InsUserID,
                                    InsDate = weightingProducts.InsDate,
                                    InsTime = weightingProducts.InsTime,
                                    EditUserID = weightingProducts.EditUserID,
                                    EditDate = weightingProducts.EditDate,
                                    EditTime = weightingProducts.EditTime,
                                });
                            }

                            #endregion


                        }

                        #endregion

                        x.InvProductList = newInvProductList;

                    });

                    var _newObject = new WeightingProducts
                    {
                        WeightingProductID = weightingProducts.WeightingProductID,
                        ProductionPlanPatilID = weightingProducts.ProductionPlanPatilID,
                        InvProductID = weightingProducts.InvProductID,
                        StartDate = weightingProducts.StartDate,
                        StartTime = weightingProducts.StartTime,
                        EndDate = weightingProducts.EndDate,
                        EndTime = weightingProducts.EndTime,
                        EntryWeight = weightingProducts.EntryWeight,
                        PackagedWeight = weightingProducts.PackagedWeight,
                        Waste = weightingProducts.Waste,
                        InsUserID = weightingProducts.InsUserID,
                        InsDate = weightingProducts.InsDate,
                        InsTime = weightingProducts.InsTime,
                        EditUserID = weightingProducts.EditUserID,
                        EditDate = weightingProducts.EditDate,
                        EditTime = weightingProducts.EditTime,

                        WeightingProductDetailList = weightingProducts.WeightingProductDetailList,

                    };

                    _repositoryFactory.WeightingProducts.Add(_newObject);

                    status &= _unitOfWork.Commit() > 0;

                    t.Commit();

                    if (status)
                        return _newObject.WeightingProductID;
                    else
                        return int.MinValue;
                }
                catch (System.Exception)
                {
                    t.Rollback();
                    throw;
                }
            }
        }


        public bool Update(WeightingProducts weightingProducts)
        {

            throw new System.Exception("بعلت وجود باگ امکان بروز رسانی وجود ندارد");

            using (var t = _unitOfWork.StartTransaction())
            {


                try
                {
                    var status = true;


                    var weightingProductDetails = _repositoryFactory.WeightingProductDetail
                        .Where(x => x.WeightingProductID == weightingProducts.WeightingProductID).AsNoTracking().ToList();

                    var invProducts = _repositoryFactory.InvProducts.Where(i => weightingProductDetails.Select(w => w.WeightingProductDetailID).Contains((int)i.WeightingProductDetailID))
                        .AsNoTracking().ToList();

                    #region Delete records

                    #region DELETE InvRawMaterial by InvProductId

                    ////
                    ///مواد اولیه که از توزین ارسال شده باید خذف شوند
                    ///

                    var invRM = _repositoryFactory.InvRawMaterials.Where(x => invProducts.Select(p => p.InvProductID).Contains((int)x.InvProductID)).AsNoTracking().ToList();

                    _repositoryFactory.InvRawMaterialLots.DeleteBy(x => invRM.Select(p => p.InvRawMaterialID).Contains((int)x.InvRawMaterialID));
                    _repositoryFactory.InvRawMaterials.DeleteBy(x => invProducts.Select(p => p.InvProductID).Contains((int)x.InvProductID));

                    #endregion


                    #region Delete InvProduct records

                    invProducts.ForEach(invProduct =>
                    {
                        _repositoryFactory.InvProducts.Delete(invProduct);

                    });

                    #endregion

                    #region Delete WeightingProductDetail records

                    weightingProductDetails.ForEach(x =>
                    _repositoryFactory.WeightingProductDetail.Delete(x));

                    ////
                    ///Clear ID key for new insert
                    ///
                    weightingProducts.WeightingProductDetailList.ForEach(x => x.WeightingProductDetailID = 0);

                    #endregion

                    #region Delete Kardex related recordes

                    var invRMs = _repositoryFactory.InvRawMaterials.Where(x => invProducts.Select(x => x.InvProductID).Contains((int)x.InvProductID)).AsNoTracking().ToList();

                    CardInvDetailsService cardInvDetailsService = new CardInvDetailsService(_repositoryFactory, _unitOfWork);
                    status &= cardInvDetailsService.DeleteCardInvDetailsByInvRawMaterials(invRMs);

                    #endregion Delete Kardex

                    #endregion

                    #region update WeightingProducts


                    _repositoryFactory.WeightingProducts.UpdateBy(x => x.WeightingProductID == weightingProducts.WeightingProductID,
                        new WeightingProducts
                        {
                            WeightingProductID = weightingProducts.WeightingProductID,
                            ProductionPlanPatilID = weightingProducts.ProductionPlanPatilID,
                            InvProductID = weightingProducts.InvProductID,
                            StartDate = weightingProducts.StartDate,
                            StartTime = weightingProducts.StartTime,
                            EndDate = weightingProducts.EndDate,
                            EndTime = weightingProducts.EndTime,
                            EntryWeight = weightingProducts.EntryWeight,
                            PackagedWeight = weightingProducts.PackagedWeight,
                            Waste = weightingProducts.Waste,
                            InsUserID = weightingProducts.InsUserID,
                            InsDate = weightingProducts.InsDate,
                            InsTime = weightingProducts.InsTime,
                            EditUserID = weightingProducts.EditUserID,
                            EditDate = weightingProducts.EditDate,
                            EditTime = weightingProducts.EditTime,
                            WeightingProductDetailList = weightingProducts.WeightingProductDetailList,
                        });


                    #endregion

                    //status &= _unitOfWork.Commit() > 0;


                    short groupRawId = 1;

                    var productId = int.MinValue;
                    ProductionPlans productionPlans = null;
                    if (weightingProducts.ProductionPlanPatilID != null)
                    {
                        productionPlans = _repositoryFactory.ProductionPlanPatils.Table
                        .Include(x => x.ProductionPlan).ThenInclude(x => x.OrderDetail)
                        .FirstOrDefault(x => x.ProductionPlanPatilID == weightingProducts.ProductionPlanPatilID).ProductionPlan;

                        productId = productionPlans.OrderDetail.ProductID;
                    }
                    else
                    {
                        productId = _repositoryFactory.InvProducts
                        .FirstOrDefault(x => x.InvProductID == weightingProducts.InvProductID).ProductID;

                    }

                    //status &= _unitOfWork.Commit() > 0;

                    var newBarCode = GetInvProductLastCode();
                    var firstPartCode = newBarCode.FirstPartCode;
                    var counter = newBarCode.Counter;
                    weightingProducts.WeightingProductDetailList.ForEach(weightingProduc =>
                    {
                        WeightingProductDetail WeightingProductDetail;
                        DataProduction dataProduction = null;
                        InvProducts prvInvProduct = null;

                        List<InvProducts> newInvProductList = new List<InvProducts>();

                        #region production weighting

                        if (weightingProducts.ProductionPlanPatilID != null && weightingProducts.ProductionPlanPatilID > 0)
                        {
                            dataProduction = _repositoryFactory.DataProduction.Table
                            .Include(x => x.ProductionPlanPatil).ThenInclude(x => x.ProductionPlan)
                            .FirstOrDefault(x => x.ProductionPlanPatilID == weightingProducts.ProductionPlanPatilID)
                            ;

                            #region Append new invProduct

                            var invStatus = productionPlans == null || (!productionPlans.TransferToInvRM && !productionPlans.TransferToWarehouse)
                            ? (byte)InvProductStatus.Weighted
                            : productionPlans.TransferToInvRM ? (byte)InvProductStatus.TransferToInvRM : (byte)InvProductStatus.TransferToWarehouse;


                            for (int i = 0; i < weightingProduc.QTY; i++)
                            {
                                var newInvProduct = new InvProducts()
                                {
                                    InvProductCode = $"{firstPartCode}{(++counter).ToString("000")}",
                                    DataProductionID = dataProduction.DataProductionID,
                                    WeightingProductDetailID = null,// weightingProduc.WeightingProductDetailID,
                                    ProductID = productId,
                                    Weight = weightingProduc.EmptyWeight + weightingProduc.NetWeight,
                                    NetWeight = weightingProduc.NetWeight,
                                    EntryDate = General.CurrentDateString,
                                    ProducedDate = weightingProducts.StartDate,
                                    ExpireDate = "1402/00/00",
                                    ShelfLife = "1402/00/00",
                                    EnProducedDate = (new PersianLibrary.PersianCalendar()).ToDateTime(weightingProducts.StartDate).ToString("yyyy/MM/dd"),
                                    EnExpireDate = "2023/00/00",
                                    EnShelfLife = "2023/00/00",
                                    PackagingPlanID = weightingProduc.PackagingPlanID,
                                    SupplierID = null,
                                    Remark = null,
                                    Status = invStatus,
                                    QcStatus = (byte)QcStatus.Normal,
                                    ParentID = null,
                                    InsUserID = weightingProducts.InsUserID,
                                    InsDate = weightingProducts.InsDate,
                                    InsTime = weightingProducts.InsTime,
                                    EditUserID = weightingProducts.EditUserID,
                                    EditDate = weightingProducts.EditDate,
                                    EditTime = weightingProducts.EditTime,
                                };

                                _repositoryFactory.InvProducts.Add(newInvProduct);

                                status &= _unitOfWork.Commit() > 0;

                                //throw new System.Exception("QQQQQQQQQQQQQQQQQ");
                                newInvProductList.Add(newInvProduct);


                                #region TransferToInvRM


                                var rawMaterialID = (int)_repositoryFactory.Products.Table.FirstOrDefault(x => x.ProductID == productId).Final_RawMaterialID;

                                if (invStatus == (byte)InvProductStatus.TransferToInvRM)
                                {
                                    var _newInvRawMaterial = new InvRawMaterials
                                    {
                                        InvRawMaterialID = 0,//invRawMaterials.InvRawMaterialID,
                                        RawMaterialID = rawMaterialID,
                                        //LotNo = newInvProduct.InvProductCode,
                                        FinancialRequestNo = "0",
                                        InvProductID = newInvProduct.InvProductID,
                                        EntryDate = newInvProduct.EntryDate,
                                        //Weight = newInvProduct.Weight,
                                        //NetWeight = newInvProduct.NetWeight,
                                        //PalletQty = 1,
                                        //ProducedDate = newInvProduct.ProducedDate,
                                        //EnProducedDate = newInvProduct.EnProducedDate,
                                        //ExpireDate = newInvProduct.ExpireDate,
                                        //EnExpireDate = newInvProduct.EnExpireDate,
                                        //ShelfLife = newInvProduct.ShelfLife,
                                        //EnShelfLife = newInvProduct.EnShelfLife,
                                        //PackagingTypeID = newInvProduct.PackagingPlanID,
                                        SupplierID = null,
                                        Describe = "Atlas cellulose production(Planning....)",
                                        IsSample = false,
                                        Status = InvRawMaterialStatus.Saved,
                                        //QcStatus = (byte)QcStatus.Normal,
                                        InsUserID = newInvProduct.InsUserID,
                                        InsDate = newInvProduct.InsDate,
                                        InsTime = newInvProduct.InsTime,
                                        EditUserID = newInvProduct.EditUserID,
                                        EditDate = newInvProduct.EditDate,
                                        EditTime = newInvProduct.EditTime,
                                    };

                                    _repositoryFactory.InvRawMaterials.Add(_newInvRawMaterial);

                                    status &= _unitOfWork.Commit() > 0;

                                    #region Append into cardex

                                    CardInvDetailsService cardInvDetailsService = new CardInvDetailsService(_repositoryFactory, _unitOfWork);
                                    cardInvDetailsService.AppendCardInvDetails(_newInvRawMaterial, _newInvRawMaterial.InvRawMaterialID, groupRawId++);

                                    #endregion


                                    //درصورتی که ماده نیمه ساخته باشد
                                    //مطابق اینکه باید به انبار مواد منتقل شود یا انبار محصول
                                    //وضعیت در جدول انبار محصول تعیین میشود
                                    //و پس از ثبت باید در جدول
                                    //انبار مواد اولیه
                                    //InvRawMaterial
                                    //ثبت گردد و کلید انبار محصول نیز در آن ثبت شود


                                    //بخش قابل تامل این است که اگر مواد نیمه ساخته قابل فروش باشد
                                    //چگونه با نبار منتقل شود
                                    //درحالی که وزن شده و به انبار منتقل شده چگونه مجددا منتقل شود؟


                                    // تست برنامه انجام شود


                                }

                                #endregion

                                #region TransferToInvRM

                                else if (invStatus == (byte)InvProductStatus.TransferToWarehouse)
                                {
                                    //برای انبار محصول نیز انجام شود
                                }

                                #endregion
                            }

                            #endregion

                        }
                        #endregion

                        #region Inv product weighting

                        else if (weightingProducts.InvProductID != null && weightingProducts.InvProductID > 0)
                        {
                            prvInvProduct = _repositoryFactory.InvProducts.Table.AsNoTracking().FirstOrDefault(x => x.InvProductID == weightingProducts.InvProductID);

                            #region Append new invProduct

                            for (int i = 0; i < weightingProduc.QTY; i++)
                            {

                                var _newInvProducts = new InvProducts()
                                {
                                    //InvProductCode = GetInvProductNewCode(prvInvProduct.InvProductCode.Substring(0,6)),
                                    InvProductCode = $"{firstPartCode}{(++counter).ToString("000")}",
                                    DataProductionID = prvInvProduct.DataProductionID,
                                    ProductID = prvInvProduct.ProductID,
                                    //WeightingProductDetailID = x.WeightingProductDetailID,
                                    Weight = weightingProduc.EmptyWeight + weightingProduc.NetWeight,
                                    NetWeight = weightingProduc.NetWeight,
                                    EntryDate = General.CurrentDateString,
                                    ProducedDate = prvInvProduct.ProducedDate,
                                    ExpireDate = prvInvProduct.ExpireDate,
                                    ShelfLife = prvInvProduct.ShelfLife,
                                    EnProducedDate = prvInvProduct.EnProducedDate,
                                    EnExpireDate = prvInvProduct.EnExpireDate,
                                    EnShelfLife = prvInvProduct.EnShelfLife,
                                    PackagingPlanID = weightingProduc.PackagingPlanID,
                                    SupplierID = prvInvProduct.SupplierID,
                                    Remark = prvInvProduct.Remark,
                                    Status = (byte)InvProductStatus.Weighted,
                                    QcStatus = (byte)QcStatus.Normal,
                                    ParentID = null,
                                    InsUserID = weightingProducts.InsUserID,
                                    InsDate = weightingProducts.InsDate,
                                    InsTime = weightingProducts.InsTime,
                                    EditUserID = weightingProducts.EditUserID,
                                    EditDate = weightingProducts.EditDate,
                                    EditTime = weightingProducts.EditTime,
                                };

                                _repositoryFactory.InvProducts.Add(_newInvProducts);

                                newInvProductList.Add(_newInvProducts);
                            }

                            status &= _unitOfWork.Commit() > 0;

                            #endregion


                        }

                        #endregion



                        weightingProduc.InvProductList = newInvProductList;

                    });







                    #region Update InvProduct



                    //با بررسی ها مشخص شود که آیا
                    //    جدول
                    //    InvProduct
                    //بروز رسانی 

                    //    شود یا خیر
                    //    ؟

                    //    پس از آن 
                    //    بروز رسانی کاردکس نیز انجام شود






                    #endregion Update InvProduct


                    #region Update Kardex

                    //CardInvDetailsService cardInvDetailsService = new CardInvDetailsService(_repositoryFactory, _unitOfWork);
                    //cardInvDetailsService.UpdateCardInvDetails(invRawMaterials);

                    #endregion Update Kardex



                    t.Commit();
                    return status;
                }
                catch (System.Exception ex)
                {
                    t.Rollback();
                    throw ex;
                }
            }
        }

        public long Delete(int weightingProductID)
        {
            using (var t = _unitOfWork.StartTransaction())
            {


                try
                {

                    var status = true;
                    var weightingProducts = _repositoryFactory.WeightingProducts.Table
                        //.Include(x => x.WeightingProductDetailList)//.ThenInclude(x=>x.InvProductLis)
                        .Include(x => x.WeightingProductDetailList).ThenInclude(x => x.InvProductList)
                        .FirstOrDefault(x => x.WeightingProductID == weightingProductID);

                    //var detailList = weightingProducts.WeightingProductDetailList;

                    if (weightingProducts == null)
                        throw new System.Exception("WeightingProducts Notfound.");

                    var invProducts = _repositoryFactory.InvProducts.Where(x => weightingProducts.WeightingProductDetailList.Select(x => x.WeightingProductDetailID).Contains((int)x.WeightingProductDetailID)).ToList();
                    _repositoryFactory.InvProducts.DeleteBy(x => weightingProducts.WeightingProductDetailList.Select(x => x.WeightingProductDetailID).ToList().Contains((int)x.WeightingProductDetailID));

                    var invRMs = _repositoryFactory.InvRawMaterials.Where(x => invProducts.Select(x => x.InvProductID).Contains((int)x.InvProductID)).ToList();
                    _repositoryFactory.WeightingProducts.Delete(weightingProducts);
                    //var statuse = _unitOfWork.Commit();

                    #region Delete Kardex

                    CardInvDetailsService cardInvDetailsService = new CardInvDetailsService(_repositoryFactory, _unitOfWork);
                    status &= cardInvDetailsService.DeleteCardInvDetailsByInvRawMaterials(invRMs);

                    #endregion Delete Kardex

                    //var statuse = _unitOfWork.Commit();

                    if (status)
                        t.Commit();
                    else
                        t.Rollback();

                    return invProducts.Count;
                }
                catch
                {
                    t.Rollback();
                    throw;
                }
            }
        }

        public async Task<List<WeightingProducts>> GetListByProductionPlanPatilIdAsync(int productionPlanPatilId)
        {
            try
            {

                var weightingProducts = await _repositoryFactory.WeightingProducts
                    .Where(x => x.ProductionPlanPatilID == productionPlanPatilId)
                    .ToListAsync();

                return weightingProducts;
            }
            catch (System.Exception ex)
            {
                throw;
            }
        }


    }
}