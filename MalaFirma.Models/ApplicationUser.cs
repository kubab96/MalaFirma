using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleQMS.Models
{
    public class ApplicationUser : IdentityUser
    {
        [Required(ErrorMessage = "Imię jest wymagane.")]
        public string Imie { get; set; }
        [Required(ErrorMessage = "Nazwisko jest wymagane.")]
        public string Nazwisko { get; set; }
        public string Kraj { get; set; }
        [Required(ErrorMessage = "Miasto klienta jest wymagane.")]
        public string Miasto { get; set; }
        [Required(ErrorMessage = "Ulica oraz numer jest wymagany.")]
        [DisplayName("Ulica oraz numer")]
        public string UlicaNumer { get; set; }
        [Required(ErrorMessage = "Kod pocztowy jest wymagany.")]
        [DisplayName("Kod pocztowy")]
        public string KodPocztowy { get; set; }
        public List<IdentityUserRole<string>> Roles { get; set; }
    }
}
