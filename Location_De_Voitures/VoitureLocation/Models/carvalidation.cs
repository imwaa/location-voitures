using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace VoitureLocation.Models
{
    [MetadataType(typeof(carMetaData))]

    public partial class t_voiture
    {

        public class carMetaData
        {

            [DisplayName("Numero de voiture")]
            public string voiture_num { get; set; }

            [DisplayName("Marque")]
            public string voiture_marque { get; set; }

            [DisplayName("Modele")]
            public string voiture_modele { get; set; }

            [DisplayName("Plaque d'immatriculation")]
            public string voiture_immatriculation { get; set; }

            [DisplayName("Disponibilite")]
            public string disponibilite { get; set; }


        }
    }
}