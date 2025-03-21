using PPC.Core.Interface;
using PPC.Core.Models;
using PPC.Core.Repository;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

using System.Linq;
using Microsoft.EntityFrameworkCore;
namespace PPC.Core.Services
{
    public class RawMaterialsService : BaseService, IRawMaterialsService
    {
        IUnitOfWork _unitOfWork;
        public RawMaterialsService(RepositoryFactory repositoryFactory,
            IUnitOfWork unitOfWork)
        {
            _repositoryFactory = repositoryFactory;
            _unitOfWork = unitOfWork;
        }


        public List<RawMaterials> GetAll()
        {
            try
            {
                var rawMaterials = _repositoryFactory.RawMaterials.Table.Include(x=>x.Units).ToList();

                return rawMaterials;
            }
            catch
            {
                throw;
            }
        }

        public async Task<List<RawMaterials>> GetAllAsync()
        {
            try
            {

                var rawMaterials = await _repositoryFactory.RawMaterials.Table.ToListAsync();
                return rawMaterials;
            }
            catch (System.Exception ex)
            {
                throw;
            }
        }

        public RawMaterials GetRawMaterialsById(int rawMaterialID)
        {
            try
            {
                var rawMaterials = _repositoryFactory.RawMaterials
                    .FirstOrDefault(x => x.RawMaterialID == rawMaterialID);

                return rawMaterials;
            }
            catch
            {
                throw;
            }
        }

        public async Task<RawMaterials> GetRawMaterialsByIdAsync(int rawMaterialID)
        {
            try
            {
                var rawMaterials = await _repositoryFactory.RawMaterials
                    .FirstOrDefaultAsync(x => x.RawMaterialID == rawMaterialID);

                return rawMaterials;
            }
            catch
            {
                throw;
            }
        }

        public bool Append(RawMaterials rawMaterials)
        {
            try
            {
                _repositoryFactory.RawMaterials.Add(
                    new RawMaterials
                    {
                        RawMaterialOriginCode = rawMaterials.RawMaterialOriginCode,
                        RawMaterialOriginName = rawMaterials.RawMaterialOriginName,
                        RawMaterialCode = rawMaterials.RawMaterialCode,
                        RawMaterialName = rawMaterials.RawMaterialName,
                        RawMaterialLatinName = rawMaterials.RawMaterialLatinName,
                        UnitID = rawMaterials.UnitID,
                        RawMaterialGroupID = rawMaterials.RawMaterialGroupID,
                        IsActive = rawMaterials.IsActive,


                    });
                var statuse = _unitOfWork.Commit() > 0;
                return statuse;
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }


        public bool Update(RawMaterials rawMaterials)
        {
            try
            {

                _repositoryFactory.RawMaterials.UpdateBy(x => x.RawMaterialID == rawMaterials.RawMaterialID,
                    new RawMaterials
                    {
                        RawMaterialOriginCode = rawMaterials.RawMaterialOriginCode,
                        RawMaterialOriginName = rawMaterials.RawMaterialOriginName,
                        RawMaterialCode = rawMaterials.RawMaterialCode,
                        RawMaterialName = rawMaterials.RawMaterialName,
                        RawMaterialLatinName = rawMaterials.RawMaterialLatinName,
                        UnitID = rawMaterials.UnitID,
                        RawMaterialGroupID = rawMaterials.RawMaterialGroupID,
                        IsActive = rawMaterials.IsActive,


                    });
                var statuse = _unitOfWork.Commit() > 0;
                return statuse;
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }

        public long Delete(int rawMaterialID)
        {
            try
            {
                var rawMaterials = _repositoryFactory.RawMaterials
                    .FirstOrDefault(x => x.RawMaterialID == rawMaterialID);

                if (rawMaterials == null)
                    throw new System.Exception("RawMaterials Notfound.");

                _repositoryFactory.RawMaterials.Delete(rawMaterials);
                var statuse = _unitOfWork.Commit();

                return statuse;
            }
            catch
            {
                throw;
            }
        }


        public async Task<bool> ExistRawMaterialsAsync(string name)
        {
            try
            {

                return await _repositoryFactory.RawMaterials.FirstOrDefaultAsync(x => x.RawMaterialName.ToUpper() == name.ToUpper()) != null;
            }
            catch
            {
                throw;
            }
        }

    }
}
