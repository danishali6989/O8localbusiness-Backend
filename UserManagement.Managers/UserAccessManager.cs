using UserManagement.Dtos.UserAccess;
using UserManagement.Entities;
using UserManagement.Factories;
using UserManagement.Infrastructure.DataLayer;
using UserManagement.Infrastructure.Managers;
using UserManagement.Infrastructure.Repositories;
using UserManagement.Models.UserAccess;
using UserManagement.Utilities;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace UserManagement.Managers
{
    public class UserAccessManager : IUserAccessMAnager
    {
        private readonly IUserAccessRepository _repository;
        private readonly IUnitOfWork _unitOfWork;

        private readonly string _userId;

        public UserAccessManager(IHttpContextAccessor contextAccessor,
          IUserAccessRepository repository,
          IUnitOfWork unitOfWork)
        {
            _userId = contextAccessor.HttpContext.User.GetUserId();

            _repository = repository;
            _unitOfWork = unitOfWork;
        }

        public async Task AddUserScreenAccessAsync(ScreenAccessModel model, string header)
        {
            await _repository.DeleteAsyncUserScreenAccess(model.UserRoleId);
            await _unitOfWork.SaveChangesAsync();
            List<UserScreenAccess> item = new List<UserScreenAccess>();
           
            UserScreenAccessFactory.CreateUserScreenAccess(model, item, header);
            await _repository.AddUserScreenAccessAsync(item);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task<List<ScreenAccessDto>> GetUserScreenAccessById(int id, int header)
        {
            List<ScreenAccessDto> data = new List<ScreenAccessDto>();
          data = await _repository.GetAsyncUserScreenAccess(id, header);
            if(data.Count == 0)
            {
                var screenData = await _repository.GetAllScreen();
                foreach(var item in screenData)
                {
                    ScreenAccessDto obj = new ScreenAccessDto();
                    obj.ScreenId = item.Id;
                    obj.UserRoleId = id;
                    obj.CanAccess = false;
                    obj.ScreenName = item.ScreenName;
                    data.Add(obj);
                }
            }

            return data;
        }
        public async Task<List<ScreendetailDto>> GetAllScreenDetail(int header)
        {
            return await _repository.GetAllScreenDetail(header);
        }
    }
}
