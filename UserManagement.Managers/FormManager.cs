using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using UserManagement.Dtos.Form;
using UserManagement.Dtos.FormBuilderType;
using UserManagement.Factories;
using UserManagement.Infrastructure.DataLayer;
using UserManagement.Infrastructure.Managers;
using UserManagement.Infrastructure.Repositories;
using UserManagement.Models.FormBuilder;
using UserManagement.Utilities;

namespace UserManagement.Managers
{
    public class FormManager : IFormManager
    {
        public readonly IFormRepository _repository;
        public readonly IUnitOfWork _unitOfWork;
        public readonly string _userId;
        public FormManager(IHttpContextAccessor contextAccessor,IFormRepository repository,IUnitOfWork unitOfWork)
        {
            _userId = contextAccessor.HttpContext.User.GetUserId();
            _repository = repository;
            _unitOfWork = unitOfWork;
        }

        public async Task<int> AddAsync(FormAddModel model)
        {
           var obj= await _repository.AddAsync(FormFactory.Create( model,_userId));
            return obj.Id;
        }
        public async Task ClaimAsync(AddClaimRequestModel model)
        {
            var data = await _repository.GetForm(model.FormId);
           FormFactory.CreateClaim(model,data,_userId);
            _repository.Edit(data);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task ClaimBusinessAsync(int ClaimUserId,int FormId)
        {
            var data = await _repository.GetFormByClaimUserId(ClaimUserId,FormId);
            FormFactory.CreateBusinessClaim(data,_userId);
            _repository.EditIsClaim(data);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task SaveOtp(int ClaimUserId,int FormId,int Otp)
        {
            var item = await _repository.GetFormByClaimId(ClaimUserId,FormId);
            FormFactory.CreateOtp(Otp,item,_userId);
            _repository.EditOtp(item);
            await _unitOfWork.SaveChangesAsync();
        }
        public async Task<FormDetailDto> GetOtp(int ClaimUserId,int FormId)
        {
            return await _repository.GetOtpAsync(ClaimUserId,FormId);
        }
        public async Task AddFormField(AddFormFieldsModel model)
        {
            try
            {
            await _repository.AddFormField(FormFactory.CreateForm(model, _userId));
            await _unitOfWork.SaveChangesAsync();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task AddFieldOptions(AddFieldOptionsModel model)
        {
            try
            {
                await _repository.AddFieldOptions(FormFactory.CreateOptions(model, _userId));
                await _unitOfWork.SaveChangesAsync();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<List<FormDetailDto>> GetAll()
        {
            var data = await _repository.GetAll();
            foreach (var item in data)
            {
                item.Fields = await _repository.GetAllFields(item.Id);
               foreach(var i in item.Fields)
                {
                    i.values = await _repository.GetAllOptions(item.Id);
                } 
            }
            return data;

        }
        public async Task<List<FormDetailDto>> GetFormDetailAsync(int UserId,int BusinessCategoryId,int BusinessSubCategoryId)
        {
            var data = await _repository.GetFormDetailByBusinessId(UserId,BusinessCategoryId,BusinessSubCategoryId);
            foreach (var item in data)
            {
                item.Fields = await _repository.GetAllFields(item.Id);
                foreach (var i in item.Fields)
                {
                    i.values = await _repository.GetAllOptions(item.Id);
                }
            }
            return data;
        }
        public async Task<List<FormDetailDto>> GetFormDetailByCategoryIdAsync( int BusinessCategoryId,int BusinessSubCategoryId)
        {
            var data = await _repository.GetFormDetailByCategoryId(BusinessCategoryId,BusinessSubCategoryId);
            foreach (var item in data)
            {
                item.Fields = await _repository.GetAllFields(item.Id);
                foreach (var i in item.Fields)
                {
                    i.values = await _repository.GetAllOptions(item.Id);
                }
            }
            return data;
        }
            public async Task<List<FormDetailDto>> GetDetailByIdAsync(int Id)
        {
            var data = await _repository.GetFormDetailById(Id);
            foreach (var item in data)
            {
                item.Fields = await _repository.GetAllFields(item.Id);
                foreach (var i in item.Fields)
                {
                    i.values = await _repository.GetAllOptions(item.Id);
                }
            }
            return data;
        }
        public async Task<FormDetailDto> GetFormDetail(int id)
        {
            return await _repository.GetFormDetail(id);
        }
        public async Task<FormFieldDetailDto> GetFieldDetail(int FormId,string FormFieldType)
        {
            return await _repository.GetFieldDetail(FormId,FormFieldType);
        }

        public async Task DeleteForm(int id)
        {
            var data = await _repository.GetFieldDetailByFormId(id);
            foreach (var item in data)
            {
                if (item.value != null)
                {
                    var data1 = await _repository.GetFieldOptionsByFormId(id);
                    foreach (var item1 in data1)
                    {
                        await _repository.DeleteFieldOption(item1.FormId);
                    }
                }
                await _repository.DeleteField(id);
            }
            await _repository.DeleteForm(id);
        }
    }
}
