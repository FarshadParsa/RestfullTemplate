using PPC.Core.Interface;
using PPC.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

using System.Linq;
using Microsoft.EntityFrameworkCore;
using PPC.Core.Repository;

namespace PPC.Core.Services
{
    public class UnitsService : BaseService, IUnitsService
    {
        IUnitOfWork _unitOfWork;
        public UnitsService(RepositoryFactory repositoryFactory,
            IUnitOfWork unitOfWork)
        {
            _repositoryFactory = repositoryFactory;
            _unitOfWork = unitOfWork;
        }


        public List<Units> GetAll()
        {
            try
            {
                var units = _repositoryFactory.Units.Table.ToList();

                return units;
            }
            catch
            {
                throw;
            }
        }

        public async Task<List<Units>> GetAllAsync()
        {
            try
            {

                var units = await _repositoryFactory.Units.Table.ToListAsync();
                return units;
            }
            catch (System.Exception ex)
            {
                throw;
            }
        }

        public Units GetUnitsById(int unitID)
        {
            try
            {
                var units = _repositoryFactory.Units
                    .FirstOrDefault(x => x.UnitID == unitID);

                return units;
            }
            catch
            {
                throw;
            }
        }

        public async Task<Units> GetUnitsByIdAsync(int unitID)
        {
            try
            {
                var units = await _repositoryFactory.Units
                    .FirstOrDefaultAsync(x => x.UnitID == unitID);

                return units;
            }
            catch
            {
                throw;
            }
        }

        public bool Append(Units units)
        {
            try
            {
                _repositoryFactory.Units.Add(
                    new Units
                    {
                        UnitID = units.UnitID,
                        UnitName = units.UnitName,
                        UnitLatinName = units.UnitLatinName,
                        Abbreviation = units.Abbreviation,


                    });
                var statuse = _unitOfWork.Commit() > 0;
                return statuse;
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }


        public bool Update(Units units)
        {
            try
            {

                _repositoryFactory.Units.UpdateBy(x => x.UnitID == units.UnitID,
                    new Units
                    {
                        UnitID = units.UnitID,
                        UnitName = units.UnitName,
                        UnitLatinName = units.UnitLatinName,
                        Abbreviation = units.Abbreviation,


                    });
                var statuse = _unitOfWork.Commit() > 0;
                return statuse;
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }

        public long Delete(int unitID)
        {
            try
            {
                var units = _repositoryFactory.Units
                    .FirstOrDefault(x => x.UnitID == unitID);

                if (units == null)
                    throw new System.Exception("Units Notfound.");

                _repositoryFactory.Units.Delete(units);
                var statuse = _unitOfWork.Commit();

                return statuse;
            }
            catch
            {
                throw;
            }
        }

        public async Task<bool> ExistUnitsAsync(string name)
        {
            try
            {
                return await _repositoryFactory.Units.FirstOrDefaultAsync(x => x.UnitName.ToUpper() == name.ToUpper()) != null;
            }
            catch 
            {
                throw;
            }
        }

        public async Task<Units> GetUnitByNameAsync(string unitName)
        {
            try
            {
                var units = await _repositoryFactory.Units
                    .FirstOrDefaultAsync(x => x.UnitName.Equals(unitName));

                return units;
            }
            catch
            {
                throw;
            }
        }

    }
}
