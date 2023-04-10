using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Infrastructure.Data.SeedData
{
    public class SeedDb
    {
        public static async Task SeedAsync(ApplicationContext context)
        {
            if (!context.Categories.Any())
            {
                var categoryData = File.ReadAllText("../Infrastructure/Data/SeedData/Category.json");
                var categories = JsonSerializer.Deserialize<List<Category>>(categoryData);
                context.Categories.AddRange(categories);
            }
            if (!context.Countries.Any())
            {
                var countryData = File.ReadAllText("../Infrastructure/Data/SeedData/Country.json");
                var countries = JsonSerializer.Deserialize<Country>(countryData);
                context.Countries.AddRange(countries);
            }
            if (!context.Counties.Any())
            {
                var countyData = File.ReadAllText("../Infrastructure/Data/SeedData/County.json");
                var counties = JsonSerializer.Deserialize<List<County>>(countyData);
                context.Counties.AddRange(counties);
            }
            if (!context.Cities.Any())
            {
                var cityData = File.ReadAllText("../Infrastructure/Data/SeedData/City.json");
                var cities = JsonSerializer.Deserialize<List<City>>(cityData);
                context.Cities.AddRange(cities);
            }
            if (!context.Users.Any())
            {
                var userData = File.ReadAllText("../Infrastructure/Data/SeedData/User.json");
                var users = JsonSerializer.Deserialize<User>(userData);
                context.Users.AddRange(users);
            }
            if (!context.Mestri.Any())
            {
                var mestarData = File.ReadAllText("../Infrastructure/Data/SeedData/Mestar.json");
                var mestri = JsonSerializer.Deserialize<Mestar>(mestarData);
                context.Mestri.AddRange(mestri);
            }
            if (!context.Natjecaji.Any())
            {
                var natjecajData = File.ReadAllText("../Infrastructure/Data/SeedData/Natjecaj.json");
                var natjecaji = JsonSerializer.Deserialize<List<Natjecaj>>(natjecajData);
                context.Natjecaji.AddRange(natjecaji);
            }
            if (context.ChangeTracker.HasChanges()) await context.SaveChangesAsync();
        }
    }
}
