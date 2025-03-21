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
    public class ProductGroupTypesService : BaseService, IProductGroupTypesService
    {
        IUnitOfWork _unitOfWork;
        public ProductGroupTypesService(RepositoryFactory repositoryFactory,
            IUnitOfWork unitOfWork)
        {
            _repositoryFactory = repositoryFactory;
            _unitOfWork = unitOfWork;
        }


        public List<ProductGroupTypes> GetAll()
        {
            try
            {
                var productGroupTypes = _repositoryFactory.ProductGroupTypes.Table.ToList();

                return productGroupTypes;
            }
            catch
            {
                throw;
            }
        }

        public async Task<List<ProductGroupTypes>> GetAllAsync()
        {
            try
            {

                var productGroupTypes = await _repositoryFactory.ProductGroupTypes.Table.ToListAsync();
                return productGroupTypes;
            }
            catch (System.Exception ex)
            {
                throw;
            }
        }

        public ProductGroupTypes GetProductGroupTypesById(short productGroupTypeID)
        {
            try
            {
                var productGroupTypes = _repositoryFactory.ProductGroupTypes
                    .FirstOrDefault(x => x.ProductGroupTypeID == productGroupTypeID);

                return productGroupTypes;
            }
            catch
            {
                throw;
            }
        }

        public async Task<ProductGroupTypes> GetProductGroupTypesByIdAsync(short productGroupTypeID)
        {
            try
            {
                var productGroupTypes = await _repositoryFactory.ProductGroupTypes
                    .FirstOrDefaultAsync(x => x.ProductGroupTypeID == productGroupTypeID);

                return productGroupTypes;
            }
            catch
            {
                throw;
            }
        }

        public bool Append(ProductGroupTypes productGroupTypes)
        {
            try
            {
                _repositoryFactory.ProductGroupTypes.Add(
                    new ProductGroupTypes
                    {
                        ProductGroupTypeID = productGroupTypes.ProductGroupTypeID,
                        ProductGroupTypeName = productGroupTypes.ProductGroupTypeName,
                        ProductGroupTypeLatinName = productGroupTypes.ProductGroupTypeLatinName,
                        IsActive = productGroupTypes.IsActive,


                    });
                var statuse = _unitOfWork.Commit() > 0;
                return statuse;
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }


        public bool Update(ProductGroupTypes productGroupTypes)
        {
            try
            {

                _repositoryFactory.ProductGroupTypes.UpdateBy(x => x.ProductGroupTypeID == productGroupTypes.ProductGroupTypeID,
                    new ProductGroupTypes
                    {
                        ProductGroupTypeID = productGroupTypes.ProductGroupTypeID,
                        ProductGroupTypeName = productGroupTypes.ProductGroupTypeName,
                        ProductGroupTypeLatinName = productGroupTypes.ProductGroupTypeLatinName,
                        IsActive = productGroupTypes.IsActive,


                    });
                var statuse = _unitOfWork.Commit() > 0;
                return statuse;
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }

        public long Delete(short productGroupTypeID)
        {
            try
            {
                var productGroupTypes = _repositoryFactory.ProductGroupTypes
                    .FirstOrDefault(x => x.ProductGroupTypeID == productGroupTypeID);

                if (productGroupTypes == null)
                    throw new System.Exception("ProductGroupTypes Notfound.");

                _repositoryFactory.ProductGroupTypes.Delete(productGroupTypes);
                var statuse = _unitOfWork.Commit();

                return statuse;
            }
            catch
            {
                throw;
            }
        }


        public async Task<bool> ExistProductGroupTypesAsync(string name)
        {
            try
            {

                return await _repositoryFactory.ProductGroupTypes.FirstOrDefaultAsync(x => x.ProductGroupTypeName.ToUpper() == name.ToUpper()) != null;
            }
            catch
            {
                throw;
            }
        }
    }
}
