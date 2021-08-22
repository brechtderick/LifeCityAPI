using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LifeCityAPI.Models
{
    public interface ITalentenRepository
    {
        Talenten GetBy(int id);
        IEnumerable<Talenten> GetByUser(string user);
        bool TryGetTalenten(int id, out Talenten talenten);
        IEnumerable<Talenten> GetAll();
        IEnumerable<Talenten> GetBy(string naam = null, string user = null);
        void Add(Talenten talenten);
        void Delete(Talenten talenten);
        void Update(Talenten talenten);
        void SaveChanges();
    }
}
