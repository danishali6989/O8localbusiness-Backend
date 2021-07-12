using UserManagement.Dtos;
using UserManagement.Dtos.UserLogin;
using UserManagement.Factories;
using UserManagement.Infrastructure.DataLayer;
using UserManagement.Infrastructure.Managers;
using UserManagement.Infrastructure.Repositories;
using UserManagement.Models.UserLogin;
using UserManagement.Utilities;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using UserManagement.Dtos.UserAccess;

namespace UserManagement.Managers
{
    public class UserRoleManager:IUserRoleManager
    {
        private readonly IUserRoleRepository _repository;
        private readonly IUserAccessMAnager _screenrepository;
        private readonly IUnitOfWork _unitOfWork;

        private readonly string _userId;

        public UserRoleManager(IHttpContextAccessor contextAccessor,
          IUserRoleRepository repository, IUserAccessMAnager screenRepository,
          IUnitOfWork unitOfWork)
        {
            _userId = contextAccessor.HttpContext.User.GetUserId();

            _repository = repository;
            _unitOfWork = unitOfWork;
            _screenrepository = screenRepository;


        }

        public async Task AddAsync(UserRoleModel model, string header)
        {
            await _repository.AddAsync(UserRoleFactory.Create(model, _userId, header));
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task EditAsync(UserRoleModel model, string header)
        {
            var item = await _repository.GetAsync(model.Id, Convert.ToInt32(header));
            UserRoleFactory.Create(model, item, _userId, header);
            _repository.Edit(item);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task<UserRoleDetailDto> GetDetailAsync(int id, int header)
        {
            return await _repository.GetDetailAsync(id, header);
        }

        public async Task<JqDataTableResponse<UserRoleDetailDto>> GetPagedResultAsync(JqDataTableRequest model, int header)
        {
            return await _repository.GetPagedResultAsync(model, header);
        }

        public async Task DeleteAsync(int id, int header)
        {
            await _repository.DeleteAsync(id, header);
            await _unitOfWork.SaveChangesAsync();
        }
        public async Task<List<UserRoleDetailDto>> GetAllAsync(int header)
        {
            List<UserRoleDetailDto> data = new List<UserRoleDetailDto>();
                      data = await _repository.GetAllAsync(header);
            if (data.Count >0)
            {
                List<ScreenAccessDto> Screens = new List<ScreenAccessDto>();
                ScreenAccessDto obj = new ScreenAccessDto();

                foreach (var item in data)
                {
                    obj.Id = item.Id;

                    obj.ScreenName = item.ScreenName;
                    obj.ScreenId = item.Id;

                    Screens.Add(obj);
                    item.Screens = await _screenrepository.GetUserScreenAccessById(item.Id, header);
                }
            }



                    return data;
            
        }
        public bool UpdateRoleId(int roleId, int userId, string header)
        {
            return _repository.UpdateRoleId(roleId, userId,header);

        }
    }
}
