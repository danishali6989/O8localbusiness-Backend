using System;
using System.Collections.Generic;
using System.Text;

namespace UserManagement.Models.FormBuilder
{
    public class AddClaimRequestModel
    {
        public int FormId { get; set; }
        public string Email { get; set;  }
        public int ClaimUserId { get; set; }
    }
}
