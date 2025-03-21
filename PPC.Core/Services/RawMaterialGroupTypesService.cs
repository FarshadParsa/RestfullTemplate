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
    public class RawMaterialGroupTypesService : BaseService, IRawMaterialGroupTypesService
    {
        IUnitOfWork _unitOfWork;
        public RawMaterialGroupTypesService(RepositoryFactory repositoryFactory,
            IUnitOfWork unitOfWork)
        {
            _repositoryFactory = repositoryFactory;
            _unitOfWork = unitOfWork;
        }


        public List<RawMaterialGroupTypes> GetAll()
        {
            try
            {
                var rawMaterialGroupTypes = _repositoryFactory.RawMaterialGroupTypes.Table.ToList();

                return rawMaterialGroupTypes;
            }
            catch
            {
                throw;
            }
        }

        public async Task<List<RawMaterialGroupTypes>> GetAllAsync()
        {
            try
            {

                var rawMaterialGroupTypes = await _repositoryFactory.RawMaterialGroupTypes.Table.ToListAsync();
                return rawMaterialGroupTypes;
            }
            catch (System.Exception ex)
            {
                throw;
            }
        }

        public RawMaterialGroupTypes GetRawMaterialGroupTypesById(short rawMaterialGroupTypeID)
        {
            try
            {
                var rawMaterialGroupTypes = _repositoryFactory.RawMaterialGroupTypes
                    .FirstOrDefault(x => x.RawMaterialGroupTypeID == rawMaterialGroupTypeID);

                return rawMaterialGroupTypes;
            }
            catch
            {
                throw;
            }
        }

        public async Task<RawMaterialGroupTypes> GetRawMaterialGroupTypesByIdAsync(short rawMaterialGroupTypeID)
        {
            try
            {
                var rawMaterialGroupTypes = await _repositoryFactory.RawMaterialGroupTypes
                    .FirstOrDefaultAsync(x => x.RawMaterialGroupTypeID == rawMaterialGroupTypeID);

                return rawMaterialGroupTypes;
            }
            catch
            {
                throw;
            }
        }

        public bool Append(RawMaterialGroupTypes rawMaterialGroupTypes)
        {
            try
            {
                _repositoryFactory.RawMaterialGroupTypes.Add(
                    new RawMaterialGroupTypes
                    {
                        RawMaterialGroupTypeID = rawMaterialGroupTypes.RawMaterialGroupTypeID,
                        RawMaterialGroupTypeName = rawMaterialGroupTypes.RawMaterialGroupTypeName,
                        RawMaterialGroupTypeLatinName = rawMaterialGroupTypes.RawMaterialGroupTypeLatinName,
                        IsLiquid = rawMaterialGroupTypes.IsLiquid,
                        IsActive = rawMaterialGroupTypes.IsActive,


                    });
                var statuse = _unitOfWork.Commit() > 0;
                return statuse;
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }


        public bool Update(RawMaterialGroupTypes rawMaterialGroupTypes)
        {
            try
            {

                _repositoryFactory.RawMaterialGroupTypes.UpdateBy(x => x.RawMaterialGroupTypeID == rawMaterialGroupTypes.RawMaterialGroupTypeID,
                    new RawMaterialGroupTypes
                    {
                        RawMaterialGroupTypeID = rawMaterialGroupTypes.RawMaterialGroupTypeID,
                        RawMaterialGroupTypeName = rawMaterialGroupTypes.RawMaterialGroupTypeName,
                        RawMaterialGroupTypeLatinName = rawMaterialGroupTypes.RawMaterialGroupTypeLatinName,
                        IsLiquid = rawMaterialGroupTypes.IsLiquid,
                        IsActive = rawMaterialGroupTypes.IsActive,


                    });
                var statuse = _unitOfWork.Commit() > 0;
                return statuse;
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }

        public long Delete(short rawMaterialGroupTypeID)
        {
            try
            {
                var rawMaterialGroupTypes = _repositoryFactory.RawMaterialGroupTypes
                    .FirstOrDefault(x => x.RawMaterialGroupTypeID == rawMaterialGroupTypeID);

                if (rawMaterialGroupTypes == null)
                    throw new System.Exception("RawMaterialGroupTypes Notfound.");

                _repositoryFactory.RawMaterialGroupTypes.Delete(rawMaterialGroupTypes);
                var statuse = _unitOfWork.Commit();

                return statuse;
            }
            catch
            {
                throw;
            }
        }


        public async Task<bool> ExistRawMaterialGroupTypesAsync(string name)
        {
            try
            {

                return await _repositoryFactory.RawMaterialGroupTypes.FirstOrDefaultAsync(x => x.RawMaterialGroupTypeName.ToUpper() == name.ToUpper()) != null;
            }
            catch
            {
                throw;
            }
        }
    }
}
