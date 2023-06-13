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

            var hasher = new PasswordHasher<APIUser>();

            builder.HasData(
                    new APIUser
                    {
                        Id = "projectoneowner-manuallyseededid",
                        FName = "ProjectOwner",
                        LName = "Example One",
                        Email = "ProjectOwner1@example.com",
                        NormalizedEmail = "PROJECTOWNER1@EXAMLE.COM",
                        UserName = "ProjectOwner1@example.com",
                        NormalizedUserName = "PROJECTOWNER1@EXAMLE.COM",
                        OrganizationName = "Example Organization",
                        PasswordHash = hasher.HashPassword(null, "Passw0rd?"),
                        ProjectId = "projectoneidstring",
                    },
                    new APIUser
                    {
                        Id = "projecttwoowner-manuallyseededid",
                        FName = "ProjectOwner",
                        LName = "Example Two",
                        Email = "ProjectOwner2@example.com",
                        NormalizedEmail = "PROJECTOWNER2@EXAMLE.COM",
                        UserName = "ProjectOwner2@example.com",
                        NormalizedUserName = "PROJECTOWNER2@EXAMLE.COM",
                        OrganizationName = "Example Organization",
                        PasswordHash = hasher.HashPassword(null, "Password+123"),
                        ProjectId = "projecttwoidstring",
                    },
                    new APIUser
                    {
                        Id = "projectoneuser-manuallyseededid",
                        FName = "ProjectUser",
                        LName = "Example Two",
                        Email = "ProjectUser2@example.com",
                        NormalizedEmail = "PROJECTUSER2@EXAMLE.COM",
                        UserName = "ProjectUser2@example.com",
                        NormalizedUserName = "PROJECTUSER2@EXAMLE.COM",
                        OrganizationName = "Example Organization",
                        PasswordHash = hasher.HashPassword(null, "p4ssw!rd"),
                        ProjectId = "projectoneidstring",
                    },
                    new APIUser
                    {
                        Id = "projecttwoeditor-manuallyseededid",
                        FName = "ProjectEditor",
                        LName = "Example One",
                        Email = "ProjectEditor@example.com",
                        NormalizedEmail = "PROJECTEDITOR2@EXAMLE.COM",
                        UserName = "ProjectEditor@example.com",
                        NormalizedUserName = "PROJECTEDITOR2@EXAMLE.COM",
                        PasswordHash = hasher.HashPassword(null, "p*ssw0rD"),
                        ProjectId = "projecttwoidstring",
                    }
                );
        }
    }
}
