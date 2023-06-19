using System.ComponentModel.DataAnnotations;

namespace CMS.API.DataAccessLayer.DTOs.APIUser
{
    public class APIUserCreateDTO : APIUserLoginDTO
    {
        [Required(ErrorMessage = "Please provide a first name.")]
        [MaxLength(256, ErrorMessage = "The first name value cannot exceed 255 characters.")]
        public required string FName { get; set; }
        [Required(ErrorMessage = "Please provide a last name.")]
        [MaxLength(256, ErrorMessage = "The first name value cannot exceed 255 characters.")]
        public required string LName { get; set; }
        public string? OrganizationName { get; set; }
        [StringLength(255, ErrorMessage = "Must be between 5 and 255 characters", MinimumLength = 5)]
        [Compare("Password", ErrorMessage = "Password and Confirmation Password must match.")]
        [DataType(DataType.Password)]
        public required string ConfirmPassword { get; set; }
    }
}
