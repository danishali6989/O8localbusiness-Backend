using System;
using System.Collections.Generic;
using System.Text;
using UserManagement.Utilities;

namespace UserManagement.Entities
{
    public class LoginModule
    {
        public int Id { get; set; }
        public int UserId { get; set; } 
        public DateTime? createdOn { get; set; }
        public bool? status1 { get; set; }
        public Constants.RecordStatus Status { get; set; }
        public int? RoleId { get; set; }
        public User user { get; set; }
        public int? CompanyId { get; set; }
       
        public DateTime? LastLogin { get; set; }
        public string Ip_Address { get; set; }
        public string BrowserAgent { get; set; }


    }
}
