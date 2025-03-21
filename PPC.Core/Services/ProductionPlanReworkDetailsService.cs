using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PPC.Core.Interface;
using PPC.Core.Models;
using PPC.Core.Repository;
namespace PPC.Core.Services
{
    public class ProductionPlanReworkDetailsService : BaseService, IProductionPlanReworkDetailsService
    {
        //IUnitOfWork _unitOfWork;
        public ProductionPlanReworkDetailsService(RepositoryFactory repositoryFactory,
            IUnitOfWork unitOfWork)
        {
            _repositoryFactory = repositoryFactory;
            _unitOfWork = unitOfWork;
        }


        public List<ProductionPlanReworkDetails> GetAll()
        {
            try
            {
                var productionPlanReworkDetails = _repositoryFactory.ProductionPlanReworkDetails.Table.ToList();

                return productionPlanReworkDetails;
            }
            catch
            {
                throw;
            }
        }

        public async Task<List<ProductionPlanReworkDetails>> GetAllAsync()
        {
            try
            {

                var productionPlanReworkDetails = await _repositoryFactory.ProductionPlanReworkDetails.Table.ToListAsync();
                return productionPlanReworkDetails;
            }
            catch (System.Exception ex)
            {
                throw;
            }
        }

        public ProductionPlanReworkDetails GetProductionPlanReworkDetailsById(int productionPlanReworkDetailID)
        {
            try
            {
                var productionPlanReworkDetails = _repositoryFactory.ProductionPlanReworkDetails
                    .FirstOrDefault(x => x.ProductionPlanReworkDetailID == productionPlanReworkDetailID);

                return productionPlanReworkDetails;
            }
            catch
            {
                throw;
            }
        }

        public async Task<ProductionPlanReworkDetails> GetProductionPlanReworkDetailsByIdAsync(int productionPlanReworkDetailID)
        {
            try
            {
                var productionPlanReworkDetails = await _repositoryFactory.ProductionPlanReworkDetails
                    .FirstOrDefaultAsync(x => x.ProductionPlanReworkDetailID == productionPlanReworkDetailID);

                return productionPlanReworkDetails;
            }
            catch
            {
                throw;
            }
        }

        public int Append(ProductionPlanReworkDetails productionPlanReworkDetails)
        {
            try
            {
                var _newObject = new ProductionPlanReworkDetails
                {
                    ProductionPlanReworkDetailID = productionPlanReworkDetails.ProductionPlanReworkDetailID,
                    ProductionPlanReworkID = productionPlanReworkDetails.ProductionPlanReworkID,
                    ProductionPlanBOMDetailID = productionPlanReworkDetails.ProductionPlanBOMDetailID,
                    ProductionPlanBOMDetailRevisedID = productionPlanReworkDetails.ProductionPlanBOMDetailRevisedID,
                    ParentID = productionPlanReworkDetails.ParentID,
                    BOMDetailID = productionPlanReworkDetails.BOMDetailID,
                    RMWhiteListID = productionPlanReworkDetails.RMWhiteListID,
                    RawMaterialID = productionPlanReworkDetails.RawMaterialID,
                    Priority = productionPlanReworkDetails.Priority,
                    Percentage = productionPlanReworkDetails.Percentage,
                    PlannedWeight = productionPlanReworkDetails.PlannedWeight,
                    PlanningDescribe = productionPlanReworkDetails.PlanningDescribe,
                    WronglyMixed = productionPlanReworkDetails.WronglyMixed,
                    ActualWeight = productionPlanReworkDetails.ActualWeight,
                    ActualPercentage = productionPlanReworkDetails.ActualPercentage,
                    NewChargeWeight = productionPlanReworkDetails.NewChargeWeight,
                    NewChargePercent = productionPlanReworkDetails.NewChargePercent,
                    NewWeight = productionPlanReworkDetails.NewWeight,
                    ManualAdded = productionPlanReworkDetails.ManualAdded,
                    LotNo = productionPlanReworkDetails.LotNo,
                    Describe = productionPlanReworkDetails.Describe,
                };

                _repositoryFactory.ProductionPlanReworkDetails.Add(_newObject);

                var statuse = _unitOfWork.Commit() > 0;

                if (statuse)
                    return _newObject.ProductionPlanReworkDetailID;
                else
                    throw new System.Exception(Resources.Resources.pub_RegistrationHasError);
            }
            catch (System.Exception)
            {
                throw;
            }
        }


        public bool Update(ProductionPlanReworkDetails productionPlanReworkDetails)
        {
            try
            {

                _repositoryFactory.ProductionPlanReworkDetails.UpdateBy(x => x.ProductionPlanReworkDetailID == productionPlanReworkDetails.ProductionPlanReworkDetailID,
                    new ProductionPlanReworkDetails
                    {
                        ProductionPlanReworkDetailID = productionPlanReworkDetails.ProductionPlanReworkDetailID,
                        ProductionPlanReworkID = productionPlanReworkDetails.ProductionPlanReworkID,
                        ProductionPlanBOMDetailID = productionPlanReworkDetails.ProductionPlanBOMDetailID,
                        ProductionPlanBOMDetailRevisedID = productionPlanReworkDetails.ProductionPlanBOMDetailRevisedID,
                        ParentID = productionPlanReworkDetails.ParentID,
                        BOMDetailID = productionPlanReworkDetails.BOMDetailID,
                        RMWhiteListID = productionPlanReworkDetails.RMWhiteListID,
                        RawMaterialID = productionPlanReworkDetails.RawMaterialID,
                        Priority = productionPlanReworkDetails.Priority,
                        Percentage = productionPlanReworkDetails.Percentage,
                        PlannedWeight = productionPlanReworkDetails.PlannedWeight,
                        PlanningDescribe = productionPlanReworkDetails.PlanningDescribe,
                        WronglyMixed = productionPlanReworkDetails.WronglyMixed,
                        ActualWeight = productionPlanReworkDetails.ActualWeight,
                        ActualPercentage = productionPlanReworkDetails.ActualPercentage,
                        NewChargeWeight = productionPlanReworkDetails.NewChargeWeight,
                        NewChargePercent = productionPlanReworkDetails.NewChargePercent,
                        NewWeight = productionPlanReworkDetails.NewWeight,
                        ManualAdded = productionPlanReworkDetails.ManualAdded,
                        LotNo = productionPlanReworkDetails.LotNo,
                        Describe = productionPlanReworkDetails.Describe,


                    });
                var statuse = _unitOfWork.Commit() > 0;
                return statuse;
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }

        public long Delete(int productionPlanReworkDetailID)
        {
            try
            {
                var productionPlanReworkDetails = _repositoryFactory.ProductionPlanReworkDetails
                    .FirstOrDefault(x => x.ProductionPlanReworkDetailID == productionPlanReworkDetailID);

                if (productionPlanReworkDetails == null)
                    throw new System.Exception("ProductionPlanReworkDetails Notfound.");

                _repositoryFactory.ProductionPlanReworkDetails.Delete(productionPlanReworkDetails);
                var statuse = _unitOfWork.Commit();

                return statuse;
            }
            catch
            {
                throw;
            }
        }


        public async Task<List<ProductionPlanReworkDetails>> GetDetailsListByProductionPlanReworkIdAsync(int productionPlanReworkId)
        {
            try
            {

                var productionPlanReworkDetails = await _repositoryFactory.ProductionPlanReworkDetails
                    .Where(x=>x.ProductionPlanReworkID == productionPlanReworkId)
                    .ToListAsync();
                return productionPlanReworkDetails;
            }
            catch (System.Exception ex)
            {
                throw;
            }
        }



    }
}
