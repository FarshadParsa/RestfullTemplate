using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PPC.Core.Interface;

using PPC.Core.Models;

using PPC.Core.Repository;

namespace PPC.Core.Services
{
    public class TestPlanGroupsService : BaseService, ITestPlanGroupsService
    {
        IUnitOfWork _unitOfWork;
        public TestPlanGroupsService(RepositoryFactory repositoryFactory,
            IUnitOfWork unitOfWork)
        {
            _repositoryFactory = repositoryFactory;
            _unitOfWork = unitOfWork;
        }


        public List<TestPlanGroups> GetAll()
        {
            try
            {
                var testPlanGroups = _repositoryFactory.TestPlanGroups.Table.ToList();

                return testPlanGroups;
            }
            catch
            {
                throw;
            }
        }

        public async Task<List<TestPlanGroups>> GetAllAsync()
        {
            try
            {

                var testPlanGroups = await _repositoryFactory.TestPlanGroups.Table.ToListAsync();
                return testPlanGroups;
            }
            catch (System.Exception ex)
            {
                throw;
            }
        }

        public TestPlanGroups GetTestPlanGroupsById(byte testPlanGroupID)
        {
            try
            {
                var testPlanGroups = _repositoryFactory.TestPlanGroups
                    .FirstOrDefault(x => x.TestPlanGroupID == testPlanGroupID);

                return testPlanGroups;
            }
            catch
            {
                throw;
            }
        }

        public async Task<TestPlanGroups> GetTestPlanGroupsByIdAsync(byte testPlanGroupID)
        {
            try
            {
                var testPlanGroups = await _repositoryFactory.TestPlanGroups
                    .FirstOrDefaultAsync(x => x.TestPlanGroupID == testPlanGroupID);

                return testPlanGroups;
            }
            catch
            {
                throw;
            }
        }

        public bool Append(TestPlanGroups testPlanGroups)
        {
            try
            {
                _repositoryFactory.TestPlanGroups.Add(
                    new TestPlanGroups
                    {
                        TestPlanGroupID = testPlanGroups.TestPlanGroupID,
                        TestPlanGroupCode = testPlanGroups.TestPlanGroupCode,
                        TestPlanGroupName = testPlanGroups.TestPlanGroupName,
                        TestPlanGroupSign = testPlanGroups.TestPlanGroupSign,
                        IsActive = testPlanGroups.IsActive,


                    });
                var statuse = _unitOfWork.Commit() > 0;
                return statuse;
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }


        public bool Update(TestPlanGroups testPlanGroups)
        {
            try
            {

                _repositoryFactory.TestPlanGroups.UpdateBy(x => x.TestPlanGroupID == testPlanGroups.TestPlanGroupID,
                    new TestPlanGroups
                    {
                        TestPlanGroupID = testPlanGroups.TestPlanGroupID,
                        TestPlanGroupCode = testPlanGroups.TestPlanGroupCode,
                        TestPlanGroupName = testPlanGroups.TestPlanGroupName,
                        TestPlanGroupSign = testPlanGroups.TestPlanGroupSign,
                        IsActive = testPlanGroups.IsActive,


                    });
                var statuse = _unitOfWork.Commit() > 0;
                return statuse;
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }

        public long Delete(byte testPlanGroupID)
        {
            try
            {
                var testPlanGroups = _repositoryFactory.TestPlanGroups
                    .FirstOrDefault(x => x.TestPlanGroupID == testPlanGroupID);

                if (testPlanGroups == null)
                    throw new System.Exception("TestPlanGroups Notfound.");

                _repositoryFactory.TestPlanGroups.Delete(testPlanGroups);
                var statuse = _unitOfWork.Commit();

                return statuse;
            }
            catch
            {
                throw;
            }
        }


        public async Task<bool> ExistTestPlanGroupsAsync(string name)
        {
            try
            {

                return await _repositoryFactory.TestPlanGroups.FirstOrDefaultAsync(x => x.TestPlanGroupName.ToUpper() == name.ToUpper()) != null;
            }
            catch
            {
                throw;
            }
        }

        public async Task<List<TestPlanGroups>> GetAllByEntranceTypeAsync(byte id)
        {
            try
            {
                //throw new System.NotImplementedException();
                
                var db = _repositoryFactory;
                var testPlanGroups = await (from testPlanGroup in db.TestPlanGroups.Table
                                            join testPlanGroupAssign in db.TestPlanGroupTypeAssigns.Table on testPlanGroup.TestPlanGroupID equals testPlanGroupAssign.TestPlanGroupID
                                            where testPlanGroupAssign.TestPlanEntranceType== id
                                            select testPlanGroup).ToListAsync();
                return testPlanGroups;

            }
            catch (System.Exception ex)
            {
                throw;
            }
        }

       
    }
}
