using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace CMS.API.DataAccessLayer.Models
{
    [Index(nameof(Name), IsUnique = true)]
    [Index(nameof(Id), IsUnique = true)]
    public class cmsProject
    {
        [Key]
        public string Id { get; set; }
        public required string Name { get; set; }
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime LastUpdated { get; set; }
        public bool IsActive { get; set; } = true;
        [ForeignKey("ProjectId")]
        public IList<APIUser>? Users { get; set; }
        public IList<UserFile>? Files { get; set; }
    }
}
