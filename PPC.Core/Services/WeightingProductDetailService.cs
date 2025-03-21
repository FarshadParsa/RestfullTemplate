using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PPC.Core.Interface;
using PPC.Core.Models;
using PPC.Core.Repository;
namespace PPC.Core.Services
{
    public class WeightingProductDetailService : BaseService, IWeightingProductDetailService
    {
        IUnitOfWork _unitOfWork;
        public WeightingProductDetailService(RepositoryFactory repositoryFactory,
            IUnitOfWork unitOfWork)
        {
            _repositoryFactory = repositoryFactory;
            _unitOfWork = unitOfWork;
        }


        public List<WeightingProductDetail> GetAll()
        {
            try
            {
                var weightingProductDetail = _repositoryFactory.WeightingProductDetail.Table.ToList();

                return weightingProductDetail;
            }
            catch
            {
                throw;
            }
        }

        public async Task<List<WeightingProductDetail>> GetAllAsync()
        {
            try
            {

                var weightingProductDetail = await _repositoryFactory.WeightingProductDetail.Table.ToListAsync();
                return weightingProductDetail;
            }
            catch (System.Exception ex)
            {
                throw;
            }
        }

        public WeightingProductDetail GetWeightingProductDetailById(int weightingProductDetailID)
        {
            try
            {
                var weightingProductDetail = _repositoryFactory.WeightingProductDetail
                    .FirstOrDefault(x => x.WeightingProductDetailID == weightingProductDetailID);

                return weightingProductDetail;
            }
            catch
            {
                throw;
            }
        }

        public async Task<WeightingProductDetail> GetWeightingProductDetailByIdAsync(int weightingProductDetailID)
        {
            try
            {
                var weightingProductDetail = await _repositoryFactory.WeightingProductDetail
                    .FirstOrDefaultAsync(x => x.WeightingProductDetailID == weightingProductDetailID);

                return weightingProductDetail;
            }
            catch
            {
                throw;
            }
        }

        public int Append(WeightingProductDetail weightingProductDetail)
        {
            try
            {
                var _newObject = new WeightingProductDetail
                {
                    WeightingProductDetailID = weightingProductDetail.WeightingProductDetailID,
                    WeightingProductID = weightingProductDetail.WeightingProductID,
                    PackagingPlanID = weightingProductDetail.PackagingPlanID,
                    QTY = weightingProductDetail.QTY,
                    EmptyWeight = weightingProductDetail.EmptyWeight,
                    NetWeight = weightingProductDetail.NetWeight,


                };

                _repositoryFactory.WeightingProductDetail.Add(_newObject);

                var statuse = _unitOfWork.Commit() > 0;

                if (statuse)
                    return _newObject.WeightingProductDetailID;
                else
                    return int.MinValue;
            }
            catch (System.Exception)
            {
                throw;
            }
        }


        public bool Update(WeightingProductDetail weightingProductDetail)
        {
            try
            {

                _repositoryFactory.WeightingProductDetail.UpdateBy(x => x.WeightingProductDetailID == weightingProductDetail.WeightingProductDetailID,
                    new WeightingProductDetail
                    {
                        WeightingProductDetailID = weightingProductDetail.WeightingProductDetailID,
                        WeightingProductID = weightingProductDetail.WeightingProductID,
                        PackagingPlanID = weightingProductDetail.PackagingPlanID,
                        QTY = weightingProductDetail.QTY,
                        EmptyWeight = weightingProductDetail.EmptyWeight,
                        NetWeight = weightingProductDetail.NetWeight,


                    });
                var statuse = _unitOfWork.Commit() > 0;
                return statuse;
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }

        public long Delete(int weightingProductDetailID)
        {
            try
            {
                var weightingProductDetail = _repositoryFactory.WeightingProductDetail
                    .FirstOrDefault(x => x.WeightingProductDetailID == weightingProductDetailID);

                if (weightingProductDetail == null)
                    throw new System.Exception("WeightingProductDetail Notfound.");

                _repositoryFactory.WeightingProductDetail.Delete(weightingProductDetail);
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
