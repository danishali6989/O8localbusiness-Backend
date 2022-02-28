using System;
using System.Collections.Generic;
using System.Text;
using UserManagement.Utilities;

namespace UserManagement.Entities
{
    public class FormField
    {
        public int Id { get; set; }
        public int FormId { get; set; }
      //  public int? FormBuilderTypeId { get; set; }
        public string FormFieldType { get; set; }
        public string FieldName { get; set; }
         public string className { get; set; }
        public string HelpText { get; set; }
        public string Placeholder { get; set; }
        public bool? requireValidOption { get; set; }
        public bool? Multiple { get; set; }
        public bool? Required { get; set; }
        public bool? Toggle { get; set; }
        public bool? EnableOther { get; set; }
        public bool? Inline { get; set; }
        public bool? Access { get; set; }
        public string SubType { get; set; }
        public string Style { get; set; }
       // public string Class { get; set; }
        public string Name { get; set; }
        public double? Value { get; set; }
        public double? Maxlength { get; set; }
        public double? Rows { get; set; }
        public Constants.RecordStatus Status { get; set; }
        public DateTime CreatedOn { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public string UpdatedBy { get; set; }

    }
}
