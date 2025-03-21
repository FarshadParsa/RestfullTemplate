using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PPC.Core.Interface;

using PPC.Core.Models;

using PPC.Core.Repository;

namespace PPC.Core.Services
{
    public class TestPlanBasicIndexService : BaseService, ITestPlanBasicIndexService
    {
        IUnitOfWork _unitOfWork;
        public TestPlanBasicIndexService(RepositoryFactory repositoryFactory,
            IUnitOfWork unitOfWork)
        {
            _repositoryFactory = repositoryFactory;
            _unitOfWork = unitOfWork;
        }


        public List<TestPlanBasicIndex> GetAll()
        {
            try
            {
                var testPlanBasicIndex = _repositoryFactory.TestPlanBasicIndex.Table.ToList();

                return testPlanBasicIndex;
            }
            catch
            {
                throw;
            }
        }

        public async Task<List<TestPlanBasicIndex>> GetAllAsync()
        {
            try
            {

                var testPlanBasicIndex = await _repositoryFactory.TestPlanBasicIndex.Table.ToListAsync();
                return testPlanBasicIndex;
            }
            catch (System.Exception ex)
            {
                throw;
            }
        }

        public TestPlanBasicIndex GetTestPlanBasicIndexById(short testPlanBasicIndexID)
        {
            try
            {
                var testPlanBasicIndex = _repositoryFactory.TestPlanBasicIndex
                    .FirstOrDefault(x => x.TestPlanBasicIndexID == testPlanBasicIndexID);

                return testPlanBasicIndex;
            }
            catch
            {
                throw;
            }
        }

        public async Task<TestPlanBasicIndex> GetTestPlanBasicIndexByIdAsync(short testPlanBasicIndexID)
        {
            try
            {
                var testPlanBasicIndex = await _repositoryFactory.TestPlanBasicIndex
                    .FirstOrDefaultAsync(x => x.TestPlanBasicIndexID == testPlanBasicIndexID);

                return testPlanBasicIndex;
            }
            catch
            {
                throw;
            }
        }

        public short Append(TestPlanBasicIndex testPlanBasicIndex)
        {
            try
            {
                var _newObject = new TestPlanBasicIndex
                {
                    TestPlanBasicIndexID = testPlanBasicIndex.TestPlanBasicIndexID,
                    TestPlanIndexID = testPlanBasicIndex.TestPlanIndexID,
                    MinVal = testPlanBasicIndex.MinVal,
                    MaxVal = testPlanBasicIndex.MaxVal,
                    TextPhrase = testPlanBasicIndex.TextPhrase,
                    UnitID = testPlanBasicIndex.UnitID,
                    DiagnosisMethod = testPlanBasicIndex.DiagnosisMethod,
                    TestTool = testPlanBasicIndex.TestTool,
                    TestStage = testPlanBasicIndex.TestStage,
                    InstructionID = testPlanBasicIndex.InstructionID,


                };

                _repositoryFactory.TestPlanBasicIndex.Add(_newObject);

                var statuse = _unitOfWork.Commit() > 0;

                if (statuse)
                    return _newObject.TestPlanBasicIndexID;
                else
                    return short.MinValue;
            }
            catch (System.Exception)
            {
                throw;
            }
        }


        public bool Update(TestPlanBasicIndex testPlanBasicIndex)
        {
            try
            {

                _repositoryFactory.TestPlanBasicIndex.UpdateBy(x => x.TestPlanBasicIndexID == testPlanBasicIndex.TestPlanBasicIndexID,
                    new TestPlanBasicIndex
                    {
                        TestPlanBasicIndexID = testPlanBasicIndex.TestPlanBasicIndexID,
                        TestPlanIndexID = testPlanBasicIndex.TestPlanIndexID,
                        MinVal = testPlanBasicIndex.MinVal,
                        MaxVal = testPlanBasicIndex.MaxVal,
                        TextPhrase = testPlanBasicIndex.TextPhrase,
                        UnitID = testPlanBasicIndex.UnitID,
                        DiagnosisMethod = testPlanBasicIndex.DiagnosisMethod,
                        TestTool = testPlanBasicIndex.TestTool,
                        TestStage = testPlanBasicIndex.TestStage,
                        InstructionID = testPlanBasicIndex.InstructionID,


                    });
                var statuse = _unitOfWork.Commit() > 0;
                return statuse;
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }

        public long Delete(short testPlanBasicIndexID)
        {
            try
            {
                var testPlanBasicIndex = _repositoryFactory.TestPlanBasicIndex
                    .FirstOrDefault(x => x.TestPlanBasicIndexID == testPlanBasicIndexID);

                if (testPlanBasicIndex == null)
                    throw new System.Exception("TestPlanBasicIndex Notfound.");

                _repositoryFactory.TestPlanBasicIndex.Delete(testPlanBasicIndex);
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
