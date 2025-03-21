using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PPC.Core.Interface;
using PPC.Core.Models;
using PPC.Core.Repository;
namespace PPC.Core.Services
{
    public class DataDosingDetailService : BaseService, IDataDosingDetailService
    {
        IUnitOfWork _unitOfWork;
        public DataDosingDetailService(RepositoryFactory repositoryFactory,
            IUnitOfWork unitOfWork)
        {
            _repositoryFactory = repositoryFactory;
            _unitOfWork = unitOfWork;
        }


        public List<DataDosingDetail> GetAll()
        {
            try
            {
                var dataDosingDetail = _repositoryFactory.DataDosingDetail.Table.ToList();

                return dataDosingDetail;
            }
            catch
            {
                throw;
            }
        }

        public async Task<List<DataDosingDetail>> GetAllAsync()
        {
            try
            {

                var dataDosingDetail = await _repositoryFactory.DataDosingDetail.Table.ToListAsync();
                return dataDosingDetail;
            }
            catch (System.Exception ex)
            {
                throw;
            }
        }

        public DataDosingDetail GetDataDosingDetailById(int dataDosingDetailID)
        {
            try
            {
                var dataDosingDetail = _repositoryFactory.DataDosingDetail
                    .FirstOrDefault(x => x.DataDosingDetailID == dataDosingDetailID);

                return dataDosingDetail;
            }
            catch
            {
                throw;
            }
        }

        public async Task<DataDosingDetail> GetDataDosingDetailByIdAsync(int dataDosingDetailID)
        {
            try
            {
                var dataDosingDetail = await _repositoryFactory.DataDosingDetail
                    .FirstOrDefaultAsync(x => x.DataDosingDetailID == dataDosingDetailID);

                return dataDosingDetail;
            }
            catch
            {
                throw;
            }
        }

        public int Append(DataDosingDetail dataDosingDetail)
        {
            try
            {
                var _newObject = new DataDosingDetail
                {
                    DataDosingDetailID = dataDosingDetail.DataDosingDetailID,
                    DataProductionID = dataDosingDetail.DataProductionID,
                    RawMaterialID = dataDosingDetail.RawMaterialID,
                    RawMaterialType = dataDosingDetail.RawMaterialType,
                    Priority = dataDosingDetail.Priority,
                    PlannedWeight = dataDosingDetail.PlannedWeight,
                    ChargedWeight = dataDosingDetail.ChargedWeight,
                    LotNumber = dataDosingDetail.LotNumber,
                    Wastes = dataDosingDetail.Wastes,
                    Operator = dataDosingDetail.Operator,
                    IsFinalRM = dataDosingDetail.IsFinalRM,
                    Describe = dataDosingDetail.Describe,


                };

                _repositoryFactory.DataDosingDetail.Add(_newObject);

                var statuse = _unitOfWork.Commit() > 0;

                if (statuse)
                    return _newObject.DataDosingDetailID;
                else
                    return int.MinValue;
            }
            catch (System.Exception)
            {
                throw;
            }
        }


        public bool Update(DataDosingDetail dataDosingDetail)
        {
            try
            {

                _repositoryFactory.DataDosingDetail.UpdateBy(x => x.DataDosingDetailID == dataDosingDetail.DataDosingDetailID,
                    new DataDosingDetail
                    {
                        DataDosingDetailID = dataDosingDetail.DataDosingDetailID,
                        DataProductionID = dataDosingDetail.DataProductionID,
                        RawMaterialID = dataDosingDetail.RawMaterialID,
                        RawMaterialType = dataDosingDetail.RawMaterialType,
                        Priority = dataDosingDetail.Priority,
                        PlannedWeight = dataDosingDetail.PlannedWeight,
                        ChargedWeight = dataDosingDetail.ChargedWeight,
                        LotNumber = dataDosingDetail.LotNumber,
                        Wastes = dataDosingDetail.Wastes,
                        Operator = dataDosingDetail.Operator,
                        IsFinalRM = dataDosingDetail.IsFinalRM,
                        Describe = dataDosingDetail.Describe,

                    });
                var statuse = _unitOfWork.Commit() > 0;
                return statuse;
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }

        public long Delete(int dataDosingDetailID)
        {
            try
            {
                var dataDosingDetail = _repositoryFactory.DataDosingDetail
                    .FirstOrDefault(x => x.DataDosingDetailID == dataDosingDetailID);

                if (dataDosingDetail == null)
                    throw new System.Exception("DataDosingDetail Notfound.");

                _repositoryFactory.DataDosingDetail.Delete(dataDosingDetail);
                var statuse = _unitOfWork.Commit();

                return statuse;
            }
            catch
            {
                throw;
            }
        }

        public async Task<List<DataDosingDetail>> GetListByDataProductionIdAsync(int dataProductionId)
        {
            try
            {

                var dataDosingDetail = await _repositoryFactory.DataDosingDetail
                    .Where(x => x.DataProductionID == dataProductionId)
                    .Include(x => x.DataProduction).ThenInclude(x => x.ProductionPlanPatil).ThenInclude(x => x.ProductionPlan)
                    .Include(x => x.RawMaterial)

                    .ToListAsync();
                return dataDosingDetail;
            }
            catch (System.Exception ex)
            {
                throw;
            }
        }

    }
}
