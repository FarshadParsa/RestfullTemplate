using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PPC.Base.Utility;
using PPC.Core.Interface;
using PPC.Core.Models;
using PPC.Core.Repository;
namespace PPC.Core.Services
{
    public class ProductionPlanBOMDetailService : BaseService, IProductionPlanBOMDetailService
    {
        IUnitOfWork _unitOfWork;
        public ProductionPlanBOMDetailService(RepositoryFactory repositoryFactory,
            IUnitOfWork unitOfWork)
        {
            _repositoryFactory = repositoryFactory;
            _unitOfWork = unitOfWork;
        }


        public List<ProductionPlanBOMDetail> GetAll()
        {
            try
            {
                var productionPlanBOMDetail = _repositoryFactory.ProductionPlanBOMDetail.Table.ToList();

                return productionPlanBOMDetail;
            }
            catch
            {
                throw;
            }
        }

        public async Task<List<ProductionPlanBOMDetail>> GetAllAsync()
        {
            try
            {

                var productionPlanBOMDetail = await _repositoryFactory.ProductionPlanBOMDetail.Table.ToListAsync();
                return productionPlanBOMDetail;
            }
            catch (System.Exception ex)
            {
                throw;
            }
        }

        public ProductionPlanBOMDetail GetProductionPlanBOMDetailById(int productionPlanBOMDetailID)
        {
            try
            {
                var productionPlanBOMDetail = _repositoryFactory.ProductionPlanBOMDetail
                    .FirstOrDefault(x => x.ProductionPlanBOMDetailID == productionPlanBOMDetailID);

                return productionPlanBOMDetail;
            }
            catch
            {
                throw;
            }
        }

        public async Task<ProductionPlanBOMDetail> GetProductionPlanBOMDetailByIdAsync(int productionPlanBOMDetailID)
        {
            try
            {
                var productionPlanBOMDetail = await _repositoryFactory.ProductionPlanBOMDetail
                    .FirstOrDefaultAsync(x => x.ProductionPlanBOMDetailID == productionPlanBOMDetailID);

                return productionPlanBOMDetail;
            }
            catch
            {
                throw;
            }
        }

        public int Append(ProductionPlanBOMDetail productionPlanBOMDetail)
        {
            try
            {
                var _newObject = new ProductionPlanBOMDetail
                {
                    ProductionPlanBOMDetailID = productionPlanBOMDetail.ProductionPlanBOMDetailID,
                    ProductionPlanID = productionPlanBOMDetail.ProductionPlanID,
                    BOMDetailID = productionPlanBOMDetail.BOMDetailID,
                    RawMaterialID = productionPlanBOMDetail.RawMaterialID,
                    RawMaterialType = productionPlanBOMDetail.RawMaterialType,
                    ComplementaryCount = productionPlanBOMDetail.ComplementaryCount,
                    Priority = productionPlanBOMDetail.Priority,
                    BOMComplementaryDesc = productionPlanBOMDetail.BOMComplementaryDesc,
                    Planned = productionPlanBOMDetail.Planned,
                    Stock = productionPlanBOMDetail.Stock,
                    PlanningReserved = productionPlanBOMDetail.PlanningReserved,
                    Expiration = productionPlanBOMDetail.Expiration,
                    IsFinalRM = productionPlanBOMDetail.IsFinalRM,
                    Describe = productionPlanBOMDetail.Describe,
                    Percentage = productionPlanBOMDetail.Percentage,
                    RequiredWeight = productionPlanBOMDetail.RequiredWeight,
                    EditUserID = productionPlanBOMDetail.EditUserID,
                    EditDate = productionPlanBOMDetail.EditDate,
                    EditTime = productionPlanBOMDetail.EditTime,
                    RowVer = productionPlanBOMDetail.RowVer,


                };

                _repositoryFactory.ProductionPlanBOMDetail.Add(_newObject);

                var statuse = _unitOfWork.Commit() > 0;

                if (statuse)
                    return _newObject.ProductionPlanBOMDetailID;
                else
                    return int.MinValue;
            }
            catch (System.Exception)
            {
                throw;
            }
        }


        public bool Update(ProductionPlanBOMDetail productionPlanBOMDetail)
        {
            try
            {

                _repositoryFactory.ProductionPlanBOMDetail.UpdateBy(x => x.ProductionPlanBOMDetailID == productionPlanBOMDetail.ProductionPlanBOMDetailID,
                    new ProductionPlanBOMDetail
                    {
                        ProductionPlanBOMDetailID = productionPlanBOMDetail.ProductionPlanBOMDetailID,
                        ProductionPlanID = productionPlanBOMDetail.ProductionPlanID,
                        BOMDetailID = productionPlanBOMDetail.BOMDetailID,
                        RawMaterialID = productionPlanBOMDetail.RawMaterialID,
                        RawMaterialType = productionPlanBOMDetail.RawMaterialType,
                        ComplementaryCount = productionPlanBOMDetail.ComplementaryCount,
                        Priority = productionPlanBOMDetail.Priority,
                        BOMComplementaryDesc = productionPlanBOMDetail.BOMComplementaryDesc,
                        Planned = productionPlanBOMDetail.Planned,
                        Stock = productionPlanBOMDetail.Stock,
                        PlanningReserved = productionPlanBOMDetail.PlanningReserved,
                        Expiration = productionPlanBOMDetail.Expiration,
                        IsFinalRM = productionPlanBOMDetail.IsFinalRM,
                        Describe = productionPlanBOMDetail.Describe,
                        Percentage = productionPlanBOMDetail.Percentage,
                        RequiredWeight = productionPlanBOMDetail.RequiredWeight,
                        EditUserID = productionPlanBOMDetail.EditUserID,
                        EditDate = productionPlanBOMDetail.EditDate,
                        EditTime = productionPlanBOMDetail.EditTime,
                        RowVer = productionPlanBOMDetail.RowVer,


                    });
                var statuse = _unitOfWork.Commit() > 0;
                return statuse;
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }

        public long Delete(int productionPlanBOMDetailID)
        {
            try
            {
                var productionPlanBOMDetail = _repositoryFactory.ProductionPlanBOMDetail
                    .FirstOrDefault(x => x.ProductionPlanBOMDetailID == productionPlanBOMDetailID);

                if (productionPlanBOMDetail == null)
                    throw new System.Exception("ProductionPlanBOMDetail Notfound.");

                _repositoryFactory.ProductionPlanBOMDetail.Delete(productionPlanBOMDetail);
                var statuse = _unitOfWork.Commit();

                return statuse;
            }
            catch
            {
                throw;
            }
        }

        public async Task<List<ProductionPlanBOMDetail>> GetListByProductionPlanIdAsync(int productionPlanId)
        {
            try
            {

                var productionPlanBOMDetail = await _repositoryFactory.ProductionPlanBOMDetail
                    .Where(x => x.ProductionPlanID == productionPlanId)
                    .Include(x => x.RawMaterial)
                    .Include(x => x.BOMDetail)
                    .ToListAsync();

                productionPlanBOMDetail.ForEach(x => x.RowVer = null);

                return productionPlanBOMDetail;
            }
            catch (System.Exception ex)
            {
                throw;
            }
        }

        public bool BOMRevise(List<ProductionPlanBOMDetail> productionPlanBOMList)
        {

            using (var t = _unitOfWork.StartTransaction())
            {

                try
                {
                    var db = _repositoryFactory;
                    productionPlanBOMList.ForEach(detail =>
                    {
                        #region Obtain oldProductionPlanBOMDetail

                        var oldProductionPlanBOMDetail = db.ProductionPlanBOMDetail.Table.AsNoTracking().Include(o => o.ProductionPlan)
                            .FirstOrDefault(o => o.ProductionPlanBOMDetailID == detail.ProductionPlanBOMDetailID);

                        #endregion


                        #region Update ProductionPlanBOMDetail

                        if (db.ProductionPlanBOMDetail.Any(d => d.ProductionPlanBOMDetailID == detail.ProductionPlanBOMDetailID))
                        {
                            db.ProductionPlanBOMDetail.UpdateBy(d => d.ProductionPlanBOMDetailID == detail.ProductionPlanBOMDetailID,
                                new ProductionPlanBOMDetail
                                {
                                    ProductionPlanBOMDetailID = detail.ProductionPlanBOMDetailID,
                                    ProductionPlanID = detail.ProductionPlanID,
                                    BOMDetailID = detail.BOMDetailID,
                                    RawMaterialID = detail.RawMaterialID,
                                    RawMaterialType = detail.RawMaterialType,
                                    ComplementaryCount = detail.ComplementaryCount,
                                    Priority = detail.Priority,
                                    BOMComplementaryDesc = detail.BOMComplementaryDesc,
                                    Planned = detail.Planned,
                                    Stock = detail.Stock,
                                    PlanningReserved = detail.PlanningReserved,
                                    Expiration = detail.Expiration,
                                    IsFinalRM = detail.IsFinalRM,
                                    Describe = detail.Describe,
                                    Percentage = detail.Percentage,
                                    RequiredWeight = detail.RequiredWeight,
                                    EditUserID = detail.EditUserID,
                                    EditDate = detail.EditDate,
                                    EditTime = detail.EditTime,
                                });
                        }
                        else
                        {
                            db.ProductionPlanBOMDetail.Add(new ProductionPlanBOMDetail
                            {
                                //ProductionPlanBOMDetailID = detail.ProductionPlanBOMDetailID,
                                ProductionPlanID = detail.ProductionPlanID,
                                BOMDetailID = null,//detail.BomDetailID,
                                RawMaterialID = detail.RawMaterialID,
                                RawMaterialType = detail.RawMaterialType,
                                ComplementaryCount = detail.ComplementaryCount,
                                Priority = detail.Priority,
                                BOMComplementaryDesc = detail.BOMComplementaryDesc,
                                Planned = detail.Planned,
                                Stock = detail.Stock,
                                PlanningReserved = detail.PlanningReserved,
                                Expiration = detail.Expiration,
                                IsFinalRM = detail.IsFinalRM,
                                Describe = detail.Describe,
                                Percentage = detail.Percentage,
                                RequiredWeight = detail.RequiredWeight,
                                EditUserID = detail.EditUserID,
                                EditDate = detail.EditDate,
                                EditTime = detail.EditTime,
                            });

                        }

                        #endregion

                        #region Append oldProductionPlanBOMDetail into ProductionPlanBOMDetailRevised

                        if (oldProductionPlanBOMDetail != null)
                        {
                            db.ProductionPlanBOMDetailRevised.Add(new ProductionPlanBOMDetailRevised
                            {
                                //ProductionPlanBOMDetailRevisedID = oldProductionPlanBOMDetail.ProductionPlanBOMDetailRevisedID,
                                ProductionPlanID = oldProductionPlanBOMDetail.ProductionPlanID,
                                BOMDetailID = oldProductionPlanBOMDetail.BOMDetailID,
                                RawMaterialType = oldProductionPlanBOMDetail.RawMaterialType,
                                Priority = oldProductionPlanBOMDetail.Priority,
                                Planned = oldProductionPlanBOMDetail.Planned,
                                Stock = oldProductionPlanBOMDetail.Stock,
                                PlanningReserved = oldProductionPlanBOMDetail.PlanningReserved,
                                Expiration = oldProductionPlanBOMDetail.Expiration,
                                Describe = detail.Describe,
                                PlaningDescribe = oldProductionPlanBOMDetail.Describe,
                                Percentage = oldProductionPlanBOMDetail.Percentage,
                                RequiredWeight = oldProductionPlanBOMDetail.RequiredWeight,
                                EditUserID = oldProductionPlanBOMDetail.EditUserID,
                                EditDate = oldProductionPlanBOMDetail.EditDate,
                                EditTime = oldProductionPlanBOMDetail.EditTime,
                            });
                        }

                        #endregion

                    });

                    #region Deleted removed rows

                    db.ProductionPlanBOMDetail.DeleteBy(x => x.ProductionPlanID == productionPlanBOMList.First().ProductionPlanID &&  !productionPlanBOMList.Select(d => d.ProductionPlanBOMDetailID).Contains(x.ProductionPlanBOMDetailID));

                    #endregion


                    var statuse = _unitOfWork.Commit() > 0;

                    t.Commit();

                    return statuse;
                }
                catch (System.Exception)
                {
                    t.Rollback();
                    throw;
                }
            }
        }

    }
}
