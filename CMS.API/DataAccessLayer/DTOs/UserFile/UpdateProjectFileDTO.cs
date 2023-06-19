using CMS.API.DataAccessLayer.Enumerables;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.ComponentModel.DataAnnotations;

namespace CMS.API.DataAccessLayer.DTOs.UserFile
{
    public class UpdateProjectFileDTO
    {
        [Required(ErrorMessage = "Please provide a title.")]
        [MaxLength(256, ErrorMessage = "The title value cannot exceed 255 characters.")]
        public required string Title { get; set; }
        [JsonProperty("category")]
        [JsonConverter(typeof(StringEnumConverter))]
        public FileCategory? Category { get; set; }
        [MaxLength(256, ErrorMessage = "The description value cannot exceed 255 characters.")]
        public string? Description { get; set; }
    }
}