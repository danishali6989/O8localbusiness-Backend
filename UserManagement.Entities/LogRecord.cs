using System;
using System.Collections.Generic;
using System.Text;

namespace UserManagement.Entities
{
   public class LogRecord
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Comment { get; set; }
        public string Type { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime? UpdatedOn { get; set; }
    }
}
