using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PPC.Core.Interface;
using PPC.Core.Models;
using PPC.Core.Repository;
namespace PPC.Core.Services
{
    public class PatilsService : BaseService, IPatilsService
    {
        IUnitOfWork _unitOfWork;
        public PatilsService(RepositoryFactory repositoryFactory,
            IUnitOfWork unitOfWork)
        {
            _repositoryFactory = repositoryFactory;
            _unitOfWork = unitOfWork;
        }


        public List<Patils> GetAll()
        {
            try
            {
                var patils = _repositoryFactory.Patils.Table.ToList();

                return patils;
            }
            catch
            {
                throw;
            }
        }

        public async Task<List<Patils>> GetAllAsync()
        {
            try
            {

                var patils = await _repositoryFactory.Patils.Table.ToListAsync();
                return patils;
            }
            catch (System.Exception ex)
            {
                throw;
            }
        }

        public Patils GetPatilsById(int patilID)
        {
            try
            {
                var patils = _repositoryFactory.Patils
                    .FirstOrDefault(x => x.PatilID == patilID);

                return patils;
            }
            catch
            {
                throw;
            }
        }

        public async Task<Patils> GetPatilsByIdAsync(int patilID)
        {
            try
            {
                var patils = await _repositoryFactory.Patils
                    .FirstOrDefaultAsync(x => x.PatilID == patilID);

                return patils;
            }
            catch
            {
                throw;
            }
        }

        public int Append(Patils patils)
        {
            try
            {
                var _newObject = new Patils
                {
                    PatilID = patils.PatilID,
                    PatilNo = patils.PatilNo,
                    Capacity = patils.Capacity,
                    MinCapacity = patils.MinCapacity,
                    EmptyWeight = patils.EmptyWeight,
                    InUse = patils.InUse,
                    IsActive = patils.IsActive,


                };

                _repositoryFactory.Patils.Add(_newObject);

                var statuse = _unitOfWork.Commit() > 0;

                if (statuse)
                    return _newObject.PatilID;
                else
                    return int.MinValue;
            }
            catch (System.Exception)
            {
                throw;
            }
        }


        public bool Update(Patils patils)
        {
            try
            {

                _repositoryFactory.Patils.UpdateBy(x => x.PatilID == patils.PatilID,
                    new Patils
                    {
                        PatilID = patils.PatilID,
                        PatilNo = patils.PatilNo,
                        Capacity = patils.Capacity,
                        MinCapacity = patils.MinCapacity,
                        EmptyWeight = patils.EmptyWeight,
                        InUse = patils.InUse,
                        IsActive = patils.IsActive,


                    });
                var statuse = _unitOfWork.Commit() > 0;
                return statuse;
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }

        public long Delete(int patilID)
        {
            try
            {
                var patils = _repositoryFactory.Patils
                    .FirstOrDefault(x => x.PatilID == patilID);

                if (patils == null)
                    throw new System.Exception("Patils Notfound.");

                _repositoryFactory.Patils.Delete(patils);
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
