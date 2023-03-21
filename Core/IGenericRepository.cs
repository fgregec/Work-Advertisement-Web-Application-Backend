using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    public interface IGenericRepository<T> where T : BaseEntity
    {
        Task<T> GetByIdAsync(int id);
        Task<IReadOnlyList<T>> ListAllAsync();
        Task<T> GetEntityWithSpec();
        Task<IReadOnlyList<T>> ListAsyncWithSpec();

        void Add(T entity);
        void Update(T entity);
        void Delete(int id);
    }
}
