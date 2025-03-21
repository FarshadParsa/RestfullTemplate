using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PPC.Core.Interface;
using PPC.Core.Models;
using PPC.Core.Repository;
namespace PPC.Core.Services
{
    public class BOMComplementaryService : BaseService, IBOMComplementaryService
    {
        IUnitOfWork _unitOfWork;
        public BOMComplementaryService(RepositoryFactory repositoryFactory,
            IUnitOfWork unitOfWork)
        {
            _repositoryFactory = repositoryFactory;
            _unitOfWork = unitOfWork;
        }


        public List<BOMComplementary> GetAll()
        {
            try
            {
                var bOMComplementary = _repositoryFactory.BOMComplementary.Table.ToList();

                return bOMComplementary;
            }
            catch
            {
                throw;
            }
        }

        public async Task<List<BOMComplementary>> GetAllAsync()
        {
            try
            {

                var bOMComplementary = await _repositoryFactory.BOMComplementary.Table.ToListAsync();
                return bOMComplementary;
            }
            catch (System.Exception ex)
            {
                throw;
            }
        }

        public BOMComplementary GetBOMComplementaryById(int bOMComplementaryID)
        {
            try
            {
                var bOMComplementary = _repositoryFactory.BOMComplementary
                    .FirstOrDefault(x => x.BOMComplementaryID == bOMComplementaryID);

                return bOMComplementary;
            }
            catch
            {
                throw;
            }
        }

        public async Task<BOMComplementary> GetBOMComplementaryByIdAsync(int bOMComplementaryID)
        {
            try
            {
                var bOMComplementary = await _repositoryFactory.BOMComplementary
                    .FirstOrDefaultAsync(x => x.BOMComplementaryID == bOMComplementaryID);

                return bOMComplementary;
            }
            catch
            {
                throw;
            }
        }

        public int Append(BOMComplementary bOMComplementary)
        {
            try
            {
                var _newObject = new BOMComplementary
                {
                    BOMComplementaryID = bOMComplementary.BOMComplementaryID,
                    BOMDetailID = bOMComplementary.BOMDetailID,
                    RawMaterialID = bOMComplementary.RawMaterialID,
                    Priority = bOMComplementary.Priority,
                    Percentage = bOMComplementary.Percentage,
                    Describe = bOMComplementary.Describe,


                };

                _repositoryFactory.BOMComplementary.Add(_newObject);

                var statuse = _unitOfWork.Commit() > 0;

                if (statuse)
                    return _newObject.BOMComplementaryID;
                else
                    return int.MinValue;
            }
            catch (System.Exception)
            {
                throw;
            }
        }


        public bool Update(BOMComplementary bOMComplementary)
        {
            try
            {

                _repositoryFactory.BOMComplementary.UpdateBy(x => x.BOMComplementaryID == bOMComplementary.BOMComplementaryID,
                    new BOMComplementary
                    {
                        BOMComplementaryID = bOMComplementary.BOMComplementaryID,
                        BOMDetailID = bOMComplementary.BOMDetailID,
                        RawMaterialID = bOMComplementary.RawMaterialID,
                        Priority = bOMComplementary.Priority,
                        Percentage = bOMComplementary.Percentage,
                        Describe = bOMComplementary.Describe,


                    });
                var statuse = _unitOfWork.Commit() > 0;
                return statuse;
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }

        public long Delete(int bOMComplementaryID)
        {
            try
            {
                var bOMComplementary = _repositoryFactory.BOMComplementary
                    .FirstOrDefault(x => x.BOMComplementaryID == bOMComplementaryID);

                if (bOMComplementary == null)
                    throw new System.Exception("BOMComplementary Notfound.");

                _repositoryFactory.BOMComplementary.Delete(bOMComplementary);
                var statuse = _unitOfWork.Commit();

                return statuse;
            }
            catch
            {
                throw;
            }
        }

        public async Task<List<BOMComplementary>> GetListByRMWhiteListIdAsync(int rmWhiteListId)
        {
            try
            {

                var rwWhiteList = _repositoryFactory.RawMaterialWhiteListAssign
                    .Where(x => x.RMWhiteListID == rmWhiteListId)
                    .Select(x => x.RawMaterialID);
                    //.Include(x => x.RMWhiteList);

                var bomComplementary = await _repositoryFactory.BOMComplementary.Table
                    .Include(x=>x.BOMDetail).ThenInclude(x=>x.BOM)
                    .Include(x=>x.RawMaterial)
                    .Where(x=> rwWhiteList.Contains(x.RawMaterialID))
                    .ToListAsync();
                return bomComplementary;
            }
            catch (System.Exception ex)
            {
                throw;
            }
        }
        
        public async Task<List<BOMComplementary>> GetListByBOMDetailId(int bomDetailId)
        {
            try
            {
                var bomComplementary = await _repositoryFactory.BOMComplementary.Table
                    .Include(x=>x.BOMDetail).ThenInclude(x=>x.BOM).ThenInclude(x=>x.Product).ThenInclude(x=>x.ProductSerie).ThenInclude(x=>x.ProductType).ThenInclude(x=>x.ProductGroup).ThenInclude(x=>x.ProductGroupType)
                    .Include(x=>x.RawMaterial).ThenInclude(x => x.RawMaterialGroups).ThenInclude(x => x.RawMaterialGroupType)
                    .Include(x=>x.RawMaterial).ThenInclude(x => x.Units)
                    .Where(x=> x.BOMDetailID  == bomDetailId)
                    .ToListAsync();
                return bomComplementary;
            }
            catch (System.Exception ex)
            {
                throw;
            }
        }

        public async Task<List<BOMComplementary>> GetListByBOMId(int bomId)
        {
            try
            {

                var bomComplementary = await _repositoryFactory.BOMComplementary.Table
                    .Include(x => x.BOMDetail).ThenInclude(x => x.BOM)
                    .Include(x => x.RawMaterial)
                    .Where(x => x.BOMDetail.BOMID == bomId)
                    .ToListAsync();

                var bomComplementary1 = _repositoryFactory.BOMComplementary.Table
                .Include(x => x.BOMDetail).ThenInclude(x => x.BOM)
                .Include(x => x.RawMaterial)
                .Where(x => x.BOMDetail.BOMID == bomId)
                .ToQueryString();

                bomComplementary.ForEach(x => x.BOMDetail.BOMComplementaryList = null);
                return bomComplementary;


            }
            catch (System.Exception ex)
            {
                throw;
            }
        }


    }
}
