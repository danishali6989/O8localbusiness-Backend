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
using Microsoft.Extensions.DependencyInjection;

namespace UserManagement.DataLayer.Repositories
{
    public class UserRoleRepository:IUserRoleRepository
    {
        private readonly DataContext _dataContext;

        public UserRoleRepository(DataContext dataContext,IServiceProvider serviceProvider)
        {
            //_dataContext = dataContext;
            _dataContext = serviceProvider.CreateScope().ServiceProvider.GetRequiredService<DataContext>();

        }

        public async Task AddAsync(UserRole entity)
        {
            await _dataContext.UsersRoles.AddAsync(entity);
            await _dataContext.SaveChangesAsync();
        }

        public void Edit(UserRole entity)
        {
            _dataContext.UsersRoles.Update(entity);
            _dataContext.SaveChanges();
        }

        public async Task<UserRole> GetAsync(int id, int header)
        {
            return await _dataContext.UsersRoles.FindAsync(id);
        }

        public async Task<UserRoleDetailDto> GetDetailAsync(int id, int header)
        {
            return await (from s in _dataContext.UsersRoles
                          join s1 in _dataContext.ScreenDetail on s.Id equals s1.Id
                          where s.Id == id && s.CompanyId == header
                          select new UserRoleDetailDto
                          {
                              Id = s.Id,
                              RoleName = s.RoleName,
                              CompanyId=s.CompanyId,
                              Status=s.Status,
                              ScreenName=s1.ScreenName,
                              ScreenId=s1.Id
                              
                          })
                          .AsNoTracking()
                          .SingleOrDefaultAsync();
        }
        public async Task<List<UserRoleDetailDto>> GetAllAsync(int header)
        {
            return await (from s in _dataContext.UsersRoles
                        
                          where s.CompanyId == header
                          select new UserRoleDetailDto
                          {
                            
                             RoleName=s.RoleName,
                             Id=s.Id,
                              CompanyId=s.CompanyId,
                              Status=s.Status
                              
                             
                          })
                          .AsNoTracking()
                          .ToListAsync();
        }

        public async Task<JqDataTableResponse<UserRoleDetailDto>> GetPagedResultAsync(JqDataTableRequest model, int header)
        {
            if (model.Length == 0)
            {
                model.Length = Constants.DefaultPageSize;
            }

            var filterKey = model.Search.Value;

            var linqStmt = (from s in _dataContext.UsersRoles
                            where s.Status != Constants.RecordStatus.Deleted && (filterKey == null || EF.Functions.Like(s.RoleName, "%" + filterKey + "%")) && s.CompanyId == header
                            select new UserRoleDetailDto
                            {
                                Id = s.Id,
                                RoleName = s.RoleName,
                                CompanyId=s.CompanyId,
                                Status=s.Status
                                
                            })
                            .AsNoTracking();

            var sortExpresstion = model.GetSortExpression();

            var pagedResult = new JqDataTableResponse<UserRoleDetailDto>
            {
                RecordsTotal = await _dataContext.UsersRoles.CountAsync(x => x.Status != Constants.RecordStatus.Deleted),
                RecordsFiltered = await linqStmt.CountAsync(),
                Data = await linqStmt.OrderBy(sortExpresstion).Skip(model.Start).Take(model.Length).ToListAsync()
            };
            return pagedResult;
        }
        public bool UpdateRoleId(int roleId, int userId, string header)
        {
            try
            {
                var user = _dataContext.User.Where(x => x.Id == userId).FirstOrDefault();
                user.RoleId = roleId;
                _dataContext.User.Update(user);
                _dataContext.SaveChanges();
                return true;

            }
            catch (Exception ex)
            {
                //throw ex;
                return false;
            }

        }
        public async Task DeleteAsync(int id, int header)
        {
            var data = await _dataContext.UsersRoles.FindAsync(id);
            data.Status = Constants.RecordStatus.Deleted;
            _dataContext.UsersRoles.Update(data);
            await _dataContext.SaveChangesAsync();
        }
    }
}
