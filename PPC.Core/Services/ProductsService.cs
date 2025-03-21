using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Linq;
using Microsoft.EntityFrameworkCore;
using PPC.Core.Interface;
using PPC.Core.Models;
using PPC.Core.Repository;
using Microsoft.VisualBasic;

namespace PPC.Core.Services
{
    public class ProductsService : BaseService, IProductsService
    {
        IUnitOfWork _unitOfWork;
        public ProductsService(RepositoryFactory repositoryFactory,
            IUnitOfWork unitOfWork)
        {
            _repositoryFactory = repositoryFactory;
            _unitOfWork = unitOfWork;
        }


        public List<Products> GetAll()
        {
            try
            {
                var products = _repositoryFactory.Products.Table
                    .Include(x => x.TestPlan)
                    .Include(x => x.ProductSerie)
                    .Include(x => x.PrintingTechniques)
                    .ToList();
                //var products = _repositoryFactory.Products.Table.Include(x=>x.ProductSerie).ThenInclude(x=>x.ProductType).ToList();



                return products;
            }
            catch
            {
                throw;
            }
        }

        public async Task<List<Products>> GetAllAsync()
        {
            try
            {

                //var productsss = await _repositoryFactory.Products.Table.Include(x => x.ProductSerie).Include(x => x.PrintingTechniques).ToListAsync();
                var db = _repositoryFactory;
                var p = await (from products in db.Products.Table.Include(x => x.TestPlan).Include(x => x.Final_RawMaterial)//.Include(x=>x.TestPlanAssign)
                               join productSerie in db.ProductSeries.Table.Include(x => x.ProductType).ThenInclude(x => x.ProductGroup).ThenInclude(x => x.ProductGroupType) on products.ProductSerieID equals productSerie.ProductSerieID
                               join printingTechniques in db.PrintingTechniques.Table on products.PrintingTechniqueID equals printingTechniques.PrintingTechniqueID into pt_jointable
                               from printingTechnique in pt_jointable.DefaultIfEmpty()
                               select new Products
                               {
                                   ProductID = products.ProductID,
                                   ProductCode = products.ProductCode,
                                   SerialCode = products.SerialCode,
                                   ProductName = products.ProductName,
                                   ProductLatinName = products.ProductLatinName,
                                   ProductLabelName = products.ProductLabelName,
                                   ProductLatinLabelName = products.ProductLatinLabelName,
                                   ProductSerieID = productSerie.ProductSerieID,
                                   ProductSerie = productSerie,
                                   PrintingTechniqueID = printingTechnique.PrintingTechniqueID,
                                   PrintingTechniques = printingTechnique,
                                   TestPlanID = products.TestPlanID,
                                   ShelfLifeMonth = products.ShelfLifeMonth,
                                   TestPlan = products.TestPlan,
                                   //TestPlanAssign = products.TestPlanAssign,
                                   IsSemiProduct = products.IsSemiProduct,
                                   Final_RawMaterialID = products.Final_RawMaterialID,
                                   Final_ProductID = products.Final_ProductID,
                                   IsPaste = products.IsPaste,
                                   BOMSerialCode = products.BOMSerialCode,
                                   IsActive = products.IsActive,
                                   Final_RawMaterial = products.Final_RawMaterial,
                               }

                        ).ToListAsync();

                //return productsss;
                return p;
            }
            catch (System.Exception ex)
            {
                throw;
            }
        }

        public Products GetProductsById(int productID)
        {
            try
            {
                //var products = _repositoryFactory.Products.Table.Include(x => x.ProductSerie).Include(x => x.PrintingTechniques)
                //    .FirstOrDefault(x => x.ProductID == productID);

                var db = _repositoryFactory;
                var p = (from products in db.Products.Table.Include(x => x.TestPlan)
                         join productSerie in db.ProductSeries.Table.Include(x => x.ProductType).ThenInclude(x => x.ProductGroup).ThenInclude(x => x.ProductGroupType) on products.ProductSerieID equals productSerie.ProductSerieID
                         join printingTechniques in db.PrintingTechniques.Table on products.PrintingTechniqueID equals printingTechniques.PrintingTechniqueID into pt_jointable
                         from printingTechnique in pt_jointable.DefaultIfEmpty()
                         where products.ProductID == productID
                         select new Products
                         {

                             ProductID = products.ProductID,
                             ProductCode = products.ProductCode,
                             SerialCode = products.SerialCode,
                             ProductName = products.ProductName,
                             ProductLatinName = products.ProductLatinName,
                             ProductLabelName = products.ProductLabelName,
                             ProductLatinLabelName = products.ProductLatinLabelName,
                             ProductSerieID = productSerie.ProductSerieID,
                             ProductSerie = productSerie,
                             PrintingTechniqueID = printingTechnique.PrintingTechniqueID,
                             PrintingTechniques = printingTechnique,
                             TestPlanID = products.TestPlanID,
                             ShelfLifeMonth = products.ShelfLifeMonth,
                             TestPlan = products.TestPlan,
                             IsSemiProduct = products.IsSemiProduct,
                             Final_RawMaterialID = products.Final_RawMaterialID,
                             Final_ProductID = products.Final_ProductID,
                             IsPaste = products.IsPaste,
                             BOMSerialCode = products.BOMSerialCode,
                             IsActive = products.IsActive,

                         }

                        ).FirstOrDefault();

                //return productsss;
                return p;
            }
            catch
            {
                throw;
            }
        }

        public async Task<Products> GetProductsByIdAsync(int productID)
        {
            try
            {
                //var products = await _repositoryFactory.Products.Table.Include(x => x.ProductSerie).Include(x => x.PrintingTechniques)
                //    .FirstOrDefaultAsync(x => x.ProductID == productID);

                var db = _repositoryFactory;
                var p = (from products in db.Products.Table.Include(x => x.TestPlan)
                         join productSerie in db.ProductSeries.Table.Include(x => x.ProductType).ThenInclude(x => x.ProductGroup).ThenInclude(x => x.ProductGroupType) on products.ProductSerieID equals productSerie.ProductSerieID
                         join printingTechniques in db.PrintingTechniques.Table on products.PrintingTechniqueID equals printingTechniques.PrintingTechniqueID into pt_jointable
                         from printingTechnique in pt_jointable.DefaultIfEmpty()
                         where products.ProductID == productID
                         select new Products
                         {

                             ProductID = products.ProductID,
                             ProductCode = products.ProductCode,
                             SerialCode = products.SerialCode,
                             ProductName = products.ProductName,
                             ProductLatinName = products.ProductLatinName,
                             ProductLabelName = products.ProductLabelName,
                             ProductLatinLabelName = products.ProductLatinLabelName,
                             ProductSerieID = productSerie.ProductSerieID,
                             ProductSerie = productSerie,
                             PrintingTechniqueID = printingTechnique.PrintingTechniqueID,
                             PrintingTechniques = printingTechnique,
                             TestPlanID = products.TestPlanID,
                             ShelfLifeMonth = products.ShelfLifeMonth,
                             TestPlan = products.TestPlan,
                             IsSemiProduct = products.IsSemiProduct,
                             Final_RawMaterialID = products.Final_RawMaterialID,
                             Final_ProductID = products.Final_ProductID,
                             IsPaste = products.IsPaste,
                             BOMSerialCode = products.BOMSerialCode,
                             IsActive = products.IsActive,
                         }

                        ).FirstOrDefault();

                //return productsss;
                return p;
            }
            catch
            {
                throw;
            }
        }

        public int Append(Products products)
        {
            try
            {

                var _newObject = new Products
                {
                    ProductID = products.ProductID,
                    ProductCode = products.ProductCode,
                    SerialCode = products.SerialCode,
                    ProductName = products.ProductName,
                    ProductLatinName = products.ProductLatinName,
                    ProductLabelName = products.ProductLabelName,
                    ProductLatinLabelName = products.ProductLatinLabelName,
                    ProductSerieID = products.ProductSerieID,
                    PrintingTechniqueID = products.PrintingTechniqueID,
                    TestPlanID = products.TestPlanID,
                    ShelfLifeMonth = products.ShelfLifeMonth,
                    IsSemiProduct = products.IsSemiProduct,
                    Final_RawMaterialID = products.Final_RawMaterialID,
                    Final_ProductID = products.Final_ProductID,
                    IsPaste = products.IsPaste,
                    BOMSerialCode = products.BOMSerialCode,
                    IsActive = products.IsActive,
                };


                _repositoryFactory.Products.Add(_newObject);

                var statuse = _unitOfWork.Commit() > 0;

                return _newObject.ProductID;
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }


        public bool Update(Products products)
        {
            try
            {

                _repositoryFactory.Products.UpdateBy(x => x.ProductID == products.ProductID,
                    new Products
                    {
                        ProductID = products.ProductID,
                        ProductCode = products.ProductCode,
                        SerialCode = products.SerialCode,
                        ProductName = products.ProductName,
                        ProductLatinName = products.ProductLatinName,
                        ProductLabelName = products.ProductLabelName,
                        ProductLatinLabelName = products.ProductLatinLabelName,
                        ProductSerieID = products.ProductSerieID,
                        PrintingTechniqueID = products.PrintingTechniqueID,
                        TestPlanID = products.TestPlanID,
                        ShelfLifeMonth = products.ShelfLifeMonth,
                        IsSemiProduct = products.IsSemiProduct,
                        Final_RawMaterialID = products.Final_RawMaterialID,
                        Final_ProductID = products.Final_ProductID,
                        IsPaste = products.IsPaste,
                        BOMSerialCode = products.BOMSerialCode,
                        IsActive = products.IsActive,


                    });
                var statuse = _unitOfWork.Commit() > 0;
                return statuse;
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }

        public long Delete(int productID)
        {
            try
            {
                var products = _repositoryFactory.Products
                    .FirstOrDefault(x => x.ProductID == productID);

                if (products == null)
                    throw new System.Exception("Products Notfound.");

                _repositoryFactory.Products.Delete(products);
                var statuse = _unitOfWork.Commit();

                return statuse;
            }
            catch
            {
                throw;
            }
        }


        public async Task<bool> ExistProductsAsync(string name)
        {
            try
            {

                return await _repositoryFactory.Products.FirstOrDefaultAsync(x => x.ProductName.ToUpper() == name.ToUpper()) != null;
            }
            catch
            {
                throw;
            }
        }

        public async Task<List<Products>> GetAllWithProductTypeAsync()
        {
            try
            {

                var products = _repositoryFactory.Products.Table.Include(x => x.ProductSerie).ThenInclude(x => x.ProductType).ToList();
                return products;
            }
            catch (System.Exception ex)
            {
                throw;
            }
        }

        public async Task<string> GetMaxSerialCodeAsync()
        {
            try
            {
                var maxSerailCode = _repositoryFactory.Products.Table.Max(x => x.SerialCode);

                return maxSerailCode;
            }
            catch (System.Exception ex)
            {
                throw;
            }
        }

        public async Task<string> GetMaxBOMcodeAsync()
        {
            try
            {
                var maxSerailCode = _repositoryFactory.Products.Table.Max(x => x.BOMSerialCode);

                return maxSerailCode;
            }
            catch (System.Exception ex)
            {
                throw;
            }
        }


        public async Task<Products> GetListByFinalRawMaterialID(int finalRawMaterialID)
        {
            try
            {
                var productsss = await _repositoryFactory.Products.Table
                    .Include(x => x.Final_RawMaterial)//.ThenInclude(x=>x.RawMaterial)

                    .FirstOrDefaultAsync(x => x.Final_RawMaterialID == finalRawMaterialID);

                return productsss;
            }
            catch (System.Exception ex)
            {
                throw;
            }
        }


        public async Task<List<Products>> GetProductsByPaletIdAsync(int paletId)
        {
            try
            {

                var products = await _repositoryFactory.PaletDetail
                    .Where(x=>x.PaletID ==  paletId)
                    .Include(x => x.InvProduct).ThenInclude(x => x.Product)
                    .Select(x=>x.InvProduct.Product)
                    .ToListAsync();
                return products;
            }
            catch (System.Exception ex)
            {
                throw;
            }
        }


    }
}
