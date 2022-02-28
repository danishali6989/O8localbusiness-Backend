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
               
            };
            return data;
        }

        
    }
}
