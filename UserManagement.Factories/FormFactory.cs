using System;
using System.Collections.Generic;
using System.Text;
using UserManagement.Entities;
using UserManagement.Models.FormBuilder;
using UserManagement.Utilities;

namespace UserManagement.Factories
{
   public  class FormFactory
    {
        public static Form Create(FormAddModel model,string userId)
        {
            var data = new Form
            {
                UserId = model.UserId,
                UserName = model.UserName == null ? null :model.UserName,
                Description = model.Description == null ? null : model.Description,
                BusinessName = model.BusinessName == null ? null : model.BusinessName,
                BusinessAlias = model.BusinessAlias == null ? null : model.BusinessAlias,
                BusinessCategoryId = model.BusinessCategoryId == null ? null : model.BusinessCategoryId,
                BusinessSubCategoryId = model.BusinessSubCategoryId == null ? null : model.BusinessSubCategoryId,
                Email = model.Email == null ? null : model.Email,
                MobileNo = model.MobileNo == null ? null : model.MobileNo,
                Postalcode = model.PostalCode == null ? null : model.PostalCode,
                Address = model.Address == null ? null : model.Address,
                IsClaim = false,
                //FormData = model.FormData,
                CreatedOn = DateTime.Now,
                CreatedBy = userId ?? "0",
                Status   = Constants.RecordStatus.Active
            };
            return data;
        }

        public static FormField CreateForm(AddFormFieldsModel model,string userId)
        {
            var data = new FormField
            {
                FormId = model.FormId,
                FormFieldType = model.type,
                FieldName = model.label==null ? "" : model.label,
                Multiple = model.multiple == null ? null : model.multiple,
                HelpText = model.HelpText == null ? null : model.HelpText,
                Placeholder = model.Placeholder == null ? null : model.Placeholder,
                requireValidOption = model.requireValidOption == null ? null : model.requireValidOption,
                Required = model.required == null ? null: model.required,
                Toggle = model.toggle == null ? null : model.toggle,
                EnableOther = model.other == null ? null : model.other,
                Inline = model.inline == null ? null : model.inline,
                Access = model.access == null ? null : model.access,
                SubType = model.subtype == null ? null : model.subtype,
                Style = model.style == null ? null: model.style,
                className = model.className == null ? null : model.className,
                Name = model.name == null ? null : model.name,
                Value = model.value == null ? null  : model.value,
                Maxlength = model.Maxlength== null ? null : model.Maxlength,
                Rows = model.Rows == null ? null : model.Rows,
                Status = Constants.RecordStatus.Active,
                CreatedOn = DateTime.Now,
                CreatedBy = userId ?? "0"
            };
            return data;
        }
        public static FormOption CreateOptions(AddFieldOptionsModel model,string userId)
        {
            var data = new FormOption
            {
                FormId = model.FormId,
                FieldId = model.FieldId,
                OptionName= model.label == null ? null : model.label,
                Value = model.value == null ? null : model.value,
                IsSelected = model.selected == null ? null  : model.selected,
                Status = Constants.RecordStatus.Active,
                CreatedOn = DateTime.Now,
                CreatedBy = userId ?? "0"
            };
            return data;
        }

        public static void CreateOtp(int Otp,Form entity,string userId)
        {
                entity.Otp = Otp;
        }
        public static void CreateBusinessClaim( Form entity, string userId)
        {
            entity.IsClaim = true;
        }
        public static void CreateClaim(AddClaimRequestModel model, Form entity, string userId)
        {
            entity.ClaimUserId = model.ClaimUserId;
        }
    }
}
