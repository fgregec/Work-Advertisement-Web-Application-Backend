using Core;
using Core.Entities;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
    {
        private readonly MestarContext _context;

        public GenericRepository(MestarContext context)
        {
            _context = context;
        }
        public void Add(T entity)
        {
            _context.Set<T>().Add(entity);
        }

        public void Delete(T entity)
        {
            _context.Set<T>().Remove(entity);
        }

        public async Task<T> GetByIdAsync(Guid id)
        {
            return await _context.Set<T>().FindAsync(id);
        }

        public Task<T> GetEntityWithSpec()
        {
            throw new NotImplementedException();
        }

        public async Task<IReadOnlyList<T>> ListAllAsync()
        {
           if(_context.Set<T>().Count() > 0)
            {
                return await _context.Set<T>().ToListAsync();
            }
            return new List<T>();
        }

        public Task<IReadOnlyList<T>> ListAsyncWithSpec()
        {
            throw new NotImplementedException();
        }

        public void Update(T entity)
        {
            _context.Set<T>().Update(entity);
        }
    }
}
