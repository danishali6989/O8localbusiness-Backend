using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using UserManagement.Dtos.RolePermission;
using UserManagement.Entities;
using UserManagement.Infrastructure.Repositories;

using System.Linq;
using System.Linq.Dynamic.Core;
using Microsoft.EntityFrameworkCore;
using UserManagement.Utilities;
using UserManagement.Models.RolePermission;
using Microsoft.Extensions.DependencyInjection;

namespace UserManagement.DataLayer.Repositories
{
    public class RolePermiRepository:IRolePermiRepository
    {
        private readonly DataContext _dataContext;

        public RolePermiRepository(DataContext dataContext,IServiceProvider serviceProvider)
        {
            // _dataContext = dataContext;
            _dataContext = serviceProvider.CreateScope().ServiceProvider.GetRequiredService<DataContext>();

        }

        public async Task AddAsync(RolePermi entity)
        {
            await _dataContext.RolePermi.AddAsync(entity);
            await _dataContext.SaveChangesAsync();
        }

        public async Task AddUserScreenAccessAsync(List<RolePermi> entity)
        {
            foreach (var item in entity)
            {
                await _dataContext.RolePermi.AddAsync(item);
                await _dataContext.SaveChangesAsync();
            }

        }
        public async Task DeleteAsync(int id, int header)
        {
            var data = await _dataContext.RolePermi.FindAsync(id);
            _dataContext.RolePermi.Remove(data);
            await _dataContext.SaveChangesAsync();
        }
        public async Task DeleteAsync1(int id)
        {
            var data = await _dataContext.RolePermi.FindAsync(id);
            _dataContext.RolePermi.Remove(data);
            await _dataContext.SaveChangesAsync();

        }

        public  RolePermissionDto isExist(AddRolePermission model)
        {
            return  (from s in _dataContext.RolePermi
                          where s.Pid == model.Permission_id && s.Roleid == model.Role_id
                     select new RolePermissionDto
                          {
                              Id = s.id,
                              Per_id = s.Pid,
                              Rol_id = s.Roleid,
                              CompanyId = s.Companyid
                          })
                         .AsNoTracking()
                         .FirstOrDefault();
        }
    }
}
