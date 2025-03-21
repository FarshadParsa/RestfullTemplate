using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PPC.Core.Interface;
using PPC.Core.Models;
using PPC.Core.Repository;
namespace PPC.Core.Services
{
    public class ProductionPlanPatilsCapacityService : BaseService, IProductionPlanPatilsCapacityService
    {
        IUnitOfWork _unitOfWork;
        public ProductionPlanPatilsCapacityService(RepositoryFactory repositoryFactory,
            IUnitOfWork unitOfWork)
        {
            _repositoryFactory = repositoryFactory;
            _unitOfWork = unitOfWork;
        }


        public List<ProductionPlanPatilsCapacity> GetAll()
        {
            try
            {
                var productionPlanPatilsCapacity = _repositoryFactory.ProductionPlanPatilsCapacity.Table.ToList();

                return productionPlanPatilsCapacity;
            }
            catch
            {
                throw;
            }
        }

        public async Task<List<ProductionPlanPatilsCapacity>> GetAllAsync()
        {
            try
            {

                var productionPlanPatilsCapacity = await _repositoryFactory.ProductionPlanPatilsCapacity.Table.ToListAsync();
                return productionPlanPatilsCapacity;
            }
            catch (System.Exception ex)
            {
                throw;
            }
        }

        public ProductionPlanPatilsCapacity GetProductionPlanPatilsCapacityById(int productionPlanPatilCapacityID)
        {
            try
            {
                var productionPlanPatilsCapacity = _repositoryFactory.ProductionPlanPatilsCapacity
                    .FirstOrDefault(x => x.ProductionPlanPatilCapacityID == productionPlanPatilCapacityID);

                return productionPlanPatilsCapacity;
            }
            catch
            {
                throw;
            }
        }

        public async Task<ProductionPlanPatilsCapacity> GetProductionPlanPatilsCapacityByIdAsync(int productionPlanPatilCapacityID)
        {
            try
            {
                var productionPlanPatilsCapacity = await _repositoryFactory.ProductionPlanPatilsCapacity
                    .FirstOrDefaultAsync(x => x.ProductionPlanPatilCapacityID == productionPlanPatilCapacityID);

                return productionPlanPatilsCapacity;
            }
            catch
            {
                throw;
            }
        }

        public int Append(ProductionPlanPatilsCapacity productionPlanPatilsCapacity)
        {
            try
            {
                var _newObject = new ProductionPlanPatilsCapacity
                {
                    ProductionPlanPatilCapacityID = productionPlanPatilsCapacity.ProductionPlanPatilCapacityID,
                    ProductionPlanID = productionPlanPatilsCapacity.ProductionPlanID,
                    Capacity = productionPlanPatilsCapacity.Capacity,
                    QTY = productionPlanPatilsCapacity.QTY,


                };

                _repositoryFactory.ProductionPlanPatilsCapacity.Add(_newObject);

                var statuse = _unitOfWork.Commit() > 0;

                if (statuse)
                    return _newObject.ProductionPlanPatilCapacityID;
                else
                    return int.MinValue;
            }
            catch (System.Exception)
            {
                throw;
            }
        }


        public bool Update(ProductionPlanPatilsCapacity productionPlanPatilsCapacity)
        {
            try
            {

                _repositoryFactory.ProductionPlanPatilsCapacity.UpdateBy(x => x.ProductionPlanPatilCapacityID == productionPlanPatilsCapacity.ProductionPlanPatilCapacityID,
                    new ProductionPlanPatilsCapacity
                    {
                        ProductionPlanPatilCapacityID = productionPlanPatilsCapacity.ProductionPlanPatilCapacityID,
                        ProductionPlanID = productionPlanPatilsCapacity.ProductionPlanID,
                        Capacity = productionPlanPatilsCapacity.Capacity,
                        QTY = productionPlanPatilsCapacity.QTY,


                    });
                var statuse = _unitOfWork.Commit() > 0;
                return statuse;
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }

        public long Delete(int productionPlanPatilCapacityID)
        {
            try
            {
                var productionPlanPatilsCapacity = _repositoryFactory.ProductionPlanPatilsCapacity
                    .FirstOrDefault(x => x.ProductionPlanPatilCapacityID == productionPlanPatilCapacityID);

                if (productionPlanPatilsCapacity == null)
                    throw new System.Exception("ProductionPlanPatilsCapacity Notfound.");

                _repositoryFactory.ProductionPlanPatilsCapacity.Delete(productionPlanPatilsCapacity);
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
