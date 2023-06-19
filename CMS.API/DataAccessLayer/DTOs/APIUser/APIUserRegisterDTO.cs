using System.ComponentModel.DataAnnotations;

namespace CMS.API.DataAccessLayer.DTOs.APIUser
{
    public class APIUserRegisterDTO : APIUserCreateDTO
    {
        [Required(ErrorMessage = "Please provide your project's name.")]
        [MaxLength(256, ErrorMessage = "The project name value cannot exceed 255 characters.")]
        public required string ProjectName { get; set; }
    }
}
