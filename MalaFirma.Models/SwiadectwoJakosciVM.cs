using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MalaFirma.Models
{
    public class SwiadectwoJakosciVM
    {
        [ValidateNever]
        public Zamowienie Zamowienie { get; set; }
        [ValidateNever]
        public SwiadectwoJakosci SwiadectwoJakosci { get; set; }
        [ValidateNever]
        public IEnumerable<SwiadectwoJakosci> SwiadectwaJakosci { get; set; }
        [ValidateNever]
        public IEnumerable<Wymaganie> Wymagania { get; set; }
        [ValidateNever]
        public Wymaganie Wymaganie { get; set; }
        [ValidateNever]
        public IEnumerable<PrzewodnikPracy> PrzewodnikiPracy { get; set; }
        [ValidateNever]
        public PrzewodnikPracy PrzewodnikPracy { get; set; }
        [ValidateNever]
        public IEnumerable<Operacja> Operacje { get; set; }
        [ValidateNever]
        public IEnumerable<Przywieszka> Przywieszki { get; set; }
        [ValidateNever]
        public Przywieszka Przywieszka { get; set; }
        public Przeglad Przeglad { get; set; }
        public IFormFile Rysunek { get; set; }
    }
}
