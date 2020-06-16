using GestContact.Models.Client.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GestContact.Infrastructure
{
    public static class SessionManager
    {
        public static Utilisateur User
        { 
            get { return (Utilisateur)HttpContext.Current.Session[nameof(User)]; }
            set { HttpContext.Current.Session[nameof(User)] = value; }
        }

        public static void Abandon()
        {
            HttpContext.Current.Session.Abandon();
        }
    }
}