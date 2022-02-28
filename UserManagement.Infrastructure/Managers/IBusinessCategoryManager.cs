using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using UserManagement.Dtos.Business;
using UserManagement.Models.Business;

namespace UserManagement.Infrastructure.Managers
{
    public interface IBusinessCategoryManager
    {
        Task AddAsync(BusinessCategoryAddModel model);
        Task<List<BusinessCategoryDetailDto>> GetAllAsync();
        Task<BusinessCategoryDetailDto> GetByIdAsync(int id);
        Task Delete(int id);
    }
}
