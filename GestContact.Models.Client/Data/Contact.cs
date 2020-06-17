using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestContact.Models.Client.Data
{
    public class Contact
    {
        private int _id, _utilisateurId;
        private string _nom, _prenom, _email, _tel;

        public int Id
        {
            get
            {
                return _id;
            }

            private set
            {
                _id = value;
            }
        }        

        public string Nom
        {
            get
            {
                return _nom;
            }

            set
            {
                _nom = value;
            }
        }

        public string Prenom
        {
            get
            {
                return _prenom;
            }

            set
            {
                _prenom = value;
            }
        }

        public string Email
        {
            get
            {
                return _email;
            }

            set
            {
                _email = value;
            }
        }

        public string Tel
        {
            get
            {
                return _tel;
            }

            set
            {
                _tel = value;
            }
        }

        public int UtilisateurId
        {
            get
            {
                return _utilisateurId;
            }

            private set
            {
                _utilisateurId = value;
            }
        }

        public Contact(string nom, string prenom, string email, string tel, int utilisateurId)
        {
            Nom = nom;
            Prenom = prenom;
            Email = email;
            Tel = tel;
            UtilisateurId = utilisateurId;
        }

        internal Contact(int id, string nom, string prenom, string email, string tel, int utilisateurId)
            : this(nom, prenom, email, tel, utilisateurId)
        {
            Id = id;
        }
    }
}
