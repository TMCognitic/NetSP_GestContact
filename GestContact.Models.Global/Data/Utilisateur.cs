using System;
using System.Collections.Generic;
using System.Text;

namespace GestContact.Models.Global.Data
{
    public class Utilisateur
    {
        public int Id { get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public string Email { get; set; }
        public string Passwd { get; set; }
    }
}
