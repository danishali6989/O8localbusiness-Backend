using System;
using System.Collections.Generic;
using System.Text;

namespace UserManagement.Models.EmailSetting
{
    public  class EmailSettingEditModel
    {
       
        public int Id { get; set; }
        public string Email { get; set; }
        public string password { get; set; }
        public int Portnumber { get; set; }
        public string smtpNo { get; set; }
        public string description { get; set; }
        public int DeletedBy { get; set; }
    }
}
