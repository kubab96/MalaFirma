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
    public class Przeglad
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Wpisz wynik przeglądu.")]
        [DisplayName("Wynik przegladu")]
        public string WynikPrzegladu { get; set; }
        public string? ZidentyfikowaneProblemy { get; set; }
        public string? PlanowaneDzialania { get; set; }
        public int zamowienieId { get; set; }
        [ValidateNever]
        public Zamowienie Zamowienie { get; set; } 
    }
}
