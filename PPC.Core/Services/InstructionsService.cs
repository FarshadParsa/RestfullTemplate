using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PPC.Core.Interface;

using PPC.Core.Models;

using PPC.Core.Repository;

namespace PPC.Core.Services
{
    public class InstructionsService : BaseService, IInstructionsService
    {
        IUnitOfWork _unitOfWork;
        public InstructionsService(RepositoryFactory repositoryFactory,
            IUnitOfWork unitOfWork)
        {
            _repositoryFactory = repositoryFactory;
            _unitOfWork = unitOfWork;
        }


        public List<Instructions> GetAll()
        {
            try
            {
                var instructions = _repositoryFactory.Instructions.Table.ToList();

                return instructions;
            }
            catch
            {
                throw;
            }
        }

        public async Task<List<Instructions>> GetAllAsync()
        {
            try
            {

                var instructions = await _repositoryFactory.Instructions.Table.ToListAsync();
                return instructions;
            }
            catch (System.Exception ex)
            {
                throw;
            }
        }

        public Instructions GetInstructionsById(short instructionID)
        {
            try
            {
                var instructions = _repositoryFactory.Instructions
                    .FirstOrDefault(x => x.InstructionID == instructionID);

                return instructions;
            }
            catch
            {
                throw;
            }
        }

        public async Task<Instructions> GetInstructionsByIdAsync(short instructionID)
        {
            try
            {
                var instructions = await _repositoryFactory.Instructions
                    .FirstOrDefaultAsync(x => x.InstructionID == instructionID);

                return instructions;
            }
            catch
            {
                throw;
            }
        }

        public bool Append(Instructions instructions)
        {
            try
            {
                _repositoryFactory.Instructions.Add(
                    new Instructions
                    {
                        InstructionID = instructions.InstructionID,
                        InstructionCode = instructions.InstructionCode,
                        InstructionName = instructions.InstructionName,
                        IsActive = instructions.IsActive,


                    });
                var statuse = _unitOfWork.Commit() > 0;
                return statuse;
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }


        public bool Update(Instructions instructions)
        {
            try
            {

                _repositoryFactory.Instructions.UpdateBy(x => x.InstructionID == instructions.InstructionID,
                    new Instructions
                    {
                        InstructionID = instructions.InstructionID,
                        InstructionCode = instructions.InstructionCode,
                        InstructionName = instructions.InstructionName,
                        IsActive = instructions.IsActive,


                    });
                var statuse = _unitOfWork.Commit() > 0;
                return statuse;
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }

        public long Delete(short instructionID)
        {
            try
            {
                var instructions = _repositoryFactory.Instructions
                    .FirstOrDefault(x => x.InstructionID == instructionID);

                if (instructions == null)
                    throw new System.Exception("Instructions Notfound.");

                _repositoryFactory.Instructions.Delete(instructions);
                var statuse = _unitOfWork.Commit();

                return statuse;
            }
            catch
            {
                throw;
            }
        }


        public async Task<bool> ExistInstructionsAsync(string name)
        {
            try
            {

                return await _repositoryFactory.Instructions.FirstOrDefaultAsync(x => x.InstructionName.ToUpper() == name.ToUpper()) != null;
            }
            catch
            {
                throw;
            }
        }


    }
}
