using System;
using System.Collections.Generic;
using System.Text;
using UserManagement.Utilities;

namespace UserManagement.Dtos.Languages
{
   public class LanguagesDto
    {
        public int lang_id { get; set; }
        public string lang_name { get; set; }
        public string lang_orientation { get; set; }

        public Constants.RecordStatus Status { get; set; }

    }
}
