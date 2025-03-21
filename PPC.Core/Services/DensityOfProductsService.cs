using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PPC.Core.Interface;

using PPC.Core.Models;

using PPC.Core.Repository;

namespace PPC.Core.Services
{
    public class DensityOfProductsService : BaseService, IDensityOfProductsService
    {
        IUnitOfWork _unitOfWork;
        public DensityOfProductsService(RepositoryFactory repositoryFactory,
            IUnitOfWork unitOfWork)
        {
            _repositoryFactory = repositoryFactory;
            _unitOfWork = unitOfWork;
        }


        public List<DensityOfProducts> GetAll()
        {
            try
            {
                var densityOfProducts = _repositoryFactory.DensityOfProducts.Table.Include(x => x.Product).ToList();

                return densityOfProducts;
            }
            catch
            {
                throw;
            }
        }

        public async Task<List<DensityOfProducts>> GetAllAsync()
        {
            try
            {

                var densityOfProducts = await _repositoryFactory.DensityOfProducts.Table.Include(x => x.Product).ToListAsync();
                return densityOfProducts;
            }
            catch (System.Exception ex)
            {
                throw;
            }
        }

        public DensityOfProducts GetDensityOfProductsById(int densityID)
        {
            try
            {
                var densityOfProducts = _repositoryFactory.DensityOfProducts.Table.Include(x => x.Product)
                    .FirstOrDefault(x => x.DensityID == densityID);

                return densityOfProducts;
            }
            catch
            {
                throw;
            }
        }

        public async Task<DensityOfProducts> GetDensityOfProductsByIdAsync(int densityID)
        {
            try
            {
                var densityOfProducts = await _repositoryFactory.DensityOfProducts.Table.Include(x => x.Product)
                    .FirstOrDefaultAsync(x => x.DensityID == densityID);

                return densityOfProducts;
            }
            catch
            {
                throw;
            }
        }

        public List<DensityOfProducts> Append(List<DensityOfProducts> densityOfProducts)
        {
            using (var t = _unitOfWork.StartTransaction())
            {
                try
                {
                    List<DensityOfProducts> _newObject = new List<DensityOfProducts>();
                    densityOfProducts.ForEach(x =>
                    {
                        _newObject.Add(new DensityOfProducts
                        {
                            DensityID = x.DensityID,
                            ProductID = x.ProductID,
                            Density = x.Density,
                        });

                    });

                    GetAll().ForEach(x =>
                    {
                        _repositoryFactory.DensityOfProducts.Delete(x);
                    });

                    _repositoryFactory.DensityOfProducts.AddRange(_newObject);

                    var statuse = _unitOfWork.Commit() > 0;

                    t.Commit();

                    if (statuse)
                        return _newObject;
                    else
                        return null;
                }
                catch (System.Exception)
                {
                    t.Rollback();
                    throw;
                }
            }
        }


        public bool Update(DensityOfProducts densityOfProducts)
        {
            try
            {

                _repositoryFactory.DensityOfProducts.UpdateBy(x => x.DensityID == densityOfProducts.DensityID,
                    new DensityOfProducts
                    {
                        DensityID = densityOfProducts.DensityID,
                        ProductID = densityOfProducts.ProductID,
                        Density = densityOfProducts.Density,


                    });
                var statuse = _unitOfWork.Commit() > 0;
                return statuse;
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }

        public long Delete(int densityID)
        {
            try
            {
                var densityOfProducts = _repositoryFactory.DensityOfProducts
                    .FirstOrDefault(x => x.DensityID == densityID);

                if (densityOfProducts == null)
                    throw new System.Exception("DensityOfProducts Notfound.");

                _repositoryFactory.DensityOfProducts.Delete(densityOfProducts);
                var statuse = _unitOfWork.Commit();

                return statuse;
            }
            catch
            {
                throw;
            }
        }

        public async Task<List<DensityOfProducts>> GetAllByProductAsync(int productId)
        {
            try
            {
                var densityOfProducts = await _repositoryFactory.DensityOfProducts.Where(x => x.ProductID == productId).ToListAsync();

                return densityOfProducts;
            }
            catch
            {
                throw;
            }
        }


    }
}
