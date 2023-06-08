using Microsoft.AspNetCore.Identity;

namespace CMS.API.DataAccessLayer.Models
{
    public class APIUser : IdentityUser
    {
        public string FName { get; set; }
        public string LName { get; set; }
        public string? CompanyName { get; set; }
    }
}
