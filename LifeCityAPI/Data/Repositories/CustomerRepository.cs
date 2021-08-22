using LifeCityAPI.Data;
using LifeCityAPI.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace LifeCityAPI
{
    internal class CustomerRepository : ICustomerRepository
    {
        private readonly EmotieregulatieContext _context;
        private readonly DbSet<Customer> _customers;

        public CustomerRepository(EmotieregulatieContext dbContext)
        {
            _context = dbContext;
            _customers = dbContext.Customers;
        }

        public Customer GetBy(string email)
        {
            return _customers.SingleOrDefault(c => c.Email == email);
        }

        public void Add(Customer customer)
        {
            _customers.Add(customer);
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

    }
}