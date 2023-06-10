using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace CMS.API.DataAccessLayer.Models
{
    public class APIUser : IdentityUser
    {
        public string FName { get; set; }
        public string LName { get; set; }
        public string? OrganizationName { get; set; }
        public bool IsProjectOwner { get; set; }
    }
}
