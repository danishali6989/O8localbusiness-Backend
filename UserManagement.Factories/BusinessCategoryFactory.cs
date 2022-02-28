using System;
using System.Collections.Generic;
using System.Text;
using UserManagement.Entities;
using UserManagement.Models.Business;

namespace UserManagement.Factories
{
    public class BusinessCategoryFactory
    {
        public static BusinessCategory Create(BusinessCategoryAddModel model,string Userid)
        {
            var data = new BusinessCategory
            {
                BusinessCategoryName = model.BusinessCategoryName,
                CreatedOn = DateTime.Now,
                CreatedBy = Userid ?? "0"
            };
            return data;
        }

        
    }
}
