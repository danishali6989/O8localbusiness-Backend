using UserManagement.Utilities;

namespace UserManagement.Dtos
{
    public class SelectListItemDto
    {
        public int KeyInt { get; set; }
        public string KeyString { get; set; }
        public string Value { get; set; }
        public int CompanyId { get; set; }
        public Constants.RecordStatus Status { get; set; }



    }
}
