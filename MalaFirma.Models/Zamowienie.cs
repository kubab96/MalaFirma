using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MalaFirma.Models
{
    public class Zamowienie
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Data zamówienia jest wymagana")]
        [DisplayName("Data zamówienia")]
        public DateTime DataZamowienia { get; set; } = DateTime.Now;  
        [Required(ErrorMessage ="Opis zamówienia jest wymagany")]
        [DisplayName("Opis zamówienia")]
        public string OpisZamowienia { get; set; }
        [DisplayName("Uwagi zamówienia")]
        public string UwagiZamowienia { get; set; }
    }
}
