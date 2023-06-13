using CMS.API.DataAccessLayer.Models;
using Microsoft.AspNetCore.Identity;

namespace CMS.API.DataAccessLayer.Configurations;

class UsersAndRolesSeeder
{
    public static async Task Seed(UserManager<APIUser> userManager)
    {
        APIUser owner1 = new APIUser
        {
            Id = "projectoneowner-manuallyseededid",
            FName = "ProjectOwner",
            LName = "Example One",
            Email = "ProjectOwner1@example.com",
            UserName = "ProjectOwner1@example.com",
            OrganizationName = "Example Organization",
            ProjectId = "projectoneidstring",
        };

        APIUser owner2 = new APIUser
        {
            Id = "projecttwoowner-manuallyseededid",
            FName = "ProjectOwner",
            LName = "Example Two",
            Email = "ProjectOwner2@example.com",
            UserName = "ProjectOwner2@example.com",
            OrganizationName = "Example Organization",
            ProjectId = "projecttwoidstring",
        };

        APIUser user1 = new APIUser
        {
            Id = "projectoneuser-manuallyseededid",
            FName = "ProjectUser",
            LName = "Example Three",
            Email = "ProjectUser2@example.com",
            UserName = "ProjectUser2@example.com",
            OrganizationName = "Example Organization",
            ProjectId = "projectoneidstring",
        };

        APIUser editor2 = new APIUser
        {
            Id = "projecttwoeditor-manuallyseededid",
            FName = "ProjectEditor",
            LName = "Example Four",
            Email = "ProjectEditor@example.com",
            UserName = "ProjectEditor@example.com",
            ProjectId = "projecttwoidstring",
        };

        var userList = new List<APIUser>()
        {
            owner1,
            owner2,
            user1,
            editor2,
        };

        var passwords = new List<string>()
        {
            "Passw0rd?",
            "Password+123",
            "p4ssW!rd",
            "p*ssw0rD",
        };

        for (var i = 0; i < userList.Count; i++)
        {
            if (!userManager.Users.Any(r => r.UserName == userList[i].UserName))
            {
                var result = await userManager.CreateAsync(userList[i], passwords[i]);
            }
        }

        var usersRolesList = new List<IdentityUserRole<string>>(){
            new IdentityUserRole<string>
            {
                RoleId = "ProjectOwner",
                UserId = "projectoneowner-manuallyseededid",
            },
            new IdentityUserRole<string>
            {
                RoleId = "ProjectOwner",
                UserId = "projecttwoowner-manuallyseededid",
            },
            new IdentityUserRole<string>
            {
                RoleId = "ProjectUser",
                UserId = "projectoneuser-manuallyseededid",
            },
            new IdentityUserRole<string>
            {
                RoleId = "ProjectEditor",
                UserId = "projecttwoeditor-manuallyseededid",
            }
        };

        foreach (IdentityUserRole<string> userrole in usersRolesList)
        {
            var user = await userManager.FindByIdAsync(userrole.UserId);
            if (user != null)
            {
                var result = await userManager.AddToRoleAsync(user, userrole.RoleId);
            }
        }
    }
}