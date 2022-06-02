using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MalaFirma.Models
{
    public class Przeglad
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Wpisz wynik przeglądu.")]
        [DisplayName("Wynik przegladu")]
        public string WynikPrzegladu { get; set; }
        public int zamowienieId { get; set; }
        public Zamowienie Zamowienie { get; set; } 
    }
}
