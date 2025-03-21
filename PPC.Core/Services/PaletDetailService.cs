using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PPC.Core.Interface;
using PPC.Core.Models;
using PPC.Core.Repository;
namespace PPC.Core.Services
{
    public class PaletDetailService : BaseService, IPaletDetailService
    {
        IUnitOfWork _unitOfWork;
        public PaletDetailService(RepositoryFactory repositoryFactory,
            IUnitOfWork unitOfWork)
        {
            _repositoryFactory = repositoryFactory;
            _unitOfWork = unitOfWork;
        }


        public List<PaletDetail> GetAll()
        {
            try
            {
                var paletDetail = _repositoryFactory.PaletDetail.Table.ToList();

                return paletDetail;
            }
            catch
            {
                throw;
            }
        }

        public async Task<List<PaletDetail>> GetAllAsync()
        {
            try
            {

                var paletDetail = await _repositoryFactory.PaletDetail.Table.ToListAsync();
                return paletDetail;
            }
            catch (System.Exception ex)
            {
                throw;
            }
        }

        public PaletDetail GetPaletDetailById(int paletDetailID)
        {
            try
            {
                var paletDetail = _repositoryFactory.PaletDetail
                    .FirstOrDefault(x => x.PaletDetailID == paletDetailID);

                return paletDetail;
            }
            catch
            {
                throw;
            }
        }

        public async Task<PaletDetail> GetPaletDetailByIdAsync(int paletDetailID)
        {
            try
            {
                var paletDetail = await _repositoryFactory.PaletDetail
                    .FirstOrDefaultAsync(x => x.PaletDetailID == paletDetailID);

                return paletDetail;
            }
            catch
            {
                throw;
            }
        }

        public int Append(PaletDetail paletDetail)
        {
            try
            {
                var _newObject = new PaletDetail
                {
                    PaletDetailID = paletDetail.PaletDetailID,
                    InvProductID = paletDetail.InvProductID,
                    PaletID = paletDetail.PaletID,


                };

                _repositoryFactory.PaletDetail.Add(_newObject);

                var statuse = _unitOfWork.Commit() > 0;

                if (statuse)
                    return _newObject.PaletDetailID;
                else
                    return int.MinValue;
            }
            catch (System.Exception)
            {
                throw;
            }
        }


        public bool Update(PaletDetail paletDetail)
        {
            try
            {

                _repositoryFactory.PaletDetail.UpdateBy(x => x.PaletDetailID == paletDetail.PaletDetailID,
                    new PaletDetail
                    {
                        PaletDetailID = paletDetail.PaletDetailID,
                        InvProductID = paletDetail.InvProductID,
                        PaletID = paletDetail.PaletID,


                    });
                var statuse = _unitOfWork.Commit() > 0;
                return statuse;
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }

        public long Delete(int paletDetailID)
        {
            try
            {
                var paletDetail = _repositoryFactory.PaletDetail
                    .FirstOrDefault(x => x.PaletDetailID == paletDetailID);

                if (paletDetail == null)
                    throw new System.Exception("PaletDetail Notfound.");

                _repositoryFactory.PaletDetail.Delete(paletDetail);
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

