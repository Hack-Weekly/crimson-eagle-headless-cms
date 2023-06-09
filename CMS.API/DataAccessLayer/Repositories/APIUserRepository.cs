using AutoMapper;
using CMS.API.DataAccessLayer.Interfaces;
using CMS.API.DataAccessLayer.Models;
using System.Diagnostics.Metrics;

namespace CMS.API.DataAccessLayer.Repositories
{
    public class APIUserRepository : GenericRepository<APIUser>, IAPIUserRepository
    {
        private readonly CMSDbContext _context;
        private readonly IMapper _mapper;

        public APIUserRepository(CMSDbContext context, IMapper mapper) : base(context, mapper)
        {
            this._context = context;
            this._mapper = mapper;
        }

    }
}
