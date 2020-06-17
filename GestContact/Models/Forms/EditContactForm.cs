using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GestContact.Models.Forms
{
    public class EditContactForm
    {
        [HiddenInput]
        public int Id { get; set; }
        [Required]
        [MaxLength(50)]
        public string Nom { get; set; }
        [Required]
        [MaxLength(50)]
        public string Prenom { get; set; }
        [Required]
        [EmailAddress]
        [MaxLength(320)]
        public string Email { get; set; }
        [Required]
        //[RegularExpression(@"^(+32|0)\d{8,9}$", ErrorMessage = "Format de numéro de téléphone invalide (ex : +32477000000, 020000000)")]
        public string Tel { get; set; }
    }
}