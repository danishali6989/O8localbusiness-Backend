using System;
using System.Collections.Generic;
using System.Text;
using UserManagement.Utilities;

namespace UserManagement.Dtos.EmailSetting
{
     public class EmailSettingDto
    {
        public int Id { get; set; }
        public int? companyId { get; set; }
        public string Email { get; set; }
        public string password { get; set; }
        public int Portnumber { get; set; }
        public Constants.RecordStatus Status { get; set; }
        public int DeletedBy { get; set; }
        public string description { get; set; }
        public string SmtpNo { get; set; }
    }
}
