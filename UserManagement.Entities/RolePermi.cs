using System;
using System.Collections.Generic;
using System.Text;

namespace UserManagement.Entities
{
    public class RolePermi
    {
        public int id { get; set; }
        public int Companyid { get; set; }
        public int Pid { get; set; }
     
        public int Roleid { get; set; }
        public Permi Permi { get; set; }
        public UserRole Role { get; set; }
    }
}
