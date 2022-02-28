using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using UserManagement.Dtos.Form;
using UserManagement.Factories;
using UserManagement.Infrastructure.DataLayer;
using UserManagement.Infrastructure.Managers;
using UserManagement.Infrastructure.Repositories;
using UserManagement.Models.FormBuilder;
using UserManagement.Utilities;

namespace UserManagement.Managers
{
    public class FormFieldValueManager: IFormFieldValueManager
    {
        private readonly IFormFieldValueRepository _repository;
        public readonly IFormRepository _Formrepository;

        private readonly IUnitOfWork _unitOfWork;
        private readonly string _userId;

        public FormFieldValueManager(IFormRepository FormRepository,IHttpContextAccessor contextAccessor, IFormFieldValueRepository repository, IUnitOfWork unitOfWork)
        {
            _userId = contextAccessor.HttpContext.User.GetUserId();
            _repository = repository;
            _unitOfWork = unitOfWork;
            _Formrepository = FormRepository;
        }

        public async Task AddAsync(FormValue model)
        {
            await _repository.AddAsync(FormFieldValueFactory.Create(model,_userId));
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task<List<FormWithValueDetailDto>> GetFormDetailByFormId(int FormId)
        {
            var data = await _repository.GetFormDetailByFormId(FormId);
            foreach (var r in data)
            {
                r.FormField = await _repository.GetFormFieldData(FormId);
                // var data1 = await _repository.GetFormFieldData(FormId);
                foreach (var i in r.FormField)
                {
                    i.fieldvalue = await _repository.GetFormFieldVal(FormId);
                }



            }
            return data;
        }

        /*public async Task AddFormCommonFieldValueAsync(FormFieldValueAddModel model)
        {
            await _repository.AddFormCommonFieldValue(FormFieldValueFactory.Create(model, _userId));
        }*/
    }
}
