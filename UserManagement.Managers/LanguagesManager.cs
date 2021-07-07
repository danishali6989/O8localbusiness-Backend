using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using UserManagement.Dtos.Languages;
using UserManagement.Factories;
using UserManagement.Infrastructure.DataLayer;
using UserManagement.Infrastructure.Managers;
using UserManagement.Infrastructure.Repositories;
using UserManagement.Models.Languages;
using UserManagement.Utilities;

namespace UserManagement.Managers
{
  public  class LanguagesManager : ILanguagesManager
    {
        private readonly ILanguagesRepository _repository;
        private readonly IUnitOfWork _unitOfWork;

        private readonly string _userId;

        public LanguagesManager(IHttpContextAccessor contextAccessor,
          ILanguagesRepository repository,
          IUnitOfWork unitOfWork)
        {
            _userId = contextAccessor.HttpContext.User.GetUserId();

            _repository = repository;
            _unitOfWork = unitOfWork;
        }
        public async Task AddAsync(LanguagesAddModel model)
        {
            await _repository.AddAsync(LanguagesFactory.Create(model, _userId));
            await _unitOfWork.SaveChangesAsync();
        }
        public async Task EditAsync(LanguagesEditModel model)
        {
            var item = await _repository.GetAsync(model.lang_id);
            LanguagesFactory.Create(model, item, _userId);
            _repository.Edit(item);
            await _unitOfWork.SaveChangesAsync();
        }
        public async Task<LanguagesDto> GetDetailAsync(int id)
        {
            return await _repository.GetDetailAsync(id);
        }
        public async Task<List<LanguagesDto>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<JqDataTableResponse<LanguagesDto>> GetPagedResultAsync(JqDataTableRequest model)
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
