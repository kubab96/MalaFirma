using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;
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
    public class ZamowienieProcesVM
    {

        public Zamowienie Zamowienie { get; set; }
        [ValidateNever]
        public IEnumerable<Proces> Procesy { get; set; }
        [ValidateNever]
        public Proces Proces { get; set; }
        [ValidateNever]
        public IEnumerable<SelectListItem> Klienci { get; set; }
        [ValidateNever]
        public Klient Klient { get; set; }
    }
}
