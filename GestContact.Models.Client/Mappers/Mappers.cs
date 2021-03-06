﻿using GestContact.Models.Client.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

using G = GestContact.Models.Global.Data;

namespace GestContact.Models.Client.Mappers
{
    internal static class Mappers
    {
        #region Mappers Utilisateur
        internal static G.Utilisateur ToGlobal(this Utilisateur entity)
        {
            return new G.Utilisateur() { Id = entity.Id, Nom = entity.Nom, Prenom = entity.Prenom, Email = entity.Email, Passwd = entity.Passwd };
        }

        internal static Utilisateur ToClient(this G.Utilisateur entity)
        {
            return new Utilisateur(entity.Id, entity.Nom, entity.Prenom, entity.Email);
        }
        #endregion

        #region Mappers Contact
        internal static G.Contact ToGlobal(this Contact entity)
        {
            return new G.Contact() { Id = entity.Id, Nom = entity.Nom, Prenom = entity.Prenom, Email = entity.Email, Tel = entity.Tel, UtilisateurId = entity.UtilisateurId };
        }

        internal static Contact ToClient(this G.Contact entity)
        {
            return new Contact(entity.Id, entity.Nom, entity.Prenom, entity.Email, entity.Tel, entity.UtilisateurId);
        }
        #endregion
    }
}
