using System;
using System.Collections.Generic;
using System.Text;
using UserManagement.Utilities;

namespace UserManagement.Dtos.Permission
{
    public  class PermissionDto
    {
        public int Id { get; set; }
        public string Permissions { get; set; }
        public string Permission_Description { get; set; }
        public int CompanyId { get; set; }
        
        public Constants.RecordStatus Status { get; set; }
       

        public int ScreenId { get; set; }
       
    }
}
