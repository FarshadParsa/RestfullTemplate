using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Linq;
using Microsoft.EntityFrameworkCore;
using PPC.Core.Models;
using PPC.Core.Repository;
using PPC.Core.Interface;

namespace PPC.Core.Services
{
    public class ProductTypesService : BaseService, IProductTypesService
    {
        IUnitOfWork _unitOfWork;
        public ProductTypesService(RepositoryFactory repositoryFactory,
            IUnitOfWork unitOfWork)
        {
            _repositoryFactory = repositoryFactory;
            _unitOfWork = unitOfWork;
        }


        public List<ProductTypes> GetAll()
        {
            try
            {
                var productTypes = _repositoryFactory.ProductTypes.Table.Include(x => x.ProductGroup).ToList();

                return productTypes;
            }
            catch
            {
                throw;
            }
        }

        public async Task<List<ProductTypes>> GetAllAsync()
        {
            try
            {

                var productTypes = await _repositoryFactory.ProductTypes.Table.Include(x => x.ProductGroup).ToListAsync();
                return productTypes;
            }
            catch (System.Exception ex)
            {
                throw;
            }
        }

        public ProductTypes GetProductTypesById(short productTypeID)
        {
            try
            {
                var productTypes = _repositoryFactory.ProductTypes.Table.Include(x => x.ProductGroup)
                    .FirstOrDefault(x => x.ProductTypeID == productTypeID);

                return productTypes;
            }
            catch
            {
                throw;
            }
        }

        public async Task<ProductTypes> GetProductTypesByIdAsync(short productTypeID)
        {
            try
            {
                var productTypes = await _repositoryFactory.ProductTypes.Table.Include(x => x.ProductGroup)
                    .FirstOrDefaultAsync(x => x.ProductTypeID == productTypeID);

                return productTypes;
            }
            catch
            {
                throw;
            }
        }

        public bool Append(ProductTypes productTypes)
        {
            try
            {
                _repositoryFactory.ProductTypes.Add(
                    new ProductTypes
                    {
                        ProductTypeID = productTypes.ProductTypeID,
                        ProductTypeName = productTypes.ProductTypeName,
                        ProductTypeLatinName = productTypes.ProductTypeLatinName,
                        ProductTypeLabelName = productTypes.ProductTypeLabelName,
                        ProductTypeLabelLatinName = productTypes.ProductTypeLabelLatinName,
                        ProductGroupID = productTypes.ProductGroupID,
                        BOMSerialCode = productTypes.BOMSerialCode,
                        IsActive = productTypes.IsActive,


                    });
                var statuse = _unitOfWork.Commit() > 0;
                return statuse;
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }


        public bool Update(ProductTypes productTypes)
        {
            try
            {

                _repositoryFactory.ProductTypes.UpdateBy(x => x.ProductTypeID == productTypes.ProductTypeID,
                    new ProductTypes
                    {
                        ProductTypeID = productTypes.ProductTypeID,
                        ProductTypeName = productTypes.ProductTypeName,
                        ProductTypeLatinName = productTypes.ProductTypeLatinName,
                        ProductTypeLabelName = productTypes.ProductTypeLabelName,
                        ProductTypeLabelLatinName = productTypes.ProductTypeLabelLatinName,
                        ProductGroupID = productTypes.ProductGroupID,
                        BOMSerialCode = productTypes.BOMSerialCode,
                        IsActive = productTypes.IsActive,


                    });
                var statuse = _unitOfWork.Commit() > 0;
                return statuse;
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }

        public long Delete(short productTypeID)
        {
            try
            {
                var productTypes = _repositoryFactory.ProductTypes
                    .FirstOrDefault(x => x.ProductTypeID == productTypeID);

                if (productTypes == null)
                    throw new System.Exception("ProductTypes Notfound.");

                _repositoryFactory.ProductTypes.Delete(productTypes);
                var statuse = _unitOfWork.Commit();

                return statuse;
            }
            catch
            {
                throw;
            }
        }


        public async Task<bool> ExistProductTypesAsync(string name)
        {
            try
            {

                return await _repositoryFactory.ProductTypes.FirstOrDefaultAsync(x => x.ProductTypeName.ToUpper() == name.ToUpper()) != null;
            }
            catch
            {
                throw;
            }
        }
    }
}
