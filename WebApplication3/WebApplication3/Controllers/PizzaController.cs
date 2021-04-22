using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication3.Models;
using WebApplication3.Utils;

namespace WebApplication3.Controllers
{
    public class PizzaController : Controller
    {
        // GET: Pizza
        public ActionResult Index()
        {
            return View(FakeDB.Instance.Pizzas);
        }

        // GET: Pizza/Details/5
        public ActionResult Details(int id)
        {
            return View(FakeDB.Instance.Pizzas.FirstOrDefault(p => p.Id == id));
        }

        // GET: Pizza/Create
        public ActionResult Create()
        {
            PizzaViewModel pizzaView = new PizzaViewModel();
            pizzaView.Pates = FakeDB.Instance.PatesDisponibles.Select(pa => new SelectListItem() { Text = pa.Nom, Value = pa.Id.ToString() }).ToList();
            pizzaView.Ingredients = FakeDB.Instance.IngredientsDisponibles.Select(pa => new SelectListItem() { Text = pa.Nom, Value = pa.Id.ToString() }).ToList();
            return View(pizzaView);
        }

        // POST: Pizza/Create
        [HttpPost]
        public ActionResult Create(PizzaViewModel pizza, FormCollection collection)
        {
            try
            {
                pizza.Pizza.Pate = FakeDB.Instance.PatesDisponibles.Where(pa => pa.Id == pizza.PateId).FirstOrDefault();
                pizza.Pizza.Ingredients = FakeDB.Instance.IngredientsDisponibles.Where(i => pizza.IngredientId.Contains(i.Id)).ToList();

                FakeDB.Instance.Pizzas.Add(pizza.Pizza);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Pizza/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Pizza/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Pizza/Delete/5
        public ActionResult Delete(int id)
        {
            return View(FakeDB.Instance.Pizzas.FirstOrDefault(p => p.Id == id));
        }

        // POST: Pizza/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                FakeDB.Instance.Pizzas.Remove(FakeDB.Instance.Pizzas.FirstOrDefault(p => p.Id == id));
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
