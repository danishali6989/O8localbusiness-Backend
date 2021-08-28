using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using UserManagement.Dtos.Field;
using UserManagement.Entities;
using UserManagement.Utilities;

namespace UserManagement.Infrastructure.Repositories
{
   public interface IFieldRepository
    {
        Task AddAsync(Field entity);
        void Edit(Field entity);
       

        Task<Field> GetAsync(int id);
        Task<FieldDto> GetDetailAsync(int id);
        Task<List<FieldDetailDto>> GetFieldDetailAsync(int lang_id,int screen_id);
        Task<List<FieldDetailDto>> GetFieldDetailByLanguageAsync(int lang_id);
        Task<List<FieldDto>> GetAllAsync();
        Task<JqDataTableResponse<FieldDto>> GetPagedResultAsync(JqDataTableRequest model);
        Task DeleteAsync(int id);
    }
}
