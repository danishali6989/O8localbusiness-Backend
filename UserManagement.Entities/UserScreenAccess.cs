using System;
using System.Collections.Generic;
using System.Text;

namespace UserManagement.Entities
{
    public class UserScreenAccess
    {
        public int Id { get; set; }
        public int? RoleId { get; set; }
        public int ScreenId { get; set; }
        public bool CanAccess { get; set; }

        public int CompanyId { get; set; }


        public ScreenDetail Screen { get; set; }

        public UserRole UserRole { get; set; }
    }
}
