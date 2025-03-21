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
    public class CustomersService : BaseService, ICustomersService
    {
        IUnitOfWork _unitOfWork;
        public CustomersService(RepositoryFactory repositoryFactory,
            IUnitOfWork unitOfWork)
        {
            _repositoryFactory = repositoryFactory;
            _unitOfWork = unitOfWork;
        }


        public List<Customers> GetAll()
        {
            try
            {
                var customers = _repositoryFactory.Customers.Table
                    .Include(x => x.Province)
                    .Include(x => x.CustomerGrade).ToList();

                return customers;
            }
            catch
            {
                throw;
            }
        }

        public async Task<List<Customers>> GetAllAsync()
        {
            try
            {

                var customers = await _repositoryFactory.Customers.Table
                    .Include(x => x.Province)
                    .Include(x => x.CustomerGrade)
                    .Include(x => x.User_EditUser)
                    .Include(x => x.User_InsUser)
                    .ToListAsync();
                return customers;
            }
            catch (System.Exception ex)
            {
                throw;
            }
        }

        public Customers GetCustomersById(int customerID)
        {
            try
            {
                var customers = _repositoryFactory.Customers.Table
                    .Include(x => x.Province)
                    .Include(x => x.CustomerGrade).FirstOrDefault(x => x.CustomerID == customerID);

                return customers;
            }
            catch
            {
                throw;
            }
        }

        public async Task<Customers> GetCustomersByIdAsync(int customerID)
        {
            try
            {
                var customers = await _repositoryFactory.Customers.Table
                    .Include(x => x.Province)
                    .Include(x => x.CustomerGrade).FirstOrDefaultAsync(x => x.CustomerID == customerID);

                return customers;
            }
            catch
            {
                throw;
            }
        }

        public bool Append(Customers customers)
        {
            try
            {
                _repositoryFactory.Customers.Add(
                    new Customers
                    {
                        CustomerID = customers.CustomerID,
                        CustomerCode = customers.CustomerCode,
                        CustomerName = customers.CustomerName,
                        CustomerLatinName = customers.CustomerLatinName,
                        CustomerLableName = customers.CustomerLableName,
                        ProvinceID = customers.ProvinceID,
                        Address = customers.Address,
                        Tel = customers.Tel,
                        IsForeign = customers.IsForeign,
                        ContactPerson = customers.ContactPerson,
                        InvoicingAddress = customers.InvoicingAddress,
                        DeliveryAddress = customers.DeliveryAddress,
                        IsConfirmed = customers.IsConfirmed,
                        IsActive = customers.IsActive,
                        Rating = customers.Rating,
                        StartDate = customers.StartDate,
                        CustomerGradeID = customers.CustomerGradeID,
                        ZipCode = customers.ZipCode,
                        NationalIdentity = customers.NationalIdentity,
                        RegistrationNumber = customers.RegistrationNumber,
                        EconomicCode = customers.EconomicCode,
                        CEO = customers.CEO,
                        InvoiceRecipient = customers.InvoiceRecipient,
                        InsUserID = customers.InsUserID,
                        InsDate = customers.InsDate,
                        InsTime = customers.InsTime,
                        EditUserID = customers.EditUserID,
                        EditDate = customers.EditDate,
                        EditTime = customers.EditTime,


                    });
                var statuse = _unitOfWork.Commit() > 0;
                return statuse;
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }


        public bool Update(Customers customers)
        {
            try
            {

                _repositoryFactory.Customers.UpdateBy(x => x.CustomerID == customers.CustomerID,
                    new Customers
                    {
                        CustomerID = customers.CustomerID,
                        CustomerCode = customers.CustomerCode,
                        CustomerName = customers.CustomerName,
                        CustomerLatinName = customers.CustomerLatinName,
                        CustomerLableName = customers.CustomerLableName,
                        ProvinceID = customers.ProvinceID,
                        Address = customers.Address,
                        Tel = customers.Tel,
                        IsForeign = customers.IsForeign,
                        ContactPerson = customers.ContactPerson,
                        InvoicingAddress = customers.InvoicingAddress,
                        DeliveryAddress = customers.DeliveryAddress,
                        IsConfirmed = customers.IsConfirmed,
                        IsActive = customers.IsActive,
                        Rating = customers.Rating,
                        StartDate = customers.StartDate,
                        CustomerGradeID = customers.CustomerGradeID,
                        ZipCode = customers.ZipCode,
                        NationalIdentity = customers.NationalIdentity,
                        RegistrationNumber = customers.RegistrationNumber,
                        EconomicCode = customers.EconomicCode,
                        CEO = customers.CEO,
                        InvoiceRecipient = customers.InvoiceRecipient,
                        InsUserID = customers.InsUserID,
                        InsDate = customers.InsDate,
                        InsTime = customers.InsTime,
                        EditUserID = customers.EditUserID,
                        EditDate = customers.EditDate,
                        EditTime = customers.EditTime,


                    });
                var statuse = _unitOfWork.Commit() > 0;
                return statuse;
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }

        public long Delete(int customerID)
        {
            try
            {
                var customers = _repositoryFactory.Customers
                    .FirstOrDefault(x => x.CustomerID == customerID);

                if (customers == null)
                    throw new System.Exception("Customers Notfound.");

                _repositoryFactory.Customers.Delete(customers);
                var statuse = _unitOfWork.Commit();

                return statuse;
            }
            catch
            {
                throw;
            }
        }


        public async Task<bool> ExistCustomersAsync(string name)
        {
            try
            {

                return await _repositoryFactory.Customers.FirstOrDefaultAsync(x => x.CustomerName.ToUpper() == name.ToUpper()) != null;
            }
            catch
            {
                throw;
            }
        }

        public async Task<Customers> GetCustomersByNameAsync(string customerName)
        {
            try
            {
                var customers = await _repositoryFactory.Customers.Table
                    .Include(x => x.Province)
                    .Include(x => x.CustomerGrade).FirstOrDefaultAsync(x => x.CustomerName == customerName);

                return customers;
            }
            catch
            {
                throw;
            }
        }


    }
}
