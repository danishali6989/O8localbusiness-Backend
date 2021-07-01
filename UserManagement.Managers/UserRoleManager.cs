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

namespace UserManagement.Managers
{
    public class UserRoleManager:IUserRoleManager
    {
        private readonly IUserRoleRepository _repository;
        private readonly IUnitOfWork _unitOfWork;

        private readonly string _userId;

        public UserRoleManager(IHttpContextAccessor contextAccessor,
          IUserRoleRepository repository,
          IUnitOfWork unitOfWork)
        {
            _userId = contextAccessor.HttpContext.User.GetUserId();

            _repository = repository;
            _unitOfWork = unitOfWork;
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
        public async Task<List<SelectListItemDto>> GetAllAsync(int header)
        {
            return await _repository.GetAllAsync(header);
        }
        public bool UpdateRoleId(int roleId, int userId, string header)
        {
            return _repository.UpdateRoleId(roleId, userId,header);

        }
    }
}
