using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MalaFirma.Models
{
    public class NarzedzieTypVM
    {
        public Narzedzie Narzedzie { get; set; }
        [ValidateNever]
        public IEnumerable<SelectListItem> TypNarzedzi { get; set; }
        [ValidateNever]
        public ObslugaMetrologiczna ObslugaMetrologiczna { get; set; }
        public TypNarzedzia TypNarzedzia { get; set; }

    }
}
