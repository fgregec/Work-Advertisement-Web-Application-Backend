using Core.Entities;
using Core.interfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationContext _context;

        public UserRepository(ApplicationContext context)
        {
            _context = context;
        }

        public async Task<IReadOnlyList<User>> Search(string input)
        {
            return await _context.Users
                            .Include(user => user.City)
                            .Where(user => user.FirstName.Contains(input) ||
                                            user.LastName.Contains(input) ||
                                            user.City.Name.Contains(input))
                             .ToListAsync();
        }
    }
}
