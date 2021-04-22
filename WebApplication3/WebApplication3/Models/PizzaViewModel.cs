using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace WebApplication3.Models
{
    public class PizzaViewModel
    {
        public int? Id { get; set; }
        public int? PateId { get; set; }
        public List<int> IngredientId { get; set; } = new List<int>();

        public Pizza Pizza { get; set; }
        public List<SelectListItem> Ingredients { get; set; } = new List<SelectListItem>();
        public List<SelectListItem> Pates { get; set; } = new List<SelectListItem>();
    }
}
