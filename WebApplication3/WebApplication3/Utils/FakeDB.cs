using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplication3.Models;

namespace WebApplication3.Utils
{
    public class FakeDB
    {
        private static readonly Lazy<FakeDB> lazy = new Lazy<FakeDB>(() => new FakeDB());

        public static FakeDB Instance { get { return lazy.Value; } }

        private FakeDB()
        {
            this.InitialiserData();
        }

        public List<Ingredient> IngredientsDisponibles { get; } = new List<Ingredient>();
        public List<Pate> PatesDisponibles { get; } = new List<Pate>();
        public List<Pizza> Pizzas { get; } = new List<Pizza>();

        private void InitialiserData()
        {
            IngredientsDisponibles.AddRange(new List<Ingredient>
                {
                    new Ingredient{Id=1,Nom="Mozzarella"},
                    new Ingredient{Id=2,Nom="Jambon"},
                    new Ingredient{Id=3,Nom="Tomate"},
                    new Ingredient{Id=4,Nom="Oignon"},
                    new Ingredient{Id=5,Nom="Cheddar"},
                    new Ingredient{Id=6,Nom="Saumon"},
                    new Ingredient{Id=7,Nom="Champignon"},
                    new Ingredient{Id=8,Nom="Poulet"}
                });

            PatesDisponibles.AddRange(new List<Pate> 
                {
                 new Pate{ Id=1,Nom="Pate fine, base crême"},
                 new Pate{ Id=2,Nom="Pate fine, base tomate"},
                 new Pate{ Id=3,Nom="Pate épaisse, base crême"},
                 new Pate{ Id=4,Nom="Pate épaisse, base tomate"}
                });
        }
    }
}
