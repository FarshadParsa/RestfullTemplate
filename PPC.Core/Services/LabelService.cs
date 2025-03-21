using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PPC.Core.Interface;
using PPC.Core.Models;
using PPC.Core.Repository;
namespace PPC.Core.Services
{
    public class LabelService : BaseService, ILabelService
    {
        IUnitOfWork _unitOfWork;
        public LabelService(RepositoryFactory repositoryFactory,
            IUnitOfWork unitOfWork)
        {
            _repositoryFactory = repositoryFactory;
            _unitOfWork = unitOfWork;
        }


        public List<Label> GetAll()
        {
            try
            {
                var label = _repositoryFactory.Label.Table.ToList();

                return label;
            }
            catch
            {
                throw;
            }
        }

        public async Task<List<Label>> GetAllAsync()
        {
            try
            {

                var label = await _repositoryFactory.Label.Table.ToListAsync();
                return label;
            }
            catch (System.Exception ex)
            {
                throw;
            }
        }

        public Label GetLabelById(int labelID)
        {
            try
            {
                var label = _repositoryFactory.Label
                    .FirstOrDefault(x => x.LabelID == labelID);

                return label;
            }
            catch
            {
                throw;
            }
        }

        public async Task<Label> GetLabelByIdAsync(int labelID)
        {
            try
            {
                var label = await _repositoryFactory.Label
                    .FirstOrDefaultAsync(x => x.LabelID == labelID);

                return label;
            }
            catch
            {
                throw;
            }
        }

        public int Append(Label label)
        {
            try
            {
                var _newObject = new Label
                {
                    LabelID = label.LabelID,
                    LabelName = label.LabelName,
                    ZebraCommand = label.ZebraCommand,


                };

                _repositoryFactory.Label.Add(_newObject);

                var statuse = _unitOfWork.Commit() > 0;

                if (statuse)
                    return _newObject.LabelID;
                else
                    return int.MinValue;
            }
            catch (System.Exception)
            {
                throw;
            }
        }


        public bool Update(Label label)
        {
            try
            {

                _repositoryFactory.Label.UpdateBy(x => x.LabelID == label.LabelID,
                    new Label
                    {
                        LabelID = label.LabelID,
                        LabelName = label.LabelName,
                        ZebraCommand = label.ZebraCommand,


                    });
                var statuse = _unitOfWork.Commit() > 0;
                return statuse;
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }

        public long Delete(int labelID)
        {
            try
            {
                var label = _repositoryFactory.Label
                    .FirstOrDefault(x => x.LabelID == labelID);

                if (label == null)
                    throw new System.Exception("Label Notfound.");

                _repositoryFactory.Label.Delete(label);
                var statuse = _unitOfWork.Commit();

                return statuse;
            }
            catch
            {
                throw;
            }
        }


        public async Task<Label> GetInstanceByNameAsync(string name)
        {
            try
            {

                return await _repositoryFactory.Label
                    //.Table.Include(x=>x.RawMaterial)
                    .FirstOrDefaultAsync(x => x.LabelName.ToUpper() == name.ToUpper());
            }
            catch
            {
                throw;
            }
        }


    }
}
