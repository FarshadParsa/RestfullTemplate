using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebApi.Core.Interface;

using WebApi.Core.Models;

using WebApi.Core.Repository;

namespace WebApi.Core.Services
{
    public class MenuAccessStatesService : BaseService, IMenuAccessStatesService
    {
        IUnitOfWork _unitOfWork;
        public MenuAccessStatesService(RepositoryFactory repositoryFactory,
            IUnitOfWork unitOfWork)
        {
            _repositoryFactory = repositoryFactory;
            _unitOfWork = unitOfWork;
        }


        public List<MenuAccessStates> GetAll()
        {
            try
            {
                var menuAccessStates = _repositoryFactory.MenuAccessStates.Table.ToList();

                return menuAccessStates;
            }
            catch
            {
                throw;
            }
        }

        public async Task<List<MenuAccessStates>> GetAllAsync()
        {
            try
            {

                var menuAccessStates = await _repositoryFactory.MenuAccessStates.Table.ToListAsync();
                return menuAccessStates;
            }
            catch (System.Exception ex)
            {
                throw;
            }
        }

        public MenuAccessStates GetMenuAccessStatesById(int menuAccessStateID)
        {
            try
            {
                var menuAccessStates = _repositoryFactory.MenuAccessStates
                    .FirstOrDefault(x => x.MenuAccessStateID == menuAccessStateID);

                return menuAccessStates;
            }
            catch
            {
                throw;
            }
        }

        public async Task<MenuAccessStates> GetMenuAccessStatesByIdAsync(int menuAccessStateID)
        {
            try
            {
                var menuAccessStates = await _repositoryFactory.MenuAccessStates
                    .FirstOrDefaultAsync(x => x.MenuAccessStateID == menuAccessStateID);

                return menuAccessStates;
            }
            catch
            {
                throw;
            }
        }

        public bool Append(MenuAccessStates menuAccessStates)
        {
            try
            {
                _repositoryFactory.MenuAccessStates.Add(
                    new MenuAccessStates
                    {
                        MenuAccessStateID = menuAccessStates.MenuAccessStateID,
                        MenuName = menuAccessStates.MenuName,
                        MenuText = menuAccessStates.MenuText,
                        State = menuAccessStates.State,
                        MenuGroupID = menuAccessStates.MenuGroupID,


                    });
                var statuse = _unitOfWork.Commit() > 0;
                return statuse;
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }


        public bool Update(MenuAccessStates menuAccessStates)
        {
            try
            {

                _repositoryFactory.MenuAccessStates.UpdateBy(x => x.MenuAccessStateID == menuAccessStates.MenuAccessStateID,
                    new MenuAccessStates
                    {
                        MenuAccessStateID = menuAccessStates.MenuAccessStateID,
                        MenuName = menuAccessStates.MenuName,
                        MenuText = menuAccessStates.MenuText,
                        State = menuAccessStates.State,
                        MenuGroupID = menuAccessStates.MenuGroupID,


                    });
                var statuse = _unitOfWork.Commit() > 0;
                return statuse;
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }

        public long Delete(int menuAccessStateID)
        {
            try
            {
                var menuAccessStates = _repositoryFactory.MenuAccessStates
                    .FirstOrDefault(x => x.MenuAccessStateID == menuAccessStateID);

                if (menuAccessStates == null)
                    throw new System.Exception("MenuAccessStates Notfound.");

                _repositoryFactory.MenuAccessStates.Delete(menuAccessStates);
                var statuse = _unitOfWork.Commit();

                return statuse;
            }
            catch
            {
                throw;
            }
        }


        public async Task<bool> ExistMenuAccessStatesAsync(string name)
        {
            try
            {
                return await _repositoryFactory.MenuAccessStates.FirstOrDefaultAsync(x => x.MenuName.ToUpper() == name.ToUpper()) != null;
            }
            catch
            {
                throw;
            }
        }

        public async Task<List<MenuAccessStates>> GetMenuAccessStatesByGroupIdAsync(byte groupID)
        {
            try
            {
                var menuAccessStates = await _repositoryFactory.MenuAccessStates
                    .Where(x => x.MenuGroupID == groupID).ToListAsync();

                return menuAccessStates;
            }
            catch
            {
                throw;
            }
        }



    }
}
