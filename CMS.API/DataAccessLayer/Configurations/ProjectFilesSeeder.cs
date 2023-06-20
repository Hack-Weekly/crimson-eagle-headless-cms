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

            UploadResult media2 = new UploadResult
            {
                PublicId = "iadcxon5ykav5kysifm7",
                Width = 500,
                Height = 500,
                Format = "jpg",
                ResourceType = "image",
                Url = new Uri("http://res.cloudinary.com/dgxfgifvw/image/upload/v1687202172/iadcxon5ykav5kysifm7.jpg"),
                SecureUrl = new Uri("https://res.cloudinary.com/dgxfgifvw/image/upload/v1687202172/iadcxon5ykav5kysifm7.jpg")
            };

            if (context.Images != null && context.Images.Count() == 0)
            {
                await context.Images.AddRangeAsync(new List<UploadResult>
                {
                    media,
                    media2
                });
                await context.SaveChangesAsync();
            }

            ProjectFile file = new ProjectFile
            {
                Title = "Mars",
                Description = "An image of the red planet Mars.",
                UploadedAt = DateTime.UtcNow,
                UploadedById = "projectoneowner-manuallyseededid",
                cmsProjectId = "projectoneidstring",
                ImageId = "zub4iesjxuq8z47601aw",
            };

            ProjectFile file2 = new ProjectFile
            {
                Title = "Jupiter",
                Description = "Jupiter's Great Red Spot.",
                UploadedAt = DateTime.UtcNow,
                UploadedById = "projectoneowner-manuallyseededid",
                cmsProjectId = "projectoneidstring",
                ImageId = "iadcxon5ykav5kysifm7",
            };

            if (context.userFiles != null && context.userFiles.Count() == 0)
            {
                await context.userFiles.AddRangeAsync(new List<ProjectFile>
                {
                    file,
                    file2
                });
                await context.SaveChangesAsync();
            }
        }
    }
}