using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LifeCityAPI.Models
{
    public class Emotieregulatie
    {
        public int Id { get; set; }

        [Required]
        public string Beschrijving { get; set; }

        public DateTime DateAdded { get; set; }

        public string User { get; set; }

        public string Emoties { get; set; }
        

        public Emotieregulatie()
        {
            DateAdded = DateTime.Now;
            Emoties = Emoties;
        }

        public Emotieregulatie(string beschrijving) : this()
        {
            Beschrijving = beschrijving;
        }
    }
}
