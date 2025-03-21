using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PPC.Core.Interface;
using PPC.Core.Models;
using PPC.Core.Repository;
namespace PPC.Core.Services
{
    public class InvTypesService : BaseService, IInvTypesService
    {
        //IUnitOfWork _unitOfWork;
        public InvTypesService(RepositoryFactory repositoryFactory,
            IUnitOfWork unitOfWork)
        {
            _repositoryFactory = repositoryFactory;
            _unitOfWork = unitOfWork;
        }


        public List<InvTypes> GetAll()
        {
            try
            {
                var invTypes = _repositoryFactory.InvTypes.Table.ToList();

                return invTypes;
            }
            catch
            {
                throw;
            }
        }

        public async Task<List<InvTypes>> GetAllAsync()
        {
            try
            {

                var invTypes = await _repositoryFactory.InvTypes.Table.ToListAsync();
                return invTypes;
            }
            catch (System.Exception ex)
            {
                throw;
            }
        }

        public InvTypes GetInvTypesById(byte invTypeID)
        {
            try
            {
                var invTypes = _repositoryFactory.InvTypes
                    .FirstOrDefault(x => x.InvTypeID == invTypeID);

                return invTypes;
            }
            catch
            {
                throw;
            }
        }

        public async Task<InvTypes> GetInvTypesByIdAsync(byte invTypeID)
        {
            try
            {
                var invTypes = await _repositoryFactory.InvTypes
                    .FirstOrDefaultAsync(x => x.InvTypeID == invTypeID);

                return invTypes;
            }
            catch
            {
                throw;
            }
        }

        public char Append(InvTypes invTypes)
        {
            try
            {
                var _newObject = new InvTypes
                {
                    InvTypeID = invTypes.InvTypeID,
                    InvTypeName = invTypes.InvTypeName,
                    OrderBy = invTypes.OrderBy,
                    IsActive = invTypes.IsActive,


                };

                _repositoryFactory.InvTypes.Add(_newObject);

                var statuse = _unitOfWork.Commit() > 0;

                if (statuse)
                    return _newObject.InvTypeID;
                else
                    return char.MinValue;
            }
            catch (System.Exception)
            {
                throw;
            }
        }


        public bool Update(InvTypes invTypes)
        {
            try
            {

                _repositoryFactory.InvTypes.UpdateBy(x => x.InvTypeID == invTypes.InvTypeID,
                    new InvTypes
                    {
                        InvTypeID = invTypes.InvTypeID,
                        InvTypeName = invTypes.InvTypeName,
                        OrderBy = invTypes.OrderBy,
                        IsActive = invTypes.IsActive,


                    });
                var statuse = _unitOfWork.Commit() > 0;
                return statuse;
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }

        public long Delete(byte invTypeID)
        {
            try
            {
                var invTypes = _repositoryFactory.InvTypes
                    .FirstOrDefault(x => x.InvTypeID == invTypeID);

                if (invTypes == null)
                    throw new System.Exception("InvTypes Notfound.");

                _repositoryFactory.InvTypes.Delete(invTypes);
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
