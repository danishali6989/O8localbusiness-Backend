using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using UserManagement.Dtos.Business;
using UserManagement.Entities;

namespace UserManagement.Infrastructure.Repositories
{
    public interface IBusinessSubCategoryRepository
    {
        Task AddAsync(BusinessSubCategory entity);
        Task<List<BusinessSubCategoryDetailDto>> GetAll();
        Task<BusinessSubCategoryDetailDto> GetById(int id);
        Task DeleteAsync(int id);
    }
}
