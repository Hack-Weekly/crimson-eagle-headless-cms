using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using CMS.API.DataAccessLayer.Models;

namespace CMS.API.DataAccessLayer.Configurations
{
    public class APIUserRolesConfiguration : IEntityTypeConfiguration<IdentityUserRole<string>>
    {
        public void Configure(EntityTypeBuilder<IdentityUserRole<string>> builder)
        {
            builder.HasData(
                new IdentityUserRole<string>
                {
                    RoleId = "ownerroleid",
                    UserId = "projectoneowner-manuallyseededid",
                },
                new IdentityUserRole<string>
                {
                    RoleId = "ownerroleid",
                    UserId = "projecttwoowner-manuallyseededid",
                },
                new IdentityUserRole<string>
                {
                    RoleId = "userroleid",
                    UserId = "projectoneuser-manuallyseededid",
                },
                new IdentityUserRole<string>
                {
                    RoleId = "editorroleid",
                    UserId = "projecttwoeditor-manuallyseededid",
                }
            );
        }
    }
}
