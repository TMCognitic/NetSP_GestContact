using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GestContact.Models.Forms
{
    public class LoginForm
    {
        [Required]
        [EmailAddress]
        [MaxLength(320)]
        public string Email { get; set; }
        [Required]
        [MaxLength(20)]
        [MinLength(8)]
        [DataType(DataType.Password)]
        [RegularExpression(@"^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])(?=.*?[#?!@$%^&*-=]).{8,20}$")]
        [DisplayName("Mot de passe")]
        public string Passwd { get; set; }
    }
}