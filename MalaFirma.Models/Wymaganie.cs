using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MalaFirma.Models
{
    public class Wymaganie
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Wymagane jest wpisanie wymagania")]
        public string Nazwa { get; set; }
    }
}
