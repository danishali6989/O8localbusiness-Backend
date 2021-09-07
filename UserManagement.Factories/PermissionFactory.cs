using System;
using System.Collections.Generic;
using System.Text;
using UserManagement.Entities;
using UserManagement.Models.Permission;
using UserManagement.Utilities;

namespace UserManagement.Factories
{
     public  class PermissionFactory
    {

        public static Permission Create(PermissionAddModel model, string userId, string header)
        {
            var data = new Permission()
            {
                 Permissions = model.Permissions,
                Permission_Description= model.Permission_Description,
                
                ScreenId = model.ScreenId,
                Status = Constants.RecordStatus.Active,
                CreatedBy = userId ?? "0",
                CreatedOn = Utility.GetDateTime(),
                UpdatedBy = userId ?? "0",
                UpdatedOn = Utility.GetDateTime(),
                Company_Id = Convert.ToInt32(header),
                // Language = model.lang_id

            };
            return data;
        }


        public static void Create(PermissionEditModel model, Permission entity, string userId, string header)
        {
            entity.Permissions = model.Permissions;
            entity.Permission_Description = model.Permission_Description;
            entity.ScreenId = model.ScreenId;
            
            
            entity.UpdatedBy = userId ?? "0";
            entity.UpdatedOn = Utility.GetDateTime();
            
            entity.Company_Id = Convert.ToInt32(header);
            
        }
    }
}
