using CMS.API.DataAccessLayer.Enumerables;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CMS.API.DataAccessLayer.Models
{
    public class ProjectFile
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; }
        public FileCategory Category { get; set; }
        public string? Description { get; set; }
        public int cmsProjectId { get; set; }
        public int UploadedById { get; set; }
        public DateTime UploadedAt { get; set; }
        public string Image { get; set; }
    }
}
