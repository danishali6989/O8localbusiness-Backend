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
    public  class BusinessCategoryManager : IBusinessCategoryManager
    {
        private readonly IBusinessCategoryRepository _repository;
        private readonly string _userId;    
        private readonly IUnitOfWork _unitOfWork;

        public BusinessCategoryManager(IUnitOfWork unitOfWork,IHttpContextAccessor contextAccessor, IBusinessCategoryRepository repository)
        {
            _repository = repository;
            _userId = contextAccessor.HttpContext.User.GetUserId();
            _unitOfWork = unitOfWork;
        }
        public async Task AddAsync(BusinessCategoryAddModel model)
        {
            await _repository.AddAsync(BusinessCategoryFactory.Create(model,_userId));
            await _unitOfWork.SaveChangesAsync();
        }
        public async Task<List<BusinessCategoryDetailDto>> GetAllAsync()
        {
           return  await _repository.GetAll();
        }
        public async Task<BusinessCategoryDetailDto> GetByIdAsync(int id)
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
