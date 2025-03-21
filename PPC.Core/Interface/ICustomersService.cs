using PPC.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PPC.Core.Interface
{
    public interface ICustomersService
    {

        /// <summary>
        /// Query Customer
        /// </summary>
        /// <param name="customerID"></param>
        /// <returns></returns>
        Customers GetCustomersById(int customerID);

        /// <summary>
        /// Get  Customer  based on id
        /// </summary>
        /// <param name="customerID"></param>
        /// <returns></returns>
        Task<Customers> GetCustomersByIdAsync(int customerID);

        /// <summary>
        /// Get all Customer
        /// </summary>
        /// <returns></returns>
        List<Customers> GetAll();

        /// <summary>
        /// Get all Customer Async
        /// </summary>
        /// <returns></returns>
        Task<List<Customers>> GetAllAsync();


        /// <summary>
        /// Append a record
        /// </summary>
        /// <param name="customers"></param>
        /// <returns></returns>
        bool Append(Customers customers);

        /// <summary>
        /// Update a record
        /// </summary>
        /// <param name="customers"></param>
        /// <returns></returns>
        bool Update(Customers customers);

        /// <summary>
        /// Delete a record
        /// </summary>
        /// <param name="customerID"></param>
        /// <returns></returns>
        long Delete(int customerID);

        /// <summary>
        /// Existing CustomersAsync
        /// </summary>
        /// <param name="name">customer name</param>
        /// <returns></returns>
        Task<bool> ExistCustomersAsync(string name);

        /// <summary>
        /// Get  Customer  based on id
        /// </summary>
        /// <param name="customerName">Customer Name</param>
        /// <returns></returns>
        Task<Customers> GetCustomersByNameAsync(string customerName);


    }
}
