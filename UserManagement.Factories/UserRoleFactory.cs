using UserManagement.Entities;
using UserManagement.Models.UserLogin;
using UserManagement.Utilities;
using System;
using System.Collections.Generic;
using System.Text;

namespace UserManagement.Factories
{
    public class UserRoleFactory
    {
        public static UserRole Create(UserRoleModel model, string userId, string header)
        {
            var data = new UserRole
            {
                RoleName = model.RoleName,
                Status = Constants.RecordStatus.Active,
                CreatedBy = userId ?? "0",
                CreatedOn = Utility.GetDateTime(),
                CompanyId = Convert.ToInt32(header),

            };
            return data;
        }
        public static void Create(UserRoleModel model, UserRole entity, string userId, string header)
        {
            entity.RoleName = model.RoleName;
            entity.UpdatedBy = userId ?? "0";
            entity.UpdatedOn = Utility.GetDateTime();
           entity.CompanyId = Convert.ToInt32(header);

        }
    }
}
