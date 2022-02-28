using System;
using System.Collections.Generic;
using System.Text;

namespace UserManagement.Models.Business
{
    public class BusinessSubCategoryAddModel
    {
        public int id { get; set; }
        public int BusinessCategoryid { get; set; }
        public string BusinessSubCategoryName { get; set; }
    }
}
