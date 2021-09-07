using System;
using System.Collections.Generic;
using System.Text;

namespace UserManagement.Models.Permission
{
    public class PermissionEditModel
    {
        public int Id { get; set; }
        public string Permissions { get; set; }
        public string Permission_Description { get; set; }
        public int ScreenId { get; set; }

    }
}
