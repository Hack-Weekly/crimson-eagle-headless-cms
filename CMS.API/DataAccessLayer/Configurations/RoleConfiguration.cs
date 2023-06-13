using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace CMS.API.DataAccessLayer.Configurations
{
    public class RoleConfiguration : IEntityTypeConfiguration<IdentityRole>
    {
        public void Configure(EntityTypeBuilder<IdentityRole> builder)
        {
            builder.HasData(
                    new IdentityRole
                    {
                        Id = "ownerroleid",
                        Name = "ProjectOwner",
                        NormalizedName = "PROJECTOWNER"
                    },
                    new IdentityRole
                    {
                        Id = "editorroleid",
                        Name = "ProjectEditor",
                        NormalizedName = "PROJECTEDITOR"
                    },
                    new IdentityRole
                    {
                        Id = "userroleid",
                        Name = "ProjectUser",
                        NormalizedName = "PROJECTUSER"
                    }
                );
        }
    }
}
