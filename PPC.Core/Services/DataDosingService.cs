using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PPC.Core.Interface;
using PPC.Core.Models;
using PPC.Core.Repository;
namespace PPC.Core.Services
{
    public class DataDosingService : BaseService, IDataDosingService
    {
        IUnitOfWork _unitOfWork;
        public DataDosingService(RepositoryFactory repositoryFactory,
            IUnitOfWork unitOfWork)
        {
            _repositoryFactory = repositoryFactory;
            _unitOfWork = unitOfWork;
        }


        public List<DataDosing> GetAll()
        {
            try
            {
                var dataDosing = _repositoryFactory.DataDosing.Table.ToList();

                return dataDosing;
            }
            catch
            {
                throw;
            }
        }

        public async Task<List<DataDosing>> GetAllAsync()
        {
            try
            {

                var dataDosing = await _repositoryFactory.DataDosing.Table.ToListAsync();
                return dataDosing;
            }
            catch (System.Exception ex)
            {
                throw;
            }
        }

        public DataDosing GetDataDosingById(int dataDosingID)
        {
            try
            {
                var dataDosing = _repositoryFactory.DataDosing
                    .FirstOrDefault(x => x.DataDosingID == dataDosingID);

                return dataDosing;
            }
            catch
            {
                throw;
            }
        }

        public async Task<DataDosing> GetDataDosingByIdAsync(int dataDosingID)
        {
            try
            {
                var dataDosing = await _repositoryFactory.DataDosing
                    .FirstOrDefaultAsync(x => x.DataDosingID == dataDosingID);

                return dataDosing;
            }
            catch
            {
                throw;
            }
        }

        public int Append(DataDosing dataDosing)
        {
            try
            {
                var _newObject = new DataDosing
                {
                    DataDosingID = dataDosing.DataDosingID,
                    DataProductionID = dataDosing.DataProductionID,
                    StartDate = dataDosing.StartDate,
                    StartTime = dataDosing.StartTime,
                    EndDate = dataDosing.EndDate,
                    EndTime = dataDosing.EndTime,
                    Duration = dataDosing.Duration,
                    WeighbridgeNo = dataDosing.WeighbridgeNo,
                    ShiftNo = dataDosing.ShiftNo,
                    Operators = dataDosing.Operators,
                    Wastes = dataDosing.Wastes,
                    Stopes = dataDosing.Stopes,
                    StopesDesc = dataDosing.StopesDesc,
                    Describe = dataDosing.Describe,
                    EditUserID = dataDosing.EditUserID,
                    EditDate = dataDosing.EditDate,
                    EditTime = dataDosing.EditTime,


                };

                _repositoryFactory.DataDosing.Add(_newObject);

                var statuse = _unitOfWork.Commit() > 0;

                if (statuse)
                    return _newObject.DataDosingID;
                else
                    return int.MinValue;
            }
            catch (System.Exception)
            {
                throw;
            }
        }


        public bool Update(DataDosing dataDosing)
        {
            try
            {

                _repositoryFactory.DataDosing.UpdateBy(x => x.DataDosingID == dataDosing.DataDosingID,
                    new DataDosing
                    {
                        DataDosingID = dataDosing.DataDosingID,
                        DataProductionID = dataDosing.DataProductionID,
                        StartDate = dataDosing.StartDate,
                        StartTime = dataDosing.StartTime,
                        EndDate = dataDosing.EndDate,
                        EndTime = dataDosing.EndTime,
                        Duration = dataDosing.Duration,
                        WeighbridgeNo = dataDosing.WeighbridgeNo,
                        ShiftNo = dataDosing.ShiftNo,
                        Operators = dataDosing.Operators,
                        Wastes = dataDosing.Wastes,
                        Stopes = dataDosing.Stopes,
                        StopesDesc = dataDosing.StopesDesc,
                        Describe = dataDosing.Describe,
                        EditUserID = dataDosing.EditUserID,
                        EditDate = dataDosing.EditDate,
                        EditTime = dataDosing.EditTime,


                    });
                var statuse = _unitOfWork.Commit() > 0;
                return statuse;
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }

        public long Delete(int dataDosingID)
        {
            try
            {
                var dataDosing = _repositoryFactory.DataDosing
                    .FirstOrDefault(x => x.DataDosingID == dataDosingID);

                if (dataDosing == null)
                    throw new System.Exception("DataDosing Notfound.");

                _repositoryFactory.DataDosing.Delete(dataDosing);
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
