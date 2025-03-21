using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PPC.Core.Interface;
using PPC.Core.Models;
using PPC.Core.Repository;
namespace PPC.Core.Services
{
    public class CardTypesService : BaseService, ICardTypesService
    {
        //IUnitOfWork _unitOfWork;
        public CardTypesService(RepositoryFactory repositoryFactory,
            IUnitOfWork unitOfWork)
        {
            _repositoryFactory = repositoryFactory;
            _unitOfWork = unitOfWork;
        }


        public List<CardTypes> GetAll()
        {
            try
            {
                var cardTypes = _repositoryFactory.CardTypes.Table.ToList();

                return cardTypes;
            }
            catch
            {
                throw;
            }
        }

        public async Task<List<CardTypes>> GetAllAsync()
        {
            try
            {

                var cardTypes = await _repositoryFactory.CardTypes.Table.ToListAsync();
                return cardTypes;
            }
            catch (System.Exception ex)
            {
                throw;
            }
        }

        public CardTypes GetCardTypesById(byte cardTypeID)
        {
            try
            {
                var cardTypes = _repositoryFactory.CardTypes
                    .FirstOrDefault(x => x.CardTypeID == cardTypeID);

                return cardTypes;
            }
            catch
            {
                throw;
            }
        }

        public async Task<CardTypes> GetCardTypesByIdAsync(byte cardTypeID)
        {
            try
            {
                var cardTypes = await _repositoryFactory.CardTypes
                    .FirstOrDefaultAsync(x => x.CardTypeID == cardTypeID);

                return cardTypes;
            }
            catch
            {
                throw;
            }
        }

        public byte Append(CardTypes cardTypes)
        {
            try
            {
                var _newObject = new CardTypes
                {
                    CardTypeID = cardTypes.CardTypeID,
                    CardTypeName = cardTypes.CardTypeName,
                    CardTypeVal = cardTypes.CardTypeVal,
                    OrderBy = cardTypes.OrderBy,
                    IsEntry = cardTypes.IsEntry,
                    IsActive = cardTypes.IsActive,


                };

                _repositoryFactory.CardTypes.Add(_newObject);

                var statuse = _unitOfWork.Commit() > 0;

                if (statuse)
                    return _newObject.CardTypeID;
                else
                    return byte.MinValue;
            }
            catch (System.Exception)
            {
                throw;
            }
        }


        public bool Update(CardTypes cardTypes)
        {
            try
            {

                _repositoryFactory.CardTypes.UpdateBy(x => x.CardTypeID == cardTypes.CardTypeID,
                    new CardTypes
                    {
                        CardTypeID = cardTypes.CardTypeID,
                        CardTypeName = cardTypes.CardTypeName,
                        CardTypeVal = cardTypes.CardTypeVal,
                        OrderBy = cardTypes.OrderBy,
                        IsEntry = cardTypes.IsEntry,
                        IsActive = cardTypes.IsActive,


                    });
                var statuse = _unitOfWork.Commit() > 0;
                return statuse;
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }

        public long Delete(byte cardTypeID)
        {
            try
            {
                var cardTypes = _repositoryFactory.CardTypes
                    .FirstOrDefault(x => x.CardTypeID == cardTypeID);

                if (cardTypes == null)
                    throw new System.Exception("CardTypes Notfound.");

                _repositoryFactory.CardTypes.Delete(cardTypes);
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
