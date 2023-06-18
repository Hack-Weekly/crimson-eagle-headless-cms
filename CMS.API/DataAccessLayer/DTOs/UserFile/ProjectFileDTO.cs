using CMS.API.DataAccessLayer.Models;

namespace CMS.API.DataAccessLayer.DTOs.UserFile
{
    public class ProjectFileDTO : UpdateProjectFileDTO
    {
        public int Id { get; set; }
        public DateTime UploadedAt { get; set; }

        public required string UploadedById { get; set; }
        public required string cmsProjectId { get; set; }
        public UploadResult Image { get; set; }
    }
}
