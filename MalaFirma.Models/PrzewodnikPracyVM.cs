using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MalaFirma.Models
{
    public class PrzewodnikPracyVM
    {
        [ValidateNever]
        public IEnumerable<Proces> Procesy { get; set; }
        [ValidateNever]
        public Proces Proces { get; set; }
        [ValidateNever]
        public Zamowienie Zamowienie { get; set; }
        [ValidateNever]
        public PrzewodnikPracy PrzewodnikPracy { get; set; }
        [ValidateNever]
        public IEnumerable<PrzewodnikPracy> PrzewodnikiPracy { get; set; }
        [ValidateNever]
        public IEnumerable<Operacja> Operacje { get; set; }
        [ValidateNever]
        public Operacja Operacja { get; set; }
        [ValidateNever]
        public IFormFile Rysunek { get; set; }
    }
}
