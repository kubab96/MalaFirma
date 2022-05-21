using System;
using System.Collections.Generic;
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
        public int IdPytania {get; set;}
        public Pytanie Pytanie { get; set; }
    }
}
