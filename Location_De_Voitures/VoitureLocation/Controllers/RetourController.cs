using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.SqlServer;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VoitureLocation.Models;

namespace VoitureLocation.Controllers
{

    public class RetourController : Controller
    {

        LocationVoituresEntities db = new LocationVoituresEntities();

        // GET: Retour
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult GetVoitureNum(string num)
        {
            var voiture = (from s in db.t_location
                           where s.voiture_num == num
                           select new
                           {
                               voitureNom = s.voiture_num,
                               clientNom = s.client_nom,
                               clientPrenom = s.client_prenom,
                               dateDebut = s.date_debut,
                               dateFin = s.date_fin,
                               fraiLocation = s.frais_location,
                               joursEcoule = SqlFunctions.DateDiff("day", s.date_fin,DateTime.Now )

                           }).ToArray();
            return Json(voiture,JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult Save(t_retour retour)
        {
            if (ModelState.IsValid)
            {
                db.t_retour.Add(retour);

                var car = db.t_voiture.SingleOrDefault(e => e.voiture_num == retour.voiture_num);
                if (car == null)
                {
                    return HttpNotFound("Le numero de voiture n'est pas trouvé");
                }
                // IL REND LA VOITURE DISPONIBLE
                car.disponibilite = "oui";
                db.Entry(car).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("index");
            }

            return View(retour);

        }

    }
}