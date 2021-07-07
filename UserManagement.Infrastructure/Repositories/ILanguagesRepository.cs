using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using UserManagement.Dtos.Languages;
using UserManagement.Entities;
using UserManagement.Utilities;

namespace UserManagement.Infrastructure.Repositories
{
   public interface ILanguagesRepository
    {
        Task AddAsync(Languages entity);

        void Edit(Languages entity);

        Task<Languages> GetAsync(int id);

        Task<LanguagesDto> GetDetailAsync(int id);

        Task<List<LanguagesDto>> GetAllAsync();

        Task<JqDataTableResponse<LanguagesDto>> GetPagedResultAsync(JqDataTableRequest model);

        Task DeleteAsync(int id);

    }
}
