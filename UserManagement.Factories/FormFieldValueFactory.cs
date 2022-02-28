using System;
using System.Collections.Generic;
using System.Text;
using UserManagement.Entities;
using UserManagement.Models.FormBuilder;

namespace UserManagement.Factories
{
    public class FormFieldValueFactory
    {
        public static FormFieldValue Create(FormValue model,string userid)
        {
            var data = new FormFieldValue
            {
                UserId = model.UserId,
                FormId = model.FormId,
                FormFieldId = model.FormFieldId,
                Value = model.Value
            };
            return data;
        }

        /*public static Form Create(FormFieldValueAddModel model, string userid)
        {
            var data = new Form
            {
                UserId = model.UserId,
                BusinessCategoryId = model.BusinessCategoryId,
                BusinessSubCategoryId = model.BusinessSubCategoryId,
                Email = model.Email,
                MobileNo = model.MobileNo,
                Postalcode = model.PostalCode
            };
            return data;
        }*/
    }
}
