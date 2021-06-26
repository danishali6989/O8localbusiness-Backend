using UserManagement.Dtos.UserLogin;
using UserManagement.Models.UserLogin;
using UserManagement.Models.User;

using UserManagement.Utilities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using UserManagement.Dtos.User;

namespace UserManagement.Infrastructure.Managers
{
    public interface IUserManager
    {
        Task AddAsync(AddUserModel model);
        Task LoginAddAsync(UserDetailDto model);
        Task EditAsync(EditUserModel model);
        Task EditImgAsync(EditImgModel model);

        //Task<List<AssignUserRoleDto>> GetAssignUserRoleById(int id);


        Task<UserDetailDto> GetDetailAsync(int id);

        Task<JqDataTableResponse<UserDetailDto>> GetPagedResultAsync(JqDataTableRequest model);
        Task DeleteAsync(int id);
        Task<UserDetailDto> CheckUser(string username);
        bool UserAllReadyLogin(int userid);

        Task<UserDetailDto> Login(UserLoginModel model);
       // Task<JqDataTableResponse<UserDetailDto>> GetAgentPagedResultAsync(JqDataTableRequest model);
        Task LogOut(int id);
        Task<UserDetailDto> isExist(string email);
        Task saveOtp(string email, int otp);
        Task<UserDetailDto> getOtp(string email);

        Task changePassword(string email, string password);

        Task<List<UserDetailDto>> GetAllAsync();
/*        Task<IEnumerable<UserDetailDto>> OnlineUserPagedResult(Constants.RecordStatus? status = null);
*/
        Task<JqDataTableResponse<UserDetailDto>> OnlineUserPagedResult(JqDataTableRequest model);
        //  Task<JqDataTableResponse<UserDetailDto>> GetOnlyOnlineAgentPagedResultAsync(JqDataTableRequest model);
    }
}
