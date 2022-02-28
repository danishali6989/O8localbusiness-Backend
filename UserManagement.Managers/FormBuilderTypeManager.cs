using Microsoft.AspNetCore.Http;
using UserManagement.Dtos.FormBuilderType;
using UserManagement.Factories;
using UserManagement.Infrastructure.DataLayer;
using UserManagement.Infrastructure.Managers;
using UserManagement.Infrastructure.Repositories;
using UserManagement.Models.FormBuilder;
using UserManagement.Utilities;

using System.Collections.Generic;

using System.Threading.Tasks;


namespace UserManagement.Managers
{
    public class FormBuilderTypeManager : IFormBuilderTypeManager
    {
        private readonly IFormBuilderTypeRepository _repository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly string _userId;

        public FormBuilderTypeManager(IFormBuilderTypeRepository repository,IUnitOfWork unitOfWork,
            IHttpContextAccessor contextAccessor)
        {
            _userId = contextAccessor.HttpContext.User.GetUserId();
            _repository = repository;
            _unitOfWork = unitOfWork;
        }

        public async Task AddAsync(FormBuilderTypeAddModel model)
        {
            await _repository.AddAsync(FormBuilderTypeFactory.Create(model,_userId));
            await _unitOfWork.SaveChangesAsync();
        }
        public async Task<List<FormBuilderTypeDetailDto>> GetAll()
        {
            return await _repository.GetAll();
        }
    }
}
