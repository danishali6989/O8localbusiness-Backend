using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using UserManagement.Dtos.Business;
using UserManagement.Entities;
using UserManagement.Infrastructure.Repositories;
using System.Linq;
using System.Linq.Dynamic.Core;
using Microsoft.EntityFrameworkCore;
using UserManagement.Utilities;

namespace UserManagement.DataLayer.Repositories
{
    public class BusinessCategoryRepository : IBusinessCategoryRepository
    {
        private readonly DataContext _dataContext;
        public BusinessCategoryRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task AddAsync(BusinessCategory entity )
        {
            await _dataContext.BusinessCategory.AddAsync(entity);
            await _dataContext.SaveChangesAsync();
        }
        public async Task DeleteAsync(int id)
        {
            var item = await _dataContext.BusinessCategory.FindAsync(id);
            item.Status = Constants.RecordStatus.Deleted;
            _dataContext.BusinessCategory.Update(item);
            await _dataContext.SaveChangesAsync();
        }
        public async Task<List<BusinessCategoryDetailDto>> GetAll()
        {
            return await (from s in _dataContext.BusinessCategory
                          select new BusinessCategoryDetailDto
                          { 
                              Id = s.Id,
                              BusinessCategoryName = s.BusinessCategoryName,
                              Status = s.Status,
                              CreatedBy = s.CreatedBy,
                              CreatedOn = s.CreatedOn,
                              UpdatedBy = s.UpdatedBy,
                              UpdatedOn = s.UpdatedOn
                          }).AsNoTracking().ToListAsync();
        }
        public async Task<BusinessCategoryDetailDto> GetById(int id)
        {
           return await (from s in _dataContext.BusinessCategory
                         where s.Id == id
                         select new BusinessCategoryDetailDto 
                         { 
                             Id = s.Id,
                             BusinessCategoryName = s.BusinessCategoryName,
                             Status = s.Status,
                             CreatedBy = s.CreatedBy,
                             CreatedOn = s.CreatedOn,
                             UpdatedBy = s.UpdatedBy,
                             UpdatedOn = s.UpdatedOn
                         }).AsNoTracking().SingleOrDefaultAsync();
        }  
      
    }
}
