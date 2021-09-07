using System;
using System.Collections.Generic;
using System.Text;
using UserManagement.Entities;
using UserManagement.Models.Permission;
using UserManagement.Utilities;

namespace UserManagement.Factories
{
    public class PermiFactory
    {
        public static Permi Create(PermissionAddModel model, string userId, string header)
        {
            var data = new Permi()
            {
                Permisions = model.Permissions,
                Permision_Description = model.Permission_Description,

                ScrenId = model.ScreenId,
                Status = Constants.RecordStatus.Active,
                CreatedBy = userId ?? "0",
                CreatedOn = Utility.GetDateTime(),
                UpdatedBy = userId ?? "0",
                UpdatedOn = Utility.GetDateTime(),
                Compny_Id = Convert.ToInt32(header),
                // Language = model.lang_id

            };
            return data;
        }


        public static void Create(PermissionEditModel model, Permi entity, string userId, string header)
        {
            entity.Permisions = model.Permissions;
            entity.Permision_Description = model.Permission_Description;
            entity.ScrenId = model.ScreenId;


            entity.UpdatedBy = userId ?? "0";
            entity.UpdatedOn = Utility.GetDateTime();

            entity.Compny_Id = Convert.ToInt32(header);

        }
    }
}
