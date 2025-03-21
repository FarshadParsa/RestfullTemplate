using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PPC.Core.Interface;
using PPC.Core.Models;
using PPC.Core.Repository;
namespace PPC.Core.Services
{
    public class RawMaterialLotsInventoryService : BaseService, IRawMaterialLotsInventoryService
    {
        //IUnitOfWork _unitOfWork;
        public RawMaterialLotsInventoryService(RepositoryFactory repositoryFactory,
            IUnitOfWork unitOfWork)
        {
            _repositoryFactory = repositoryFactory;
            _unitOfWork = unitOfWork;
        }


        public List<RawMaterialLotsInventory> GetAll()
        {
            try
            {
                var rawMaterialLotsInventory = _repositoryFactory.RawMaterialLotsInventory.Table
                    .Include(x => x.RawMaterial)
                    .ToList();

                return rawMaterialLotsInventory;
            }
            catch
            {
                throw;
            }
        }

        public async Task<List<RawMaterialLotsInventory>> GetAllAsync()
        {
            try
            {

                var rawMaterialLotsInventory = await _repositoryFactory.RawMaterialLotsInventory.Table
                    .Include(x => x.RawMaterial)
                    .ToListAsync();
                return rawMaterialLotsInventory;
            }
            catch (System.Exception ex)
            {
                throw;
            }
        }

        public RawMaterialLotsInventory GetInstanceByLotNo(string lotNo)
        {
            try
            {
                var rawMaterialLotsInventory = _repositoryFactory.RawMaterialLotsInventory.Table
                    .Include(x => x.RawMaterial)
                    .FirstOrDefault(x => x.LotNo == lotNo);

                return rawMaterialLotsInventory;
            }
            catch
            {
                throw;
            }
        }

        public async Task<RawMaterialLotsInventory> GetInstanceByLotNoAsync(string lotNo)
        {
            try
            {
                var rawMaterialLotsInventory = await _repositoryFactory.RawMaterialLotsInventory.Table
                    .Include(x => x.RawMaterial)
                    .FirstOrDefaultAsync(x => x.LotNo == lotNo);

                return rawMaterialLotsInventory;
            }
            catch
            {
                throw;
            }
        }


        public async Task<List<RawMaterialLotsInventory>> GetListByRawMaterialIDAsync(int rawMaterialId)
        {
            try
            {
                var rawMaterialLotsInventory = await _repositoryFactory.RawMaterialLotsInventory
                    .Where(x => x.RawMaterialID == rawMaterialId)
                    .Include(x => x.RawMaterial)
                    .ToListAsync();

                return rawMaterialLotsInventory;
            }
            catch
            {
                throw;
            }
        }

        public async Task<List<RawMaterialLotsInventory>> GetInWarehouseListAsync()
        {
            try
            {
                var rawMaterialLotsInventory = await _repositoryFactory.RawMaterialLotsInventory
                    .Where(x => x.RemainingWeight > 0)
                    .Include(x => x.RawMaterial)
                    .ToListAsync();

                return rawMaterialLotsInventory;
            }
            catch
            {
                throw;
            }
        }

        public async Task<List<RawMaterialLotsInventory>> GetInWarehouseListByRawMaterialIDAsync(int rawMaterialId)
        {
            try
            {
                var rawMaterialLotsInventory = await _repositoryFactory.RawMaterialLotsInventory
                    .Where(x => x.RemainingWeight > 0 && x.RawMaterialID == rawMaterialId)
                    .Include(x => x.RawMaterial)
                    .ToListAsync();

                return rawMaterialLotsInventory;
            }
            catch
            {
                throw;
            }
        }

        public async Task<List<RawMaterialLotsInventory>> GetInWarehouseListByRawMaterialIDsAsync(List<int> rawMaterialIdList)
        {
            try
            {
                var rawMaterialLotsInventory = await _repositoryFactory.RawMaterialLotsInventory
                    .Where(x => x.RemainingWeight > 0 && rawMaterialIdList.Contains(x.RawMaterialID))
                    .Include(x => x.RawMaterial)
                    .ToListAsync();

                return rawMaterialLotsInventory;
            }
            catch
            {
                throw;
            }
        }

        public async Task<List<RawMaterialLotsInventory>> GetOldestRawMaterialListByRawMaterialIDsAsync(List<int> rawMaterialIdList)
        {
            try
            {

                var db = _repositoryFactory;
                
                var rawMaterialLotsInventory = (from r in db.RawMaterialLotsInventory.Table
                             join m in (from r in db.RawMaterialLotsInventory.Table
                                        group r by r.RawMaterialID into g
                                        select new
                                        {
                                            RawMaterialID = g.Key,
                                            ExpireDate = g.Min(r => r.ExpireDate)
                                        }) on new { r.RawMaterialID, r.ExpireDate } equals new { m.RawMaterialID, m.ExpireDate }
                             orderby r.RawMaterialID
                             select r).ToList();

                return rawMaterialLotsInventory;

            }
            catch
            {
                throw;
            }
        }


    }
}
