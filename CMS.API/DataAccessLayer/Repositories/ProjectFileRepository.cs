using AutoMapper;
using AutoMapper.QueryableExtensions;
using CMS.API.DataAccessLayer.Interfaces;
using CMS.API.DataAccessLayer.Models;
using CMS.API.DataAccessLayer.Pagination;
using Microsoft.EntityFrameworkCore;

namespace CMS.API.DataAccessLayer.Repositories
{
    public class ProjectFileRepository : GenericRepository<ProjectFile>, IProjectFileRepository
    {
        private readonly CMSDbContext _context;
        private readonly IMapper _mapper;

        public ProjectFileRepository(CMSDbContext context, IMapper mapper) : base(context, mapper)
        {
            this._context = context;
            this._mapper = mapper;
        }

        public async Task<PagedResult<T>> GetProjectFilesAsync<T>(string projectId, QueryParams QP)
        {
            var recordCount = (_context.userFiles != null) ? await _context.userFiles
                .Where(projectRecord => projectRecord.cmsProjectId == projectId)
                .CountAsync()
                : 0;

            var recordsList = (_context.userFiles != null) ? await _context.userFiles
                .Skip(QP.NextPageNumber) // * QP.PageSize
                .Take(QP.PageSize)
                .Where(projectRecord => projectRecord.cmsProjectId == projectId)
                .ProjectTo<T>(_mapper.ConfigurationProvider)
                .ToListAsync()
                : new List<T>();

            return new PagedResult<T>
            {
                Records = recordsList,
                PageNumber = QP.NextPageNumber,
                TotalCount = recordCount
            };
        }

        public new async Task<ProjectFile?> GetAsync(int id)
        {
            return (_context.userFiles != null) ? await _context.userFiles
                .Include(f => f.Image)
                .FirstOrDefaultAsync(e => e.Id == id)
                : null;
        }
    }
}
