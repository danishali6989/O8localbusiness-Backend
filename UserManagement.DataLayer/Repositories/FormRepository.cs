using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using UserManagement.Dtos.FormBuilderType;
using UserManagement.Entities;
using UserManagement.Infrastructure.Repositories;
using System.Linq;
using System.Linq.Dynamic.Core;
using Microsoft.EntityFrameworkCore;
using UserManagement.Dtos.Form;
using UserManagement.Utilities;
using UserManagement.Infrastructure.DataLayer;

namespace UserManagement.DataLayer.Repositories
{
    public class FormRepository : IFormRepository
    {
        public readonly DataContext _dataContext;
      
        public FormRepository( IServiceProvider serviceProvider)
        {
            //_dataContext = dataContext;
            _dataContext = serviceProvider.CreateScope().ServiceProvider.GetRequiredService<DataContext>();
          
        }

        public async Task<Form> AddAsync(Form entity)
        {
            await _dataContext.Forms.AddAsync(entity);
            await _dataContext.SaveChangesAsync();
            return entity;
        }
        public async Task AddFormField(FormField entity)
        {
            await _dataContext.FormFields.AddAsync(entity);
            await _dataContext.SaveChangesAsync();
        }
        public async Task AddFieldOptions(FormOption entity)
        {
            await _dataContext.FormOptions.AddAsync(entity);
            await _dataContext.SaveChangesAsync();
        }
        public async Task<List<FieldDetailDto>> GetAllFields(int id)
        {
            return await (from s in _dataContext.FormFields
                          where s.FormId == id
                          select new FieldDetailDto
                          {
                              Id = s.Id,
                              FormId = s.FormId,
                              type = s.FormFieldType,
                              label = s.FieldName,
                              className = s.className,
                             // Content = s.Content,
                              //HelpText = s.HelpText,
                              //Placeholder = s.Placeholder,
                              required = s.Required,
                              toggle = s.Toggle,
                              other =s.EnableOther,
                              inline = s.Inline,
                              access = s.Access,
                              subtype = s.SubType,
                              style = s.Style,
                              requireValidOption=s.requireValidOption,
                            //  Class = s.Class,
                              name = s.Name,
                              value = s.Value,
                              /*Maxlength = s.Maxlength,
                              Rows = s.Rows,*/
                              multiple = s.Multiple


                          })
                         .AsNoTracking()
                         .ToListAsync();
        }

        public async Task<List<OptionDetailDto>> GetAllOptions(int id)
        {
            return await (from s in _dataContext.FormOptions
                          where s.FormId == id
                          select new OptionDetailDto
                          {
                              Id = s.Id,
                              FormId = s.FormId,
                              FieldId = s.FieldId,
                              
                              label = s.OptionName,
                              selected = s.IsSelected,
                              value = s.Value,
                             
                          })
                         .AsNoTracking()
                         .ToListAsync();
        }
        public async Task<List<FormDetailDto>> GetAll()
        {
            return await (from s in _dataContext.Forms

                          select new FormDetailDto
                          {
                              Id = s.Id,
                              BusinessName = s.BusinessName,
                              UserName = s.UserName,
                              Description = s.Description,
                              UserId = s.UserId,
                              IsClaim = s.IsClaim,
                              BusinessAlias = s.BusinessAlias,
                              Status = s.Status,
                              CreatedBy = s.CreatedBy,
                              CreatedOn = s.CreatedOn,
                              UpdatedBy = s.UpdatedBy,
                              UpdatedOn = s.UpdatedOn


                          })
                         .AsNoTracking()
                         .ToListAsync();
        }

        public async Task<Form> GetFormByClaimId(int ClaimUserId,int FormId)
        {
            return  _dataContext.Forms.Where(s=> s.ClaimUserId == ClaimUserId && s.Id == FormId).FirstOrDefault();
           
        }
        public async Task<Form> GetFormByClaimUserId(int ClaimUserId,int FormId)
        {
            return  _dataContext.Forms.Where(s=>s.ClaimUserId==ClaimUserId && s.Id == FormId).FirstOrDefault();
        }
        public async Task<Form> GetForm(int FormId)
        {
            return await _dataContext.Forms.FindAsync(FormId);
        }
        public async Task<FormFieldDetailDto> GetFieldDetail(int FormId,string FormFieldType)
        {
            return await (from s in _dataContext.FormFields
                          where s.FormId == FormId && s.FormFieldType == FormFieldType
                          select new FormFieldDetailDto
                          {
                              Id = s.Id,
                              FormId = s.FormId,
                               type= s.FormFieldType,
                              label = s.FieldName,
                              Status = s.Status,
                              CreatedBy = s.CreatedBy,
                              CreatedOn = s.CreatedOn,
                              UpdatedBy = s.UpdatedBy,
                              UpdatedOn = s.UpdatedOn
                          })
                         .AsNoTracking()
                         .SingleOrDefaultAsync();
        }

        public async Task<List<FormFieldDetailDto>> GetFieldDetailByFormId(int FormId)
        {
            return await (from s in _dataContext.FormFields
                          where s.FormId == FormId
                          select new FormFieldDetailDto 
                          { 
                              Id = s.Id,
                              FormId = s.FormId,
                              type = s.FormFieldType,
                              label = s.FieldName,
                              required = s.Required,
                              toggle = s.Toggle,
                              other = s.EnableOther,
                              inline = s.Inline,
                              access = s.Access,
                              SubType = s.SubType,
                              style = s.Style,
                              className = s.className,
                              name = s.Name,
                              value = s.Value,
                              Maxlength = s.Maxlength,
                              Rows = s.Rows,
                              Status = s.Status
                          })
                          .AsNoTracking()
                          .ToListAsync();
        }
        public async Task<List<OptionDetailDto>> GetFieldOptionsByFormId(int FormId)
        {
            return await (from s in _dataContext.FormOptions
                          where s.FormId == FormId
                          select new OptionDetailDto
                          {
                              Id = s.Id,
                              FormId = s.FormId,
                              FieldId = s.FieldId,
                              label = s.OptionName,
                              selected = s.IsSelected,
                              value = s.Value,
                              Status = s.Status
                          }
                          ).AsNoTracking().ToListAsync();
        }
        public async Task<List<FormDetailDto>> GetFormDetailByCategoryId(int BusinessCategoryId,int BusinessSubCategoryId)
        {
            return await (from s in _dataContext.Forms
                          where  s.BusinessCategoryId==BusinessCategoryId && s.BusinessSubCategoryId == BusinessSubCategoryId
                          select new FormDetailDto
                          {
                              Id = s.Id,
                              UserId = s.UserId,
                              UserName = s.UserName,
                              Description = s.Description,
                              BusinessName = s.BusinessName,
                              BusinessAlias = s.BusinessAlias,
                              IsClaim = s.IsClaim,
                              BusinessCategoryId = s.BusinessCategoryId,
                              BusinessSubCategoryId = s.BusinessSubCategoryId,
                              MobileNo = s.MobileNo,
                              Address = s.Address,
                              Email = s.Email,
                              Postalcode = s.Postalcode,
                              Status = s.Status,
                              CreatedBy = s.CreatedBy,
                              CreatedOn = s.CreatedOn,
                              UpdatedBy = s.UpdatedBy,
                              UpdatedOn = s.UpdatedOn
                          })
                         .AsNoTracking()
                         .ToListAsync();
        }
        public async Task<List<FormDetailDto>> GetFormDetailByBusinessId(int UserId, int BusinessCategoryId, int BusinessSubCategoryId)
        {
            return await (from s in _dataContext.Forms
                          where s.UserId == UserId && s.BusinessCategoryId == BusinessCategoryId && s.BusinessSubCategoryId == BusinessSubCategoryId
                          select new FormDetailDto
                          {
                              Id = s.Id,
                              UserId = s.UserId,
                              UserName = s.UserName,
                              Description = s.Description,
                              BusinessName = s.BusinessName,
                              BusinessAlias = s.BusinessAlias,
                              IsClaim = s.IsClaim,
                              BusinessCategoryId = s.BusinessCategoryId,
                              BusinessSubCategoryId = s.BusinessSubCategoryId,
                              MobileNo = s.MobileNo,
                              Address = s.Address,
                              Email = s.Email,
                              Postalcode = s.Postalcode,
                              Status = s.Status,
                              CreatedBy = s.CreatedBy,
                              CreatedOn = s.CreatedOn,
                              UpdatedBy = s.UpdatedBy,
                              UpdatedOn = s.UpdatedOn
                          })
                         .AsNoTracking()
                         .ToListAsync();
        }


        public async Task<List<FormDetailDto>> GetFormDetailById(int Id)
        {
            return await (from s in _dataContext.Forms
                          where s.Id == Id
                          select new FormDetailDto
                          {
                              Id = s.Id,
                              UserId = s.UserId,
                              UserName = s.UserName,
                              Description = s.Description,
                              BusinessName = s.BusinessName,
                              BusinessAlias = s.BusinessAlias,
                              IsClaim = s.IsClaim,
                              BusinessCategoryId = s.BusinessCategoryId,
                              BusinessSubCategoryId = s.BusinessSubCategoryId,
                              MobileNo = s.MobileNo,
                              Address = s.Address,
                              Email = s.Email,
                              Postalcode = s.Postalcode,
                              Status = s.Status,
                              CreatedBy = s.CreatedBy,
                              CreatedOn = s.CreatedOn,
                              UpdatedBy = s.UpdatedBy,
                              UpdatedOn = s.UpdatedOn
                          })
                         .AsNoTracking()
                         .ToListAsync();
        }
        public async Task<FormDetailDto> GetFormDetail(int id)
        {
            return await (from s in _dataContext.Forms
                          where s.Id == id 
                          select new FormDetailDto
                          {
                              Id = s.Id,
                              UserName = s.UserName,
                              Description = s.Description,
                              BusinessName = s.BusinessName,
                              BusinessAlias = s.BusinessAlias,
                              IsClaim = s.IsClaim,
                              UserId = s.UserId,
                              Status = s.Status,
                              CreatedBy = s.CreatedBy,
                              CreatedOn = s.CreatedOn,
                              UpdatedBy = s.UpdatedBy,
                              UpdatedOn = s.UpdatedOn
                          })
                         .AsNoTracking()
                         .SingleOrDefaultAsync();
        }
        public async Task<FormDetailDto> GetOtpAsync(int ClaimUserId,int FormId) 
        {
            return await (from s in _dataContext.Forms
                          where s.ClaimUserId == ClaimUserId && s.Id==FormId
                          select new FormDetailDto
                          {
                              Id = s.Id,
                              UserId = s.UserId,
                              UserName = s.UserName,
                              Description = s.Description,
                              BusinessName = s.BusinessName,
                              BusinessAlias = s.BusinessAlias,
                              IsClaim = s.IsClaim,
                              BusinessCategoryId = s.BusinessCategoryId,
                              BusinessSubCategoryId = s.BusinessSubCategoryId,
                              MobileNo = s.MobileNo,
                              Address = s.Address,
                              Email = s.Email,
                              Postalcode = s.Postalcode,
                              Status = s.Status,
                              Otp = s.Otp
                          }).AsNoTracking().SingleOrDefaultAsync();
        }
        public async Task DeleteFieldOption(int Formid)
        {
            var item = await _dataContext.FormOptions.FindAsync(Formid);
            item.Status = Constants.RecordStatus.Deleted;
            _dataContext.FormOptions.Update(item);
            await _dataContext.SaveChangesAsync();
        }
        public async Task DeleteField(int Formid)
        {
            var item = await _dataContext.FormFields.FindAsync(Formid);
            item.Status = Constants.RecordStatus.Deleted;
            _dataContext.FormFields.Update(item);
            await _dataContext.SaveChangesAsync();
        }
        public async Task DeleteForm(int Formid)
        {
            var item = await _dataContext.Forms.FindAsync(Formid);
            item.Status = Constants.RecordStatus.Deleted;
            _dataContext.Forms.Update(item);
            await _dataContext.SaveChangesAsync();

        }
        public void  Edit(Form Entity) 
        {
            _dataContext.Forms.Update(Entity);
            _dataContext.SaveChanges();
        }

        public void EditOtp(Form entity)
        {
            _dataContext.Forms.Update(entity);
            _dataContext.SaveChanges();
        }
        public void EditIsClaim(Form entity)
        {
            _dataContext.Forms.Update(entity);
            _dataContext.SaveChanges();
        }
    }
}
