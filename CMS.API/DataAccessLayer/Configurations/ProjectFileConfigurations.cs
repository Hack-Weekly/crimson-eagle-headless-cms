using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using CMS.API.DataAccessLayer.Models;

namespace CMS.API.DataAccessLayer.Configurations
{
    public class ProjectFileConfigurations : IEntityTypeConfiguration<ProjectFile>
    {
        public void Configure(EntityTypeBuilder<ProjectFile> builder)
        {
            builder.HasData(
                    new ProjectFile
                    {
                        Id = 1,
                        Title = "Mars",
                        Description = "An image of the red planet Mars.",
                        UploadedAt = DateTime.UtcNow,
                        UploadedById = "projectoneowner-manuallyseededid",
                        cmsProjectId = "projectoneidstring",
                        ImageId = "zub4iesjxuq8z47601aw",
                    }
                );
        }
    }
}