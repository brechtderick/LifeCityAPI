using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LifeCityAPI.Models
{
    public interface IDoelRepository
    {
        Doel GetBy(int id);
        IEnumerable<Doel> GetByUser(string user);
        bool TryGetDoel(int id, out Doel doel);
        IEnumerable<Doel> GetAll();
        IEnumerable<Doel> GetBy(string naam = null, string user = null, string beschrijving = null);
        void Add(Doel doel);
        void Delete(Doel doel);
        void Update(Doel doel);
        void SaveChanges();
    }
}
