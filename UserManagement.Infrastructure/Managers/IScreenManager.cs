using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using UserManagement.Dtos;
using UserManagement.Dtos.Screen;
using UserManagement.Models.Screen;
using UserManagement.Utilities;

namespace UserManagement.Infrastructure.Managers
{
   public interface I1ScreenManager
    {
        Task AddAsync(ScreenAddModel model);
        Task EditAsync(ScreenEditModel model);
        Task<ScreenDto> GetDetailAsync(int id);
        Task<List<ScreenDto>> GetAllAsync();

        Task<JqDataTableResponse<ScreenDto>> GetPagedResultAsync(JqDataTableRequest model);
        Task DeleteAsync(int id);




    }
}
