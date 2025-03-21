using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PPC.Core.Interface;
using PPC.Core.Models;
using PPC.Core.Repository;
namespace PPC.Core.Services
{
    public class RawMaterialWhiteListAssignService : BaseService, IRawMaterialWhiteListAssignService
    {
        IUnitOfWork _unitOfWork;
        public RawMaterialWhiteListAssignService(RepositoryFactory repositoryFactory,
            IUnitOfWork unitOfWork)
        {
            _repositoryFactory = repositoryFactory;
            _unitOfWork = unitOfWork;
        }


        public List<RawMaterialWhiteListAssign> GetAll()
        {
            try
            {
                var rawMaterialWhiteListAssign = _repositoryFactory.RawMaterialWhiteListAssign.Table.ToList();

                return rawMaterialWhiteListAssign;
            }
            catch
            {
                throw;
            }
        }

        public async Task<List<RawMaterialWhiteListAssign>> GetAllAsync()
        {
            try
            {

                var rawMaterialWhiteListAssign = await _repositoryFactory.RawMaterialWhiteListAssign.Table.ToListAsync();
                return rawMaterialWhiteListAssign;
            }
            catch (System.Exception ex)
            {
                throw;
            }
        }

        public RawMaterialWhiteListAssign GetRawMaterialWhiteListAssignById(int rawMaterialWhiteListAssignID)
        {
            try
            {
                var rawMaterialWhiteListAssign = _repositoryFactory.RawMaterialWhiteListAssign
                    .FirstOrDefault(x => x.RawMaterialWhiteListAssignID == rawMaterialWhiteListAssignID);

                return rawMaterialWhiteListAssign;
            }
            catch
            {
                throw;
            }
        }

        public async Task<RawMaterialWhiteListAssign> GetRawMaterialWhiteListAssignByIdAsync(int rawMaterialWhiteListAssignID)
        {
            try
            {
                var rawMaterialWhiteListAssign = await _repositoryFactory.RawMaterialWhiteListAssign
                    .FirstOrDefaultAsync(x => x.RawMaterialWhiteListAssignID == rawMaterialWhiteListAssignID);

                return rawMaterialWhiteListAssign;
            }
            catch
            {
                throw;
            }
        }

        public int Append(RawMaterialWhiteListAssign rawMaterialWhiteListAssign)
        {
            try
            {
                var _newObject = new RawMaterialWhiteListAssign
                {
                    RawMaterialWhiteListAssignID = rawMaterialWhiteListAssign.RawMaterialWhiteListAssignID,
                    RawMaterialID = rawMaterialWhiteListAssign.RawMaterialID,
                    RMWhiteListID = rawMaterialWhiteListAssign.RMWhiteListID,


                };

                _repositoryFactory.RawMaterialWhiteListAssign.Add(_newObject);

                var statuse = _unitOfWork.Commit() > 0;

                if (statuse)
                    return _newObject.RawMaterialWhiteListAssignID;
                else
                    return int.MinValue;
            }
            catch (System.Exception)
            {
                throw;
            }
        }


        public bool Update(RawMaterialWhiteListAssign rawMaterialWhiteListAssign)
        {
            try
            {

                _repositoryFactory.RawMaterialWhiteListAssign.UpdateBy(x => x.RawMaterialWhiteListAssignID == rawMaterialWhiteListAssign.RawMaterialWhiteListAssignID,
                    new RawMaterialWhiteListAssign
                    {
                        RawMaterialWhiteListAssignID = rawMaterialWhiteListAssign.RawMaterialWhiteListAssignID,
                        RawMaterialID = rawMaterialWhiteListAssign.RawMaterialID,
                        RMWhiteListID = rawMaterialWhiteListAssign.RMWhiteListID,


                    });
                var statuse = _unitOfWork.Commit() > 0;
                return statuse;
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }

        public long Delete(int rawMaterialWhiteListAssignID)
        {
            try
            {
                var rawMaterialWhiteListAssign = _repositoryFactory.RawMaterialWhiteListAssign
                    .FirstOrDefault(x => x.RawMaterialWhiteListAssignID == rawMaterialWhiteListAssignID);

                if (rawMaterialWhiteListAssign == null)
                    throw new System.Exception("RawMaterialWhiteListAssign Notfound.");

                _repositoryFactory.RawMaterialWhiteListAssign.Delete(rawMaterialWhiteListAssign);
                var statuse = _unitOfWork.Commit();

                return statuse;
            }
            catch
            {
                throw;
            }
        }


        /// <summary>
        /// get all of material list with whitelist id, null= all materials
        /// </summary>
        /// <param name="id">whitelist id</param>
        /// <returns></returns>
        public async Task<List<RawMaterialWhiteListAssign>> GetListByWhitelistIdAsync(int? id)
        {
            try
            {

                var rawMaterialWhiteListAssign = await _repositoryFactory.RawMaterialWhiteListAssign.Table
                    .Include(x=>x.RawMaterial).ThenInclude(x=>x.RawMaterialGroups).ThenInclude(x=>x.RawMaterialGroupType)
                    .Include(x=>x.RawMaterial).ThenInclude(x=>x.Units)
                    .Include(x=>x.RMWhiteList).ThenInclude(x => x.ProductSerie).ThenInclude(x => x.ProductType).ThenInclude(x => x.ProductGroup).ThenInclude(x => x.ProductGroupType)
                    .Where(x => (id == null || x.RMWhiteListID == id )&& !x.RawMaterial.IsSample && x.RawMaterial.IsActive
                    )
                    .ToListAsync();
                return rawMaterialWhiteListAssign;
            }
            catch (System.Exception ex)
            {
                throw;
            }
        }

        public async Task<List<RawMaterialWhiteListAssign>> GetListByRawMaterialIdAsync(int id)
        {
            try
            {
                var rawMaterialWhiteListAssign = await _repositoryFactory.RawMaterialWhiteListAssign.Table
                    .Include(x=>x.RawMaterial).ThenInclude(x=>x.RawMaterialGroups).ThenInclude(x=>x.RawMaterialGroupType)
                    .Include(x=>x.RawMaterial).ThenInclude(x=>x.Units)
                    .Include(x=>x.RMWhiteList).ThenInclude(x => x.ProductSerie).ThenInclude(x => x.ProductType).ThenInclude(x => x.ProductGroup).ThenInclude(x => x.ProductGroupType)
                    .Where(x => x.RawMaterialID == id  )
                    .ToListAsync();
                return rawMaterialWhiteListAssign;
            }
            catch (System.Exception ex)
            {
                throw;
            }
        }


    }
}
