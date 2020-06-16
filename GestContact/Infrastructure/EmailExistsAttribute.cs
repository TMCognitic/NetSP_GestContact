using GestContact.Models.Client.Data;
using GestContact.Models.Client.Services;
using GestContact.Repositories;
using System;
using System.ComponentModel.DataAnnotations;

namespace GestContact.Infrastructure
{
    [AttributeUsage(AttributeTargets.Property)]
    public class EmailExistsAttribute : ValidationAttribute
    {
        public EmailExistsAttribute()
        {
            ErrorMessage = "Email déjà utillisée...";
        }
        public override bool IsValid(object value)
        {
            IAuthService<Utilisateur> service = new AuthService();
            return service.EmailIsUsed((string)value);
        }
    }
}