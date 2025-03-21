using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AtlasCellData.ADO;
using Microsoft.EntityFrameworkCore;
using PPC.Core.Interface;
using PPC.Core.Models;
using PPC.Core.Repository;
namespace PPC.Core.Services
{
    public class ProductionPlanPatilsService : BaseService, IProductionPlanPatilsService
    {
        IUnitOfWork _unitOfWork;
        public ProductionPlanPatilsService(RepositoryFactory repositoryFactory,
            IUnitOfWork unitOfWork)
        {
            _repositoryFactory = repositoryFactory;
            _unitOfWork = unitOfWork;
        }


        public List<ProductionPlanPatils> GetAll()
        {
            try
            {
                var productionPlanPatils = _repositoryFactory.ProductionPlanPatils.Table.ToList();

                return productionPlanPatils;
            }
            catch
            {
                throw;
            }
        }

        public async Task<List<ProductionPlanPatils>> GetAllAsync()
        {
            try
            {

                var productionPlanPatils = await _repositoryFactory.ProductionPlanPatils.Table.ToListAsync();
                return productionPlanPatils;
            }
            catch (System.Exception ex)
            {
                throw;
            }
        }

        public ProductionPlanPatils GetProductionPlanPatilsById(int productionPlanPatilID)
        {
            try
            {
                var productionPlanPatils = _repositoryFactory.ProductionPlanPatils
                    .FirstOrDefault(x => x.ProductionPlanPatilID == productionPlanPatilID);

                return productionPlanPatils;
            }
            catch
            {
                throw;
            }
        }

        public async Task<ProductionPlanPatils> GetProductionPlanPatilsByIdAsync(int productionPlanPatilID)
        {
            try
            {
                var productionPlanPatils = await _repositoryFactory.ProductionPlanPatils.Table
                    .Include(x => x.ProductionPlan).ThenInclude(x => x.OrderDetail).ThenInclude(x => x.BOM)
                    .Include(x => x.ProductionPlan).ThenInclude(x => x.OrderDetail).ThenInclude(x => x.Order)
                    .Include(x => x.ProductionPlan).ThenInclude(x => x.OrderDetail).ThenInclude(x => x.Product)
                    .FirstOrDefaultAsync(x => x.ProductionPlanPatilID == productionPlanPatilID);

                return productionPlanPatils;
            }
            catch
            {
                throw;
            }
        }


        public int Append(ProductionPlanPatils productionPlanPatils)
        {
            try
            {
                var _newObject = new ProductionPlanPatils
                {
                    ProductionPlanPatilID = productionPlanPatils.ProductionPlanPatilID,
                    ProductionPlanID = productionPlanPatils.ProductionPlanID,
                    LotNoNum = productionPlanPatils.LotNoNum,
                    LotNo = productionPlanPatils.LotNo,
                    PlannedCapacity = productionPlanPatils.PlannedCapacity,


                };

                _repositoryFactory.ProductionPlanPatils.Add(_newObject);

                var statuse = _unitOfWork.Commit() > 0;

                if (statuse)
                    return _newObject.ProductionPlanPatilID;
                else
                    return int.MinValue;
            }
            catch (System.Exception)
            {
                throw;
            }
        }


        public bool Update(ProductionPlanPatils productionPlanPatils)
        {
            using (var t = _unitOfWork.StartTransaction())
            {
                try
                {

                    _repositoryFactory.ProductionPlanPatils.UpdateBy(x => x.ProductionPlanPatilID == productionPlanPatils.ProductionPlanPatilID,
                        new ProductionPlanPatils
                        {
                            ProductionPlanPatilID = productionPlanPatils.ProductionPlanPatilID,
                            ProductionPlanID = productionPlanPatils.ProductionPlanID,
                            LotNoNum = productionPlanPatils.LotNoNum,
                            LotNo = productionPlanPatils.LotNo,
                            PlannedCapacity = productionPlanPatils.PlannedCapacity,


                        });
                    var statuse = _unitOfWork.Commit() > 0;
                    return statuse;
                }
                catch (System.Exception ex)
                {
                    throw ex;
                }
            }
        }

        public long Delete(int productionPlanPatilID)
        {
            try
            {
                var productionPlanPatils = _repositoryFactory.ProductionPlanPatils
                    .FirstOrDefault(x => x.ProductionPlanPatilID == productionPlanPatilID);

                if (productionPlanPatils == null)
                    throw new System.Exception("ProductionPlanPatils Notfound.");

                _repositoryFactory.ProductionPlanPatils.Delete(productionPlanPatils);
                var statuse = _unitOfWork.Commit();

                return statuse;
            }
            catch
            {
                throw;
            }
        }

        public async Task<List<ProductionPlanPatils>> GetListByProductionPlanIdAsync(int productionPlanId)
        {
            try
            {

                var productionPlanPatils = await _repositoryFactory.ProductionPlanPatils
                    .Where(x => x.ProductionPlanID == productionPlanId)
                    .Include(x => x.ProductionPlan).ThenInclude(x => x.OrderDetail).ThenInclude(x => x.Product)
                    .Include(x => x.ProductionPlan).ThenInclude(x => x.OrderDetail).ThenInclude(x => x.BOM)
                    .ToListAsync();
                return productionPlanPatils;
            }
            catch (System.Exception ex)
            {
                throw;
            }
        }
        public async Task<List<ProductionPlanPatils>> GetDropdownListByProductionPlanIdAsync(int productionPlanId)
        {
            try
            {

                var productionPlanPatils = await _repositoryFactory.ProductionPlanPatils
                    //.Where(x => x.ProductionPlanID == productionPlanId)
                    .Where(x => productionPlanId == -1 || x.ProductionPlanID == productionPlanId)
                    .ToListAsync();
                return productionPlanPatils;
            }
            catch (System.Exception ex)
            {
                throw;
            }
        }


        public async Task<ProductionPlanPatils> GetPatilsLatestUsgedBOMAsync(int productionPlanPatilID)
        {
            try
            {
 
                var productionPlanPatils = await _repositoryFactory.ProductionPlanPatils.Table
                    .Include(x => x.ProductionPlan).ThenInclude(x => x.ProductionPlanPatilsCapacityList)
                    .Include(x => x.ProductionPlan).ThenInclude(x => x.ProductionPlanPackagingList).ThenInclude(x => x.PackagingPlan)
                    .Include(x => x.ProductionPlan).ThenInclude(x => x.OrderDetail).ThenInclude(x => x.Order)
                    .Include(x => x.ProductionPlan).ThenInclude(x => x.OrderDetail).ThenInclude(x => x.BOM)
                    .Include(x => x.ProductionPlan).ThenInclude(x => x.OrderDetail).ThenInclude(x => x.Product)
                    .Include(x => x.ProductionPlan).ThenInclude(x => x.ProductionPlanBOMDetailList).ThenInclude(x => x.RawMaterial)//لیست فرمولاسیون تولید
                    .Include(x => x.ProductionPlan).ThenInclude(x => x.ProductionPlanBOMDetailRevisedList).ThenInclude(x => x.BOMDetail)//لیست فرمولاسیون اصلاحی
                    .Include(x => x.ProductionPlan).ThenInclude(x => x.ProductionPlanPatilList).ThenInclude(x => x.ProductionPlanReworksList)//لیست فرمولاسیون اقدام اصلاحی
                    .Include(x => x.ProductionPlan).ThenInclude(x => x.User_InsUser)
                    .Include(x => x.ProductionPlan).ThenInclude(x => x.User_InsUser)
                    .FirstOrDefaultAsync(x => x.ProductionPlanPatilID == productionPlanPatilID);

                productionPlanPatils.ProductionPlan.ProductionPlanBOMDetailList.ForEach(x => x.RowVer = null);

                return productionPlanPatils;
            }
            catch
            {
                throw;
            }
        }


    }
}
