using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using AtlasCellData.ADO;
using Microsoft.EntityFrameworkCore;
using PPC.Common;
using PPC.Core.Interface;
using PPC.Core.Models;
using PPC.Core.Repository;
namespace PPC.Core.Services
{
    public partial class ProductionPlansService : BaseService, IProductionPlansService
    {
        IUnitOfWork _unitOfWork;
        public ProductionPlansService(RepositoryFactory repositoryFactory,
            IUnitOfWork unitOfWork)
        {
            _repositoryFactory = repositoryFactory;
            _unitOfWork = unitOfWork;
        }


        public List<ProductionPlans> GetAll()
        {
            try
            {
                var productionPlans = _repositoryFactory.ProductionPlans.Table.ToList();

                return productionPlans;
            }
            catch
            {
                throw;
            }
        }

        public async Task<List<ProductionPlans>> GetAllAsync()
        {
            try
            {

                var productionPlans = await _repositoryFactory.ProductionPlans.Table
                    .Include(x => x.ProductionPlanPatilsCapacityList)
                    .Include(x => x.ProductionPlanPackagingList).ThenInclude(x => x.PackagingPlan)
                    .Include(x => x.OrderDetail).ThenInclude(x => x.Order)
                    .Include(x => x.User_InsUser)
                    .Include(x => x.User_InsUser)
                    .ToListAsync();
                return productionPlans;
            }
            catch (System.Exception ex)
            {
                throw;
            }
        }

        public ProductionPlans GetProductionPlansById(int productionPlanID)
        {
            try
            {
                var productionPlans = _repositoryFactory.ProductionPlans
                    .FirstOrDefault(x => x.ProductionPlanID == productionPlanID);

                return productionPlans;
            }
            catch
            {
                throw;
            }
        }

        public async Task<ProductionPlans> GetProductionPlansByIdAsync(int productionPlanID)
        {
            try
            {
                var productionPlans = await _repositoryFactory.ProductionPlans.Table
                    .Include(x => x.OrderDetail).ThenInclude(x => x.Order)
                    .Include(x => x.OrderDetail).ThenInclude(x => x.Product)
                    .Include(x => x.OrderDetail).ThenInclude(x => x.BOM)
                    .Include(x => x.ProductionPlanPatilsCapacityList)
                    .Include(x => x.ProductionPlanPackagingList)
                    .Include(x => x.ProductionPlanBOMDetailList).ThenInclude(x => x.BOMDetail).ThenInclude(x => x.RawMaterial)
                    .Include(x => x.ProductionPlanBOMDetailList).ThenInclude(x => x.BOMDetail).ThenInclude(x => x.BOMComplementaryList)//.ThenInclude(x=>x.BOMDetail)
                    .Include(x => x.ProductionPlanPatilList)
                    .FirstOrDefaultAsync(x => x.ProductionPlanID == productionPlanID);


                //set null to rowver
                productionPlans?.ProductionPlanBOMDetailList?.ForEach(x => x.RowVer = null);

                return productionPlans;
            }
            catch
            {
                throw;
            }
        }

        public int Append(ProductionPlans productionPlans)
        {
            //using (var t = _unitOfWork.StartTransaction())
            //{
            try
            {
                var _newObject = new ProductionPlans
                {
                    ProductionPlanID = productionPlans.ProductionPlanID,
                    OrderDetailID = productionPlans.OrderDetailID,
                    ProducibleQuantity = productionPlans.ProducibleQuantity,
                    StartDate = productionPlans.StartDate,
                    EndDate = productionPlans.EndDate,
                    BatchNo = productionPlans.BatchNo,
                    ProductionProcessCirculation = productionPlans.ProductionProcessCirculation,
                    ProductionProcessType = productionPlans.ProductionProcessType,
                    TransferToInvRM = productionPlans.TransferToInvRM,
                    TransferToWarehouse = productionPlans.TransferToWarehouse,
                    Describe = productionPlans.Describe,
                    Status = productionPlans.Status,
                    IsDraft = productionPlans.IsDraft,
                    InsUserID = productionPlans.InsUserID,
                    InsDate = productionPlans.InsDate,
                    InsTime = productionPlans.InsTime,
                    EditUserID = productionPlans.EditUserID,
                    EditDate = productionPlans.EditDate,
                    EditTime = productionPlans.EditTime,
                    ProductionPlanPackagingList = productionPlans.ProductionPlanPackagingList,
                    ProductionPlanPatilsCapacityList = productionPlans.ProductionPlanPatilsCapacityList,
                    ProductionPlanBOMDetailList = productionPlans.ProductionPlanBOMDetailList,
                    ProductionPlanPatilList = productionPlans.ProductionPlanPatilList
                };
                _repositoryFactory.ProductionPlans.Add(_newObject);
                var statuse = _unitOfWork.Commit() > 0;

                //productionPlans.ProductionPlanPackagingList.ForEach(x =>
                //_repositoryFactory.ProductionPlanPackaging.Add(
                //    new ProductionPlanPackaging
                //    {
                //        ProductionPlanID = _newObject.ProductionPlanID,
                //        Priority= x.Priority,
                //        PackagingPlanID= x.PackagingPlanID,
                //        QTY = x.QTY,
                //    })) ;

                //productionPlans.ProductionPlanPatilsCapacityList.ForEach(x =>
                //_repositoryFactory.ProductionPlanPatilsCapacity.Add(
                //    new ProductionPlanPatilsCapacity
                //    {
                //        ProductionPlanID = _newObject.ProductionPlanID,
                //        Capacity = x.Capacity,
                //        QTY= x.QTY,
                //    }));


                //statuse &= _unitOfWork.Commit() > 0;

                // t.Commit(); 

                if (statuse)
                    return _newObject.ProductionPlanID;
                else
                    return int.MinValue;
            }
            catch (System.Exception)
            {
                //t.Rollback();
                throw;
            }
            //}
        }


        public bool Update(ProductionPlans productionPlans)
        {
            using (var t = _unitOfWork.StartTransaction())
            {


                try
                {


                    #region delete removed records


                    _repositoryFactory.ProductionPlanPatilsCapacity.DeleteBy(x => x.ProductionPlanID == productionPlans.ProductionPlanID &&
                    !productionPlans.ProductionPlanPatilsCapacityList.Select(x => x.ProductionPlanID).Contains(x.ProductionPlanID));

                    _repositoryFactory.ProductionPlanPackaging.DeleteBy(x => x.ProductionPlanID == productionPlans.ProductionPlanID &&
                    !productionPlans.ProductionPlanPackagingList.Select(x => x.ProductionPlanID).Contains(x.ProductionPlanID));

                    _repositoryFactory.ProductionPlanBOMDetail.DeleteBy(x => x.ProductionPlanID == productionPlans.ProductionPlanID &&
                    !productionPlans.ProductionPlanBOMDetailList.Select(x => x.ProductionPlanID).Contains(x.ProductionPlanID));


                    //_repositoryFactory.ProductionPlanPatils.DeleteBy(x => x.ProductionPlanID == productionPlans.ProductionPlanID &&
                    //!productionPlans.ProductionPlanPatilList.Select(x => x.ProductionPlanID).Contains(x.ProductionPlanID));
                    ////بعلت استفاده از شماره های لات نامبر در تحویل مواد به تولید امکان ویرایش تنها زمانی
                    ///وجود خواهد داشت که استفاده نشده باشند به همین دلیل از این روش بمنظور بررسی استفاده های
                    ///اختمالی استفاده می کنیم
                    /// ProductionPlanPatils
                    /// 

                    _repositoryFactory.ProductionPlanPatils.DeleteBy(x => x.ProductionPlanID == productionPlans.ProductionPlanID);

                    #endregion


                    _repositoryFactory.ProductionPlans.UpdateBy(x => x.ProductionPlanID == productionPlans.ProductionPlanID,
                        new ProductionPlans
                        {
                            ProductionPlanID = productionPlans.ProductionPlanID,
                            OrderDetailID = productionPlans.OrderDetailID,
                            ProducibleQuantity = productionPlans.ProducibleQuantity,
                            StartDate = productionPlans.StartDate,
                            EndDate = productionPlans.EndDate,
                            BatchNo = productionPlans.BatchNo,
                            ProductionProcessCirculation = productionPlans.ProductionProcessCirculation,
                            ProductionProcessType = productionPlans.ProductionProcessType,
                            TransferToInvRM = productionPlans.TransferToInvRM,
                            TransferToWarehouse = productionPlans.TransferToWarehouse,
                            Describe = productionPlans.Describe,
                            Status = productionPlans.Status,
                            IsDraft = productionPlans.IsDraft,
                            InsUserID = productionPlans.InsUserID,
                            InsDate = productionPlans.InsDate,
                            InsTime = productionPlans.InsTime,
                            EditUserID = productionPlans.EditUserID,
                            EditDate = productionPlans.EditDate,
                            EditTime = productionPlans.EditTime,

                            ProductionPlanPackagingList = productionPlans.ProductionPlanPackagingList,
                            ProductionPlanPatilsCapacityList = productionPlans.ProductionPlanPatilsCapacityList,
                            ProductionPlanBOMDetailList = productionPlans.ProductionPlanBOMDetailList,
                            ProductionPlanPatilList = productionPlans.ProductionPlanPatilList


                        });
                    var statuse = _unitOfWork.Commit() > 0;

                    t.Commit();

                    return statuse;
                }
                catch (System.Exception ex)
                {
                    t.Rollback();
                    throw ex;
                }
            }
        }

        public long Delete(int productionPlanID)
        {
            try
            {
                var productionPlans = _repositoryFactory.ProductionPlans.Table
                    .Include(x => x.ProductionPlanPatilsCapacityList)
                    .Include(x => x.ProductionPlanBOMDetailList)
                    .Include(x => x.ProductionPlanPackagingList)
                    .Include(x => x.ProductionPlanPatilList)
                    .FirstOrDefault(x => x.ProductionPlanID == productionPlanID);

                if (productionPlans == null)
                    throw new System.Exception("ProductionPlans Notfound.");

                //productionPlans.ProductionPlanPatilsCapacityList= _repositoryFactory.ProductionPlanPatilsCapacity.Where(x=>x.ProductionPlanID == productionPlanID).ToList();
                //productionPlans.ProductionPlanPackagingList= _repositoryFactory.ProductionPlanPackaging.Where(x=>x.ProductionPlanID == productionPlanID).ToList();


                _repositoryFactory.ProductionPlans.Delete(productionPlans);
                var statuse = _unitOfWork.Commit();

                return statuse;
            }
            catch
            {
                throw;
            }
        }

        public async Task<ProductionPlans> GetMaxProductionPlanByDateAsync(string date)
        {
            try
            {
                var productionPlans = await _repositoryFactory.ProductionPlans.Table
                    .Where(x => x.InsDate == date).OrderByDescending(x => x.InsDate).FirstOrDefaultAsync();

                return productionPlans;
            }
            catch
            {
                throw;
            }
        }

        public async Task<List<ProductionPlans>> GetBatchNumbersListByOrderDetailIdAsync(int orderDetailId)
        {
            try
            {
                var productionPlans = await _repositoryFactory.ProductionPlans.Table
                    .Where(x => x.OrderDetailID == orderDetailId)
                    .ToListAsync();

                return productionPlans;
            }
            catch
            {
                throw;
            }
        }

        public async Task<List<ProductionPlans>> GetListForDropdown()
        {
            try
            {
                var productionPlans = await _repositoryFactory.ProductionPlans.Table
                    .ToListAsync();

                return productionPlans;
            }
            catch
            {
                throw;
            }
        }

        public async Task<List<ProductionPlans>> GetInprocessListAsync(string startDate, string endDate)
        {
            try
            {

                List<byte> allowable = new List<byte> {

                    (byte)PPC.Common.ProductionPlanStatus.Saved,
                    (byte)PPC.Common.ProductionPlanStatus.Paused,
                    //(byte)PPC.Common.ProductionPlanStatus.Produced,
                };

                var productionPlans = await _repositoryFactory.ProductionPlans
                   .Where(x => allowable.Contains(x.Status) ||
                   (string.Compare(x.InsDate, startDate) >= 0 && string.Compare(x.InsDate, endDate) <= 0)
                   )
                   .Include(x => x.ProductionPlanPatilsCapacityList)
                   .Include(x => x.ProductionPlanPatilList)
                   .Include(x => x.ProductionPlanPackagingList).ThenInclude(x => x.PackagingPlan)
                   .Include(x => x.OrderDetail).ThenInclude(x => x.Order)
                   .Include(x => x.OrderDetail).ThenInclude(x => x.Product)
                   .Include(x => x.User_InsUser)
                   .Include(x => x.User_EditUser)
                   .ToListAsync();
                return productionPlans;
            }
            catch (System.Exception ex)
            {
                throw;
            }
        }

        public (DataTable productionDT, DataTable bomDT, DataTable packagingDT, DataTable patilesDT) GetProductionReport(int productionPlanId)
        {
            try
            {
                var DTs = ProductionPlansDL.GetProductionReport(productionPlanId);

                return (DTs.productionDT, DTs.bomDT, DTs.packagingDT,DTs.patilesDT);
            }
            catch (System.Exception ex)
            {
                throw;
            }
        }

        public async Task<bool> FinishPlanAsync(int productionPlanId)
        {
            try
            {
                var plan = await _repositoryFactory.ProductionPlans.FirstOrDefaultAsync(x => x.ProductionPlanID == productionPlanId);
                plan.Status = (byte)ProductionPlanStatus.Finished;
                var statuse = _unitOfWork.Commit() > 0;

                return statuse;
            }
            catch
            {
                throw;
            }
        }

        public async Task<ProductionPlans> GetLatestUsgedBOMAsync(int productionPlanId)
        {
            try
            {

                var productionPlans = await _repositoryFactory.ProductionPlans.Table
                    .Include(x => x.ProductionPlanPatilsCapacityList)
                    .Include(x => x.ProductionPlanPackagingList).ThenInclude(x => x.PackagingPlan)
                    .Include(x => x.OrderDetail).ThenInclude(x => x.Order)
                    .Include(x => x.OrderDetail).ThenInclude(x => x.BOM)
                    .Include(x => x.ProductionPlanBOMDetailList).ThenInclude(x=>x.RawMaterial)//لیست فرمولاسیون تولید
                    .Include(x=>x.ProductionPlanBOMDetailRevisedList).ThenInclude(x=>x.BOMDetail)//لیست فرمولاسیون اصلاحی
                    .Include(x=>x.ProductionPlanPatilList).ThenInclude(x=>x.ProductionPlanReworksList)//لیست فرمولاسیون اقدام اصلاحی
                    .Include(x => x.User_InsUser)
                    .Include(x => x.User_InsUser)
                    .FirstOrDefaultAsync(x => x.ProductionPlanID == productionPlanId);


                //var productionPlans = await _repositoryFactory.ProductionPlans.Table
                //    .Include(x => x.ProductionPlanPatilsCapacityList)
                //    .Include(x => x.ProductionPlanPatilsCapacityList)
                //    .Include(x => x.ProductionPlanPackagingList).ThenInclude(x => x.PackagingPlan)
                //    .Include(x => x.OrderDetail).ThenInclude(x => x.Order)
                //    .Include(x => x.ProductionPlanBOMDetailList).ThenInclude(x => x.BOMDetail).ThenInclude(x => x.BOM)
                //    .Include(x => x.ProductionPlanBOMDetailList).ThenInclude(x => x.RawMaterial)//لیست فرمولاسیون تولید
                //    .Include(x => x.ProductionPlanBOMDetailRevisedList).ThenInclude(x => x.BOMDetail).ThenInclude(x => x.BOM)//لیست فرمولاسیون اصلاحی
                //    .Include(x => x.ProductionPlanPatilList).ThenInclude(x => x.ProductionPlanReworksList).ThenInclude(x => x.ProductionPlanReworkDetailList).ThenInclude(x => x.BOMDetail)//لیست فرمولاسیون اقدام اصلاحی
                //    .Include(x => x.User_InsUser)
                //    .Include(x => x.User_InsUser)
                //    .FirstOrDefaultAsync(x => x.ProductionPlanID == productionPlanId);

                foreach (var item in productionPlans.ProductionPlanBOMDetailList)
                {
                    item.RowVer = null;
                }

                return productionPlans;
            }
            catch (System.Exception ex)
            {
                throw;
            }
        }


        public async Task<ProductionPlans> GetInstanceByProductionPlanPatilId(int productionPlanPatilID)
        {
            try
            {
                var productionPlans = (await _repositoryFactory.ProductionPlanPatils.Table.AsNoTracking()
                    .Include(x=>x.ProductionPlan)
                    .FirstOrDefaultAsync(x => x.ProductionPlanPatilID == productionPlanPatilID)).ProductionPlan;

                return productionPlans;
            }
            catch
            {
                throw;
            }
        }


        public async Task<List<ProductionPlans>> GetAllAsync(string startDate, string endDate)
        {
            try
            {

                 var productionPlans = _repositoryFactory.ProductionPlans
                   .Where(x => (string.Compare(x.InsDate, startDate) >= 0 && string.Compare(x.InsDate, endDate) <= 0)
                   )
                   .Include(x => x.ProductionPlanPatilsCapacityList)
                   .Include(x => x.ProductionPlanPatilList)
                   .Include(x => x.ProductionPlanPackagingList).ThenInclude(x => x.PackagingPlan)
                   .Include(x => x.OrderDetail).ThenInclude(x => x.Order)
                   .Include(x => x.OrderDetail).ThenInclude(x => x.Product)
                   .Include(x => x.User_InsUser)
                   .Include(x => x.User_EditUser)
                   .ToList();

                //var productionPlan1 = (_repositoryFactory.ProductionPlans
                //    .Where(x => (string.Compare(x.InsDate, startDate) >= 0 && string.Compare(x.InsDate, endDate) <= 0))
                //    .Include(x => x.ProductionPlanPatilsCapacityList)
                //    //.Include(x => x.ProductionPlanPatilList)
                //    //.Include(x => x.ProductionPlanPackagingList).ThenInclude(x => x.PackagingPlan)
                //    //.Include(x => x.OrderDetail).ThenInclude(x => x.Order)
                //    //.Include(x => x.OrderDetail).ThenInclude(x => x.Product)
                //    //.Include(x => x.User_InsUser)
                //    //.Include(x => x.User_InsUser)
                //    ).ToQueryString();

                return productionPlans;
            }
            catch (System.Exception ex)
            {
                throw;
            }
        }

    }
}
