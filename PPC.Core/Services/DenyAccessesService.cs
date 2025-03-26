using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebApi.Core.Interface;

using WebApi.Core.Models;

using WebApi.Core.Repository;

namespace WebApi.Core.Services
{
    public class DenyAccessesService : BaseService, IDenyAccessesService
    {
        IUnitOfWork _unitOfWork;
        public DenyAccessesService(WebApi.Core.Repository.RepositoryFactory repositoryFactory,
            IUnitOfWork unitOfWork)
        {
            _repositoryFactory = repositoryFactory;
            _unitOfWork = unitOfWork;
        }


        public List<DenyAccesses> GetAll()
        {
            try
            {
                var denyAccesses = _repositoryFactory.DenyAccesses.Table.ToList();

                return denyAccesses;
            }
            catch
            {
                throw;
            }
        }

        public async Task<List<DenyAccesses>> GetAllAsync()
        {
            try
            {

                var denyAccesses = await _repositoryFactory.DenyAccesses.Table.ToListAsync();
                return denyAccesses;
            }
            catch (System.Exception ex)
            {
                throw;
            }
        }

        public DenyAccesses GetDenyAccessesById(int denyAccessID)
        {
            try
            {
                var denyAccesses = _repositoryFactory.DenyAccesses
                    .FirstOrDefault(x => x.DenyAccessID == denyAccessID);

                return denyAccesses;
            }
            catch
            {
                throw;
            }
        }

        public async Task<DenyAccesses> GetDenyAccessesByIdAsync(int denyAccessID)
        {
            try
            {
                var denyAccesses = await _repositoryFactory.DenyAccesses
                    .FirstOrDefaultAsync(x => x.DenyAccessID == denyAccessID);

                return denyAccesses;
            }
            catch
            {
                throw;
            }
        }

        public bool Append(DenyAccesses denyAccesses)
        {
            try
            {
                _repositoryFactory.DenyAccesses.Add(
                    new DenyAccesses
                    {
                        DenyAccessID = denyAccesses.DenyAccessID,
                        UserID = denyAccesses.UserID,
                        StationID = denyAccesses.StationID,
                        MenuGroupID = denyAccesses.MenuGroupID,
                        MenuID = denyAccesses.MenuID,
                        MenuName = denyAccesses.MenuName,
                        Caption = denyAccesses.Caption,
                        CaptionPath = denyAccesses.CaptionPath,
                        State = denyAccesses.State,


                    });
                var statuse = _unitOfWork.Commit() > 0;
                return statuse;
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }


        public bool Update(DenyAccesses denyAccesses)
        {
            try
            {

                _repositoryFactory.DenyAccesses.UpdateBy(x => x.DenyAccessID == denyAccesses.DenyAccessID,
                    new DenyAccesses
                    {
                        DenyAccessID = denyAccesses.DenyAccessID,
                        UserID = denyAccesses.UserID,
                        StationID = denyAccesses.StationID,
                        MenuGroupID = denyAccesses.MenuGroupID,
                        MenuID = denyAccesses.MenuID,
                        MenuName = denyAccesses.MenuName,
                        Caption = denyAccesses.Caption,
                        CaptionPath = denyAccesses.CaptionPath,
                        State = denyAccesses.State,


                    });
                var statuse = _unitOfWork.Commit() > 0;
                return statuse;
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }

        public long Delete(int denyAccessID)
        {
            try
            {
                var denyAccesses = _repositoryFactory.DenyAccesses
                    .FirstOrDefault(x => x.DenyAccessID == denyAccessID);

                if (denyAccesses == null)
                    throw new System.Exception("DenyAccesses Notfound.");

                _repositoryFactory.DenyAccesses.Delete(denyAccesses);
                var statuse = _unitOfWork.Commit();

                return statuse;
            }
            catch
            {
                throw;
            }
        }


        public async Task<bool> ExistDenyAccessesAsync(string name)
        {
            try
            {

                return await _repositoryFactory.DenyAccesses.FirstOrDefaultAsync(x => x.MenuName.ToUpper() == name.ToUpper()) != null;
            }
            catch
            {
                throw;
            }
        }

        public async Task<List<DenyAccesses>> GetAllByUserIdAsync(int userId)
        {
            try
            {
                var denyAccesses = await _repositoryFactory.DenyAccesses.Table.Where(x=>x.UserID == userId).ToListAsync();
                return denyAccesses;
            }
            catch (System.Exception ex)
            {
                throw;
            }
        }

        public async Task<List<DenyAccesses>> GetAllByStationIdAsync(int stationId)
        {
            try
            {
                var denyAccesses = await _repositoryFactory.DenyAccesses.Table.Where(x=>x.StationID == stationId).ToListAsync();
                return denyAccesses;
            }
            catch (System.Exception ex)
            {
                throw;
            }
        }

        public long DeleteByUserIfExists(int userId)
        {
            try
            {
                var denyAccesses = _repositoryFactory.DenyAccesses
                    .Where(x => x.UserID == userId).ToList();

                if (denyAccesses == null)
                    return 0;

                denyAccesses.ForEach(x =>
                _repositoryFactory.DenyAccesses.Delete(x));
                var statuse = _unitOfWork.Commit();

                return statuse;
            }
            catch
            {
                throw;
            }
        }

        public long DeleteByStationIfExists(int stationId)
        {
            try
            {
                var denyAccesses = _repositoryFactory.DenyAccesses
                    .Where(x => x.StationID == stationId).ToList();

                if (denyAccesses == null)
                    return 0;

                denyAccesses.ForEach(x =>
                _repositoryFactory.DenyAccesses.Delete(x));
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
