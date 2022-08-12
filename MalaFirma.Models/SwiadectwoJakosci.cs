using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MalaFirma.Models
{
    public class SwiadectwoJakosci
    {
        [Key]
        public int Id { get; set; }
        public string? NumerSwiadectwa { get; set; }
        public int? ZamowienieId { get; set; }
        public Zamowienie Zamowienie { get; set; }
    }
}
