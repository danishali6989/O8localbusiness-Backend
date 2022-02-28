using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using UserManagement.Dtos.RolePermission;
using UserManagement.Models.RolePermission;

namespace UserManagement.Infrastructure.Managers
{
   public interface IRolePermiManager
    {
       
            Task AddAsync(AddRolePermission model, string header);
            Task DeleteAsync(int id, int header);
            Task DeleteAsync2(int id);
            RolePermissionDto isExist(AddRolePermission id);
        
    }
}
