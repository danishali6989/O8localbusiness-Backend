using UserManagement.Dtos.FormBuilderType;
using UserManagement.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;


namespace UserManagement.Infrastructure.Repositories
{
    public interface IFormBuilderTypeRepository
    {
        Task AddAsync(FormBuilderType entity);
        Task<List<FormBuilderTypeDetailDto>> GetAll();

    }
}
