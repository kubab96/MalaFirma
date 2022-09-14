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
    public class ZadowolenieKlienta
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Ocena czasu realizacji jest wymagana.")]
        [DisplayName("Czas realizacji")]
        public int CzasRealizacji { get; set; }
        [Required(ErrorMessage = "Ocena jakości realizacji jest wymagana.")]
        [DisplayName("Jakość realizacji")]
        public int Jakosc { get; set; }
        public string Uwagi { get; set; }
        [DisplayName("Data zakończenia zadowolenia")]
        [DataType(DataType.DateTime)]
        public DateTime DataZakonczeniaZadowolenia { get; set; }
        public int? ZamowienieId { get; set; }

        [ValidateNever]
        public Zamowienie Zamowienie { get; set; }
        
        public int KlientId { get; set; }
        [ValidateNever]
        public Klient Klient { get; set; }
    }
}
