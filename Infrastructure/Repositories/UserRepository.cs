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
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationContext _context;
        public UserRepository(ApplicationContext applicationContext)
        {
            _context = applicationContext;
        }

        public void Add(User user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
        }

        public void Delete(User user)
        {
            _context.Users.Remove(user);
            _context.SaveChanges();
        }
        public void Update(User user)
        {
            _context.Update(user);
            _context.SaveChanges();
        }

        public async Task<User> GetByIdAsync(Guid id)
        {
            return await _context.Users.AsNoTracking().SingleOrDefaultAsync(x => x.Id == id);
        }
        
        public async Task<IReadOnlyList<User>> ListAllAsync()
        {
            return await _context.Users.AsNoTracking().ToListAsync();
        }

        public async Task<IEnumerable<Natjecaj>> ListResolvedNatjecaja(Guid userID)
        {
            var user = await GetByIdAsync(userID);
            return  user.ListResolvedNatjecaja;
        }

        public Task<IReadOnlyList<User>> ListAsyncWithSpec()
        {
            throw new NotImplementedException();
        }

        public Task<User> GetEntityWithSpec()
        {
            throw new NotImplementedException();
        }
    }
}
