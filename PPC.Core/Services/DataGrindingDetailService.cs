using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PPC.Core.Interface;
using PPC.Core.Models;
using PPC.Core.Repository;
namespace PPC.Core.Services
{
    public class DataGrindingDetailService : BaseService, IDataGrindingDetailService
    {
        IUnitOfWork _unitOfWork;
        public DataGrindingDetailService(RepositoryFactory repositoryFactory,
            IUnitOfWork unitOfWork)
        {
            _repositoryFactory = repositoryFactory;
            _unitOfWork = unitOfWork;
        }


        public List<DataGrindingDetail> GetAll()
        {
            try
            {
                var dataGrindingDetail = _repositoryFactory.DataGrindingDetail.Table.ToList();

                return dataGrindingDetail;
            }
            catch
            {
                throw;
            }
        }

        public async Task<List<DataGrindingDetail>> GetAllAsync()
        {
            try
            {

                var dataGrindingDetail = await _repositoryFactory.DataGrindingDetail.Table.ToListAsync();
                return dataGrindingDetail;
            }
            catch (System.Exception ex)
            {
                throw;
            }
        }

        public DataGrindingDetail GetDataGrindingDetailById(int dataGrindingDetailID)
        {
            try
            {
                var dataGrindingDetail = _repositoryFactory.DataGrindingDetail
                    .FirstOrDefault(x => x.DataGrindingDetailID == dataGrindingDetailID);

                return dataGrindingDetail;
            }
            catch
            {
                throw;
            }
        }

        public async Task<DataGrindingDetail> GetDataGrindingDetailByIdAsync(int dataGrindingDetailID)
        {
            try
            {
                var dataGrindingDetail = await _repositoryFactory.DataGrindingDetail
                    .FirstOrDefaultAsync(x => x.DataGrindingDetailID == dataGrindingDetailID);

                return dataGrindingDetail;
            }
            catch
            {
                throw;
            }
        }

        public int Append(DataGrindingDetail dataGrindingDetail)
        {
            try
            {
                var _newObject = new DataGrindingDetail
                {
                    DataGrindingDetailID = dataGrindingDetail.DataGrindingDetailID,
                    DataProductionID = dataGrindingDetail.DataProductionID,
                    Date = dataGrindingDetail.Date,
                    Time = dataGrindingDetail.Time,
                    DateTimeSaveDistance = dataGrindingDetail.DateTimeSaveDistance,
                    PressurePump = dataGrindingDetail.PressurePump,
                    MaterialFlowSpeed = dataGrindingDetail.MaterialFlowSpeed,
                    Duration = dataGrindingDetail.Duration,
                    GrindingSpeed = dataGrindingDetail.GrindingSpeed,
                    EnginePower = dataGrindingDetail.EnginePower,
                    MaterialTemp = dataGrindingDetail.MaterialTemp,
                    MixerSpeed = dataGrindingDetail.MixerSpeed,
                    Operator = dataGrindingDetail.Operator,
                    Energy = dataGrindingDetail.Energy,
                    RotorSpeed = dataGrindingDetail.RotorSpeed,
                    Describe = dataGrindingDetail.Describe,


                };

                _repositoryFactory.DataGrindingDetail.Add(_newObject);

                var statuse = _unitOfWork.Commit() > 0;

                if (statuse)
                    return _newObject.DataGrindingDetailID;
                else
                    return int.MinValue;
            }
            catch (System.Exception)
            {
                throw;
            }
        }


        public bool Update(DataGrindingDetail dataGrindingDetail)
        {
            try
            {

                _repositoryFactory.DataGrindingDetail.UpdateBy(x => x.DataGrindingDetailID == dataGrindingDetail.DataGrindingDetailID,
                    new DataGrindingDetail
                    {
                        DataGrindingDetailID = dataGrindingDetail.DataGrindingDetailID,
                        DataProductionID = dataGrindingDetail.DataProductionID,
                        Date = dataGrindingDetail.Date,
                        Time = dataGrindingDetail.Time,
                        DateTimeSaveDistance = dataGrindingDetail.DateTimeSaveDistance,
                        PressurePump = dataGrindingDetail.PressurePump,
                        MaterialFlowSpeed = dataGrindingDetail.MaterialFlowSpeed,
                        Duration = dataGrindingDetail.Duration,
                        GrindingSpeed = dataGrindingDetail.GrindingSpeed,
                        EnginePower = dataGrindingDetail.EnginePower,
                        MaterialTemp = dataGrindingDetail.MaterialTemp,
                        MixerSpeed = dataGrindingDetail.MixerSpeed,
                        Operator = dataGrindingDetail.Operator,
                        Energy = dataGrindingDetail.Energy,
                        RotorSpeed = dataGrindingDetail.RotorSpeed,
                        Describe = dataGrindingDetail.Describe,


                    });
                var statuse = _unitOfWork.Commit() > 0;
                return statuse;
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }

        public long Delete(int dataGrindingDetailID)
        {
            try
            {
                var dataGrindingDetail = _repositoryFactory.DataGrindingDetail
                    .FirstOrDefault(x => x.DataGrindingDetailID == dataGrindingDetailID);

                if (dataGrindingDetail == null)
                    throw new System.Exception("DataGrindingDetail Notfound.");

                _repositoryFactory.DataGrindingDetail.Delete(dataGrindingDetail);
                var statuse = _unitOfWork.Commit();

                return statuse;
            }
            catch
            {
                throw;
            }
        }


        public async Task<List<DataGrindingDetail>> GetListByDataProductionIdAsync(int dataProductionId)
        {
            try
            {

                var dataGrindingDetail = await _repositoryFactory.DataGrindingDetail
                    .Where(x => x.DataProductionID == dataProductionId)
                    .Include(x => x.DataProduction)
                    .ToListAsync();
                return dataGrindingDetail;
            }
            catch (System.Exception ex)
            {
                throw;
            }
        }


    }
}
