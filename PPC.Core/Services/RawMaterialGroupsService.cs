using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PPC.Core.Interface;

using PPC.Core.Models;

using PPC.Core.Repository;

namespace PPC.Core.Services
{
    public class RawMaterialGroupsService : BaseService, IRawMaterialGroupsService
    {
        IUnitOfWork _unitOfWork;
        public RawMaterialGroupsService(RepositoryFactory repositoryFactory,
            IUnitOfWork unitOfWork)
        {
            _repositoryFactory = repositoryFactory;
            _unitOfWork = unitOfWork;
        }


        public List<RawMaterialGroups> GetAll()
        {
            try
            {
                var rawMaterialGroups = _repositoryFactory.RawMaterialGroups.Table.Include(x => x.RawMaterialGroupType).ToList();

                return rawMaterialGroups;
            }
            catch
            {
                throw;
            }
        }

        public async Task<List<RawMaterialGroups>> GetAllAsync()
        {
            try
            {

                var rawMaterialGroups = await _repositoryFactory.RawMaterialGroups.Table.Include(x=>x.RawMaterialGroupType).ToListAsync();
                return rawMaterialGroups;
            }
            catch (System.Exception ex)
            {
                throw;
            }
        }

        public RawMaterialGroups GetRawMaterialGroupsById(short rawMaterialGroupID)
        {
            try
            {
                var rawMaterialGroups = _repositoryFactory.RawMaterialGroups.Table.Include(x => x.RawMaterialGroupType)
                    .FirstOrDefault(x => x.RawMaterialGroupID == rawMaterialGroupID);

                return rawMaterialGroups;
            }
            catch
            {
                throw;
            }
        }

        public async Task<RawMaterialGroups> GetRawMaterialGroupsByIdAsync(short rawMaterialGroupID)
        {
            try
            {
                var rawMaterialGroups = await _repositoryFactory.RawMaterialGroups.Table.Include(x => x.RawMaterialGroupType)
                    .FirstOrDefaultAsync(x => x.RawMaterialGroupID == rawMaterialGroupID);

                return rawMaterialGroups;
            }
            catch
            {
                throw;
            }
        }

        public bool Append(RawMaterialGroups rawMaterialGroups)
        {
            try
            {
                _repositoryFactory.RawMaterialGroups.Add(
                    new RawMaterialGroups
                    {
                        RawMaterialGroupID = rawMaterialGroups.RawMaterialGroupID,
                        RawMaterialGroupName = rawMaterialGroups.RawMaterialGroupName,
                        RawMaterialGroupLatinName = rawMaterialGroups.RawMaterialGroupLatinName,
                        RawMaterialGroupTypeID = rawMaterialGroups.RawMaterialGroupTypeID,
                        StorageConditions = rawMaterialGroups.StorageConditions,
                        IsActive = rawMaterialGroups.IsActive,


                    });
                var statuse = _unitOfWork.Commit() > 0;
                return statuse;
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }


        public bool Update(RawMaterialGroups rawMaterialGroups)
        {
            try
            {

                _repositoryFactory.RawMaterialGroups.UpdateBy(x => x.RawMaterialGroupID == rawMaterialGroups.RawMaterialGroupID,
                    new RawMaterialGroups
                    {
                        RawMaterialGroupID = rawMaterialGroups.RawMaterialGroupID,
                        RawMaterialGroupName = rawMaterialGroups.RawMaterialGroupName,
                        RawMaterialGroupLatinName = rawMaterialGroups.RawMaterialGroupLatinName,
                        RawMaterialGroupTypeID = rawMaterialGroups.RawMaterialGroupTypeID,
                        StorageConditions = rawMaterialGroups.StorageConditions,
                        IsActive = rawMaterialGroups.IsActive,


                    });
                var statuse = _unitOfWork.Commit() > 0;
                return statuse;
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }

        public long Delete(short rawMaterialGroupID)
        {
            try
            {
                var rawMaterialGroups = _repositoryFactory.RawMaterialGroups
                    .FirstOrDefault(x => x.RawMaterialGroupID == rawMaterialGroupID);

                if (rawMaterialGroups == null)
                    throw new System.Exception("RawMaterialGroups Notfound.");

                _repositoryFactory.RawMaterialGroups.Delete(rawMaterialGroups);
                var statuse = _unitOfWork.Commit();

                return statuse;
            }
            catch
            {
                throw;
            }
        }


        public async Task<bool> ExistRawMaterialGroupsAsync(string name)
        {
            try
            {

                return await _repositoryFactory.RawMaterialGroups.FirstOrDefaultAsync(x => x.RawMaterialGroupName.ToUpper() == name.ToUpper()) != null;
            }
            catch
            {
                throw;
            }
        }


    }
}
