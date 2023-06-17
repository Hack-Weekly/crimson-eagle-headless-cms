using CMS.API.DataAccessLayer.Models;

namespace CMS.API.DataAccessLayer.DTOs.UserFile
{
    public class ProjectFileDTO : UpdateProjectFileDTO
    {
        public DateTime UploadedAt { get; set; }

        public UploadResult Image { get; set; }
        public required string UploadedById { get; set; }
        public required string cmsProjectId { get; set; }
    }
}
