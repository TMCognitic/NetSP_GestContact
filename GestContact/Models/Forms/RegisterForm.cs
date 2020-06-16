using GestContact.Infrastructure;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GestContact.Models.Forms
{
    public class RegisterForm
    {
        [Required]
        [MaxLength(50)]
        public string Nom { get; set; }
        [Required]
        [MaxLength(50)]
        public string Prenom { get; set; }
        [Required]
        [EmailAddress]
        [MaxLength(320)]
        [EmailExists(ErrorMessage="Email already exists...")]
        public string Email { get; set; }
        [Required]
        [MaxLength(20)]
        [MinLength(8)]
        [DisplayName("Mot de passe")]
        [RegularExpression(@"^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])(?=.*?[#?!@$%^&*-=]).{8,20}$")]
        [DataType(DataType.Password)]
        public string Passwd { get; set; }
        [Compare(nameof(Passwd))]
        [DisplayName("Vérification")]
        [DataType(DataType.Password)]
        public string Confirm { get; set; }
    }
}