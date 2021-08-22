using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LifeCityAPI.Models
{
    public interface ILevenslijnRepository
    {
        LevenslijnItem GetBy(int id);
        IEnumerable<LevenslijnItem> GetByUser(string user);
        bool TryGetLevenslijnItem(int id, out LevenslijnItem levenslijnItem);
        IEnumerable<LevenslijnItem> GetAll();
        IEnumerable<LevenslijnItem> GetBy(string naam = null, string user = null, string beschrijving = null);
        void Add(LevenslijnItem levenslijnItem);
        void Delete(LevenslijnItem levenslijnItem);
        void Update(LevenslijnItem levenslijnItem);
        void SaveChanges();
    }
}
