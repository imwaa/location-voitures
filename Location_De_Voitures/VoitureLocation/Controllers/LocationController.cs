using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VoitureLocation.Models;

namespace VoitureLocation.Controllers
{
    public class LocationController : Controller
    {

        LocationVoituresEntities db = new LocationVoituresEntities();

        // GET: Location
        public ActionResult Index()
        {
            var resultat = (from r in db.t_location
                            join c in db.t_voiture on r.voiture_num equals c.voiture_num
                            select new LocationViewModel
                            {
                                id = r.id,
                                voiture_num = r.voiture_num,
                                marque_modele_voiture = r.marque_modele_voiture,
                                client_nom = r.client_nom,
                                client_prenom = r.client_prenom,
                                frais_location = r.frais_location,
                                date_debut = r.date_debut,
                                date_fin = r.date_fin,
                                disponibilite = c.disponibilite

                            }).ToList();
            return View(resultat);
        }


        /* FONCTION GET QUI NOUS PERMET D'ALLER RECUPERER LA LISTE DE TOUS LES VOITURES ENCODES DANS LA
         * BASE DE DONNES ET QU'ON TRANSFORME EN JSON POUR POUVOIR LE TRAITER AVEC AJAX*/
        [HttpGet]
        public ActionResult GetCar()
        {

            var car = db.t_voiture.ToList();

            return Json(car, JsonRequestBehavior.AllowGet);

        }

        /* FONCTION GET QUI NOUS PERMET D'ALLER RECUPERER LA MARQUE ET LE MODELE DUNE VOITURE A PARTIR DE SON NUMERO
        * QUI SE TROVUENT DANS LA BASE DE DONNES ET QU'ON TRANSFORME EN JSON POUR POUVOIR LE TRAITER AVEC AJAX*/
        [HttpPost]
        public ActionResult GetCarName(string num)
        {

            var marque = (from s in db.t_voiture where s.voiture_num == num select s.voiture_marque).ToList();
            var modele = (from s in db.t_voiture where s.voiture_num == num select s.voiture_modele).ToList();

            var resultat = marque.Concat(modele);
            return Json(resultat, JsonRequestBehavior.AllowGet);

        }


        /* FONCTION GET QUI NOUS PERMET D'ALLER RECUPERER LE PRENOM D'UNE PERSONNE A PARTIR DE SON NOM DE FAMILLE
        * QUI SE TROUVENT DANS LA BASE DE DONNES ET QU'ON TRANSFORME EN JSON POUR POUVOIR LE TRAITER AVEC AJAX*/
        [HttpPost]
        public ActionResult Getid(string name)
        {

            var client = (from s in db.t_client where s.client_nom == name select s.client_prenom).ToList();

            return Json(client, JsonRequestBehavior.AllowGet);

        }

        /* FONCTION GET QUI NOUS PERMET D'ALLER RECUPERER LA DISPONIBILITE D'UNE VOITURE */
        [HttpPost]
        public ActionResult GetDispo(string num)
        {

            var cardispo = (from s in db.t_voiture where s.voiture_num == num select s.disponibilite).FirstOrDefault();

            return Json(cardispo, JsonRequestBehavior.AllowGet);

        }

        /* FONCTION POST QUI NOUS PERMET D'AJOUTER UNE LOCATION DANS LA BASE DE DONNEES*/
        [HttpPost]
        public ActionResult Save(t_location location)
        {
            if (ModelState.IsValid)
            {
                db.t_location.Add(location);

                var car = db.t_voiture.SingleOrDefault(e => e.voiture_num == location.voiture_num);
                if(car == null)
                {
                    return HttpNotFound("Le numero de voiture n'est pas trouvé");
                }

                // IL REND LA VOITURE IN-DISPONIBLE
                car.disponibilite = "non";
                db.Entry(car).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("index");
            }

            return View(location);

        }


    }
}