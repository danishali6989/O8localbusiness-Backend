using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using UserManagement.Dtos.RolePermission;
using UserManagement.Entities;
using UserManagement.Factories;
using UserManagement.Infrastructure.DataLayer;
using UserManagement.Infrastructure.Managers;
using UserManagement.Infrastructure.Repositories;
using UserManagement.Models.RolePermission;
using UserManagement.Utilities;

namespace UserManagement.Managers
{
    public class RolePermiManager:IRolePermiManager
    {
        private readonly IRolePermiRepository _repository;
        private readonly IUnitOfWork _unitOfWork;

        private readonly string _userId;

        public RolePermiManager(IHttpContextAccessor contextAccessor,
          IRolePermiRepository repository,
          IUnitOfWork unitOfWork)
        {
            _userId = contextAccessor.HttpContext.User.GetUserId();

            _repository = repository;
            _unitOfWork = unitOfWork;
        }

        public async Task AddAsync(AddRolePermission model, string header)
        {
            await _repository.AddAsync(RolePermiFactory.Create(model, _userId, header));
            await _unitOfWork.SaveChangesAsync();
        }

       

        public async Task DeleteAsync(int id, int header)
        {
            await _repository.DeleteAsync(id, header);
            await _unitOfWork.SaveChangesAsync();
        }
        public async Task DeleteAsync2(int id)
        {
            await _repository.DeleteAsync1(id);
            await _unitOfWork.SaveChangesAsync();
        }

        public  RolePermissionDto isExist(AddRolePermission id)
        {
            try
            {
                return  _repository.isExist(id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
