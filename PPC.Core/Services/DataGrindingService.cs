using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PPC.Core.Interface;
using PPC.Core.Models;
using PPC.Core.Repository;
namespace PPC.Core.Services
{
    public class DataGrindingService : BaseService, IDataGrindingService
    {
        IUnitOfWork _unitOfWork;
        public DataGrindingService(RepositoryFactory repositoryFactory,
            IUnitOfWork unitOfWork)
        {
            _repositoryFactory = repositoryFactory;
            _unitOfWork = unitOfWork;
        }


        public List<DataGrinding> GetAll()
        {
            try
            {
                var dataGrinding = _repositoryFactory.DataGrinding.Table.ToList();

                return dataGrinding;
            }
            catch
            {
                throw;
            }
        }

        public async Task<List<DataGrinding>> GetAllAsync()
        {
            try
            {

                var dataGrinding = await _repositoryFactory.DataGrinding.Table.ToListAsync();
                return dataGrinding;
            }
            catch (System.Exception ex)
            {
                throw;
            }
        }

        public DataGrinding GetDataGrindingById(int dataGrindingID)
        {
            try
            {
                var dataGrinding = _repositoryFactory.DataGrinding
                    .FirstOrDefault(x => x.DataGrindingID == dataGrindingID);

                return dataGrinding;
            }
            catch
            {
                throw;
            }
        }

        public async Task<DataGrinding> GetDataGrindingByIdAsync(int dataGrindingID)
        {
            try
            {
                var dataGrinding = await _repositoryFactory.DataGrinding
                    .FirstOrDefaultAsync(x => x.DataGrindingID == dataGrindingID);

                return dataGrinding;
            }
            catch
            {
                throw;
            }
        }

        public int Append(DataGrinding dataGrinding)
        {
            try
            {
                var _newObject = new DataGrinding
                {
                    DataGrindingID = dataGrinding.DataGrindingID,
                    DataProductionID = dataGrinding.DataProductionID,
                    StationID = dataGrinding.StationID,
                    StartDate = dataGrinding.StartDate,
                    StartTime = dataGrinding.StartTime,
                    EndDate = dataGrinding.EndDate,
                    EndTime = dataGrinding.EndTime,
                    Duration = dataGrinding.Duration,
                    ShiftNo = dataGrinding.ShiftNo,
                    Operators = dataGrinding.Operators,
                    Stopes = dataGrinding.Stopes,
                    StopesDesc = dataGrinding.StopesDesc,
                    StationSpeed = dataGrinding.StationSpeed,
                    Describe = dataGrinding.Describe,
                    EditUserID = dataGrinding.EditUserID,
                    EditDate = dataGrinding.EditDate,
                    EditTime = dataGrinding.EditTime,


                };

                _repositoryFactory.DataGrinding.Add(_newObject);

                var statuse = _unitOfWork.Commit() > 0;

                if (statuse)
                    return _newObject.DataGrindingID;
                else
                    return int.MinValue;
            }
            catch (System.Exception)
            {
                throw;
            }
        }


        public bool Update(DataGrinding dataGrinding)
        {
            try
            {

                _repositoryFactory.DataGrinding.UpdateBy(x => x.DataGrindingID == dataGrinding.DataGrindingID,
                    new DataGrinding
                    {
                        DataGrindingID = dataGrinding.DataGrindingID,
                        DataProductionID = dataGrinding.DataProductionID,
                        StationID = dataGrinding.StationID,
                        StartDate = dataGrinding.StartDate,
                        StartTime = dataGrinding.StartTime,
                        EndDate = dataGrinding.EndDate,
                        EndTime = dataGrinding.EndTime,
                        Duration = dataGrinding.Duration,
                        ShiftNo = dataGrinding.ShiftNo,
                        Operators = dataGrinding.Operators,
                        Stopes = dataGrinding.Stopes,
                        StopesDesc = dataGrinding.StopesDesc,
                        StationSpeed = dataGrinding.StationSpeed,
                        Describe = dataGrinding.Describe,
                        EditUserID = dataGrinding.EditUserID,
                        EditDate = dataGrinding.EditDate,
                        EditTime = dataGrinding.EditTime,


                    });
                var statuse = _unitOfWork.Commit() > 0;
                return statuse;
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }

        public long Delete(int dataGrindingID)
        {
            try
            {
                var dataGrinding = _repositoryFactory.DataGrinding
                    .FirstOrDefault(x => x.DataGrindingID == dataGrindingID);

                if (dataGrinding == null)
                    throw new System.Exception("DataGrinding Notfound.");

                _repositoryFactory.DataGrinding.Delete(dataGrinding);
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

