using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PPC.Core.Interface;
using PPC.Core.Models;
using PPC.Core.Repository;
namespace PPC.Core.Services
{
    public class RevertPaletsService : BaseService, IRevertPaletsService
    {
        //IUnitOfWork _unitOfWork;
        public RevertPaletsService(RepositoryFactory repositoryFactory,
            IUnitOfWork unitOfWork)
        {
            _repositoryFactory = repositoryFactory;
            _unitOfWork = unitOfWork;
        }


        public List<RevertPalets> GetAll()
        {
            try
            {
                var revertPalets = _repositoryFactory.RevertPalets.Table.ToList();

                return revertPalets;
            }
            catch
            {
                throw;
            }
        }

        public async Task<List<RevertPalets>> GetAllAsync()
        {
            try
            {

                var revertPalets = await _repositoryFactory.RevertPalets.Table.ToListAsync();
                return revertPalets;
            }
            catch (System.Exception ex)
            {
                throw;
            }
        }

        public RevertPalets GetRevertPaletsById(int id)
        {
            try
            {
                var revertPalets = _repositoryFactory.RevertPalets
                    .FirstOrDefault(x => x.Id == id);

                return revertPalets;
            }
            catch
            {
                throw;
            }
        }

        public async Task<RevertPalets> GetRevertPaletsByIdAsync(int id)
        {
            try
            {
                var revertPalets = await _repositoryFactory.RevertPalets
                    .FirstOrDefaultAsync(x => x.Id == id);

                return revertPalets;
            }
            catch
            {
                throw;
            }
        }

        public int Append(RevertPalets revertPalets)
        {
            try
            {
                var _newObject = new RevertPalets
                {
                    Id = revertPalets.Id,
                    RevertID = revertPalets.RevertID,
                    PaletID = revertPalets.PaletID,
                    NewPaletID = revertPalets.NewPaletID,
                    Remark = revertPalets.Remark,
                    InsertUserId = revertPalets.InsertUserId,
                    UpdateUserId = revertPalets.UpdateUserId,
                    InsertDateTime = revertPalets.InsertDateTime,
                    UpdateDateTime = revertPalets.UpdateDateTime,


                };

                _repositoryFactory.RevertPalets.Add(_newObject);

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


        public bool Update(RevertPalets revertPalets)
        {
            try
            {

                _repositoryFactory.RevertPalets.UpdateBy(x => x.Id == revertPalets.Id,
                    new RevertPalets
                    {
                        Id = revertPalets.Id,
                        RevertID = revertPalets.RevertID,
                        PaletID = revertPalets.PaletID,
                        NewPaletID = revertPalets.NewPaletID,
                        Remark = revertPalets.Remark,
                        InsertUserId = revertPalets.InsertUserId,
                        UpdateUserId = revertPalets.UpdateUserId,
                        InsertDateTime = revertPalets.InsertDateTime,
                        UpdateDateTime = revertPalets.UpdateDateTime,


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
                var revertPalets = _repositoryFactory.RevertPalets
                    .FirstOrDefault(x => x.Id == id);

                if (revertPalets == null)
                    throw new System.Exception("RevertPalets not found.");

                _repositoryFactory.RevertPalets.Delete(revertPalets);
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
