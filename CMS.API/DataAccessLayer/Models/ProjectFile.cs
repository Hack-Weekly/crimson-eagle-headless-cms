using CMS.API.DataAccessLayer.Enumerables;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CMS.API.DataAccessLayer.Models
{
    public class ProjectFile
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public required string Title { get; set; }
        public FileCategory? Category { get; set; }
        public string? Description { get; set; }
        public DateTime UploadedAt { get; set; }

        [ForeignKey("UploadResult")]
        public required string ImageId { get; set; }
        public UploadResult Image { get; set; }
        [ForeignKey("APIUser")]
        public required string UploadedById { get; set; }
        public APIUser UploadedBy { get; set; }
        [ForeignKey("cmsProject")]
        public required string cmsProjectId { get; set; }
        public cmsProject Project { get; set; }
    }
}
