using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using UserManagement.Dtos.RolePermission;
using UserManagement.Entities;
using UserManagement.Models.RolePermission;

namespace UserManagement.Infrastructure.Repositories
{
    public interface IRolePermiRepository
    {
       
        Task AddAsync(RolePermi entity);
        Task DeleteAsync(int id, int header);
        Task DeleteAsync1(int id);

        RolePermissionDto isExist(AddRolePermission id);
    }
}
