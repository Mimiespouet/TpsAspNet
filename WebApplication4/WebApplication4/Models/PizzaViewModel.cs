using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using WebApplication4.ValidationAttributs;

namespace WebApplication4.Models
{
    public class PizzaViewModel
    {
        [ValidationName]
        public Pizza Pizza { get; set; }
        public List<Pate> Pates { get; set; }
        public List<SelectListItem> Ingredients { get; set; }

        [Required(ErrorMessage = "Une pizza doit avoir entre 2 et 5 ingrédients.")]
        [ValidationIngredientList]
        public List<int> IngredientIds { get; set; }
    }
}
