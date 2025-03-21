using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PPC.Core.Interface;
using PPC.Core.Models;
using PPC.Core.Repository;
namespace PPC.Core.Services
{
    public class BOMDetailService : BaseService, IBOMDetailService
    {
        IUnitOfWork _unitOfWork;
        public BOMDetailService(RepositoryFactory repositoryFactory,
            IUnitOfWork unitOfWork)
        {
            _repositoryFactory = repositoryFactory;
            _unitOfWork = unitOfWork;
        }


        public List<BOMDetail> GetAll()
        {
            try
            {
                var bOMDetail = _repositoryFactory.BOMDetail.Table.ToList();

                return bOMDetail;
            }
            catch
            {
                throw;
            }
        }

        public async Task<List<BOMDetail>> GetAllAsync()
        {
            try
            {

                var bOMDetail = await _repositoryFactory.BOMDetail.Table.ToListAsync();
                return bOMDetail;
            }
            catch (System.Exception ex)
            {
                throw;
            }
        }

        public BOMDetail GetBOMDetailById(int bOMDetailID)
        {
            try
            {
                var bOMDetail = _repositoryFactory.BOMDetail
                    .FirstOrDefault(x => x.BOMDetailID == bOMDetailID);

                return bOMDetail;
            }
            catch
            {
                throw;
            }
        }

        public async Task<BOMDetail> GetBOMDetailByIdAsync(int bOMDetailID)
        {
            try
            {
                var bOMDetail = await _repositoryFactory.BOMDetail
                    .FirstOrDefaultAsync(x => x.BOMDetailID == bOMDetailID);

                return bOMDetail;
            }
            catch
            {
                throw;
            }
        }

        public int Append(BOMDetail bOMDetail)
        {
            try
            {
                var _newObject = new BOMDetail
                {
                    BOMDetailID = bOMDetail.BOMDetailID,
                    BOMID = bOMDetail.BOMID,
                    RawMaterialID = bOMDetail.RawMaterialID,
                    RMWhiteListID = bOMDetail.RMWhiteListID,
                    Priority = bOMDetail.Priority,
                    Percentage = bOMDetail.Percentage,
                    IsFinalRM = bOMDetail.IsFinalRM,
                    Describe = bOMDetail.Describe,


                };

                _repositoryFactory.BOMDetail.Add(_newObject);

                var statuse = _unitOfWork.Commit() > 0;

                if (statuse)
                    return _newObject.BOMDetailID;
                else
                    return int.MinValue;
            }
            catch (System.Exception)
            {
                throw;
            }
        }


        public bool Update(BOMDetail bOMDetail)
        {
            try
            {

                _repositoryFactory.BOMDetail.UpdateBy(x => x.BOMDetailID == bOMDetail.BOMDetailID,
                    new BOMDetail
                    {
                        BOMDetailID = bOMDetail.BOMDetailID,
                        BOMID = bOMDetail.BOMID,
                        RawMaterialID = bOMDetail.RawMaterialID,
                        RMWhiteListID = bOMDetail.RMWhiteListID,
                        Priority = bOMDetail.Priority,
                        Percentage = bOMDetail.Percentage,
                        IsFinalRM = bOMDetail.IsFinalRM,
                        Describe = bOMDetail.Describe,


                    });
                var statuse = _unitOfWork.Commit() > 0;
                return statuse;
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }

        public long Delete(int bOMDetailID)
        {
            try
            {
                var bOMDetail = _repositoryFactory.BOMDetail
                    .FirstOrDefault(x => x.BOMDetailID == bOMDetailID);

                if (bOMDetail == null)
                    throw new System.Exception("BOMDetail Notfound.");

                _repositoryFactory.BOMDetail.Delete(bOMDetail);
                var statuse = _unitOfWork.Commit();

                return statuse;
            }
            catch
            {
                throw;
            }
        }

        public async Task<List<BOMDetail>> GetListByBOMIdAsync(int id)
        {
            try
            {

                var bOMDetail = await _repositoryFactory.BOMDetail
                    .Where (x=>x.BOMID==id)
                    .Include(x=>x.RawMaterial)
                    .Include(x=>x.RMWhiteList)
                    //.Table
                    .ToListAsync();
                return bOMDetail;
            }
            catch (System.Exception ex)
            {
                throw;
            }
        }


    }
}
