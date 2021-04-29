using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApplication7.Data;
using WebApplication7.Models;

namespace WebApplication7.Controllers
{
    public class SamouraisController : Controller
    {
        private WebApplication7Context db = new WebApplication7Context();

        // GET: Samourais
        public ActionResult Index()
        {
            return View(db.Samourais.ToList());
        }

        // GET: Samourais/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Samourai samourai = db.Samourais.Find(id);
            if (samourai == null)
            {
                return HttpNotFound();
            }
            return View(samourai);
        }

        // GET: Samourais/Create
        public ActionResult Create()
        {
            SamouraiViewModel vm = new SamouraiViewModel();
            vm.ArtMartiaux = db.ArtMartials.ToList();
            vm.Armes = db.Armes.ToList();
            return View(vm);
        }

        // POST: Samourais/Create
        // Afin de déjouer les attaques par survalidation, activez les propriétés spécifiques auxquelles vous voulez établir une liaison. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(SamouraiViewModel vm)
        {
            if (ModelState.IsValid)
            {
                vm.Samourai.Arme = db.Armes.Find(vm.ArmeId);
                vm.Samourai.ArtMartiaux = db.ArtMartials.Where(am => vm.ArtMartialId.Contains(am.Id)).ToList();
                db.Samourais.Add(vm.Samourai);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            vm.ArtMartiaux = db.ArtMartials.ToList();
            vm.Armes = db.Armes.ToList();
            return View(vm);
        }

        // GET: Samourais/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Samourai samourai = db.Samourais.Find(id);
            if (samourai == null)
            {
                return HttpNotFound();
            }

            SamouraiViewModel vm = new SamouraiViewModel();
            vm.ArtMartiaux = db.ArtMartials.ToList();
            vm.Armes = db.Armes.ToList();
            vm.Samourai = samourai;
            vm.ArmeId = samourai.Arme?.Id;
            vm.ArtMartialId = samourai.ArtMartiaux.Select(x => x.Id).ToList();
            return View(vm);
        }

        // POST: Samourais/Edit/5
        // Afin de déjouer les attaques par survalidation, activez les propriétés spécifiques auxquelles vous voulez établir une liaison. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(SamouraiViewModel vm)
        {
            if (ModelState.IsValid)
            {
                Samourai samourai = db.Samourais.Include(x => x.Arme).SingleOrDefault(x => x.Id == vm.Samourai.Id);
                samourai.ArtMartiaux = db.ArtMartials.Where(am => vm.ArtMartialId.Contains(am.Id)).ToList();
                samourai.Nom = vm.Samourai.Nom;
                samourai.Force = vm.Samourai.Force;
                samourai.Arme = db.Armes.Find(vm.ArmeId);
                db.Entry(samourai).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            vm.ArtMartiaux = db.ArtMartials.ToList();
            vm.Armes = db.Armes.ToList();
            return View(vm);
        }

        // GET: Samourais/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Samourai samourai = db.Samourais.Find(id);
            if (samourai == null)
            {
                return HttpNotFound();
            }
            return View(samourai);
        }

        // POST: Samourais/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Samourai samourai = db.Samourais.Find(id);
            db.Samourais.Remove(samourai);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}