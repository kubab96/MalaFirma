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
        public IEnumerable<Proces> Procesy { get; set; }
        [ValidateNever]
        public Proces Proces { get; set; }
        [ValidateNever]
        public Zamowienie Zamowienie { get; set; }
    }
}
