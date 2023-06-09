using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CMS.API.DataAccessLayer.Models
{
    public class cmsProject
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual IList<APIUser> Users { get; set; }
        [ForeignKey(nameof(ProjectOwnerId))]
        public int ProjectOwnerId { get; set; }
        public DateTime LastUpdated { get; set; }
        public bool IsActive { get; set; }
    }
}
