using GestContact.Models.Client.Data;
using GestContact.Models.Forms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GestContact.Models.Mappers
{
    internal static class ContactMapper
    {
        internal static DisplayContact ToDisplay(this Contact entity)
        {
            return new DisplayContact() { Id = entity.Id, Nom = entity.Nom, Prenom = entity.Prenom };
        }

        internal static DetailsContact ToDetails(this Contact entity)
        {
            return new DetailsContact() { Id = entity.Id, Nom = entity.Nom, Prenom = entity.Prenom, Email = entity.Email, Tel = entity.Tel };
        }

        internal static EditContactForm ToEditForm(this Contact entity)
        {
            return new EditContactForm() { Id = entity.Id, Nom = entity.Nom, Prenom = entity.Prenom, Email = entity.Email, Tel = entity.Tel };
        }
    }
}