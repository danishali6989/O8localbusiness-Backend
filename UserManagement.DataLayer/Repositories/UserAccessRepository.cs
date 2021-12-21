using UserManagement.Dtos.UserAccess;
using UserManagement.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using System.Linq.Dynamic.Core;
using Microsoft.EntityFrameworkCore;
using UserManagement.Infrastructure.Repositories;
using UserManagement.Dtos.RolePermission;

namespace UserManagement.DataLayer.Repositories
{
    public class UserAccessRepository: IUserAccessRepository
    {
        private readonly DataContext _dataContext;

        public UserAccessRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
        public async Task AddUserScreenAccessAsync(List<UserScreenAccess> entity)
        {
            foreach (var item in entity)
            {
                await _dataContext.UserScreenAccess.AddAsync(item);
            }

        }

        public async Task<List<ScreenAccessDto>> GetAsyncUserScreenAccess(int id, int header)
        {
           var obj= await (from s in _dataContext.UserScreenAccess
                          join s1 in _dataContext.ScreenDetail on s.ScreenId equals s1.Id
                          where s.RoleId == id && s.CompanyId==header
                          select new ScreenAccessDto
                          {
                              Id = s.Id,
                              ScreenId = s.ScreenId,
                              UserRoleId = s.UserRole.Id,
                              CanAccess = s.CanAccess,
                              ScreenName = s1.ScreenName,
                              CompanyId = s.CompanyId,
                              ScreenUrl=s1.ScreenUrl


                          })
                         .AsNoTracking()
                         .OrderBy("ScreenName Asc")
                         .ToListAsync();
            return obj;
        }

        public async Task<List<RolePermissionDto>> GetAsyncUserPermissionAccess(int id, int header)
        {
            var obj = await (from s in _dataContext.RolePermi
                             join s1 in _dataContext.Permi on s.Pid equals s1.Id
                             where s.Roleid == id && s1.Compny_Id == header
                             select new RolePermissionDto
                             {
                                 Id = s1.Id,
                                 Per_id = s.Permi.Id,
                                 Rol_id = s.Role.Id,
                                 screenId=s1.ScrenId,
                                 permin_title = s1.Permisions,
                                 ScreenName = s1.Screen.ScreenName, 


                                 CompanyId = header,
                                


                             })
                          .AsNoTracking().ToListAsync();


            return obj;
        }

        public async Task DeleteAsyncUserScreenAccess(int id)
        {
            var data = await _dataContext.UserScreenAccess.Where(x => x.RoleId == id).ToListAsync();
            foreach (var item in data)
            {
                _dataContext.UserScreenAccess.Remove(item);
            }

        }
        public async Task<List<ScreendetailDto>> GetAllScreenDetail(int header)
        {
            return await (from s in _dataContext.ScreenDetail
                          where s.CompanyId == header
                          select new ScreendetailDto
                          {
                              Id = s.Id,
                              ScreenCode = s.ScreenCode,
                              ScreenName = s.ScreenName,
                              CompanyId=s.CompanyId,
                              ScreenUrl=s.ScreenUrl
                          })
                         .AsNoTracking()
                         .ToListAsync();
        }

        public async Task<List<ScreendetailDto>> GetAllScreen()
        {
            return await (from s in _dataContext.ScreenDetail
                         
                          select new ScreendetailDto
                          {
                              Id = s.Id,
                              ScreenCode = s.ScreenCode,
                              ScreenName = s.ScreenName,
                              CompanyId = s.CompanyId,
                              ScreenUrl=s.ScreenUrl
                          })
                         .AsNoTracking()
                         .ToListAsync();
        }

    }
}
