using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MalaFirma.Models
{
    public class Odpowiedz
    {
        [Key]
        public int Id { get; set; }
        public bool Wartosc { get; set; }
        public string Status { get; set; }
        [Required(ErrorMessage = "Data przegladu jest wymagana")]
        [DisplayName("Data przegladu")]
        public DateTime DataPrzegladu { get; set; } = DateTime.Now;
        [DisplayName("Wymagane Działania")]
        public string? WymaganeDzialania { get; set; }
        public int PytanieId { get; set;}
        public Pytanie Pytanie { get; set; }
        public int PrzegladId { get; set; }
        public Przeglad Przeglad { get; set; }
    }
}
