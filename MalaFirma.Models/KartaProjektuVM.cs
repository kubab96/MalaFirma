using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleQMS.Models
{
    public class KartaProjektuVM
    {
        public IEnumerable<Wymaganie> Wymagania { get; set; }
        public IEnumerable<Przeglad> Przeglady { get; set; }
        public IEnumerable<PrzewodnikPracy> Przewodniki { get; set; }
        public IEnumerable<SwiadectwoJakosci> Swiadectwa { get; set; }
        [ValidateNever]
        public Wymaganie Wymaganie { get; set; }
        [ValidateNever]
        public Zamowienie Zamowienie { get; set; }
        public Przeglad Przeglad { get; set; }
        public KartaProjektu KartaProjektu { get; set; }
    }
}
