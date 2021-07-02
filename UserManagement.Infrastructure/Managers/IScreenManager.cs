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
        Task AddAsync(ScreenAddModel model, string header);
        Task EditAsync(ScreenEditModel model, string header);
        Task<ScreenDto> GetDetailAsync(int id, int header);
        Task<List<ScreenDto>> GetAllAsync(int header);

        Task<JqDataTableResponse<ScreenDto>> GetPagedResultAsync(JqDataTableRequest model, int header);
        Task DeleteAsync(int id, int header);




    }
}
