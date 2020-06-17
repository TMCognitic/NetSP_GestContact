using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GestContact.Models.Forms
{
    public class DetailsContact
    {
        public int Id { get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public string Email { get; set; }
        public string Tel { get; set; }

    }
}