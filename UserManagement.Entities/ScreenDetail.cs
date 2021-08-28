using System;
using System.Collections.Generic;
using System.Text;
using UserManagement.Utilities;

namespace UserManagement.Entities
{
    public class ScreenDetail
    {
        public int Id { get; set; }
        public string ScreenName { get; set; }
       public string ScreenCode { get; set; }
       // public int screen_id { get; set; }
        public Constants.RecordStatus Status { get; set; }
        public DateTime CreatedOn { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public string UpdatedBy { get; set; }
        public int CompanyId { get; set; }
        public string ScreenUrl { get; set; }


    }
}
