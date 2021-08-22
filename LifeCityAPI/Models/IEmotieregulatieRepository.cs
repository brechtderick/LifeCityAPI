using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LifeCityAPI.Models
{
    public interface IEmotieregulatieRepository
    {
        Emotieregulatie GetBy(int id);
        bool TryGetEmotieregulatie(int id, out Emotieregulatie emotieregulatie);
        IEnumerable<Emotieregulatie> GetAll();
        IEnumerable<Emotieregulatie> GetBy(string beschrijving = null, string user = null, string emotie = null);
        void Add(Emotieregulatie emotieregulatie);
        void Delete(Emotieregulatie emotieregulatie);
        void Update(Emotieregulatie emotieregulatie);
        void SaveChanges();
    }
}
