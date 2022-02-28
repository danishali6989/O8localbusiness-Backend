using System;
using System.Collections.Generic;
using System.Text;
using UserManagement.Utilities;

namespace UserManagement.Dtos.Form
{
    public class FormWithValueDetailDto
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int? BusinessCategoryId { get; set; }
        public int? BusinessSubCategoryId { get; set; }
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
        public List<FormFieldWithValueDetailDto> FormField { get; set; }
    }
    public class FormFieldWithValueDetailDto
    {
        public int Id { get; set; }
        public int FormId { get; set; }
        public string type { get; set; }
        public string label { get; set; }
        public string className { get; set; }
        public string subtype { get; set; }
        public double? value { get; set; }
        public Constants.RecordStatus Status { get; set; }
        public List<FormFieldValues> fieldvalue { get; set; }
    }
    public class FormFieldValues
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int FormId { get; set; }
        public int FieldId { get; set; }
        public string Value { get; set; }
    }
}
