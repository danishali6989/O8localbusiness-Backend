using UserManagement.Entities;
using UserManagement.Models.FormBuilder;
using UserManagement.Utilities;
using System;
using System.Collections.Generic;
using System.Text;

namespace UserManagement.Factories
{
    public class FormBuilderTypeFactory
    {
        public static FormBuilderType Create(FormBuilderTypeAddModel model,string userId)
        {
            var data = new FormBuilderType
            {
                TypeName = model.Type,
                Status   = Constants.RecordStatus.Active,
                CreatedBy = userId ?? "0",
                CreatedOn = Utility.GetDateTime(),

            };
            return data;
        }
    }
}
