using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace VoitureLocation.Models
{
    [MetadataType(typeof(clientMetaData))]

    public partial class t_client
    {
       
        public class clientMetaData
        {

            [DisplayName("Nom")]
            public string client_nom { get; set; }

            [DisplayName("Prenom")]
            public string client_prenom { get; set; }

            [DisplayName("Numero d'identité")]
            public string client_num_identite { get; set; }

            [DisplayName("Adresse")]
            public string client_adresse { get; set; }

            [DisplayName("GSM")]
            public Nullable<int> client_mobile { get; set; }
        }


    }
}