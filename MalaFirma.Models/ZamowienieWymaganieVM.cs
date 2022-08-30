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
    public class ZamowienieWymaganieVM
    {

        public Zamowienie Zamowienie { get; set; }
        [ValidateNever]
        public IEnumerable<Wymaganie> Wymagania { get; set; }
        [ValidateNever]
        public Wymaganie Wymaganie { get; set; }
        [ValidateNever]
        public IEnumerable<SelectListItem> Klienci { get; set; }
        [ValidateNever]
        public Klient Klient { get; set; }
        [ValidateNever]
        public IEnumerable<KartaProjektu> KartyProjektu { get; set; }
        [ValidateNever]
        public KartaProjektu KartaProjektu { get; set; }
        [ValidateNever]
        public IEnumerable<PrzewodnikPracy> PrzewodnikiPracy { get; set; }
        [ValidateNever]
        public PrzewodnikPracy PrzewodnikPracy { get; set; }
        [ValidateNever]
        public Przeglad Przeglad { get; set; }
    }
}
