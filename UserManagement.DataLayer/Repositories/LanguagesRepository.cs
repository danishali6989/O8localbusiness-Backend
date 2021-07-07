/*using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using UserManagement.Dtos.Languages;
using UserManagement.Entities;
using UserManagement.Infrastructure.Repositories;*/

using UserManagement.Dtos.UserLogin;
using UserManagement.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using System.Linq.Dynamic.Core;
using UserManagement.Utilities;
using Microsoft.EntityFrameworkCore;
using UserManagement.Infrastructure.Repositories;
using UserManagement.Dtos;
using UserManagement.Dtos.Screen;
using UserManagement.Dtos.Languages;

namespace UserManagement.DataLayer.Repositories
{
  public  class LanguagesRepository : ILanguagesRepository
    {
        private readonly DataContext _dataContext;

        public LanguagesRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
        public async Task AddAsync(Languages entity)
        {
            await _dataContext.Languages.AddAsync(entity);
        }

        public void Edit(Languages entity)
        {
            _dataContext.Languages.Update(entity);
        }
        public async Task<Languages> GetAsync(int id)
        {
            return await _dataContext.Languages.FindAsync(id);
        }
        public async Task<LanguagesDto> GetDetailAsync(int id)
        {
            return await(from s in _dataContext.Languages
                          where s.lang_id == id
                          select new LanguagesDto
                          {
                             lang_name=s.lang_name,
                             lang_orientation=s.lang_orientation,
                              Status = s.Status

                          })
                          .AsNoTracking()
                          .SingleOrDefaultAsync();
        }
        public async Task<List<LanguagesDto>> GetAllAsync()
        {
            return await (from s in _dataContext.Languages
                          
                          select new LanguagesDto
                          {
                              lang_name = s.lang_name,
                              lang_orientation = s.lang_orientation,
                              Status = s.Status

                          })
                          .AsNoTracking()
                          .ToListAsync();
        }

        public async Task<JqDataTableResponse<LanguagesDto>> GetPagedResultAsync(JqDataTableRequest model)
        {
            if (model.Length == 0)
            {
                model.Length = Constants.DefaultPageSize;
            }

            var filterKey = model.Search.Value;

            var linqStmt = (from s in _dataContext.Languages
                            where s.Status != Constants.RecordStatus.Deleted && (filterKey == null || EF.Functions.Like(s.lang_name, "%" + filterKey + "%"))
                            select new LanguagesDto
                            {
                                lang_name = s.lang_name,
                                lang_orientation = s.lang_orientation,
                                Status = s.Status
                            })
                            .AsNoTracking();

            var sortExpresstion = model.GetSortExpression();

            var pagedResult = new JqDataTableResponse<LanguagesDto>
            {
                RecordsTotal = await _dataContext.UsersRoles.CountAsync(x => x.Status != Constants.RecordStatus.Deleted),
                RecordsFiltered = await linqStmt.CountAsync(),
                Data = await linqStmt.OrderBy(sortExpresstion).Skip(model.Start).Take(model.Length).ToListAsync()
            };
            return pagedResult;
        }

        public async Task DeleteAsync(int id)
        {
            var data = await _dataContext.Languages.FindAsync(id);
            data.Status = Constants.RecordStatus.Deleted;
            _dataContext.Languages.Update(data);
        }
    }
}
