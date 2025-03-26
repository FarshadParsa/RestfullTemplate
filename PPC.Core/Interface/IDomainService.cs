using WebApi.Core.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace WebApi.Core.Interface
{
    public interface IDomainService
    {

        /// <summary>
        /// 
        /// </summary>
        /// <param name="isActive">null)All domain </param>
        /// <returns></returns>
        List<Domain> GetDomain(bool? isActive = null);

        /// <summary>
        /// Query domains 
        /// </summary>
        /// <param name="domainId"></param>
        /// <returns></returns>
        Domain GetDomainById(int domainId);

        /// <summary>
        /// Find Domain Async
        /// </summary>
        /// <param name="domainName"></param>
        /// <returns></returns>
        Task<Domain> FindDomainAsync(string domainName);

        /// <summary>
        /// Get Domain  based on id
        /// </summary>
        /// <param name="domainId"></param>
        /// <returns></returns>
        Task<Domain> GetDomainByIdAsync(int domainId);

        bool Append(Domain domain);
        bool Update(Domain domain);
        long DeleteDomain(int domainId);
        


    }
}
