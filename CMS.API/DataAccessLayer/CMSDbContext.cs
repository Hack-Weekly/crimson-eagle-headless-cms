using CMS.API.DataAccessLayer.Configurations;
using CMS.API.DataAccessLayer.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CMS.API.DataAccessLayer
{
    public class CMSDbContext : IdentityDbContext<APIUser>
    {
        public CMSDbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<APIUser>? APIUsers { get; set; }
        public DbSet<cmsProject>? CMSProjects { get; set; }
        public DbSet<ProjectFile>? userFiles { get; set; }
        public DbSet<UploadResult>? Images { get; set; }

        /* Apply Seeders Here */
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            /* Role Seeder */
            modelBuilder.ApplyConfiguration(new RoleConfiguration()); // seeds the roles table

            /* cmsProject Seeder */
            modelBuilder.ApplyConfiguration(new cmsProjectConfigurations());

            // media
            modelBuilder.ApplyConfiguration(new MediaConfigurations());
            modelBuilder.ApplyConfiguration(new ProjectFileConfigurations());

            // generate id string for cmsProject
            modelBuilder.Entity<cmsProject>().Property(x => x.Id)
                .ValueGeneratedOnAdd()
                .HasValueGenerator<cmsProjectIdGenerator>();
            modelBuilder.Entity<cmsProject>().HasIndex(x => x.Name).IsUnique();
            modelBuilder.Entity<cmsProject>().Property(x => x.LastUpdated).HasDefaultValueSql("CURRENT_TIMESTAMP");
        }

    }
}
