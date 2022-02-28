using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using UserManagement.Dtos.Business;
using UserManagement.Models.Business;

namespace UserManagement.Infrastructure.Managers
{
    public interface IBusinessSubCategoryManager
    {
        Task AddAsync(BusinessSubCategoryAddModel model);
        Task<List<BusinessSubCategoryDetailDto>> GetAllAsync();
        Task<BusinessSubCategoryDetailDto> GetByIdAsync(int id);
        Task Delete(int id);
    }
}
