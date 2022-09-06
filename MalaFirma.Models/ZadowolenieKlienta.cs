using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MalaFirma.Models
{
    public class ZadowolenieKlienta
    {
        [Key]
        public int Id { get; set; }
        public int CzasRealizacji { get; set; }
        public int Jakosc { get; set; }
        public string Uwagi { get; set; }
        
        public int? ZamowienieId { get; set; }

        [ValidateNever]
        public Zamowienie Zamowienie { get; set; }
        
        public int KlientId { get; set; }
        [ValidateNever]
        public Klient Klient { get; set; }
    }
}
