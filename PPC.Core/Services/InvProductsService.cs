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
    public class InvProductsService : BaseService, IInvProductsService
    {
        IUnitOfWork _unitOfWork;
        public InvProductsService(RepositoryFactory repositoryFactory,
            IUnitOfWork unitOfWork)
        {
            _repositoryFactory = repositoryFactory;
            _unitOfWork = unitOfWork;
        }


        public List<InvProducts> GetAll()
        {
            try
            {
                var invProducts = _repositoryFactory.InvProducts.Table.ToList();

                return invProducts;
            }
            catch
            {
                throw;
            }
        }

        public async Task<List<InvProducts>> GetAllInvProductsAsync()
        {
            try
            {

                var invProducts = await _repositoryFactory.InvProducts
                    .Where(x=> x.Status == (byte)InvProductStatus.Warehouse || x.Status == (byte)InvProductStatus.Reverted)
                    .Include(x=>x.Product)
                    .Include(x=>x.Palet)
                    .Include(x=>x.Palet.Customer)
                    .Include(x=>x.Palet).ThenInclude(x=>x.OrderDetail).ThenInclude(x=>x.Order)
                    .ToListAsync();
                return invProducts;
            }
            catch (System.Exception ex)
            {
                throw;
            }
        }

        public InvProducts GetInvProductsById(int invProductID)
        {
            try
            {
                var invProducts = _repositoryFactory.InvProducts
                    .FirstOrDefault(x => x.InvProductID == invProductID);

                return invProducts;
            }
            catch
            {
                throw;
            }
        }

        public async Task<InvProducts> GetInvProductsByIdAsync(int invProductID)
        {
            try
            {
                var invProducts = await _repositoryFactory.InvProducts.Table
                    .Include(x=>x.Product)
                    .Include(x=>x.DataProduction).ThenInclude(x=>x.ProductionPlanPatil).ThenInclude(x=>x.ProductionPlan).ThenInclude(x=>x.OrderDetail).ThenInclude(x=>x.Order).ThenInclude(x=>x.Customer)
                    .Include(x=>x.Palet)
                    //.Include(x=>x.PackagingPlan)
                    .Include(x=>x.Supplier)
                    .FirstOrDefaultAsync(x => x.InvProductID == invProductID);

                return invProducts;
            }
            catch
            {
                throw;
            }
        }

        public int Append(InvProducts invProducts)
        {
            try
            {
                var _newObject = new InvProducts
                {
                    InvProductID = invProducts.InvProductID,
                    InvProductCode = invProducts.InvProductCode,
                    DataProductionID = invProducts.DataProductionID,
                    ProductID = invProducts.ProductID,
                    WeightingProductDetailID = invProducts.WeightingProductDetailID,
                    Weight = invProducts.Weight,
                    NetWeight = invProducts.NetWeight,
                    EntryDate = invProducts.EntryDate,
                    ProducedDate = invProducts.ProducedDate,
                    ExpireDate = invProducts.ExpireDate,
                    ShelfLife = invProducts.ShelfLife,
                    EnProducedDate = invProducts.EnProducedDate,
                    EnExpireDate = invProducts.EnExpireDate,
                    EnShelfLife = invProducts.EnShelfLife,
                    PackagingPlanID = invProducts.PackagingPlanID,
                    SupplierID = invProducts.SupplierID,
                    Remark = invProducts.Remark,
                    Status = invProducts.Status,
                    QcStatus = invProducts.QcStatus,
                    PaletID = invProducts.PaletID,
                    ParentID = invProducts.ParentID,
                    InsUserID = invProducts.InsUserID,
                    InsDate = invProducts.InsDate,
                    InsTime = invProducts.InsTime,
                    EditUserID = invProducts.EditUserID,
                    EditDate = invProducts.EditDate,
                    EditTime = invProducts.EditTime,


                };

                _repositoryFactory.InvProducts.Add(_newObject);

                var statuse = _unitOfWork.Commit() > 0;

                if (statuse)
                    return _newObject.InvProductID;
                else
                    return int.MinValue;
            }
            catch (System.Exception)
            {
                throw;
            }
        }


        public bool Update(InvProducts invProducts)
        {
            try
            {

                _repositoryFactory.InvProducts.UpdateBy(x => x.InvProductID == invProducts.InvProductID,
                    new InvProducts
                    {
                        InvProductID = invProducts.InvProductID,
                        InvProductCode = invProducts.InvProductCode,
                        DataProductionID = invProducts.DataProductionID,
                        ProductID = invProducts.ProductID,
                        WeightingProductDetailID = invProducts.WeightingProductDetailID,
                        Weight = invProducts.Weight,
                        NetWeight = invProducts.NetWeight,
                        EntryDate = invProducts.EntryDate,
                        ProducedDate = invProducts.ProducedDate,
                        ExpireDate = invProducts.ExpireDate,
                        ShelfLife = invProducts.ShelfLife,
                        EnProducedDate = invProducts.EnProducedDate,
                        EnExpireDate = invProducts.EnExpireDate,
                        EnShelfLife = invProducts.EnShelfLife,
                        PackagingPlanID = invProducts.PackagingPlanID,
                        SupplierID = invProducts.SupplierID,
                        Remark = invProducts.Remark,
                        Status = invProducts.Status,
                        QcStatus = invProducts.QcStatus,
                        PaletID = invProducts.PaletID,
                        ParentID = invProducts.ParentID,
                        InsUserID = invProducts.InsUserID,
                        InsDate = invProducts.InsDate,
                        InsTime = invProducts.InsTime,
                        EditUserID = invProducts.EditUserID,
                        EditDate = invProducts.EditDate,
                        EditTime = invProducts.EditTime,


                    });
                var statuse = _unitOfWork.Commit() > 0;
                return statuse;
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }

        public long Delete(int invProductID)
        {
            try
            {
                var invProducts = _repositoryFactory.InvProducts
                    .FirstOrDefault(x => x.InvProductID == invProductID);

                if (invProducts == null)
                    throw new System.Exception("InvProducts Notfound.");

                _repositoryFactory.InvProducts.Delete(invProducts);
                var statuse = _unitOfWork.Commit();

                return statuse;
            }
            catch
            {
                throw;
            }
        }

        public async Task<InvProducts> GetInstanceByBarcodeAsync(string barcode)
        {
            try
            {
                var invProducts = await _repositoryFactory.InvProducts.Table
                    .Include(x => x.Product)
                    .FirstOrDefaultAsync(x => x.InvProductCode == barcode);

                return invProducts;
            }
            catch
            {
                throw;
            }
        }

        public async Task<List<InvProducts>> GetListByWeightingProductIdAsync(int weightingProductId)
        {
            try
            {
                var invProducts = await _repositoryFactory.InvProducts.Table
                    .Include(x => x.WeightingProductDetail)
                    .Include(x => x.Product)
                    .Include(x => x.Palet)
                    .Include(x => x.DataProduction).ThenInclude(x=>x.ProductionPlanPatil)
                    .Where(x => x.WeightingProductDetail.WeightingProductID == weightingProductId)
                    .ToListAsync();

                return invProducts;
            }
            catch (System.Exception ex)
            {
                throw;
            }
        }

        public async Task<List<InvProducts>> GetByPaletIdAsync(int paletId)
        {
            try
            {
                var invProducts = await _repositoryFactory.InvProducts
                    .Where(x => x.PaletID == paletId)
                    .Include(x => x.Product)
                    .Include(x => x.DataProduction).ThenInclude(x=>x.ProductionPlanPatil)
                    .ToListAsync();
                return invProducts;
            }
            catch (System.Exception ex)
            {
                throw;
            }
        }



    }
}
