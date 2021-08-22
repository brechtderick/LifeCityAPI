using LifeCityAPI.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LifeCityAPI.Data
{
    public class EmotieregulatieDataInitializer
    {
        private readonly EmotieregulatieContext _dbContext;
        private readonly UserManager<IdentityUser> _userManager;

        public EmotieregulatieDataInitializer(EmotieregulatieContext dbContext, UserManager<IdentityUser> userManager)
        {
            _dbContext = dbContext;
            _userManager = userManager;
        }
        public async Task InitializeData()
        {
            _dbContext.Database.EnsureDeleted();
            if (_dbContext.Database.EnsureCreated())
            {
                Customer customer = new Customer { Email = "lifecity@email.com", FirstName = "admin", LastName = "admin" };
                _dbContext.Customers.Add(customer);
                await CreateUser(customer.Email, "P@ssword1111");

                Customer customer1 = new Customer { Email = "customer@email.com", FirstName = "customer", LastName = "one" };
                _dbContext.Customers.Add(customer1);
                await CreateUser(customer1.Email, "P@ssword1111");

                _dbContext.SaveChanges();
                //seeding the database with recipes, see DBContext
               
            }
        }

        private async Task CreateUser(string email, string password)
        {
            var user = new IdentityUser { UserName = email, Email = email };
            await _userManager.CreateAsync(user, password);
        }
    }
}
