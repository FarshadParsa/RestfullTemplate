using PPC.Core.Interface;
using PPC.Core.Models;
using PPC.Core.Repository;
using PPC.Response.DTOs;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PPC.Core.Services
{
    public class CustomerService : BaseService, ICustomerService
    {

        IUnitOfWork _unitOfWork;
        public CustomerService(RepositoryFactory repositoryFactory,
            IUnitOfWork unitOfWork)
        {
            _repositoryFactory = repositoryFactory;
            _unitOfWork = unitOfWork;
        }

        public bool Append(Customer customer)
        {
            try
            {
                _repositoryFactory.Customer.Add(
                    new Customer
                    {
                        CustomerID = customer.CustomerID,
                        CustCode = customer.CustCode,
                        CustName = customer.CustName,
                        Province_ProvinceID = customer.Province_ProvinceID,
                        CustLatinName = customer.CustLatinName,
                        Address = customer.Address,
                        Tel = customer.Tel,
                        ContactPerson = customer.ContactPerson,
                        IsActive = customer.IsActive,
                        IsForiegn = customer.IsForiegn,
                        IsWhite = customer.IsWhite,
                        CustPersianName = customer.CustPersianName,
                        InvoicingAddress = customer.InvoicingAddress,
                        DeliveryAddress = customer.DeliveryAddress,
                        Stars=customer.Stars,
                        IsAgent=customer.IsAgent,
                        AgentName = customer.AgentName,
                        AgentID = customer.AgentID,
                    });
                var statuse = _unitOfWork.Commit() > 0;
                return statuse;
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }

        public bool Update(Customer customer)
        {
            try
            {

                _repositoryFactory.Customer.UpdateBy(x => x.CustomerID == customer.CustomerID,
                    new Customer
                    {
                        CustomerID = customer.CustomerID,
                        CustCode = customer.CustCode,
                        CustName = customer.CustName,
                        Province_ProvinceID = customer.Province_ProvinceID,
                        CustLatinName = customer.CustLatinName,
                        Address = customer.Address,
                        Tel = customer.Tel,
                        ContactPerson = customer.ContactPerson,
                        IsActive = customer.IsActive,
                        IsForiegn = customer.IsForiegn,
                        IsWhite = customer.IsWhite,
                        CustPersianName = customer.CustPersianName,
                        InvoicingAddress = customer.InvoicingAddress,
                        DeliveryAddress = customer.DeliveryAddress,
                        Stars = customer.Stars,
                        IsAgent = customer.IsAgent,
                        AgentName = customer.AgentName,
                        AgentID = customer.AgentID,
                    });
                var statuse = _unitOfWork.Commit() > 0;
                return statuse;
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }

        public long Delete(int customerId)
        {
            try
            {
                var customer = _repositoryFactory.Customer
                    .FirstOrDefault(x => x.CustomerID == customerId);

                if (customer == null)
                    throw new System.Exception("Customer Not found.");

                _repositoryFactory.Customer.Delete(customer);
                var statuse = _unitOfWork.Commit();

                return statuse;
            }
            catch
            {
                throw;
            }
        }

        public Customer GetCustomerById(int customerId)
        {
            try
            {
                var customer = _repositoryFactory.Customer
                    .FirstOrDefault(x => x.CustomerID == customerId);

                return customer;
            }
            catch
            {
                throw;
            }
        }

        public Customer GetCustomerByName(string customerName)
        {
            try
            {
                var customer = _repositoryFactory.Customer
                    .FirstOrDefault(x => x.CustName.Equals(customerName, StringComparison.InvariantCultureIgnoreCase));

                return customer;
            }
            catch
            {
                throw;
            }
        }

        public Customer[] GetCustomers()
        {
            try
            {
                var customer = _repositoryFactory.Customer.Table.ToArray();

                return customer;
            }
            catch
            {
                throw;
            }
        }

        public async Task<Customer[]> GetCustomersAsync()
        {
            try
            {
                var customer = _repositoryFactory.Customer.Table.ToArray();

                return customer;
            }
            catch
            {
                throw;
            }
        }

        public Task<Customer> FindCustomerAsync(string customername)
        {
            throw new NotImplementedException();
        }

        public Task<Customer> GetCurrentCustomerAsync()
        {
            throw new NotImplementedException();
        }

        public Customer[] GetCustomer()
        {
            throw new NotImplementedException();
        }

        public Task<Customer[]> GetCustomerAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Customer> GetCustomerByIdAsync(int customerId)
        {
            throw new NotImplementedException();
        }

    }
}
