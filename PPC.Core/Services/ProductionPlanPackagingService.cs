using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PPC.Core.Interface;
using PPC.Core.Models;
using PPC.Core.Repository;
namespace PPC.Core.Services
{
    public class ProductionPlanPackagingService : BaseService, IProductionPlanPackagingService
    {
        IUnitOfWork _unitOfWork;
        public ProductionPlanPackagingService(RepositoryFactory repositoryFactory,
            IUnitOfWork unitOfWork)
        {
            _repositoryFactory = repositoryFactory;
            _unitOfWork = unitOfWork;
        }


        public List<ProductionPlanPackaging> GetAll()
        {
            try
            {
                var productionPlanPackaging = _repositoryFactory.ProductionPlanPackaging.Table.ToList();

                return productionPlanPackaging;
            }
            catch
            {
                throw;
            }
        }

        public async Task<List<ProductionPlanPackaging>> GetAllAsync()
        {
            try
            {

                var productionPlanPackaging = await _repositoryFactory.ProductionPlanPackaging.Table.ToListAsync();
                return productionPlanPackaging;
            }
            catch (System.Exception ex)
            {
                throw;
            }
        }

        public ProductionPlanPackaging GetProductionPlanPackagingById(int productionPlanPackagingID)
        {
            try
            {
                var productionPlanPackaging = _repositoryFactory.ProductionPlanPackaging
                    .FirstOrDefault(x => x.ProductionPlanPackagingID == productionPlanPackagingID);

                return productionPlanPackaging;
            }
            catch
            {
                throw;
            }
        }

        public async Task<ProductionPlanPackaging> GetProductionPlanPackagingByIdAsync(int productionPlanPackagingID)
        {
            try
            {
                var productionPlanPackaging = await _repositoryFactory.ProductionPlanPackaging
                    .FirstOrDefaultAsync(x => x.ProductionPlanPackagingID == productionPlanPackagingID);

                return productionPlanPackaging;
            }
            catch
            {
                throw;
            }
        }

        public int Append(ProductionPlanPackaging productionPlanPackaging)
        {
            try
            {
                var _newObject = new ProductionPlanPackaging
                {
                    ProductionPlanPackagingID = productionPlanPackaging.ProductionPlanPackagingID,
                    ProductionPlanID = productionPlanPackaging.ProductionPlanID,
                    Priority = productionPlanPackaging.Priority,
                    PackagingPlanID = productionPlanPackaging.PackagingPlanID,
                    QTY = productionPlanPackaging.QTY,


                };

                _repositoryFactory.ProductionPlanPackaging.Add(_newObject);

                var statuse = _unitOfWork.Commit() > 0;

                if (statuse)
                    return _newObject.ProductionPlanPackagingID;
                else
                    return int.MinValue;
            }
            catch (System.Exception)
            {
                throw;
            }
        }


        public bool Update(ProductionPlanPackaging productionPlanPackaging)
        {
            try
            {

                _repositoryFactory.ProductionPlanPackaging.UpdateBy(x => x.ProductionPlanPackagingID == productionPlanPackaging.ProductionPlanPackagingID,
                    new ProductionPlanPackaging
                    {
                        ProductionPlanPackagingID = productionPlanPackaging.ProductionPlanPackagingID,
                        ProductionPlanID = productionPlanPackaging.ProductionPlanID,
                        Priority = productionPlanPackaging.Priority,
                        PackagingPlanID = productionPlanPackaging.PackagingPlanID,
                        QTY = productionPlanPackaging.QTY,


                    });
                var statuse = _unitOfWork.Commit() > 0;
                return statuse;
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }

        public long Delete(int productionPlanPackagingID)
        {
            try
            {
                var productionPlanPackaging = _repositoryFactory.ProductionPlanPackaging
                    .FirstOrDefault(x => x.ProductionPlanPackagingID == productionPlanPackagingID);

                if (productionPlanPackaging == null)
                    throw new System.Exception("ProductionPlanPackaging Notfound.");

                _repositoryFactory.ProductionPlanPackaging.Delete(productionPlanPackaging);
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

