using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PPC.Core.Interface;
using PPC.Core.Models;
using PPC.Core.Repository;
namespace PPC.Core.Services
{
    public class DataPatilService : BaseService, IDataPatilService
    {
        IUnitOfWork _unitOfWork;
        public DataPatilService(RepositoryFactory repositoryFactory,
            IUnitOfWork unitOfWork)
        {
            _repositoryFactory = repositoryFactory;
            _unitOfWork = unitOfWork;
        }


        public List<DataPatil> GetAll()
        {
            try
            {
                var dataPatil = _repositoryFactory.DataPatil.Table.ToList();

                return dataPatil;
            }
            catch
            {
                throw;
            }
        }

        public async Task<List<DataPatil>> GetAllAsync()
        {
            try
            {

                var dataPatil = await _repositoryFactory.DataPatil.Table.ToListAsync();
                return dataPatil;
            }
            catch (System.Exception ex)
            {
                throw;
            }
        }

        public DataPatil GetDataPatilById(int dataPatilID)
        {
            try
            {
                var dataPatil = _repositoryFactory.DataPatil
                    .FirstOrDefault(x => x.DataPatilID == dataPatilID);

                return dataPatil;
            }
            catch
            {
                throw;
            }
        }

        public async Task<DataPatil> GetDataPatilByIdAsync(int dataPatilID)
        {
            try
            {
                var dataPatil = await _repositoryFactory.DataPatil
                    .FirstOrDefaultAsync(x => x.DataPatilID == dataPatilID);

                return dataPatil;
            }
            catch
            {
                throw;
            }
        }

        public int Append(DataPatil dataPatil)
        {
            try
            {
                var _newObject = new DataPatil
                {
                    DataPatilID = dataPatil.DataPatilID,
                    DataProductionID = dataPatil.DataProductionID,
                    PatilID = dataPatil.PatilID,
                    Capacity = dataPatil.Capacity,
                    EmptyWeight = dataPatil.EmptyWeight,
                    AfterChargeWeight = dataPatil.AfterChargeWeight,
                    AfterFirstMixWeight = dataPatil.AfterFirstMixWeight,
                    DuringGrindingWeight = dataPatil.DuringGrindingWeight,
                    FinalWeight = dataPatil.FinalWeight,
                    NetWeight = dataPatil.NetWeight,
                    EditUserID = dataPatil.EditUserID,
                    EditDate = dataPatil.EditDate,
                    EditTime = dataPatil.EditTime,


                };

                _repositoryFactory.DataPatil.Add(_newObject);

                var statuse = _unitOfWork.Commit() > 0;

                if (statuse)
                    return _newObject.DataPatilID;
                else
                    return int.MinValue;
            }
            catch (System.Exception)
            {
                throw;
            }
        }


        public bool Update(DataPatil dataPatil)
        {
            try
            {

                _repositoryFactory.DataPatil.UpdateBy(x => x.DataPatilID == dataPatil.DataPatilID,
                    new DataPatil
                    {
                        DataPatilID = dataPatil.DataPatilID,
                        DataProductionID = dataPatil.DataProductionID,
                        PatilID = dataPatil.PatilID,
                        Capacity = dataPatil.Capacity,
                        EmptyWeight = dataPatil.EmptyWeight,
                        AfterChargeWeight = dataPatil.AfterChargeWeight,
                        AfterFirstMixWeight = dataPatil.AfterFirstMixWeight,
                        DuringGrindingWeight = dataPatil.DuringGrindingWeight,
                        FinalWeight = dataPatil.FinalWeight,
                        NetWeight = dataPatil.NetWeight,
                        EditUserID = dataPatil.EditUserID,
                        EditDate = dataPatil.EditDate,
                        EditTime = dataPatil.EditTime,


                    });
                var statuse = _unitOfWork.Commit() > 0;
                return statuse;
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }

        public long Delete(int dataPatilID)
        {
            try
            {
                var dataPatil = _repositoryFactory.DataPatil
                    .FirstOrDefault(x => x.DataPatilID == dataPatilID);

                if (dataPatil == null)
                    throw new System.Exception("DataPatil Notfound.");

                _repositoryFactory.DataPatil.Delete(dataPatil);
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
