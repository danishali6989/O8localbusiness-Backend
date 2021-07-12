using System;
using System.Collections.Generic;
using System.Text;
using UserManagement.Dtos.UserAccess;
using UserManagement.Utilities;

namespace UserManagement.Dtos.UserLogin
{
    public class UserRoleDetailDto
    {
        public int Id { get; set; }
        public string RoleName { get; set; }

        public int CompanyId { get; set; }
        public string ScreenName { get; set; }
        public int ScreenId { get; set; }

        public List<ScreenAccessDto> Screens { get; set; }

        public Constants.RecordStatus Status { get; set; }




    }
}
