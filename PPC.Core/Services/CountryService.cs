using PPC.Core.Interface;
using PPC.Core.Models;
using PPC.Core.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PPC.Core.Services
{

    public class CountryService : BaseService, ICountryService
    {
        IUnitOfWork _unitOfWork;

        public CountryService(RepositoryFactory repositoryFactory,
            IUnitOfWork unitOfWork)
        {
            _repositoryFactory = repositoryFactory;
            _unitOfWork = unitOfWork;
        }

        public bool Append(Country country)
        {
            throw new NotImplementedException();
        }

        public long DeleteCountry(int countryId)
        {
            throw new NotImplementedException();
        }

        public Country FindCountry(string countryname)
        {
            throw new NotImplementedException();
        }

        public Task<Country> FindCountryAsync(string countryname)
        {
            throw new NotImplementedException();
        }

        public List<Country> GetAll()
        {
            try
            {
                var station = _repositoryFactory.Country.Table.ToList();
                //var station = (new PPCDbContext()).Stations.ToList();

                return station;
            }
            catch
            {
                throw;
            }
        }

        public List<Country> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Country GetCountryById(int countryId)
        {
            throw new NotImplementedException();
        }

        public Task<Country> GetCountryByIdAsync(int countryId)
        {
            throw new NotImplementedException();
        }

        public bool Update(Country country)
        {
            throw new NotImplementedException();
        }
    }
}
