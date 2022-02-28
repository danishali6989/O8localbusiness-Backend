using UserManagement.Utilities;
using System;
using System.Collections.Generic;
using System.Text;

namespace UserManagement.Entities
{
    public class Field
    {
        public int id { get; set; }
      
        public string field { get; set; }
        public string description { get; set; }
        public int screen_id { get; set; }
        public DateTime CreatedOn { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public string UpdatedBy { get; set; }
        public Constants.RecordStatus Status { get; set; }

        public int lang_id { get; set; }
        public Languages Language { get; set; }


    }
}
