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
        Task AddAsync(AddUserModel model, string header);
        Task LoginAddAsync(UserDetailDto model);
        Task EditAsync(EditUserModel model, string header);
        Task EditImgAsync(EditImgModel model, string header);

        //Task<List<AssignUserRoleDto>> GetAssignUserRoleById(int id);
        Task<UserDetailDto> CheckEmail(string Email);


        Task<UserDetailDto> GetDetailAsync(int id, int header);

        Task<JqDataTableResponse<UserDetailDto>> GetPagedResultAsync(JqDataTableRequest model, int header);
        Task DeleteAsync(int id, int header);
        Task<UserDetailDto> CheckUser(string username);
        bool UserAllReadyLogin(int userid);

        Task<UserDetailDto> Login(UserLoginModel model);
        // Task<JqDataTableResponse<UserDetailDto>> GetAgentPagedResultAsync(JqDataTableRequest model);
        Task LogOut(int id, int header);
        Task<UserDetailDto> isExist(string email);
        Task saveOtp(string email, int otp);
        Task<UserDetailDto> getOtp(string email);

        Task changePassword(string email, string password);
        Task UpdateStatus(UserStatus model, string header);


        Task<List<UserDetailDto>> GetAllAsync(int header);
        /*        Task<IEnumerable<UserDetailDto>> OnlineUserPagedResult(Constants.RecordStatus? status = null);
        */
        Task<JqDataTableResponse<UserDetailDto>> OnlineUserPagedResult(JqDataTableRequest model, int header);
        bool CheckPassword(int adminid, string adminPassword);
        Task ChangePasswordAdmin(ChangePasswordModel model);

        //  Task<JqDataTableResponse<UserDetailDto>> GetOnlyOnlineAgentPagedResultAsync(JqDataTableRequest model);
    }

}
