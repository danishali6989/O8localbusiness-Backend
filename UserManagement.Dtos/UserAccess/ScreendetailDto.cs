using System;
using System.Collections.Generic;
using System.Text;

namespace UserManagement.Dtos.UserAccess
{
    public class ScreendetailDto
    {
        public int Id { get; set; }
        public string ScreenName { get; set; }
        public string ScreenCode { get; set; }

        public int CompanyId { get; set; }

        public string ScreenUrl { get; set; }


    }
}
