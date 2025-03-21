using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PPC.Core.Interface;

using PPC.Core.Models;

using PPC.Core.Repository;

namespace PPC.Core.Services
{
    public class InvRawMaterialLotsService : BaseService, IInvRawMaterialLotsService
    {
        IUnitOfWork _unitOfWork;
        public InvRawMaterialLotsService(RepositoryFactory repositoryFactory,
            IUnitOfWork unitOfWork)
        {
            _repositoryFactory = repositoryFactory;
            _unitOfWork = unitOfWork;
        }


        public List<InvRawMaterialLots> GetAll()
        {
            try
            {
                var invRawMaterialLots = _repositoryFactory.InvRawMaterialLots.Table.Include(x=>x.InvRawMaterial).ToList();

                return invRawMaterialLots;
            }
            catch
            {
                throw;
            }
        }

        public async Task<List<InvRawMaterialLots>> GetAllAsync()
        {
            try
            {

                var invRawMaterialLots = await _repositoryFactory.InvRawMaterialLots.Table.Include(x => x.InvRawMaterial).ToListAsync();
                return invRawMaterialLots;
            }
            catch (System.Exception ex)
            {
                throw;
            }
        }

        public InvRawMaterialLots GetInvRawMaterialLotsById(int invRawMaterialLotID)
        {
            try
            {
                var invRawMaterialLots = _repositoryFactory.InvRawMaterialLots.Table.Include(x => x.InvRawMaterial)
                    .FirstOrDefault(x => x.InvRawMaterialLotID == invRawMaterialLotID);

                return invRawMaterialLots;
            }
            catch
            {
                throw;
            }
        }

        public async Task<InvRawMaterialLots> GetInvRawMaterialLotsByIdAsync(int invRawMaterialLotID)
        {
            try
            {
                var invRawMaterialLots = await _repositoryFactory.InvRawMaterialLots.Table.Include(x => x.InvRawMaterial)
                    .FirstOrDefaultAsync(x => x.InvRawMaterialLotID == invRawMaterialLotID);

                return invRawMaterialLots;
            }
            catch
            {
                throw;
            }
        }

        public int Append(InvRawMaterialLots invRawMaterialLots)
        {
            try
            {
                var _newObject = new InvRawMaterialLots
                {
                    InvRawMaterialLotID = invRawMaterialLots.InvRawMaterialLotID,
                    InvRawMaterialID = invRawMaterialLots.InvRawMaterialID,
                    LotNo = invRawMaterialLots.LotNo,
                    IsGenerated = invRawMaterialLots.IsGenerated,
                    ProducedDate = invRawMaterialLots.ProducedDate,
                    EnProducedDate = invRawMaterialLots.EnProducedDate,
                    ExpireDate = invRawMaterialLots.ExpireDate,
                    EnExpireDate = invRawMaterialLots.EnExpireDate,
                    ShelfLife = invRawMaterialLots.ShelfLife,
                    EnShelfLife = invRawMaterialLots.EnShelfLife,
                    SolidPercentage = invRawMaterialLots.SolidPercentage,
                    QcStatus = invRawMaterialLots.QcStatus,
                    RNDStatus = invRawMaterialLots.RNDStatus,
                    Weight = invRawMaterialLots.Weight,
                    NetWeight = invRawMaterialLots.NetWeight,
                    Describe = invRawMaterialLots.Describe,
                    PalletQty = invRawMaterialLots.PalletQty,
                    PackagingTypeID = invRawMaterialLots.PackagingTypeID,
                    RawMaterialID = invRawMaterialLots.RawMaterialID,
                    

                };

                _repositoryFactory.InvRawMaterialLots.Add(_newObject);

                var statuse = _unitOfWork.Commit() > 0;

                if (statuse)
                    return _newObject.InvRawMaterialLotID;
                else
                    throw new System.Exception(Resources.Resources.pub_RegistrationHasError);
            }
            catch (System.Exception)
            {
                throw;
            }
        }

        public bool Update(InvRawMaterialLots invRawMaterialLots)
        {
            try
            {

                _repositoryFactory.InvRawMaterialLots.UpdateBy(x => x.InvRawMaterialLotID == invRawMaterialLots.InvRawMaterialLotID,
                    new InvRawMaterialLots
                    {
                        InvRawMaterialLotID = invRawMaterialLots.InvRawMaterialLotID,
                        InvRawMaterialID = invRawMaterialLots.InvRawMaterialID,
                        LotNo = invRawMaterialLots.LotNo,
                        IsGenerated = invRawMaterialLots.IsGenerated,
                        ProducedDate = invRawMaterialLots.ProducedDate,
                        EnProducedDate = invRawMaterialLots.EnProducedDate,
                        ExpireDate = invRawMaterialLots.ExpireDate,
                        EnExpireDate = invRawMaterialLots.EnExpireDate,
                        ShelfLife = invRawMaterialLots.ShelfLife,
                        EnShelfLife = invRawMaterialLots.EnShelfLife,
                        SolidPercentage = invRawMaterialLots.SolidPercentage,
                        QcStatus = invRawMaterialLots.QcStatus,
                        RNDStatus = invRawMaterialLots.RNDStatus,
                        Weight = invRawMaterialLots.Weight,
                        NetWeight = invRawMaterialLots.NetWeight,
                        Describe = invRawMaterialLots.Describe,
                        PalletQty = invRawMaterialLots.PalletQty,
                        PackagingTypeID = invRawMaterialLots.PackagingTypeID,
                        RawMaterialID = invRawMaterialLots.RawMaterialID,


                    });
                var statuse = _unitOfWork.Commit() > 0;
                return statuse;
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }

        public long Delete(int invRawMaterialLotID)
        {
            try
            {
                var invRawMaterialLots = _repositoryFactory.InvRawMaterialLots
                    .FirstOrDefault(x => x.InvRawMaterialLotID == invRawMaterialLotID);

                if (invRawMaterialLots == null)
                    throw new System.Exception("InvRawMaterialLots Notfound.");

                _repositoryFactory.InvRawMaterialLots.Delete(invRawMaterialLots);
                var statuse = _unitOfWork.Commit();

                return statuse;
            }
            catch
            {
                throw;
            }
        }


        public async Task<InvRawMaterialLots> GetInvRawMaterialLotsAsync(string lotNo)
        {
            try
            {

                return await _repositoryFactory.InvRawMaterialLots.Table.Include(x => x.InvRawMaterial)
                    .FirstOrDefaultAsync(x => x.LotNo.ToUpper() == lotNo.ToUpper()) ;
            }
            catch
            {
                throw;
            }
        }

        public async Task<string> GetLatestByPartOfLotNoAsync(string partlotNo)
        {
            try
            
            {

                var q = await _repositoryFactory.InvRawMaterialLots.Table.Include(x => x.InvRawMaterial)
                    .Where(x => x.LotNo.ToUpper().StartsWith(partlotNo.ToUpper()))
                    .MaxAsync(x => x.LotNo);

                return q;
            }
            catch
            {
                throw;
            }
        }

    }
}
