using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using UserManagement.Dtos.Business;
using UserManagement.Factories;
using UserManagement.Infrastructure.DataLayer;
using UserManagement.Infrastructure.Managers;
using UserManagement.Infrastructure.Repositories;
using UserManagement.Models.Business;
using UserManagement.Utilities;

namespace UserManagement.Managers
{
    public class BusinessSubCategoryManager : IBusinessSubCategoryManager
    {
        private readonly IBusinessSubCategoryRepository _repository;
        private readonly string _userId;
        private readonly IUnitOfWork _unitOfWork;

        public BusinessSubCategoryManager(IUnitOfWork unitOfWork,IHttpContextAccessor contextAccessor, IBusinessSubCategoryRepository repository)
        {
            _repository = repository;
            _userId = contextAccessor.HttpContext.User.GetUserId();
            _unitOfWork = unitOfWork;
        }
        public async Task AddAsync(BusinessSubCategoryAddModel model)
        {
            await _repository.AddAsync(BusinessSubCategoryFactory.Create(model, _userId));
        }

        public async Task<List<BusinessSubCategoryDetailDto>> GetAllAsync()
        {
            return await _repository.GetAll();
        }
        public async Task<BusinessSubCategoryDetailDto> GetByIdAsync(int id)
        {
            return await _repository.GetById(id);
        }
        public async Task Delete(int id)
        {
            await _repository.DeleteAsync(id);
            await _unitOfWork.SaveChangesAsync();
        }
    }
}
