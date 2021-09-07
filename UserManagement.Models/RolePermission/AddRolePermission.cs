using System;
using System.Collections.Generic;
using System.Text;

namespace UserManagement.Models.RolePermission
{
   public  class AddRolePermission
    {
        public int id { get; set; }
        public  int Permission_id { get; set; }
        public int Role_id { get; set; }
        public bool CanCheck { get; set; }
    }
}
