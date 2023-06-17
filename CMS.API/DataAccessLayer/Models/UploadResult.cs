using System.ComponentModel.DataAnnotations;

namespace CMS.API.DataAccessLayer.Models
{
    public class UploadResult
    {
        [Key]
        public required string PublicId { get; set; }
        public required int Width { get; set; }
        public required int Height { get; set; }
        public required string Format { get; set; }
        public required string ResourceType { get; set; }
        public required Uri Url { get; set; }
        public required Uri SecureUrl { get; set; }
    }
}