using UserManagement.Dtos.FormBuilderType;
using UserManagement.Models.FormBuilder;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace UserManagement.Infrastructure.Managers
{
    public  interface IFormBuilderTypeManager
    {
        Task AddAsync(FormBuilderTypeAddModel model);
        Task<List<FormBuilderTypeDetailDto>> GetAll();
    }
}
