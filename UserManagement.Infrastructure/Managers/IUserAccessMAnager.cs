using UserManagement.Dtos.UserAccess;
using UserManagement.Models.UserAccess;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using UserManagement.Dtos.RolePermission;

namespace UserManagement.Infrastructure.Managers
{
    public interface IUserAccessMAnager
    {
        Task AddUserScreenAccessAsync(ScreenAccessModel model, string header);
        Task<List<ScreenAccessDto>> GetUserScreenAccessById(int id, int header);
        Task<List<RolePermissionDto>> GetUserPermissionAccessById(int id, int header);
        Task<List<ScreendetailDto>> GetAllScreenDetail(int header);
    }
}
