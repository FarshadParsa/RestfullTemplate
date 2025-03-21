using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PPC.Core.Interface;
using PPC.Core.Models;
using PPC.Core.Repository;
namespace PPC.Core.Services
{
    public class PackagingTypesService : BaseService, IPackagingTypesService
    {
        //IUnitOfWork _unitOfWork;
        public PackagingTypesService(RepositoryFactory repositoryFactory,
            IUnitOfWork unitOfWork)
        {
            _repositoryFactory = repositoryFactory;
            _unitOfWork = unitOfWork;
        }


        public List<PackagingTypes> GetAll()
        {
            try
            {
                var packagingTypes = _repositoryFactory.PackagingTypes.Table.ToList();

                return packagingTypes;
            }
            catch
            {
                throw;
            }
        }

        public async Task<List<PackagingTypes>> GetAllAsync()
        {
            try
            {

                var packagingTypes = await _repositoryFactory.PackagingTypes.Table.ToListAsync();
                return packagingTypes;
            }
            catch (System.Exception ex)
            {
                throw;
            }
        }

        public PackagingTypes GetPackagingTypesById(int packagingTypeID)
        {
            try
            {
                var packagingTypes = _repositoryFactory.PackagingTypes
                    .FirstOrDefault(x => x.PackagingTypeID == packagingTypeID);

                return packagingTypes;
            }
            catch
            {
                throw;
            }
        }

        public async Task<PackagingTypes> GetPackagingTypesByIdAsync(int packagingTypeID)
        {
            try
            {
                var packagingTypes = await _repositoryFactory.PackagingTypes
                    .FirstOrDefaultAsync(x => x.PackagingTypeID == packagingTypeID);

                return packagingTypes;
            }
            catch
            {
                throw;
            }
        }

        public int Append(PackagingTypes packagingTypes)
        {
            try
            {
                var _newObject = new PackagingTypes
                {
                    PackagingTypeID = packagingTypes.PackagingTypeID,
                    PackagingTypeCode = packagingTypes.PackagingTypeCode,
                    PackagingTypeName = packagingTypes.PackagingTypeName,
                    PackagingTypeDesc = packagingTypes.PackagingTypeDesc,
                    UnitID = packagingTypes.UnitID,
                    EmptyWeight = packagingTypes.EmptyWeight,
                    Capacity = packagingTypes.Capacity,
                    MinCapacity = packagingTypes.MinCapacity,
                    MaxCapacity = packagingTypes.MaxCapacity,
                    Tolerance = packagingTypes.Tolerance,
                    IsEditableEmptyWeight = packagingTypes.IsEditableEmptyWeight,
                    UsableInProduction = packagingTypes.UsableInProduction,
                    PackagingUsableType = packagingTypes.PackagingUsableType,
                    Describe = packagingTypes.Describe,
                    EditUserID = packagingTypes.EditUserID,
                    EditDate = packagingTypes.EditDate,
                    EditTime = packagingTypes.EditTime,
                    IsActive = packagingTypes.IsActive,


                };

                _repositoryFactory.PackagingTypes.Add(_newObject);

                var statuse = _unitOfWork.Commit() > 0;

                if (statuse)
                    return _newObject.PackagingTypeID;
                else
                    throw new System.Exception(Resources.Resources.pub_RegistrationHasError);
            }
            catch (System.Exception)
            {
                throw;
            }
        }


        public bool Update(PackagingTypes packagingTypes)
        {
            try
            {

                _repositoryFactory.PackagingTypes.UpdateBy(x => x.PackagingTypeID == packagingTypes.PackagingTypeID,
                    new PackagingTypes
                    {
                        PackagingTypeID = packagingTypes.PackagingTypeID,
                        PackagingTypeCode = packagingTypes.PackagingTypeCode,
                        PackagingTypeName = packagingTypes.PackagingTypeName,
                        PackagingTypeDesc = packagingTypes.PackagingTypeDesc,
                        UnitID = packagingTypes.UnitID,
                        EmptyWeight = packagingTypes.EmptyWeight,
                        Capacity = packagingTypes.Capacity,
                        MinCapacity = packagingTypes.MinCapacity,
                        MaxCapacity = packagingTypes.MaxCapacity,
                        Tolerance = packagingTypes.Tolerance,
                        IsEditableEmptyWeight = packagingTypes.IsEditableEmptyWeight,
                        UsableInProduction = packagingTypes.UsableInProduction,
                        PackagingUsableType = packagingTypes.PackagingUsableType,
                        Describe = packagingTypes.Describe,
                        EditUserID = packagingTypes.EditUserID,
                        EditDate = packagingTypes.EditDate,
                        EditTime = packagingTypes.EditTime,
                        IsActive = packagingTypes.IsActive,


                    });
                var statuse = _unitOfWork.Commit() > 0;
                return statuse;
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }

        public long Delete(int packagingTypeID)
        {
            try
            {
                var packagingTypes = _repositoryFactory.PackagingTypes
                    .FirstOrDefault(x => x.PackagingTypeID == packagingTypeID);

                if (packagingTypes == null)
                    throw new System.Exception("PackagingTypes Notfound.");

                _repositoryFactory.PackagingTypes.Delete(packagingTypes);
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
