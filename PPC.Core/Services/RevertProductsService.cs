using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PPC.Core.Interface;
using PPC.Core.Models;
using PPC.Core.Repository;
namespace PPC.Core.Services
{
    public class RevertProductsService : BaseService, IRevertProductsService
    {
        //IUnitOfWork _unitOfWork;
        public RevertProductsService(RepositoryFactory repositoryFactory,
            IUnitOfWork unitOfWork)
        {
            _repositoryFactory = repositoryFactory;
            _unitOfWork = unitOfWork;
        }


        public List<RevertProducts> GetAll()
        {
            try
            {
                var revertProducts = _repositoryFactory.RevertProducts.Table.ToList();

                return revertProducts;
            }
            catch
            {
                throw;
            }
        }

        public async Task<List<RevertProducts>> GetAllAsync()
        {
            try
            {

                var revertProducts = await _repositoryFactory.RevertProducts.Table.ToListAsync();
                return revertProducts;
            }
            catch (System.Exception ex)
            {
                throw;
            }
        }

        public RevertProducts GetRevertProductsById(int id)
        {
            try
            {
                var revertProducts = _repositoryFactory.RevertProducts
                    .FirstOrDefault(x => x.Id == id);

                return revertProducts;
            }
            catch
            {
                throw;
            }
        }

        public async Task<RevertProducts> GetRevertProductsByIdAsync(int id)
        {
            try
            {
                var revertProducts = await _repositoryFactory.RevertProducts
                    .FirstOrDefaultAsync(x => x.Id == id);

                return revertProducts;
            }
            catch
            {
                throw;
            }
        }

        public int Append(RevertProducts revertProducts)
        {
            try
            {
                var _newObject = new RevertProducts
                {
                    Id = revertProducts.Id,
                    RevertID = revertProducts.RevertID,
                    InvProductID = revertProducts.InvProductID,
                    NewInvProductID = revertProducts.NewInvProductID,
                    Remark = revertProducts.Remark,
                    InsertUserId = revertProducts.InsertUserId,
                    UpdateUserId = revertProducts.UpdateUserId,
                    InsertDateTime = revertProducts.InsertDateTime,
                    UpdateDateTime = revertProducts.UpdateDateTime,


                };

                _repositoryFactory.RevertProducts.Add(_newObject);

                var statuse = _unitOfWork.Commit() > 0;

                if (statuse)
                    return _newObject.Id;
                else
                    throw new System.Exception(Resources.Resources.pub_RegistrationHasError);
            }
            catch (System.Exception)
            {
                throw;
            }
        }


        public bool Update(RevertProducts revertProducts)
        {
            try
            {

                _repositoryFactory.RevertProducts.UpdateBy(x => x.Id == revertProducts.Id,
                    new RevertProducts
                    {
                        Id = revertProducts.Id,
                        RevertID = revertProducts.RevertID,
                        InvProductID = revertProducts.InvProductID,
                        NewInvProductID = revertProducts.NewInvProductID,
                        Remark = revertProducts.Remark,
                        InsertUserId = revertProducts.InsertUserId,
                        UpdateUserId = revertProducts.UpdateUserId,
                        InsertDateTime = revertProducts.InsertDateTime,
                        UpdateDateTime = revertProducts.UpdateDateTime,


                    });
                var statuse = _unitOfWork.Commit() > 0;
                return statuse;
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }

        public long Delete(int id)
        {
            try
            {
                var revertProducts = _repositoryFactory.RevertProducts
                    .FirstOrDefault(x => x.Id == id);

                if (revertProducts == null)
                    throw new System.Exception("RevertProducts not found.");

                _repositoryFactory.RevertProducts.Delete(revertProducts);
                var statuse = _unitOfWork.Commit();

                return statuse;
            }
            catch
            {
                throw;
            }
        }




    }
}
