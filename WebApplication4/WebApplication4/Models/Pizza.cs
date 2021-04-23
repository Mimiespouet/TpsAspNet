using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplication4.ValidationAttributs;

namespace WebApplication4.Models
{
    public class Pizza
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Une pizza doit toujours avoir un nom")]
        [StringLength(20, MinimumLength = 5)]
        public string Nom { get; set; }

        public Pate Pate { get; set; }

        public List<Ingredient> Ingredients { get; set; } = new List<Ingredient>();
    }
}
