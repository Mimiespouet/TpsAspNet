using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApplication6.Data;
using WebApplication6.Models;

namespace WebApplication6.Controllers
{
    public class SamouraisController : Controller
    {
        private WebApplication6Context db = new WebApplication6Context();

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
            var samouraivm = new SamouraiViewModel();
            samouraivm.Armes = db.Armes.ToList();
            return View(samouraivm);
        }

        // POST: Samourais/Create
        // Afin de déjouer les attaques par survalidation, activez les propriétés spécifiques auxquelles vous voulez établir une liaison. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(SamouraiViewModel samouraivm)
        {
            if (ModelState.IsValid)
            {
                if (samouraivm.armeId != null)
                {
                    samouraivm.Samourai.Arme = db.Armes.FirstOrDefault(a => a.Id == samouraivm.armeId.Value);
                }
                db.Samourais.Add(samouraivm.Samourai);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            samouraivm.Armes = db.Armes.ToList();
            return View(samouraivm);
        }

        // GET: Samourais/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var samouraivm = new SamouraiViewModel();
            Samourai samourai = db.Samourais.Find(id);
            if (samourai == null)
            {
                return HttpNotFound();
            }
            
            samouraivm.Armes = db.Armes.ToList();
            return View(samouraivm);
        }

        // POST: Samourais/Edit/5
        // Afin de déjouer les attaques par survalidation, activez les propriétés spécifiques auxquelles vous voulez établir une liaison. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(SamouraiViewModel samouraivm)
        {
            if (ModelState.IsValid)
            {
                var samouraiDb = db.Samourais.Find(samouraivm.Samourai.Id);
                samouraiDb.Nom = samouraivm.Samourai.Nom;
                samouraiDb.Force = samouraivm.Samourai.Force;
                samouraiDb.Arme = db.Armes.FirstOrDefault(a => a.Id == samouraivm.armeId);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            samouraivm.Armes = db.Armes.ToList();
            return View(samouraivm);
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
