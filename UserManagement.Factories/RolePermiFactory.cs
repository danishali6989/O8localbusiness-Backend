using System;
using System.Collections.Generic;
using System.Text;
using UserManagement.Entities;
using UserManagement.Models.RolePermission;

namespace UserManagement.Factories
{
    public  class RolePermiFactory
    {
        public static RolePermi Create(AddRolePermission model, string userId, string header)
        {
            var data = new RolePermi()
            {
                Pid = model.Permission_id,
                Roleid = model.Role_id,

                
                Companyid = Convert.ToInt32(header),
                // Language = model.lang_id

            };
            return data;
        }

        /*public static void Create(List<AddRolePermission> model, List<RolePermi> entities,string header)
        {

            foreach (var item in model)
            {
                var data = new RolePermi
                {
                    //  Id = Guid.NewGuid(),
                    Pid = item.Permission_id,
                    Roleid = item.Role_id,
                    Companyid = Convert.ToInt32(header)
                };
                entities.Add(data);
            }
        }*/

        /* public static RolePermi CreateUserRolePermissionAccess(AddRolePermission model,string userId,string header)
         {



         }*/
    }
}
