using UserManagement.Dtos.UserLogin;
using UserManagement.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using System.Linq.Dynamic.Core;
using Microsoft.EntityFrameworkCore;
using UserManagement.Utilities;
using UserManagement.Infrastructure.Repositories;
using UserManagement.Models.UserLogin;
using UserManagement.Dtos.Field;
using Microsoft.Extensions.DependencyInjection;

namespace UserManagement.DataLayer.Repositories
{
    public class FieldRepository:IFieldRepository
    {
        private readonly DataContext _dataContext;

        public FieldRepository(DataContext dataContext,IServiceProvider serviceProvider)
        {
            // _dataContext = dataContext;
            _dataContext = serviceProvider.CreateScope().ServiceProvider.GetRequiredService<DataContext>();

        }
        public async Task AddAsync(Field entity)
        {
            await _dataContext.Field.AddAsync(entity);
            await _dataContext.SaveChangesAsync();
        }

        public void Edit(Field entity)
        {
            _dataContext.Field.Update(entity);
            _dataContext.SaveChanges();
        }

        public async Task<FieldDto> GetDetailAsync(int id)
        {
            return await (from s in _dataContext.Field
                          where s.id == id 
                          select new FieldDto
                          {
                              lang_id = s.lang_id,
                              screen_id = s.screen_id,
                              description = s.description,
                              field = s.field,
                              Status = s.Status

                          })
                          .AsNoTracking()
                          .SingleOrDefaultAsync();
        }
     
        public async Task<List<FieldDetailDto>> GetFieldDetailAsync(int lang_id,int screen_id)
        {
            return await (from s in _dataContext.Field
                          where s.screen_id == screen_id && s.lang_id ==lang_id

                          select new FieldDetailDto
                          {
                              lang_id = s.lang_id,
                              screen_id = s.screen_id,
                              description = s.description,
                              field = s.field,
                             

                          })
                          .AsNoTracking()
                          .ToListAsync();
        }

        public async Task<List<FieldDetailDto>> GetFieldDetailByLanguageAsync(int lang_id)
        {
            return await (from s in _dataContext.Field
                          where s.lang_id == lang_id && s.Status != Constants.RecordStatus.Deleted

                          select new FieldDetailDto
                          {
                              lang_id = s.lang_id,
                              screen_id = s.screen_id,
                              description = s.description,
                              field = s.field,


                          })
                          .AsNoTracking()
                          .ToListAsync();
        }

        public async Task<List<FieldDto>> GetAllAsync()
        {
            return await (from s in _dataContext.Field

                          select new FieldDto
                          {
                              lang_id = s.lang_id,
                              screen_id = s.screen_id,
                              description = s.description,
                              field = s.field,
                              Status=s.Status

                          })
                          .AsNoTracking()
                          .ToListAsync();
        }

        public async Task<Field> GetAsync(int id)
        {
            return await _dataContext.Field.FindAsync(id);
        }

        public async Task<JqDataTableResponse<FieldDto>> GetPagedResultAsync(JqDataTableRequest model)
        {
            if (model.Length == 0)
            {
                model.Length = Constants.DefaultPageSize;
            }

            var filterKey = model.Search.Value;

            var linqStmt = (from s in _dataContext.Field
                            where s.Status != Constants.RecordStatus.Deleted && (filterKey == null || EF.Functions.Like(s.field, "%" + filterKey + "%"))
                            select new FieldDto
                            {
                                lang_id = s.lang_id,
                                field = s.field,
                                description = s.description,
                                
                            })
                            .AsNoTracking();

            var sortExpresstion = model.GetSortExpression();

            var pagedResult = new JqDataTableResponse<FieldDto>
            {
                RecordsTotal = await _dataContext.UsersRoles.CountAsync(x => x.Status != Constants.RecordStatus.Deleted),
                RecordsFiltered = await linqStmt.CountAsync(),
                Data = await linqStmt.OrderBy(sortExpresstion).Skip(model.Start).Take(model.Length).ToListAsync()
            };
            return pagedResult;
        }

        public async Task DeleteAsync(int id)
        {
            var data = await _dataContext.Field.FindAsync(id);
            data.Status = Constants.RecordStatus.Deleted;
            _dataContext.Field.Update(data);
            await _dataContext.SaveChangesAsync();
        }
    }
}
