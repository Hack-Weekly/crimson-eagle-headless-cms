using AutoMapper;
using AutoMapper.QueryableExtensions;
using CMS.API.DataAccessLayer.Interfaces;
using CMS.API.DataAccessLayer.Pagination;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

namespace CMS.API.DataAccessLayer.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly CMSDbContext _context;
        private readonly IMapper _mapper;

        public GenericRepository(CMSDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        /* CREATE */
        public async Task<T> AddAsync(T entity)
        {
            // async keyword automatically maps to correct type _context.Countries.AddAsync(country)
            await _context.AddAsync(entity);
            await _context.SaveChangesAsync(); // saves to the db

            return entity;
        }

        /* READ */
        public async Task<T?> GetAsync(int id)
        {
            return await _context.Set<T>().FindAsync(id); // returns one
        }

        public async Task<List<TResult>> GetAllAsync<TResult>()
        {
            return await _context.Set<T>()
                .ProjectTo<TResult>(_mapper.ConfigurationProvider)
                .ToListAsync(); // gets the dbset of type given
        }

        // Adds Pagination

        public async Task<PagedResult<TResult>> GetAllAsync<TResult>(QueryParams QP)
        {
            var totalSize = await _context.Set<T>().CountAsync();
            var records = await _context.Set<T>()
                .Skip(QP.NextPageNumber)
                .Take(QP.PageSize)
                .ProjectTo<TResult>(_mapper.ConfigurationProvider)
                .ToListAsync();

            return new PagedResult<TResult>
            {
                Records = records,
                PageNumber = QP.NextPageNumber,
                TotalCount = totalSize
            };
        }

        public async Task<bool> Exists(int id)
        {
            var EntitySearchingFor = await GetAsync(id);

            return EntitySearchingFor != null;
        }

        /* UPDATE */
        public async Task UpdateAsync(T entity)
        {
            _context.Update(entity); // updates entity state to modified
            await _context.SaveChangesAsync();
        }

        /* DELETE */
        public async Task DeleteAsync(int id)
        {
            var EntitySearchingFor = await GetAsync(id);
            if (EntitySearchingFor != null)
            {
                _context.Set<T>().Remove(EntitySearchingFor); // this cannot be called asynchronously
                await _context.SaveChangesAsync();
            }
        }
    }
}
