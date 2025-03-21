using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PPC.Core.Interface;
using PPC.Core.Models;
using PPC.Core.Repository;
namespace PPC.Core.Services
{
    public class RawMaterialConfirmationService : BaseService, IRawMaterialConfirmationService
    {
        IUnitOfWork _unitOfWork;
        public RawMaterialConfirmationService(RepositoryFactory repositoryFactory,
            IUnitOfWork unitOfWork)
        {
            _repositoryFactory = repositoryFactory;
            _unitOfWork = unitOfWork;
        }


        public List<RawMaterialConfirmation> GetAll()
        {
            try
            {
                var rawMaterialConfirmation = _repositoryFactory.RawMaterialConfirmation.Table.ToList();

                return rawMaterialConfirmation;
            }
            catch
            {
                throw;
            }
        }

        public async Task<List<RawMaterialConfirmation>> GetAllAsync()
        {
            try
            {

                var rawMaterialConfirmation = await _repositoryFactory.RawMaterialConfirmation.Table.ToListAsync();
                return rawMaterialConfirmation;
            }
            catch (System.Exception ex)
            {
                throw;
            }
        }

        public RawMaterialConfirmation GetRawMaterialConfirmationById(int rawMaterialConfirmationID)
        {
            try
            {
                var rawMaterialConfirmation = _repositoryFactory.RawMaterialConfirmation
                    .FirstOrDefault(x => x.RawMaterialConfirmationID == rawMaterialConfirmationID);

                return rawMaterialConfirmation;
            }
            catch
            {
                throw;
            }
        }

        public async Task<RawMaterialConfirmation> GetRawMaterialConfirmationByIdAsync(int rawMaterialConfirmationID)
        {
            try
            {
                var rawMaterialConfirmation = await _repositoryFactory.RawMaterialConfirmation
                    .FirstOrDefaultAsync(x => x.RawMaterialConfirmationID == rawMaterialConfirmationID);

                return rawMaterialConfirmation;
            }
            catch
            {
                throw;
            }
        }

        public int Append(RawMaterialConfirmation rawMaterialConfirmation)
        {
            try
            {
                var _newObject = new RawMaterialConfirmation
                {
                    RawMaterialConfirmationID = rawMaterialConfirmation.RawMaterialConfirmationID,
                    RawMaterialID = rawMaterialConfirmation.RawMaterialID,
                    Status = rawMaterialConfirmation.Status,
                    IsConfirmed = rawMaterialConfirmation.IsConfirmed,
                    InsUserID = rawMaterialConfirmation.InsUserID,
                    InsDate = rawMaterialConfirmation.InsDate,
                    InsTime = rawMaterialConfirmation.InsTime,
                    ConfirmerID = rawMaterialConfirmation.ConfirmerID,
                    ConfirmDate = rawMaterialConfirmation.ConfirmDate,
                    ConfirmTime = rawMaterialConfirmation.ConfirmTime,
                    ConfirmDescribe = rawMaterialConfirmation.ConfirmDescribe,


                };

                _repositoryFactory.RawMaterialConfirmation.Add(_newObject);

                var statuse = _unitOfWork.Commit() > 0;

                if (statuse)
                    return _newObject.RawMaterialConfirmationID;
                else
                    return int.MinValue;
            }
            catch (System.Exception)
            {
                throw;
            }
        }


        public bool Update(RawMaterialConfirmation rawMaterialConfirmation)
        {
            try
            {

                _repositoryFactory.RawMaterialConfirmation.UpdateBy(x => x.RawMaterialConfirmationID == rawMaterialConfirmation.RawMaterialConfirmationID,
                    new RawMaterialConfirmation
                    {
                        RawMaterialConfirmationID = rawMaterialConfirmation.RawMaterialConfirmationID,
                        RawMaterialID = rawMaterialConfirmation.RawMaterialID,
                        Status = rawMaterialConfirmation.Status,
                        IsConfirmed = rawMaterialConfirmation.IsConfirmed,
                        InsUserID = rawMaterialConfirmation.InsUserID,
                        InsDate = rawMaterialConfirmation.InsDate,
                        InsTime = rawMaterialConfirmation.InsTime,
                        ConfirmerID = rawMaterialConfirmation.ConfirmerID,
                        ConfirmDate = rawMaterialConfirmation.ConfirmDate,
                        ConfirmTime = rawMaterialConfirmation.ConfirmTime,
                        ConfirmDescribe = rawMaterialConfirmation.ConfirmDescribe,


                    });
                var statuse = _unitOfWork.Commit() > 0;
                return statuse;
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }

        public long Delete(int rawMaterialConfirmationID)
        {
            try
            {
                var rawMaterialConfirmation = _repositoryFactory.RawMaterialConfirmation
                    .FirstOrDefault(x => x.RawMaterialConfirmationID == rawMaterialConfirmationID);

                if (rawMaterialConfirmation == null)
                    throw new System.Exception("RawMaterialConfirmation Notfound.");

                _repositoryFactory.RawMaterialConfirmation.Delete(rawMaterialConfirmation);
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
