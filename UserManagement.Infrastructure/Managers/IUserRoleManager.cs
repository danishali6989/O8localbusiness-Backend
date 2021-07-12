using UserManagement.Dtos;
using UserManagement.Dtos.UserLogin;
using UserManagement.Models.UserLogin;
using UserManagement.Utilities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace UserManagement.Infrastructure.Managers
{
    public interface IUserRoleManager
    {
        Task AddAsync(UserRoleModel model, string header);

        Task EditAsync(UserRoleModel model, string header);

        Task<UserRoleDetailDto> GetDetailAsync(int id, int header);

        Task<JqDataTableResponse<UserRoleDetailDto>> GetPagedResultAsync(JqDataTableRequest model, int header);
        Task DeleteAsync(int id, int header);
        Task<List<UserRoleDetailDto>> GetAllAsync(int header);
        bool UpdateRoleId(int roleId, int userId, string header);

    }
}
