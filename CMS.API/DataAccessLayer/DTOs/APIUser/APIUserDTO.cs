using System.ComponentModel.DataAnnotations;

namespace CMS.API.DataAccessLayer.DTOs.APIUser
{
    public class APIUserDTO : APIUserLoginDTO
    {
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        public string? CompanyName { get; set; }
    }
}
