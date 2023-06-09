using CMS.API.DataAccessLayer.Enumerables;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CMS.API.DataAccessLayer.Models
{
    public class UserFile
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public FileCategory Category { get; set; }
        [Required]
        public string Description { get; set; }
        public int cmsProjectId { get; set; }
        [ForeignKey(nameof(UploadedById))]
        [Required]
        public int UploadedById { get; set; }
        [Required]
        public DateTime UploadedAt { get; set; }
        [Required]
        public string Image { get; set; }
    }
}
