using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using UserManagement.Dtos.Permission;
using UserManagement.Factories;
using UserManagement.Infrastructure.DataLayer;
using UserManagement.Infrastructure.Managers;
using UserManagement.Infrastructure.Repositories;
using UserManagement.Models.Permission;
using UserManagement.Utilities;

namespace UserManagement.Managers
{
    public class PermissionManager:IPermissionManager
    {
        private readonly IPermissionRepository _repository;
        private readonly IUnitOfWork _unitOfWork;

        private readonly string _userId;

        public PermissionManager(IHttpContextAccessor contextAccessor,
          IPermissionRepository repository,
          IUnitOfWork unitOfWork)
        {
            _userId = contextAccessor.HttpContext.User.GetUserId();

            _repository = repository;
            _unitOfWork = unitOfWork;
        }

        public async Task AddAsync(PermissionAddModel model,string header)
        {
            await _repository.AddAsync(PermissionFactory.Create(model, _userId,header));
            await _unitOfWork.SaveChangesAsync();
        }


        public async Task EditAsync(PermissionEditModel model, string header)
        {
            var item = await _repository.GetAsync(model.Id, Convert.ToInt32(header));
            PermissionFactory.Create(model, item, _userId, header);
            _repository.Edit(item);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task<PermissionDto> GetDetailAsync(int id,int header)
        {
            return await _repository.GetDetailAsync(id,header);
        }

        public async Task<PermissionDto> GetDetailByScreenAsync(int id, int header)
        {
            return await _repository.GetScreenDetailAsync(id, header);
        }

        public async Task<List<PermissionDto>> GetAllAsync(int header)
        {
            return await _repository.GetAllAsync(header);
        }

        public async Task DeleteAsync(int id, int header)
        {
            await _repository.DeleteAsync(id, header);
            await _unitOfWork.SaveChangesAsync();
        }
    }
}
