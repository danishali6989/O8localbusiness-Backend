using UserManagement.Entities;
using UserManagement.Models.UserAccess;
using System;
using System.Collections.Generic;
using System.Text;

namespace UserManagement.Factories
{
    public class UserScreenAccessFactory
    {
        public static void CreateUserScreenAccess(ScreenAccessModel model, List<UserScreenAccess> entities, string header)
        {

            
            var ids = model.ScreenId.Split(",");
            for(var i =0; i < ids.Length; i++)
            {
                var data = new UserScreenAccess
                {
                 
                    RoleId = model.UserRoleId,
                    ScreenId =Convert.ToInt32(ids[i]),
                    CanAccess = model.CanAccess,
                    CompanyId = Convert.ToInt32(header),

                };
                entities.Add(data);
            }
               

        }
    }
}
