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

namespace UserManagement.DataLayer.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly DataContext _dataContext;

        public UserRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task AddAsync(User entity)
        {
            await _dataContext.User.AddAsync(entity);
        }

        public async Task LoginAddAsync(LoginModule entity)
        {
            var obj = _dataContext.User.Where(x => x.Id == entity.UserId).FirstOrDefault();
            if (obj != null)
            {
                obj.LastLogin = DateTime.Now;
                _dataContext.User.Update(obj);
            }

            await _dataContext.LoginModule.AddAsync(entity);


        }

        public void Edit(User entity)
        {
            _dataContext.User.Update(entity);
        }

        public async Task<User> GetAsync(int id, int header)
        {
            return await _dataContext.User.FindAsync(id);
        }

        public async Task<UserDetailDto> GetDetailAsync(int id, int header)
        {
            return await (from s in _dataContext.User
                          where s.Id == id && s.CompanyId == header //&& s.Status == Constants.RecordStatus.Active
                          select new UserDetailDto
                          {
                              Id = s.Id,
                              Usr_FName = s.Usr_FName,
                              Usr_LName = s.Usr_LName,
                              UserName = s.UserName,
                              Password = s.Password,
                              Mobile = s.Mobile,
                              Email = s.Email,
                              RoleId = s.RoleId,
                              RoleName = s.Role.RoleName,
                              CompanyId = s.CompanyId,
                              Ip_Address = s.Ip_Address,
                              Finance_year = s.Finance_year,
                              App_id = s.App_id,
                              CompanyName = s.Company.CompanyName,
                              image = s.image,

                          })
                          .AsNoTracking()
                          .SingleOrDefaultAsync();
        }

        public async Task<JqDataTableResponse<UserDetailDto>> GetPagedResultAsync(JqDataTableRequest model, int header)
        {
            if (model.Length == 0)
            {
                model.Length = Constants.DefaultPageSize;
            }

            var filterKey = model.Search.Value;

            var linqStmt = (from s in _dataContext.User
                            where s.Status != Constants.RecordStatus.Deleted && (model.filterKey == null || EF.Functions.Like(s.Usr_FName, "%" + model.filterKey + "%")
                            || EF.Functions.Like(s.Usr_FName, "%" + model.filterKey + "%")) && s.CompanyId == header
                            select new UserDetailDto
                            {
                                Id = s.Id,
                                Usr_FName = s.Usr_FName,
                                Usr_LName = s.Usr_LName,
                                UserName = s.UserName,
                                Password = s.Password,
                                Mobile = s.Mobile,
                                Email = s.Email,
                                RoleId = s.RoleId,
                                RoleName = s.Role.RoleName,
                                App_id = s.App_id,
                                Finance_year = s.Finance_year,
                                Ip_Address = s.Ip_Address,
                                image = s.image,


                                CompanyId = s.CompanyId
                            })
                            .AsNoTracking();

            var sortExpresstion = model.GetSortExpression();

            var pagedResult = new JqDataTableResponse<UserDetailDto>
            {
                RecordsTotal = await _dataContext.User.CountAsync(x => x.Status != Constants.RecordStatus.Deleted),
                RecordsFiltered = await linqStmt.CountAsync(),
                Data = await linqStmt.OrderBy(sortExpresstion).Skip(model.Start).Take(model.Length).ToListAsync()
            };
            return pagedResult;
        }

        public async Task DeleteAsync(int id, int header1)
        {
            var data = await _dataContext.User.FindAsync(id);
            data.Status = Constants.RecordStatus.Deleted;
            _dataContext.User.Update(data);
        }

        public bool GetByUserAllradyAsync(int userid)
        {
            var user = _dataContext.User.Where(x => x.Id == userid).FirstOrDefault();

            if (user != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public async Task<UserDetailDto> GetByUserAsync(string username)
        {
            return await (from s in _dataContext.User
                          where s.UserName == username
                          select new UserDetailDto
                          {
                              Id = s.Id,
                              Usr_FName = s.Usr_FName,
                              Usr_LName = s.Usr_LName,
                              UserName = s.UserName,
                              Password = s.Password,
                              Mobile = s.Mobile,
                              Email = s.Email,
                              RoleId = s.RoleId,
                              RoleName = s.Role.RoleName,
                              App_id = s.App_id,
                              Finance_year = s.Finance_year,
                              Ip_Address = s.Ip_Address,
                              CompanyId = s.CompanyId
                          })
                         .AsNoTracking()
                         .SingleOrDefaultAsync();
        }

        public async Task<UserDetailDto> getOtp(string email)
        {
            return await (from s in _dataContext.User
                          where s.Email == email
                          select new UserDetailDto
                          {
                              Id = s.Id,
                              Usr_FName = s.Usr_FName,
                              Usr_LName = s.Usr_LName,
                              UserName = s.UserName,
                              Password = s.Password,
                              Mobile = s.Mobile,
                              Email = s.Email,
                              RoleId = s.RoleId,
                              RoleName = s.Role.RoleName,
                              App_id = s.App_id,
                              Finance_year = s.Finance_year,
                              Ip_Address = s.Ip_Address,
                              CompanyId = s.CompanyId,
                              otp = s.otp

                          })
                         .AsNoTracking()
                         .SingleOrDefaultAsync();
        }

        public async Task<UserDetailDto> Login(UserLoginModel model)
        {

            var user = await (from s in _dataContext.User
                              where s.UserName == model.UserName && s.Password == Utility.Encrypt(model.Password)
                              select new UserDetailDto
                              {
                                  Id = s.Id,
                                  Usr_FName = s.Usr_FName,
                                  Usr_LName = s.Usr_LName,
                                  UserName = s.UserName,
                                  Password = s.Password,
                                  Mobile = s.Mobile,
                                  Email = s.Email,
                                  RoleId = s.RoleId,
                                  RoleName = s.Role.RoleName
                              })
                         .AsNoTracking()
                         .SingleOrDefaultAsync();
            if (user != null)
            {
                var obj = _dataContext.User.Where(x => x.Id == user.Id).FirstOrDefault();
                obj.LastLogin = DateTime.Now;
                _dataContext.User.Update(obj);
            }
            return user;
        }
        public async Task<List<UserDetailDto>> GetAllAsync()
        {
            return await (from s in _dataContext.User
                          select new UserDetailDto
                          {
                              Id = s.Id,
                              Usr_FName = s.Usr_FName,
                              Usr_LName = s.Usr_LName,
                              UserName = s.UserName,
                              Password = s.Password,
                              Mobile = s.Mobile,
                              Email = s.Email,
                              RoleId = s.RoleId,
                              RoleName = s.Role.RoleName,
                              App_id = s.App_id,
                              Finance_year = s.Finance_year,
                              Ip_Address = s.Ip_Address,
                              image = s.image,
                              CompanyId = s.CompanyId
                          })
                          .AsNoTracking()
                          .ToListAsync();
        }
        public async Task<UserDetailDto> isExist(string email)
        {
            return await (from s in _dataContext.User
                          where s.Email == email
                          select new UserDetailDto
                          {
                              Id = s.Id,
                              Usr_FName = s.Usr_FName,
                              Usr_LName = s.Usr_LName,
                              UserName = s.UserName,
                              Password = s.Password,
                              Mobile = s.Mobile,
                              Email = s.Email,
                              RoleId = s.RoleId,
                              RoleName = s.Role.RoleName
                          })
                         .AsNoTracking()
                         .SingleOrDefaultAsync();
        }

        /* public async Task<IEnumerable<UserDetailDto>> GetAllAsync(Constants.RecordStatus? status = null)
         {
             return await (from s in _dataContext.User

                           where status == null
                             ? s.Status != Constants.RecordStatus.Deleted
                             : s.Status == status.Value
                           orderby s.UserName
                           select new UserDetailDto
                           {
                               Id = s.Id,
                               Usr_FName = s.Usr_FName,
                               Usr_LName = s.Usr_LName,
                               UserName = s.UserName,
                               Password = s.Password,
                               Mobile = s.Mobile,
                               Email = s.Email,
                               RoleId = s.RoleId,
                               RoleName = s.Role.RoleName,
                               App_id = s.App_id,
                               Finance_year = s.Finance_year,
                               Ip_Address = s.Ip_Address,

                               CompanyId = s.CompanyId
                           })
                           .AsNoTracking()
                             .ToListAsync();
         }
 */

        public async Task LogOut(int id)
        {
            var data = await _dataContext.LoginModule.Where(x => x.UserId == id).FirstOrDefaultAsync();

            _dataContext.LoginModule.Remove(data);

        }

        public async Task saveOtp(string email, int otp)
        {
            var data = await _dataContext.User.Where(x => x.Email == email).FirstOrDefaultAsync();
            data.otp = otp;

            _dataContext.User.Update(data);


        }

        public async Task changePassword(string email, string password)
        {
            var data = await _dataContext.User.Where(x => x.Email == email).FirstOrDefaultAsync();
            data.Password = Utility.Encrypt(password);

            _dataContext.User.Update(data);


        }

        //with online status
        public async Task<JqDataTableResponse<UserDetailDto>> OnlineUserPagedResult(JqDataTableRequest model)
        {
            if (model.Length == 0)
            {
                model.Length = Constants.DefaultPageSize;
            }

            var filterKey = model.Search.Value;

            var linqStmt = (from s in _dataContext.User
                            join l in _dataContext.LoginModule on s.Id equals l.UserId
                            where s.Status != Constants.RecordStatus.Deleted && (model.filterKey == null || EF.Functions.Like(s.Usr_FName, "%" + model.filterKey + "%")
                            || EF.Functions.Like(s.Usr_LName, "%" + model.filterKey + "%"))
                            select new UserDetailDto
                            {
                                Id = s.Id,
                                Usr_FName = s.Usr_FName,
                                Usr_LName = s.Usr_LName,
                                UserName = s.UserName,
                                Password = s.Password,
                                Mobile = s.Mobile,
                                Email = s.Email,
                                RoleId = s.RoleId,
                                RoleName = s.Role.RoleName,
                                CallStatus = l.status ?? false
                            })
                            .AsNoTracking();

            var sortExpresstion = model.GetSortExpression();

            var pagedResult = new JqDataTableResponse<UserDetailDto>
            {
                RecordsTotal = await _dataContext.User.CountAsync(x => x.Status != Constants.RecordStatus.Deleted),
                RecordsFiltered = await linqStmt.CountAsync(),
                Data = await linqStmt.OrderBy(sortExpresstion).Skip(model.Start).Take(model.Length).ToListAsync()
            };
            return pagedResult;
        }
    }
}
