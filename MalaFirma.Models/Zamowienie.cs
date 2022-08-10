using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
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
    public class Zamowienie
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Nazwa zamówienia jest wymagana")]
        [DisplayName("Nazwa zamówienia")]
        public string Nazwa { get; set; }
        [DisplayName("Data zamówienia")]
        public DateTime DataZamowienia { get; set; } = DateTime.Now;  
        public int KlientId { get; set; }
        [ValidateNever]
        public Klient Klient { get; set; }
        [DisplayName("Uwagi zamówienia")]
        public string? UwagiZamowienia { get; set; }
        public string? StatusZamowienia { get; set; }
    }
}
