using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MalaFirma.Models
{
    public class PrzewodnikPracy
    {
        [Key]
        public int Id { get; set; }
        public string? NumerPrzewodnika { get; set; }
        public int? ZamowienieId { get; set; }
        public Zamowienie Zamowienie { get; set; }
        public int? ProcesId { get; set; }
        public Proces Proces { get; set; }
        public string? StatusPrzewodnika { get; set; }
        public string? Rysunek { get; set; }
    }
}
