using PPC.Core.Interface;
using PPC.Core.Models;
using PPC.Core.Repository;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Text;
using System.Linq;
using AtlasCellData;
using Newtonsoft.Json;
using System.Data;
using System.Drawing;
using System.Linq.Expressions;
using System.Reflection;
using PPC.Base.Extensions;
using PPC.Base;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using AtlasCellData.ADO;

using System.Linq;
using Microsoft.EntityFrameworkCore;
namespace PPC.Core.Services
{
    public class ProvincesService : BaseService, IProvincesService
    {
        IUnitOfWork _unitOfWork;
        public ProvincesService(RepositoryFactory repositoryFactory,
            IUnitOfWork unitOfWork)
        {
            _repositoryFactory = repositoryFactory;
            _unitOfWork = unitOfWork;
        }


        public List<Provinces> GetAll()
        {
            try
            {
                var provinces = _repositoryFactory.Provinces.Table.Include(x=>x.Countries).ToList();

                return provinces;
            }
            catch
            {
                throw;
            }
        }

        public async Task<List<Provinces>> GetAllAsync()
        {
            try
            {

                var provinces = await _repositoryFactory.Provinces.Table.Include(x => x.Countries).ToListAsync();
                return provinces;
            }
            catch (System.Exception ex)
            {
                throw;
            }
        }

        public Provinces GetProvincesById(short provinceID)
        {
            try
            {
                var provinces = _repositoryFactory.Provinces.Table.Include(x => x.Countries)
                    .FirstOrDefault(x => x.ProvinceID == provinceID);

                return provinces;
            }
            catch
            {
                throw;
            }
        }

        public async Task<Provinces> GetProvincesByIdAsync(short provinceID)
        {
            try
            {
                var provinces = await _repositoryFactory.Provinces.Table.Include(x => x.Countries)
                    .FirstOrDefaultAsync(x => x.ProvinceID == provinceID);

                return provinces;
            }
            catch
            {
                throw;
            }
        }

        public bool Append(Provinces provinces)
        {
            try
            {
                _repositoryFactory.Provinces.Add(
                    new Provinces
                    {
                        ProvinceID = provinces.ProvinceID,
                        CountryID = provinces.CountryID,
                        ProvinceCode = provinces.ProvinceCode,
                        ProvinceName = provinces.ProvinceName,
                        ProvinceLatinName = provinces.ProvinceLatinName,
                        IsActive = provinces.IsActive,


                    });
                var statuse = _unitOfWork.Commit() > 0;
                return statuse;
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }


        public bool Update(Provinces provinces)
        {
            try
            {

                _repositoryFactory.Provinces.UpdateBy(x => x.ProvinceID == provinces.ProvinceID,
                    new Provinces
                    {
                        ProvinceID = provinces.ProvinceID,
                        CountryID = provinces.CountryID,
                        ProvinceCode = provinces.ProvinceCode,
                        ProvinceName = provinces.ProvinceName,
                        ProvinceLatinName = provinces.ProvinceLatinName,
                        IsActive = provinces.IsActive,


                    });
                var statuse = _unitOfWork.Commit() > 0;
                return statuse;
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }

        public long Delete(short provinceID)
        {
            try
            {
                var provinces = _repositoryFactory.Provinces
                    .FirstOrDefault(x => x.ProvinceID == provinceID);

                if (provinces == null)
                    throw new System.Exception("Provinces Notfound.");

                _repositoryFactory.Provinces.Delete(provinces);
                var statuse = _unitOfWork.Commit();

                return statuse;
            }
            catch
            {
                throw;
            }
        }


        public async Task<bool> ExistProvincesAsync(string name)
        {
            try
            {

                return await _repositoryFactory.Provinces.FirstOrDefaultAsync(x => x.ProvinceName.ToUpper() == name.ToUpper()) != null;
            }
            catch
            {
                throw;
            }
        }
        
        public async Task<bool> ExistProvincesCodeAsync(string code)
        {
            try
            {
                return await _repositoryFactory.Provinces.FirstOrDefaultAsync(x => x.ProvinceCode.ToUpper() == code.ToUpper()) != null;
            }
            catch
            {
                throw;
            }
        }

        public async Task<Provinces> GetProvincesByCodeAsync(string provinceCode)
        {
            try
            {
                var provinces = await _repositoryFactory.Provinces.Table.Include(x => x.Countries)
                    .FirstOrDefaultAsync(x => x.ProvinceCode == provinceCode);

                return provinces;
            }
            catch
            {
                throw;
            }
        }

        public async Task<Provinces> GetProvincesByNameAsync(string provinceName)
        {
            try
            {
                var provinces = await _repositoryFactory.Provinces.Table.Include(x => x.Countries)
                    .FirstOrDefaultAsync(x => x.ProvinceName == provinceName);

                return provinces;
            }
            catch
            {
                throw;
            }
        }


        public async Task<List<Provinces>> GetActiveProvincesAsync()
        {
            try
            {

                var provinces = await _repositoryFactory.Provinces.Table.Include(x => x.Countries).Where( x=> x.IsActive).ToListAsync();
                return provinces;
            }
            catch (System.Exception ex)
            {
                throw;
            }
        }

        public async Task<List<Provinces>> GetAllByCountryIDAsync(short countryID)
        {
            try
            {
                var provinces = await _repositoryFactory.Provinces.Table.Include(x => x.Countries).Where(x=>x.CountryID==countryID).ToListAsync();
                return provinces;
            }
            catch (System.Exception ex)
            {
                throw;
            }
        }
    }

}
