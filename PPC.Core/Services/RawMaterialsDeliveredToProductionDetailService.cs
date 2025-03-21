using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PPC.Core.Interface;
using PPC.Core.Models;
using PPC.Core.Repository;
namespace PPC.Core.Services
{
    public class RawMaterialsDeliveredToProductionDetailService : BaseService, IRawMaterialsDeliveredToProductionDetailService
    {
        IUnitOfWork _unitOfWork;
        public RawMaterialsDeliveredToProductionDetailService(RepositoryFactory repositoryFactory,
            IUnitOfWork unitOfWork)
        {
            _repositoryFactory = repositoryFactory;
            _unitOfWork = unitOfWork;
        }


        public List<RawMaterialsDeliveredToProductionDetail> GetAll()
        {
            try
            {
                var rawMaterialsDeliveredToProductionDetail = _repositoryFactory.RawMaterialsDeliveredToProductionDetail.Table.ToList();

                return rawMaterialsDeliveredToProductionDetail;
            }
            catch
            {
                throw;
            }
        }

        public async Task<List<RawMaterialsDeliveredToProductionDetail>> GetAllAsync()
        {
            try
            {

                var rawMaterialsDeliveredToProductionDetail = await _repositoryFactory.RawMaterialsDeliveredToProductionDetail.Table.ToListAsync();
                return rawMaterialsDeliveredToProductionDetail;
            }
            catch (System.Exception ex)
            {
                throw;
            }
        }

        public RawMaterialsDeliveredToProductionDetail GetRawMaterialsDeliveredToProductionDetailById(int rawMaterialsDeliveredToProductionDetailID)
        {
            try
            {
                var rawMaterialsDeliveredToProductionDetail = _repositoryFactory.RawMaterialsDeliveredToProductionDetail
                    .FirstOrDefault(x => x.RawMaterialsDeliveredToProductionDetailID == rawMaterialsDeliveredToProductionDetailID);

                return rawMaterialsDeliveredToProductionDetail;
            }
            catch
            {
                throw;
            }
        }

        public async Task<RawMaterialsDeliveredToProductionDetail> GetRawMaterialsDeliveredToProductionDetailByIdAsync(int rawMaterialsDeliveredToProductionDetailID)
        {
            try
            {
                var rawMaterialsDeliveredToProductionDetail = await _repositoryFactory.RawMaterialsDeliveredToProductionDetail
                    .FirstOrDefaultAsync(x => x.RawMaterialsDeliveredToProductionDetailID == rawMaterialsDeliveredToProductionDetailID);

                return rawMaterialsDeliveredToProductionDetail;
            }
            catch
            {
                throw;
            }
        }

        public int Append(RawMaterialsDeliveredToProductionDetail rawMaterialsDeliveredToProductionDetail)
        {
            try
            {
                var _newObject = new RawMaterialsDeliveredToProductionDetail
                {
                    RawMaterialsDeliveredToProductionDetailID = rawMaterialsDeliveredToProductionDetail.RawMaterialsDeliveredToProductionDetailID,
                    RawMaterialsDeliveredToProductionID = rawMaterialsDeliveredToProductionDetail.RawMaterialsDeliveredToProductionID,
                    RawMaterialID = rawMaterialsDeliveredToProductionDetail.RawMaterialID,
                    RequestedAmount = rawMaterialsDeliveredToProductionDetail.RequestedAmount,
                    DeliveredAmount = rawMaterialsDeliveredToProductionDetail.DeliveredAmount,
                    GeneralLotNumber = rawMaterialsDeliveredToProductionDetail.GeneralLotNumber,
                    Describe = rawMaterialsDeliveredToProductionDetail.Describe,


                };

                _repositoryFactory.RawMaterialsDeliveredToProductionDetail.Add(_newObject);

                var statuse = _unitOfWork.Commit() > 0;

                if (statuse)
                    return _newObject.RawMaterialsDeliveredToProductionDetailID;
                else
                    return int.MinValue;
            }
            catch (System.Exception)
            {
                throw;
            }
        }


        public bool Update(RawMaterialsDeliveredToProductionDetail rawMaterialsDeliveredToProductionDetail)
        {
            try
            {

                _repositoryFactory.RawMaterialsDeliveredToProductionDetail.UpdateBy(x => x.RawMaterialsDeliveredToProductionDetailID == rawMaterialsDeliveredToProductionDetail.RawMaterialsDeliveredToProductionDetailID,
                    new RawMaterialsDeliveredToProductionDetail
                    {
                        RawMaterialsDeliveredToProductionDetailID = rawMaterialsDeliveredToProductionDetail.RawMaterialsDeliveredToProductionDetailID,
                        RawMaterialsDeliveredToProductionID = rawMaterialsDeliveredToProductionDetail.RawMaterialsDeliveredToProductionID,
                        RawMaterialID = rawMaterialsDeliveredToProductionDetail.RawMaterialID,
                        RequestedAmount = rawMaterialsDeliveredToProductionDetail.RequestedAmount,
                        DeliveredAmount = rawMaterialsDeliveredToProductionDetail.DeliveredAmount,
                        GeneralLotNumber = rawMaterialsDeliveredToProductionDetail.GeneralLotNumber,
                        Describe = rawMaterialsDeliveredToProductionDetail.Describe,


                    });
                var statuse = _unitOfWork.Commit() > 0;
                return statuse;
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }

        public long Delete(int rawMaterialsDeliveredToProductionDetailID)
        {
            try
            {
                var rawMaterialsDeliveredToProductionDetail = _repositoryFactory.RawMaterialsDeliveredToProductionDetail
                    .FirstOrDefault(x => x.RawMaterialsDeliveredToProductionDetailID == rawMaterialsDeliveredToProductionDetailID);

                if (rawMaterialsDeliveredToProductionDetail == null)
                    throw new System.Exception("RawMaterialsDeliveredToProductionDetail Notfound.");

                _repositoryFactory.RawMaterialsDeliveredToProductionDetail.Delete(rawMaterialsDeliveredToProductionDetail);
                var statuse = _unitOfWork.Commit();

                return statuse;
            }
            catch
            {
                throw;
            }
        }



    }
}
