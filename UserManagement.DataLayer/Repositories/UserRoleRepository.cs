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

namespace UserManagement.DataLayer.Repositories
{
    public class UserRoleRepository:IUserRoleRepository
    {
        private readonly DataContext _dataContext;

        public UserRoleRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task AddAsync(UserRole entity)
        {
            await _dataContext.UsersRoles.AddAsync(entity);
        }

        public void Edit(UserRole entity)
        {
            _dataContext.UsersRoles.Update(entity);
        }

        public async Task<UserRole> GetAsync(int id, int header)
        {
            return await _dataContext.UsersRoles.FindAsync(id);
        }

        public async Task<UserRoleDetailDto> GetDetailAsync(int id, int header)
        {
            return await (from s in _dataContext.UsersRoles
                          where s.Id == id && s.CompanyId == header
                          select new UserRoleDetailDto
                          {
                              Id = s.Id,
                              RoleName = s.RoleName,
                              CompanyId=s.CompanyId
                              
                          })
                          .AsNoTracking()
                          .SingleOrDefaultAsync();
        }
        public async Task<List<SelectListItemDto>> GetAllAsync(int header)
        {
            return await (from s in _dataContext.UsersRoles
                          where s.CompanyId == header
                          select new SelectListItemDto
                          {
                              KeyInt = s.Id,
                              Value = s.RoleName,
                              CompanyId=s.CompanyId
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
                                CompanyId=s.CompanyId
                                
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
        }
    }
}
