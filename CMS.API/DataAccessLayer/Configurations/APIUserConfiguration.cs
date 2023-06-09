using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using CMS.API.DataAccessLayer.Models;

namespace CMS.API.DataAccessLayer.Configurations
{
    public class APIUserConfiguration : IEntityTypeConfiguration<APIUser>
    {
        public void Configure(EntityTypeBuilder<APIUser> builder)
        {
            builder.HasData(
                    new APIUser
                    {
                        FName = "ProjectOwner",
                        LName = "Example One",
                        Email = "ProjectOwner1@example.com",
                        OrganizationName = "Example Organization",
                        IsProjectOwner = true,
                        
                    },
                    new APIUser
                    {
                        FName = "ProjectOwner",
                        LName = "Example Two",
                        Email = "ProjectOwner2@example.com",
                        OrganizationName = "Example Organization",
                        IsProjectOwner = true,
                    },
                    new APIUser
                    {
                        FName = "ProjectUser",
                        LName = "Example Two",
                        Email = "ProjectUser2@example.com",
                        OrganizationName = "Example Organization",
                        IsProjectOwner = false,
                    },
                    new APIUser
                    {
                        FName = "ProjectEditor",
                        LName = "Example One",
                        Email = "ProjectEditor@example.com",
                        OrganizationName = "Example Organization",
                        IsProjectOwner = false,
                    }
                );
        }
    }
}
