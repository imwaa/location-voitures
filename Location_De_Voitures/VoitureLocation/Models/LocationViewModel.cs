using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VoitureLocation.Models
{
    public class LocationViewModel
    {


        public int id { get; set; }
        public string voiture_num { get; set; }
        public string marque_modele_voiture { get; set; }
        public string client_nom { get; set; }
        public string client_prenom { get; set; }
        public string frais_location { get; set; }
        public Nullable<System.DateTime> date_debut { get; set; }
        public Nullable<System.DateTime> date_fin { get; set; }
        public string disponibilite { get; set; }

    }
}