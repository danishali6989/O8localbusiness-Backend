using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using UserManagement.Dtos.Permission;
using UserManagement.Entities;

namespace UserManagement.Infrastructure.Repositories
{
    public interface IPermiRepository
    {
        Task AddAsync(Permi entity);
        void Edit(Permi entity);
        Task<Permi> GetAsync(int id, int header);



        Task<PermissionDto> GetDetailAsync(int id, int header);
        Task<PermissionDto> GetScreenDetailAsync(int id, int header);
        Task<List<PermissionDto>> GetAllAsync(int header);

        Task DeleteAsync(int id, int header);

    }
}
