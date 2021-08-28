using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using UserManagement.Dtos.EmailSetting;
using UserManagement.Dtos.Languages;
using UserManagement.Models.EmailSetting;
using UserManagement.Models.Languages;
using UserManagement.Utilities;

namespace UserManagement.Infrastructure.Managers
{
     public interface IEmailSettingManager
    {
        Task AddAsync(EmailSettingAddModel model, string header);

        Task EditAsync(EmailSettingEditModel model,string header);
        Task<EmailSettingDto> GetDetailAsync(int id,int header);

        Task<List<EmailSettingDto>> GetAllAsync(int header);

        Task DeleteAsync(int id,int header);
    }
}
