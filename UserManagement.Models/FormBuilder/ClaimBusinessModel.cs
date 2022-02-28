using System;
using System.Collections.Generic;
using System.Text;

namespace UserManagement.Models.FormBuilder
{
    public class ClaimBusinessModel
    {
        public int ClaimUserId { get; set; }
        public int Otp { get; set; }
        public int FormId { get; set; }
    }
}
