using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using UserManagement.Dtos.Field;
using UserManagement.Factories;
using UserManagement.Infrastructure.DataLayer;
using UserManagement.Infrastructure.Managers;
using UserManagement.Infrastructure.Repositories;
using UserManagement.Models.Field;
using UserManagement.Utilities;

namespace UserManagement.Managers
{
    public class FieldManager:IFieldManager
    {
        private readonly IFieldRepository _repository;
        private readonly IUnitOfWork _unitOfWork;

        private readonly string _userId;

        public FieldManager(IHttpContextAccessor contextAccessor,
         IFieldRepository repository,
         IUnitOfWork unitOfWork)
        {
            _userId = contextAccessor.HttpContext.User.GetUserId();

            _repository = repository;
            _unitOfWork = unitOfWork;
        }

        public async Task AddAsync(FieldsAddModel model)
        {
            await _repository.AddAsync(FieldsFactory.Create(model, _userId));
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task EditAsync(FieldEditModel model)
        {
            var item = await _repository.GetAsync(model.lang_id);
            FieldsFactory.Create(model, item, _userId);
            _repository.Edit(item);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task<FieldDto> GetDetailAsync(int id)
        {
            return await _repository.GetDetailAsync(id);
        }

        public async Task<List<FieldDetailDto>> GetFieldDetailAsync(int lang_id,int screen_id)
        {
            return await _repository.GetFieldDetailAsync(lang_id,screen_id);
        }
        public async Task<List<FieldDetailDto>> GetFieldDetailByLanguageAsync(int lang_id)
        {
            return await _repository.GetFieldDetailByLanguageAsync(lang_id);
        }
        public async Task<List<FieldDto>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<JqDataTableResponse<FieldDto>> GetPagedResultAsync(JqDataTableRequest model)
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
