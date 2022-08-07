using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MalaFirma.Models
{
    public class KartaProjektuVM
    {
        public IEnumerable<Proces> Procesy { get; set; }
        public IEnumerable<Przeglad> Przeglady { get; set; }
        [ValidateNever]
        public Proces Proces { get; set; }
        [ValidateNever]
        public Zamowienie Zamowienie { get; set; }
        public Przeglad Przeglad { get; set; }
        public KartaProjektu KartaProjektu { get; set; }
    }
}
