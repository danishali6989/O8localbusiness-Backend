using System;
using System.Collections.Generic;
using System.Text;
using UserManagement.Utilities;

namespace UserManagement.Entities
{
    public class FormOption
    {
        public int Id { get; set; }
        public int FieldId { get; set; }
        public int FormId { get; set; }
        public string OptionName { get; set; }
        public string Value { get; set; }
        public bool? IsSelected { get; set; }
        public Constants.RecordStatus Status { get; set; }
        public DateTime CreatedOn { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public string UpdatedBy { get; set; }
    }
}
