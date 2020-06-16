using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestContact.Models.Client.Data
{
    public class Utilisateur
    {
        private int _id;
        private string _nom, _prenom, _email, passwd;

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

            private set
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

            private set
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

        public string Passwd
        {
            get
            {
                return passwd;
            }

            private set
            {
                passwd = value;
            }
        }

        public Utilisateur(string nom, string prenom, string email, string passwd)
        {
            Nom = nom;
            Prenom = prenom;
            Email = email;
            Passwd = passwd;
        }

        internal Utilisateur(int id, string nom, string prenom, string email)
        {
            Id = id;
            Nom = nom;
            Prenom = prenom;
            Email = email;
        }
    }
}
