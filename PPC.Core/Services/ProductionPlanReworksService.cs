using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PPC.Common;
using PPC.Core.Interface;
using PPC.Core.Models;
using PPC.Core.Repository;
namespace PPC.Core.Services
{
    public class ProductionPlanReworksService : BaseService, IProductionPlanReworksService
    {
        //IUnitOfWork _unitOfWork;
        public ProductionPlanReworksService(RepositoryFactory repositoryFactory,
            IUnitOfWork unitOfWork)
        {
            _repositoryFactory = repositoryFactory;
            _unitOfWork = unitOfWork;
        }


        public List<ProductionPlanReworks> GetAll()
        {
            try
            {
                var productionPlanReworks = _repositoryFactory.ProductionPlanReworks.Table.Where(x => x.DelUserID == null)
                    .ToList();

                return productionPlanReworks;
            }
            catch
            {
                throw;
            }
        }

        public async Task<List<ProductionPlanReworks>> GetAllAsync()
        {
            try
            {

                var productionPlanReworks = await _repositoryFactory.ProductionPlanReworks.Where(x => x.DelUserID == null).ToListAsync();
                return productionPlanReworks;
            }
            catch (System.Exception ex)
            {
                throw;
            }
        }

        public ProductionPlanReworks GetProductionPlanReworksById(int productionPlanReworkID)
        {
            try
            {
                var productionPlanReworks = _repositoryFactory.ProductionPlanReworks
                    .FirstOrDefault(x => x.DelUserID == null && x.ProductionPlanReworkID == productionPlanReworkID);

                return productionPlanReworks;
            }
            catch
            {
                throw;
            }
        }

        public async Task<ProductionPlanReworks> GetProductionPlanReworksByIdAsync(int productionPlanReworkID)
        {
            try
            {
                var productionPlanReworks = await _repositoryFactory.ProductionPlanReworks.Table
                    .Include(x => x.ProductionPlanPatil).ThenInclude(x => x.ProductionPlan).ThenInclude(x => x.OrderDetail)

                    .FirstOrDefaultAsync(x => x.DelUserID == null && x.ProductionPlanReworkID == productionPlanReworkID);

                return productionPlanReworks;
            }
            catch
            {
                throw;
            }
        }

        public int Append(ProductionPlanReworks productionPlanReworks)
        {
            using (var t = _unitOfWork.StartTransaction())
            {
                try
                {

                    #region update  ProductionPlans instance

                    ProductionPlansService productionPlans = new ProductionPlansService(_repositoryFactory, _unitOfWork);
                    var productionPlan = productionPlans.GetInstanceByProductionPlanPatilId(productionPlanReworks.ProductionPlanPatilID).Result;

                    productionPlan.ProductionPlanBOMDetailList = null;
                    productionPlan.ProductionPlanPatilList = null;
                    productionPlan.ProductionPlanPackagingList = null;
                    productionPlan.ProductionPlanPatilsCapacityList = null;
                    productionPlan.Status = (byte)ProductionPlanStatus.CorrectiveAction;
                    _repositoryFactory.ProductionPlans.Update(productionPlan);

                    #endregion

                    var _newObject = new ProductionPlanReworks
                    {
                        ProductionPlanReworkID = productionPlanReworks.ProductionPlanReworkID,
                        ProductionPlanPatilID = productionPlanReworks.ProductionPlanPatilID,
                        LevelNo = productionPlanReworks.LevelNo,
                        ProductID = productionPlanReworks.ProductID,
                        CorrectiveActionType = productionPlanReworks.CorrectiveActionType,
                        Describe = productionPlanReworks.Describe,
                        InsUserID = productionPlanReworks.InsUserID,
                        InsDate = productionPlanReworks.InsDate,
                        InsTime = productionPlanReworks.InsTime,
                        EditUserID = productionPlanReworks.EditUserID,
                        EditDate = productionPlanReworks.EditDate,
                        EditTime = productionPlanReworks.EditTime,
                        ProductionPlanLastStatus = productionPlan.Status,
                        ProductionPlanReworkDetailList = productionPlanReworks.ProductionPlanReworkDetailList,
                    };

                    #region update  ProductionPlans

                    #endregion

                    _repositoryFactory.ProductionPlanReworks.Add(_newObject);

                    var statuse = _unitOfWork.Commit() > 0;

                    if (statuse)
                    {
                        t.Commit();
                        return _newObject.ProductionPlanReworkID;
                    }
                    else
                        throw new System.Exception(Resources.Resources.pub_RegistrationHasError);
                }
                catch (System.Exception)
                {
                    t.Rollback();
                    throw;
                }
            }
        }


        public bool Update(ProductionPlanReworks productionPlanReworks)
        {
            try
            {

                _repositoryFactory.ProductionPlanReworks.UpdateBy(x => x.ProductionPlanReworkID == productionPlanReworks.ProductionPlanReworkID,
                    new ProductionPlanReworks
                    {
                        ProductionPlanReworkID = productionPlanReworks.ProductionPlanReworkID,
                        ProductionPlanPatilID = productionPlanReworks.ProductionPlanPatilID,
                        LevelNo = productionPlanReworks.LevelNo,
                        ProductID = productionPlanReworks.ProductID,
                        CorrectiveActionType = productionPlanReworks.CorrectiveActionType,
                        Describe = productionPlanReworks.Describe,
                        InsUserID = productionPlanReworks.InsUserID,
                        InsDate = productionPlanReworks.InsDate,
                        InsTime = productionPlanReworks.InsTime,
                        EditUserID = productionPlanReworks.EditUserID,
                        EditDate = productionPlanReworks.EditDate,
                        EditTime = productionPlanReworks.EditTime,
                        ProductionPlanReworkDetailList = productionPlanReworks.ProductionPlanReworkDetailList,


                    });
                var statuse = _unitOfWork.Commit() > 0;
                return statuse;
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }

        public long Delete(int productionPlanReworkID)
        {
            try
            {
                throw new System.Exception("فقط حذف منطقی امکان پذیر است");

                var productionPlanReworks = _repositoryFactory.ProductionPlanReworks
                    .FirstOrDefault(x => x.ProductionPlanReworkID == productionPlanReworkID);

                if (productionPlanReworks == null)
                    throw new System.Exception("ProductionPlanReworks Notfound.");

                _repositoryFactory.ProductionPlanReworks.Delete(productionPlanReworks);
                var statuse = _unitOfWork.Commit();

                return statuse;
            }
            catch
            {
                throw;
            }
        }


        public byte GetMaxLevelNoByPatilId(int productionPlanPatilID)
        {
            try
            {
                var q = _repositoryFactory.ProductionPlanReworks.Where(x => x.DelUserID == null && x.ProductionPlanPatilID == productionPlanPatilID);
                var levelNo = q.Any() ? q.Max(x => x.LevelNo) : (byte)1;

                return levelNo;
            }
            catch
            {
                throw;
            }
        }

        public async Task<List<ProductionPlanReworks>> GetInstanceByProductionPlanPatilIDAsync(int productionPlanPatilId)
        {
            try
            {
                var productionPlanReworks = await _repositoryFactory.ProductionPlanReworks
                    .Where(x => x.DelUserID == null && x.ProductionPlanPatilID == productionPlanPatilId)
                    .Include(x => x.ProductionPlanReworkDetailList).ThenInclude(x => x.RawMaterial)
                    .Include(x => x.Product)
                    .Include(x => x.User_InsUser)
                    .Include(x => x.User_EditUser)
                    .ToListAsync();

                return productionPlanReworks;
            }
            catch
            {
                throw;
            }
        }

        public bool DeleteLogic(int productionPlanReworkID, int userId)
        {
            try
            {
                var productionPlanReworks = _repositoryFactory.ProductionPlanReworks
                    .FirstOrDefault(x => x.ProductionPlanReworkID == productionPlanReworkID);

                if (productionPlanReworks == null)
                    throw new System.Exception("ProductionPlanReworks Notfound.");

                productionPlanReworks.DelUserID = userId;
                productionPlanReworks.DelDate = PPC.Common.General.CurrentDateString;
                productionPlanReworks.DelTime = PPC.Common.General.CurrentTimeString;
                _repositoryFactory.ProductionPlanReworks.Update(productionPlanReworks);

                var statuse = _unitOfWork.Commit() > 0;

                return statuse;
            }
            catch
            {
                throw;
            }
        }


    }
}
