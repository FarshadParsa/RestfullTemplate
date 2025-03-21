using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PPC.Core.Interface;

using PPC.Core.Models;

using PPC.Core.Repository;

namespace PPC.Core.Services
{
    public class TestPlanGroupTypeAssignsService : BaseService, ITestPlanGroupTypeAssignsService
    {
        IUnitOfWork _unitOfWork;
        public TestPlanGroupTypeAssignsService(RepositoryFactory repositoryFactory,
            IUnitOfWork unitOfWork)
        {
            _repositoryFactory = repositoryFactory;
            _unitOfWork = unitOfWork;
        }


        public List<TestPlanGroupTypeAssigns> GetAll()
        {
            try
            {
                var testPlanGroupTypeAssigns = _repositoryFactory.TestPlanGroupTypeAssigns.Table.ToList();

                return testPlanGroupTypeAssigns;
            }
            catch
            {
                throw;
            }
        }

        public async Task<List<TestPlanGroupTypeAssigns>> GetAllAsync()
        {
            try
            {

                var testPlanGroupTypeAssigns = await _repositoryFactory.TestPlanGroupTypeAssigns.Table.ToListAsync();
                return testPlanGroupTypeAssigns;
            }
            catch (System.Exception ex)
            {
                throw;
            }
        }

        public TestPlanGroupTypeAssigns GetTestPlanGroupTypeAssignsById(short testPlanGroupTypeAssignID)
        {
            try
            {
                var testPlanGroupTypeAssigns = _repositoryFactory.TestPlanGroupTypeAssigns
                    .FirstOrDefault(x => x.TestPlanGroupTypeAssignID == testPlanGroupTypeAssignID);

                return testPlanGroupTypeAssigns;
            }
            catch
            {
                throw;
            }
        }

        public async Task<TestPlanGroupTypeAssigns> GetTestPlanGroupTypeAssignsByIdAsync(short testPlanGroupTypeAssignID)
        {
            try
            {
                var testPlanGroupTypeAssigns = await _repositoryFactory.TestPlanGroupTypeAssigns
                    .FirstOrDefaultAsync(x => x.TestPlanGroupTypeAssignID == testPlanGroupTypeAssignID);

                return testPlanGroupTypeAssigns;
            }
            catch
            {
                throw;
            }
        }

        public bool Append(TestPlanGroupTypeAssigns testPlanGroupTypeAssigns)
        {
            try
            {
                _repositoryFactory.TestPlanGroupTypeAssigns.Add(
                    new TestPlanGroupTypeAssigns
                    {
                        TestPlanGroupTypeAssignID = testPlanGroupTypeAssigns.TestPlanGroupTypeAssignID,
                        TestPlanGroupID = testPlanGroupTypeAssigns.TestPlanGroupID,
                        TestPlanEntranceType = testPlanGroupTypeAssigns.TestPlanEntranceType,


                    });
                var statuse = _unitOfWork.Commit() > 0;
                return statuse;
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }


        public bool Update(TestPlanGroupTypeAssigns testPlanGroupTypeAssigns)
        {
            try
            {

                _repositoryFactory.TestPlanGroupTypeAssigns.UpdateBy(x => x.TestPlanGroupTypeAssignID == testPlanGroupTypeAssigns.TestPlanGroupTypeAssignID,
                    new TestPlanGroupTypeAssigns
                    {
                        TestPlanGroupTypeAssignID = testPlanGroupTypeAssigns.TestPlanGroupTypeAssignID,
                        TestPlanGroupID = testPlanGroupTypeAssigns.TestPlanGroupID,
                        TestPlanEntranceType = testPlanGroupTypeAssigns.TestPlanEntranceType,


                    });
                var statuse = _unitOfWork.Commit() > 0;
                return statuse;
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }

        public long Delete(short testPlanGroupTypeAssignID)
        {
            try
            {
                var testPlanGroupTypeAssigns = _repositoryFactory.TestPlanGroupTypeAssigns
                    .FirstOrDefault(x => x.TestPlanGroupTypeAssignID == testPlanGroupTypeAssignID);

                if (testPlanGroupTypeAssigns == null)
                    throw new System.Exception("TestPlanGroupTypeAssigns Notfound.");

                _repositoryFactory.TestPlanGroupTypeAssigns.Delete(testPlanGroupTypeAssigns);
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
