using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PPC.Core.Interface;

using PPC.Core.Models;

using PPC.Core.Repository;

namespace PPC.Core.Services
{
    public class RawMaterialLotNumbersService : BaseService, IRawMaterialLotNumbersService
    {
        IUnitOfWork _unitOfWork;
        public RawMaterialLotNumbersService(RepositoryFactory repositoryFactory,
            IUnitOfWork unitOfWork)
        {
            _repositoryFactory = repositoryFactory;
            _unitOfWork = unitOfWork;
        }


        public List<RawMaterialLotNumbers> GetAll()
        {
            try
            {
                var rawMaterialLotNumbers = _repositoryFactory.RawMaterialLotNumbers.Table.ToList();

                return rawMaterialLotNumbers;
            }
            catch
            {
                throw;
            }
        }

        public async Task<List<RawMaterialLotNumbers>> GetAllAsync()
        {
            try
            {

                var rawMaterialLotNumbers = await _repositoryFactory.RawMaterialLotNumbers.Table.ToListAsync();
                return rawMaterialLotNumbers;
            }
            catch (System.Exception ex)
            {
                throw;
            }
        }

        public RawMaterialLotNumbers GetRawMaterialLotNumbersById(int rawMaterialLotNumberID)
        {
            try
            {
                var rawMaterialLotNumbers = _repositoryFactory.RawMaterialLotNumbers
                    .FirstOrDefault(x => x.RawMaterialLotNumberID == rawMaterialLotNumberID);

                return rawMaterialLotNumbers;
            }
            catch
            {
                throw;
            }
        }

        public async Task<RawMaterialLotNumbers> GetRawMaterialLotNumbersByIdAsync(int rawMaterialLotNumberID)
        {
            try
            {
                var rawMaterialLotNumbers = await _repositoryFactory.RawMaterialLotNumbers
                    .FirstOrDefaultAsync(x => x.RawMaterialLotNumberID == rawMaterialLotNumberID);

                return rawMaterialLotNumbers;
            }
            catch
            {
                throw;
            }
        }

        public int Append(RawMaterialLotNumbers rawMaterialLotNumbers)
        {
            try
            {
                var _newObject = new RawMaterialLotNumbers
                {
                    RawMaterialLotNumberID = rawMaterialLotNumbers.RawMaterialLotNumberID,
                    RawMaterialID = rawMaterialLotNumbers.RawMaterialID,
                    RepeatNo = rawMaterialLotNumbers.RepeatNo,
                    LotNumber = rawMaterialLotNumbers.LotNumber,
                    Describe = rawMaterialLotNumbers.Describe,
                    InsUserID = rawMaterialLotNumbers.InsUserID,
                    InsDate = rawMaterialLotNumbers.InsDate,
                    InsTime = rawMaterialLotNumbers.InsTime,
                    EditUserID = rawMaterialLotNumbers.EditUserID,
                    EditDate = rawMaterialLotNumbers.EditDate,
                    EditTime = rawMaterialLotNumbers.EditTime,


                };

                _repositoryFactory.RawMaterialLotNumbers.Add(_newObject);

                var statuse = _unitOfWork.Commit() > 0;

                if (statuse)
                    return _newObject.RawMaterialLotNumberID;
                else
                    return int.MinValue;
            }
            catch (System.Exception)
            {
                throw;
            }
        }


        public bool Update(RawMaterialLotNumbers rawMaterialLotNumbers)
        {
            try
            {

                _repositoryFactory.RawMaterialLotNumbers.UpdateBy(x => x.RawMaterialLotNumberID == rawMaterialLotNumbers.RawMaterialLotNumberID,
                    new RawMaterialLotNumbers
                    {
                        RawMaterialLotNumberID = rawMaterialLotNumbers.RawMaterialLotNumberID,
                        RawMaterialID = rawMaterialLotNumbers.RawMaterialID,
                        RepeatNo = rawMaterialLotNumbers.RepeatNo,
                        LotNumber = rawMaterialLotNumbers.LotNumber,
                        Describe = rawMaterialLotNumbers.Describe,
                        InsUserID = rawMaterialLotNumbers.InsUserID,
                        InsDate = rawMaterialLotNumbers.InsDate,
                        InsTime = rawMaterialLotNumbers.InsTime,
                        EditUserID = rawMaterialLotNumbers.EditUserID,
                        EditDate = rawMaterialLotNumbers.EditDate,
                        EditTime = rawMaterialLotNumbers.EditTime,


                    });
                var statuse = _unitOfWork.Commit() > 0;
                return statuse;
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }

        public long Delete(int rawMaterialLotNumberID)
        {
            try
            {
                var rawMaterialLotNumbers = _repositoryFactory.RawMaterialLotNumbers
                    .FirstOrDefault(x => x.RawMaterialLotNumberID == rawMaterialLotNumberID);

                if (rawMaterialLotNumbers == null)
                    throw new System.Exception("RawMaterialLotNumbers Notfound.");

                _repositoryFactory.RawMaterialLotNumbers.Delete(rawMaterialLotNumbers);
                var statuse = _unitOfWork.Commit();

                return statuse;
            }
            catch
            {
                throw;
            }
        }


        public async Task<RawMaterialLotNumbers> GetInstanceByLotNoAsync(string lotNo)
        {
            try
            {
                return await _repositoryFactory.RawMaterialLotNumbers.FirstOrDefaultAsync(x => x.LotNumber == lotNo);
            }
            catch
            {
                throw;
            }
        }


    }
}
