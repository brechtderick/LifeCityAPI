using LifeCityAPI.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LifeCityAPI.Data.Repositories
{
    public class LevenslijnRepository : ILevenslijnRepository
    {
        private readonly EmotieregulatieContext _context;
        private readonly DbSet<LevenslijnItem> _levenslijnItems;

        public LevenslijnRepository(EmotieregulatieContext dbContext)
        {
            _context = dbContext;
            _levenslijnItems = dbContext.LevenslijnItems;
        }

        public IEnumerable<LevenslijnItem> GetAll()
        {
            return _levenslijnItems.ToList();
        }

        public LevenslijnItem GetBy(int id)
        {
            return _levenslijnItems.SingleOrDefault(l => l.Id == id);
        }

        public IEnumerable<LevenslijnItem> GetByUser(string user)
        {
            return _levenslijnItems.Where(l => l.User == user).ToList();
        }

        public bool TryGetLevenslijnItem(int id, out LevenslijnItem levenslijnItem)
        {
            levenslijnItem = _context.LevenslijnItems.FirstOrDefault(l => l.Id == id);
            return levenslijnItem != null;
        }

        public void Add(LevenslijnItem levenslijnItem)
        {
            _levenslijnItems.Add(levenslijnItem);
        }

        public void Update(LevenslijnItem levenslijnItem)
        {
            _levenslijnItems.Update(levenslijnItem);
        }

        public void Delete(LevenslijnItem levenslijnItem)
        {
            _levenslijnItems.Remove(levenslijnItem);
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        public IEnumerable<LevenslijnItem> GetBy(string naam = null, string user = null, string beschrijving = null)
        {
            var levenslijnItems = _levenslijnItems.AsQueryable();
            if (!string.IsNullOrEmpty(naam))
                levenslijnItems = levenslijnItems.Where(h => h.Naam == naam);
            if (!string.IsNullOrEmpty(user))
                levenslijnItems = levenslijnItems.Where(h => h.User == user);
            if (!string.IsNullOrEmpty(beschrijving))
                levenslijnItems = levenslijnItems.Where(h => h.Beschrijving == beschrijving);
            return levenslijnItems.OrderBy(h => h.Naam).ToList();
        }
    }
}
