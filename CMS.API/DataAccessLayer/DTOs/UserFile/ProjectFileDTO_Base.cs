using CMS.API.DataAccessLayer.Enumerables;

namespace CMS.API.DataAccessLayer.DTOs.UserFile
{
    public abstract class ProjectFileDTO_Base
    {
        public string Title { get; set; }
        public FileCategory Category { get; set; }
        public string? Description { get; set; }
        public int cmsProjectId { get; set; }
        public int UploadedById { get; set; }
        public DateTime UploadedAt { get; set; }
    }
}
