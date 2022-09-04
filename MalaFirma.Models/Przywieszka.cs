using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MalaFirma.Models
{
    public class Przywieszka
    {
        public int Id { get; set; }
        public string? Rysunek { get; set; }
        public string? NumerPrzywieszki { get; set; }
        public int SwiadectwoJakosciId { get; set; }
        [ValidateNever]
        public SwiadectwoJakosci SwiadectwoJakosci { get; set; }
    }
}
