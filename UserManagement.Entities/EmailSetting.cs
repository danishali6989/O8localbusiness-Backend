using System;
using System.Collections.Generic;
using System.Text;
using UserManagement.Utilities;

namespace UserManagement.Entities
{
    public class EmailSetting
    {
        public int Id { get; set; }
        public int? CompanyId { get; set; }
        public string Email { get; set; }
        public string password { get; set; }
        public int Portnumber { get; set; }
        public string SmtpNo { get; set; }
        public int DeletedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public string UpdatedBy { get; set; }

        public string Description { get; set; }
        public DateTime CreatedOn { get; set; }
        public string CreatedBy { get; set; }

    }
}
