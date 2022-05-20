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
    public class Proces
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }
        [Required(ErrorMessage = "Nazwa zamówienia jest wymagana")]
        [DisplayName("Nazwa zamówienia")]
        public string Nazwa { get; set; }
        [Required(ErrorMessage = "Wymagane jest wpisanie wymagania")]
        public string Wymaganie { get; set; }
        public int ZamowienieId { get; set; }
        public Zamowienie Zamowienie { get; set; }
    }
}
