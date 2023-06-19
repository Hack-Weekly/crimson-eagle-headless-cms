using CMS.API.DataAccessLayer.Models;

namespace CMS.API.DataAccessLayer.Configurations
{
    public class ProjectFilesSeeder
    {
        public static async Task Seed(CMSDbContext context)
        {

            UploadResult media = new UploadResult
            {
                PublicId = "zub4iesjxuq8z47601aw",
                Width = 500,
                Height = 500,
                Format = "jpg",
                ResourceType = "image",
                Url = new Uri("http://res.cloudinary.com/dgxfgifvw/image/upload/v1687115656/zub4iesjxuq8z47601aw.jpg"),
                SecureUrl = new Uri("https://res.cloudinary.com/dgxfgifvw/image/upload/v1687115656/zub4iesjxuq8z47601aw.jpg")
            };

            if (context.Images != null)
            {
                await context.Images.AddAsync(media);
            }

            ProjectFile file = new ProjectFile
            {
                Id = 1,
                Title = "Mars",
                Description = "An image of the red planet Mars.",
                UploadedAt = DateTime.UtcNow,
                UploadedById = "projectoneowner-manuallyseededid",
                cmsProjectId = "projectoneidstring",
                ImageId = "zub4iesjxuq8z47601aw",
            };

            if (context.userFiles != null)
            {
                await context.userFiles.AddAsync(file);
            }
        }
    }
}