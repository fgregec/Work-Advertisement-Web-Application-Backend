using Core.Entities;
using Core.Interfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class NatjecajRepository : IGenericRepository<Natjecaj>
    {
        private readonly ApplicationContext _context;
        public NatjecajRepository(ApplicationContext context)
        {
            _context = context;
        }

        public void Add(Natjecaj natjecaj)
        {
            _context.Natjecaji.Add(natjecaj);
            _context.SaveChanges();
        }

        public void Delete(Natjecaj natjecaj)
        {
            _context.Natjecaji.Remove(natjecaj);
            _context.SaveChanges();
        }

        public void Update(Natjecaj natjecaj)
        {
            _context.Natjecaji.Update(natjecaj);
            _context.SaveChanges();
        }

        public async Task<Natjecaj> GetByIdAsync(Guid id)
        {
            return await _context.Natjecaji.AsNoTracking().SingleOrDefaultAsync(x => x.Id == id);
        }               

        public async Task<IReadOnlyList<Natjecaj>> ListAllAsync()
        {
            return await _context.Natjecaji.AsNoTracking().ToListAsync();
        }
        public Task<Natjecaj> GetEntityWithSpec()
        {
            throw new NotImplementedException();
        }

        public Task<IReadOnlyList<Natjecaj>> ListAsyncWithSpec()
        {
            throw new NotImplementedException();
        }        
    }
}
