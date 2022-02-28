using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using UserManagement.Dtos.Form;
using UserManagement.Models.FormBuilder;

namespace UserManagement.Infrastructure.Managers
{
    public interface IFormFieldValueManager
    {
        Task AddAsync(FormValue model);
        // Task AddFormCommonFieldValueAsync(FormFieldValueAddModel model);
        Task<List<FormWithValueDetailDto>> GetFormDetailByFormId(int FormId);
    }
}
