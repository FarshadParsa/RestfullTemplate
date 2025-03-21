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

namespace PPC.Core.Services
{
    public class ProductSerieTechniqueAssignsService : BaseService, IProductSerieTechniqueAssignsService
    {
        IUnitOfWork _unitOfWork;
        public ProductSerieTechniqueAssignsService(RepositoryFactory repositoryFactory,
            IUnitOfWork unitOfWork)
        {
            _repositoryFactory = repositoryFactory;
            _unitOfWork = unitOfWork;
        }


        public List<ProductSerieTechniqueAssigns> GetAll()
        {
            try
            {
                var productSerieTechniqueAssigns = _repositoryFactory.ProductSerieTechniqueAssigns.Table.ToList();

                return productSerieTechniqueAssigns;
            }
            catch
            {
                throw;
            }
        }

        public async Task<List<ProductSerieTechniqueAssigns>> GetAllAsync()
        {
            try
            {

                var productSerieTechniqueAssigns = await _repositoryFactory.ProductSerieTechniqueAssigns.Table.ToListAsync();
                return productSerieTechniqueAssigns;
            }
            catch (System.Exception ex)
            {
                throw;
            }
        }

        public ProductSerieTechniqueAssigns GetProductSerieTechniqueAssignsById(int productSerieTechniqueAssignID)
        {
            try
            {
                var productSerieTechniqueAssigns = _repositoryFactory.ProductSerieTechniqueAssigns
                    .FirstOrDefault(x => x.ProductSerieTechniqueAssignID == productSerieTechniqueAssignID);

                return productSerieTechniqueAssigns;
            }
            catch
            {
                throw;
            }
        }

        public async Task<ProductSerieTechniqueAssigns> GetProductSerieTechniqueAssignsByIdAsync(int productSerieTechniqueAssignID)
        {
            try
            {
                var productSerieTechniqueAssigns = await _repositoryFactory.ProductSerieTechniqueAssigns
                    .FirstOrDefaultAsync(x => x.ProductSerieTechniqueAssignID == productSerieTechniqueAssignID);

                return productSerieTechniqueAssigns;
            }
            catch
            {
                throw;
            }
        }

        public bool Append(ProductSerieTechniqueAssigns productSerieTechniqueAssigns)
        {
            try
            {
                _repositoryFactory.ProductSerieTechniqueAssigns.Add(
                    new ProductSerieTechniqueAssigns
                    {
                        ProductSerieTechniqueAssignID = productSerieTechniqueAssigns.ProductSerieTechniqueAssignID,
                        ProductSerieID = productSerieTechniqueAssigns.ProductSerieID,
                        PrintingTechniqueID = productSerieTechniqueAssigns.PrintingTechniqueID,


                    });
                var statuse = _unitOfWork.Commit() > 0;
                return statuse;
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }


        public bool Update(ProductSerieTechniqueAssigns productSerieTechniqueAssigns)
        {
            try
            {

                _repositoryFactory.ProductSerieTechniqueAssigns.UpdateBy(x => x.ProductSerieTechniqueAssignID == productSerieTechniqueAssigns.ProductSerieTechniqueAssignID,
                    new ProductSerieTechniqueAssigns
                    {
                        ProductSerieTechniqueAssignID = productSerieTechniqueAssigns.ProductSerieTechniqueAssignID,
                        ProductSerieID = productSerieTechniqueAssigns.ProductSerieID,
                        PrintingTechniqueID = productSerieTechniqueAssigns.PrintingTechniqueID,


                    });
                var statuse = _unitOfWork.Commit() > 0;
                return statuse;
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }

        public long Delete(int productSerieTechniqueAssignID)
        {
            try
            {
                var productSerieTechniqueAssigns = _repositoryFactory.ProductSerieTechniqueAssigns
                    .FirstOrDefault(x => x.ProductSerieTechniqueAssignID == productSerieTechniqueAssignID);

                if (productSerieTechniqueAssigns == null)
                    throw new System.Exception("ProductSerieTechniqueAssigns Notfound.");

                _repositoryFactory.ProductSerieTechniqueAssigns.Delete(productSerieTechniqueAssigns);
                var statuse = _unitOfWork.Commit();

                return statuse;
            }
            catch
            {
                throw;
            }
        }

        public async Task<List<ProductSerieTechniqueAssigns>> GetProductSerieTechniqueAssignsBySerieIdAsync(int productSerieID)
        {
            try
            {
                var productSerieTechniqueAssigns = await _repositoryFactory.ProductSerieTechniqueAssigns
                    .Where(x => x.ProductSerieID == productSerieID).ToListAsync();

                return productSerieTechniqueAssigns;
            }
            catch
            {
                throw;
            }
        }


    }
}
