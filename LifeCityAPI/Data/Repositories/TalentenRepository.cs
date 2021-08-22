using LifeCityAPI.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LifeCityAPI.Data.Repositories
{
    public class TalentenRepository : ITalentenRepository
    {
        private readonly EmotieregulatieContext _context;
        private readonly DbSet<Talenten> _talenten;

        public TalentenRepository(EmotieregulatieContext dbContext)
        {
            _context = dbContext;
            _talenten = dbContext.Talenten;
        }

        public IEnumerable<Talenten> GetAll()
        {
            return _talenten.ToList();
        }

        public Talenten GetBy(int id)
        {
            return _talenten.SingleOrDefault(t => t.Id == id);
        }

        public IEnumerable<Talenten> GetByUser(string user)
        {
            return _talenten.Where(t => t.User == user).ToList();
        }

        public bool TryGetTalenten(int id, out Talenten talenten)
        {
            talenten = _context.Talenten.FirstOrDefault(t => t.Id == id);
            return talenten != null;
        }

        public void Add(Talenten talenten)
        {
            _talenten.Add(talenten);
        }

        public void Update(Talenten talenten)
        {
            _context.Update(talenten);
        }

        public void Delete(Talenten talenten)
        {
            _talenten.Remove(talenten);
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        public IEnumerable<Talenten> GetBy(string naam = null, string user = null)
        {
            var talenten = _talenten.AsQueryable();
            if (!string.IsNullOrEmpty(naam))
                talenten = talenten.Where(t => t.Naam.IndexOf(naam) >= 0);
            if (!string.IsNullOrEmpty(user))
                talenten = talenten.Where(t => t.User == user);
            return talenten.OrderBy(t => t.User).ToList();
        }
    }
}
