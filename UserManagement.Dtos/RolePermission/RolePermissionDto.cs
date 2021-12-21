using System;
using System.Collections.Generic;
using System.Text;

namespace UserManagement.Dtos.RolePermission
{
    public class RolePermissionDto
    {
        public int Id { get; set; }
        public int screenId { get; set; }
        public string permin_title { get; set; }
        public int Per_id { get; set; }
        public int Rol_id { get; set; }
        public int CompanyId { get; set; }
        public string ScreenName { get; set; }
    }
}
