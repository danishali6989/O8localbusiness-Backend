using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using UserManagement.Dtos.Form;
using UserManagement.Dtos.FormBuilderType;
using UserManagement.Models.FormBuilder;

namespace UserManagement.Infrastructure.Managers
{
    public interface IFormManager
    {
        Task<int> AddAsync(FormAddModel model);
        Task ClaimAsync(AddClaimRequestModel model);
        Task ClaimBusinessAsync(int ClaimUserId,int FormId);
        Task<List<FormDetailDto>> GetAll();
        Task SaveOtp(int ClaimUserId,int FormId,int Otp);
        Task<FormDetailDto> GetOtp(int ClaimUserId,int FormId);
        Task<List<FormDetailDto>> GetDetailByIdAsync(int Id);
        Task<List<FormDetailDto>> GetFormDetailAsync(int Userid, int BusinessCategoryId, int BusinessSubcategoryId);
        Task<List<FormDetailDto>> GetFormDetailByCategoryIdAsync(int BusinessCategoryId,int BusinessSubCategoryId);
        Task<FormDetailDto> GetFormDetail(int Id);
        Task<FormFieldDetailDto> GetFieldDetail(int FormId,string FormFieldType);
        Task AddFormField(AddFormFieldsModel model);
        Task AddFieldOptions(AddFieldOptionsModel model);
        Task DeleteForm(int FormId);
    }
}
