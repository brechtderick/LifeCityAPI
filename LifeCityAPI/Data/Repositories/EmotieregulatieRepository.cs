using LifeCityAPI.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LifeCityAPI.Data.Repositories
{
    public class EmotieregulatieRepository : IEmotieregulatieRepository
    {
        private readonly EmotieregulatieContext _context;
        private readonly DbSet<Emotieregulatie> _emotieregulaties;

        public EmotieregulatieRepository(EmotieregulatieContext dbContext)
        {
            _context = dbContext;
            _emotieregulaties = dbContext.Emotieregulaties;
        }

        public IEnumerable<Emotieregulatie> GetAll()
        {
            return _emotieregulaties.ToList();
        }

        public Emotieregulatie GetBy(int id)
        {
            return _emotieregulaties.SingleOrDefault(e => e.Id == id);
        }

        public bool TryGetEmotieregulatie(int id, out Emotieregulatie emotieregulatie)
        {
            emotieregulatie = _context.Emotieregulaties.FirstOrDefault(e => e.Id == id);
            return emotieregulatie != null;
        }

        public void Add(Emotieregulatie emotieregulatie)
        {
            _emotieregulaties.Add(emotieregulatie);
        }

        public void Update(Emotieregulatie emotieregulatie)
        {
            _context.Update(emotieregulatie);
        }

        public void Delete(Emotieregulatie emotieregulatie)
        {
            _emotieregulaties.Remove(emotieregulatie);
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        public IEnumerable<Emotieregulatie> GetBy(string beschrijving = null, string user = null, string emotie = null)
        {
            var emotieregulaties = _emotieregulaties.AsQueryable();
            if (!string.IsNullOrEmpty(beschrijving))
                emotieregulaties = emotieregulaties.Where(e => e.Beschrijving.IndexOf(beschrijving) >= 0);
            if (!string.IsNullOrEmpty(user))
                emotieregulaties = emotieregulaties.Where(e => e.User == user);
            if (!string.IsNullOrEmpty(emotie))
                emotieregulaties = emotieregulaties.Where(e => e.Emoties == emotie);
            return emotieregulaties.OrderBy(e => e.DateAdded).ToList();
        }
    }
}
