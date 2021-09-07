using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using UserManagement.Dtos.Permission;
using UserManagement.Models.Permission;

namespace UserManagement.Infrastructure.Managers
{
    public interface IPermiManager
    {
        Task AddAsync(PermissionAddModel model, string header);
        Task EditAsync(PermissionEditModel model, string header);

        Task<PermissionDto> GetDetailAsync(int id, int header);
        Task<PermissionDto> GetDetailByScreenAsync(int id, int header);

        Task<List<PermissionDto>> GetAllAsync(int header);

        Task DeleteAsync(int id, int header);
    }
}
