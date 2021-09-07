using UserManagement.Dtos.UserAccess;
using UserManagement.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using UserManagement.Dtos.RolePermission;

namespace UserManagement.Infrastructure.Repositories
{
    public interface IUserAccessRepository
    {
        Task AddUserScreenAccessAsync(List<UserScreenAccess> entity);
        Task<List<ScreenAccessDto>> GetAsyncUserScreenAccess(int id, int header);
        Task<List<RolePermissionDto>> GetAsyncUserPermissionAccess(int id, int header);
        Task DeleteAsyncUserScreenAccess(int id);
        Task<List<ScreendetailDto>> GetAllScreenDetail(int header);
        Task<List<ScreendetailDto>> GetAllScreen();


    }
}
