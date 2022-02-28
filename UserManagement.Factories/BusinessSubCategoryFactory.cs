using System;
using System.Collections.Generic;
using System.Text;
using UserManagement.Entities;
using UserManagement.Models.Business;

namespace UserManagement.Factories
{
    public class BusinessSubCategoryFactory
    {
        public static BusinessSubCategory Create(BusinessSubCategoryAddModel model, string Userid)
        {
            var data = new BusinessSubCategory
            {
                BusinessCategoryId = model.BusinessCategoryid,
                BusinessSubCategoryName = model.BusinessSubCategoryName,
                CreatedOn = DateTime.Now,
                CreatedBy = Userid ?? "0"
            };
            return data;
        }
    }
}
