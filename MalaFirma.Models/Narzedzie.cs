using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MalaFirma.Models
{
    public class Narzedzie
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Nazwa narzędzia/wyposażenia jest wymagana.")]
        [DisplayName("Nazwa")]
        public string Nazwa { get; set; }
        [ValidateNever]
        [DisplayName("Numer identyfikacyjny")]
        public string NumerIdentyfikacyjny { get; set; }
        [Required(ErrorMessage = "Numer fabryczny jest wymagany.")]
        [DisplayName("Numer fabryczny")]
        public string NumerFabryczny { get; set; }
        [Required(ErrorMessage = "Wymagane jest podanie czy narzędzie/wyposażenie jest poddawane obsłudze metorologicznej.")]
        [DisplayName("Obsługa Metrologiczna")]
        public bool ObslugaMetrologiczna { get; set; }
        public string Status { get; set; }
        [DisplayName("Typ narzędzia")]
        [Required(ErrorMessage = "Wymagane jest podanie typu narzędzia.")]
        public int TypNarzedziaId { get; set; }
        [ForeignKey("TypNarzedziaId")]
        [ValidateNever]
        public TypNarzedzia TypNarzedzia { get; set; }
    }
}
