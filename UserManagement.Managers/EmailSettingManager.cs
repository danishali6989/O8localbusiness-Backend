using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using UserManagement.Dtos.EmailSetting;
using UserManagement.Factories;
using UserManagement.Infrastructure.DataLayer;
using UserManagement.Infrastructure.Managers;
using UserManagement.Infrastructure.Repositories;
using UserManagement.Models.EmailSetting;
using UserManagement.Utilities;

namespace UserManagement.Managers
{
    public class EmailSettingManager : IEmailSettingManager
    {
        private readonly IEmailSettingRepository _repository;
        private readonly IUnitOfWork _unitOfWork;

        private readonly string _userId;

        public EmailSettingManager(IHttpContextAccessor contextAccessor,
          IEmailSettingRepository repository,
          IUnitOfWork unitOfWork)
        {
            _userId = contextAccessor.HttpContext.User.GetUserId();

            _repository = repository;
            _unitOfWork = unitOfWork;
        }

        public async Task AddAsync(EmailSettingAddModel model,string header)
        {
            try
            {

                await _repository.AddAsync1(EmailSettingFactory.Create(model, _userId,header));
                await _unitOfWork.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task EditAsync(EmailSettingEditModel model,string header)
        {
            var item = await _repository.GetAsync(model.Id, Convert.ToInt32(header));
            EmailSettingFactory.Create(model, item, _userId,header);
            _repository.Edit(item);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task<EmailSettingDto> GetDetailAsync(int id,int header)
        {
            return await _repository.GetDetailAsync(id,header);
        }


        public async Task<List<EmailSettingDto>> GetAllAsync(int header)
        {
            return await _repository.GetAllAsync(header);
        }

        public async Task DeleteAsync(int id,int header)
        {
            await _repository.DeleteAsync(id,header);
            await _unitOfWork.SaveChangesAsync();
        }
    }
}
