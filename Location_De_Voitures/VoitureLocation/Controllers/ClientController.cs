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
    public class ClientController : Controller
    {
        private LocationVoituresEntities db = new LocationVoituresEntities();

        // GET: Client
        public ActionResult Index()
        {
            return View(db.t_client.ToList());
        }

        // GET: Client/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            t_client t_client = db.t_client.Find(id);
            if (t_client == null)
            {
                return HttpNotFound();
            }
            return View(t_client);
        }

        // GET: Client/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Client/Create
        // Afin de déjouer les attaques par survalidation, activez les propriétés spécifiques auxquelles vous voulez établir une liaison. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,client_nom,client_prenom,client_num_identite,client_adresse,client_mobile")] t_client t_client)
        {
            if (ModelState.IsValid)
            {
                db.t_client.Add(t_client);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(t_client);
        }

        // GET: Client/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            t_client t_client = db.t_client.Find(id);
            if (t_client == null)
            {
                return HttpNotFound();
            }
            return View(t_client);
        }

        // POST: Client/Edit/5
        // Afin de déjouer les attaques par survalidation, activez les propriétés spécifiques auxquelles vous voulez établir une liaison. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,client_nom,client_prenom,client_num_identite,client_adresse,client_mobile")] t_client t_client)
        {
            if (ModelState.IsValid)
            {
                db.Entry(t_client).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(t_client);
        }

        // GET: Client/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            t_client t_client = db.t_client.Find(id);
            if (t_client == null)
            {
                return HttpNotFound();
            }
            return View(t_client);
        }

        // POST: Client/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            t_client t_client = db.t_client.Find(id);
            db.t_client.Remove(t_client);
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
