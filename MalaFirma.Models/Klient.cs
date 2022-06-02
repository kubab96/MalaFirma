using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MalaFirma.Models
{
    public class Klient
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Nazwa klienta jest wymagana.")]
        [DisplayName("Nazwa klienta")]
        public string NazwaKlienta { get; set; }
        [Required(ErrorMessage = "Kraj klienta jest wymagany.")]
        public string Kraj { get; set; }
        [Required(ErrorMessage = "Miasto klienta jest wymagane.")]
        public string Miasto { get; set; }
        [Required(ErrorMessage = "Ulica oraz numer jest wymagany.")]
        [DisplayName("Ulica oraz numer")]
        public string UlicaNumer { get; set; }
        [Required(ErrorMessage = "Kod pocztowy jest wymagany.")]
        [DisplayName("Kod pocztowy")]
        public string KodPocztowy { get; set; }
    }
}
