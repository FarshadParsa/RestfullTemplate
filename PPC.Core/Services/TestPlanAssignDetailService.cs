using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PPC.Core.Interface;

using PPC.Core.Models;

using PPC.Core.Repository;

namespace PPC.Core.Services
{
    public class TestPlanAssignDetailService : BaseService, ITestPlanAssignDetailService
    {
        IUnitOfWork _unitOfWork;
        public TestPlanAssignDetailService(RepositoryFactory repositoryFactory,
            IUnitOfWork unitOfWork)
        {
            _repositoryFactory = repositoryFactory;
            _unitOfWork = unitOfWork;
        }


        public List<TestPlanAssignDetail> GetAll()
        {
            try
            {
                var testPlanAssignDetail = _repositoryFactory.TestPlanAssignDetail.Table
                    .Include(x => x.TestPlanAssign)
                    .Include(x => x.TestPlanIndex)
                    .Include(x => x.Instruction)
                    .ToList();

                return testPlanAssignDetail;
            }
            catch
            {
                throw;
            }
        }

        public async Task<List<TestPlanAssignDetail>> GetAllAsync()
        {
            try
            {

                var testPlanAssignDetail = await _repositoryFactory.TestPlanAssignDetail.Table
                    .Include(x => x.TestPlanAssign)
                    .Include(x => x.TestPlanIndex)
                    .Include(x => x.Instruction)
                    .ToListAsync();
                return testPlanAssignDetail;
            }
            catch (System.Exception ex)
            {
                throw;
            }
        }

        public TestPlanAssignDetail GetTestPlanAssignDetailById(int testPlanAssignDetailID)
        {
            try
            {
                var testPlanAssignDetail = _repositoryFactory.TestPlanAssignDetail.Table
                    .Include(x => x.TestPlanAssign)
                    .Include(x => x.TestPlanIndex)
                    .Include(x => x.Instruction)
                    .FirstOrDefault(x => x.TestPlanAssignDetailID == testPlanAssignDetailID);

                return testPlanAssignDetail;
            }
            catch
            {
                throw;
            }
        }

        public async Task<TestPlanAssignDetail> GetTestPlanAssignDetailByIdAsync(int testPlanAssignDetailID)
        {
            try
            {
                var testPlanAssignDetail = await _repositoryFactory.TestPlanAssignDetail.Table
                    .Include(x => x.TestPlanAssign)
                    .Include(x => x.TestPlanIndex)
                    .Include(x => x.Instruction)
                    .FirstOrDefaultAsync(x => x.TestPlanAssignDetailID == testPlanAssignDetailID);

                return testPlanAssignDetail;
            }
            catch
            {
                throw;
            }
        }

        public int Append(TestPlanAssignDetail testPlanAssignDetail)
        {
            try
            {
                var _newObject = new TestPlanAssignDetail
                {
                    TestPlanAssignDetailID = testPlanAssignDetail.TestPlanAssignDetailID,
                    TestPlanAssignID = testPlanAssignDetail.TestPlanAssignID,
                    TestPlanIndexID = testPlanAssignDetail.TestPlanIndexID,
                    MinVal = testPlanAssignDetail.MinVal,
                    MaxVal = testPlanAssignDetail.MaxVal,
                    TextPhrase = testPlanAssignDetail.TextPhrase,
                    UnitID = testPlanAssignDetail.UnitID,
                    DiagnosisMethod = testPlanAssignDetail.DiagnosisMethod,
                    TestTool = testPlanAssignDetail.TestTool,
                    TestStage = testPlanAssignDetail.TestStage,
                    InstructionID = testPlanAssignDetail.InstructionID,
                    Describe = testPlanAssignDetail.Describe,


                };

                _repositoryFactory.TestPlanAssignDetail.Add(_newObject);

                var statuse = _unitOfWork.Commit() > 0;

                if (statuse)
                    return _newObject.TestPlanAssignDetailID;
                else
                    return int.MinValue;
            }
            catch (System.Exception)
            {
                throw;
            }
        }


        public bool Update(TestPlanAssignDetail testPlanAssignDetail)
        {
            try
            {

                _repositoryFactory.TestPlanAssignDetail.UpdateBy(x => x.TestPlanAssignDetailID == testPlanAssignDetail.TestPlanAssignDetailID,
                    new TestPlanAssignDetail
                    {
                        TestPlanAssignDetailID = testPlanAssignDetail.TestPlanAssignDetailID,
                        TestPlanAssignID = testPlanAssignDetail.TestPlanAssignID,
                        TestPlanIndexID = testPlanAssignDetail.TestPlanIndexID,
                        MinVal = testPlanAssignDetail.MinVal,
                        MaxVal = testPlanAssignDetail.MaxVal,
                        TextPhrase = testPlanAssignDetail.TextPhrase,
                        UnitID = testPlanAssignDetail.UnitID,
                        DiagnosisMethod = testPlanAssignDetail.DiagnosisMethod,
                        TestTool = testPlanAssignDetail.TestTool,
                        TestStage = testPlanAssignDetail.TestStage,
                        InstructionID = testPlanAssignDetail.InstructionID,
                        Describe = testPlanAssignDetail.Describe,


                    });
                var statuse = _unitOfWork.Commit() > 0;
                return statuse;
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }

        public long Delete(int testPlanAssignDetailID)
        {
            try
            {
                var testPlanAssignDetail = _repositoryFactory.TestPlanAssignDetail
                    .FirstOrDefault(x => x.TestPlanAssignDetailID == testPlanAssignDetailID);

                if (testPlanAssignDetail == null)
                    throw new System.Exception("TestPlanAssignDetail Notfound.");

                _repositoryFactory.TestPlanAssignDetail.Delete(testPlanAssignDetail);
                var statuse = _unitOfWork.Commit();

                return statuse;
            }
            catch
            {
                throw;
            }
        }


        //public async Task<bool> ExistTestPlanAssignDetailAsync(string name)
        //{
        //    try
        //    {

        //        return await _repositoryFactory.TestPlanAssignDetail.FirstOrDefaultAsync(x => x.TestPlanAssignDetailName.ToUpper() == name.ToUpper()) != null;
        //    }
        //    catch
        //    {
        //        throw;
        //    }
        //}


        public async Task<List<TestPlanAssignDetail>> GetListByTestPlanAssignIdAsync(int testPlanAssignId)
        {
            try
            {
                var testPlanAssignDetail = _repositoryFactory.TestPlanAssignDetail.Table
                    .Include(x => x.TestPlanAssign)
                    .Include(x => x.TestPlanIndex)
                    .Include(x => x.Instruction)
                    .Where(x => x.TestPlanAssignID == testPlanAssignId)
                    .ToList();

                return  testPlanAssignDetail;
            }
            catch
            {
                throw;
            }
        }


    }
}
