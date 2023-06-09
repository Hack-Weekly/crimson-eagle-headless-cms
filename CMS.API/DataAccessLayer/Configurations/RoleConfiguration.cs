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
                        Name = "ProjectOwner",
                        NormalizedName = "PROJOWNER"
                    },
                    new IdentityRole
                    {
                        Name = "ProjectEditor",
                        NormalizedName = "PROJEDITOR"
                    },
                    new IdentityRole
                    {
                        Name = "ProjectUser",
                        NormalizedName = "PROJUSER"
                    }
                );
        }
    }
}
