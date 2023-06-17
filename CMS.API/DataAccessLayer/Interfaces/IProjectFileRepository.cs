using CMS.API.DataAccessLayer.Models;
using CMS.API.DataAccessLayer.Pagination;

namespace CMS.API.DataAccessLayer.Interfaces
{
    public interface IProjectFileRepository : IGenericRepository<ProjectFile>
    {

        Task<PagedResult<UserFile>> GetProjectFilesAsync<UserFile>(string projectId, QueryParams QP);
    }
}
