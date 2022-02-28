using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using UserManagement.Dtos.Form;
using UserManagement.Entities;
using System.Linq;
using System.Linq.Dynamic.Core;
using UserManagement.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

namespace UserManagement.DataLayer.Repositories
{
    public  class FormFieldValueRepository : IFormFieldValueRepository
    {
        public readonly DataContext _dataContext;
        public FormFieldValueRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task AddAsync(FormFieldValue entity )
        {
            await _dataContext.FormFieldValue.AddAsync(entity);
            await _dataContext.SaveChangesAsync();
        }
        /* public async Task AddFormCommonFieldValue(Form entity)
         {
             await _dataContext.Forms.AddAsync(entity);
             await _dataContext.SaveChangesAsync();
         }*/

        public async Task<List<FormWithValueDetailDto>> GetFormDetailByFormId(int FormId)
        {
            return await (from s in _dataContext.Forms
                          where s.Id == FormId
                          select new FormWithValueDetailDto 
                          { 
                              Id = s.Id,
                              UserId = s.UserId,
                              BusinessCategoryId = s.BusinessCategoryId,
                              BusinessSubCategoryId = s.BusinessSubCategoryId,
                              MobileNo = s.MobileNo,
                              BusinessName = s.BusinessName,
                              Address = s.Address,
                              Email = s.Email,
                              Postalcode = s.Postalcode
                          }).AsNoTracking().ToListAsync();
        }
       
        public async Task<List<FormFieldWithValueDetailDto>> GetFormFieldData(int FormId)
        {
            return await (from s in _dataContext.FormFields
                          where s.Id == FormId
                          select new FormFieldWithValueDetailDto
                          {
                              Id = s.Id,
                              FormId = s.FormId,
                              type = s.FormFieldType,
                              label = s.FieldName,
                              className = s.className,
                              subtype = s.SubType,
                              value = s.Value,
                              
                          }).AsNoTracking().ToListAsync();
        }

        public async Task<List<FormFieldValues>> GetFormFieldVal(int FormId)
        {
            return await (from s in _dataContext.FormFieldValue
                          where s.Id == FormId
                          select new FormFieldValues
                          {
                              Id = s.Id,
                              FormId = s.FormId,
                              UserId = s.UserId,
                              FieldId = s.FormFieldId,
                              Value = s.Value,
                          }).AsNoTracking().ToListAsync();
        }
    }
}
