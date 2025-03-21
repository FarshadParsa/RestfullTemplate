using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PPC.Core.Interface;
using PPC.Core.Models;
using PPC.Core.Repository;
namespace PPC.Core.Services
{
    public class CustomerDraftPaletsService : BaseService, ICustomerDraftPaletsService
    {
        //IUnitOfWork _unitOfWork;
        public CustomerDraftPaletsService(RepositoryFactory repositoryFactory,
            IUnitOfWork unitOfWork)
        {
            _repositoryFactory = repositoryFactory;
            _unitOfWork = unitOfWork;
        }


        public List<CustomerDraftPalets> GetAll()
        {
            try
            {
                var customerDraftPalets = _repositoryFactory.CustomerDraftPalets.Table.ToList();

                return customerDraftPalets;
            }
            catch
            {
                throw;
            }
        }

        public async Task<List<CustomerDraftPalets>> GetAllAsync()
        {
            try
            {

                var customerDraftPalets = await _repositoryFactory.CustomerDraftPalets.Table.ToListAsync();
                return customerDraftPalets;
            }
            catch (System.Exception ex)
            {
                throw;
            }
        }

        public CustomerDraftPalets GetCustomerDraftPaletsById(int customerDraftPaletID)
        {
            try
            {
                var customerDraftPalets = _repositoryFactory.CustomerDraftPalets
                    .FirstOrDefault(x => x.CustomerDraftPaletID == customerDraftPaletID);

                return customerDraftPalets;
            }
            catch
            {
                throw;
            }
        }

        public async Task<CustomerDraftPalets> GetCustomerDraftPaletsByIdAsync(int customerDraftPaletID)
        {
            try
            {
                var customerDraftPalets = await _repositoryFactory.CustomerDraftPalets
                    .FirstOrDefaultAsync(x => x.CustomerDraftPaletID == customerDraftPaletID);

                return customerDraftPalets;
            }
            catch
            {
                throw;
            }
        }

        public int Append(CustomerDraftPalets customerDraftPalets)
        {
            try
            {
                var _newObject = new CustomerDraftPalets
                {
                    CustomerDraftPaletID = customerDraftPalets.CustomerDraftPaletID,
                    CustomerDraftID = customerDraftPalets.CustomerDraftID,
                    PaletID = customerDraftPalets.PaletID,


                };

                _repositoryFactory.CustomerDraftPalets.Add(_newObject);

                var statuse = _unitOfWork.Commit() > 0;

                if (statuse)
                    return _newObject.CustomerDraftPaletID;
                else
                    return int.MinValue;
            }
            catch (System.Exception)
            {
                throw;
            }
        }


        public bool Update(CustomerDraftPalets customerDraftPalets)
        {
            try
            {

                _repositoryFactory.CustomerDraftPalets.UpdateBy(x => x.CustomerDraftPaletID == customerDraftPalets.CustomerDraftPaletID,
                    new CustomerDraftPalets
                    {
                        CustomerDraftPaletID = customerDraftPalets.CustomerDraftPaletID,
                        CustomerDraftID = customerDraftPalets.CustomerDraftID,
                        PaletID = customerDraftPalets.PaletID,


                    });
                var statuse = _unitOfWork.Commit() > 0;
                return statuse;
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }

        public long Delete(int customerDraftPaletID)
        {
            try
            {
                var customerDraftPalets = _repositoryFactory.CustomerDraftPalets
                    .FirstOrDefault(x => x.CustomerDraftPaletID == customerDraftPaletID);

                if (customerDraftPalets == null)
                    throw new System.Exception("CustomerDraftPalets Notfound.");

                _repositoryFactory.CustomerDraftPalets.Delete(customerDraftPalets);
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

