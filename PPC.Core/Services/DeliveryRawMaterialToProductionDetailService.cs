using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PPC.Core.Interface;
using PPC.Core.Models;
using PPC.Core.Repository;
namespace PPC.Core.Services
{
    public class DeliveryRawMaterialToProductionDetailService : BaseService, IDeliveryRawMaterialToProductionDetailService
    {
        IUnitOfWork _unitOfWork;
        public DeliveryRawMaterialToProductionDetailService(RepositoryFactory repositoryFactory,
            IUnitOfWork unitOfWork)
        {
            _repositoryFactory = repositoryFactory;
            _unitOfWork = unitOfWork;
        }


        public List<DeliveryRawMaterialToProductionDetail> GetAll()
        {
            try
            {
                var deliveryRawMaterialToProductionDetail = _repositoryFactory.DeliveryRawMaterialToProductionDetail.Table.ToList();

                return deliveryRawMaterialToProductionDetail;
            }
            catch
            {
                throw;
            }
        }

        public async Task<List<DeliveryRawMaterialToProductionDetail>> GetAllAsync()
        {
            try
            {

                var deliveryRawMaterialToProductionDetail = await _repositoryFactory.DeliveryRawMaterialToProductionDetail.Table.ToListAsync();
                return deliveryRawMaterialToProductionDetail;
            }
            catch (System.Exception ex)
            {
                throw;
            }
        }

        public DeliveryRawMaterialToProductionDetail GetDeliveryRawMaterialToProductionDetailById(int deliveryRawMaterialToProductionDetailID)
        {
            try
            {
                var deliveryRawMaterialToProductionDetail = _repositoryFactory.DeliveryRawMaterialToProductionDetail
                    .FirstOrDefault(x => x.DeliveryRawMaterialToProductionDetailID == deliveryRawMaterialToProductionDetailID);

                return deliveryRawMaterialToProductionDetail;
            }
            catch
            {
                throw;
            }
        }

        public async Task<DeliveryRawMaterialToProductionDetail> GetDeliveryRawMaterialToProductionDetailByIdAsync(int deliveryRawMaterialToProductionDetailID)
        {
            try
            {
                var deliveryRawMaterialToProductionDetail = await _repositoryFactory.DeliveryRawMaterialToProductionDetail
                    .FirstOrDefaultAsync(x => x.DeliveryRawMaterialToProductionDetailID == deliveryRawMaterialToProductionDetailID);

                return deliveryRawMaterialToProductionDetail;
            }
            catch
            {
                throw;
            }
        }

        public int Append(DeliveryRawMaterialToProductionDetail deliveryRawMaterialToProductionDetail)
        {
            try
            {
                var _newObject = new DeliveryRawMaterialToProductionDetail
                {
                    DeliveryRawMaterialToProductionDetailID = deliveryRawMaterialToProductionDetail.DeliveryRawMaterialToProductionDetailID,
                    DeliveryRawMaterialToProductionID = deliveryRawMaterialToProductionDetail.DeliveryRawMaterialToProductionID,
                    RawMaterialID = deliveryRawMaterialToProductionDetail.RawMaterialID,
                    Planned = deliveryRawMaterialToProductionDetail.Planned,
                    InvProduction = deliveryRawMaterialToProductionDetail.InvProduction,
                    RemainingToProduction = deliveryRawMaterialToProductionDetail.RemainingToProduction,
                    RequestedAmount = deliveryRawMaterialToProductionDetail.RequestedAmount,
                    Describe = deliveryRawMaterialToProductionDetail.Describe,


                };

                _repositoryFactory.DeliveryRawMaterialToProductionDetail.Add(_newObject);

                var statuse = _unitOfWork.Commit() > 0;

                if (statuse)
                    return _newObject.DeliveryRawMaterialToProductionDetailID;
                else
                    return int.MinValue;
            }
            catch (System.Exception)
            {
                throw;
            }
        }


        public bool Update(DeliveryRawMaterialToProductionDetail deliveryRawMaterialToProductionDetail)
        {
            try
            {

                _repositoryFactory.DeliveryRawMaterialToProductionDetail.UpdateBy(x => x.DeliveryRawMaterialToProductionDetailID == deliveryRawMaterialToProductionDetail.DeliveryRawMaterialToProductionDetailID,
                    new DeliveryRawMaterialToProductionDetail
                    {
                        DeliveryRawMaterialToProductionDetailID = deliveryRawMaterialToProductionDetail.DeliveryRawMaterialToProductionDetailID,
                        DeliveryRawMaterialToProductionID = deliveryRawMaterialToProductionDetail.DeliveryRawMaterialToProductionID,
                        RawMaterialID = deliveryRawMaterialToProductionDetail.RawMaterialID,
                        Planned = deliveryRawMaterialToProductionDetail.Planned,
                        InvProduction = deliveryRawMaterialToProductionDetail.InvProduction,
                        RemainingToProduction = deliveryRawMaterialToProductionDetail.RemainingToProduction,
                        RequestedAmount = deliveryRawMaterialToProductionDetail.RequestedAmount,
                        Describe = deliveryRawMaterialToProductionDetail.Describe,


                    });
                var statuse = _unitOfWork.Commit() > 0;
                return statuse;
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }

        public long Delete(int deliveryRawMaterialToProductionDetailID)
        {
            try
            {
                var deliveryRawMaterialToProductionDetail = _repositoryFactory.DeliveryRawMaterialToProductionDetail
                    .FirstOrDefault(x => x.DeliveryRawMaterialToProductionDetailID == deliveryRawMaterialToProductionDetailID);

                if (deliveryRawMaterialToProductionDetail == null)
                    throw new System.Exception("DeliveryRawMaterialToProductionDetail Notfound.");

                _repositoryFactory.DeliveryRawMaterialToProductionDetail.Delete(deliveryRawMaterialToProductionDetail);
                var statuse = _unitOfWork.Commit();

                return statuse;
            }
            catch
            {
                throw;
            }
        }


        public async Task<List<DeliveryRawMaterialToProductionDetail>> GetAllToProductionDeliveryAsync()
        {
            try
            {

                var deliveryRawMaterialToProduction = await _repositoryFactory.DeliveryRawMaterialToProductionDetail.Table
                    .Include(x => x.DeliveryRawMaterialToProduction).ThenInclude(x => x.ProductionPlan).ThenInclude(x => x.OrderDetail).ThenInclude(x => x.Order)
                    .Include(x => x.DeliveryRawMaterialToProduction).ThenInclude(x => x.Requester)
                    .Include(x => x.DeliveryRawMaterialToProduction).ThenInclude(x => x.Requester)
                    .Include(x => x.DeliveryRawMaterialToProduction).ThenInclude(x => x.DeliveryRawMaterialToProductionDetailList).ThenInclude(x => x.RawMaterial)
                    .Include(x => x.DeliveryRawMaterialToProduction).ThenInclude(x => x.DeliveryRawMaterialToProductionPatilList).ThenInclude(x => x.ProductionPlanPatil)
                    .Where(x => x.DeliveryRawMaterialToProduction.Status == (byte)PPC.Common.DeliveryRawMaterialToProductionStatus.Saved)
                    .ToListAsync();


                return deliveryRawMaterialToProduction;
            }
            catch (System.Exception ex)
            {
                throw;
            }
        }

        public async Task<List<DeliveryRawMaterialToProductionDetail>> GetRawMaterialToProductionDeliveryListByDRMPId(int deliveryRawMaterialToProductionId)
        {
            try
            {
                var deliveryRawMaterialToProductionDetail = await _repositoryFactory.DeliveryRawMaterialToProductionDetail
                    .Where(x => x.DeliveryRawMaterialToProductionID == deliveryRawMaterialToProductionId)
                    .Include(x => x.RawMaterial)
                    .ToListAsync();
                return deliveryRawMaterialToProductionDetail;

                //var deliveryRawMaterialToProductionDetail = await _repositoryFactory.DeliveryRawMaterialToProductionDetail
                //    .Where(x => x.DeliveryRawMaterialToProductionID == deliveryRawMaterialToProductionId)
                //    .Include(x => x.RawMaterial)
                //    .ToListAsync();

                ////var deliveryRawMaterialToProductionDetail2 = await _repositoryFactory.DeliveryRawMaterialToProductionDetail
                ////    .Where(x => x.DeliveryRawMaterialToProductionID == deliveryRawMaterialToProductionId)
                ////    .Include(x => x.RawMaterial)
                ////    .Select(x=> new
                ////    {
                ////        x.DeliveryRawMaterialToProductionID
                ////    })
                ////    .ToListAsync();



                //var result = _repositoryFactory.DeliveryRawMaterialToProductionDetail.Table.Include(x => x.RawMaterial)
                //.Where(x => x.DeliveryRawMaterialToProductionID == deliveryRawMaterialToProductionId)
                //.GroupBy(x => new
                //{
                //    x.RawMaterialID,
                //    x.Planned,
                //    x.InvProduction,
                //    x.RemainingToProduction,
                //    x.Describe
                //})
                //.Select(x => new
                //{
                //    x.Key,
                //    //x.Key.,
                //    //x.Key.,


                //    //FieldName = x.Key,
                //    SumOfAnotherField = x.Sum(y => y.RequestedAmount)
                //}).ToList();
                ////.Select(x=> new
                ////{
                ////    x.FieldName.
                ////}).ToList();
                ////.Select(x => new
                ////{
                ////    FieldName = x.Key,
                ////    SumOfAnotherField = x.Sum(y => y.RequestedAmount)
                ////}).ToList();


                //return null;
            }
            catch (System.Exception ex)
            {
                throw;
            }
        }



    }
}
