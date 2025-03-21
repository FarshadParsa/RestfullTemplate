using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PPC.Core.Interface;
using PPC.Core.Models;
using PPC.Core.Repository;
namespace PPC.Core.Services
{
    public class ProductionPlanBOMDetailRevisedService : BaseService, IProductionPlanBOMDetailRevisedService
    {
        IUnitOfWork _unitOfWork;
        public ProductionPlanBOMDetailRevisedService(RepositoryFactory repositoryFactory,
            IUnitOfWork unitOfWork)
        {
            _repositoryFactory = repositoryFactory;
            _unitOfWork = unitOfWork;
        }


        public List<ProductionPlanBOMDetailRevised> GetAll()
        {
            try
            {
                var productionPlanBOMDetailRevised = _repositoryFactory.ProductionPlanBOMDetailRevised.Table.ToList();

                return productionPlanBOMDetailRevised;
            }
            catch
            {
                throw;
            }
        }

        public async Task<List<ProductionPlanBOMDetailRevised>> GetAllAsync()
        {
            try
            {

                var productionPlanBOMDetailRevised = await _repositoryFactory.ProductionPlanBOMDetailRevised.Table.ToListAsync();
                return productionPlanBOMDetailRevised;
            }
            catch (System.Exception ex)
            {
                throw;
            }
        }

        public ProductionPlanBOMDetailRevised GetProductionPlanBOMDetailRevisedById(int productionPlanBOMDetailRevisedID)
        {
            try
            {
                var productionPlanBOMDetailRevised = _repositoryFactory.ProductionPlanBOMDetailRevised
                    .FirstOrDefault(x => x.ProductionPlanBOMDetailRevisedID == productionPlanBOMDetailRevisedID);

                return productionPlanBOMDetailRevised;
            }
            catch
            {
                throw;
            }
        }

        public async Task<ProductionPlanBOMDetailRevised> GetProductionPlanBOMDetailRevisedByIdAsync(int productionPlanBOMDetailRevisedID)
        {
            try
            {
                var productionPlanBOMDetailRevised = await _repositoryFactory.ProductionPlanBOMDetailRevised
                    .FirstOrDefaultAsync(x => x.ProductionPlanBOMDetailRevisedID == productionPlanBOMDetailRevisedID);

                return productionPlanBOMDetailRevised;
            }
            catch
            {
                throw;
            }
        }

        public int Append(ProductionPlanBOMDetailRevised productionPlanBOMDetailRevised)
        {
            try
            {
                var _newObject = new ProductionPlanBOMDetailRevised
                {
                    ProductionPlanBOMDetailRevisedID = productionPlanBOMDetailRevised.ProductionPlanBOMDetailRevisedID,
                    ProductionPlanID = productionPlanBOMDetailRevised.ProductionPlanID,
                    BOMDetailID = productionPlanBOMDetailRevised.BOMDetailID,
                    RawMaterialType = productionPlanBOMDetailRevised.RawMaterialType,
                    Priority = productionPlanBOMDetailRevised.Priority,
                    Planned = productionPlanBOMDetailRevised.Planned,
                    Stock = productionPlanBOMDetailRevised.Stock,
                    PlanningReserved = productionPlanBOMDetailRevised.PlanningReserved,
                    Expiration = productionPlanBOMDetailRevised.Expiration,
                    Describe = productionPlanBOMDetailRevised.Describe,
                    PlaningDescribe = productionPlanBOMDetailRevised.PlaningDescribe,
                    Percentage = productionPlanBOMDetailRevised.Percentage,
                    RequiredWeight = productionPlanBOMDetailRevised.RequiredWeight,
                    EditUserID = productionPlanBOMDetailRevised.EditUserID,
                    EditDate = productionPlanBOMDetailRevised.EditDate,
                    EditTime = productionPlanBOMDetailRevised.EditTime,


                };

                _repositoryFactory.ProductionPlanBOMDetailRevised.Add(_newObject);

                var statuse = _unitOfWork.Commit() > 0;

                if (statuse)
                    return _newObject.ProductionPlanBOMDetailRevisedID;
                else
                    return int.MinValue;
            }
            catch (System.Exception)
            {
                throw;
            }
        }


        public bool Update(ProductionPlanBOMDetailRevised productionPlanBOMDetailRevised)
        {
            try
            {

                _repositoryFactory.ProductionPlanBOMDetailRevised.UpdateBy(x => x.ProductionPlanBOMDetailRevisedID == productionPlanBOMDetailRevised.ProductionPlanBOMDetailRevisedID,
                    new ProductionPlanBOMDetailRevised
                    {
                        ProductionPlanBOMDetailRevisedID = productionPlanBOMDetailRevised.ProductionPlanBOMDetailRevisedID,
                        ProductionPlanID = productionPlanBOMDetailRevised.ProductionPlanID,
                        BOMDetailID = productionPlanBOMDetailRevised.BOMDetailID,
                        RawMaterialType = productionPlanBOMDetailRevised.RawMaterialType,
                        Priority = productionPlanBOMDetailRevised.Priority,
                        Planned = productionPlanBOMDetailRevised.Planned,
                        Stock = productionPlanBOMDetailRevised.Stock,
                        PlanningReserved = productionPlanBOMDetailRevised.PlanningReserved,
                        Expiration = productionPlanBOMDetailRevised.Expiration,
                        Describe = productionPlanBOMDetailRevised.Describe,
                        PlaningDescribe = productionPlanBOMDetailRevised.PlaningDescribe,
                        Percentage = productionPlanBOMDetailRevised.Percentage,
                        RequiredWeight = productionPlanBOMDetailRevised.RequiredWeight,
                        EditUserID = productionPlanBOMDetailRevised.EditUserID,
                        EditDate = productionPlanBOMDetailRevised.EditDate,
                        EditTime = productionPlanBOMDetailRevised.EditTime,


                    });
                var statuse = _unitOfWork.Commit() > 0;
                return statuse;
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }

        public long Delete(int productionPlanBOMDetailRevisedID)
        {
            try
            {
                var productionPlanBOMDetailRevised = _repositoryFactory.ProductionPlanBOMDetailRevised
                    .FirstOrDefault(x => x.ProductionPlanBOMDetailRevisedID == productionPlanBOMDetailRevisedID);

                if (productionPlanBOMDetailRevised == null)
                    throw new System.Exception("ProductionPlanBOMDetailRevised Notfound.");

                _repositoryFactory.ProductionPlanBOMDetailRevised.Delete(productionPlanBOMDetailRevised);
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
