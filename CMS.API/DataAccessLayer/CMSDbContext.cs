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

        /* Apply Seeders Here */
    }
}
