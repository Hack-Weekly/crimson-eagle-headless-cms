using CMS.API.DataAccessLayer.Pagination;
using Microsoft.AspNetCore.OData.Results;

namespace CMS.API.DataAccessLayer.Interfaces
{
    public interface IGenericRepository<T> where T : class
    {
        // Interfaces are contracts, aka a required format of data that's not a class
        // in charge of communicating with the database on our behalf, the context won't be called in the controller
        Task<T?> GetAsync(int id); // asynchronous task to receive type of T with argument of int id
        Task<List<TResult>> GetAllAsync<TResult>(); // Gets Multiple
        Task<PagedResult<TResult>> GetAllAsync<TResult>(QueryParams QP); // Adds Pagination
        Task<T> AddAsync(T entity); // adds a row
        Task UpdateAsync(T entity); // Does not return data but performs action
        Task DeleteAsync(int id);
        Task<bool> Exists(int id);
    }
}
