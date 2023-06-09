using CMS.API.DataAccessLayer.Configurations;
using CMS.API.DataAccessLayer.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;

namespace CMS.API.DataAccessLayer
{
    public class CMSDbContext : IdentityDbContext<APIUser>
    {
        public CMSDbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<APIUser> APIUsers { get; set; }
        public DbSet<cmsProject> CMSProjects { get; set; }

        /* Apply Seeders Here */
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            /* Role Seeder */
            modelBuilder.ApplyConfiguration(new RoleConfiguration()); // seeds the roles table

            /* APIUser, cmsProject Seeder */
            modelBuilder.ApplyConfiguration(new APIUserConfiguration()); // seeds the roles table
            modelBuilder.ApplyConfiguration(new cmsProjectConfigurations()); // seeds the roles table
        }

    }
}
