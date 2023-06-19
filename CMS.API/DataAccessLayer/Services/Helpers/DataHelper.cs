using Microsoft.EntityFrameworkCore;

namespace CMS.API.DataAccessLayer.Services.Helpers;

public static class DataHelper
{
    public static async Task ManageDataAsync(IServiceProvider svcProvider)
    {
        //Service: An instance of db context
        var dbContextSvc = svcProvider.GetRequiredService<CMSDbContext>();

        //Migration: This is the programmatic equivalent to Update-Database
        await dbContextSvc.Database.MigrateAsync();
    }
}