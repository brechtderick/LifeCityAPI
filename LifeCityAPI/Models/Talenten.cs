using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LifeCityAPI.Models
{
    public class Talenten
    {
        public int Id { get; set; }

        [Required]
        public string Naam { get; set; }

        public string User { get; set; }

        public Talenten()
        {
        
        }

        public Talenten(string naam) : this()
        {
            Naam = naam;
        }
    }
}
