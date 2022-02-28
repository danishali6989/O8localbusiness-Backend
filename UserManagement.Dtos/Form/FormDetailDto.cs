using System;
using System.Collections.Generic;
using System.Text;
using UserManagement.Utilities;

namespace UserManagement.Dtos.Form
{
   public class FormDetailDto
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string Description { get; set; }
        public int? BusinessCategoryId { get; set; }
        public int? BusinessSubCategoryId { get; set; }
        public bool IsClaim { get;set; }
        public int? ClaimUserId { get; set; }
        public int? Otp { get; set; }
        public string BusinessAlias { get; set; }
        public int? MobileNo { get; set; }
        public string BusinessName { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string Postalcode { get; set; }
        public Constants.RecordStatus Status { get; set; }
        public DateTime CreatedOn { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public string UpdatedBy { get; set; }
        public List<FieldDetailDto> Fields { get; set; }
      
    }
    public class FieldDetailDto
    {
        public int Id { get; set; }
        public int FormId { get; set; }
        public string type { get; set; }
       // public int? FormBuilderTypeId { get; set; }
        // public FormBuilderType FormBuilderType { get; set; }
        public string label { get; set; }
        public string className { get; set; }
       /* public string HelpText { get; set; }
        public string Placeholder { get; set; }*/
        public string subtype { get; set; }
        public bool? requireValidOption { get; set;  }
        public bool? required { get; set; }
        public bool? toggle { get; set; }
        public bool? other { get; set; }
        public bool? multiple { get; set; }
        public bool? inline { get; set; }
        public bool? access { get; set; }
       // public string subtype { get; set; }
        public string style { get; set; }
        public string Class { get; set; }
        public string name { get; set; }
        public double? value { get; set; }
        /* public double? Maxlength { get; set; }
         public double? Rows { get; set; }*/
        public Constants.RecordStatus Status { get; set; }

        public List<OptionDetailDto> values { get; set; }

    }
    public class OptionDetailDto
    {
        public int Id { get; set; }
        public int FormId { get; set; }
        public int FieldId { get; set; }
        public string label { get; set; }
        public string value { get; set; }
        public bool? selected { get; set; }
        public Constants.RecordStatus Status { get; set; }

    }
}
