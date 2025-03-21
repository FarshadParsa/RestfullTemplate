using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PPC.Core.Interface;

using PPC.Core.Models;

using PPC.Core.Repository;
using PPC.Response.DTOs;

namespace PPC.Core.Services
{
    public class AutoCompleteFieldService : BaseService, IAutoCompleteFieldService
    {
        IUnitOfWork _unitOfWork;
        public AutoCompleteFieldService(RepositoryFactory repositoryFactory,
            IUnitOfWork unitOfWork)
        {
            _repositoryFactory = repositoryFactory;
            _unitOfWork = unitOfWork;
        }


        public List<AutoCompleteField> GetAll()
        {
            try
            {
                var autoCompleteField = _repositoryFactory.AutoCompleteField.Table.ToList();

                return autoCompleteField;
            }
            catch
            {
                throw;
            }
        }

        public async Task<List<AutoCompleteField>> GetAllAsync()
        {
            try
            {

                var autoCompleteField = await _repositoryFactory.AutoCompleteField.Table.ToListAsync();
                return autoCompleteField;
            }
            catch (System.Exception ex)
            {
                throw;
            }
        }

        public AutoCompleteField GetAutoCompleteFieldById(int autoCompleteFieldID)
        {
            try
            {
                var autoCompleteField = _repositoryFactory.AutoCompleteField
                    .FirstOrDefault(x => x.AutoCompleteFieldID == autoCompleteFieldID);

                return autoCompleteField;
            }
            catch
            {
                throw;
            }
        }

        public async Task<AutoCompleteField> GetAutoCompleteFieldByIdAsync(int autoCompleteFieldID)
        {
            try
            {
                var autoCompleteField = await _repositoryFactory.AutoCompleteField
                    .FirstOrDefaultAsync(x => x.AutoCompleteFieldID == autoCompleteFieldID);

                return autoCompleteField;
            }
            catch
            {
                throw;
            }
        }

        public int Append(AutoCompleteField autoCompleteField)
        {
            try
            {
                var _newObject = new AutoCompleteField
                {
                    AutoCompleteFieldID = autoCompleteField.AutoCompleteFieldID,
                    FieldName = autoCompleteField.FieldName,
                    FieldValue = autoCompleteField.FieldValue,


                };

                _repositoryFactory.AutoCompleteField.Add(_newObject);

                var statuse = _unitOfWork.Commit() > 0;

                if (statuse)
                    return _newObject.AutoCompleteFieldID;
                else
                    return int.MinValue;
            }
            catch (System.Exception)
            {
                throw;
            }
        }


        public bool Update(AutoCompleteField autoCompleteField)
        {
            try
            {

                _repositoryFactory.AutoCompleteField.UpdateBy(x => x.AutoCompleteFieldID == autoCompleteField.AutoCompleteFieldID,
                    new AutoCompleteField
                    {
                        AutoCompleteFieldID = autoCompleteField.AutoCompleteFieldID,
                        FieldName = autoCompleteField.FieldName,
                        FieldValue = autoCompleteField.FieldValue,


                    });
                var statuse = _unitOfWork.Commit() > 0;
                return statuse;
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }

        public long Delete(int autoCompleteFieldID)
        {
            try
            {
                var autoCompleteField = _repositoryFactory.AutoCompleteField
                    .FirstOrDefault(x => x.AutoCompleteFieldID == autoCompleteFieldID);

                if (autoCompleteField == null)
                    throw new System.Exception("AutoCompleteField Notfound.");

                _repositoryFactory.AutoCompleteField.Delete(autoCompleteField);
                var statuse = _unitOfWork.Commit();

                return statuse;
            }
            catch
            {
                throw;
            }
        }


        public async Task<List<AutoCompleteField>> GetAutoCompleteFieldByFieldNameAsync(string name)
        {
            try
            {
                return await _repositoryFactory.AutoCompleteField.Where(x => x.FieldName.ToUpper() == name.ToUpper()).ToListAsync();
            }
            catch
            {
                throw;
            }
        }


    }
}
