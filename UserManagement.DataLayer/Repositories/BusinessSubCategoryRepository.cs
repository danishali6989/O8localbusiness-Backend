using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using UserManagement.Dtos.Business;
using UserManagement.Entities;
using UserManagement.Infrastructure.Repositories;
using UserManagement.Utilities;
using System.Linq;
using System.Linq.Dynamic.Core;
using Microsoft.EntityFrameworkCore;

namespace UserManagement.DataLayer.Repositories
{
    public class BusinessSubCategoryRepository : IBusinessSubCategoryRepository
    {
        private readonly DataContext _dataContext;
        public BusinessSubCategoryRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
        public async Task AddAsync(BusinessSubCategory entity)
        {
            await _dataContext.BusinessSubCategory.AddAsync(entity);
            await _dataContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var item = await _dataContext.BusinessSubCategory.FindAsync(id);
            item.Status = Constants.RecordStatus.Deleted;
            _dataContext.BusinessSubCategory.Update(item);
            await _dataContext.SaveChangesAsync();

        }
        public async Task<List<BusinessSubCategoryDetailDto>> GetAll()
        {
            return await (from s in _dataContext.BusinessSubCategory
                          select new BusinessSubCategoryDetailDto
                          {
                              Id = s.Id,
                              BusinessCategoryId = s.BusinessCategoryId,
                              BusinessSubCategoryName = s.BusinessSubCategoryName,
                              Status = s.Status,
                              CreatedBy = s.CreatedBy,
                              CreatedOn = s.CreatedOn,
                              UpdatedBy = s.UpdatedBy,
                              UpdatedOn = s.UpdatedOn
                          }).AsNoTracking().ToListAsync();
        }
        public async Task<BusinessSubCategoryDetailDto> GetById(int id)
        {
            return await (from s in _dataContext.BusinessSubCategory
                          where s.Id == id
                          select new BusinessSubCategoryDetailDto
                          {
                              Id = s.Id,
                              BusinessCategoryId = s.BusinessCategoryId,
                              BusinessSubCategoryName = s.BusinessSubCategoryName,
                              Status = s.Status,
                              CreatedBy = s.CreatedBy,
                              CreatedOn = s.CreatedOn,
                              UpdatedBy = s.UpdatedBy,
                              UpdatedOn = s.UpdatedOn
                          }).AsNoTracking().SingleOrDefaultAsync();
        }
    }
}
