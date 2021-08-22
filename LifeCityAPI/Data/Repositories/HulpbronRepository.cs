using LifeCityAPI.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LifeCityAPI.Data.Repositories
{
    public class HulpbronRepository : IHulpbronRepository
    {
        private readonly EmotieregulatieContext _context;
        private readonly DbSet<Hulpbron> _hulpbronnen;

        public HulpbronRepository(EmotieregulatieContext dbContext)
        {
            _context = dbContext;
            _hulpbronnen = dbContext.Hulpbronnen;
        }

        public IEnumerable<Hulpbron> GetAll()
        {
            return _hulpbronnen.ToList();
        }

        public Hulpbron GetBy(int id)
        {
            return _hulpbronnen.SingleOrDefault(h => h.Id == id);
        }

        public IEnumerable<Hulpbron> GetByUser(string user)
        {
            return _hulpbronnen.Where(h => h.User == user).ToList();
        }

        public bool TryGetHulpbron(int id, out Hulpbron hulpbron)
        {
            hulpbron = _context.Hulpbronnen.FirstOrDefault(h => h.Id == id);
            return hulpbron != null;
        }

        public void Add(Hulpbron hulpbron)
        {
            _hulpbronnen.Add(hulpbron);
        }

        public void Update(Hulpbron hulpbron)
        {
            _hulpbronnen.Update(hulpbron);
        }

        public void Delete(Hulpbron hulpbron)
        {
            _hulpbronnen.Remove(hulpbron);
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        public IEnumerable<Hulpbron> GetBy(string naam = null, string user = null, string beschrijving = null)
        {
            var hulpbronnen = _hulpbronnen.AsQueryable();
            if (!string.IsNullOrEmpty(naam))
                hulpbronnen = hulpbronnen.Where(h => h.Naam == naam);
            if (!string.IsNullOrEmpty(user))
                hulpbronnen = hulpbronnen.Where(h => h.User == user);
            if (!string.IsNullOrEmpty(beschrijving))
                hulpbronnen = hulpbronnen.Where(h => h.Beschrijving == beschrijving);
            return hulpbronnen.OrderBy(h => h.Naam).ToList();
        }
    }
}
