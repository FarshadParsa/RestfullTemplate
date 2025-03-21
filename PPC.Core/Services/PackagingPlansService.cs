using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PPC.Core.Interface;

using PPC.Core.Models;

using PPC.Core.Repository;

namespace PPC.Core.Services
{
    public class PackagingPlansService : BaseService, IPackagingPlansService
    {
        IUnitOfWork _unitOfWork;
        public PackagingPlansService(RepositoryFactory repositoryFactory,
            IUnitOfWork unitOfWork)
        {
            _repositoryFactory = repositoryFactory;
            _unitOfWork = unitOfWork;
        }


        public List<PackagingPlans> GetAll()
        {
            try
            {
                var packagingPlans = _repositoryFactory.PackagingPlans.Table.ToList();

                return packagingPlans;
            }
            catch
            {
                throw;
            }
        }

        public async Task<List<PackagingPlans>> GetAllAsync()
        {
            try
            {

                var packagingPlans = await _repositoryFactory.PackagingPlans.Table.ToListAsync();
                return packagingPlans;
            }
            catch (System.Exception ex)
            {
                throw;
            }
        }

        public PackagingPlans GetPackagingPlansById(int packagingPlanID)
        {
            try
            {
                var packagingPlans = _repositoryFactory.PackagingPlans
                    .FirstOrDefault(x => x.PackagingPlanID == packagingPlanID);

                return packagingPlans;
            }
            catch
            {
                throw;
            }
        }

        public async Task<PackagingPlans> GetPackagingPlansByIdAsync(int packagingPlanID)
        {
            try
            {
                var packagingPlans = await _repositoryFactory.PackagingPlans
                    .FirstOrDefaultAsync(x => x.PackagingPlanID == packagingPlanID);

                return packagingPlans;
            }
            catch
            {
                throw;
            }
        }

        public int Append(PackagingPlans packagingPlans)
        {
            try
            {
                var _newObject = new PackagingPlans
                {
                    PackagingPlanID = packagingPlans.PackagingPlanID,
                    PackagingPlanCode = packagingPlans.PackagingPlanCode,
                    PackagingPlanName = packagingPlans.PackagingPlanName,
                    PackagingPlanDesc = packagingPlans.PackagingPlanDesc,
                    EmptyWeight = packagingPlans.EmptyWeight,
                    Capacity = packagingPlans.Capacity,
                    MinCapacity = packagingPlans.MinCapacity,
                    Tolerance = packagingPlans.Tolerance,
                    Describe = packagingPlans.Describe,
                    EditUserID = packagingPlans.EditUserID,
                    EditDate = packagingPlans.EditDate,
                    EditTime = packagingPlans.EditTime,
                    IsActive = packagingPlans.IsActive,


                };

                _repositoryFactory.PackagingPlans.Add(_newObject);

                var statuse = _unitOfWork.Commit() > 0;

                if (statuse)
                    return _newObject.PackagingPlanID;
                else
                    return int.MinValue;
            }
            catch (System.Exception)
            {
                throw;
            }
        }


        public bool Update(PackagingPlans packagingPlans)
        {
            try
            {

                _repositoryFactory.PackagingPlans.UpdateBy(x => x.PackagingPlanID == packagingPlans.PackagingPlanID,
                    new PackagingPlans
                    {
                        PackagingPlanID = packagingPlans.PackagingPlanID,
                        PackagingPlanCode = packagingPlans.PackagingPlanCode,
                        PackagingPlanName = packagingPlans.PackagingPlanName,
                        PackagingPlanDesc = packagingPlans.PackagingPlanDesc,
                        EmptyWeight = packagingPlans.EmptyWeight,
                        Capacity = packagingPlans.Capacity,
                        MinCapacity = packagingPlans.MinCapacity,
                        Tolerance = packagingPlans.Tolerance,
                        Describe = packagingPlans.Describe,
                        EditUserID = packagingPlans.EditUserID,
                        EditDate = packagingPlans.EditDate,
                        EditTime = packagingPlans.EditTime,
                        IsActive = packagingPlans.IsActive,


                    });
                var statuse = _unitOfWork.Commit() > 0;
                return statuse;
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }

        public long Delete(int packagingPlanID)
        {
            try
            {
                var packagingPlans = _repositoryFactory.PackagingPlans
                    .FirstOrDefault(x => x.PackagingPlanID == packagingPlanID);

                if (packagingPlans == null)
                    throw new System.Exception("PackagingPlans Notfound.");

                _repositoryFactory.PackagingPlans.Delete(packagingPlans);
                var statuse = _unitOfWork.Commit();

                return statuse;
            }
            catch
            {
                throw;
            }
        }


        public async Task<bool> ExistPackagingPlansAsync(string name)
        {
            try
            {

                return await _repositoryFactory.PackagingPlans.FirstOrDefaultAsync(x => x.PackagingPlanName.ToUpper() == name.ToUpper()) != null;
            }
            catch
            {
                throw;
            }
        }

    }
}
