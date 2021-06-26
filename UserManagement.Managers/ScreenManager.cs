using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using UserManagement.Dtos;
using UserManagement.Dtos.Screen;
using UserManagement.Factories;
using UserManagement.Infrastructure.DataLayer;
using UserManagement.Infrastructure.Managers;
using UserManagement.Infrastructure.Repositories;
using UserManagement.Models.Screen;
using UserManagement.Utilities;

namespace UserManagement.Managers
{
    public class ScreenManager: I1ScreenManager
    {
        private readonly IScreenRepository _repository;
        private readonly IUnitOfWork _unitOfWork;

        private readonly string _userId;

        public ScreenManager(IHttpContextAccessor contextAccessor,
          IScreenRepository repository,
          IUnitOfWork unitOfWork)
        {
            _userId = contextAccessor.HttpContext.User.GetUserId();

            _repository = repository;
            _unitOfWork = unitOfWork;
        }
        public async Task AddAsync(ScreenAddModel model)
        {
            await _repository.AddAsync(ScreenFactory.Create(model, _userId));
            await _unitOfWork.SaveChangesAsync();
        }
        public async Task EditAsync(ScreenEditModel model)
        {
            var item = await _repository.GetAsync(model.Id);
            ScreenFactory.Create(model, item, _userId);
            _repository.Edit(item);
            await _unitOfWork.SaveChangesAsync();
        }
        public async Task<ScreenDto> GetDetailAsync(int id)
        {
            return await _repository.GetDetailAsync(id);
        }
        public async Task<List<ScreenDto>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<JqDataTableResponse<ScreenDto>> GetPagedResultAsync(JqDataTableRequest model)
        {
            return await _repository.GetPagedResultAsync(model);
        }

        public async Task DeleteAsync(int id)
        {
            await _repository.DeleteAsync(id);
            await _unitOfWork.SaveChangesAsync();
        }
    }
    }
