using System;
using System.Collections.Generic;
using System.Text;

namespace UserManagement.Dtos.Screen
{
   public class ScreenDto
    {
        public int Id { get; set; }
        public string ScreenName { get; set; }
        public string ScreenCode { get; set; }

        public int CompanyId { get; set; }

    }
}
