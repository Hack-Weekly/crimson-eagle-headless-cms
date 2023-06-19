using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using CMS.API.DataAccessLayer.Models;

namespace CMS.API.DataAccessLayer.Configurations
{
    public class MediaConfigurations : IEntityTypeConfiguration<UploadResult>
    {
        public void Configure(EntityTypeBuilder<UploadResult> builder)
        {
            builder.HasData(
                    new UploadResult
                    {
                        PublicId = "zub4iesjxuq8z47601aw",
                        Width = 500,
                        Height = 500,
                        Format = "jpg",
                        ResourceType = "image",
                        Url = new Uri("http://res.cloudinary.com/dgxfgifvw/image/upload/v1687115656/zub4iesjxuq8z47601aw.jpg"),
                        SecureUrl = new Uri("https://res.cloudinary.com/dgxfgifvw/image/upload/v1687115656/zub4iesjxuq8z47601aw.jpg")
                    }
                );
        }
    }
}