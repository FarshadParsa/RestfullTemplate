using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PPC.Core.Interface;

using PPC.Core.Models;

using PPC.Core.Repository;

namespace PPC.Core.Services
{
    public class ProductSeriesService : BaseService, IProductSeriesService
    {
        IUnitOfWork _unitOfWork;
        public ProductSeriesService(RepositoryFactory repositoryFactory,
            IUnitOfWork unitOfWork)
        {
            _repositoryFactory = repositoryFactory;
            _unitOfWork = unitOfWork;
        }


        public List<ProductSeries> GetAll()
        {
            try
            {
                var productSeries = _repositoryFactory.ProductSeries.Table.ToList();

                return productSeries;
            }
            catch
            {
                throw;
            }
        }

        public async Task<List<ProductSeries>> GetAllAsync(bool getPrintingTechniques = false)
        {
            //try
            //{

            //    var productSeries = await _repositoryFactory.ProductSeries.Table.ToListAsync();
            //    return productSeries;
            //}
            //catch (System.Exception ex)
            //{
            //    throw;
            //}

            try
            {
                if (!getPrintingTechniques)
                {
                    var productSeries = await _repositoryFactory.ProductSeries.Table.Include(x => x.ProductType).ToListAsync();
                    return productSeries;
                }
                else
                {

                    var db = _repositoryFactory;

                    //var productSeriessss = (from pt in db.PrintingTechniques.Table join
                    //                     pstAssign in db.ProductSerieTechniqueAssigns.Table on pt.PrintingTechniqueID equals pstAssign.PrintingTechniqueID join
                    //                     ps in db.ProductSeries.Table on pstAssign.ProductSerieID equals ps.ProductSerieID

                    //                     select new
                    //                     {

                    //                         ps.ProductSerieID,
                    //                         ps.ProductSerieName,
                    //                         ps.ProductTypeID,
                    //                         ps.ProductType,
                    //                         ps.ProductSerieLabelName,
                    //                         ps.ProductSerieLatinLabelName,
                    //                         ps.Usages,
                    //                         ps.IsActive,
                    //                         PrintingTechniques= _repositoryFactory.PrintingTechniques.Where(x=>x.PrintingTechniqueID==1)
                    //                         //new ps.PrintingTechnique
                    //                         //PrintingTechniques = new PrintingTechniques()
                    //                         //PrintingTechniques = db.PrintingTechniques.Table.Select(x=>x.PrintingTechniqueID == pstAssign.PrintingTechniqueID),
                    //                         //PrintingTechniques = pt,//PrintingTechniques = new List<PrintingTechniques>() { pt },

                    //                     }

                    //                     ).ToList().ToList();

                    var productSeries = await _repositoryFactory.ProductSeries.Table.Include(x => x.ProductType).ToListAsync();
                    return productSeries;
                }

            }
            catch (System.Exception ex)
            {
                throw;
            }
        }

        public ProductSeries GetProductSeriesById(int productSerieID)
        {
            try
            {
                var productSeries = _repositoryFactory.ProductSeries
                    .FirstOrDefault(x => x.ProductSerieID == productSerieID);

                return productSeries;
            }
            catch
            {
                throw;
            }
        }

        public async Task<ProductSeries> GetProductSeriesByIdAsync(int productSerieID)
        {
            try
            {
                var productSeries = await _repositoryFactory.ProductSeries
                    .FirstOrDefaultAsync(x => x.ProductSerieID == productSerieID);

                return productSeries;
            }
            catch
            {
                throw;
            }
        }

        public int Append(ProductSeries productSeries)
        {
            using (var tr = _unitOfWork.StartTransaction())
            {


                try
                {
                    var _newObject = new ProductSeries
                    {
                        ProductSerieID = productSeries.ProductSerieID,
                        ProductSerieName = productSeries.ProductSerieName,
                        ProductTypeID = productSeries.ProductTypeID,
                        ProductSerieLabelName = productSeries.ProductSerieLabelName,
                        ProductSerieLatinLabelName = productSeries.ProductSerieLatinLabelName,
                        Usages = productSeries.Usages,
                        BOMSerialCode = productSeries.BOMSerialCode,
                        IsActive = productSeries.IsActive,
                    };

                    _repositoryFactory.ProductSeries.Add(_newObject);
                    var statuse = _unitOfWork.Commit() > 0;

                    productSeries.ProductSerieTechniqueList.ForEach(x =>
                    _repositoryFactory.ProductSerieTechniqueAssigns.Add(
                        new ProductSerieTechniqueAssigns()
                        {
                            ProductSerieID = _newObject.ProductSerieID,
                            PrintingTechniqueID = x.PrintingTechniqueID
                        }));

                    statuse &= _unitOfWork.Commit() > 0;

                    tr.Commit();


                    if (statuse)
                        return _newObject.ProductSerieID;
                    else
                        return int.MinValue;
                }
                catch (System.Exception)
                {
                    tr.Rollback();
                    throw;
                }
            }
        }


        public bool Update(ProductSeries productSeries)
        {
            using (var tr = _unitOfWork.StartTransaction())
            {
                try
                {

                    _repositoryFactory.ProductSeries.UpdateBy(x => x.ProductSerieID == productSeries.ProductSerieID,
                        new ProductSeries
                        {
                            ProductSerieID = productSeries.ProductSerieID,
                            ProductSerieName = productSeries.ProductSerieName,
                            ProductTypeID = productSeries.ProductTypeID,
                            ProductSerieLabelName = productSeries.ProductSerieLabelName,
                            ProductSerieLatinLabelName = productSeries.ProductSerieLatinLabelName,
                            Usages = productSeries.Usages,
                            BOMSerialCode = productSeries.BOMSerialCode,
                            IsActive = productSeries.IsActive,
                        });

                    _repositoryFactory.ProductSerieTechniqueAssigns.DeleteBy(x => x.ProductSerieID == productSeries.ProductSerieID);

                    productSeries.ProductSerieTechniqueList.ForEach(x =>

                    _repositoryFactory.ProductSerieTechniqueAssigns.Add(
                        new ProductSerieTechniqueAssigns()
                        {
                            ProductSerieID = productSeries.ProductSerieID,
                            PrintingTechniqueID = x.PrintingTechniqueID
                        }));

                    var statuse = _unitOfWork.Commit() > 0;

                    tr.Commit();

                    return statuse;
                }
                catch (System.Exception ex)
                {
                    tr.Rollback();
                    throw ex;
                }
            }
        }

        public long Delete(int productSerieID)
        {
            try
            {
                var productSeries = _repositoryFactory.ProductSeries
                    .FirstOrDefault(x => x.ProductSerieID == productSerieID);

                if (productSeries == null)
                    throw new System.Exception("ProductSeries Notfound.");

                _repositoryFactory.ProductSeries.Delete(productSeries);
                var statuse = _unitOfWork.Commit();

                return statuse;
            }
            catch
            {
                throw;
            }
        }


        public async Task<bool> ExistProductSeriesAsync(string name)
        {
            try
            {

                return await _repositoryFactory.ProductSeries.FirstOrDefaultAsync(x => x.ProductSerieName.ToUpper() == name.ToUpper()) != null;
            }
            catch
            {
                throw;
            }
        }

        public async Task<List<ProductSeries>> GetAllParentAsync(bool getPrintingTechniques = false)
        {
            try
            {
                if (!getPrintingTechniques)
                {
                    var productSeries = await _repositoryFactory.ProductSeries.Table.Include(x => x.ProductType).ThenInclude(x => x.ProductGroup).ThenInclude(x => x.ProductGroupType).ToListAsync();
                    return productSeries;
                }
                else
                {

                    //var db = _repositoryFactory;

                    //var productSeriessss = (from pt in db.PrintingTechniques.Table
                    //                        join
                    //                     pstAssign in db.ProductSerieTechniqueAssigns.Table on pt.PrintingTechniqueID equals pstAssign.PrintingTechniqueID
                    //                        join
                    //                     ps in db.ProductSeries.Table on pstAssign.ProductSerieID equals ps.ProductSerieID

                    //                        select new
                    //                        {

                    //                            ps.ProductSerieID,
                    //                            ps.ProductSerieName,
                    //                            ps.ProductTypeID,
                    //                            ps.ProductType,
                    //                            ps.ProductSerieLabelName,
                    //                            ps.ProductSerieLatinLabelName,
                    //                            ps.Usages,
                    //                            ps.IsActive,
                    //                            PrintingTechniques = _repositoryFactory.PrintingTechniques.Where(x => x.PrintingTechniqueID == 1)
                    //                        }

                    //                     ).ToList().ToList();

                    var productSeries = await _repositoryFactory.ProductSeries.Table.Include(x => x.ProductType).ToListAsync();
                    return productSeries;
                }

            }
            catch (System.Exception ex)
            {
                throw;
            }
        }

    }
}


/*
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
using PPC.Response.DTOs;

namespace PPC.Core.Services
{
    public class ProductSeriesService : BaseService, IProductSeriesService
    {
        IUnitOfWork _unitOfWork;
        public ProductSeriesService(RepositoryFactory repositoryFactory,
            IUnitOfWork unitOfWork)
        {
            _repositoryFactory = repositoryFactory;
            _unitOfWork = unitOfWork;
        }


        public List<ProductSeries> GetAll(bool getPrintingTechniques = false)
        {
            try
            {
                var productSeries = _repositoryFactory.ProductSeries.Table.Include(x=>x.ProductType).ToList();

                return productSeries;
            }
            catch
            {
                throw;
            }
        }

        public async Task<List<ProductSeries>> GetAllAsync(bool getPrintingTechniques = false)
        {
            try
            {
                if (!getPrintingTechniques)
                {
                    var productSeries = await _repositoryFactory.ProductSeries.Table.Include(x => x.ProductType).ToListAsync();
                    return productSeries;
                }
                else
                {

                    var db = _repositoryFactory;

                    //var productSeriessss = (from pt in db.PrintingTechniques.Table join
                    //                     pstAssign in db.ProductSerieTechniqueAssigns.Table on pt.PrintingTechniqueID equals pstAssign.PrintingTechniqueID join
                    //                     ps in db.ProductSeries.Table on pstAssign.ProductSerieID equals ps.ProductSerieID

                    //                     select new
                    //                     {

                    //                         ps.ProductSerieID,
                    //                         ps.ProductSerieName,
                    //                         ps.ProductTypeID,
                    //                         ps.ProductType,
                    //                         ps.ProductSerieLabelName,
                    //                         ps.ProductSerieLatinLabelName,
                    //                         ps.Usages,
                    //                         ps.IsActive,
                    //                         PrintingTechniques= _repositoryFactory.PrintingTechniques.Where(x=>x.PrintingTechniqueID==1)
                    //                         //new ps.PrintingTechnique
                    //                         //PrintingTechniques = new PrintingTechniques()
                    //                         //PrintingTechniques = db.PrintingTechniques.Table.Select(x=>x.PrintingTechniqueID == pstAssign.PrintingTechniqueID),
                    //                         //PrintingTechniques = pt,//PrintingTechniques = new List<PrintingTechniques>() { pt },

                    //                     }

                    //                     ).ToList().ToList();

                    var productSeries = await _repositoryFactory.ProductSeries.Table.Include(x => x.ProductType).ToListAsync();
                    return productSeries;
                }

            }
            catch (System.Exception ex)
            {
                throw;
            }
        }

        public ProductSeries GetProductSeriesById(int productSerieID)
        {
            try
            {
                var productSeries = _repositoryFactory.ProductSeries.Table.Include(x => x.ProductType)
                    .FirstOrDefault(x => x.ProductSerieID == productSerieID);

                return productSeries;
            }
            catch
            {
                throw;
            }
        }

        public async Task<ProductSeries> GetProductSeriesByIdAsync(int productSerieID)
        {
            try
            {
                var productSeries = await _repositoryFactory.ProductSeries.Table.Include(x => x.ProductType)
                    .FirstOrDefaultAsync(x => x.ProductSerieID == productSerieID);

                return productSeries;
            }
            catch
            {
                throw;
            }
        }

        public bool Append(ProductSeries productSeries)
        {

            try
            {
                _repositoryFactory.ProductSeries.Add(
                    new ProductSeries
                    {
                        ProductSerieID = productSeries.ProductSerieID,
                        ProductSerieName = productSeries.ProductSerieName,
                        ProductTypeID = productSeries.ProductTypeID,
                        ProductSerieLabelName = productSeries.ProductSerieLabelName,
                        ProductSerieLatinLabelName = productSeries.ProductSerieLatinLabelName,
                        Usages = productSeries.Usages,
                        IsActive = productSeries.IsActive,


                    });
                var statuse = _unitOfWork.Commit() > 0;
                return statuse;
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }


        public bool Update(ProductSeries productSeries)
        {
            try
            {

                _repositoryFactory.ProductSeries.UpdateBy(x => x.ProductSerieID == productSeries.ProductSerieID,
                    new ProductSeries
                    {
                        ProductSerieID = productSeries.ProductSerieID,
                        ProductSerieName = productSeries.ProductSerieName,
                        ProductTypeID = productSeries.ProductTypeID,
                        ProductSerieLabelName = productSeries.ProductSerieLabelName,
                        ProductSerieLatinLabelName = productSeries.ProductSerieLatinLabelName,
                        Usages = productSeries.Usages,
                        IsActive = productSeries.IsActive,


                    });
                var statuse = _unitOfWork.Commit() > 0;
                return statuse;
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }

        public long Delete(int productSerieID)
        {
            try
            {
                var productSeries = _repositoryFactory.ProductSeries
                    .FirstOrDefault(x => x.ProductSerieID == productSerieID);

                if (productSeries == null)
                    throw new System.Exception("ProductSeries Notfound.");

                _repositoryFactory.ProductSeries.Delete(productSeries);
                var statuse = _unitOfWork.Commit();

                return statuse;
            }
            catch
            {
                throw;
            }
        }


        public async Task<bool> ExistProductSeriesAsync(string name)
        {
            try
            {

                return await _repositoryFactory.ProductSeries.FirstOrDefaultAsync(x => x.ProductSerieName.ToUpper() == name.ToUpper()) != null;
            }
            catch
            {
                throw;
            }
        }


        public async Task<List<ProductSeries>> GetAllParentAsync(bool getPrintingTechniques = false)
        {
            try
            {
                if (!getPrintingTechniques)
                {
                    var productSeries = await _repositoryFactory.ProductSeries.Table.Include(x => x.ProductType).ThenInclude(x => x.ProductGroup).ThenInclude(x=>x.ProductGroupType).ToListAsync();
                    return productSeries;
                }
                else
                {

                    //var db = _repositoryFactory;

                    //var productSeriessss = (from pt in db.PrintingTechniques.Table
                    //                        join
                    //                     pstAssign in db.ProductSerieTechniqueAssigns.Table on pt.PrintingTechniqueID equals pstAssign.PrintingTechniqueID
                    //                        join
                    //                     ps in db.ProductSeries.Table on pstAssign.ProductSerieID equals ps.ProductSerieID

                    //                        select new
                    //                        {

                    //                            ps.ProductSerieID,
                    //                            ps.ProductSerieName,
                    //                            ps.ProductTypeID,
                    //                            ps.ProductType,
                    //                            ps.ProductSerieLabelName,
                    //                            ps.ProductSerieLatinLabelName,
                    //                            ps.Usages,
                    //                            ps.IsActive,
                    //                            PrintingTechniques = _repositoryFactory.PrintingTechniques.Where(x => x.PrintingTechniqueID == 1)
                    //                        }

                    //                     ).ToList().ToList();

                    var productSeries = await _repositoryFactory.ProductSeries.Table.Include(x => x.ProductType).ToListAsync();
                    return productSeries;
                }

            }
            catch (System.Exception ex)
            {
                throw;
            }
        }


    }
}
*/