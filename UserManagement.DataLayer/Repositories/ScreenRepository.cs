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

namespace UserManagement.DataLayer.Repositories
{
    public class ScreenRepository : IScreenRepository
    {
        private readonly DataContext _dataContext;

        public ScreenRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task AddAsync(ScreenDetail entity)
        {
            await _dataContext.ScreenDetail.AddAsync(entity);
        }

        public void Edit(ScreenDetail entity)
        {
            _dataContext.ScreenDetail.Update(entity);
        }

        public async Task<ScreenDetail> GetAsync(int id)
        {
            return await _dataContext.ScreenDetail.FindAsync(id);
        }

        public async Task<ScreenDto> GetDetailAsync(int id)
        {
            return await (from s in _dataContext.ScreenDetail
                          where s.Id == id
                          select new ScreenDto
                          {
                              Id = s.Id,
                              ScreenName=s.ScreenName,
                              ScreenCode=s.ScreenCode
                          })
                          .AsNoTracking()
                          .SingleOrDefaultAsync();
        }
        public async Task<List<ScreenDto>> GetAllAsync()
        {
            return await (from s in _dataContext.ScreenDetail
                          select new ScreenDto
                          {
                              Id=s.Id,
                              ScreenName = s.ScreenName,
                              ScreenCode = s.ScreenCode
                          })
                          .AsNoTracking()
                          .ToListAsync();
        }

        public async Task<JqDataTableResponse<ScreenDto>> GetPagedResultAsync(JqDataTableRequest model)
        {
            if (model.Length == 0)
            {
                model.Length = Constants.DefaultPageSize;
            }

            var filterKey = model.Search.Value;

            var linqStmt = (from s in _dataContext.ScreenDetail
                            where s.Status != Constants.RecordStatus.Deleted && (filterKey == null || EF.Functions.Like(s.ScreenName, "%" + filterKey + "%"))
                            select new ScreenDto
                            {
                                Id = s.Id,
                                ScreenCode=s.ScreenCode,
                                ScreenName=s.ScreenName
                            })
                            .AsNoTracking();

            var sortExpresstion = model.GetSortExpression();

            var pagedResult = new JqDataTableResponse<ScreenDto>
            {
                RecordsTotal = await _dataContext.UsersRoles.CountAsync(x => x.Status != Constants.RecordStatus.Deleted),
                RecordsFiltered = await linqStmt.CountAsync(),
                Data = await linqStmt.OrderBy(sortExpresstion).Skip(model.Start).Take(model.Length).ToListAsync()
            };
            return pagedResult;
        }
        
        public async Task DeleteAsync(int id)
        {
            var data = await _dataContext.ScreenDetail.FindAsync(id);
            data.Status = Constants.RecordStatus.Deleted;
            _dataContext.ScreenDetail.Update(data);
        }
    }
}
