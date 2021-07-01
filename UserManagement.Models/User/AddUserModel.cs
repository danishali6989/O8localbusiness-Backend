using System;
using System.Collections.Generic;
using System.Text;

namespace UserManagement.Models.User
{
   public class AddUserModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Mobile { get; set; }
        public int RoleId { get; set; }
        public int App_id { get; set; }
        public int Finance_year { get; set; }
        public string Ip_Address { get; set; }
       // public int CompanyId { get; set; }
        public string image { get; set; }
        public string imageUrl { get; set; }
    }
}
