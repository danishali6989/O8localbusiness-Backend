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
using Microsoft.Extensions.DependencyInjection;

namespace UserManagement.DataLayer.Repositories
{
    public class ScreenRepository : IScreenRepository
    {
        private readonly DataContext _dataContext;

        public ScreenRepository(DataContext dataContext, IServiceProvider serviceProvider)
        {
            //_dataContext = dataContext;
            _dataContext = serviceProvider.CreateScope().ServiceProvider.GetRequiredService<DataContext>();

        }

        public async Task AddAsync(ScreenDetail entity)
        {
            await _dataContext.ScreenDetail.AddAsync(entity);
            await _dataContext.SaveChangesAsync();
        }

        public void Edit(ScreenDetail entity)
        {
            _dataContext.ScreenDetail.Update(entity);
            _dataContext.SaveChanges();

        }

        public async Task<ScreenDetail> GetAsync(int id, int header)
        {
            return await _dataContext.ScreenDetail.FindAsync(id);
        }

        public async Task<ScreenDto> GetDetailAsync(int id, int header)
        {
            return await (from s in _dataContext.ScreenDetail
                          where s.Id == id && s.CompanyId == header
                          select new ScreenDto
                          {
                              Id = s.Id,
                              ScreenName=s.ScreenName,
                              ScreenCode=s.ScreenCode,
                              CompanyId=s.CompanyId,
                              ScreenUrl=s.ScreenUrl,
                              Status=s.Status
                              
                           

                          })
                          .AsNoTracking()
                          .SingleOrDefaultAsync();
        }
        public async Task<List<ScreenDto>> GetAllAsync(int header)
        {
            return await (from s in _dataContext.ScreenDetail
                          where s.CompanyId == header
                          select new ScreenDto
                          {
                              Id=s.Id,
                              ScreenName = s.ScreenName,
                              ScreenCode = s.ScreenCode,
                              CompanyId = s.CompanyId,
                              ScreenUrl=s.ScreenUrl,
                              Status=s.Status

                          })
                          .AsNoTracking()
                          .ToListAsync();
        }

        public async Task<JqDataTableResponse<ScreenDto>> GetPagedResultAsync(JqDataTableRequest model, int header)
        {
            if (model.Length == 0)
            {
                model.Length = Constants.DefaultPageSize;
            }

            var filterKey = model.Search.Value;

            var linqStmt = (from s in _dataContext.ScreenDetail
                            where s.Status != Constants.RecordStatus.Deleted && (filterKey == null || EF.Functions.Like(s.ScreenName, "%" + filterKey + "%")) && s.CompanyId == header
                            select new ScreenDto
                            {
                                Id = s.Id,
                                ScreenCode=s.ScreenCode,
                                ScreenName=s.ScreenName,
                                CompanyId=s.CompanyId,
                                ScreenUrl=s.ScreenUrl,
                                Status=s.Status
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
        
        public async Task DeleteAsync(int id, int header)
        {
            var data = await _dataContext.ScreenDetail.FindAsync(id);
            data.Status = Constants.RecordStatus.Deleted;
            _dataContext.ScreenDetail.Update(data);
            await _dataContext.SaveChangesAsync();
        }
    }
}
