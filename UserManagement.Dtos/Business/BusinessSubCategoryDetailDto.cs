using System;
using System.Collections.Generic;
using System.Text;
using UserManagement.Utilities;

namespace UserManagement.Dtos.Business
{
    public class BusinessSubCategoryDetailDto
    {
        public int Id { get; set; }
        public int BusinessCategoryId { get; set; }
        public string BusinessSubCategoryName { get; set; }
        public DateTime CreatedOn { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public string UpdatedBy { get; set; }
        public Constants.RecordStatus Status { get; set; }
    }
}
