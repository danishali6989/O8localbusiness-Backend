using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using UserManagement.Dtos.Languages;
using UserManagement.Models.Languages;
using UserManagement.Utilities;

namespace UserManagement.Infrastructure.Managers
{
  public  interface ILanguagesManager
    {
        Task AddAsync(LanguagesAddModel model);
        Task EditAsync(LanguagesEditModel model);

        Task UpdateAsync(LanguagesUpdateModel model);

        Task<LanguagesDto> GetDetailAsync(int id);

        Task<List<LanguagesDto>> GetAllAsync();

        Task<JqDataTableResponse<LanguagesDto>> GetPagedResultAsync(JqDataTableRequest model);
        Task DeleteAsync(int id);

    }
}
