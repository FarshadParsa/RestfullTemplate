using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PPC.Core.Interface;

using PPC.Core.Models;

using PPC.Core.Repository;

namespace PPC.Core.Services
{
    public class TestPlanDetailsService : BaseService, ITestPlanDetailsService
    {
        IUnitOfWork _unitOfWork;
        public TestPlanDetailsService(RepositoryFactory repositoryFactory,
            IUnitOfWork unitOfWork)
        {
            _repositoryFactory = repositoryFactory;
            _unitOfWork = unitOfWork;
        }


        public List<TestPlanDetails> GetAll()
        {
            try
            {
                var testPlanDetails = _repositoryFactory.TestPlanDetails.Table
                    .Include(x => x.TestPlan)
                    .Include(x => x.Unit)
                    .Include(x => x.Instruction)
                    .Include(x => x.TestPlanIndex)
                    .ToList();

                return testPlanDetails;
            }
            catch
            {
                throw;
            }
        }

        public async Task<List<TestPlanDetails>> GetAllAsync()
        {
            try
            {

                var testPlanDetails = await _repositoryFactory.TestPlanDetails.Table
                    .Include(x => x.TestPlan)
                    .Include(x => x.Unit)
                    .Include(x => x.Instruction)
                    .Include(x => x.TestPlanIndex)
                    .ToListAsync();
                return testPlanDetails;
            }
            catch (System.Exception ex)
            {
                throw;
            }
        }

        public TestPlanDetails GetTestPlanDetailsById(int testPlanDetailID)
        {
            try
            {
                var testPlanDetails = _repositoryFactory.TestPlanDetails.Table
                    .Include(x => x.TestPlan)
                    .Include(x => x.Unit)
                    .Include(x => x.Instruction)
                    .Include(x => x.TestPlanIndex)
                    .FirstOrDefault(x => x.TestPlanDetailID == testPlanDetailID);

                return testPlanDetails;
            }
            catch
            {
                throw;
            }
        }

        public async Task<TestPlanDetails> GetTestPlanDetailsByIdAsync(int testPlanDetailID)
        {
            try
            {
                var testPlanDetails = await _repositoryFactory.TestPlanDetails.Table
                    .Include(x => x.TestPlan)
                    .Include(x => x.Unit)
                    .Include(x => x.Instruction)
                    .Include(x => x.TestPlanIndex)
                    .FirstOrDefaultAsync(x => x.TestPlanDetailID == testPlanDetailID);

                return testPlanDetails;
            }
            catch
            {
                throw;
            }
        }

        public bool Append(TestPlanDetails testPlanDetails)
        {
            try
            {
                _repositoryFactory.TestPlanDetails.Add(
                    new TestPlanDetails
                    {
                        TestPlanDetailID = testPlanDetails.TestPlanDetailID,
                        TestPlanID = testPlanDetails.TestPlanID,
                        TestPlanIndexID = testPlanDetails.TestPlanIndexID,
                        MinVal = testPlanDetails.MinVal,
                        MaxVal = testPlanDetails.MaxVal,
                        TextPhrase = testPlanDetails.TextPhrase,
                        UnitID = testPlanDetails.UnitID,
                        DiagnosisMethod = testPlanDetails.DiagnosisMethod,
                        TestTool = testPlanDetails.TestTool,
                        TestStage = testPlanDetails.TestStage,
                        InstructionID = testPlanDetails.InstructionID,
                        Describe = testPlanDetails.Describe,


                    });
                var statuse = _unitOfWork.Commit() > 0;
                return statuse;
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }


        public bool Update(TestPlanDetails testPlanDetails)
        {
            try
            {

                _repositoryFactory.TestPlanDetails.UpdateBy(x => x.TestPlanDetailID == testPlanDetails.TestPlanDetailID,
                    new TestPlanDetails
                    {
                        TestPlanDetailID = testPlanDetails.TestPlanDetailID,
                        TestPlanID = testPlanDetails.TestPlanID,
                        TestPlanIndexID = testPlanDetails.TestPlanIndexID,
                        MinVal = testPlanDetails.MinVal,
                        MaxVal = testPlanDetails.MaxVal,
                        TextPhrase = testPlanDetails.TextPhrase,
                        UnitID = testPlanDetails.UnitID,
                        DiagnosisMethod = testPlanDetails.DiagnosisMethod,
                        TestTool = testPlanDetails.TestTool,
                        TestStage = testPlanDetails.TestStage,
                        InstructionID = testPlanDetails.InstructionID,
                        Describe = testPlanDetails.Describe,


                    });
                var statuse = _unitOfWork.Commit() > 0;
                return statuse;
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }

        public long Delete(int testPlanDetailID)
        {
            try
            {
                var testPlanDetails = _repositoryFactory.TestPlanDetails
                    .FirstOrDefault(x => x.TestPlanDetailID == testPlanDetailID);

                if (testPlanDetails == null)
                    throw new System.Exception("TestPlanDetails Notfound.");

                _repositoryFactory.TestPlanDetails.Delete(testPlanDetails);
                var statuse = _unitOfWork.Commit();

                return statuse;
            }
            catch
            {
                throw;
            }
        }

        public async Task<List<TestPlanDetails>> GetAllByTestPlanIdAsync(int testPlanId)
        {
            try
            {

                var testPlanDetails = await _repositoryFactory.TestPlanDetails.Table.Where(x=>x.TestPlanID == testPlanId)
                    .Include(x => x.TestPlan)
                    .Include(x => x.Unit)
                    .Include(x => x.Instruction)
                    .Include(x => x.TestPlanIndex)
                    .ToListAsync();
                return testPlanDetails;
            }
            catch (System.Exception ex)
            {
                throw;
            }
        }



    }
}
