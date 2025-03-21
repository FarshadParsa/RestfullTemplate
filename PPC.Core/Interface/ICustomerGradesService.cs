using PPC.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PPC.Core.Interface
{
    public interface ICustomerGradesService
    {

        /// <summary>
        /// Query CustomerGrade
        /// </summary>
        /// <param name="customerGradeID"></param>
        /// <returns></returns>
        CustomerGrades GetCustomerGradesById(byte customerGradeID);

        /// <summary>
        /// Get  CustomerGrade  based on id
        /// </summary>
        /// <param name="customerGradeID"></param>
        /// <returns></returns>
        Task<CustomerGrades> GetCustomerGradesByIdAsync(byte customerGradeID);

        /// <summary>
        /// Get all CustomerGrade
        /// </summary>
        /// <returns></returns>
        List<CustomerGrades> GetAll();

        /// <summary>
        /// Get all CustomerGrade Async
        /// </summary>
        /// <returns></returns>
        Task<List<CustomerGrades>> GetAllAsync();


        /// <summary>
        /// Append a record
        /// </summary>
        /// <param name="customerGrades"></param>
        /// <returns></returns>
        bool Append(CustomerGrades customerGrades);

        /// <summary>
        /// Update a record
        /// </summary>
        /// <param name="customerGrades"></param>
        /// <returns></returns>
        bool Update(CustomerGrades customerGrades);

        /// <summary>
        /// Delete a record
        /// </summary>
        /// <param name="customerGradeID"></param>
        /// <returns></returns>
        long Delete(byte customerGradeID);

        /// <summary>
        /// Existing CustomerGradesAsync
        /// </summary>
        /// <param name="name">customerGrade name</param>
        /// <returns></returns>
        Task<bool> ExistCustomerGradesAsync(string name);
    }
}
