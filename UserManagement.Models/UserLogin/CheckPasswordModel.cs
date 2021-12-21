using System;
using System.Collections.Generic;
using System.Text;

namespace UserManagement.Models.UserLogin
{
    public class CheckPasswordModel
    {
        public int userid { get; set; }
        public string oldpassword { get; set; }
    }
}
