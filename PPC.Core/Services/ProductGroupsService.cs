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
    public class ProductGroupsService : BaseService, IProductGroupsService
    {
        IUnitOfWork _unitOfWork;
        public ProductGroupsService(RepositoryFactory repositoryFactory,
            IUnitOfWork unitOfWork)
        {
            _repositoryFactory = repositoryFactory;
            _unitOfWork = unitOfWork;
        }


        public List<ProductGroups> GetAll()
        {
            try
            {
                var productGroups = _repositoryFactory.ProductGroups.Table.Include(x=>x.ProductGroupType).ToList();

                return productGroups;
            }
            catch
            {
                throw;
            }
        }

        public async Task<List<ProductGroups>> GetAllAsync()
        {
            try
            {

                var productGroups = await _repositoryFactory.ProductGroups.Table.Include(x => x.ProductGroupType).ToListAsync();
                return productGroups;
            }
            catch (System.Exception ex)
            {
                throw;
            }
        }

        public ProductGroups GetProductGroupsById(short productGroupID)
        {
            try
            {
                var productGroups = _repositoryFactory.ProductGroups.Table.Include(x => x.ProductGroupType)
                    .FirstOrDefault(x => x.ProductGroupID == productGroupID);

                return productGroups;
            }
            catch
            {
                throw;
            }
        }

        public async Task<ProductGroups> GetProductGroupsByIdAsync(short productGroupID)
        {
            try
            {
                var productGroups = await _repositoryFactory.ProductGroups.Table.Include(x => x.ProductGroupType)
                    .FirstOrDefaultAsync(x => x.ProductGroupID == productGroupID);

                return productGroups;
            }
            catch
            {
                throw;
            }
        }

        public bool Append(ProductGroups productGroups)
        {
            try
            {
                _repositoryFactory.ProductGroups.Add(
                    new ProductGroups
                    {
                        ProductGroupID = productGroups.ProductGroupID,
                        ProductGroupName = productGroups.ProductGroupName,
                        ProductGroupLatinName = productGroups.ProductGroupLatinName,
                        ProductGroupTypeID = productGroups.ProductGroupTypeID,
                        BOMSerialCode = productGroups.BOMSerialCode,
                        IsActive = productGroups.IsActive,


                    });
                var statuse = _unitOfWork.Commit() > 0;
                return statuse;
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }


        public bool Update(ProductGroups productGroups)
        {
            try
            {

                _repositoryFactory.ProductGroups.UpdateBy(x => x.ProductGroupID == productGroups.ProductGroupID,
                    new ProductGroups
                    {
                        ProductGroupID = productGroups.ProductGroupID,
                        ProductGroupName = productGroups.ProductGroupName,
                        ProductGroupLatinName = productGroups.ProductGroupLatinName,
                        ProductGroupTypeID = productGroups.ProductGroupTypeID,
                        BOMSerialCode = productGroups.BOMSerialCode,
                        IsActive = productGroups.IsActive,


                    });
                var statuse = _unitOfWork.Commit() > 0;
                return statuse;
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }

        public long Delete(short productGroupID)
        {
            try
            {
                var productGroups = _repositoryFactory.ProductGroups
                    .FirstOrDefault(x => x.ProductGroupID == productGroupID);

                if (productGroups == null)
                    throw new System.Exception("ProductGroups Notfound.");

                _repositoryFactory.ProductGroups.Delete(productGroups);
                var statuse = _unitOfWork.Commit();

                return statuse;
            }
            catch
            {
                throw;
            }
        }


        public async Task<bool> ExistProductGroupsAsync(string name)
        {
            try
            {

                return await _repositoryFactory.ProductGroups.FirstOrDefaultAsync(x => x.ProductGroupName.ToUpper() == name.ToUpper()) != null;
            }
            catch
            {
                throw;
            }
        }
    }
}
