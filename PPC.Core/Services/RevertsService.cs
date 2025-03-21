using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.Serialization.Formatters;
using System.Threading.Tasks;
using System.Transactions;
using Microsoft.EntityFrameworkCore;
using PPC.Base.Extensions;
using PPC.Base.Utility;
using PPC.Common;
using PPC.Core.Interface;
using PPC.Core.Models;
using PPC.Core.Repository;
namespace PPC.Core.Services
{
    public class RevertsService : BaseService, IRevertsService
    {
        //IUnitOfWork _unitOfWork;
        public RevertsService(RepositoryFactory repositoryFactory,
            IUnitOfWork unitOfWork)
        {
            _repositoryFactory = repositoryFactory;
            _unitOfWork = unitOfWork;
        }


        public List<Reverts> GetList()
        {
            try
            {
                var reverts = _repositoryFactory.Reverts.Table.ToList();

                return reverts;
            }
            catch
            {
                throw;
            }
        }

        public async Task<List<Reverts>> GetListAsync(
            Expression<Func<Reverts, bool>> predicate = null,
            params Expression<Func<Reverts, object>>[] includes)
        {
            try
            {
                //var reverts = await _repositoryFactory.Reverts.Table.ToListAsync();
                //return reverts;

                var query = _repositoryFactory.Reverts.Table.AsQueryable();

                // اعمال روابط تو در تو
                foreach (var include in includes)
                {
                    query = query.Include(include);
                }

                // اعمال شرط داینامیک
                if (predicate != null)
                {
                    query = query.Where(predicate);
                }

                var reverts = await query.ToListAsync();
                
                return reverts;

            }
            catch (System.Exception ex)
            {
                throw;
            }
        }

        public Reverts GetRevertsById(int id)
        {
            try
            {
                var reverts = _repositoryFactory.Reverts.TableNoTracking
                    .Include(x => x.RevertPaletsList).ThenInclude(x => x.Palet).ThenInclude(x => x.Customer)
                    .Include(x => x.RevertPaletsList).ThenInclude(x => x.Palet).ThenInclude(x => x.Product)
                    .Include(x => x.RevertPaletsList).ThenInclude(x => x.NewPalet)
                    .FirstOrDefault(x => x.Id == id);

                return reverts;
            }
            catch
            {
                throw;
            }
        }

        public async Task<Reverts> GetRevertsByIdAsync(int id)
        {
            try
            {
                var reverts = await _repositoryFactory.Reverts.Table.AsNoTracking()
                    .Include(x => x.RevertPaletsList).ThenInclude(x => x.Palet).ThenInclude(x => x.Customer)
                    .Include(x => x.RevertPaletsList).ThenInclude(x => x.Palet).ThenInclude(x => x.Product)
                    .Include(x => x.RevertPaletsList).ThenInclude(x => x.Palet).ThenInclude(x => x.PaletDetailList)
                            .ThenInclude(x => x.InvProduct).ThenInclude(x => x.DataProduction).ThenInclude(x => x.ProductionPlanPatil)
                    .Include(x => x.RevertPaletsList).ThenInclude(x => x.NewPalet)
                    .FirstOrDefaultAsync(x => x.Id == id);

                return reverts;
            }
            catch
            {
                throw;
            }
        }

        public int Append(Reverts reverts)
        {
            using (var scope = _unitOfWork.StartTransaction())
            {
                try
                {
                    reverts.Customer = null;
                    //var revertedPalet = reverts.RevertPaletsList.First().Palet;

                    if (reverts.RevertPaletsList != null)
                    {

                        #region RevertPalet


                        if (reverts.RevertPaletsList != null)
                        {
                            int no = 1;
                            PaletsService paletsService = new PaletsService(_repositoryFactory, _unitOfWork);

                            foreach (var revertedPalet in reverts.RevertPaletsList)
                            {
                                #region NewPalet

                                var newPaletNo = paletsService.GetNextPaletNoAsync(no++).Result;

                                Palets newPalet = new Palets
                                {
                                    PaletNo = newPaletNo,
                                    NetWeight = revertedPalet.Palet.NetWeight,
                                    CustomerID = null,
                                    OrderDetailID = null,
                                    PaletDate = PPC.Common.General.CurrentDateString,
                                    PaletTime = PPC.Common.General.CurrentTimeString,
                                    ProductID = revertedPalet.Palet.ProductID,
                                    ProductsQuality = revertedPalet.Palet.ProductsQuality,
                                    QcStatus = revertedPalet.Palet.QcStatus,
                                    QualityClass = revertedPalet.Palet.QualityClass,
                                    QTY = revertedPalet.Palet.QTY,
                                    Remarks = revertedPalet.Palet.Remarks,
                                    StationID = revertedPalet.Palet.StationID,
                                    Status = (byte)PaletStatus.Saved, //revertedPalet.Status,
                                    UserID = reverts.UserID,//revertedPalet.Palet.UserID,
                                    Weight = revertedPalet.Palet.Weight,
                                };


                                newPalet.PaletDetailList = new List<PaletDetail>();

                                revertedPalet.Palet.PaletDetailList.ForEach(detail =>
                                {
                                    PaletDetail newPaletDetail = new PaletDetail
                                    {
                                        PaletID = detail.PaletID,
                                        InvProductID = detail.InvProductID,
                                    };

                                    newPalet.PaletDetailList.Add(newPaletDetail);
                                });

                                #endregion

                                #region change PaletStatus to Reverted

                                var oldPalet = _repositoryFactory.Palets.FirstOrDefault(p => p.PaletID == revertedPalet.PaletID);
                                oldPalet.Status = (byte)PaletStatus.Reverted;
                                #endregion
                                //revertedPalet.Palet.Status = (byte)PaletStatus.Reverted;
                                revertedPalet.Palet = oldPalet;
                                //revertedPalet.PaletID = revertedPalet.PaletID;
                                revertedPalet.NewPalet = newPalet;
                            }
                        }

                        #endregion


                    }


                    var _newObject = new Reverts
                    {
                        Id = reverts.Id,
                        RevertDate = reverts.RevertDate,
                        CustomerID = reverts.CustomerID,
                        UserID = reverts.UserID,
                        Remark = reverts.Remark,
                        InsertUserId = reverts.InsertUserId,
                        UpdateUserId = reverts.UpdateUserId,
                        InsertDateTime = reverts.InsertDateTime,
                        UpdateDateTime = reverts.UpdateDateTime,
                        RevertPaletsList = reverts.RevertPaletsList,
                        //RevertProductsList = reverts.RevertProductsList,


                    };

                    _repositoryFactory.Reverts.Add(_newObject);

                    var statuse = _unitOfWork.Commit() > 0;


                    if (!statuse)
                        throw new System.Exception(Resources.Resources.pub_RegistrationHasError);

                    scope.Commit();
                    return _newObject.Id;

                }
                catch (System.Exception)
                {
                    scope.Rollback();
                    throw;
                }
            }
        }



        //public bool Update(Reverts reverts)
        //{
        //    try
        //    {

        //        _repositoryFactory.Reverts.UpdateBy(x => x.Id == reverts.Id,
        //            new Reverts
        //            {
        //                Id = reverts.Id,
        //                RevertDate = reverts.RevertDate,
        //                CustomerID = reverts.CustomerID,
        //                UserID = reverts.UserID,
        //                Remark = reverts.Remark,
        //                InsertUserId = reverts.InsertUserId,
        //                UpdateUserId = reverts.UpdateUserId,
        //                InsertDateTime = reverts.InsertDateTime,
        //                UpdateDateTime = reverts.UpdateDateTime,
        //                RevertPaletsList = reverts.RevertPaletsList,
        //                RevertProductsList = reverts.RevertProductsList,


        //            });
        //        var statuse = _unitOfWork.Commit() > 0;
        //        return statuse;
        //    }
        //    catch (System.Exception ex)
        //    {
        //        throw ex;
        //    }
        //}


        public bool Update(Reverts reverts)
        {

            using (var scope = _unitOfWork.StartTransaction())
            {
                try
                {

                    //var deliveredCustomerID = reverts.RevertPaletsList.FirstOrDefault(x => x.Palet?.CustomerID != null).Palet.CustomerID;
                    //var deliveredOrderDetailID = reverts.RevertPaletsList.FirstOrDefault(x => x.Palet?.OrderDetailID != null).Palet.OrderDetailID;
                    #region get list of deletable pallets

                    // بازیابی رکورد برگشتی موجود از پایگاه داده
                    var oldRevert = GetRevertsByIdAsync(reverts.Id).Result;

                    // بازیابی رکورد های پالت های برگشتی موجود از پایگاه داده
                    var oldrevertPallets = oldRevert.RevertPaletsList;

                    // لیست پالت های ارسال شده جهت بروز رسانی
                    var newRevertPallets = reverts.RevertPaletsList;


                    #region obtain each palet detail
                    newRevertPallets.ForEach(revertPalet =>
                    {
                        var paletDetails = _repositoryFactory.PaletDetail.Where(x => x.PaletID == revertPalet.PaletID).ToList();
                        revertPalet.Palet.PaletDetailList = paletDetails;
                    });

                    #endregion

                    (List<RevertPalets> deletablePaletDifference, List<RevertPalets> newDifference) = oldrevertPallets.GetListDifferences(newRevertPallets,
                        (item1, item2) =>
                        {
                            return item1.Id == item2.Id &&
                                   item1.PaletID == item2.PaletID;
                        });


                    #endregion


                    #region delete removed palates

                    if (deletablePaletDifference?.Count > 0)
                    {
                        #region change & delete removed plateStatus => "Delivered"


                        foreach (var item in deletablePaletDifference)
                        {
                            var pallet = _repositoryFactory.Palets.FirstOrDefault(x => x.PaletID == item.PaletID);
                            pallet.Status = (byte)PaletStatus.Delivered;

                            ///
                            ///delete reverted palet
                            ///
                            var revertedPalets = _repositoryFactory.Palets.Table
                                .Include(x => x.PaletDetailList)
                                .FirstOrDefault(x => x.PaletID == item.NewPaletID);

                            _repositoryFactory.Palets.Delete(revertedPalets);

                        }

                        #endregion


                        #region delete removed RevertPalet record

                        var deletableRevertPaletIds = deletablePaletDifference.Select(d => d.RevertPaletsId).ToList();
                        var deletableRevertPalets = _repositoryFactory.RevertPalets
                            .Where(x =>
                            deletableRevertPaletIds.Contains(x.Id)
                            ).ToList();
                        deletableRevertPalets.ForEach(x => _repositoryFactory.RevertPalets.Delete(x));

                        _unitOfWork.Commit();

                        #endregion


                    }
                    #endregion


                    #region create new RevertPalet

                    int no = 1;

                    foreach (RevertPalets revertedPalet in newRevertPallets)
                    {

                        if (revertedPalet?.Palet != null)
                        {
                            PaletsService paletsService = new PaletsService(_repositoryFactory, _unitOfWork);

                            reverts.RevertPaletsList.ForEach(revertPalet =>
                            {
                                var newPaletNo = paletsService.GetNextPaletNoAsync(no++).Result;

                                Palets newPalet = new Palets
                                {
                                    PaletNo = newPaletNo,
                                    CustomerID = null,
                                    OrderDetailID = null,
                                    NetWeight = revertedPalet.Palet.NetWeight,
                                    PaletDate = PPC.Common.General.CurrentDateString,
                                    PaletTime = PPC.Common.General.CurrentTimeString,
                                    ProductID = revertedPalet.Palet.ProductID,
                                    ProductsQuality = revertedPalet.Palet.ProductsQuality,
                                    QcStatus = revertedPalet.Palet.QcStatus,
                                    QualityClass = revertedPalet.Palet.QualityClass,
                                    QTY = revertedPalet.Palet.QTY,
                                    Remarks = revertedPalet.Palet.Remarks,
                                    StationID = revertedPalet.Palet.StationID,
                                    Status = (byte)PaletStatus.Saved,
                                    UserID = revertedPalet.Palet.UserID,
                                    Weight = revertedPalet.Palet.Weight,
                                };

                                #region change  revertedPalet status to Reverted

                                var oldPalet = _repositoryFactory.Palets.FirstOrDefault(p => p.PaletID == revertedPalet.PaletID);
                                oldPalet.Status = (byte)PaletStatus.Delivered;
                                #endregion


                                newPalet.PaletDetailList = new List<PaletDetail>();

                                revertedPalet.Palet.PaletDetailList.ForEach(detail =>
                                {
                                    PaletDetail newPaletDetail = new PaletDetail
                                    {
                                        PaletID = detail.PaletID,
                                        InvProductID = detail.InvProductID,
                                    };

                                    newPalet.PaletDetailList.Add(newPaletDetail);
                                });


                                revertPalet.Palet = null;
                                revertPalet.PaletID = revertedPalet.PaletID;
                                revertPalet.NewPalet = newPalet;
                            });
                        }
                    }
                    #endregion


                    #region update revert

                    _repositoryFactory.Reverts.UpdateBy(x => x.Id == reverts.Id,
                        new Reverts
                        {
                            Id = reverts.Id,
                            RevertDate = reverts.RevertDate,
                            CustomerID = reverts.CustomerID,
                            UserID = reverts.UserID,
                            Remark = reverts.Remark,
                            InsertUserId = reverts.InsertUserId,
                            UpdateUserId = reverts.UpdateUserId,
                            InsertDateTime = reverts.InsertDateTime,
                            UpdateDateTime = reverts.UpdateDateTime,
                            RevertPaletsList = reverts.RevertPaletsList,
                            RevertProductsList = reverts.RevertProductsList,
                        });

                    var statuse = _unitOfWork.Commit() > 0;

                    #endregion


                    scope.Commit();
                    return statuse;
                }
                catch (System.Exception ex)
                {
                    scope.Rollback();
                    throw ex; // اگر نیاز به ثبت لاگ دارید، اینجا انجام دهید
                }
            }
        }


        public bool Upsert(Reverts reverts)
        {
            try
            {
                bool statuse = false;
                if (reverts.RevertId > 0)
                    statuse = Update(reverts);
                else
                    statuse = Append(reverts) > 0;

                return statuse;
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }

        public long Delete(int id)
        {
            using (var scop = _unitOfWork.StartTransaction())
            {

                try
                {
                    //var reverts = GetRevertsById(id);

                    var reverts = _repositoryFactory.Reverts.Table
                        .Include(x => x.RevertPaletsList).ThenInclude(x => x.Palet)
                        .Include(x => x.RevertPaletsList).ThenInclude(x => x.NewPalet)
                        .FirstOrDefault(x => x.Id == id);


                    if (reverts == null)
                        throw new System.Exception("Reverts not found.");

                    #region  palet id's

                    var newPaletIdList = new List<int>();
                    newPaletIdList = reverts.RevertPaletsList.Select(x => x.NewPaletID).ToList();

                    var paletIdList = new List<int>();
                    paletIdList = reverts.RevertPaletsList.Select(x => x.PaletID).ToList();

                    #endregion 

                    #region Palet status update

                    var paletsToUpdate = _repositoryFactory.Palets.Table
                        .Where(x => paletIdList.Contains(x.PaletID))
                        .ToList();

                    paletsToUpdate.ForEach(palet =>
                    {
                        palet.Status = (byte)PaletStatus.Delivered;
                        _repositoryFactory.Palets.Update(palet);
                    });

                    #endregion


                    ///delete revertsRevertPalets
                    _repositoryFactory.RevertPalets.DeleteBy(x => x.RevertID == reverts.RevertId);

                    ///delete reverts
                    _repositoryFactory.Reverts.Delete(reverts);

                    #region delete new palet


                    // بارگذاری موجودیت‌ها همراه با داده‌های مرتبط
                    var paletsToDelete = _repositoryFactory.Palets.Table
                        .Include(x => x.PaletDetailList)
                        .Where(x => newPaletIdList.Contains(x.PaletID))
                        .ToList();

                    // حذف موجودیت‌ها
                    paletsToDelete.ForEach(palet =>
                    {
                        _repositoryFactory.PaletDetail.DeleteBy(x => x.PaletID == palet.PaletID);
                        _repositoryFactory.Palets.DeleteBy(x => x.PaletID == palet.PaletID);
                    });


                    #endregion

                    var statuse = _unitOfWork.Commit();



                    scop.Commit();
                    return statuse;
                }
                catch
                {
                    scop.Rollback();
                    throw;
                }
            }
        }

        public async Task<List<Reverts>> GetListByDate(
            string dateFrom, 
            string dateTo,
            params Expression<Func<Reverts, object>>[] includes)
        {
            try
            {

                var query = _repositoryFactory.Reverts.Table.AsQueryable();

                // Apply includes
                foreach (var include in includes)
                    query = query.Include(include);

                var reverts = await query
                    .Where(x => (string.Compare(x.RevertDate, dateFrom) >= 0 && string.Compare(x.RevertDate, dateTo) <= 0))
                    .ToListAsync();

                return reverts;
            }
            catch (System.Exception ex)
            {
                throw;
            }
        }



    }
}
