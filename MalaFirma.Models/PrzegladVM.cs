using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleQMS.Models
{
    public class PrzegladVM
    {
        public IEnumerable<Pytanie> Pytania { get; set; }
        public IEnumerable<Odpowiedz> Odpowiedzi { get; set; }
        public IEnumerable<Zamowienie> Zamowienia{ get; set; }
        [ValidateNever]
        public IEnumerable<Wymaganie> Wymagania { get; set; }
        [ValidateNever]
        public IEnumerable<Przeglad> Przeglady { get; set; }
        [ValidateNever]
        public Wymaganie Wymaganie { get; set; }
        public Odpowiedz Odpowiedz { get; set; }
        public Pytanie Pytanie { get; set; }
        public Zamowienie Zamowienie { get; set; }
        public Przeglad Przeglad { get; set; }
    }
}
