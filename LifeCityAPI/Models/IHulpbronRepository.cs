using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LifeCityAPI.Models
{
    public interface IHulpbronRepository
    {
        Hulpbron GetBy(int id);
        IEnumerable<Hulpbron> GetByUser(string user);
        bool TryGetHulpbron(int id, out Hulpbron hulpbron);
        IEnumerable<Hulpbron> GetAll();
        IEnumerable<Hulpbron> GetBy(string naam = null, string user = null, string beschrijving = null);
        void Add(Hulpbron hulpbron);
        void Delete(Hulpbron hulpbron);
        void Update(Hulpbron hulpbron);
        void SaveChanges();
    }
}
