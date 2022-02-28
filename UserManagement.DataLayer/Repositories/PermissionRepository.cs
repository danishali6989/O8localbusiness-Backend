using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using UserManagement.Dtos.Permission;
using UserManagement.Entities;
using UserManagement.Infrastructure.Repositories;

using System.Linq;
using System.Linq.Dynamic.Core;
using Microsoft.EntityFrameworkCore;
using UserManagement.Utilities;

namespace UserManagement.DataLayer.Repositories
{
   public  class PermissionRepository : IPermissionRepository
    {

        private readonly DataContext _dataContext;

        public PermissionRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task AddAsync(Permission entity)
        {
            await _dataContext.Permission.AddAsync(entity);
        }

        public void Edit(Permission entity)
        {
            _dataContext.Permission.Update(entity);
        }

        public async Task<Permission> GetAsync(int id, int header)
        {
            return await _dataContext.Permission.FindAsync(id);
        }

        public async Task<PermissionDto> GetDetailAsync(int id, int header)
        {
            return await (from s in  _dataContext.Permission
                          where s.Id == id && s.Company_Id == header  && s.Status == Constants.RecordStatus.Active
                          select new PermissionDto
                          {
                             Id = s.Id,
                             Permissions = s.Permissions,
                             Permission_Description =s.Permission_Description,
                             CompanyId = header,
                             Status = s.Status,
                             ScreenId = s.ScreenId

                          })
                          .AsNoTracking()
                          .SingleOrDefaultAsync();
        }


        public async Task<PermissionDto> GetScreenDetailAsync(int id, int header)
        {
            return await (from s in _dataContext.Permission
                          where s.ScreenId == id && s.Company_Id == header && s.Status == Constants.RecordStatus.Active
                          select new PermissionDto
                          {
                              Id = s.Id,
                              Permissions = s.Permissions,
                              Permission_Description = s.Permission_Description,
                              CompanyId = header,
                              Status = s.Status,
                              ScreenId = s.ScreenId

                          })
                          .AsNoTracking()
                          .SingleOrDefaultAsync();
        }



        public async Task<List<PermissionDto>> GetAllAsync(int header)
        {
            return await (from s in _dataContext.Permission
                          where s.Company_Id == header  && s.Status == Constants.RecordStatus.Active
                          select new PermissionDto
                          {
                              Id = s.Id,
                              Permissions = s.Permissions,
                              Permission_Description = s.Permission_Description,
                              CompanyId = header,
                              Status = s.Status,
                              ScreenId = s.ScreenId

                          })
                          .AsNoTracking()
                          .ToListAsync();
        }

        public async Task DeleteAsync(int id, int header)
        {
            var data = await _dataContext.Permission.FindAsync(id);
            data.Status = Constants.RecordStatus.Deleted;
            _dataContext.Permission.Update(data);
            await _dataContext.SaveChangesAsync();
        }


    }
}
