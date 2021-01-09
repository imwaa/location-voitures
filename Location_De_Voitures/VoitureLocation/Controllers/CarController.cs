using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using VoitureLocation.Models;

namespace VoitureLocation.Controllers
{
    public class CarController : Controller
    {
        private LocationVoituresEntities db = new LocationVoituresEntities();

        // GET: Car
        public ActionResult Index()
        {
            return View(db.t_voiture.ToList());
        }

        // GET: Car/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            t_voiture t_voiture = db.t_voiture.Find(id);
            if (t_voiture == null)
            {
                return HttpNotFound();
            }
            return View(t_voiture);
        }

        // GET: Car/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Car/Create
        // Afin de déjouer les attaques par survalidation, activez les propriétés spécifiques auxquelles vous voulez établir une liaison. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,voiture_num,voiture_marque,voiture_modele,voiture_immatriculation,disponibilite")] t_voiture t_voiture)
        {
            if (ModelState.IsValid)
            {
                db.t_voiture.Add(t_voiture);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(t_voiture);
        }

        // GET: Car/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            t_voiture t_voiture = db.t_voiture.Find(id);
            if (t_voiture == null)
            {
                return HttpNotFound();
            }
            return View(t_voiture);
        }

        // POST: Car/Edit/5
        // Afin de déjouer les attaques par survalidation, activez les propriétés spécifiques auxquelles vous voulez établir une liaison. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,voiture_num,voiture_marque,voiture_modele,voiture_immatriculation,disponibilite")] t_voiture t_voiture)
        {
            if (ModelState.IsValid)
            {
                db.Entry(t_voiture).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(t_voiture);
        }

        // GET: Car/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            t_voiture t_voiture = db.t_voiture.Find(id);
            if (t_voiture == null)
            {
                return HttpNotFound();
            }
            return View(t_voiture);
        }

        // POST: Car/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            t_voiture t_voiture = db.t_voiture.Find(id);
            db.t_voiture.Remove(t_voiture);
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
