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
    public class CountryRepository : ICountryRepository
    {
        private readonly MestarContext _context;

        public CountryRepository(MestarContext context)
        {
            _context = context;
        }

        public async Task<IReadOnlyList<Country>> GetCountriesAsync()
        {
            return await _context.Countries.ToListAsync();
        }
    }
}
