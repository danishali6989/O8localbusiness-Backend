using System;
using System.Collections.Generic;
using System.Text;

namespace UserManagement.Models.Field
{
   public class FieldEditModel
    {
        public int lang_id { get; set; }
        public int screen_id { get; set; }
        public string field { get; set; }
        public string description { get; set; }
    }
}
