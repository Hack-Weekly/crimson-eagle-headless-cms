using System.ComponentModel.DataAnnotations;

namespace CMS.API.DataAccessLayer.DTOs.APIUser
{
    public class APIUserLoginDTO
    {
        [Required(ErrorMessage = "Please provide an e-mail address.")]
        [EmailAddress]
        [RegularExpression("^[a-zA-Z0-9_\\.-]+@([a-zA-Z0-9-]+\\.)+[a-zA-Z]{2,6}$", ErrorMessage = "Please provide a valid e-mail address.")]
        public required string Email { get; set; }
        [Required(ErrorMessage = "Please provide a password.")]
        [StringLength(255, ErrorMessage = "Must be between 5 and 255 characters", MinimumLength = 5)]
        [DataType(DataType.Password)]
        public required string Password { get; set; }
    }
}
