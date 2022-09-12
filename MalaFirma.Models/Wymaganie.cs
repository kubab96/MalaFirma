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
    public class Wymaganie
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }
        [Required(ErrorMessage = "Nazwa wymagania do wykonania jest wymagana.")]
        [DisplayName("Nazwa wymagania")]
        public string Nazwa { get; set; }
        [Required(ErrorMessage = "Opis wymagania do wykonania jest wymagany.")]
        public string Opis { get; set; }
        [DisplayName("Ilość")]
        public int? Ilosc { get; set; }
        [DisplayName("Materiał")]
        public string? Material { get; set; }
        public int ZamowienieId { get; set; }
        [ValidateNever]
        public Zamowienie Zamowienie { get; set; }

    }
}
