using PPC.Base.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using PPC.Common;
using PPC.Core.Interface;
using PPC.Core.Models;
using PPC.Core.Repository;
using PPC.Core.Extensions;

namespace PPC.Core.Services
{
    public class InvRawMaterialsService : BaseService, IInvRawMaterialsService
    {

        private readonly PPCDbContext _context;

        IUnitOfWork _unitOfWork;
        public InvRawMaterialsService(RepositoryFactory repositoryFactory,
            IUnitOfWork unitOfWork,
            PPCDbContext context)
        {
            _repositoryFactory = repositoryFactory;
            _unitOfWork = unitOfWork;
            _context = context;
        }


        public List<InvRawMaterials> GetAll()
        {
            try
            {
                var invRawMaterials = _repositoryFactory.InvRawMaterials.Table
                    .Include(x => x.RawMaterial)
                    .ThenInclude(x => x.Units)
                    .Include(x => x.RawMaterial)
                    .ThenInclude(x => x.RawMaterialGroups)
                    .ToList();

                return invRawMaterials;
            }
            catch
            {
                throw;
            }
        }

        public async Task<List<InvRawMaterials>> GetListAsync(Expression<Func<InvRawMaterials, object>>[] includes)
        {
            try
            {
                var query = _repositoryFactory.InvRawMaterials.Table;

                foreach (var include in includes)
                {
                    query  = query.Include(include);
                }

                return await query.ToListAsync();

                //var invRawMaterials = await _repositoryFactory.InvRawMaterials.Table
                //    .Include(x => x.RawMaterial).ThenInclude(x => x.Units)
                //    .Include(x => x.RawMaterial).ThenInclude(x => x.RawMaterialGroups)
                //    .ToListAsync();
                //return invRawMaterials;
            }
            catch (System.Exception ex)
            {
                throw;
            }
        }

        public InvRawMaterials GetInvRawMaterialsById(int invRawMaterialID)
        {
            try
            {
                var invRawMaterials = _repositoryFactory.InvRawMaterials.Table
                    .Include(x => x.RawMaterial).ThenInclude(x => x.Units)
                    .Include(x => x.RawMaterial).ThenInclude(x => x.RawMaterialGroups)
                    .FirstOrDefault(x => x.InvRawMaterialID == invRawMaterialID);

                return invRawMaterials;
            }
            catch
            {
                throw;
            }
        }

        public async Task<InvRawMaterials> GetInvRawMaterialsByIdAsync(int invRawMaterialID)
        {
            try
            {
                var invRawMaterials = await _repositoryFactory.InvRawMaterials.Table
                    .Include(x => x.RawMaterial).ThenInclude(x => x.Units)
                    .Include(x => x.RawMaterial).ThenInclude(x => x.RawMaterialGroups)
                    .FirstOrDefaultAsync(x => x.InvRawMaterialID == invRawMaterialID);

                return invRawMaterials;
            }
            catch
            {
                throw;
            }
        }


        public async Task<InvRawMaterials> GetInvRawMaterialsByIdAsync(int invRawMaterialID, params Expression<Func<InvRawMaterials, object>>[] includes)
        {
            try
            {

                var query = _repositoryFactory.InvRawMaterials.Table.AsNoTracking();

                foreach (var include in includes)
                {
                    query = query.Include(include);
                }

                var invRawMaterials = await query.FirstOrDefaultAsync(e => e.InvRawMaterialID == invRawMaterialID);

                return invRawMaterials;

            }
            catch
            {
                throw;
            }
        }


        public int Append(InvRawMaterials invRawMaterials)
        {

            using (var tr = _unitOfWork.StartTransaction())
            {

                try
                {
                    #region Append InvRawMaterial

                    var _newObject = new InvRawMaterials
                    {
                        InvRawMaterialID = invRawMaterials.InvRawMaterialID,
                        RawMaterialID = invRawMaterials.RawMaterialID,
                        FinancialRequestNo = invRawMaterials.FinancialRequestNo,
                        InvProductID = invRawMaterials.InvProductID,
                        EntryDate = invRawMaterials.EntryDate,
                        Describe = invRawMaterials.Describe,
                        IsSample = invRawMaterials.IsSample,
                        Status = invRawMaterials.Status,
                        InsUserID = invRawMaterials.InsUserID,
                        InsDate = invRawMaterials.InsDate,
                        InsTime = invRawMaterials.InsTime,
                        EditUserID = invRawMaterials.EditUserID,
                        EditDate = invRawMaterials.EditDate,
                        EditTime = invRawMaterials.EditTime,
                        InvRawMaterialLotsList = invRawMaterials.InvRawMaterialLotsList,
                    };

                    _repositoryFactory.InvRawMaterials.Add(_newObject);
                    var statuse = _unitOfWork.Commit() > 0;

                    #endregion

                    #region  (Cardex) ==> Append CardInvDetail - وارده به انبار مواد
                    if (statuse)
                    {
                        #region Append into cardex

                        CardInvDetailsService cardInvDetailsService = new CardInvDetailsService(_repositoryFactory, _unitOfWork);
                        cardInvDetailsService.AppendCardInvDetails(invRawMaterials, _newObject.InvRawMaterialID);

                        #endregion Append into cardex


                        //CardInvDetails cardInvDetails = new CardInvDetails();

                        //cardInvDetails.InvTypeID = 'R';
                        //cardInvDetails.Year = General.Year;
                        //cardInvDetails.RawMaterialID = invRawMaterials.RawMaterialID;
                        //cardInvDetails.EntryDate = invRawMaterials.EntryDate;
                        //cardInvDetails.EntryTime = invRawMaterials.EditTime;
                        //cardInvDetails.Amount = invRawMaterials.NetWeight;
                        //cardInvDetails.CardTypeVal = '$';
                        //cardInvDetails.IsEntry = true;
                        //cardInvDetails.InsDate = invRawMaterials.InsDate;
                        //cardInvDetails.InsTime = invRawMaterials.InsTime;
                        //cardInvDetails.InsUserID = invRawMaterials.InsUserID;
                        //cardInvDetails.InvRawMaterialID = _newObject.InvRawMaterialID;
                        //cardInvDetails.RawMaterialsDeliveredToProductionDetailID = null;
                        //cardInvDetails.InvProductionRawMaterialID = null;
                        //cardInvDetails.DataDosingDetailID = null;

                        //CardInvDetailsService cardInvDetailsService = new CardInvDetailsService(_repositoryFactory, _unitOfWork);
                        //cardInvDetailsService.Append(cardInvDetails);

                        ////throw new System.Exception("QQ");

                        //statuse &= _unitOfWork.Commit() > 0;

                    }
                    #endregion

                    tr.Commit();
                    if (statuse)
                        return _newObject.InvRawMaterialID;
                    else
                        return int.MinValue;
                }
                catch (System.Exception)
                {
                    tr.Rollback();
                    throw;
                }
            }
        }


        public async Task<bool> Update(InvRawMaterials invRawMaterials)
        {
            using (var tr = _unitOfWork.StartTransaction())
            {
                try
                {

                    #region حذف رکورد های قدیم درصورت خالی بودن لیست ارسال نشده

                    // گام 1: حذف تمام رکوردهای موجود اگر لیست جدید خالی باشد

                    if (invRawMaterials.InvRawMaterialLotsList == null || !invRawMaterials.InvRawMaterialLotsList.Any())
                    {
                        // حذف تمام رکوردهای موجود اگر لیست جدید خالی باشد
                        _repositoryFactory.InvRawMaterialLots.DeleteBy(x => x.InvRawMaterialID == invRawMaterials.InvRawMaterialID);
                    }

                    #endregion


                    //گام 2: بازیابی موجودیت موجود
                    var existingEntity = await GetInvRawMaterialsByIdAsync(invRawMaterials.InvRawMaterialID,
                        new List<Expression<Func<InvRawMaterials, object>>>
                        {
                           x=> x.InvRawMaterialLotsList
                        }.ToArray()
                    );

                    if (existingEntity == null)
                        return false;

                    #region حذف رکورد های تغییر یافته و افزودن رکورد های جدید

                    //گام 3: حذف رکورد هایی که از سمت کلاینت حذف شده اند
                    #region Delete

                    if (existingEntity.InvRawMaterialLotsList != null && existingEntity.InvRawMaterialLotsList.Any())
                    {
                        var oldList = existingEntity.InvRawMaterialLotsList;
                        var newList = invRawMaterials.InvRawMaterialLotsList;

                        (List<InvRawMaterialLots> deletableDifference, List<InvRawMaterialLots> newDifference) =
                            oldList.GetListDifferences(newList,
                            (item1, item2) => item1.InvRawMaterialLotID == item2.InvRawMaterialLotID);

                        if (deletableDifference != null && deletableDifference.Any())
                        {
                            _repositoryFactory.InvRawMaterialLots.DeleteBy(x => deletableDifference.Select(x => x.InvRawMaterialLotID).Contains(x.InvRawMaterialLotID));
                        }

                    }

                    #endregion


                    #region Append

                    foreach (var newItem in invRawMaterials.InvRawMaterialLotsList)
                    {

                        //// بررسی اینکه آیا موجودیت قبلاً ردیابی میشود
                        //var existingItem = _repositoryFactory.InvRawMaterialLots.Table.Local.FirstOrDefault(x => x.InvRawMaterialLotID == newItem.InvRawMaterialLotID);

                        //if (existingItem != null)
                        //{
                        //    // اگر موجودیت ردیابی میشود، آن را از کانتکست جدا کنید
                        //    _context.Entry(existingItem).State = EntityState.Detached;
                        //}
                        //throw new System.Exception("QQQQQQQQQQQQQ");

                        if (newItem.InvRawMaterialLotID == 0)
                        {
                            ////append

                            newItem.RawMaterial = null;
                            newItem.InvRawMaterialID = invRawMaterials.InvRawMaterialID; // تنظیم Foreign Key
                            _repositoryFactory.InvRawMaterialLots.Add(newItem);
                        }
                        else
                        {
                            ///updtate

                            _repositoryFactory.InvRawMaterialLots.UpdateBy(x => x.InvRawMaterialLotID == newItem.InvRawMaterialLotID,
                                new InvRawMaterialLots
                                {
                                    InvRawMaterialLotID = newItem.InvRawMaterialLotID,
                                    InvRawMaterialID = newItem.InvRawMaterialID,
                                    LotNo = newItem.LotNo,
                                    IsGenerated = newItem.IsGenerated,
                                    ProducedDate = newItem.ProducedDate,
                                    EnProducedDate = newItem.EnProducedDate,
                                    ExpireDate = newItem.ExpireDate,
                                    EnExpireDate = newItem.EnExpireDate,
                                    ShelfLife = newItem.ShelfLife,
                                    EnShelfLife = newItem.EnShelfLife,
                                    SolidPercentage = newItem.SolidPercentage,
                                    QcStatus = newItem.QcStatus,
                                    RNDStatus = newItem.RNDStatus,
                                    Weight = newItem.Weight,
                                    NetWeight = newItem.NetWeight,
                                    Describe = newItem.Describe,
                                    PalletQty = newItem.PalletQty,
                                    PackagingTypeID = newItem.PackagingTypeID,
                                    RawMaterialID = newItem.RawMaterialID,
                                });

                        }
                    }

                    #endregion

                    //var status1 = _unitOfWork.Commit() > 0;

                    #endregion


                    #region تنظیم مقادیر جدید و بروز رسانی

                    existingEntity.InvRawMaterialID = invRawMaterials.InvRawMaterialID;
                    existingEntity.RawMaterialID = invRawMaterials.RawMaterialID;
                    existingEntity.FinancialRequestNo = invRawMaterials.FinancialRequestNo;
                    existingEntity.InvProductID = invRawMaterials.InvProductID;
                    existingEntity.EntryDate = invRawMaterials.EntryDate;
                    existingEntity.SupplierID = invRawMaterials.SupplierID;
                    existingEntity.Describe = invRawMaterials.Describe;
                    existingEntity.IsSample = invRawMaterials.IsSample;
                    existingEntity.Status = invRawMaterials.Status;
                    existingEntity.InsUserID = invRawMaterials.InsUserID;
                    existingEntity.InsDate = invRawMaterials.InsDate;
                    existingEntity.InsTime = invRawMaterials.InsTime;
                    existingEntity.EditUserID = invRawMaterials.EditUserID;
                    existingEntity.EditDate = invRawMaterials.EditDate;
                    existingEntity.EditTime = invRawMaterials.EditTime;

                    _repositoryFactory.InvRawMaterials.Update(existingEntity);

                    #endregion


                    // گام ۴: ذخیره تغییرات
                    var status = _unitOfWork.Commit() > 0;
                    tr.Commit();

                    return status;

                }
                catch (System.Exception)
                {
                    tr.Rollback();
                    throw;
                }
            }
        }

        //public bool Update(InvRawMaterials invRawMaterials)
        //{
        //    using (var tr = _unitOfWork.StartTransaction())
        //    {

        //        try
        //        {

        //            _repositoryFactory.InvRawMaterials.UpdateBy(x => x.InvRawMaterialID == invRawMaterials.InvRawMaterialID,
        //                new InvRawMaterials
        //                {
        //                    InvRawMaterialID = invRawMaterials.InvRawMaterialID,
        //                    RawMaterialID = invRawMaterials.RawMaterialID,
        //                    FinancialRequestNo = invRawMaterials.FinancialRequestNo,
        //                    InvProductID = invRawMaterials.InvProductID,
        //                    EntryDate = invRawMaterials.EntryDate,
        //                    SupplierID = invRawMaterials.SupplierID,
        //                    Describe = invRawMaterials.Describe,
        //                    IsSample = invRawMaterials.IsSample,
        //                    Status = invRawMaterials.Status,
        //                    InsUserID = invRawMaterials.InsUserID,
        //                    InsDate = invRawMaterials.InsDate,
        //                    InsTime = invRawMaterials.InsTime,
        //                    EditUserID = invRawMaterials.EditUserID,
        //                    EditDate = invRawMaterials.EditDate,
        //                    EditTime = invRawMaterials.EditTime,
        //                    InvRawMaterialLotsList = invRawMaterials.InvRawMaterialLotsList,
        //                });

        //            _repositoryFactory.InvRawMaterialLots.DeleteBy(x => x.InvRawMaterialID == invRawMaterials.InvRawMaterialID);


        //            var statuse = _unitOfWork.Commit() > 0;

        //            #region Update Kardex

        //            CardInvDetailsService cardInvDetailsService = new CardInvDetailsService(_repositoryFactory, _unitOfWork);
        //            cardInvDetailsService.UpdateCardInvDetails(invRawMaterials);

        //            //var cardInvDetails = _repositoryFactory.CardInvDetails.Table
        //            //    .FirstOrDefault(x => x.InvRawMaterialID == invRawMaterials.InvRawMaterialID);

        //            //if (cardInvDetails != null)
        //            //{
        //            //    cardInvDetails.Amount = invRawMaterials.NetWeight;

        //            //    CardInvDetailsService detail = new CardInvDetailsService(_repositoryFactory, _unitOfWork);
        //            //    statuse &= detail.Update(cardInvDetails);
        //            //}

        //            #endregion

        //            tr.Commit();
        //            return statuse;
        //        }
        //        catch (System.Exception ex)
        //        {
        //            tr.Rollback();
        //            throw ex;
        //        }
        //    }
        //}


        public long Delete(int invRawMaterialID)
        {
            using (var tr = _unitOfWork.StartTransaction())
            {
                try
                {
                    var invRawMaterials = _repositoryFactory.InvRawMaterials.Table
                        .Include(x=>x.InvRawMaterialLotsList)
                        .FirstOrDefault(x => x.InvRawMaterialID == invRawMaterialID);

                    if (invRawMaterials == null)
                        throw new System.Exception("InvRawMaterials Notfound.");

                    _repositoryFactory.InvRawMaterialLots.DeleteBy(x => x.InvRawMaterialID == invRawMaterialID);
                    _repositoryFactory.InvRawMaterials.Delete(invRawMaterials);
                    long statuse = _unitOfWork.Commit();


                    #region Remove from Kardex

                    var cardInvDetails = _repositoryFactory.CardInvDetails.Table
                        .FirstOrDefault(x => x.InvRawMaterialID == invRawMaterialID);

                    if (cardInvDetails != null)
                    {
                        CardInvDetailsService detail = new CardInvDetailsService(_repositoryFactory, _unitOfWork);
                        statuse += detail.DeleteByInvRawMaterialID(invRawMaterialID);
                    }

                    #endregion

                    tr.Commit();
                    return statuse;
                }
                catch
                {
                    tr.Rollback();
                    throw;
                }
            }
        }

        public async Task<InvRawMaterials> GetInvRawMaterialByFinancialRequestNoAsync(string financialRequestNo)
        {
            try
            {

                return await _repositoryFactory.InvRawMaterials.Table
                    .Include(x => x.RawMaterial)
                    .Include(x => x.Supplier)
                    //.Include(x => x.PackagingType)
                    .FirstOrDefaultAsync(x => x.FinancialRequestNo == financialRequestNo);
            }
            catch
            {
                throw;
            }
        }

        public async Task<InvRawMaterials> GetInvRawMaterialWithLotsByIdAsync(int invRawMaterialID)
        {
            try
            {
                var invRawMaterials = await _repositoryFactory.InvRawMaterials.Table
                    .Include(x => x.RawMaterial).ThenInclude(x => x.Units)
                    .Include(x => x.RawMaterial).ThenInclude(x => x.RawMaterialGroups)
                    .Include(x => x.InvRawMaterialLotsList)
                    .FirstOrDefaultAsync(x => x.InvRawMaterialID == invRawMaterialID);

                var lots = _repositoryFactory.InvRawMaterialLots.Where(x => x.InvRawMaterialID == invRawMaterialID);
                //invRawMaterials.LotNumbers = lots.ToDictionary(x => x.LotNo, x => x.IsGenerated);

                return invRawMaterials;
            }
            catch
            {
                throw;
            }
        }

        public async Task<List<InvRawMaterials>> GetListByDateAsync(
            string startDate,
            string endDate,
            Expression<Func<InvRawMaterials, object>>[] includes)
        {
            try
            {

                var query = _repositoryFactory.InvRawMaterials.Table
            .Where(x => string.Compare(x.EntryDate, startDate) >= 0 && string.Compare(x.EntryDate, endDate) <= 0);

                // اعمال Includes اصلی
                foreach (var include in includes)
                {
                    query = query.Include(include);
                }

                var invRawMaterials = await query.ToListAsync();

                // Explicit Loading برای PackagingType در InvRawMaterialLots
                foreach (var item in invRawMaterials)
                {
                    foreach (var lot in item.InvRawMaterialLotsList)
                    {
                        await _context.Entry(lot)
                            .Reference(l => l.PackagingType) // لود PackagingType
                            .LoadAsync();
                    }
                }

                return invRawMaterials;


                //var query = _repositoryFactory.InvRawMaterials.Table
                //            .Where(x => string.Compare(x.EntryDate, startDate) >= 0 && string.Compare(x.EntryDate, endDate) <= 0);

                //foreach (var include in includes)
                //{
                //    query = query.IncludeMultiple(include);
                //}

                //var invRawMaterials = await query.ToListAsync();

                //// Explicit Loading برای روابط پیچیده
                //foreach (var item in invRawMaterials)
                //{
                //    await _context.Entry(item)
                //        .Collection(x => x.InvRawMaterialLotsList)
                //        .Query()
                //        .Include(lot => lot.RawMaterial)
                //        .ThenInclude(rawMaterial => rawMaterial.RawMaterialGroups)
                //        .LoadAsync();
                //}

                //return invRawMaterials;


                ////var query = _repositoryFactory.InvRawMaterials.Table
                ////    .Where(x => (string.Compare(x.EntryDate, startDate) >= 0 && string.Compare(x.EntryDate, endDate) <= 0))
                ////    ;

                ////foreach (var include in includes)
                ////{
                ////    query = query.Include(include);
                ////}

                ////return await query.ToListAsync();

                //////var invRawMaterials = await _repositoryFactory.InvRawMaterials.Table
                //////    .Include(x => x.RawMaterial).ThenInclude(x => x.Units)
                //////    .Include(x => x.RawMaterial).ThenInclude(x => x.RawMaterialGroups)
                //////    .ToListAsync();
                //////return invRawMaterials;
            }
            catch (System.Exception ex)
            {
                throw;
            }
        }



        //public async Task<InvRawMaterials> GetInstanceByPartOfLotNoAsync(string partlotNo)
        //{
        //    try
        //    {
        //        var maxLotNo = await _repositoryFactory.InvRawMaterials.Table
        //            .Where(x => x.LotNo.ToUpper().StartsWith(partlotNo.ToUpper()))
        //            .MaxAsync(x => x.LotNo);

        //        var q = await _repositoryFactory.InvRawMaterials.Table
        //            .FirstOrDefaultAsync(x => x.LotNo == maxLotNo);



        //        return q;
        //    }
        //    catch
        //    {
        //        throw;
        //    }
        //}

        //public async Task<List<InvRawMaterials>> GetListByGeneralLotNoAsync(string generalLotNo)
        //{
        //    try
        //    {
        //        var q = await _repositoryFactory.InvRawMaterials.Table
        //            .Where(x => x.LotNo.ToUpper() == generalLotNo.ToUpper())
        //            .ToListAsync();

        //        return q;
        //    }
        //    catch
        //    {
        //        throw;
        //    }
        //}

        //public async Task<List<string>> GetLotnumbersByRawMaterialIdAsync(int rawMaterialId)
        //{
        //    try
        //    {
        //        var lotNumbers = await _repositoryFactory.InvRawMaterials
        //            .Where(x => x.RawMaterialID == rawMaterialId).Select(x => x.LotNo).Distinct().ToListAsync();

        //        return lotNumbers;
        //    }
        //    catch
        //    {
        //        throw;
        //    }
        //}





    }
}
