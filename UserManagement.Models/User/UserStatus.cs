using System;
using System.Collections.Generic;
using System.Text;
using UserManagement.Utilities;

namespace UserManagement.Models.User
{
   public class UserStatus
    {
        public int userid { get; set; }
        public Constants.RecordStatus status { get; set; }
    }
}
