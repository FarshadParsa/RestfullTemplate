using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PPC.Core.Interface;
using PPC.Core.Models;
using PPC.Core.Repository;
namespace PPC.Core.Services
{
    public class DataPremixService : BaseService, IDataPremixService
    {
        IUnitOfWork _unitOfWork;
        public DataPremixService(RepositoryFactory repositoryFactory,
            IUnitOfWork unitOfWork)
        {
            _repositoryFactory = repositoryFactory;
            _unitOfWork = unitOfWork;
        }


        public List<DataPremix> GetAll()
        {
            try
            {
                var dataPremix = _repositoryFactory.DataPremix.Table.ToList();

                return dataPremix;
            }
            catch
            {
                throw;
            }
        }

        public async Task<List<DataPremix>> GetAllAsync()
        {
            try
            {

                var dataPremix = await _repositoryFactory.DataPremix.Table.ToListAsync();
                return dataPremix;
            }
            catch (System.Exception ex)
            {
                throw;
            }
        }

        public DataPremix GetDataPremixById(int dataPremixID)
        {
            try
            {
                var dataPremix = _repositoryFactory.DataPremix
                    .FirstOrDefault(x => x.DataPremixID == dataPremixID);

                return dataPremix;
            }
            catch
            {
                throw;
            }
        }

        public async Task<DataPremix> GetDataPremixByIdAsync(int dataPremixID)
        {
            try
            {
                var dataPremix = await _repositoryFactory.DataPremix
                    .FirstOrDefaultAsync(x => x.DataPremixID == dataPremixID);

                return dataPremix;
            }
            catch
            {
                throw;
            }
        }

        public int Append(DataPremix dataPremix)
        {
            try
            {
                var _newObject = new DataPremix
                {
                    DataPremixID = dataPremix.DataPremixID,
                    DataProductionID = dataPremix.DataProductionID,
                    StationID = dataPremix.StationID,
                    StartDate = dataPremix.StartDate,
                    StartTime = dataPremix.StartTime,
                    EndDate = dataPremix.EndDate,
                    EndTime = dataPremix.EndTime,
                    Duration = dataPremix.Duration,
                    ShiftNo = dataPremix.ShiftNo,
                    Operators = dataPremix.Operators,
                    Wastes = dataPremix.Wastes,
                    Stopes = dataPremix.Stopes,
                    StopesDesc = dataPremix.StopesDesc,
                    StationSpeed = dataPremix.StationSpeed,
                    Describe = dataPremix.Describe,
                    EditUserID = dataPremix.EditUserID,
                    EditDate = dataPremix.EditDate,
                    EditTime = dataPremix.EditTime,


                };

                _repositoryFactory.DataPremix.Add(_newObject);

                var statuse = _unitOfWork.Commit() > 0;

                if (statuse)
                    return _newObject.DataPremixID;
                else
                    return int.MinValue;
            }
            catch (System.Exception)
            {
                throw;
            }
        }


        public bool Update(DataPremix dataPremix)
        {
            try
            {

                _repositoryFactory.DataPremix.UpdateBy(x => x.DataPremixID == dataPremix.DataPremixID,
                    new DataPremix
                    {
                        DataPremixID = dataPremix.DataPremixID,
                        DataProductionID = dataPremix.DataProductionID,
                        StationID = dataPremix.StationID,
                        StartDate = dataPremix.StartDate,
                        StartTime = dataPremix.StartTime,
                        EndDate = dataPremix.EndDate,
                        EndTime = dataPremix.EndTime,
                        Duration = dataPremix.Duration,
                        ShiftNo = dataPremix.ShiftNo,
                        Operators = dataPremix.Operators,
                        Wastes = dataPremix.Wastes,
                        Stopes = dataPremix.Stopes,
                        StopesDesc = dataPremix.StopesDesc,
                        StationSpeed = dataPremix.StationSpeed,
                        Describe = dataPremix.Describe,
                        EditUserID = dataPremix.EditUserID,
                        EditDate = dataPremix.EditDate,
                        EditTime = dataPremix.EditTime,


                    });
                var statuse = _unitOfWork.Commit() > 0;
                return statuse;
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }

        public long Delete(int dataPremixID)
        {
            try
            {
                var dataPremix = _repositoryFactory.DataPremix
                    .FirstOrDefault(x => x.DataPremixID == dataPremixID);

                if (dataPremix == null)
                    throw new System.Exception("DataPremix Notfound.");

                _repositoryFactory.DataPremix.Delete(dataPremix);
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
