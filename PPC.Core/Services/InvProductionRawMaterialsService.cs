using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PPC.Core.Interface;
using PPC.Core.Models;
using PPC.Core.Repository;
namespace PPC.Core.Services
{
    public class InvProductionRawMaterialsService : BaseService, IInvProductionRawMaterialsService
    {
        //IUnitOfWork _unitOfWork;
        public InvProductionRawMaterialsService(RepositoryFactory repositoryFactory,
            IUnitOfWork unitOfWork)
        {
            _repositoryFactory = repositoryFactory;
            _unitOfWork = unitOfWork;
        }


        public List<InvProductionRawMaterials> GetAll()
        {
            try
            {
                var invProductionRawMaterials = _repositoryFactory.InvProductionRawMaterials.Table.ToList();

                return invProductionRawMaterials;
            }
            catch
            {
                throw;
            }
        }

        public async Task<List<InvProductionRawMaterials>> GetAllAsync()
        {
            try
            {

                var invProductionRawMaterials = await _repositoryFactory.InvProductionRawMaterials.Table.ToListAsync();
                return invProductionRawMaterials;
            }
            catch (System.Exception ex)
            {
                throw;
            }
        }

        public InvProductionRawMaterials GetInvProductionRawMaterialsById(int invProductionRawMaterialID)
        {
            try
            {
                var invProductionRawMaterials = _repositoryFactory.InvProductionRawMaterials
                    .FirstOrDefault(x => x.InvProductionRawMaterialID == invProductionRawMaterialID);

                return invProductionRawMaterials;
            }
            catch
            {
                throw;
            }
        }

        public async Task<InvProductionRawMaterials> GetInvProductionRawMaterialsByIdAsync(int invProductionRawMaterialID)
        {
            try
            {
                var invProductionRawMaterials = await _repositoryFactory.InvProductionRawMaterials
                    .FirstOrDefaultAsync(x => x.InvProductionRawMaterialID == invProductionRawMaterialID);

                return invProductionRawMaterials;
            }
            catch
            {
                throw;
            }
        }

        public int Append(InvProductionRawMaterials invProductionRawMaterials)
        {
            try
            {
                var _newObject = new InvProductionRawMaterials
                {
                    InvProductionRawMaterialID = invProductionRawMaterials.InvProductionRawMaterialID,
                    RawMaterialID = invProductionRawMaterials.RawMaterialID,
                    RawMaterialsDeliveredToProductionID = invProductionRawMaterials.RawMaterialsDeliveredToProductionID,
                    Weight = invProductionRawMaterials.Weight,
                    EntryDate = invProductionRawMaterials.EntryDate,
                    EntryTime = invProductionRawMaterials.EntryTime,
                    InsUserID = invProductionRawMaterials.InsUserID,
                    InsDate = invProductionRawMaterials.InsDate,
                    InsTime = invProductionRawMaterials.InsTime,
                    EditUserID = invProductionRawMaterials.EditUserID,
                    EditDate = invProductionRawMaterials.EditDate,
                    EditTime = invProductionRawMaterials.EditTime,
                    InsSysTime = invProductionRawMaterials.InsSysTime,


                };

                _repositoryFactory.InvProductionRawMaterials.Add(_newObject);

                var statuse = _unitOfWork.Commit() > 0;

                if (statuse)
                    return _newObject.InvProductionRawMaterialID;
                else
                    return int.MinValue;
            }
            catch (System.Exception)
            {
                throw;
            }
        }


        public bool Update(InvProductionRawMaterials invProductionRawMaterials)
        {
            try
            {

                _repositoryFactory.InvProductionRawMaterials.UpdateBy(x => x.InvProductionRawMaterialID == invProductionRawMaterials.InvProductionRawMaterialID,
                    new InvProductionRawMaterials
                    {
                        InvProductionRawMaterialID = invProductionRawMaterials.InvProductionRawMaterialID,
                        RawMaterialID = invProductionRawMaterials.RawMaterialID,
                        RawMaterialsDeliveredToProductionID = invProductionRawMaterials.RawMaterialsDeliveredToProductionID,
                        Weight = invProductionRawMaterials.Weight,
                        EntryDate = invProductionRawMaterials.EntryDate,
                        EntryTime = invProductionRawMaterials.EntryTime,
                        InsUserID = invProductionRawMaterials.InsUserID,
                        InsDate = invProductionRawMaterials.InsDate,
                        InsTime = invProductionRawMaterials.InsTime,
                        EditUserID = invProductionRawMaterials.EditUserID,
                        EditDate = invProductionRawMaterials.EditDate,
                        EditTime = invProductionRawMaterials.EditTime,
                        InsSysTime = invProductionRawMaterials.InsSysTime,


                    });
                var statuse = _unitOfWork.Commit() > 0;
                return statuse;
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }

        public long Delete(int invProductionRawMaterialID)
        {
            try
            {
                var invProductionRawMaterials = _repositoryFactory.InvProductionRawMaterials
                    .FirstOrDefault(x => x.InvProductionRawMaterialID == invProductionRawMaterialID);

                if (invProductionRawMaterials == null)
                    throw new System.Exception("InvProductionRawMaterials Notfound.");

                _repositoryFactory.InvProductionRawMaterials.Delete(invProductionRawMaterials);
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
