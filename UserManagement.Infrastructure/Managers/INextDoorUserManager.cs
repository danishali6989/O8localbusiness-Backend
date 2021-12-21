using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using UserManagement.Dtos.NextDoorUser;
using UserManagement.Models.NextDoorUser;

namespace UserManagement.Infrastructure.Managers
{
   public interface INextDoorUserManager
    {
        Task AddAsync(AddNextDoorUserModel model);
        Task<NextDoorUserDto> CheckNextDoorUserEmail(string Email);

        Task DeleteAsync(int id);
        Task<List<NextDoorUserDto>> GetAllAsync();

        Task<NextDoorUserDto> CheckUser(string email);
        
    }
}
