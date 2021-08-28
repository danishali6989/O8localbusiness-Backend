using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using UserManagement.Dtos.Field;
using UserManagement.Models.Field;
using UserManagement.Utilities;

namespace UserManagement.Infrastructure.Managers
{
   public interface IFieldManager
    {
        Task AddAsync(FieldsAddModel model);
        Task EditAsync(FieldEditModel model);
        Task<FieldDto> GetDetailAsync(int id);
        Task<List<FieldDetailDto>> GetFieldDetailAsync(int lang_id,int screen_id);
        Task<List<FieldDetailDto>> GetFieldDetailByLanguageAsync(int lang_id);
        Task<List<FieldDto>> GetAllAsync();
       Task<JqDataTableResponse<FieldDto>> GetPagedResultAsync(JqDataTableRequest model);
        Task DeleteAsync(int id);
    }
}
