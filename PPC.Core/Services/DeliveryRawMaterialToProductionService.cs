using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PPC.Common;
using PPC.Core.Interface;
using PPC.Core.Models;
using PPC.Core.Repository;
namespace PPC.Core.Services
{
    public class DeliveryRawMaterialToProductionService : BaseService, IDeliveryRawMaterialToProductionService
    {
        IUnitOfWork _unitOfWork;
        public DeliveryRawMaterialToProductionService(RepositoryFactory repositoryFactory,
            IUnitOfWork unitOfWork)
        {
            _repositoryFactory = repositoryFactory;
            _unitOfWork = unitOfWork;
        }


        public List<DeliveryRawMaterialToProduction> GetAll()
        {
            try
            {
                var deliveryRawMaterialToProduction = _repositoryFactory.DeliveryRawMaterialToProduction.Table.ToList();

                return deliveryRawMaterialToProduction;
            }
            catch
            {
                throw;
            }
        }

        public async Task<List<DeliveryRawMaterialToProduction>> GetAllAsync()
        {
            try
            {

                var deliveryRawMaterialToProduction = await _repositoryFactory.DeliveryRawMaterialToProduction.Table
                    .Include(x => x.ProductionPlan).ThenInclude(x => x.OrderDetail).ThenInclude(x => x.Order)
                    .Include(x => x.User_InsUser)
                    .Include(x => x.User_EditUser)
                    .Include(x => x.Requester)
                    .Include(x => x.DeliveryRawMaterialToProductionDetailList).ThenInclude(x => x.RawMaterial)
                    .Include(x => x.DeliveryRawMaterialToProductionPatilList).ThenInclude(x => x.ProductionPlanPatil)
                    .ToListAsync();


                return deliveryRawMaterialToProduction;
            }
            catch (System.Exception ex)
            {
                throw;
            }
        }

        public DeliveryRawMaterialToProduction GetDeliveryRawMaterialToProductionById(int deliveryRawMaterialToProductionID)
        {
            try
            {
                var deliveryRawMaterialToProduction = _repositoryFactory.DeliveryRawMaterialToProduction.Table
                    .Include(x => x.ProductionPlan)
                    .Include(x => x.DeliveryRawMaterialToProductionDetailList)
                    .Include(x => x.DeliveryRawMaterialToProductionPatilList)
                    .FirstOrDefault(x => x.DeliveryRawMaterialToProductionID == deliveryRawMaterialToProductionID);

                return deliveryRawMaterialToProduction;
            }
            catch
            {
                throw;
            }
        }

        public async Task<DeliveryRawMaterialToProduction> GetDeliveryRawMaterialToProductionByIdAsync(int deliveryRawMaterialToProductionID)
        {
            try
            {
                var deliveryRawMaterialToProduction = await _repositoryFactory.DeliveryRawMaterialToProduction.Table
                    .Include(x => x.ProductionPlan)
                    .Include(x => x.DeliveryRawMaterialToProductionDetailList).ThenInclude(x => x.RawMaterial)
                    .Include(x => x.DeliveryRawMaterialToProductionPatilList)
                    .FirstOrDefaultAsync(x => x.DeliveryRawMaterialToProductionID == deliveryRawMaterialToProductionID);

                //deliveryRawMaterialToProduction.RowVer = null;

                return deliveryRawMaterialToProduction;
            }
            catch
            {
                throw;
            }
        }

        public int Append(DeliveryRawMaterialToProduction deliveryRawMaterialToProduction)
        {
            //using (var t = _unitOfWork.StartTransaction())
            //{


            try
            {
                #region Append into DeliveryRawMaterialToProduction

                var _newObject = new DeliveryRawMaterialToProduction
                {
                    DeliveryRawMaterialToProductionID = deliveryRawMaterialToProduction.DeliveryRawMaterialToProductionID,
                    RequestNo = deliveryRawMaterialToProduction.RequestNo,
                    RequestDate = deliveryRawMaterialToProduction.RequestDate,
                    RequesterID = deliveryRawMaterialToProduction.RequesterID,
                    ProductionPlanID = deliveryRawMaterialToProduction.ProductionPlanID,
                    Status = deliveryRawMaterialToProduction.Status,
                    InsUserID = deliveryRawMaterialToProduction.InsUserID,
                    InsDate = deliveryRawMaterialToProduction.InsDate,
                    InsTime = deliveryRawMaterialToProduction.InsTime,
                    IsDraft = deliveryRawMaterialToProduction.IsDraft,
                    EditUserID = deliveryRawMaterialToProduction.EditUserID,
                    EditDate = deliveryRawMaterialToProduction.EditDate,
                    EditTime = deliveryRawMaterialToProduction.EditTime,
//                    RowVer = deliveryRawMaterialToProduction.RowVer,
                    DeliveryRawMaterialToProductionDetailList = deliveryRawMaterialToProduction.DeliveryRawMaterialToProductionDetailList,
                    DeliveryRawMaterialToProductionPatilList = deliveryRawMaterialToProduction.DeliveryRawMaterialToProductionPatilList,

                };
                _repositoryFactory.DeliveryRawMaterialToProduction.Add(_newObject);
                var statuse = _unitOfWork.Commit() > 0;

                #endregion




                //t.Commit();

                if (statuse)
                    return _newObject.DeliveryRawMaterialToProductionID;
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


        public bool Update(DeliveryRawMaterialToProduction deliveryRawMaterialToProduction)
        {

            try
            {

                _repositoryFactory.DeliveryRawMaterialToProduction.UpdateBy(x => x.DeliveryRawMaterialToProductionID == deliveryRawMaterialToProduction.DeliveryRawMaterialToProductionID,
                    new DeliveryRawMaterialToProduction
                    {
                        DeliveryRawMaterialToProductionID = deliveryRawMaterialToProduction.DeliveryRawMaterialToProductionID,
                        RequestNo = deliveryRawMaterialToProduction.RequestNo,
                        RequestDate = deliveryRawMaterialToProduction.RequestDate,
                        RequesterID = deliveryRawMaterialToProduction.RequesterID,
                        ProductionPlanID = deliveryRawMaterialToProduction.ProductionPlanID,
                        Status = deliveryRawMaterialToProduction.Status,
                        InsUserID = deliveryRawMaterialToProduction.InsUserID,
                        InsDate = deliveryRawMaterialToProduction.InsDate,
                        InsTime = deliveryRawMaterialToProduction.InsTime,
                        IsDraft = deliveryRawMaterialToProduction.IsDraft,
                        EditUserID = deliveryRawMaterialToProduction.EditUserID,
                        EditDate = deliveryRawMaterialToProduction.EditDate,
                        EditTime = deliveryRawMaterialToProduction.EditTime,
                        //RowVer = deliveryRawMaterialToProduction.RowVer,
                        DeliveryRawMaterialToProductionDetailList = deliveryRawMaterialToProduction.DeliveryRawMaterialToProductionDetailList,
                        DeliveryRawMaterialToProductionPatilList = deliveryRawMaterialToProduction.DeliveryRawMaterialToProductionPatilList,


                    });
                var statuse = _unitOfWork.Commit() > 0;
                return statuse;
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }

        public long Delete(int deliveryRawMaterialToProductionID)
        {

            try
            {
                var deliveryRawMaterialToProduction = _repositoryFactory.DeliveryRawMaterialToProduction.Table
                    .Include(x => x.DeliveryRawMaterialToProductionDetailList)
                    .Include(x => x.DeliveryRawMaterialToProductionPatilList)
                    .FirstOrDefault(x => x.DeliveryRawMaterialToProductionID == deliveryRawMaterialToProductionID);

                if (deliveryRawMaterialToProduction == null)
                    throw new System.Exception("DeliveryRawMaterialToProduction Notfound.");

                _repositoryFactory.DeliveryRawMaterialToProduction.Delete(deliveryRawMaterialToProduction);
                var statuse = _unitOfWork.Commit();

                return statuse;
            }
            catch
            {
                throw;
            }
        }

        public int? GetMaxRequestNo()
        {
            try
            {
                int? maxRequestNo = null;
                maxRequestNo = _repositoryFactory.DeliveryRawMaterialToProduction.Table
                    .Max(x => (int?)x.RequestNo);



                return maxRequestNo;
            }
            catch
            {
                throw;
            }
        }

        public async Task<List<DeliveryRawMaterialToProduction>> GetRawMaterialToProductionDeliveryListAsync()
        {
            try
            {

                var deliveryRawMaterialToProduction = await _repositoryFactory.DeliveryRawMaterialToProduction
                    .Where(x => x.Status == (byte)PPC.Common.DeliveryRawMaterialToProductionStatus.Saved)
                    .Include(x => x.ProductionPlan).ThenInclude(x => x.OrderDetail).ThenInclude(x => x.Order)
                    .Include(x => x.User_InsUser)
                    .Include(x => x.User_EditUser)
                    .Include(x => x.Requester)
                    .Include(x => x.DeliveryRawMaterialToProductionDetailList).ThenInclude(x => x.RawMaterial)
                    .Include(x => x.DeliveryRawMaterialToProductionPatilList).ThenInclude(x => x.ProductionPlanPatil)
                    .ToListAsync();


                return deliveryRawMaterialToProduction;
            }
            catch (System.Exception ex)
            {
                throw;
            }
        }

        public async Task<List<DeliveryRawMaterialToProduction>> GetListByStatus(byte status, string dateFrom, string dateTo)
        {
            try
            {

                var deliveryRawMaterialToProduction = await _repositoryFactory.DeliveryRawMaterialToProduction
                    .Where(x => x.Status == status)
                    .Include(x => x.ProductionPlan).ThenInclude(x => x.OrderDetail).ThenInclude(x => x.Order)
                    .Include(x => x.User_InsUser)
                    .Include(x => x.User_EditUser)
                    .Include(x => x.Requester)
                    .Include(x => x.DeliveryRawMaterialToProductionDetailList).ThenInclude(x => x.RawMaterial)
                    .Include(x => x.DeliveryRawMaterialToProductionPatilList).ThenInclude(x => x.ProductionPlanPatil)
                    .ToListAsync();


                return deliveryRawMaterialToProduction;
            }
            catch (System.Exception ex)
            {
                throw;
            }
        }


    }

}
