using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using UserManagement.Dtos.Form;
using UserManagement.Entities;

namespace UserManagement.Infrastructure.Repositories
{
    public interface IFormFieldValueRepository
    {
        Task AddAsync(FormFieldValue entity);
        // Task AddFormCommonFieldValue(Form entity);
        Task<List<FormWithValueDetailDto>> GetFormDetailByFormId(int FormId);
        Task<List<FormFieldWithValueDetailDto>> GetFormFieldData(int FormId);
        Task<List<FormFieldValues>> GetFormFieldVal(int FormId);
    }
}
