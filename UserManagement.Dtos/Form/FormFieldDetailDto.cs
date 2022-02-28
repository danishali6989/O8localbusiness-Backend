using System;
using System.Collections.Generic;
using System.Text;
using UserManagement.Utilities;

namespace UserManagement.Dtos.Form
{
    public class FormFieldDetailDto
    {
        public int Id { get; set; }
        public int FormId { get; set; }
        public string type { get; set; }
        //public int? FormBuilderTypeId { get; set; }
        // public FormBuilderType FormBuilderType { get; set; }
        public string label { get; set; }
       /* public string Content { get; set; }
        public string HelpText { get; set; }
        public string Placeholder { get; set; }
       */ public bool? required { get; set; }
        public bool? toggle { get; set; }
        public bool? other { get; set; }
        public bool? inline { get; set; }
        public bool? access { get; set; }
        public string SubType { get; set; }
        public string style { get; set; }
        public string className { get; set; }
        public string name { get; set; }
        public double? value { get; set; }
        public double? Maxlength { get; set; }
        public double? Rows { get; set; }
        public Constants.RecordStatus Status { get; set; }
        public DateTime CreatedOn { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public string UpdatedBy { get; set; }
    }
}
