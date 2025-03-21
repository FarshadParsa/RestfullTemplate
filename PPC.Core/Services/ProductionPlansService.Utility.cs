using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using AtlasCellData.ADO;
using Microsoft.EntityFrameworkCore;
using PPC.Common;
using PPC.Core.Interface;
using PPC.Core.Models;
using PPC.Core.Repository;
namespace PPC.Core.Services
{
    public partial class ProductionPlansService : BaseService, IProductionPlansService
    {

        public async Task<bool> ValidateCanFinishPlanAsync(int productionPlanId)
        {
            try
            {
                bool result = true;

                var plan = await _repositoryFactory.ProductionPlans.FirstOrDefaultAsync(x => x.ProductionPlanID == productionPlanId);

                if (plan.Status == (byte)ProductionPlanStatus.Finished)
                {
                    result= false;
                    throw new System.Exception("برنامه قبلا خاتمه یافته است");
                }



                return result;
            }
            catch
            {
                throw;
            }
        }


    }
}
