using UserManagement.Dtos.FormBuilderType;
using UserManagement.Entities;
using UserManagement.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using System.Linq.Dynamic.Core;
using Microsoft.EntityFrameworkCore;


namespace UserManagement.DataLayer.Repositories
{
    public class FormBuilderTypeRepository : IFormBuilderTypeRepository
    {
        private readonly DataContext _dataContext;
        public FormBuilderTypeRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task AddAsync(FormBuilderType entity)
        {
            await _dataContext.FormBuilderTypes.AddAsync(entity);
        }
        
      
        public async Task<List<FormBuilderTypeDetailDto>> GetAll()
        {
            return await (from s in _dataContext.FormBuilderTypes
                         
                          select new FormBuilderTypeDetailDto
                          {
                              Id = s.Id,
                              TypeName = s.TypeName,
                              Status = s.Status,
                              CreatedBy = s.CreatedBy,
                              CreatedOn = s.CreatedOn,
                              UpdatedOn = s.UpdatedOn,
                              UpdatedBy = s.UpdatedBy,

                          })
                        .AsNoTracking()
                        .ToListAsync();

        }
    }
}
