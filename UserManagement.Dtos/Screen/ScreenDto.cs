using System;
using System.Collections.Generic;
using System.Text;
using UserManagement.Utilities;

namespace UserManagement.Dtos.Screen
{
   public class ScreenDto
    {
        public int Id { get; set; }
        public string ScreenName { get; set; }
        public string ScreenCode { get; set; }
        public string ScreenUrl { get; set; }
        public int CompanyId { get; set; }
        public Constants.RecordStatus Status { get; set; }


    }
}
