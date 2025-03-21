using PPC.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PPC.Core.Interface
{
    public interface ICustomerService
    {

        /// <summary>
        /// Query customerType 
        /// </summary>
        /// <param name="customerId"></param>
        /// <returns></returns>
        Customer GetCustomerById(int customerId);

        Customer[] GetCustomer();

        /// <summary>
        /// Find Customer Async
        /// </summary>
        /// <param name="customerName"></param>
        /// <returns></returns>
        Task<Customer> FindCustomerAsync(string customername);

        /// <summary>
        /// Get Customer  based on id
        /// </summary>
        /// <param name="customerId"></param>
        /// <returns></returns>
        Task<Customer> GetCustomerByIdAsync(int customerId);

        /// <summary>
        /// Get Current Customer 
        /// </summary>
        /// <param name="customerId"></param>
        /// <returns></returns>
        Task<Customer> GetCurrentCustomerAsync();

        Task<Customer[]> GetCustomerAsync();

        bool Append(Customer customer);
        bool Update(Customer customer);
        long Delete(int customerId);




    }
}
