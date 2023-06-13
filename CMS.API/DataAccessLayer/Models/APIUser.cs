using Microsoft.AspNetCore.Identity;

namespace CMS.API.DataAccessLayer.Models
{
    public class APIUser : IdentityUser
    {
        public required string FName { get; set; }
        public required string LName { get; set; }
        public string? OrganizationName { get; set; }
        public required string ProjectId { get; set; }
        public cmsProject Project { get; set; }
    }
}
