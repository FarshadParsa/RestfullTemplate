using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PPC.Core.Interface;
using PPC.Core.Models;
using PPC.Core.Repository;
namespace PPC.Core.Services
{
    public class DeliveryRawMaterialToProductionPatilsService : BaseService, IDeliveryRawMaterialToProductionPatilsService
    {
        IUnitOfWork _unitOfWork;
        public DeliveryRawMaterialToProductionPatilsService(RepositoryFactory repositoryFactory,
            IUnitOfWork unitOfWork)
        {
            _repositoryFactory = repositoryFactory;
            _unitOfWork = unitOfWork;
        }


        public List<DeliveryRawMaterialToProductionPatils> GetAll()
        {
            try
            {
                var deliveryRawMaterialToProductionPatils = _repositoryFactory.DeliveryRawMaterialToProductionPatils.Table.ToList();

                return deliveryRawMaterialToProductionPatils;
            }
            catch
            {
                throw;
            }
        }

        public async Task<List<DeliveryRawMaterialToProductionPatils>> GetAllAsync()
        {
            try
            {

                var deliveryRawMaterialToProductionPatils = await _repositoryFactory.DeliveryRawMaterialToProductionPatils.Table.ToListAsync();
                return deliveryRawMaterialToProductionPatils;
            }
            catch (System.Exception ex)
            {
                throw;
            }
        }

        public DeliveryRawMaterialToProductionPatils GetDeliveryRawMaterialToProductionPatilsById(int deliveryRawMaterialToProductionPatilID)
        {
            try
            {
                var deliveryRawMaterialToProductionPatils = _repositoryFactory.DeliveryRawMaterialToProductionPatils
                    .FirstOrDefault(x => x.DeliveryRawMaterialToProductionPatilID == deliveryRawMaterialToProductionPatilID);

                return deliveryRawMaterialToProductionPatils;
            }
            catch
            {
                throw;
            }
        }

        public async Task<DeliveryRawMaterialToProductionPatils> GetDeliveryRawMaterialToProductionPatilsByIdAsync(int deliveryRawMaterialToProductionPatilID)
        {
            try
            {
                var deliveryRawMaterialToProductionPatils = await _repositoryFactory.DeliveryRawMaterialToProductionPatils
                    .FirstOrDefaultAsync(x => x.DeliveryRawMaterialToProductionPatilID == deliveryRawMaterialToProductionPatilID);

                return deliveryRawMaterialToProductionPatils;
            }
            catch
            {
                throw;
            }
        }

        public int Append(DeliveryRawMaterialToProductionPatils deliveryRawMaterialToProductionPatils)
        {
            try
            {
                var _newObject = new DeliveryRawMaterialToProductionPatils
                {
                    DeliveryRawMaterialToProductionPatilID = deliveryRawMaterialToProductionPatils.DeliveryRawMaterialToProductionPatilID,
                    DeliveryRawMaterialToProductionID = deliveryRawMaterialToProductionPatils.DeliveryRawMaterialToProductionID,
                    ProductionPlanPatilID = deliveryRawMaterialToProductionPatils.ProductionPlanPatilID,


                };

                _repositoryFactory.DeliveryRawMaterialToProductionPatils.Add(_newObject);

                var statuse = _unitOfWork.Commit() > 0;

                if (statuse)
                    return _newObject.DeliveryRawMaterialToProductionPatilID;
                else
                    return int.MinValue;
            }
            catch (System.Exception)
            {
                throw;
            }
        }


        public bool Update(DeliveryRawMaterialToProductionPatils deliveryRawMaterialToProductionPatils)
        {
            try
            {

                _repositoryFactory.DeliveryRawMaterialToProductionPatils.UpdateBy(x => x.DeliveryRawMaterialToProductionPatilID == deliveryRawMaterialToProductionPatils.DeliveryRawMaterialToProductionPatilID,
                    new DeliveryRawMaterialToProductionPatils
                    {
                        DeliveryRawMaterialToProductionPatilID = deliveryRawMaterialToProductionPatils.DeliveryRawMaterialToProductionPatilID,
                        DeliveryRawMaterialToProductionID = deliveryRawMaterialToProductionPatils.DeliveryRawMaterialToProductionID,
                        ProductionPlanPatilID = deliveryRawMaterialToProductionPatils.ProductionPlanPatilID,


                    });
                var statuse = _unitOfWork.Commit() > 0;
                return statuse;
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }

        public long Delete(int deliveryRawMaterialToProductionPatilID)
        {
            try
            {
                var deliveryRawMaterialToProductionPatils = _repositoryFactory.DeliveryRawMaterialToProductionPatils
                    .FirstOrDefault(x => x.DeliveryRawMaterialToProductionPatilID == deliveryRawMaterialToProductionPatilID);

                if (deliveryRawMaterialToProductionPatils == null)
                    throw new System.Exception("DeliveryRawMaterialToProductionPatils Notfound.");

                _repositoryFactory.DeliveryRawMaterialToProductionPatils.Delete(deliveryRawMaterialToProductionPatils);
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
