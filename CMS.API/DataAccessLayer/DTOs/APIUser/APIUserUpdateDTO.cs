using System.ComponentModel.DataAnnotations;

namespace CMS.API.DataAccessLayer.DTOs.APIUser
{
    public class APIUserUpdateDTO
    {
        [Required(ErrorMessage = "Please provide your e-mail address.")]
        [EmailAddress]
        [RegularExpression("^[a-zA-Z0-9_\\.-]+@([a-zA-Z0-9-]+\\.)+[a-zA-Z]{2,6}$", ErrorMessage = "Please provide a valid e-mail address.")]
        public required string Email { get; set; }
        [Required(ErrorMessage = "Please provide your first name.")]
        [MaxLength(256, ErrorMessage = "The first name value cannot exceed 255 characters.")]
        public required string FName { get; set; }
        [Required(ErrorMessage = "Please provide your last name.")]
        [MaxLength(256, ErrorMessage = "The first name value cannot exceed 255 characters.")]
        public required string LName { get; set; }
        public string? OrganizationName { get; set; }
        [StringLength(255, ErrorMessage = "Must be between 5 and 255 characters", MinimumLength = 5)]
        [DataType(DataType.Password)]
        public string? Password { get; set; }
        [StringLength(255, ErrorMessage = "Must be between 5 and 255 characters", MinimumLength = 5)]
        [Compare("Password", ErrorMessage = "Password and Confirmation Password must match.")]
        [DataType(DataType.Password)]
        public string? ConfirmPassword { get; set; }
    }
}
