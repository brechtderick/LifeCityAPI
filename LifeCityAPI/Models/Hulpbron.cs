using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LifeCityAPI.Models
{
    public class Hulpbron
    {
        public int Id { get; set; }

        [Required]
        public string Naam { get; set; }

        public string User { get; set; }

        public string Beschrijving { get; set; }

        public Hulpbron() { }

        public Hulpbron(string naam) :this()
        {
            Naam = naam;
        }
    }
}
