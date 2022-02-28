using System;
using System.Collections.Generic;
using System.Text;
using UserManagement.Utilities;

namespace UserManagement.Entities
{
    public class Permission
    {
        public int Id { get; set; }
        public string Permissions { get; set; }
        public string Permission_Description { get; set; }
        public int Company_Id { get; set; }
        public Company Company { get; set; }
        public Constants.RecordStatus Status { get; set; }
        public DateTime CreatedOn { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public string UpdatedBy { get; set; }
    
        public int ScreenId { get; set; }
        public ScreenDetail Screen { get; set; }

    }
}
