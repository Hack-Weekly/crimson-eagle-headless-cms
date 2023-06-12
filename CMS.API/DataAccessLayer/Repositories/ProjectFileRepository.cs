using AutoMapper;
using AutoMapper.QueryableExtensions;
using CMS.API.DataAccessLayer.Interfaces;
using CMS.API.DataAccessLayer.Models;
using CMS.API.DataAccessLayer.Pagination;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.OData.ModelBuilder;
using System.Linq;

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

        public async Task<PagedResult<UserFile>> GetProjectFilesAsync<UserFile>([FromBody] int? projectId, [FromQuery] QueryParams QP)
        {
            var recordCount = await _context.userFiles
                .Where(projectRecord => projectRecord.cmsProjectId == projectId)
                .CountAsync();

            var recordsList = await _context.userFiles
                .Skip(QP.NextPageNumber)
                .Take(QP.PageSize)
                .Where(projectRecord => projectRecord.cmsProjectId == projectId)
                .ProjectTo<UserFile>(_mapper.ConfigurationProvider)
                .ToListAsync();

            return new PagedResult<UserFile>
            {
                Records = recordsList,
                PageNumber = QP.NextPageNumber,
                TotalCount = recordCount
            };
        }
    }
}
