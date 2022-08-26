using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MalaFirma.Models
{
    public class Dostawca
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Nazwa dostawcy jest wymagana.")]
        [DisplayName("Nazwa dostawcy")]
        public string NazwaDostawcy { get; set; }
        [Required(ErrorMessage = "Adres dostawcy jest wymagany.")]
        [DisplayName("Adres dostawcy")]
        public string AdresDostwacy { get; set; }
        [Required(ErrorMessage = "Zakres dzialalnosci jest wymagany.")]
        [DisplayName("Zakres dzialalnosci")]
        public string ZakresDzialalnosci { get; set; }
        [DisplayName("Data zatwierdzenia")]
        public DateTime DataZatwierdzenia { get; set; } = DateTime.Now;
        [Required(ErrorMessage = "Data wygaśnięcia jest wymagana.")]
        [DisplayName("Data wygaśnięcia")]
        public DateTime DataWygasniecia { get; set; } = DateTime.Now;
        public string? Uwagi { get; set; }
    }
}
