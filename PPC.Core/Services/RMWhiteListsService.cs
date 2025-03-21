using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PPC.Core.Interface;
using PPC.Core.Models;
using PPC.Core.Repository;

namespace PPC.Core.Services
{
    public class RMWhiteListsService : BaseService, IRMWhiteListsService
    {
        IUnitOfWork _unitOfWork;
        public RMWhiteListsService(RepositoryFactory repositoryFactory,
            IUnitOfWork unitOfWork)
        {
            _repositoryFactory = repositoryFactory;
            _unitOfWork = unitOfWork;
        }


        public List<RMWhiteLists> GetAll()
        {
            try
            {
                var rMWhiteLists = _repositoryFactory.RMWhiteLists.Table.ToList();

                return rMWhiteLists;
            }
            catch
            {
                throw;
            }
        }

        public async Task<List<RMWhiteLists>> GetAllAsync()
        {
            try
            {

                var rMWhiteLists = await _repositoryFactory.RMWhiteLists.Table.ToListAsync();
                return rMWhiteLists;
            }
            catch (System.Exception ex)
            {
                throw;
            }
        }

        public RMWhiteLists GetRMWhiteListsById(int rMWhiteListID)
        {
            try
            {
                var rMWhiteLists = _repositoryFactory.RMWhiteLists
                    .FirstOrDefault(x => x.RMWhiteListID == rMWhiteListID);

                return rMWhiteLists;
            }
            catch
            {
                throw;
            }
        }

        public async Task<RMWhiteLists> GetRMWhiteListsByIdAsync(int rMWhiteListID)
        {
            try
            {
                var rMWhiteLists = await _repositoryFactory.RMWhiteLists
                    .FirstOrDefaultAsync(x => x.RMWhiteListID == rMWhiteListID);

                return rMWhiteLists;
            }
            catch
            {
                throw;
            }
        }

        public int Append(RMWhiteLists rMWhiteLists)
        {
            try
            {
                var _newObject = new RMWhiteLists
                {
                    RMWhiteListID = rMWhiteLists.RMWhiteListID,
                    RMWhiteListCode = rMWhiteLists.RMWhiteListCode,
                    RMWhiteListName = rMWhiteLists.RMWhiteListName,
                    IsActive = rMWhiteLists.IsActive,


                };

                _repositoryFactory.RMWhiteLists.Add(_newObject);

                var statuse = _unitOfWork.Commit() > 0;

                if (statuse)
                    return _newObject.RMWhiteListID;
                else
                    return int.MinValue;
            }
            catch (System.Exception)
            {
                throw;
            }
        }


        public bool Update(RMWhiteLists rMWhiteLists)
        {
            try
            {

                _repositoryFactory.RMWhiteLists.UpdateBy(x => x.RMWhiteListID == rMWhiteLists.RMWhiteListID,
                    new RMWhiteLists
                    {
                        RMWhiteListID = rMWhiteLists.RMWhiteListID,
                        RMWhiteListCode = rMWhiteLists.RMWhiteListCode,
                        RMWhiteListName = rMWhiteLists.RMWhiteListName,
                        IsActive = rMWhiteLists.IsActive,


                    });
                var statuse = _unitOfWork.Commit() > 0;
                return statuse;
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }

        public long Delete(int rMWhiteListID)
        {
            try
            {
                var rMWhiteLists = _repositoryFactory.RMWhiteLists
                    .FirstOrDefault(x => x.RMWhiteListID == rMWhiteListID);

                if (rMWhiteLists == null)
                    throw new System.Exception("RMWhiteLists Notfound.");

                _repositoryFactory.RMWhiteLists.Delete(rMWhiteLists);
                var statuse = _unitOfWork.Commit();

                return statuse;
            }
            catch
            {
                throw;
            }
        }


        public async Task<RMWhiteLists> GetByCodeAsync(string code)
        {
            try
            {

                return await _repositoryFactory.RMWhiteLists.FirstOrDefaultAsync(x => x.RMWhiteListCode.ToUpper() == code.ToUpper()) ;
            }
            catch
            {
                throw;
            }
        }

        public async Task<List<RMWhiteLists>> GetAllForDropDownAsync()
        {
            try
            {
                var rmWhiteList = await _repositoryFactory.RMWhiteLists.Table
                    .Include(x => x.ProductSerie)
                    .ToListAsync();
                return rmWhiteList;
            }
            catch (System.Exception ex)
            {
                throw;
            }
        }




    }
}
