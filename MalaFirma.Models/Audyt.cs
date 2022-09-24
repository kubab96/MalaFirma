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
    public class Audyt
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Temat audytu jest wymagany.")]
        public string Temat { get; set; }
        [Required(ErrorMessage = "Data rozpoczęcia audytu jest wymagana.")]
        [DisplayName("Data rozpoczęcia")]
        [DataType(DataType.Date)]
        public DateTime DataRozpoczecia { get; set; } = DateTime.Now;
        [Required(ErrorMessage = "Data zakończenia audytu jest wymagana.")]
        [DisplayName("Data zakończenia")]
        [DataType(DataType.Date)]
        public DateTime DataZakonczenia { get; set; } = DateTime.Now;
        [DisplayName("Opis niezgodności")]
        public string? Opis { get; set; }
        public string? Status { get; set; }
        public string? Uwagi { get; set; }
        [DisplayName("Termin usunięcia niezgodności")]
        [DataType(DataType.Date)]
        public DateTime? TerminUsuniecia { get; set; }

        [Required(ErrorMessage = "Rodzaj audytu jest wymagany.")]
        [DisplayName("Rodzaj audytu")]
        [EnumDataType(typeof(Rodzaj))]
        public Rodzaj RodzajAudytu { get; set; }
    }
    public enum Rodzaj
    {
        Wewnętrzny = 1,
        Zewnętrzny = 2
    }

}
