using LifeCityAPI.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LifeCityAPI.Data.Repositories
{
    public class DoelRepository : IDoelRepository
    {
        private readonly EmotieregulatieContext _context;
        private readonly DbSet<Doel> _doelen;

        public DoelRepository(EmotieregulatieContext dbContext)
        {
            _context = dbContext;
            _doelen = dbContext.Doelen;
        }

        public IEnumerable<Doel> GetAll()
        {
            return _doelen.ToList();
        }

        public Doel GetBy(int id)
        {
            return _doelen.SingleOrDefault(d => d.Id == id);
        }

        public IEnumerable<Doel>  GetByUser(string user)
        {
            return _doelen.Where(d => d.User == user).ToList();
        }

        public bool TryGetDoel(int id, out Doel doel)
        {
            doel = _context.Doelen.FirstOrDefault(d => d.Id == id);
            return doel != null;
        }

        public void Add(Doel doel)
        {
            _doelen.Add(doel);
        }

        public void Update(Doel doel)
        {
            _doelen.Update(doel);
        }

        public void Delete(Doel doel)
        {
            _doelen.Remove(doel);
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        public IEnumerable<Doel> GetBy(string naam = null, string user = null, string beschrijving = null)
        {
            var doelen = _doelen.AsQueryable();
            if (!string.IsNullOrEmpty(naam))
                doelen = doelen.Where(d => d.Naam == naam);
            if (!string.IsNullOrEmpty(user))
                doelen = doelen.Where(d => d.User == user);
            if (!string.IsNullOrEmpty(beschrijving))
                doelen = doelen.Where(d => d.Beschrijving == beschrijving);
            return doelen.OrderBy(d => d.Naam).ToList();
        }

    }
}
