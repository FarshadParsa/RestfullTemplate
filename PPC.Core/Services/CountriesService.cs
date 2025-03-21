using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PPC.Core.Interface;

using PPC.Core.Models;

using PPC.Core.Repository;

namespace PPC.Core.Services
{
    public class CountriesService : BaseService, ICountriesService
    {
        IUnitOfWork _unitOfWork;
        public CountriesService(RepositoryFactory repositoryFactory,
            IUnitOfWork unitOfWork)
        {
            _repositoryFactory = repositoryFactory;
            _unitOfWork = unitOfWork;
        }


        public List<Countries> GetAll()
        {
            try
            {
                var countries = _repositoryFactory.Countries.Table.ToList();

                return countries;
            }
            catch
            {
                throw;
            }
        }

        public async Task<List<Countries>> GetAllAsync()
        {
            try
            {

                var countries = await _repositoryFactory.Countries.Table.ToListAsync();
                return countries;
            }
            catch (System.Exception ex)
            {
                throw;
            }
        }

        public Countries GetCountriesById(short countryID)
        {
            try
            {
                var countries = _repositoryFactory.Countries
                    .FirstOrDefault(x => x.CountryID == countryID);

                return countries;
            }
            catch
            {
                throw;
            }
        }

        public async Task<Countries> GetCountriesByIdAsync(short countryID)
        {
            try
            {
                var countries = await _repositoryFactory.Countries
                    .FirstOrDefaultAsync(x => x.CountryID == countryID);

                return countries;
            }
            catch
            {
                throw;
            }
        }

        public bool Append(Countries countries)
        {
            try
            {
                _repositoryFactory.Countries.Add(
                    new Countries
                    {
                        CountryID = countries.CountryID,
                        CountryName = countries.CountryName,
                        CountryLatinName = countries.CountryLatinName,
                        IsActive = countries.IsActive,


                    });
                var statuse = _unitOfWork.Commit() > 0;
                return statuse;
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }


        public bool Update(Countries countries)
        {
            try
            {

                _repositoryFactory.Countries.UpdateBy(x => x.CountryID == countries.CountryID,
                    new Countries
                    {
                        CountryID = countries.CountryID,
                        CountryName = countries.CountryName,
                        CountryLatinName = countries.CountryLatinName,
                        IsActive = countries.IsActive,


                    });
                var statuse = _unitOfWork.Commit() > 0;
                return statuse;
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }

        public long Delete(short countryID)
        {
            try
            {
                var countries = _repositoryFactory.Countries
                    .FirstOrDefault(x => x.CountryID == countryID);

                if (countries == null)
                    throw new System.Exception("Countries Notfound.");

                _repositoryFactory.Countries.Delete(countries);
                var statuse = _unitOfWork.Commit();

                return statuse;
            }
            catch
            {
                throw;
            }
        }


        public async Task<bool> ExistCountriesAsync(string name)
        {
            try
            {

                return await _repositoryFactory.Countries.FirstOrDefaultAsync(x => x.CountryName.ToUpper() == name.ToUpper()) != null;
            }
            catch
            {
                throw;
            }
        }


    }
}
